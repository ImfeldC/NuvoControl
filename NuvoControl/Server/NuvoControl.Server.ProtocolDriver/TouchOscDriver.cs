﻿/**************************************************************************************************
 * 
 *   Copyright (C) 2016 by Ch. Imfeld. All Rights Reserved.
 * 
 ***************************************************************************************************
 *
 *   Project:        NuvoControl
 *   SubProject:     NuvoControl.Server.HostConsole
 * 
 **************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using Common.Logging;

using Bespoke.Common;
using Bespoke.Common.Osc;

using NuvoControl.Common;
using NuvoControl.Common.Configuration;
using NuvoControl.Server.ProtocolDriver.Interface;



namespace NuvoControl.Server.ProtocolDriver
{
    public class TouchOscDriver : IOscDriver
    {
        public event OscEventReceivedEventHandler onOscEventReceived;

        private OSCDevice _oscDevice;
        private OscServer _oscServer;

        public TouchOscDriver(OSCDevice oscDevice)
        {
            _oscDevice = oscDevice;
            if (_oscDevice.DeviceType == eOSCDeviceType.OSCServer)
            {
                _oscServer = new OscServer(TransportType.Udp, oscDevice.IpAddress, oscDevice.Port, true, false);
            }
        }

        public void Start()
        {
            if (_oscServer != null)
            {
                _oscServer.BundleReceived += new EventHandler<OscBundleReceivedEventArgs>(oscServer_BundleReceived);
                _oscServer.MessageReceived += new EventHandler<OscMessageReceivedEventArgs>(oscServer_MessageReceived);
                _oscServer.ReceiveErrored += new EventHandler<ExceptionEventArgs>(oscServer_ReceiveErrored);
                _oscServer.Start();
            }
        }

        public void Stop()
        {
            if (_oscServer != null)
            {
                _oscServer.Stop();
            }
        }


        #region OSC Server Events

        private static int sBundlesReceivedCount = 0;
        private static int sMessagesReceivedCount = 0;

        private void oscServer_BundleReceived(object sender, OscBundleReceivedEventArgs e)
        {
            sBundlesReceivedCount++;
            OscBundle bundle = e.Bundle;
            LogHelper.Log(LogLevel.Info, string.Format("[OSC] Bundle Rcv [{0}:{1}]: Nested Bundles: {2} Nested Messages: {3} [{4}]", bundle.SourceEndPoint.Address, bundle.TimeStamp, bundle.Bundles.Count, bundle.Messages.Count, sBundlesReceivedCount));
        }

        private void oscServer_MessageReceived(object sender, OscMessageReceivedEventArgs e)
        {
            sMessagesReceivedCount++;
            LogHelper.Log(LogLevel.Info, string.Format("[OSC] Msg Rcv [{0}]: {1} / Message contains {2} objects. [{3}]", e.Message.SourceEndPoint.Address, e.Message.Address, e.Message.Data.Count, sMessagesReceivedCount));
            for (int i = 0; i < e.Message.Data.Count; i++)
            {
                LogHelper.Log(LogLevel.Debug, string.Format("[OSC] {0}: Value={1}", i, convertDataString(e.Message.Data[i])));
            }

            OscEvent oscEvent = processTouchOscMessage(e.Message);
            if (oscEvent != null)
            {
                LogHelper.Log(LogLevel.Info, string.Format("[OSC] OscEvent={0}", oscEvent.ToString()));
                //raise the event, and pass data to next layer
                if (onOscEventReceived != null)
                {
                    onOscEventReceived(this, new OscEventReceivedEventArgs(_oscDevice.DeviceId, oscEvent));
                }
            }
        }

        private void oscServer_ReceiveErrored(object sender, ExceptionEventArgs e)
        {
            LogHelper.Log(LogLevel.Error, string.Format("[OSC] Error during reception of osc packet: {0}", e.Exception.Message));
        }

        private OscEvent processTouchOscMessage(OscMessage message)
        {
            if( String.Compare(message.Address,"/ping")==0)
            {
                return new OscEvent( OscEvent.eOscEvent.Ping, message.Address );
            }
            if( message.Address.IndexOf("toggle")>0)
            {
                return new OscEvent((int.Parse(convertDataString(message.Data[0])) == 1 ? OscEvent.eOscEvent.SwitchOn : OscEvent.eOscEvent.SwitchOff), message.Address);
            }
            if (message.Address.IndexOf("push") > 0)
            {
                return new OscEvent((int.Parse(convertDataString(message.Data[0])) == 1 ? OscEvent.eOscEvent.SwitchOn : OscEvent.eOscEvent.SwitchOff), message.Address);
            }
            if (message.Address.IndexOf("fader") > 0)
            {
                return new OscEvent(OscEvent.eOscEvent.SetValue, message.Address, double.Parse(convertDataString(message.Data[0])));
            }
            if (message.Address.IndexOf("xy") > 0)
            {
                return new OscEvent(OscEvent.eOscEvent.SetValues, message.Address, double.Parse(convertDataString(message.Data[0])), double.Parse(convertDataString(message.Data[1])));
            }
            return null;
        }

        private string convertDataString(object data)
        {
            string dataString;

            if (data == null)
            {
                dataString = "Nil";
            }
            else
            {
                dataString = (data is byte[] ? BitConverter.ToString((byte[])data) : data.ToString());
            }

            return dataString;
        }

        #endregion



        public void RegisterMethod(OscEvent oscEvent)
        {
            throw new NotImplementedException();
        }

    }
}
