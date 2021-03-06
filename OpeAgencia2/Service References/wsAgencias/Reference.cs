﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OpeAgencia2.wsAgencias {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wsAgencias.wsAgenciasSoap")]
    public interface wsAgenciasSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ImportarClientes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        OpeAgencia2.wsAgencias.ImportarClientesResponse ImportarClientes(OpeAgencia2.wsAgencias.ImportarClientesRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ImportarClientes", ReplyAction="*")]
        System.Threading.Tasks.Task<OpeAgencia2.wsAgencias.ImportarClientesResponse> ImportarClientesAsync(OpeAgencia2.wsAgencias.ImportarClientesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ImportarEstadosPaquetesAgencia", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        OpeAgencia2.wsAgencias.ImportarEstadosPaquetesAgenciaResponse ImportarEstadosPaquetesAgencia(OpeAgencia2.wsAgencias.ImportarEstadosPaquetesAgenciaRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ImportarEstadosPaquetesAgencia", ReplyAction="*")]
        System.Threading.Tasks.Task<OpeAgencia2.wsAgencias.ImportarEstadosPaquetesAgenciaResponse> ImportarEstadosPaquetesAgenciaAsync(OpeAgencia2.wsAgencias.ImportarEstadosPaquetesAgenciaRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ListadoDeCargos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ListadoDeCargos(string CodigoAgencia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ListadoDeCargos", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ListadoDeCargosAsync(string CodigoAgencia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraeCodigoSecreto", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet TraeCodigoSecreto(string Eps, string CodigoAgencia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TraeCodigoSecreto", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> TraeCodigoSecretoAsync(string Eps, string CodigoAgencia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DatosDeProductos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet DatosDeProductos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DatosDeProductos", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> DatosDeProductosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FacturasAgencias", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet FacturasAgencias(string CodigoAgencia, string Fecha);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FacturasAgencias", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> FacturasAgenciasAsync(string CodigoAgencia, string Fecha);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ManifiestoAgencias", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ManifiestoAgencias(string CodigoAgencia, string DocCodigo, string FacNumero);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ManifiestoAgencias", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ManifiestoAgenciasAsync(string CodigoAgencia, string DocCodigo, string FacNumero);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ListadoCargos", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ListadoCargos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ListadoCargos", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ListadoCargosAsync();
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImportarClientes", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImportarClientesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string CodigoAgencia;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public System.Data.DataSet DsClientes;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string MensajeRetorno;
        
        public ImportarClientesRequest() {
        }
        
        public ImportarClientesRequest(string CodigoAgencia, System.Data.DataSet DsClientes, string MensajeRetorno) {
            this.CodigoAgencia = CodigoAgencia;
            this.DsClientes = DsClientes;
            this.MensajeRetorno = MensajeRetorno;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImportarClientesResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImportarClientesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool ImportarClientesResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string MensajeRetorno;
        
        public ImportarClientesResponse() {
        }
        
        public ImportarClientesResponse(bool ImportarClientesResult, string MensajeRetorno) {
            this.ImportarClientesResult = ImportarClientesResult;
            this.MensajeRetorno = MensajeRetorno;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImportarEstadosPaquetesAgencia", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImportarEstadosPaquetesAgenciaRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string CodigoAgencia;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public System.Data.DataSet dsDatos;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string MensajeRetorno;
        
        public ImportarEstadosPaquetesAgenciaRequest() {
        }
        
        public ImportarEstadosPaquetesAgenciaRequest(string CodigoAgencia, System.Data.DataSet dsDatos, string MensajeRetorno) {
            this.CodigoAgencia = CodigoAgencia;
            this.dsDatos = dsDatos;
            this.MensajeRetorno = MensajeRetorno;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImportarEstadosPaquetesAgenciaResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImportarEstadosPaquetesAgenciaResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool ImportarEstadosPaquetesAgenciaResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string MensajeRetorno;
        
        public ImportarEstadosPaquetesAgenciaResponse() {
        }
        
        public ImportarEstadosPaquetesAgenciaResponse(bool ImportarEstadosPaquetesAgenciaResult, string MensajeRetorno) {
            this.ImportarEstadosPaquetesAgenciaResult = ImportarEstadosPaquetesAgenciaResult;
            this.MensajeRetorno = MensajeRetorno;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface wsAgenciasSoapChannel : OpeAgencia2.wsAgencias.wsAgenciasSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class wsAgenciasSoapClient : System.ServiceModel.ClientBase<OpeAgencia2.wsAgencias.wsAgenciasSoap>, OpeAgencia2.wsAgencias.wsAgenciasSoap {
        
        public wsAgenciasSoapClient() {
        }
        
        public wsAgenciasSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public wsAgenciasSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public wsAgenciasSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public wsAgenciasSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync() {
            return base.Channel.HelloWorldAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OpeAgencia2.wsAgencias.ImportarClientesResponse OpeAgencia2.wsAgencias.wsAgenciasSoap.ImportarClientes(OpeAgencia2.wsAgencias.ImportarClientesRequest request) {
            return base.Channel.ImportarClientes(request);
        }
        
        public bool ImportarClientes(string CodigoAgencia, System.Data.DataSet DsClientes, ref string MensajeRetorno) {
            OpeAgencia2.wsAgencias.ImportarClientesRequest inValue = new OpeAgencia2.wsAgencias.ImportarClientesRequest();
            inValue.CodigoAgencia = CodigoAgencia;
            inValue.DsClientes = DsClientes;
            inValue.MensajeRetorno = MensajeRetorno;
            OpeAgencia2.wsAgencias.ImportarClientesResponse retVal = ((OpeAgencia2.wsAgencias.wsAgenciasSoap)(this)).ImportarClientes(inValue);
            MensajeRetorno = retVal.MensajeRetorno;
            return retVal.ImportarClientesResult;
        }
        
        public System.Threading.Tasks.Task<OpeAgencia2.wsAgencias.ImportarClientesResponse> ImportarClientesAsync(OpeAgencia2.wsAgencias.ImportarClientesRequest request) {
            return base.Channel.ImportarClientesAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        OpeAgencia2.wsAgencias.ImportarEstadosPaquetesAgenciaResponse OpeAgencia2.wsAgencias.wsAgenciasSoap.ImportarEstadosPaquetesAgencia(OpeAgencia2.wsAgencias.ImportarEstadosPaquetesAgenciaRequest request) {
            return base.Channel.ImportarEstadosPaquetesAgencia(request);
        }
        
        public bool ImportarEstadosPaquetesAgencia(string CodigoAgencia, System.Data.DataSet dsDatos, ref string MensajeRetorno) {
            OpeAgencia2.wsAgencias.ImportarEstadosPaquetesAgenciaRequest inValue = new OpeAgencia2.wsAgencias.ImportarEstadosPaquetesAgenciaRequest();
            inValue.CodigoAgencia = CodigoAgencia;
            inValue.dsDatos = dsDatos;
            inValue.MensajeRetorno = MensajeRetorno;
            OpeAgencia2.wsAgencias.ImportarEstadosPaquetesAgenciaResponse retVal = ((OpeAgencia2.wsAgencias.wsAgenciasSoap)(this)).ImportarEstadosPaquetesAgencia(inValue);
            MensajeRetorno = retVal.MensajeRetorno;
            return retVal.ImportarEstadosPaquetesAgenciaResult;
        }
        
        public System.Threading.Tasks.Task<OpeAgencia2.wsAgencias.ImportarEstadosPaquetesAgenciaResponse> ImportarEstadosPaquetesAgenciaAsync(OpeAgencia2.wsAgencias.ImportarEstadosPaquetesAgenciaRequest request) {
            return base.Channel.ImportarEstadosPaquetesAgenciaAsync(request);
        }
        
        public System.Data.DataSet ListadoDeCargos(string CodigoAgencia) {
            return base.Channel.ListadoDeCargos(CodigoAgencia);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ListadoDeCargosAsync(string CodigoAgencia) {
            return base.Channel.ListadoDeCargosAsync(CodigoAgencia);
        }
        
        public System.Data.DataSet TraeCodigoSecreto(string Eps, string CodigoAgencia) {
            return base.Channel.TraeCodigoSecreto(Eps, CodigoAgencia);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> TraeCodigoSecretoAsync(string Eps, string CodigoAgencia) {
            return base.Channel.TraeCodigoSecretoAsync(Eps, CodigoAgencia);
        }
        
        public System.Data.DataSet DatosDeProductos() {
            return base.Channel.DatosDeProductos();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> DatosDeProductosAsync() {
            return base.Channel.DatosDeProductosAsync();
        }
        
        public System.Data.DataSet FacturasAgencias(string CodigoAgencia, string Fecha) {
            return base.Channel.FacturasAgencias(CodigoAgencia, Fecha);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> FacturasAgenciasAsync(string CodigoAgencia, string Fecha) {
            return base.Channel.FacturasAgenciasAsync(CodigoAgencia, Fecha);
        }
        
        public System.Data.DataSet ManifiestoAgencias(string CodigoAgencia, string DocCodigo, string FacNumero) {
            return base.Channel.ManifiestoAgencias(CodigoAgencia, DocCodigo, FacNumero);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ManifiestoAgenciasAsync(string CodigoAgencia, string DocCodigo, string FacNumero) {
            return base.Channel.ManifiestoAgenciasAsync(CodigoAgencia, DocCodigo, FacNumero);
        }
        
        public System.Data.DataSet ListadoCargos() {
            return base.Channel.ListadoCargos();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ListadoCargosAsync() {
            return base.Channel.ListadoCargosAsync();
        }
    }
}
