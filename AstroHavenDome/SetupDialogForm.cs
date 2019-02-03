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
        public SetupDialogForm()
        {
            InitializeComponent();
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
            chkTrace.Checked = Dome.tl.Enabled;
            // set the list of com ports to those that are currently available
            comboBoxComPort.Items.Clear();
            comboBoxComPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());      // use System.IO because it's static
            // select the current port if possible
            if (comboBoxComPort.Items.Contains(Dome.comPort))
            {
                comboBoxComPort.SelectedItem = Dome.comPort;
            }
        }

        #region UI


        private void btOK_Click(object sender, EventArgs e) // OK button event handler
        {
            // Place any validation constraint checks here
            // Update the state variables with results from the dialogue
            Dome.comPort = (string)comboBoxComPort.SelectedItem;
            Dome.tl.Enabled = chkTrace.Checked;
        }

        private void btCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void btOpenNorth_Click(object sender, EventArgs e)
        {
            Dome
        }

        private void btCloseNorth_Click(object sender, EventArgs e)
        {

        }

        private void btCloseSouth_Click(object sender, EventArgs e)
        {

        }

        private void btOpenSouth_Click(object sender, EventArgs e)
        {

        }

        private void ckStepByStep_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion


    }
}