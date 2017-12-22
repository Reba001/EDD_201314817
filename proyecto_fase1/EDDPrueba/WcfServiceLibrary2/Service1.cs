using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class Service1 : IService1
    {
        public static ListaPrueba list = new ListaPrueba();
        public static Arbol usuarios = new Arbol();
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }



        public Pieza setPieza(Pieza pieza)
        {
            if (pieza == null)
            {
                throw new ArgumentNullException("pieza");
            }
            list.insertar(pieza);
            return pieza;
        }
        
        public string getPieza()
        {
            return list.recorrer2();
        }
        
        public string setUsuario(Usuario user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("usuario");
            }

            NodoA busqueda = usuarios.buscar(user.Nickname);
            if (usuarios.insertar(user)){
                return "Usuario Ingresado";
            }
            return "Usuario ya esta en uso";
            
        }

        public string getUsuarios()
        {
            return usuarios.preOrden();
        }


        public void invocarGrafo()
        {
            usuarios.crearGrafo();
        }


        public string eliminarUsuario(string nickname)
        {
            NodoA busqueda = usuarios.buscar(nickname);
            if (busqueda != null)
            {
                usuarios.eliminarNodo(busqueda);
                return "Eliminado";
            }
            return "Usuario no encontrado";
        }


        public string modificarUsuario(string nickname, string nicknameNuevo)
        {
            NodoA buscar = usuarios.buscar(nickname);
            if (buscar != null)
            {
                Usuario nuevouser = new Usuario(nicknameNuevo, buscar.Usuario.Contrasenia, buscar.Usuario.Email, buscar.Usuario.Conectado);
                if(usuarios.insertar(nuevouser))
                {   
                    usuarios.eliminarNodo(buscar);
                    return "Modificado";
                }
                return "Usuario ya esta en uso";
            }
            return "No Encontrado";
        }


        public string modificarContrasenia(string nickname, string contrasenia)
        {
            NodoA buscar = usuarios.buscar(nickname);
            if (buscar != null)
            {
                buscar.Usuario.Contrasenia = contrasenia;
                return "Contraseña Modificada";
            }
            return "No Encontrado";

        }

        public string modificarCorreo(string nickname, string correo)
        {
            NodoA buscar = usuarios.buscar(nickname);
            if (buscar != null)
            {
                buscar.Usuario.Email = correo;
                return "Correo Modificado";
            }
            return "No Encontrado";
        }


        public string modificarEstad(string nickname, bool estado)
        {
            NodoA buscar = usuarios.buscar(nickname);
            if (buscar != null)
            {
                buscar.Usuario.Conectado = estado;
                return "Estado Modificado";
            }
            return "No Encontrado";
        }


        public Usuario buscarUsuario(string nickname)
        {
            NodoA buscar = usuarios.buscar(nickname);
            if (buscar != null){
                return buscar.Usuario;
            }
            return null;
        }
    }
}
