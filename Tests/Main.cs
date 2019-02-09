using ASCOM.DriverAccess;
using System;
using System.Windows.Forms;

namespace ASCOM.AstroHaven
{
    public partial class Main : Form
    {
        public const string
            ACTION_GET_STATUS = "ACTION_GET_STATUS",
            ACTION_LASTSTATUS = "ACTION_LAST_STATUS",

            ACTION_OPEN_LEFT = "ACTION_OPEN_LEFT",
            ACTION_OPEN_RIGHT = "ACTION_OPEN_RIGHT",

            ACTION_CLOSE_LEFT = "ACTION_CLOSE_LEFT",
            ACTION_CLOSE_RIGHT = "ACTION_CLOSE_RIGHT",

            ACTION_OPEN_BOTH = "ACTION_OPEN_BOTH",
            ACTION_CLOSE_BOTH = "ACTION_CLOSE_BOTH"

           ;

        public const string
            STATUS_BOTH_CLOSED = "0",
            STATUS_RIGHT_CLOSED = "1",
            STATUS_LEFT_CLOSED = "2",
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
                case STATUS_LEFT_CLOSED:
                    return "Left panel closed";
                case STATUS_RIGHT_CLOSED:
                    return "Right panel closed";

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
                if (string.IsNullOrEmpty(Properties.Settings.Default.DriverId))
                    Properties.Settings.Default.DriverId = ASCOM.DriverAccess.Dome.Choose("ASCOM.AstroHaven.Dome");

                TryConnect(true); // try to autoconnect
            }
            catch (Exception exc)
            {
                Log(exc);
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            if (toolStripStatusLabel2.Tag != null)
                MessageBox.Show("Error details", (string)toolStripStatusLabel2.Tag);
        }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsConnected)
                _dome.Connected = false;

            Properties.Settings.Default.Save();
        }

        private void btOpenRight_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                _dome.Action(ACTION_OPEN_RIGHT, string.Empty);
            }
            catch (Exception exc)
            {
                Log(exc);
            }
        }

        private void btCloseLeft_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                _dome.Action(ACTION_CLOSE_LEFT, string.Empty);
            }
            catch (Exception exc)
            {
                Log(exc);
            }
        }

        private void btCloseRight_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                _dome.Action(ACTION_CLOSE_RIGHT, string.Empty);
            }
            catch (Exception exc)
            {
                Log(exc);
            }
        }

        private void btOpenLeft_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                _dome.Action(ACTION_OPEN_LEFT, string.Empty);
            }
            catch (Exception exc)
            {
                Log(exc);
            }
        }

        private void btChoose_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DriverId = ASCOM.DriverAccess.Dome.Choose(Properties.Settings.Default.DriverId);

            if (string.IsNullOrEmpty(Properties.Settings.Default.DriverId))
            {
                toolStripStatusLabel2.Text = "Please select an ASCOM Driver";
            } else
                toolStripStatusLabel2.Text = string.Empty;

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

                var tempStatus = (lastStatus == RESPONSE_LEFT_ALREADY_CLOSED) ||
                    (lastStatus == RESPONSE_RIGHT_ALREADY_CLOSED) ||
                    (lastStatus == RESPONSE_LEFT_ALREADY_OPEN) ||
                    (lastStatus == RESPONSE_RIGHT_ALREADY_OPEN);

                if (!tempStatus)
                {

                    bool leftShutterClosed = (lastStatus == STATUS_BOTH_CLOSED) || (lastStatus == STATUS_LEFT_CLOSED);
                    bool rightShutterClosed = (lastStatus == STATUS_BOTH_CLOSED) || (lastStatus == STATUS_RIGHT_CLOSED);

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
                case STATUS_LEFT_CLOSED:
                    return 1;
                case STATUS_RIGHT_CLOSED:
                    return 2;
                case STATUS_BOTH_OPEN:
                    return 3;
                default:
                    return -1;
            }
        }
    }
}
