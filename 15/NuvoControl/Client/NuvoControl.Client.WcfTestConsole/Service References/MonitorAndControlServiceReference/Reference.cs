﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuvoControl.Client.WcfTestConsole.MonitorAndControlServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MonitorAndControlServiceReference.IMonitorAndControl", CallbackContract=typeof(NuvoControl.Client.WcfTestConsole.MonitorAndControlServiceReference.IMonitorAndControlCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IMonitorAndControl {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonitorAndControl/Connect", ReplyAction="http://tempuri.org/IMonitorAndControl/ConnectResponse")]
        void Connect();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/Disconnect", ReplyAction="http://tempuri.org/IMonitorAndControl/DisconnectResponse")]
        void Disconnect();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/RenewLease", ReplyAction="http://tempuri.org/IMonitorAndControl/RenewLeaseResponse")]
        void RenewLease();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/SetZoneState", ReplyAction="http://tempuri.org/IMonitorAndControl/SetZoneStateResponse")]
        void SetZoneState(NuvoControl.Common.Configuration.Address zoneId, NuvoControl.Common.ZoneState stateCommand);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/GetZoneState", ReplyAction="http://tempuri.org/IMonitorAndControl/GetZoneStateResponse")]
        NuvoControl.Common.ZoneState GetZoneState(NuvoControl.Common.Configuration.Address zoneId);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/Monitor", ReplyAction="http://tempuri.org/IMonitorAndControl/MonitorResponse")]
        void Monitor(NuvoControl.Common.Configuration.Address zoneId);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/MonitorMultiple", ReplyAction="http://tempuri.org/IMonitorAndControl/MonitorMultipleResponse")]
        void MonitorMultiple(NuvoControl.Common.Configuration.Address[] zoneIds);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/RemoveMonitor", ReplyAction="http://tempuri.org/IMonitorAndControl/RemoveMonitorResponse")]
        void RemoveMonitor(NuvoControl.Common.Configuration.Address zoneId);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/RemoveMonitorMultiple", ReplyAction="http://tempuri.org/IMonitorAndControl/RemoveMonitorMultipleResponse")]
        void RemoveMonitorMultiple(NuvoControl.Common.Configuration.Address[] zoneIds);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IMonitorAndControlCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMonitorAndControl/OnZoneStateChanged")]
        void OnZoneStateChanged(NuvoControl.Common.Configuration.Address zoneId, NuvoControl.Common.ZoneState zoneState);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IMonitorAndControlChannel : NuvoControl.Client.WcfTestConsole.MonitorAndControlServiceReference.IMonitorAndControl, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class MonitorAndControlClient : System.ServiceModel.DuplexClientBase<NuvoControl.Client.WcfTestConsole.MonitorAndControlServiceReference.IMonitorAndControl>, NuvoControl.Client.WcfTestConsole.MonitorAndControlServiceReference.IMonitorAndControl {
        
        public MonitorAndControlClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public MonitorAndControlClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public MonitorAndControlClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MonitorAndControlClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MonitorAndControlClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Connect() {
            base.Channel.Connect();
        }
        
        public void Disconnect() {
            base.Channel.Disconnect();
        }
        
        public void RenewLease() {
            base.Channel.RenewLease();
        }
        
        public void SetZoneState(NuvoControl.Common.Configuration.Address zoneId, NuvoControl.Common.ZoneState stateCommand) {
            base.Channel.SetZoneState(zoneId, stateCommand);
        }
        
        public NuvoControl.Common.ZoneState GetZoneState(NuvoControl.Common.Configuration.Address zoneId) {
            return base.Channel.GetZoneState(zoneId);
        }
        
        public void Monitor(NuvoControl.Common.Configuration.Address zoneId) {
            base.Channel.Monitor(zoneId);
        }
        
        public void MonitorMultiple(NuvoControl.Common.Configuration.Address[] zoneIds) {
            base.Channel.MonitorMultiple(zoneIds);
        }
        
        public void RemoveMonitor(NuvoControl.Common.Configuration.Address zoneId) {
            base.Channel.RemoveMonitor(zoneId);
        }
        
        public void RemoveMonitorMultiple(NuvoControl.Common.Configuration.Address[] zoneIds) {
            base.Channel.RemoveMonitorMultiple(zoneIds);
        }
    }
}
