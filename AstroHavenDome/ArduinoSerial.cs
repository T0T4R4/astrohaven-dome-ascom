using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Ports;
using ASCOM.Utilities;

namespace ASCOM.AstroHaven
{
    internal class ArduinoSerial : SerialPort
    {
        private Util _utils = new Util(); // Helper class

        internal Stack ReplyQueue = new Stack(); // Our command received stack

        internal delegate void ReplyReceivedEventHandler(object sender, EventArgs e); // Our Process stack callback
        internal event ReplyReceivedEventHandler OnReplyReceived;

        private const string LOGGER = "Dome Hardware";

        internal static string

            COMMAND_GET_STATUS = "S",
            COMMAND_OPEN_LEFT = "a",
            COMMAND_OPEN_RIGHT = "b",
            COMMAND_CLOSE_LEFT = "A",
            COMMAND_CLOSE_RIGHT = "B",
            COMMAND_OPEN_BOTH = "O",
            COMMAND_CLOSE_BOTH = "C",
            COMMAND_RESET = "R",

            STATUS_BOTH_CLOSED = "0",
            STATUS_RIGHT_OPEN_LEFT_CLOSED = "1",
            STATUS_RIGHT_CLOSED_LEFT_OPEN = "2",
            STATUS_BOTH_OPEN = "3",

            RESPONSE_LEFT_ALREADY_CLOSED = "X",
            RESPONSE_LEFT_ALREADY_OPEN = "x",
            RESPONSE_RIGHT_ALREADY_CLOSED = "Y",
            RESPONSE_RIGHT_ALREADY_OPEN = "y";

        internal static int DEFAULT_BAUD = 9600;

        public string LastReceivedChar { get; private set; }

        internal ArduinoSerial(String comPort, int baud, bool autostart, StopBits stopBits)
        {
            this.Parity = Parity.None;
            this.PortName = comPort;
            this.StopBits = stopBits;
            this.BaudRate = baud;
            this.DataReceived += new SerialDataReceivedEventHandler(ArduinoSerial_DataReceived);
            this.ErrorReceived += ArduinoSerial_ErrorReceived;

            if (autostart)
                this.Open();
        }
        internal ArduinoSerial(String comPort, int baud) : this(comPort, baud, true, StopBits.One) { }
        //internal ArduinoSerial() : this("", DEFAULT_BAUD, true, StopBits.One) { }

        private void ArduinoSerial_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Dome.Logger.LogIssue(LOGGER, e.EventType.ToString());
        }

        private void readExisting()
        {
            var chars = this.ReadExisting().Trim("\r\n".ToCharArray());

            if ((!string.IsNullOrEmpty(chars) && chars.Length > 0))
                LastReceivedChar = chars[0].ToString();
            else
                LastReceivedChar = null;
        }

        private void ArduinoSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!this.IsOpen) return;

                // readExisting
                var c = (char)this.ReadChar();
                LastReceivedChar = c.ToString();

                OnReplyReceived(this, e);
            }
            catch (IOException exc)
            {
                // happens when we disconnect (thread killed ?)
                Dome.Logger.LogIssue(LOGGER, exc.ToString());
            }
        }


        internal void SendCommand(string command)
        {
            if (!this.IsOpen) return;

            _utils.WaitForMilliseconds(Dome.MinDelayBtwnCommands);

            this.Write(command);

            readExisting();
        }

        internal void ResetConnection()
        {
            if (this.IsOpen)
            {
                this.Close();
                _utils.WaitForMilliseconds(1000);
            }

            this.Open();
            _utils.WaitForMilliseconds(1000);
        }

    }
}