﻿/**************************************************************************************************
 * 
 *   Copyright (C) 2009 by B. Limacher, Ch. Imfeld. All Rights Reserved.
 * 
 ***************************************************************************************************
 *
 *   Project:        NuvoControl
 *   SubProject:     NuvoControl.Server.ProtocolDriver.Interface
 *   Author:         Ch.Imfeld
 *   Creation Date:  6/12/2009 11:02:29 PM
 * 
 ***************************************************************************************************
 * 
 * Revisions:
 * 1) 6/12/2009 11:02:29 PM, Ch.Imfeld: Initial implementation.
 * 
 **************************************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace NuvoControl.Server.ProtocolDriver.Interface
{

    /// <summary>
    /// Event which is issued in case data has been received.
    /// </summary>
    /// <param name="sender">This pointer to the underlaying object.</param>
    /// <param name="e">Serial port event argument, containing the received text.</param>
    public delegate void SerialPortEventHandler(
              object sender, SerialPortEventArgs e);

    /// <summary>
    /// This class is used as parameter for the serial port event.
    /// It contains the received data, as string.
    /// </summary>
    public class SerialPortEventArgs : EventArgs
    {
        string _msg;

        /// <summary>
        /// Retunrs the message, received with thîs event.
        /// </summary>
        public string Message
        {
            get { return _msg; }
        }

        /// <summary>
        /// Constructor, for this argument class.
        /// The parameter <c>msg</c> sets the message string.
        /// </summary>
        /// <param name="msg"></param>
        public SerialPortEventArgs(string msg)
        {
            _msg = msg;
        }

    }

    /// <summary>
    /// This class contains all required information, to connet to a serial port.
    /// </summary>
    public class SerialPortConnectInformation
    {
        private string _portName;
        private int _baudRate;
        private Parity _parity;
        private int _dataBits;
        StopBits _stopBits;

        /// <summary>
        /// Returns the port name, e.g. "COM1"
        /// </summary>
        public string PortName
        {
            get { return _portName; }
        }

        /// <summary>
        /// Retruns the Baud rate, e.g. 9600
        /// </summary>
        public int BaudRate
        {
            get { return _baudRate; }
        }

        /// <summary>
        /// Returns the Parit mode, e.g. 'Odd' or 'Even'
        /// </summary>
        public Parity Parity
        {
            get { return _parity; }
        }

        /// <summary>
        /// Retruns the Data bits, e.g. 1
        /// </summary>
        public int DataBits
        {
            get { return _dataBits; }
        }

        /// <summary>
        /// Returns the Stop bits, e.g. 'None' or 'One'
        /// </summary>
        public StopBits StopBits
        {
            get { return _stopBits; }
        }

        /// <summary>
        /// Returns a string representative, for this object.
        /// The format is like: "PortName={0}, BaudRate={1}, Parity={2}, DataBits={3}, StopBits={4}"
        /// </summary>
        /// <returns>String representative for this object.</returns>
        public override string ToString()
        {
            return string.Format("PortName={0}, BaudRate={1}, Parity={2}, DataBits={3}, StopBits={4}",
                _portName, _baudRate, _parity, _dataBits, _stopBits);
        }



        /// <summary>
        ///     Initializes a new instance of the System.IO.Ports.SerialPort class using
        ///     the specified port name.
        ///
        /// Exceptions:
        ///   System.IO.IOException:
        ///     The specified port could not be found or opened.
        /// </summary>
        /// <param name="portName">The port to use (for example, COM1).</param>
        public SerialPortConnectInformation(string portName)
        {
            _portName = portName;
        }



        /// <summary>
        ///    Initializes a new instance of the System.IO.Ports.SerialPort class using
        ///    the specified port name and baud rate.
        ///Exceptions:
        ///  System.IO.IOException:
        ///    The specified port could not be found or opened.
        /// </summary>
        /// <param name="portName">The port to use (for example, COM1).</param>
        /// <param name="baudRate">The baud rate.</param>
        public SerialPortConnectInformation(string portName, int baudRate)
        {
            _portName = portName;
            _baudRate = baudRate;
        }

        /// <summary>
        ///     Initializes a new instance of the System.IO.Ports.SerialPort class using
        ///     the specified port name, baud rate, and parity bit.
        /// Exceptions:
        ///   System.IO.IOException:
        ///     The specified port could not be found or opened.
        /// </summary>
        /// <param name="portName">The port to use (for example, COM1).</param>
        /// <param name="baudRate">The baud rate.</param>
        /// <param name="parity">One of the System.IO.Ports.SerialPort.Parity values.</param>
        public SerialPortConnectInformation(string portName, int baudRate, Parity parity)
        {
            _portName = portName;
            _baudRate = baudRate;
            _parity = parity;
        }


        /// <summary>
        ///     Initializes a new instance of the System.IO.Ports.SerialPort class using
        ///     the specified port name, baud rate, parity bit, and data bits.
        /// Exceptions:
        ///   System.IO.IOException:
        ///     The specified port could not be found or opened.
        /// </summary>
        /// <param name="portName">The port to use (for example, COM1).</param>
        /// <param name="baudRate">The baud rate.</param>
        /// <param name="parity">One of the System.IO.Ports.SerialPort.Parity values.</param>
        /// <param name="dataBits">The data bits value.</param>
        public SerialPortConnectInformation(string portName, int baudRate, Parity parity, int dataBits)
        {
            _portName = portName;
            _baudRate = baudRate;
            _parity = parity;
            _dataBits = dataBits;
        }


        /// <summary>
        ///     Initializes a new instance of the System.IO.Ports.SerialPort class using
        ///     the specified port name, baud rate, parity bit, data bits, and stop bit.
        /// Exceptions:
        ///   System.IO.IOException:
        ///     The specified port could not be found or opened.
        /// </summary>
        /// <param name="portName">The port to use (for example, COM1).</param>
        /// <param name="baudRate">The baud rate.</param>
        /// <param name="parity">One of the System.IO.Ports.SerialPort.Parity values.</param>
        /// <param name="dataBits">The data bits value.</param>
        /// <param name="stopBits">One of the System.IO.Ports.SerialPort.StopBits values.</param>
        public SerialPortConnectInformation(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            _portName = portName;
            _baudRate = baudRate;
            _parity = parity;
            _dataBits = dataBits;
            _stopBits = stopBits;
        }

    }

    /// <summary>
    /// Public interface, that defines the methods and events which need to be implemented 
    /// by a serial port driver. It’s the ‘lowest’ level interface in the hierarchy. 
    /// Any serial port driver – or similar drivers, like mock or simulator – which implement 
    /// this interface can be easily integrated in NuvoControl.
    /// The event onDataReceived is issued in case data has been received.
    /// </summary>
    public interface ISerialPort
    {

        /// <summary>
        /// Event issued in case data arrives.
        /// </summary>
        event SerialPortEventHandler onDataReceived;


        /// <summary>
        ///
        /// Summary:
        ///     Opens a new serial port connection.
        ///
        /// Exceptions:
        ///   System.InvalidOperationException:
        ///     The specified port is open.
        ///
        ///   System.ArgumentOutOfRangeException:
        ///     One or more of the properties for this instance are invalid. For example,
        ///     the System.IO.Ports.SerialPort.Parity, System.IO.Ports.SerialPort.DataBits,
        ///     or System.IO.Ports.SerialPort.Handshake properties are not valid values;
        ///     the System.IO.Ports.SerialPort.BaudRate is less than or equal to zero; the
        ///     System.IO.Ports.SerialPort.ReadTimeout or System.IO.Ports.SerialPort.WriteTimeout
        ///     property is less than zero and is not System.IO.Ports.SerialPort.InfiniteTimeout.
        ///
        ///   System.ArgumentException:
        ///     The port name does not begin with "COM". - or - The file type of the port
        ///     is not supported.
        ///
        ///   System.IO.IOException:
        ///     The port is in an invalid state. - or - An attempt to set the state of the
        ///     underlying port failed. For example, the parameters passed from this System.IO.Ports.SerialPort
        ///     object were invalid.
        ///
        ///   System.UnauthorizedAccessException:
        ///     Access is denied to the port.
        /// </summary>
        /// <param name="serialPortConnectInformation">Connection infromation for the serial port, like baud rate, etc.</param>
        void Open( SerialPortConnectInformation serialPortConnectInformation );

        /// <summary>
        /// Summary:
        ///     Closes the port connection, sets the System.IO.Ports.SerialPort.IsOpen property
        ///     to false, and disposes of the internal System.IO.Stream object.
        ///
        /// Exceptions:
        ///   System.InvalidOperationException:
        ///     The specified port is not open.
        /// </summary>
        void Close();

        /// <summary>
        ///
        /// Summary:
        ///     Gets a value indicating the open or closed status of the System.IO.Ports.SerialPort
        ///     object.
        ///
        /// Returns:
        ///     true if the serial port is open; otherwise, false. The default is false.
        ///
        /// Exceptions:
        ///   System.ArgumentNullException:
        ///     The System.IO.Ports.SerialPort.IsOpen value passed is null.
        ///
        ///   System.ArgumentException:
        ///     The System.IO.Ports.SerialPort.IsOpen value passed is an empty string ("").
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        ///
        /// Summary:
        ///     Writes the specified string to the serial port.
        ///
        /// Parameters:
        ///   text:
        ///     The string for output.
        ///
        /// Exceptions:
        ///   System.InvalidOperationException:
        ///     The specified port is not open.
        ///
        ///   System.ArgumentNullException:
        ///     str is null.
        ///
        ///   System.ServiceProcess.TimeoutException:
        ///     The operation did not complete before the time-out period ended.
        /// </summary>
        /// <param name="text">Message as string, which shall be written to the serial port.</param>
        void Write(string text);
    }
}
