//tabs=4
// --------------------------------------------------------------------------------
// TODO fill in this information for your driver, then remove this line!
//
// ASCOM Dome driver for AstroHaven
//
// Description:	Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam 
//				nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam 
//				erat, sed diam voluptua. At vero eos et accusam et justo duo 
//				dolores et ea rebum. Stet clita kasd gubergren, no sea takimata 
//				sanctus est Lorem ipsum dolor sit amet.
//
// Implements:	ASCOM Dome interface version: <To be completed by driver developer>
// Author:		(XXX) Your N. Here <your@email.here>
//
// Edit Log:
//
// Date			Who	Vers	Description
// -----------	---	-----	-------------------------------------------------------
// dd-mmm-yyyy	XXX	6.0.0	Initial edit, created from ASCOM driver template
// --------------------------------------------------------------------------------
//


// This is used to define code in the template that is specific to one class implementation
// unused code canbe deleted and this definition removed.
#define Dome

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;

using ASCOM;
using ASCOM.Astrometry;
using ASCOM.Astrometry.AstroUtils;
using ASCOM.Utilities;
using ASCOM.DeviceInterface;
using System.Globalization;
using System.Collections;

namespace ASCOM.AstroHaven
{
    //
    // The Guid attribute sets the CLSID for ASCOM.AstroHaven.Dome
    // The ClassInterface/None addribute prevents an empty interface called
    // _AstroHaven from being created and used as the [default] interface
    //

    /// <summary>
    /// ASCOM Dome Driver for AstroHaven Clamshell Domes
    /// </summary>
    [Guid("d580e911-dfe8-48ab-8d97-e08a1614506e")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Dome : IDomeV2
    {
        /// <summary>
        /// ASCOM DeviceID (COM ProgID) for this driver.
        /// The DeviceID is used by ASCOM applications to load the driver at runtime.
        /// </summary>
        internal static string DriverID = "ASCOM.AstroHaven.Dome";

        /// <summary>
        /// Driver description that displays in the ASCOM Chooser.
        /// </summary>
        private static string _driverDescription = "ASCOM Dome Driver for AstroHaven.";

        internal const string 
                PROFILENAME_COMPORT= "COMPort",
                PROFILENAME_BAUD = "Baud",
                PROFILENAME_ENABLELOGGING = "TraceLevel",
                PROFILE_NAME_MINDELAYBETWEENCMDS = "MinDelayBetweenCommands",
                PROFILENAME_LOOSEBELTPROTECTION = "LooseBeltProtection",
                PROFILENAME_LOOSEBELTPROTECTION_THRESHOLD_LEFT = "LooseBeltProtectionThresholdLeft",
                PROFILENAME_LOOSEBELTPROTECTION_THRESHOLD_RIGHT = "LooseBeltProtectionThresholdRight"
                ;

        // Currrent device configuration
        //
        internal static string ComPort; 
        internal static int Baud; 

        //
        internal string LastStatus = string.Empty;

        /// <summary>
        /// ASCOM Utilities object
        /// </summary>
        private Util _utils;

        /// <summary>
        /// ASCOM AstroUtilities object to provide the Range method
        /// </summary>
        private AstroUtils _astroUtils;

        /// <summary>
        /// Reference to the hardware class (most likely an arduino)
        /// </summary>
        private ArduinoSerial _arduino;

        /// <summary>
        /// Lock for managing race condition on trace logger object 
        /// </summary>
        public static bool _Lock = true;

        /// <summary>
        /// Logger identifier
        /// </summary>
        private const string LOGGER = "Dome";

        /// <summary>
        /// Logger instance (private field)
        /// </summary>
        private static TraceLogger _Logger = null;

        /// <summary>
        /// Logger instance
        /// </summary>
        internal static TraceLogger Logger
        {
            get
            {
                //lock (this)
                //{
                    if (_Logger == null) _Logger = new TraceLogger(string.Empty, "AstroHaven");
                //}
                return _Logger;
            }
        }

        /// <summary>
        /// If True, enable Anti-Loose belt protection on panel opening by pausing a bit 
        /// at the beginning of the opening of a panel
        /// </summary>
        public static bool EnableLooseBeltProtection { get; internal set; }

        /// <summary>
        /// Minimum delay in milliseconds between each commmand sent to the dome hardware
        /// </summary>
        public static int MinDelayBtwnCommands { get; internal set; }

        /// <summary>
        /// Authorized device-specific actions
        /// </summary>
        internal const string
            ACTION_GET_STATUS = "ACTION_GET_STATUS",
            ACTION_LASTSTATUS = "ACTION_LAST_STATUS",

            ACTION_OPEN_LEFT = "ACTION_OPEN_LEFT",
            ACTION_OPEN_RIGHT = "ACTION_OPEN_RIGHT",

            ACTION_CLOSE_LEFT = "ACTION_CLOSE_LEFT",
            ACTION_CLOSE_RIGHT = "ACTION_CLOSE_RIGHT",

            ACTION_OPEN_BOTH = "ACTION_OPEN_BOTH",
            ACTION_CLOSE_BOTH = "ACTION_CLOSE_BOTH"
           ;

        public static readonly bool DEFAULT_LOOSEBELT_PROTECTION = true;
        public static readonly int DEFAULT_MINDELAYBETWEENCOMMANDS = 250; //milliseconds

        public static readonly int DEFAULT_LOOSEBELT_PROTECTION_THRESHOLD = 5; // number of commands sent before we can safely open a panel
        public static int LeftPanelBeltProtectionThreshold { get; internal set; }  = DEFAULT_LOOSEBELT_PROTECTION_THRESHOLD;
        public static int RightPanelBeltProtectionThreshold { get; internal set; } = DEFAULT_LOOSEBELT_PROTECTION_THRESHOLD;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dome"/> class.
        /// Must be public for COM registration.
        /// </summary>
        public Dome()
        {
            ReadProfile(); // Read device configuration from the ASCOM Profile store

            Logger.LogMessage(LOGGER, "Starting initialisation");

            _IsConnected = false; // Initialise connected to false
            _utils = new Util(); //Initialise util object
            _astroUtils = new AstroUtils(); // Initialise astro utilities object

            Logger.LogMessage(LOGGER, "Completed initialisation");
        }

        #region Serial

        /// <summary>
        /// Attempts to connect to the hardware given the com port and baud from profile
        /// </summary>
        /// <returns>True if connection succeeded</returns>
        private bool ConnectDome()
        {
            bool success = false;
            try
            {
                _arduino = new ArduinoSerial(Dome.ComPort, Dome.Baud);
                _arduino.OnReplyReceived += new ArduinoSerial.ReplyReceivedEventHandler(onReplyReceived);
                _utils.WaitForMilliseconds(2000);

                success = true;
            } catch(Exception exc)
            {
                Logger.LogIssue(LOGGER, "Failed to connect to dome : " + exc.Message);
            }
            return success;
        }

        /// <summary>
        /// Event handler called when a reply has been received from hardware
        /// </summary>
        private void onReplyReceived(object sender, EventArgs e)
        {
            // We just read the last character from the replied string and assume it's the current dome status
            LastStatus = String.IsNullOrEmpty(_arduino.LastReceivedChar) ? "?" : _arduino.LastReceivedChar;
        }

        /// <summary>
        /// Attempts to disconnect from hardware
        /// </summary>
        /// <returns>True if successfully disconnected from dome</returns>
        private bool DisconnectDome()
        {
            if ((_arduino != null) && (_arduino.IsOpen)) {
                try
                {
                    _arduino.Close();
                }
                catch (Exception exc)
                {
                    Logger.LogIssue(LOGGER, "Failed to disconnect from dome : " + exc.Message);

                    return false;
                }
            }
           
            return true;
        }


        #endregion


        //
        // PUBLIC COM INTERFACE IDomeV2 IMPLEMENTATION
        //

        #region Common properties and methods.

        /// <summary>
        /// Displays the Setup Dialog form.
        /// If the user clicks the OK button to dismiss the form, then
        /// the new settings are saved, otherwise the old values are reloaded.
        /// THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
        /// </summary>
        public void SetupDialog()
        {
            // consider only showing the setup dialog if not connected
            // or call a different dialog if connected
            if (_IsConnected)
                System.Windows.Forms.MessageBox.Show("Already connected, just press OK");

            using (SetupDialogForm F = new SetupDialogForm())
            {
                var result = F.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    WriteProfile(); // Persist device configuration values to the ASCOM Profile store
                }
            }
        }

        /// <summary>
        /// Returns a list of supported action codes that ASCOM clients can call
        /// </summary>
        public ArrayList SupportedActions
        {
            get
            {
                //tl.LogMessage("SupportedActions Get", "Returning empty arraylist");
                var actions = new ArrayList();
                actions.Add(ACTION_GET_STATUS);
                actions.Add(ACTION_LASTSTATUS);

                actions.Add(ACTION_OPEN_LEFT);
                actions.Add(ACTION_OPEN_RIGHT);

                actions.Add(ACTION_CLOSE_LEFT);
                actions.Add(ACTION_CLOSE_RIGHT);

                actions.Add(ACTION_OPEN_BOTH);
                actions.Add(ACTION_CLOSE_BOTH);

                return actions;
            }
        }


        public string Action(string actionName, string actionParameters)
        {
            switch (actionName)
            {
                case ACTION_GET_STATUS:
                    CommandBlind(ArduinoSerial.COMMAND_GET_STATUS, false);
                    _utils.WaitForMilliseconds(100);
                    return LastStatus;

                case ACTION_LASTSTATUS:
                    if (String.IsNullOrEmpty(LastStatus))
                        return Action(ACTION_GET_STATUS, string.Empty);
                    else
                        return LastStatus;

                case ACTION_OPEN_LEFT:
                    CommandBlind(ArduinoSerial.COMMAND_OPEN_LEFT, false);
                    break;
                case ACTION_OPEN_RIGHT:
                    CommandBlind(ArduinoSerial.COMMAND_OPEN_RIGHT, false);
                    break;

                case ACTION_CLOSE_LEFT:
                    CommandBlind(ArduinoSerial.COMMAND_CLOSE_LEFT, false);
                    break;
                case ACTION_CLOSE_RIGHT:
                    CommandBlind(ArduinoSerial.COMMAND_CLOSE_RIGHT, false);
                    break;

                case ACTION_OPEN_BOTH:
                    CommandBlind(ArduinoSerial.COMMAND_OPEN_BOTH, false);
                    break;
                case ACTION_CLOSE_BOTH:
                    CommandBlind(ArduinoSerial.COMMAND_CLOSE_BOTH, false);
                    break;

                default:
                    LogMessage(string.Empty, "Action {0}, parameters {1} not implemented", actionName, actionParameters);
                    throw new ASCOM.ActionNotImplementedException("Action " + actionName + " is not implemented by this driver");

            }

            return String.Empty;

        }

        public void CommandBlind(string command, bool raw)
        {
            requiresConnected("CommandBlind");

            if (_arduino == null) return;

            if (
                // we want to open left panel
                ((command == ACTION_OPEN_BOTH) || (command == ACTION_OPEN_LEFT))  &&
                // but left panel is fully closed
                ((LastStatus == ArduinoSerial.STATUS_BOTH_CLOSED) || (LastStatus == ArduinoSerial.STATUS_LEFT_CLOSED))
            )
            {
                if (EnableLooseBeltProtection)
                {
                    // open a little bit until threshold
                    for (int i=0; i< LeftPanelBeltProtectionThreshold; i++)
                    _arduino.SendCommand(ACTION_OPEN_LEFT);

                    //.. then wait 1 sec
                    _utils.WaitForMilliseconds(2000);

                    // then continue opening...
                }
            }

            if (
                // we want to open right panel
                ((command == ACTION_OPEN_BOTH) || (command == ACTION_OPEN_RIGHT))  &&
                // but left panel is fully closed
                ((LastStatus == ArduinoSerial.STATUS_BOTH_CLOSED) || (LastStatus == ArduinoSerial.STATUS_RIGHT_CLOSED))
            )
            {
                if (EnableLooseBeltProtection)
                {
                    // open a little bit until threshold
                    for (int i = 0; i < RightPanelBeltProtectionThreshold; i++)
                        _arduino.SendCommand(ACTION_OPEN_RIGHT);

                    //.. then wait a bit for the belt to be into place
                    _utils.WaitForMilliseconds(2000);

                    // then continue opening...
                }

            }

            _utils.WaitForMilliseconds(MinDelayBtwnCommands);
            _arduino.SendCommand(command);

        }

        public bool CommandBool(string command, bool raw)
        {
            throw new ASCOM.MethodNotImplementedException("CommandBool");
        }

        public string CommandString(string command, bool raw)
        {
            throw new ASCOM.MethodNotImplementedException("CommandString");
        }

        public void Dispose()
        {
            // Clean up the tracelogger and util objects
            _Logger.Enabled = false;
            _Logger.Dispose();
            _Logger = null;

            _utils.Dispose();
            _utils = null;
            _astroUtils.Dispose();
            _astroUtils = null;

            // ensure that we disconnect from the serial
            if ((_arduino != null) && (_arduino.IsOpen))
            {
                _arduino.Close();
                _arduino.Dispose();
                _arduino = null;
            }
        }

        /// <summary>
        /// Returns true if there is a valid connection to the driver hardware
        /// </summary>
        private bool _IsConnected;

        /// <summary>
        /// Get : Returns true if connected to hardware
        /// Set : Forces the connection or disconnection to the hardware
        /// </summary>
        public bool Connected
        {
            get
            {
                return _IsConnected;
            }
            set
            {
                if (value == _IsConnected)
                    return; // doing nothing

                if (value)
                {
                    // Setting to True means we try to connect to the device
                    //

                    LogMessage(LOGGER, "Connecting to device on port {0}", ComPort);

                    _IsConnected = ConnectDome();

                    if (_IsConnected)
                        LogMessage(LOGGER, "Successfully connected to port {0}", ComPort);
                    else
                        LogMessage(LOGGER, "Failed to connect to port {0}", ComPort);
                }
                else
                {
                    // Setting to False means we try to disconnect from the device
                    //

                    LogMessage(LOGGER, "Disconnecting from port {0}", ComPort);

                    if (DisconnectDome())
                        _IsConnected = false;

                }
            }
        }

        /// <summary>
        /// Throws an exception if not connected to the hardware
        /// </summary>
        /// <param name="message">Message to attach to the NotConnectedException objet returned.</param>
        private void requiresConnected(string message)
        {
            if (!_IsConnected)
            {
                throw new ASCOM.NotConnectedException(message);
            }
        }

        public string Description
        {
            get
            {
                Logger.LogMessage("ASCOM Driver to pilot an AstroHaven Dome", _driverDescription);
                return _driverDescription;
            }
        }

        public string DriverInfo
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string driverInfo = "ASCOM Driver for AstroHaven Dome. Version: " + String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.Major, version.Minor);
                Logger.LogMessage("DriverInfo Get", driverInfo);
                return driverInfo;
            }
        }

        public string DriverVersion
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string driverVersion = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.Major, version.Minor);
                Logger.LogMessage("DriverVersion Get", driverVersion);
                return driverVersion;
            }
        }

        public short InterfaceVersion
        {
            // set by the driver wizard
            get
            {
                LogMessage("InterfaceVersion Get", "2");
                return Convert.ToInt16("2");
            }
        }

        public string Name
        {
            get
            {
                string name = "AstroHaven Dome Driver";
                Logger.LogMessage("Name Get", name);
                return name;
            }
        }

        #endregion

        #region IDome Implementation

        /// <summary>
        /// Not implemented in this driver
        /// </summary>
        public void AbortSlew()
        {
        }

        /// <summary>
        /// Throws an exception as not implemented in this driver
        /// </summary>
        public double Altitude
        {
            get
            {
                throw new ASCOM.PropertyNotImplementedException("Altitude", false);
            }
        }

        /// <summary>
        /// Throws an exception as not implemented in this driver
        /// </summary>
        public bool AtHome
        {
            get
            {                
                throw new ASCOM.PropertyNotImplementedException("AtHome", false);
            }
        }

        /// <summary>
        /// Throws an exception as not implemented in this driver
        /// </summary>
        public bool AtPark
        {
            get
            {
                throw new ASCOM.PropertyNotImplementedException("AtPark", false);
            }
        }

        /// <summary>
        /// Throws an exception as not implemented in this driver
        /// </summary>
        public double Azimuth
        {
            get
            {
                throw new ASCOM.PropertyNotImplementedException("Azimuth", false);
            }
        }

        /// <summary>
        /// Returns false as not implemented in this driver
        /// </summary>
        public bool CanFindHome
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns false as not implemented in this driver
        /// </summary>
        public bool CanPark
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns false as not implemented in this driver
        /// </summary>
        public bool CanSetAltitude
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns false as not implemented in this driver
        /// </summary>
        public bool CanSetAzimuth
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns false as not implemented in this driver
        /// </summary>
        public bool CanSetPark
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns false as not implemented in this driver
        /// </summary>
        public bool CanSetShutter
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns false as not implemented in this driver
        /// </summary>
        public bool CanSlave
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns false as not implemented in this driver
        /// </summary>
        public bool CanSyncAzimuth
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// Throws an exception as not implemented in this driver
        /// </summary>
        public void FindHome()
        {
            throw new ASCOM.MethodNotImplementedException("FindHome");
        }

        /// <summary>
        /// Attempts to close both panels
        /// </summary>
        public void CloseShutter()
        {
            Logger.LogMessage("CloseShutter", "Closing shutters...");
            Action(ACTION_CLOSE_BOTH, string.Empty);
        }


        public void OpenShutter()
        {
            Logger.LogMessage("OpenShutter", "Opening shutters...");
            Action(ACTION_OPEN_BOTH, string.Empty);
            //var result = Action(ACTION_OPEN_BOTH, string.Empty);
            //if (result == ArduinoSerial.STATUS_BOTH_OPEN)
            //    Logger.LogMessage("OpenShutter", "Both shutter are open");
            //else
            //    Logger.LogMessage("OpenShutter", "Somewhat shutters are not both open : " + result);
        }


        /// <summary>
        /// Throws an exception as not implemented in this driver
        /// </summary>
        public void Park()
        {
            throw new ASCOM.MethodNotImplementedException("Park");
        }

        /// <summary>
        /// Throws an exception as not implemented in this driver
        /// </summary>
        public void SetPark()
        {
            throw new ASCOM.MethodNotImplementedException("SetPark");
        }

        public ShutterState ShutterStatus
        {
            get
            {
                // returns last received status
                if (LastStatus == ArduinoSerial.STATUS_BOTH_OPEN)
                    return ShutterState.shutterOpen;
                else if (LastStatus == ArduinoSerial.STATUS_BOTH_CLOSED)
                    return ShutterState.shutterClosed;
                else
                    return ShutterState.shutterOpening; // in-between state, one of the panels is partially open (or closed)
            }
        }

        /// <summary>
        /// Get: Returns false as not implemented in this driver
        /// Set: Throws an exception as not implemented in this driver
        /// </summary>
        public bool Slaved
        {
            get
            {
                return false;
            }
            set
            {
                throw new ASCOM.PropertyNotImplementedException("Slaved", true);
            }
        }

        /// <summary>
        /// Throws an exception as not implemented in this driver
        /// </summary>
        public void SlewToAltitude(double Altitude)
        {
            throw new ASCOM.MethodNotImplementedException("SlewToAltitude");
        }

        /// <summary>
        /// Throws an exception as not implemented in this driver
        /// </summary>
        public void SlewToAzimuth(double Azimuth)
        {
            throw new ASCOM.MethodNotImplementedException("SlewToAzimuth");
        }

        /// <summary>
        /// Returns false as not implemented in this driver
        /// </summary>
        public bool Slewing
        {
            get
            {
                return false;
            }
        }


        /// <summary>
        /// Throws an exception as not implemented in this driver
        /// </summary>
        public void SyncToAzimuth(double Azimuth)
        {
            throw new ASCOM.MethodNotImplementedException("SyncToAzimuth");
        }

        #endregion


        #region ASCOM Registration

        /// <summary>
        /// Register or unregister the driver with the ASCOM Platform.
        /// This is harmless if the driver is already registered/unregistered.
        /// </summary>
        /// <param name="bRegister">If <c>true</c>, registers the driver, otherwise unregisters it.</param>
        private static void regUnregASCOM(bool bRegister)
        {
            using (var P = new ASCOM.Utilities.Profile())
            {
                P.DeviceType = "Dome";
                if (bRegister)
                {
                    P.Register(DriverID, _driverDescription);
                }
                else
                {
                    P.Unregister(DriverID);
                }
            }
        }

        /// <summary>
        /// This function registers the driver with the ASCOM Chooser and
        /// is called automatically whenever this class is registered for COM Interop.
        /// </summary>
        /// <param name="t">Type of the class being registered, not used.</param>
        /// <remarks>
        /// This method typically runs in two distinct situations:
        /// <list type="numbered">
        /// <item>
        /// In Visual Studio, when the project is successfully built.
        /// For this to work correctly, the option <c>Register for COM Interop</c>
        /// must be enabled in the project settings.
        /// </item>
        /// <item>During setup, when the installer registers the assembly for COM Interop.</item>
        /// </list>
        /// This technique should mean that it is never necessary to manually register a driver with ASCOM.
        /// </remarks>
        [ComRegisterFunction]
        public static void RegisterASCOM(Type t)
        {
            regUnregASCOM(true);
        }

        /// <summary>
        /// This function unregisters the driver from the ASCOM Chooser and
        /// is called automatically whenever this class is unregistered from COM Interop.
        /// </summary>
        /// <param name="t">Type of the class being registered, not used.</param>
        /// <remarks>
        /// This method typically runs in two distinct situations:
        /// <list type="numbered">
        /// <item>
        /// In Visual Studio, when the project is cleaned or prior to rebuilding.
        /// For this to work correctly, the option <c>Register for COM Interop</c>
        /// must be enabled in the project settings.
        /// </item>
        /// <item>During uninstall, when the installer unregisters the assembly from COM Interop.</item>
        /// </list>
        /// This technique should mean that it is never necessary to manually unregister a driver from ASCOM.
        /// </remarks>
        [ComUnregisterFunction]
        public static void UnregisterASCOM(Type t)
        {
            regUnregASCOM(false);
        }

        #endregion


        #region Profile management

        /// <summary>
        /// Read the device configuration from the ASCOM Profile store
        /// </summary>
        internal void ReadProfile()
        {
            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = LOGGER;

                var loggerEnabledStr = driverProfile.GetValue(DriverID, PROFILENAME_ENABLELOGGING, string.Empty, true.ToString() );
                Logger.Enabled = Convert.ToBoolean(loggerEnabledStr);

                ComPort = driverProfile.GetValue(DriverID, PROFILENAME_COMPORT, string.Empty, ArduinoSerial.DEFAULT_COMPORT);

                var baudStr = driverProfile.GetValue(DriverID, PROFILENAME_BAUD, string.Empty, ArduinoSerial.DEFAULT_BAUD.ToString());
                Baud = int.Parse(baudStr);

                var antiLooseBeltStr = driverProfile.GetValue(DriverID, PROFILENAME_LOOSEBELTPROTECTION, string.Empty, DEFAULT_LOOSEBELT_PROTECTION.ToString());
                EnableLooseBeltProtection = Convert.ToBoolean(antiLooseBeltStr);

                var threshold = driverProfile.GetValue(DriverID, PROFILENAME_LOOSEBELTPROTECTION_THRESHOLD_LEFT, string.Empty, DEFAULT_LOOSEBELT_PROTECTION_THRESHOLD.ToString());
                LeftPanelBeltProtectionThreshold = int.Parse(threshold);

                threshold = driverProfile.GetValue(DriverID, PROFILENAME_LOOSEBELTPROTECTION_THRESHOLD_RIGHT, string.Empty, DEFAULT_LOOSEBELT_PROTECTION_THRESHOLD.ToString());
                RightPanelBeltProtectionThreshold = int.Parse(threshold);

                var minDelayBtwCmdsStr = driverProfile.GetValue(DriverID, PROFILE_NAME_MINDELAYBETWEENCMDS, string.Empty, DEFAULT_MINDELAYBETWEENCOMMANDS.ToString());
                MinDelayBtwnCommands = int.Parse(minDelayBtwCmdsStr);
            }
        }

        /// <summary>
        /// Write the device configuration to the  ASCOM  Profile store
        /// </summary>
        internal void WriteProfile()
        {
            if (String.IsNullOrEmpty(ComPort))
                return;

            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = LOGGER;
                driverProfile.WriteValue(DriverID, PROFILENAME_ENABLELOGGING, Logger.Enabled.ToString());
                driverProfile.WriteValue(DriverID, PROFILENAME_COMPORT, ComPort.ToString());
                driverProfile.WriteValue(DriverID, PROFILENAME_BAUD, Baud.ToString());
                driverProfile.WriteValue(DriverID, PROFILENAME_LOOSEBELTPROTECTION, EnableLooseBeltProtection.ToString());
                driverProfile.WriteValue(DriverID, PROFILENAME_LOOSEBELTPROTECTION_THRESHOLD_LEFT, LeftPanelBeltProtectionThreshold.ToString());
                driverProfile.WriteValue(DriverID, PROFILENAME_LOOSEBELTPROTECTION_THRESHOLD_RIGHT, RightPanelBeltProtectionThreshold.ToString());
                driverProfile.WriteValue(DriverID, PROFILE_NAME_MINDELAYBETWEENCMDS, MinDelayBtwnCommands.ToString());
            }
        }

        #endregion

        /// <summary>
        /// Log helper function that takes formatted strings and arguments
        /// </summary>
        internal static void LogMessage(string identifier, string message, params object[] args)
        {
            var msg = string.Format(message, args);
            Logger.LogMessage(identifier, msg);
        }
        
    }
}
