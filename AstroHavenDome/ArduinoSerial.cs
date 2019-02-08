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

        internal static string
            DEFAULT_COMPORT = "COM4",

            COMMAND_GET_STATUS = "S",
            COMMAND_OPEN_LEFT = "a",
            COMMAND_OPEN_RIGHT = "b",
            COMMAND_CLOSE_LEFT = "A",
            COMMAND_CLOSE_RIGHT = "B",
            COMMAND_OPEN_BOTH = "O",
            COMMAND_CLOSE_BOTH = "C",
            COMMAND_RESET = "R",

            STATUS_BOTH_CLOSED = "0",
            STATUS_RIGHT_CLOSED = "1",
            STATUS_LEFT_CLOSED = "2",
            STATUS_BOTH_OPEN = "3",

            RESPONSE_LEFT_ALREADY_CLOSED = "X",
            RESPONSE_LEFT_ALREADY_OPEN = "x",
            RESPONSE_RIGHT_ALREADY_CLOSED = "Y",
            RESPONSE_RIGHT_ALREADY_OPEN = "y";

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
        internal ArduinoSerial() : this(DEFAULT_COMPORT, 9600, true, StopBits.One) { }

        private void ArduinoSerial_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Dome.Logger.LogIssue("Arduino", e.EventType.ToString());
        }

        private void ArduinoSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!this.IsOpen) return;

                var chars = this.ReadExisting().Trim("\r\n".ToCharArray());

                if ((!string.IsNullOrEmpty(chars) && chars.Length > 0))
                    LastReceivedChar = chars[0].ToString();
                else
                    LastReceivedChar = null;

                OnReplyReceived(this, e);
            }
            catch (IOException)
            {
                // happens when we disconnect (thread killed ?)
            }
        }


        internal string SendCommand(string command, bool waitForResponse = false)
        {
            if (!this.IsOpen) return null;

            this.Write(command);

            //if (waitForResponse)
            //    return this.this.ReadLine();

            return null;


        }

        internal void ResetConnection()
        {
            if (this.IsOpen)
            {
                this.Close();
                _utils.WaitForMilliseconds(1000);
            }

            this.Open();
            _utils.WaitForMilliseconds(3000);
        }
    }
}