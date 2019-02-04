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
    // Your driver's DeviceID is ASCOM.AstroHaven.Dome
    //
    // The Guid attribute sets the CLSID for ASCOM.AstroHaven.Dome
    // The ClassInterface/None addribute prevents an empty interface called
    // _AstroHaven from being created and used as the [default] interface
    //
    // TODO Replace the not implemented exceptions with code to implement the function or
    // throw the appropriate ASCOM exception.
    //

    /// <summary>
    /// ASCOM Dome Driver for AstroHaven.
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
                PROFILENAME_COMPORT= "COM Port", 
                PROFILENAME_TRACELEVEL = "Trace Level"
                ;

        internal static string ComPort; // Variables to hold the currrent device configuration
       

        internal string LastStatus = string.Empty;

        
        /// <summary>
        /// Private variable to hold an ASCOM Utilities object
        /// </summary>
        private Util _utils;

        /// <summary>
        /// Private variable to hold an ASCOM AstroUtilities object to provide the Range method
        /// </summary>
        private AstroUtils _astroUtils;

        private ArduinoSerial _arduino;

        /// <summary>
        /// Variable to hold the trace logger object (creates a diagnostic log file with information that you specify)
        /// </summary>
        internal static TraceLogger Logger;

        public const string
            ACTION_GET_STATUS = "ACTION_GET_STATUS",

            ACTION_OPEN_LEFT = "ACTION_OPEN_LEFT",
            ACTION_OPEN_RIGHT = "ACTION_OPEN_RIGHT",

            ACTION_CLOSE_LEFT = "ACTION_CLOSE_LEFT",
            ACTION_CLOSE_RIGHT = "ACTION_CLOSE_RIGHT",

            ACTION_OPEN_BOTH = "ACTION_OPEN_BOTH",
            ACTION_CLOSE_BOTH = "ACTION_CLOSE_BOTH"

           ;


        public string LOGGER = "Dome";

        /// <summary>
        /// Initializes a new instance of the <see cref="AstroHaven"/> class.
        /// Must be public for COM registration.
        /// </summary>
        public Dome()
        {
            Logger = new TraceLogger("", "AstroHaven");
            ReadProfile(); // Read device configuration from the ASCOM Profile store

            Logger.LogMessage(LOGGER, "Starting initialisation");

            _IsConnected = false; // Initialise connected to false
            _utils = new Util(); //Initialise util object
            _astroUtils = new AstroUtils(); // Initialise astro utilities object

            //TODO: Implement your additional construction here

            Logger.LogMessage(LOGGER, "Completed initialisation");
        }

        #region Serial

        private bool ConnectDome()
        {
            bool success = false;
            try
            {
                _arduino = new ArduinoSerial();
                _arduino.OnReplyReceived += new ArduinoSerial.ReplyReceivedEventHandler(onReplyReceived);
                _utils.WaitForMilliseconds(2000);
                success = true;
            } catch(Exception exc)
            {
                Logger.LogIssue(LOGGER, "Failed to connect to dome : " + exc.Message);
            }
            return success;
        }

        private void onReplyReceived(object sender, EventArgs e)
        {
            while (_arduino.ReplyQueue.Count > 0)
            {
                string[] com_args = ((string)_arduino.ReplyQueue.Pop()).Split(' ');

                string reply = com_args[0];

                // process reply ?;
                LastStatus = reply;
            }
        }

        private bool DisconnectDome()
        {
            _arduino.Close();

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

        public ArrayList SupportedActions
        {
            get
            {
                //tl.LogMessage("SupportedActions Get", "Returning empty arraylist");
                var actions = new ArrayList();
                actions.Add(ACTION_GET_STATUS);

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
                    return CommandString(ArduinoSerial.COMMAND_GET_STATUS, false);

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
                    LogMessage("", "Action {0}, parameters {1} not implemented", actionName, actionParameters);
                    throw new ASCOM.ActionNotImplementedException("Action " + actionName + " is not implemented by this driver");

            }

            return String.Empty;

        }

        public void CommandBlind(string command, bool raw)
        {
            requiresConnected("CommandBlind");

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
            Logger.Enabled = false;
            Logger.Dispose();
            Logger = null;
            _utils.Dispose();
            _utils = null;
            _astroUtils.Dispose();
            _astroUtils = null;

            // ensure that we disconnect from the serial
            if ((_arduino != null) && (_arduino.IsOpen))
            {
                _arduino.Close();
                _arduino.Dispose();
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
        /// Use this function to throw an exception if we aren't connected to the hardware
        /// </summary>
        /// <param name="message"></param>
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


        public void AbortSlew()
        {
            // This is a mandatory parameter but we have no action to take in this simple driver
            Logger.LogMessage("AbortSlew", "Completed");
        }

        public double Altitude
        {
            get
            {
                Logger.LogMessage("Altitude Get", "Not implemented");
                throw new ASCOM.PropertyNotImplementedException("Altitude", false);
            }
        }

        public bool AtHome
        {
            get
            {
                Logger.LogMessage("AtHome Get", "Not implemented");
                throw new ASCOM.PropertyNotImplementedException("AtHome", false);
            }
        }

        public bool AtPark
        {
            get
            {
                Logger.LogMessage("AtPark Get", "Not implemented");
                throw new ASCOM.PropertyNotImplementedException("AtPark", false);
            }
        }

        public double Azimuth
        {
            get
            {
                Logger.LogMessage("Azimuth Get", "Not implemented");
                throw new ASCOM.PropertyNotImplementedException("Azimuth", false);
            }
        }

        public bool CanFindHome
        {
            get
            {
                Logger.LogMessage("CanFindHome Get", false.ToString());
                return false;
            }
        }

        public bool CanPark
        {
            get
            {
                Logger.LogMessage("CanPark Get", false.ToString());
                return false;
            }
        }

        public bool CanSetAltitude
        {
            get
            {
                Logger.LogMessage("CanSetAltitude Get", false.ToString());
                return false;
            }
        }

        public bool CanSetAzimuth
        {
            get
            {
                Logger.LogMessage("CanSetAzimuth Get", false.ToString());
                return false;
            }
        }

        public bool CanSetPark
        {
            get
            {
                Logger.LogMessage("CanSetPark Get", false.ToString());
                return false;
            }
        }

        public bool CanSetShutter
        {
            get
            {
                Logger.LogMessage("CanSetShutter Get", true.ToString());
                return false;
            }
        }

        public bool CanSlave
        {
            get
            {
                Logger.LogMessage("CanSlave Get", false.ToString());
                return false;
            }
        }

        public bool CanSyncAzimuth
        {
            get
            {
                Logger.LogMessage("CanSyncAzimuth Get", false.ToString());
                return false;
            }
        }

        public void CloseShutter()
        {
            Logger.LogMessage("CloseShutter", "Closing shutters...");
            Action(ACTION_CLOSE_BOTH, null);
            //if (result == ArduinoSerial.STATUS_BOTH_CLOSED)
            //    Logger.LogMessage("CloseShutter", "Shutter has been closed");
            //else
            //    Logger.LogMessage("CloseShutter", "Somewhat they are not both closed : "  + result);
        }

        public void FindHome()
        {
            Logger.LogMessage("FindHome", "Not implemented");
            throw new ASCOM.MethodNotImplementedException("FindHome");
        }

        public void OpenShutter()
        {
            Logger.LogMessage("OpenShutter", "Opening shutters...");
            Action(ACTION_OPEN_BOTH, null);
            //var result = Action(ACTION_OPEN_BOTH, null);
            //if (result == ArduinoSerial.STATUS_BOTH_OPEN)
            //    Logger.LogMessage("OpenShutter", "Both shutter are open");
            //else
            //    Logger.LogMessage("OpenShutter", "Somewhat shutters are not both open : " + result);
        }

        public void Park()
        {
            Logger.LogMessage("Park", "Not implemented");
            throw new ASCOM.MethodNotImplementedException("Park");
        }

        public void SetPark()
        {
            Logger.LogMessage("SetPark", "Not implemented");
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
                    return ShutterState.shutterOpening; // in-between state??
            }
        }

        public bool Slaved
        {
            get
            {
                Logger.LogMessage("Slaved Get", false.ToString());
                return false;
            }
            set
            {
                Logger.LogMessage("Slaved Set", "not implemented");
                throw new ASCOM.PropertyNotImplementedException("Slaved", true);
            }
        }

        public void SlewToAltitude(double Altitude)
        {
            Logger.LogMessage("SlewToAltitude", "Not implemented");
            throw new ASCOM.MethodNotImplementedException("SlewToAltitude");
        }

        public void SlewToAzimuth(double Azimuth)
        {
            Logger.LogMessage("SlewToAzimuth", "Not implemented");
            throw new ASCOM.MethodNotImplementedException("SlewToAzimuth");
        }

        public bool Slewing
        {
            get
            {
                Logger.LogMessage("Slewing Get", false.ToString());
                return false;
            }
        }

        public void SyncToAzimuth(double Azimuth)
        {
            Logger.LogMessage("SyncToAzimuth", "Not implemented");
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
                var val = driverProfile.GetValue(DriverID, PROFILENAME_TRACELEVEL, string.Empty, "DEBUG");
                Logger.Enabled = Convert.ToBoolean(val);
                ComPort = driverProfile.GetValue(DriverID, PROFILENAME_COMPORT, string.Empty, ArduinoSerial.DEFAULT_COMPORT);
            }
        }

        /// <summary>
        /// Write the device configuration to the  ASCOM  Profile store
        /// </summary>
        internal void WriteProfile()
        {
            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = LOGGER;
                driverProfile.WriteValue(DriverID, PROFILENAME_TRACELEVEL, Logger.Enabled.ToString());
                driverProfile.WriteValue(DriverID, PROFILENAME_COMPORT, ComPort.ToString());
            }
        }

        #endregion

        /// <summary>
        /// Log helper function that takes formatted strings and arguments
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        internal static void LogMessage(string identifier, string message, params object[] args)
        {
            var msg = string.Format(message, args);
            Logger.LogMessage(identifier, msg);
        }
        
    }
}
