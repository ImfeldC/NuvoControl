﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuvoControl.Server.WebServer.MonitorAndControlServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Address", Namespace="http://schemas.datacontract.org/2004/07/NuvoControl.Common.Configuration")]
    [System.SerializableAttribute()]
    public partial class Address : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int _deviceIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int _objectIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _deviceId {
            get {
                return this._deviceIdField;
            }
            set {
                if ((this._deviceIdField.Equals(value) != true)) {
                    this._deviceIdField = value;
                    this.RaisePropertyChanged("_deviceId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _objectId {
            get {
                return this._objectIdField;
            }
            set {
                if ((this._objectIdField.Equals(value) != true)) {
                    this._objectIdField = value;
                    this.RaisePropertyChanged("_objectId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ZoneState", Namespace="http://schemas.datacontract.org/2004/07/NuvoControl.Common")]
    [System.SerializableAttribute()]
    public partial class ZoneState : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool _commandUnacknowledgedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid _guidField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime _lastUpdateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool _powerStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address _sourceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int _volumeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NuvoControl.Server.WebServer.MonitorAndControlServiceReference.ZoneQuality _zoneQualityField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool _commandUnacknowledged {
            get {
                return this._commandUnacknowledgedField;
            }
            set {
                if ((this._commandUnacknowledgedField.Equals(value) != true)) {
                    this._commandUnacknowledgedField = value;
                    this.RaisePropertyChanged("_commandUnacknowledged");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid _guid {
            get {
                return this._guidField;
            }
            set {
                if ((this._guidField.Equals(value) != true)) {
                    this._guidField = value;
                    this.RaisePropertyChanged("_guid");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime _lastUpdate {
            get {
                return this._lastUpdateField;
            }
            set {
                if ((this._lastUpdateField.Equals(value) != true)) {
                    this._lastUpdateField = value;
                    this.RaisePropertyChanged("_lastUpdate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool _powerStatus {
            get {
                return this._powerStatusField;
            }
            set {
                if ((this._powerStatusField.Equals(value) != true)) {
                    this._powerStatusField = value;
                    this.RaisePropertyChanged("_powerStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address _source {
            get {
                return this._sourceField;
            }
            set {
                if ((object.ReferenceEquals(this._sourceField, value) != true)) {
                    this._sourceField = value;
                    this.RaisePropertyChanged("_source");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int _volume {
            get {
                return this._volumeField;
            }
            set {
                if ((this._volumeField.Equals(value) != true)) {
                    this._volumeField = value;
                    this.RaisePropertyChanged("_volume");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NuvoControl.Server.WebServer.MonitorAndControlServiceReference.ZoneQuality _zoneQuality {
            get {
                return this._zoneQualityField;
            }
            set {
                if ((this._zoneQualityField.Equals(value) != true)) {
                    this._zoneQualityField = value;
                    this.RaisePropertyChanged("_zoneQuality");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ZoneQuality", Namespace="http://schemas.datacontract.org/2004/07/NuvoControl.Common")]
    public enum ZoneQuality : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Online = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Offline = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MonitorAndControlServiceReference.IMonitorAndControl", CallbackContract=typeof(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.IMonitorAndControlCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IMonitorAndControl {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonitorAndControl/Connect", ReplyAction="http://tempuri.org/IMonitorAndControl/ConnectResponse")]
        void Connect();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/Disconnect", ReplyAction="http://tempuri.org/IMonitorAndControl/DisconnectResponse")]
        void Disconnect();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/RenewLease", ReplyAction="http://tempuri.org/IMonitorAndControl/RenewLeaseResponse")]
        void RenewLease();
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/SetZoneState", ReplyAction="http://tempuri.org/IMonitorAndControl/SetZoneStateResponse")]
        void SetZoneState(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address zoneId, NuvoControl.Server.WebServer.MonitorAndControlServiceReference.ZoneState stateCommand);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/GetZoneState", ReplyAction="http://tempuri.org/IMonitorAndControl/GetZoneStateResponse")]
        NuvoControl.Server.WebServer.MonitorAndControlServiceReference.ZoneState GetZoneState(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address zoneId);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/Monitor", ReplyAction="http://tempuri.org/IMonitorAndControl/MonitorResponse")]
        void Monitor(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address zoneId);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/MonitorMultiple", ReplyAction="http://tempuri.org/IMonitorAndControl/MonitorMultipleResponse")]
        void MonitorMultiple(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address[] zoneIds);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/RemoveMonitor", ReplyAction="http://tempuri.org/IMonitorAndControl/RemoveMonitorResponse")]
        void RemoveMonitor(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address zoneId);
        
        [System.ServiceModel.OperationContractAttribute(IsInitiating=false, Action="http://tempuri.org/IMonitorAndControl/RemoveMonitorMultiple", ReplyAction="http://tempuri.org/IMonitorAndControl/RemoveMonitorMultipleResponse")]
        void RemoveMonitorMultiple(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address[] zoneIds);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMonitorAndControlCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMonitorAndControl/OnZoneStateChanged")]
        void OnZoneStateChanged(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address zoneId, NuvoControl.Server.WebServer.MonitorAndControlServiceReference.ZoneState zoneState);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMonitorAndControlChannel : NuvoControl.Server.WebServer.MonitorAndControlServiceReference.IMonitorAndControl, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MonitorAndControlClient : System.ServiceModel.DuplexClientBase<NuvoControl.Server.WebServer.MonitorAndControlServiceReference.IMonitorAndControl>, NuvoControl.Server.WebServer.MonitorAndControlServiceReference.IMonitorAndControl {
        
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
        
        public void SetZoneState(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address zoneId, NuvoControl.Server.WebServer.MonitorAndControlServiceReference.ZoneState stateCommand) {
            base.Channel.SetZoneState(zoneId, stateCommand);
        }
        
        public NuvoControl.Server.WebServer.MonitorAndControlServiceReference.ZoneState GetZoneState(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address zoneId) {
            return base.Channel.GetZoneState(zoneId);
        }
        
        public void Monitor(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address zoneId) {
            base.Channel.Monitor(zoneId);
        }
        
        public void MonitorMultiple(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address[] zoneIds) {
            base.Channel.MonitorMultiple(zoneIds);
        }
        
        public void RemoveMonitor(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address zoneId) {
            base.Channel.RemoveMonitor(zoneId);
        }
        
        public void RemoveMonitorMultiple(NuvoControl.Server.WebServer.MonitorAndControlServiceReference.Address[] zoneIds) {
            base.Channel.RemoveMonitorMultiple(zoneIds);
        }
    }
}
