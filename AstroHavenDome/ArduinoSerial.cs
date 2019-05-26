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

        internal const string

            GET_STATUS = "S",
            RESET_MOTORS = "R",

            OPEN_LEFT = "a",
            OPENING_LEFT = "a", // response when OPEN_LEFT is sent

            OPEN_RIGHT = "b",
            OPENING_RIGHT = "b", // response when OPEN_RIGHT is sent

            CLOSE_LEFT = "A",
            CLOSING_LEFT = "A",  // response when CLOSE_LEFT is sent

            CLOSE_RIGHT = "B",
            CLOSING_RIGHT = "B",  // response when CLOSE_RIGHT is sent

            // responses when sending the above commands and 
            // domes are already beyond threshold
            LEFT_ALREADY_CLOSED = "X",
            LEFT_ALREADY_OPEN = "x",
            RIGHT_ALREADY_CLOSED = "Y",
            RIGHT_ALREADY_OPEN = "y",

        // status returned on idle (when no command is sent)
            BOTH_CLOSED = "0",
            LEFT_CLOSED = "1",
            RIGHT_CLOSED = "2",
            BOTH_OPEN = "3"

            ;

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

        private void ArduinoSerial_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Dome.Logger.LogIssue(LOGGER, e.EventType.ToString());
        }

        private void readExisting()
        {
            LastReceivedChar = null;
            var chars = this.ReadExisting();

            if (chars != null)
            {
                chars = chars.Trim("\r\n".ToCharArray());

                if ((!string.IsNullOrEmpty(chars) && chars.Length > 0))
                    LastReceivedChar = chars[0].ToString();
            }
                
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


        internal void Send(string text)
        {
            if (!this.IsOpen) return;

            _utils.WaitForMilliseconds(Dome.MinDelayBtwnCommands);

            this.Write(text);             

            readExisting();
        }

    }
}