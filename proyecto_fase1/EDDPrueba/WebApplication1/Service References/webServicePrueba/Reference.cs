﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.webServicePrueba {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Usuario", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary2")]
    [System.SerializableAttribute()]
    public partial class Usuario : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ConectadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContraseniaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NicknameField;
        
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
        public bool Conectado {
            get {
                return this.ConectadoField;
            }
            set {
                if ((this.ConectadoField.Equals(value) != true)) {
                    this.ConectadoField = value;
                    this.RaisePropertyChanged("Conectado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contrasenia {
            get {
                return this.ContraseniaField;
            }
            set {
                if ((object.ReferenceEquals(this.ContraseniaField, value) != true)) {
                    this.ContraseniaField = value;
                    this.RaisePropertyChanged("Contrasenia");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nickname {
            get {
                return this.NicknameField;
            }
            set {
                if ((object.ReferenceEquals(this.NicknameField, value) != true)) {
                    this.NicknameField = value;
                    this.RaisePropertyChanged("Nickname");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Juego", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary2")]
    [System.SerializableAttribute()]
    public partial class Juego : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DesplegadasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int DestruidasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool GanarField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NicknameOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SobrevivientesField;
        
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
        public int Desplegadas {
            get {
                return this.DesplegadasField;
            }
            set {
                if ((this.DesplegadasField.Equals(value) != true)) {
                    this.DesplegadasField = value;
                    this.RaisePropertyChanged("Desplegadas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Destruidas {
            get {
                return this.DestruidasField;
            }
            set {
                if ((this.DestruidasField.Equals(value) != true)) {
                    this.DestruidasField = value;
                    this.RaisePropertyChanged("Destruidas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Ganar {
            get {
                return this.GanarField;
            }
            set {
                if ((this.GanarField.Equals(value) != true)) {
                    this.GanarField = value;
                    this.RaisePropertyChanged("Ganar");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NicknameO {
            get {
                return this.NicknameOField;
            }
            set {
                if ((object.ReferenceEquals(this.NicknameOField, value) != true)) {
                    this.NicknameOField = value;
                    this.RaisePropertyChanged("NicknameO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Sobrevivientes {
            get {
                return this.SobrevivientesField;
            }
            set {
                if ((this.SobrevivientesField.Equals(value) != true)) {
                    this.SobrevivientesField = value;
                    this.RaisePropertyChanged("Sobrevivientes");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Pieza", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary2")]
    [System.SerializableAttribute()]
    public partial class Pieza : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AlcanceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float DanioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MovimientoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NicknameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UnidadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float VidaField;
        
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
        public int Alcance {
            get {
                return this.AlcanceField;
            }
            set {
                if ((this.AlcanceField.Equals(value) != true)) {
                    this.AlcanceField = value;
                    this.RaisePropertyChanged("Alcance");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Danio {
            get {
                return this.DanioField;
            }
            set {
                if ((this.DanioField.Equals(value) != true)) {
                    this.DanioField = value;
                    this.RaisePropertyChanged("Danio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Movimiento {
            get {
                return this.MovimientoField;
            }
            set {
                if ((this.MovimientoField.Equals(value) != true)) {
                    this.MovimientoField = value;
                    this.RaisePropertyChanged("Movimiento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nickname {
            get {
                return this.NicknameField;
            }
            set {
                if ((object.ReferenceEquals(this.NicknameField, value) != true)) {
                    this.NicknameField = value;
                    this.RaisePropertyChanged("Nickname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Unidad {
            get {
                return this.UnidadField;
            }
            set {
                if ((object.ReferenceEquals(this.UnidadField, value) != true)) {
                    this.UnidadField = value;
                    this.RaisePropertyChanged("Unidad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Vida {
            get {
                return this.VidaField;
            }
            set {
                if ((this.VidaField.Equals(value) != true)) {
                    this.VidaField = value;
                    this.RaisePropertyChanged("Vida");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Parametros", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary2")]
    [System.SerializableAttribute()]
    public partial class Parametros : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LimitXField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LimitYField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int N1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int N2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int N3Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int N4Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TiempoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TipoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Usuario1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Usuario2Field;
        
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
        public int LimitX {
            get {
                return this.LimitXField;
            }
            set {
                if ((this.LimitXField.Equals(value) != true)) {
                    this.LimitXField = value;
                    this.RaisePropertyChanged("LimitX");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LimitY {
            get {
                return this.LimitYField;
            }
            set {
                if ((this.LimitYField.Equals(value) != true)) {
                    this.LimitYField = value;
                    this.RaisePropertyChanged("LimitY");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int N1 {
            get {
                return this.N1Field;
            }
            set {
                if ((this.N1Field.Equals(value) != true)) {
                    this.N1Field = value;
                    this.RaisePropertyChanged("N1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int N2 {
            get {
                return this.N2Field;
            }
            set {
                if ((this.N2Field.Equals(value) != true)) {
                    this.N2Field = value;
                    this.RaisePropertyChanged("N2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int N3 {
            get {
                return this.N3Field;
            }
            set {
                if ((this.N3Field.Equals(value) != true)) {
                    this.N3Field = value;
                    this.RaisePropertyChanged("N3");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int N4 {
            get {
                return this.N4Field;
            }
            set {
                if ((this.N4Field.Equals(value) != true)) {
                    this.N4Field = value;
                    this.RaisePropertyChanged("N4");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Tiempo {
            get {
                return this.TiempoField;
            }
            set {
                if ((object.ReferenceEquals(this.TiempoField, value) != true)) {
                    this.TiempoField = value;
                    this.RaisePropertyChanged("Tiempo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Tipo {
            get {
                return this.TipoField;
            }
            set {
                if ((this.TipoField.Equals(value) != true)) {
                    this.TipoField = value;
                    this.RaisePropertyChanged("Tipo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Usuario1 {
            get {
                return this.Usuario1Field;
            }
            set {
                if ((object.ReferenceEquals(this.Usuario1Field, value) != true)) {
                    this.Usuario1Field = value;
                    this.RaisePropertyChanged("Usuario1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Usuario2 {
            get {
                return this.Usuario2Field;
            }
            set {
                if ((object.ReferenceEquals(this.Usuario2Field, value) != true)) {
                    this.Usuario2Field = value;
                    this.RaisePropertyChanged("Usuario2");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="webServicePrueba.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/setUsuario", ReplyAction="http://tempuri.org/IService1/setUsuarioResponse")]
        string setUsuario(WebApplication1.webServicePrueba.Usuario user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getUsuarios", ReplyAction="http://tempuri.org/IService1/getUsuariosResponse")]
        string getUsuarios();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/invocarGrafo", ReplyAction="http://tempuri.org/IService1/invocarGrafoResponse")]
        void invocarGrafo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/eliminarUsuario", ReplyAction="http://tempuri.org/IService1/eliminarUsuarioResponse")]
        string eliminarUsuario(string nickname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/modificarUsuario", ReplyAction="http://tempuri.org/IService1/modificarUsuarioResponse")]
        string modificarUsuario(string nickname, string nicknameNuevo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/modificarContrasenia", ReplyAction="http://tempuri.org/IService1/modificarContraseniaResponse")]
        string modificarContrasenia(string nickname, string contrasenia);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/modificarCorreo", ReplyAction="http://tempuri.org/IService1/modificarCorreoResponse")]
        string modificarCorreo(string nickname, string correo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/modificarEstad", ReplyAction="http://tempuri.org/IService1/modificarEstadResponse")]
        string modificarEstad(string nickname, bool estado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/buscarUsuario", ReplyAction="http://tempuri.org/IService1/buscarUsuarioResponse")]
        WebApplication1.webServicePrueba.Usuario buscarUsuario(string nickname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/insertarJuegos", ReplyAction="http://tempuri.org/IService1/insertarJuegosResponse")]
        string insertarJuegos(string nicknameActual, WebApplication1.webServicePrueba.Juego game);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/insertarenTablero", ReplyAction="http://tempuri.org/IService1/insertarenTableroResponse")]
        string insertarenTablero(int fila, string columna, int nivel, WebApplication1.webServicePrueba.Pieza pieza);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/recorrerFila", ReplyAction="http://tempuri.org/IService1/recorrerFilaResponse")]
        string recorrerFila();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/recorrerCol", ReplyAction="http://tempuri.org/IService1/recorrerColResponse")]
        string recorrerCol();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/grafoMatriz", ReplyAction="http://tempuri.org/IService1/grafoMatrizResponse")]
        void grafoMatriz(int level);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getPieza", ReplyAction="http://tempuri.org/IService1/getPiezaResponse")]
        WebApplication1.webServicePrueba.Pieza getPieza(int fila, string columna, int nivel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/insertParametro", ReplyAction="http://tempuri.org/IService1/insertParametroResponse")]
        void insertParametro(WebApplication1.webServicePrueba.Parametros param);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getPJ", ReplyAction="http://tempuri.org/IService1/getPJResponse")]
        WebApplication1.webServicePrueba.Parametros getPJ();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/insertarenTableroD", ReplyAction="http://tempuri.org/IService1/insertarenTableroDResponse")]
        string insertarenTableroD(int fila, string columna, int nivel, WebApplication1.webServicePrueba.Pieza pieza);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/grafoDestruct", ReplyAction="http://tempuri.org/IService1/grafoDestructResponse")]
        void grafoDestruct(int nivel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/grafoUsuario", ReplyAction="http://tempuri.org/IService1/grafoUsuarioResponse")]
        void grafoUsuario(string jugador, int nivel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/crearMatriz", ReplyAction="http://tempuri.org/IService1/crearMatrizResponse")]
        void crearMatriz();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/eliminarMatriz", ReplyAction="http://tempuri.org/IService1/eliminarMatrizResponse")]
        void eliminarMatriz();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/crearMatrizD", ReplyAction="http://tempuri.org/IService1/crearMatrizDResponse")]
        void crearMatrizD();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/eliminarMatrizD", ReplyAction="http://tempuri.org/IService1/eliminarMatrizDResponse")]
        void eliminarMatrizD();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/matrizVacia", ReplyAction="http://tempuri.org/IService1/matrizVaciaResponse")]
        bool matrizVacia();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ArbolEspejo", ReplyAction="http://tempuri.org/IService1/ArbolEspejoResponse")]
        void ArbolEspejo();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WebApplication1.webServicePrueba.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WebApplication1.webServicePrueba.IService1>, WebApplication1.webServicePrueba.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public string setUsuario(WebApplication1.webServicePrueba.Usuario user) {
            return base.Channel.setUsuario(user);
        }
        
        public string getUsuarios() {
            return base.Channel.getUsuarios();
        }
        
        public void invocarGrafo() {
            base.Channel.invocarGrafo();
        }
        
        public string eliminarUsuario(string nickname) {
            return base.Channel.eliminarUsuario(nickname);
        }
        
        public string modificarUsuario(string nickname, string nicknameNuevo) {
            return base.Channel.modificarUsuario(nickname, nicknameNuevo);
        }
        
        public string modificarContrasenia(string nickname, string contrasenia) {
            return base.Channel.modificarContrasenia(nickname, contrasenia);
        }
        
        public string modificarCorreo(string nickname, string correo) {
            return base.Channel.modificarCorreo(nickname, correo);
        }
        
        public string modificarEstad(string nickname, bool estado) {
            return base.Channel.modificarEstad(nickname, estado);
        }
        
        public WebApplication1.webServicePrueba.Usuario buscarUsuario(string nickname) {
            return base.Channel.buscarUsuario(nickname);
        }
        
        public string insertarJuegos(string nicknameActual, WebApplication1.webServicePrueba.Juego game) {
            return base.Channel.insertarJuegos(nicknameActual, game);
        }
        
        public string insertarenTablero(int fila, string columna, int nivel, WebApplication1.webServicePrueba.Pieza pieza) {
            return base.Channel.insertarenTablero(fila, columna, nivel, pieza);
        }
        
        public string recorrerFila() {
            return base.Channel.recorrerFila();
        }
        
        public string recorrerCol() {
            return base.Channel.recorrerCol();
        }
        
        public void grafoMatriz(int level) {
            base.Channel.grafoMatriz(level);
        }
        
        public WebApplication1.webServicePrueba.Pieza getPieza(int fila, string columna, int nivel) {
            return base.Channel.getPieza(fila, columna, nivel);
        }
        
        public void insertParametro(WebApplication1.webServicePrueba.Parametros param) {
            base.Channel.insertParametro(param);
        }
        
        public WebApplication1.webServicePrueba.Parametros getPJ() {
            return base.Channel.getPJ();
        }
        
        public string insertarenTableroD(int fila, string columna, int nivel, WebApplication1.webServicePrueba.Pieza pieza) {
            return base.Channel.insertarenTableroD(fila, columna, nivel, pieza);
        }
        
        public void grafoDestruct(int nivel) {
            base.Channel.grafoDestruct(nivel);
        }
        
        public void grafoUsuario(string jugador, int nivel) {
            base.Channel.grafoUsuario(jugador, nivel);
        }
        
        public void crearMatriz() {
            base.Channel.crearMatriz();
        }
        
        public void eliminarMatriz() {
            base.Channel.eliminarMatriz();
        }
        
        public void crearMatrizD() {
            base.Channel.crearMatrizD();
        }
        
        public void eliminarMatrizD() {
            base.Channel.eliminarMatrizD();
        }
        
        public bool matrizVacia() {
            return base.Channel.matrizVacia();
        }
        
        public void ArbolEspejo() {
            base.Channel.ArbolEspejo();
        }
    }
}
