﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PVCR.DragDropExample.Authenticate {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="labware_weblims_authenticate", ConfigurationName="Authenticate.labware_weblims_authenticatePortType")]
    public interface labware_weblims_authenticatePortType {
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:authenticate", ReplyAction="urn:authenticateResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        string authenticate(string username, string password, string limsDSName, string limsServiceName);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:authenticate", ReplyAction="urn:authenticateResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        System.Threading.Tasks.Task<string> authenticateAsync(string username, string password, string limsDSName, string limsServiceName);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:authenticateWithRole", ReplyAction="urn:authenticateWithRoleResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        string authenticateWithRole(string username, string password, string role, string limsDSName, string limsServiceName);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:authenticateWithRole", ReplyAction="urn:authenticateWithRoleResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        System.Threading.Tasks.Task<string> authenticateWithRoleAsync(string username, string password, string role, string limsDSName, string limsServiceName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface labware_weblims_authenticatePortTypeChannel : PVCR.DragDropExample.Authenticate.labware_weblims_authenticatePortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class labware_weblims_authenticatePortTypeClient : System.ServiceModel.ClientBase<PVCR.DragDropExample.Authenticate.labware_weblims_authenticatePortType>, PVCR.DragDropExample.Authenticate.labware_weblims_authenticatePortType {
        
        public labware_weblims_authenticatePortTypeClient() {
        }
        
        public labware_weblims_authenticatePortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public labware_weblims_authenticatePortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public labware_weblims_authenticatePortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public labware_weblims_authenticatePortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string authenticate(string username, string password, string limsDSName, string limsServiceName) {
            return base.Channel.authenticate(username, password, limsDSName, limsServiceName);
        }
        
        public System.Threading.Tasks.Task<string> authenticateAsync(string username, string password, string limsDSName, string limsServiceName) {
            return base.Channel.authenticateAsync(username, password, limsDSName, limsServiceName);
        }
        
        public string authenticateWithRole(string username, string password, string role, string limsDSName, string limsServiceName) {
            return base.Channel.authenticateWithRole(username, password, role, limsDSName, limsServiceName);
        }
        
        public System.Threading.Tasks.Task<string> authenticateWithRoleAsync(string username, string password, string role, string limsDSName, string limsServiceName) {
            return base.Channel.authenticateWithRoleAsync(username, password, role, limsDSName, limsServiceName);
        }
    }
}