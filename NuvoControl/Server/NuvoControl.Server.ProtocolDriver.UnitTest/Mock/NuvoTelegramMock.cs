﻿/**************************************************************************************************
 * 
 *   Copyright (C) 2009 by B. Limacher, Ch. Imfeld. All Rights Reserved.
 * 
 ***************************************************************************************************
 *
 *   Project:        NuvoControl
 *   SubProject:     NuvoControl.Server.ProtocolDriver.UnitTest
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
using NuvoControl.Server.ProtocolDriver.Interface;
using Common.Logging;

namespace NuvoControl.Server.ProtocolDriver.Test.Mock
{
    class NuvoTelegramMock : ITelegram
    {
        #region Common Logger
        /// <summary>
        /// Common logger object. Requires the using directive <c>Common.Logging</c>. See 
        /// <see cref="LogManager"/> for more information.
        /// </summary>
        private ILog _log = LogManager.GetCurrentClassLogger();
        #endregion

        private bool _closeMethodCalled;
        private bool _openMethodCalled;
        SerialPortConnectInformation _serialPortConnectInformation;
        private string _telegram;
        private List<string> _telegramList = new List<string>();


        #region ITelegram Members

        public event TelegramEventHandler onTelegramReceived;

        public void Close()
        {
            _log.Debug(m => m("Close called."));
            _closeMethodCalled = true;
        }

        public void Open(SerialPortConnectInformation serialPortConnectInformation)
        {
            _log.Debug(m => m("Open called. {0}", serialPortConnectInformation.ToString()));
            _openMethodCalled = true;
            _serialPortConnectInformation = serialPortConnectInformation;
        }

        public void SendTelegram(string telegram)
        {
            _log.Debug(m => m("Send called. {0}", telegram));
            _telegram = telegram;
            _telegramList.Add(telegram);
        }


        #endregion

        //
        // Mock Specific Methods
        //

        public void passDataToTestClass(string msg)
        {
            //raise the event, and pass data to next layer
            if (onTelegramReceived != null)
            {
                onTelegramReceived(this,
                  new TelegramEventArgs(msg));
            }
            _telegramList.Add(msg);
        }

        public bool CloseMethodCalled
        {
            get { return _closeMethodCalled; }
        }
        public bool OpenMethodCalled
        {
            get { return _openMethodCalled; }
        }
        public SerialPortConnectInformation SerialPortConnectInformation
        {
            get { return _serialPortConnectInformation; }
        }
        public string Telegram
        {
            get { return _telegram; }
        }
        public List<string> TelegramList
        {
            get { return _telegramList; }
        }


    }
}
