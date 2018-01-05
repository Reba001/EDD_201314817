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

        [OperationContract]
        string insertarJuegos(string nicknameActual, Juego game);

        [OperationContract]
        string insertarenTablero(int fila, string columna, int nivel, Pieza pieza);

        [OperationContract]
        string recorrerFila();

        [OperationContract]
        string recorrerCol();

        [OperationContract]
        void grafoMatriz(int level);

        [OperationContract]
        Pieza getPieza(int fila, string columna, int nivel);
        [OperationContract]
        void insertParametro(Parametros param);
        [OperationContract]
        Parametros getPJ();

        [OperationContract]
        string insertarenTableroD(int fila, string columna, int nivel, Pieza pieza);

        [OperationContract]
        void grafoDestruct(int nivel);

        [OperationContract]
        void grafoUsuario(string jugador, int nivel);
        [OperationContract]
        void crearMatriz();
        [OperationContract]
        void eliminarMatriz();
        [OperationContract]
        void crearMatrizD();
        [OperationContract]
        void eliminarMatrizD();
        [OperationContract]
        bool matrizVacia();

        [OperationContract]
        void ArbolEspejo();
        [OperationContract]
        string modNickO(string nickname, string nicko, string nicknuevo);
        [OperationContract]
        string modDesp(string nickname, string nicko, int desp);
        [OperationContract]
        string modSob(string nickname, string nicko, int sob);
        [OperationContract]
        string modDest(string nickname, string nicko, int dest);
        [OperationContract]
        string modgana(string nickname, string nicko, bool gana);

        [OperationContract]
        string eliminarJuego(string nickname, string nicko);

        [OperationContract]
        void grafoTopWin();
        [OperationContract]
        void grafoTopDest();
        [OperationContract]
        string eliminarPieza(int fila, string columna, int nivel);

        [OperationContract]
        string insertarContacto(string nickname, string nickname2, string contrasenia, string correo);

        [OperationContract]
        string grafoContactos(string nickname);

        [OperationContract]
        void TablaDispersa();

        [OperationContract]
        void insertarHistoria(Movimiento move);
        // TODO: agregue aquí sus operaciones de servicio
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    
}
