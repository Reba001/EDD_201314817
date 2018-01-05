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
        public static Matriz tablero = new Matriz();
        public static Matriz tableroD = new Matriz();
        public static ListaParametros listP = new ListaParametros();
        public static ArbolB historia = new ArbolB();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
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


        public string insertarJuegos(string nicknameActual, Juego game)
        {
            NodoA users = usuarios.buscar(nicknameActual);
            if (users != null){
                users.listJuego.insertar(game);
                return "Dato ingresado";
            }
            return "Dato no ingresado";
        }


        public string insertarenTablero(int fila, string columna, int nivel, Pieza pieza)
        {
            if (tablero.MatrizVacia())
                tablero.iniciarMatriz();

            Pieza p = tablero.buscarPieza(fila, columna, nivel);
            if(p == null)
            {
                tablero.insertar(fila, columna, nivel, pieza);
                return "Insertado!";
            }
            return "Ya hay un nodo en esa Posicion";
        }

        public string recorrerFila()
        {
            return tablero.recorrerFilas();
        }

        public string recorrerCol()
        {
            return tablero.recorridoColumna();
        }


        public void grafoMatriz(int level)
        {
            tablero.grafoNivel(level, "");
        }


        public Pieza getPieza(int fila, string columna, int nivel)
        {
            return tablero.buscarPieza(fila, columna, nivel);
        }


        public Parametros getPJ()
        {
            return listP.getPJ();
        }

        public void insertParametro(Parametros param)
        {
            listP.insertar(param);
        }
        
        public string insertarenTableroD(int fila, string columna, int nivel, Pieza pieza)
        {
            if (tableroD.MatrizVacia())
                tableroD.iniciarMatriz();
            
            Pieza p = tableroD.buscarPieza(fila, columna, nivel);
            if (p == null)
            {
                
                tableroD.insertar(fila, columna, nivel, pieza);
                return "Insertado";
            }
            return "Nodo ya ocupado";
        }


        public void grafoDestruct(int nivel)
        {
            tableroD.grafoNivel(nivel, "destruccion");
        }


        public void grafoUsuario(string jugador, int nivel)
        {
            tablero.grafoJugador1(jugador, nivel);
        }


        public void crearMatriz()
        {
            tablero.iniciarMatriz();
        }

        public void eliminarMatriz()
        {
            tablero.eliminarMatriz();
        }


        public void crearMatrizD()
        {
            tableroD.iniciarMatriz();
        }

        public void eliminarMatrizD()
        {
            tableroD.eliminarMatriz();
        }


        public bool matrizVacia()
        {
            return tablero.MatrizVacia();
        }


        public void ArbolEspejo()
        {
            usuarios.espejo();
        }


        public string modNickO(string nickname, string nicko, string nicknuevo)
        {
            return usuarios.modifiCarOp(nickname, nicko, nicknuevo);
        }

        public string modDesp(string nickname, string nicko, int desp)
        {
            return usuarios.modifiCarDes(nickname, nicko, desp);
        }

        public string modSob(string nickname, string nicko, int sob)
        {
            return usuarios.modifiCarSob(nickname, nicko, sob);
        }

        public string modDest(string nickname, string nicko, int dest)
        {
            return usuarios.modifiCarDest(nickname, nicko, dest);
        }

        public string modgana(string nickname, string nicko, bool gana)
        {
            return usuarios.modifiCarGanada(nickname, nicko, gana);
        }


        public string eliminarJuego(string nickname, string nicko)
        {
            return usuarios.eliminarJuego(nickname, nicko);
        }


        public void grafoTopWin()
        {
            usuarios.getTopWin();
        }

        public void grafoTopDest()
        {
            usuarios.getTopDest();
        }


        public string eliminarPieza(int fila, string columna, int nivel)
        {
            tablero.eliminarPieza(fila, columna, nivel);
            return "Pieza Eliminada";
        }





        public string insertarContacto(string nickname, string nickname2, string contrasenia, string correo)
        {
            if (usuarios.insertarContacto(nickname, nickname2, contrasenia, correo))
            {
                return "insertado";
            }
            return "Error no inserto";
        }




        public string grafoContactos(string nickname)
        {
            return usuarios.grafoContactos(nickname);
        }

        public void TablaDispersa()
        {
            usuarios.getHash();
        }

        public void insertarHistoria(Movimiento move) 
        {
            historia.insertar(move);

        }
    }
}
