using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ASCOM.Utilities;
using ASCOM.AstroHaven;

namespace ASCOM.AstroHaven
{
    [ComVisible(false)]					// Form not registered for COM!
    public partial class SetupDialogForm : Form
    {
        Dome _dome = null;

        public SetupDialogForm()
        {
            InitializeComponent();
        }


        private void SetupDialogForm_Load(object sender, EventArgs e)
        {
            // Initialise current values of user settings from the ASCOM Profile
            InitUI();

            UpdateUIWhenConnected(false);
        }

        private void BrowseToAscom(object sender, EventArgs e) // Click on ASCOM logo event handler
        {
            try
            {
                System.Diagnostics.Process.Start("http://ascom-standards.org/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void InitUI()
        {
            chkTrace.Checked = Dome.Logger.Enabled;
            // set the list of com ports to those that are currently available
            comboBoxComPort.Items.Clear();
            comboBoxComPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());      // use System.IO because it's static
            // select the current port if possible
            if (comboBoxComPort.Items.Contains(Dome.ComPort))
            {
                comboBoxComPort.SelectedItem = Dome.ComPort;
            }

        }

        #region UI


        private void btOK_Click(object sender, EventArgs e) // OK button event handler
        {
            // Place any validation constraint checks here
            // Update the state variables with results from the dialogue
            Dome.ComPort = (string)comboBoxComPort.SelectedItem;
            Dome.Logger.Enabled = chkTrace.Checked;
        }

        private void btCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void btOpenLeft_Click(object sender, EventArgs e)
        {
            try
            {
                _dome.Action(Dome.ACTION_OPEN_LEFT, null);
            }
            catch (Exception exc)
            {
                Log(exc);
            }
        }

        private void btCloseLeft_Click(object sender, EventArgs e)
        {
            try
            {
                _dome.Action(Dome.ACTION_CLOSE_LEFT, null);
            }
            catch (Exception exc)
            {
                Log(exc);
            }
        }

        private void btOpenRight_Click(object sender, EventArgs e)
        {
            try
            {
                _dome.Action(Dome.ACTION_CLOSE_RIGHT, null);
            }
            catch (Exception exc)
            {
                Log(exc);
            }
        }

        private void btCloseRight_Click(object sender, EventArgs e)
        {
            try
            {
                _dome.Action(Dome.ACTION_CLOSE_RIGHT, null);
            }
            catch (Exception exc)
            {
                Log(exc);
            }
        }


        private void btOpenBoth_Click(object sender, EventArgs e)
        {
            try
            {
                //_dome.Action(Dome.ACTION_OPEN_BOTH, null);
                //or
                _dome.OpenShutter();
            }
            catch (Exception exc)
            {
                Log(exc);
            }
        }

        private void btCloseBoth_Click(object sender, EventArgs e)
        {
            try
            {
                //_dome.Action(Dome.ACTION_CLOSE_BOTH, null);
                //or
                _dome.CloseShutter();
            }
            catch (Exception exc)
            {
                Log(exc);
            }
        }

        #endregion

        private void UpdateUIWhenConnected(bool connected)
        {
            btConnect.Enabled = !connected;
            btDisconnect.Enabled = connected;
            gpControl.Enabled = connected;

            lbConnectedStatus.Text = connected ? "Connected" : "Not connected";

            lbLeftShutterStatus.Text = "";
            lbRightShutterStatus.Text = "";
        }

        void TryConnect(bool connect)
        {
            try
            {
                if (_dome == null)
                    _dome = new Dome();

                _dome.Connected = connect; // try to connect to dome
            }
            catch (Exception exc)
            {
                Log(exc);
            }

            // update connected status label
            UpdateUIWhenConnected((_dome != null) ? _dome.Connected : false);
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            TryConnect(true);
        }

        private void btDisconnect_Click(object sender, EventArgs e)
        {
            TryConnect(false);
        }

        private void Log(Exception exc)
        {
            MessageBox.Show("Error", exc.Message);
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            UpdateUIWhenConnected((_dome != null) ? _dome.Connected : false);

            if ((_dome != null) && (_dome.Connected)) {
                
                bool leftShutterClosed = (_dome.LastStatus == ArduinoSerial.STATUS_BOTH_CLOSED) || (_dome.LastStatus == ArduinoSerial.STATUS_LEFT_CLOSED);
                bool rightShutterClosed = (_dome.LastStatus == ArduinoSerial.STATUS_BOTH_CLOSED) || (_dome.LastStatus == ArduinoSerial.STATUS_RIGHT_CLOSED);

                lbLeftShutterStatus.Text = leftShutterClosed ? "Closed" : "Open";
                lbRightShutterStatus.Text = rightShutterClosed ? "Closed" : "Open";

            }
        }
        
    }
}