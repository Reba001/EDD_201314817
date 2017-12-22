using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        Pieza setPieza(Pieza pieza);

        [OperationContract]
        string getPieza();

        [OperationContract]
        string setUsuario(Usuario user);

        [OperationContract]
        string getUsuarios();

        [OperationContract]
        void invocarGrafo();

        [OperationContract]
        string eliminarUsuario(string nickname);

        [OperationContract]
        string modificarUsuario(string nickname,string nicknameNuevo);
        [OperationContract]
        string modificarContrasenia(string nickname, string contrasenia);
        [OperationContract]
        string modificarCorreo(string nickname, string correo);

        [OperationContract]
        string modificarEstad(string nickname, bool estado);

        [OperationContract]
        Usuario buscarUsuario(string nickname);

        // TODO: agregue aquí sus operaciones de servicio
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    
}
