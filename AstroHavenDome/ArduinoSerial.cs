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
            STATUS_BOTH_OPEN = "3";

        internal ArduinoSerial(String comPort, StopBits stopBits, int baud, bool autostart)
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

        private void ArduinoSerial_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            Dome.Logger.LogIssue("Arduino", e.EventType.ToString());
        }

        internal ArduinoSerial() : this(DEFAULT_COMPORT, StopBits.One, 9600, true) { }

        private void ArduinoSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ReplyQueue.Push(this.ReadLine().Trim("\r".ToCharArray())); // Push latest command onto the stack
            OnReplyReceived(this, e);
        }

        internal void SendCommand(string command)
        {
            this.Write(command);
        }

        internal void ResetConnection()
        {
            this.Close();
            _utils.WaitForMilliseconds(1000);

            this.Open();
            _utils.WaitForMilliseconds(3000);
        }
    }
}