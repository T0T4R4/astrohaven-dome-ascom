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
            chkAntiLooseBelt.Checked = Dome.EnableLooseBeltProtection;

            txtLooseBeltThresholdLeft.Text = Dome.LeftPanelBeltProtectionThreshold.ToString();
            txtLooseBeltThresholdRight.Text = Dome.RightPanelBeltProtectionThreshold.ToString();

            ddMinDelayBetweenCommands.Value = Dome.MinDelayBtwnCommands;
        }


        private void btOK_Click(object sender, EventArgs e) // OK button event handler
        {
            // Place any validation constraint checks here
            // Update the state variables with results from the dialogue
            Dome.ComPort = (string)comboBoxComPort.SelectedItem;

            int baud;
            int.TryParse(textboxBaud.Text, out baud);
            Dome.Baud = (baud == 0) ? ArduinoSerial.DEFAULT_BAUD : baud;

            Dome.Logger.Enabled = chkTrace.Checked;

            Dome.MinDelayBtwnCommands = (ddMinDelayBetweenCommands.Value < 0) ? Dome.DEFAULT_MINDELAYBETWEENCOMMANDS : (int) ddMinDelayBetweenCommands.Value;

            Dome.EnableLooseBeltProtection = chkAntiLooseBelt.Checked;

            int thresholdLeft, thresholdRight;
            int.TryParse(txtLooseBeltThresholdLeft.Text, out thresholdLeft);
            Dome.LeftPanelBeltProtectionThreshold = (thresholdLeft < 0) ? Dome.DEFAULT_LOOSEBELT_PROTECTION_THRESHOLD : thresholdLeft;
            int.TryParse(txtLooseBeltThresholdRight.Text, out thresholdRight);
            Dome.RightPanelBeltProtectionThreshold = (thresholdRight < 0) ? Dome.DEFAULT_LOOSEBELT_PROTECTION_THRESHOLD : thresholdRight;

            Dome.MinDelayBtwnCommands = (ddMinDelayBetweenCommands.Value < 0) ? Dome.DEFAULT_MINDELAYBETWEENCOMMANDS : (int) ddMinDelayBetweenCommands.Value;
        }

        private void btCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void ddMinDelayBetweenCommands_ValueChanged(object sender, EventArgs e)
        {
            if (ddMinDelayBetweenCommands.Value > 10000)
                ddMinDelayBetweenCommands.Value = 10000;
        }

        private void chkAntiLooseBelt_CheckedChanged(object sender, EventArgs e)
        {
            label5.Enabled = chkAntiLooseBelt.Checked;
            txtLooseBeltThresholdLeft.Enabled = chkAntiLooseBelt.Checked;
            txtLooseBeltThresholdRight.Enabled = chkAntiLooseBelt.Checked;
        }


    }
}