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
                PROFILENAME_COMPORT = "COMPort",
                PROFILENAME_BAUD = "Baud",
                PROFILENAME_ENABLE_LOGGING = "TraceLevel",
                PROFILENAME_MIN_DELAY_BETWEEN_CMDS = "MinDelayBetweenCommands",
                PROFILENAME_ONOPENING_PAUSE_AFTER = "OnOpeningPauseAfter",
                PROFILENAME_ONOPENING_PAUSE_DURING = "OnOpeningPauseDuring",
                PROFILENAME_ONCLOSING_OVERFEED_DURING = "OnClosingOverfeedDuring"
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
        /// Delay after which to pause when opening a dome to prevent belt loosening
        /// </summary>
        internal static int OnOpeningPauseAfter { get; set; } = DEFAULT_ONOPENING_PAUSE_AFTER;

        /// <summary>
        /// Duration of the pause on opening to prevent belt loosening
        /// </summary>
        internal static int OnOpeningPauseDuring { get; set; } = DEFAULT_ONOPENING_PAUSE_DURING;

        /// <summary>
        /// Minimum delay in milliseconds between each commmand sent to the dome hardware
        /// </summary>
        internal static int MinDelayBtwnCommands { get; set; } = DEFAULT_MINDELAYBETWEENCOMMANDS;

        /// <summary>
        /// Duration of the overfeeding on dome closure (time during which commands will be continuously sent to the dome to fully close it - for dodgy domes)
        /// </summary>
        internal static int OnClosingOverfeedDuring { get; set; } = DEFAULT_ONCLOSING_OVERFEED_DURING;

        internal bool Abort { get; set; }

        /// <summary>
        /// Authorized device-specific actions
        /// </summary>
        internal const string
            ACTION_GET_STATUS = "GET_STATUS",
            ACTION_GET_LAST_STATUS = "GET_LAST_STATUS",

            ACTION_ABORT = "ABORT",
            ACTION_RESET_MOTORS = "RESET_MOTORS",

            ACTION_OPEN_LEFT_FULL = "OPEN_LEFT_FULL",
            ACTION_OPEN_RIGHT_FULL = "OPEN_RIGHT_FULL",

            ACTION_OPEN_LEFT_STEP = "OPEN_LEFT_STEP",
            ACTION_OPEN_RIGHT_STEP = "OPEN_RIGHT_STEP",

            ACTION_CLOSE_LEFT_STEP = "CLOSE_LEFT_STEP",
            ACTION_CLOSE_RIGHT_STEP = "CLOSE_RIGHT_STEP",

            ACTION_CLOSE_LEFT_FULL = "CLOSE_LEFT_FULL",
            ACTION_CLOSE_RIGHT_FULL = "CLOSE_RIGHT_FULL"

           ;

        internal const int 
            DEFAULT_MINDELAYBETWEENCOMMANDS = 50, //milliseconds
            DEFAULT_ONOPENING_PAUSE_AFTER = 2, // seconds 
            DEFAULT_ONOPENING_PAUSE_DURING = 3, // seconds 
            DEFAULT_ONCLOSING_OVERFEED_DURING = 3, // seconds
            DEFAULT_STEP_DURATION = 1, // seconds
            DEFAULT_PRE_OPENING_DURATION = 2 // seconds 
            ; 

        /// <summary>
        /// Initializes a new instance of the <see cref="Dome"/> class.
        /// Must be public for COM registration.
        /// </summary>
        public Dome()
        {
            ReadProfile(); // Read device configuration from the ASCOM Profile store

            Logger.LogMessage(LOGGER, "Starting initialisation");

            _utils = new Util(); //Initialise util object
            _astroUtils = new AstroUtils(); // Initialise astro utilities object

            Logger.LogMessage(LOGGER, "Completed initialisation");
        }

        #region Serial

        /// <summary>
        /// Attempts to connect to the hardware given the com port and baud from profile
        /// </summary>
        /// <returns>True if connection succeeded</returns>
        private void Connect()
        {
            Disconnect();

            _arduino = new ArduinoSerial(Dome.ComPort, Dome.Baud);
            _arduino.OnReplyReceived += new ArduinoSerial.ReplyReceivedEventHandler(onReplyReceived);
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
        private void Disconnect()
        {
            if ((_arduino != null) && (_arduino.IsOpen))
            {
                _arduino.Close();

                _arduino.Dispose();
                _arduino = null;

            }
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
            using (SetupDialogForm f = new SetupDialogForm())
            {
                var result = f.ShowDialog();
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
                var actions = new ArrayList();

                actions.Add(ACTION_GET_STATUS);
                actions.Add(ACTION_GET_LAST_STATUS);

                actions.Add(ACTION_RESET_MOTORS);

                actions.Add(ACTION_ABORT);

                actions.Add(ACTION_OPEN_LEFT_FULL);
                actions.Add(ACTION_OPEN_RIGHT_FULL);

                actions.Add(ACTION_OPEN_LEFT_STEP);
                actions.Add(ACTION_OPEN_RIGHT_STEP);

                actions.Add(ACTION_CLOSE_LEFT_FULL);
                actions.Add(ACTION_CLOSE_RIGHT_FULL);

                actions.Add(ACTION_CLOSE_LEFT_STEP);
                actions.Add(ACTION_CLOSE_RIGHT_STEP);

                return actions;
            }
        }


        public string Action(string actionName, string actionParameters)
        {
            switch (actionName)
            {
                case ACTION_GET_STATUS:
                    CommandBlind(ArduinoSerial.GET_STATUS, false);
                    return LastStatus;

                case ACTION_GET_LAST_STATUS:
                    if (String.IsNullOrEmpty(LastStatus))
                        return Action(ACTION_GET_STATUS, string.Empty);
                    else
                        return LastStatus;

                case ACTION_ABORT:
                    Abort = true;
                    break;

                case ACTION_OPEN_LEFT_FULL:
                    openPanel(Panel.Left);
                    break;

                case ACTION_OPEN_LEFT_STEP:
                    stepMovePanel(Panel.Left, Direction.Open);
                    break;

                case ACTION_OPEN_RIGHT_STEP:
                    stepMovePanel(Panel.Right, Direction.Open);
                    break;


                case ACTION_CLOSE_LEFT_STEP:
                    stepMovePanel(Panel.Left, Direction.Close);
                    break;

                case ACTION_CLOSE_RIGHT_STEP:
                    stepMovePanel(Panel.Right, Direction.Close);
                    break;


                case ACTION_OPEN_RIGHT_FULL:
                    openPanel(Panel.Right);
                    break;

                case ACTION_CLOSE_LEFT_FULL:
                    closePanel(Panel.Left);
                    break;

                case ACTION_CLOSE_RIGHT_FULL:
                    closePanel(Panel.Right);
                    break;

                default:
                    throw new ASCOM.ActionNotImplementedException("Action " + actionName + " is not implemented by this driver");

            }

            return String.Empty;

        }


        public void CommandBlind(string command, bool raw = false)
        {
            requiresConnected();

            if (_arduino != null)
                _arduino.Send(command);

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
            Disconnect();

            // Clean up the tracelogger and util objects
            _Logger.Enabled = false;
            _Logger.Dispose();
            _Logger = null;

            _utils.Dispose();
            _utils = null;
            _astroUtils.Dispose();
            _astroUtils = null;

        }

        /// <summary>
        /// Get : Returns true if connected to hardware
        /// Set : Forces the connection or disconnection to the hardware
        /// </summary>
        public bool Connected
        {
            get
            {
                return (_arduino != null) ? _arduino.IsOpen : false;
            }
            set
            {
                if (value)
                {
                    // Setting to True means we try to connect to the device
                    //

                    LogMessage(LOGGER, "Connecting to device on port {0}", ComPort);

                    Connect();
                }
                else
                {
                    // Setting to False means we try to disconnect from the device
                    //

                    LogMessage(LOGGER, "Disconnecting from port {0}", ComPort);

                    Disconnect();

                }
            }
        }

        /// <summary>
        /// Automatically tries to reconnect to the hardware
        /// </summary>
        private void requiresConnected()
        {
            if ((_arduino == null) || (!_arduino.IsOpen))
            {
                Connect();
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
            Action(ACTION_CLOSE_LEFT_FULL, string.Empty);
            Action(ACTION_CLOSE_RIGHT_FULL, string.Empty);

        }


        public void OpenShutter()
        {
            Logger.LogMessage("OpenShutter", "Opening shutters...");
            Action(ACTION_OPEN_LEFT_FULL, string.Empty);
            Action(ACTION_OPEN_RIGHT_FULL, string.Empty);
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
                // Note: this ASCOM property has been desined for single shutters. Use the ACTION("LAST_STATUS") instead when possible.

                switch (LastStatus)
                {
                    case ArduinoSerial.BOTH_CLOSED:
                        return ShutterState.shutterClosed;

                    case ArduinoSerial.BOTH_OPEN:
                        return ShutterState.shutterOpen;

                    case ArduinoSerial.CLOSING_LEFT:
                    case ArduinoSerial.CLOSING_RIGHT:
                        return ShutterState.shutterClosing;

                    case ArduinoSerial.OPENING_LEFT:
                    case ArduinoSerial.OPENING_RIGHT:
                        return ShutterState.shutterOpening;

                    default:
                        return ShutterState.shutterError; // Attention: if only 1 panel is closed/open, then expect to receive error....
                }
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

                var loggerEnabledStr = driverProfile.GetValue(DriverID, PROFILENAME_ENABLE_LOGGING, string.Empty, true.ToString());
                Logger.Enabled = Convert.ToBoolean(loggerEnabledStr);

                ComPort = driverProfile.GetValue(DriverID, PROFILENAME_COMPORT, string.Empty, string.Empty);

                var baudStr = driverProfile.GetValue(DriverID, PROFILENAME_BAUD, string.Empty, ArduinoSerial.DEFAULT_BAUD.ToString());
                Baud = int.Parse(baudStr);

                var minDelayBtwCmdsStr = driverProfile.GetValue(DriverID, PROFILENAME_MIN_DELAY_BETWEEN_CMDS, string.Empty, DEFAULT_MINDELAYBETWEENCOMMANDS.ToString());
                MinDelayBtwnCommands = int.Parse(minDelayBtwCmdsStr);

                var onOpeningPauseAfterStr = driverProfile.GetValue(DriverID, PROFILENAME_ONOPENING_PAUSE_AFTER, string.Empty, DEFAULT_ONOPENING_PAUSE_AFTER.ToString());
                OnOpeningPauseAfter = int.Parse(onOpeningPauseAfterStr);

                var onOpeningPauseDuringStr = driverProfile.GetValue(DriverID, PROFILENAME_ONOPENING_PAUSE_DURING, string.Empty, DEFAULT_ONOPENING_PAUSE_DURING.ToString());
                OnOpeningPauseDuring = int.Parse(onOpeningPauseDuringStr);

                var onClosingOverfeedDuringStr = driverProfile.GetValue(DriverID, PROFILENAME_ONCLOSING_OVERFEED_DURING, string.Empty, DEFAULT_ONCLOSING_OVERFEED_DURING.ToString());
                OnClosingOverfeedDuring = int.Parse(onClosingOverfeedDuringStr);
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
                driverProfile.WriteValue(DriverID, PROFILENAME_ENABLE_LOGGING, Logger.Enabled.ToString());
                driverProfile.WriteValue(DriverID, PROFILENAME_COMPORT, ComPort.ToString());
                driverProfile.WriteValue(DriverID, PROFILENAME_BAUD, Baud.ToString());
                driverProfile.WriteValue(DriverID, PROFILENAME_MIN_DELAY_BETWEEN_CMDS, MinDelayBtwnCommands.ToString());

                driverProfile.WriteValue(DriverID, PROFILENAME_ONOPENING_PAUSE_AFTER, OnOpeningPauseAfter.ToString());
                driverProfile.WriteValue(DriverID, PROFILENAME_ONOPENING_PAUSE_DURING, OnOpeningPauseDuring.ToString());
                driverProfile.WriteValue(DriverID, PROFILENAME_ONCLOSING_OVERFEED_DURING, OnClosingOverfeedDuring.ToString());

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


        #region Action wrappers

        private enum Panel
        {
            Right, Left
        }

        private enum Direction
        {
            Open,
            Close
        }

        private bool IsLeftPanelOpen()
        {
            return LastStatus == ArduinoSerial.BOTH_OPEN ||
                 LastStatus == ArduinoSerial.LEFT_ALREADY_OPEN;

        }

        private bool IsRightPanelOpen()
        {
            return LastStatus == ArduinoSerial.BOTH_OPEN ||
                 LastStatus == ArduinoSerial.RIGHT_ALREADY_OPEN;

        }

        private bool IsLeftPanelClosed()
        {
            return (LastStatus == ArduinoSerial.BOTH_CLOSED) ||
                 (LastStatus == ArduinoSerial.LEFT_ALREADY_CLOSED);

        }

        private bool IsRightPanelClosed()
        {
            return (LastStatus == ArduinoSerial.BOTH_CLOSED) ||
                 (LastStatus == ArduinoSerial.RIGHT_ALREADY_CLOSED);

        }

        /// <summary>
        /// Repeat a command for a given duration
        /// </summary>
        /// <param name="cmd">Command to repeat</param>
        /// <param name="repeatDuration">Duration in milliseconds to repeat this command</param>
        private void repeatCommand(String cmd, int repeatDuration)
        {

            if (repeatDuration < MinDelayBtwnCommands)
                repeatDuration = MinDelayBtwnCommands;

            DateTime end = DateTime.Now.AddMilliseconds(repeatDuration);

            Abort = false; // reset

            while (!Abort)
            {
                CommandBlind(cmd); // do at least once 

                if (DateTime.Now < end) break;
            }

            Abort = false; // reset
        }


        /// <summary>
        /// Moves the given panel by step in the given direction
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="dir"></param>
        /// <param name="stepDuration">Duration of a step in Seconds </param>
        private void stepMovePanel(Panel panel, Direction dir, int stepDuration = DEFAULT_STEP_DURATION)
        {
            // build command sequence
            var cmd = (
                (panel == Panel.Left) ?
                    ((dir == Direction.Open) ? ArduinoSerial.OPEN_LEFT : ArduinoSerial.CLOSE_LEFT)
                    : // else
                    ((dir == Direction.Open) ? ArduinoSerial.OPEN_RIGHT : ArduinoSerial.CLOSE_RIGHT)
                );

            repeatCommand(cmd, stepDuration * 1000);

        }


        private void preOpenPanel(Panel panel)
        {
            // open a little bit until threshold            
            stepMovePanel(panel, Direction.Open, DEFAULT_PRE_OPENING_DURATION * 1000);

            _utils.WaitForMilliseconds(OnOpeningPauseDuring * 1000);
        }

        private void openPanel(Panel panel)
        {
            // if a pre-opening has been defined AND the panel is currently closed, then pre-open it
            if (OnOpeningPauseAfter > 0)
            {
                if ((panel == Panel.Left) && IsLeftPanelClosed())
                {
                    preOpenPanel(Panel.Left);
                }

                if ((panel == Panel.Right) && IsRightPanelClosed())
                {
                    preOpenPanel(Panel.Right);
                }
            }

            // continue with the opening
            //

            bool done = false;
            Abort = false; // reset

            while (!done && !Abort)
            {
                done = (panel == Panel.Left) ? IsLeftPanelOpen() : IsRightPanelOpen();

                stepMovePanel(panel, Direction.Open);

            }
            Abort = false; // reset
        }

        /// <summary>
        /// Closes one panel step by step
        /// </summary>
        /// <param name="panel"></param>
        private void closePanel(Panel panel)
        {
            bool done = false;
            Abort = false; // reset

            while (!done && !Abort)
            {
                done = (panel == Panel.Left) ? IsLeftPanelClosed() : IsRightPanelClosed();

                stepMovePanel(panel, Direction.Close); // full close
            }

            // unless the closure has been manually aborted, continue throwing commands to force the closure
            // note: this is mostly for domes where the magnetic sensors have been badly positioned
            if (!Abort && (OnClosingOverfeedDuring > 0))
            {
                stepMovePanel(panel, Direction.Close, OnClosingOverfeedDuring * 1000); // force closing 
            }

            Abort = false; // reset
        }



        #endregion

    }
}
