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
            else
            {
                if (comboBoxComPort.Items.Count > 0)
                    comboBoxComPort.SelectedIndex = 0;
            }
            ddMinDelayBetweenCommands.Value = Dome.MinDelayBtwnCommands;


            txtOnOpeningPauseAfter.Text = Dome.OnOpeningPauseAfter.ToString();
            txtOnOpeningPauseDuring.Text = Dome.OnOpeningPauseDuring.ToString();
            txtOnClosingOverfeedDuring.Text = Dome.OnClosingOverfeedDuring.ToString();


        }


        private void btOK_Click(object sender, EventArgs e) // OK button event handler
        {
            // Place any validation constraint checks here
            // Update the state variables with results from the dialogue
            Dome.ComPort = (string)comboBoxComPort.SelectedItem;

            int baud;
            int.TryParse(txtBaud.Text, out baud);
            Dome.Baud = (baud == 0) ? ArduinoSerial.DEFAULT_BAUD : baud;

            Dome.Logger.Enabled = chkTrace.Checked;

            Dome.MinDelayBtwnCommands = (ddMinDelayBetweenCommands.Value < 0) ? Dome.DEFAULT_MINDELAYBETWEENCOMMANDS : (int)ddMinDelayBetweenCommands.Value;

            int onOpeningPauseAfter;
            int.TryParse(txtOnOpeningPauseAfter.Text, out onOpeningPauseAfter);
            Dome.OnOpeningPauseAfter = (onOpeningPauseAfter < 0) ? Dome.DEFAULT_ONOPENING_PAUSE_AFTER : onOpeningPauseAfter;

            int onOpeningPauseDuring;
            int.TryParse(txtOnOpeningPauseDuring.Text, out onOpeningPauseDuring);
            Dome.OnOpeningPauseDuring = (onOpeningPauseDuring < 0) ? Dome.DEFAULT_ONOPENING_PAUSE_DURING : onOpeningPauseDuring;

            int onClosingOverfeedDuring;
            int.TryParse(txtOnClosingOverfeedDuring.Text, out onClosingOverfeedDuring);
            Dome.OnClosingOverfeedDuring = (onClosingOverfeedDuring < 0) ? Dome.DEFAULT_ONCLOSING_OVERFEED_DURING : onClosingOverfeedDuring;

        }

        private void btCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void ddMinDelayBetweenCommands_ValueChanged(object sender, EventArgs e)
        {
            if (ddMinDelayBetweenCommands.Value > 1000)
                ddMinDelayBetweenCommands.Value = 1000;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://astrohaven.com/");
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
        
    }
}