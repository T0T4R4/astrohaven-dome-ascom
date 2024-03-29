﻿using ASCOM.DriverAccess;
using System;
using System.Windows.Forms;

namespace ASCOM.AstroHaven
{
    public partial class Main : Form
    {
        // Copy pasted list of actions and statuses from the Dome driver
        //

        internal const string
            ACTION_GET_STATUS = "ACTION_GET_STATUS",
            ACTION_LASTSTATUS = "ACTION_LAST_STATUS",

            ACTION_ABORT = "ACTION_ABORT",

            ACTION_OPEN_BOTH = "ACTION_OPEN_BOTH",
            ACTION_CLOSE_BOTH = "ACTION_CLOSE_BOTH"
           ;

        internal const string
            STATUS_BOTH_CLOSED = "0",
            STATUS_RIGHT_OPEN_LEFT_CLOSED = "1",
            STATUS_RIGHT_CLOSED_LEFT_OPEN = "2",
            STATUS_BOTH_OPEN = "3",

            RESPONSE_LEFT_ALREADY_CLOSED = "X",
            RESPONSE_LEFT_ALREADY_OPEN = "x",
            RESPONSE_RIGHT_ALREADY_CLOSED = "Y",
            RESPONSE_RIGHT_ALREADY_OPEN = "y";

        public string GetStatusDescription(string statusCode)
        {
            switch (statusCode)
            {
                case STATUS_BOTH_CLOSED:
                    return "Both panels closed";
                case STATUS_BOTH_OPEN:
                    return "Both panels open";
                case STATUS_RIGHT_OPEN_LEFT_CLOSED:
                    return "Right panel is still open";
                case STATUS_RIGHT_CLOSED_LEFT_OPEN:
                    return "Left panel is still open";

                case RESPONSE_LEFT_ALREADY_CLOSED:
                    return "Left panel already closed";
                case RESPONSE_LEFT_ALREADY_OPEN:
                    return "Left panel already open";
                case RESPONSE_RIGHT_ALREADY_CLOSED:
                    return "Right panel already closed";
                case RESPONSE_RIGHT_ALREADY_OPEN:
                    return "Right panel already open";

                default:
                    return String.Format("Unknown '{0}'", statusCode);
            }
        }

        private enum Panel { Left, Right }
        private enum Direction { Open, Close }
        private enum Step { Full, Partial }

        private string GetActionName(Panel panel, Direction direction, Step step)
        {
            var p = (panel == Panel.Left) ? "LEFT" : "RIGHT";
            var d = (direction == Direction.Open) ? "OPEN" : "CLOSE";
            var s = (step == Step.Full) ? "FULL" : "STEP";

            return string.Format("ACTION_{0}_{1}_{2}", d, p, s);
        }

        private void doDomeAction(Panel panel, Direction direction, bool stepBystep)
        {
            if (stepBystep)
            {
                // step by step
                _dome.Action(GetActionName(panel, direction, Step.Partial), string.Empty);
            }
            else
            {
                _dome.Action(GetActionName(panel, direction, Step.Full), string.Empty);
            }
        }


        private ASCOM.DriverAccess.Dome _dome;
        private string _lastStatusDescription;

        public Main()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SetButtonClicks();
                if (string.IsNullOrEmpty(Properties.Settings.Default.DriverId))
                    Properties.Settings.Default.DriverId = ASCOM.DriverAccess.Dome.Choose("ASCOM.AstroHaven.Dome");

                TryConnect(true); // try to autoconnect
            }
            catch (Exception exc)
            {
                Log(exc);
            }
        }

        private void SetButtonClicks()
        {
            btCloseLeft.Tag = new object[] { Panel.Left, Direction.Close };
            btCloseLeft.Click += OnDomeActionClicked;

            btOpenLeft.Tag = new object[] { Panel.Left, Direction.Open };
            btOpenLeft.Click += OnDomeActionClicked;

            btCloseRight.Tag = new object[] { Panel.Right, Direction.Close };
            btCloseRight.Click += OnDomeActionClicked;

            btOpenRight.Tag = new object[] { Panel.Right, Direction.Open };
            btOpenRight.Click += OnDomeActionClicked;
        }

        private void OnDomeActionClicked(object sender, EventArgs e)
        {
            var par = (object[]) ((Button)sender).Tag;
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(par);
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel2.Tag != null)
                MessageBox.Show("Error details", (string)toolStripStatusLabel2.Tag);
        }

        private void picASCOM_Click(object sender, EventArgs e)
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

        private void picAstroHaven_Click(object sender, EventArgs e)
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

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var par = (object[]) e.Argument;
            toolStripStatusLabel2.Text = "Please wait...";
            doDomeAction((Panel)par[0], (Direction)par[1], ModifierKeys == Keys.Shift);
        }
        
        private void btAbort_Click(object sender, EventArgs e)
        {
            _dome.Action(ACTION_ABORT, "");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TryConnect(false);

            Properties.Settings.Default.Save();
        }
      

        private void btChoose_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DriverId = ASCOM.DriverAccess.Dome.Choose(Properties.Settings.Default.DriverId);

            if (string.IsNullOrEmpty(Properties.Settings.Default.DriverId))
            {
                toolStripStatusLabel2.Text = "Please select an ASCOM Driver";
            }
            else
            {
                toolStripStatusLabel2.Text = string.Empty;
            }
        }


        private bool IsConnected
        {
            get
            {
                var connected = ((this._dome != null) && (_dome.Connected == true));
                return connected;
            }
        }


        void TryConnect(bool connect)
        {
            try
            {
                if (_dome == null)
                    _dome = new Dome(Properties.Settings.Default.DriverId);

                _lastStatusDescription = connect ? "Connecting..." : "Disconnecting...";

                btConnect.Enabled = false;
                _dome.Connected = connect; // try to connect to dome
                btConnect.Enabled = true;

                if (connect && !_dome.Connected)
                {
                    // failed to connect to dome
                    _lastStatusDescription = string.Format("Failed to connect to dome.");
                }
                else
                {
                    _lastStatusDescription = _dome.Connected ? "Connected" : "Not connected";
                }
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception exc)
            {
                _lastStatusDescription = string.Format("Failed to {0}:", connect ? "connect" : "disconnecting");
                Log(exc);
            }

        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            TryConnect(!IsConnected);
        }

        #region Actions


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


        private void Log(Exception exc)
        {
            toolStripStatusLabel2.Text = exc.Message;
            toolStripStatusLabel2.Tag = exc.ToString();
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            btConnect.Text = IsConnected ? "Disconnect" : "Connect";
            gpControl.Enabled = IsConnected;

            toolStripStatusLabel1.Text = _lastStatusDescription;

            if (IsConnected)
            {
                var lastStatus = _dome.Action(ACTION_LASTSTATUS, string.Empty);

                toolStripStatusLabel3.Text = GetStatusDescription(lastStatus);

                var statusAlert = (lastStatus == RESPONSE_LEFT_ALREADY_CLOSED) ||
                    (lastStatus == RESPONSE_RIGHT_ALREADY_CLOSED) ||
                    (lastStatus == RESPONSE_LEFT_ALREADY_OPEN) ||
                    (lastStatus == RESPONSE_RIGHT_ALREADY_OPEN);

                if (!statusAlert)
                {
                    bool leftShutterClosed = (lastStatus == STATUS_BOTH_CLOSED) || 
                        (lastStatus == STATUS_RIGHT_OPEN_LEFT_CLOSED);
                    bool rightShutterClosed = (lastStatus == STATUS_BOTH_CLOSED) || 
                        (lastStatus == STATUS_RIGHT_CLOSED_LEFT_OPEN);

                    lbLeftShutterStatus.Text = leftShutterClosed ? "Closed" : "Open";
                    lbRightShutterStatus.Text = rightShutterClosed ? "Closed" : "Open";
                }

                var imgIndex = getImageIndex(lastStatus);
                pictureBox2.Visible = (imgIndex > -1);

                if (imgIndex > -1)
                {
                    pictureBox2.Image = imageList1.Images[imgIndex];
                }
            }
            else
            {
                toolStripStatusLabel1.Text = string.IsNullOrEmpty(_lastStatusDescription) ? "Ready" : _lastStatusDescription;
                toolStripStatusLabel3.Text = string.Empty;

                lbLeftShutterStatus.Text = string.Empty;
                lbRightShutterStatus.Text = string.Empty;
            }
        }

        private int getImageIndex(string lastStatus)
        {
            switch (lastStatus)
            {
                case STATUS_BOTH_CLOSED:
                    return 0;
                case STATUS_RIGHT_OPEN_LEFT_CLOSED:
                    return 1;
                case STATUS_RIGHT_CLOSED_LEFT_OPEN:
                    return 2;
                case STATUS_BOTH_OPEN:
                    return 3;
                default:
                    return -1;
            }
        }
    }
}
