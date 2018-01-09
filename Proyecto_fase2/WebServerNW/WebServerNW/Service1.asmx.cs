using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServerNW
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://NavalWarsEDD.com", Name="ProyectoEDD")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        public static ListaPrueba list = new ListaPrueba();
        public static Arbol usuarios = new Arbol();
        public static Matriz tablero = new Matriz();
        public static Matriz tableroD = new Matriz();
        public static ListaParametros listP = new ListaParametros();
        public static ArbolB historia = new ArbolB();


        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        [WebMethod]
        public string setUsuario(string nickname, string contrasenia, string correo, bool conectado)
        {
            Usuario usuario = new Usuario(nickname, contrasenia, correo, conectado);
            

            NodoA busqueda = usuarios.buscar(nickname);
            if (usuarios.insertar(usuario))
            {
                return "Usuario Ingresado";
            }
            return "Usuario ya esta en uso";

        }
        [WebMethod]
        public string getTopContactos() 
        {
            return usuarios.getTopContactos();
        }
        [WebMethod]
        public string getTopEliminadas() 
        {
            return usuarios.getTopEliminadas();
        }

        [WebMethod]
        public bool getConectado(string nickname) 
        {
            NodoA user = usuarios.buscar(nickname);
            if (user != null)
            {
                return user.Usuario.Conectado;
            }
            return false;
        }
        [WebMethod]
        public string getUsuarios()
        {
            return usuarios.preOrden();
        }

        [WebMethod]
        public string invocarGrafo()
        {
            return usuarios.crearGrafo();
        }

        [WebMethod]
        public int getMovimiento(string x, int y, int nivel)
        {
            Pieza pieza = tablero.buscarPieza(y, x, nivel);
            if (pieza != null)
            {
                return pieza.Movimiento;
            }
            return -1;
        }
        [WebMethod]
        public int getAlcance(string x, int y, int nivel) 
        {
            Pieza pieza = tablero.buscarPieza(y, x, nivel);
            if (pieza != null)
            {
                return pieza.Alcance;
            }
            return -1;
        }
        [WebMethod]
        public float getDanio(string x, int y, int nivel) 
        {
            Pieza pieza = tablero.buscarPieza(y, x, nivel);
            if (pieza != null)
            {
                return pieza.Danio;
            }
            return -1;
        }

        [WebMethod]
        public float getVida(string x, int y, int nivel) 
        {
            Pieza pieza = tablero.buscarPieza(y, x, nivel);
            if (pieza != null)
            {
                return pieza.Vida;
            }
            return -1;
        }

        [WebMethod]
        public string setVida(string x, int y, int nivel, float vida) 
        {
            if (tablero.setVida(y, x, nivel, vida))
                return "Vida: " + vida.ToString();
            return "No se encontro vida";
        }

        [WebMethod]
        public bool getPiezasDestruidas(string nickname) 
        {
            return tablero.piezasDestruidas(nickname);
        }

        [WebMethod]
        public string getNick(string x, int y, int nivel) 
        {
            Pieza pieza = tablero.buscarPieza(y, x, nivel);
            if (pieza != null)
                return pieza.Nickname;

            return null;
        }

        [WebMethod]
        public string moverPieza(string x, int y, int nivel, string xde, int yde, int nivelde) 
        {
            Pieza pieza = tablero.buscarPieza(y, x, nivel);
            if (pieza != null)
            {
                Pieza piezade = tablero.buscarPieza(yde, xde, nivelde);
                if (piezade == null)
                {
                    piezade = new Pieza(pieza.Nickname, pieza.Unidad, pieza.Alcance, pieza.Movimiento, pieza.Danio, pieza.Vida);
                    tablero.eliminarPieza(y, x, nivel);
                    tablero.insertar(yde, xde, nivelde, piezade);
                    return "Pieza: " + piezade.Unidad + " Insertada";
                }
                return "Ya hay una pieza en la posicion: "+xde+", "+yde.ToString()+", "+nivel.ToString();
            }
            return "Pieza No encontrada";
        }
        
        [WebMethod]
        public string eliminarContacto(string nickname, string nicknameC) 
        {
            NodoA busqueda = usuarios.buscar(nickname);
            if (busqueda != null)
            {
                NodoA contacto = busqueda.contactos.buscar(nicknameC);
                if (contacto != null)
                {
                    busqueda.contactos.eliminarNodo(contacto);
                    return "Se elimino contacto" + nicknameC;
                }
                return "No se encontro: " + nicknameC + " en sus contactos";
            }
            return "Usuario inexistente";
        }

        [WebMethod]
        public string eliminarUsuario(string nickname)
        {
            NodoA busqueda = usuarios.buscar(nickname);
            if (busqueda != null)
            {
                usuarios.eliminarContacto(nickname);
                usuarios.eliminarNodo(busqueda);
                return "Eliminado";
            }
            return "Usuario no encontrado";
        }
        [WebMethod]
        public string modificarContacto(string nickname, string contacto, string contactonuevo) 
        {
            NodoA buscar = usuarios.buscar(nickname);
            if (buscar != null)
            {
                NodoA contact = buscar.contactos.buscar(contacto);
                if (contact != null)
                {
                    Usuario nuevoUsuario = new Usuario(contactonuevo, contact.Usuario.Contrasenia, contact.Usuario.Email, contact.Usuario.Conectado);
                    
                    NodoA busquedaUser = buscar.contactos.buscar(contactonuevo);
                    if (busquedaUser != null)
                    {
                        NodoA modificado = new NodoA(nuevoUsuario);
                        buscar.contactos.insertar(modificado);
                        buscar.contactos.eliminarNodo(contact);
                        return "Nicname Modficado";
                    }
                    return "Nickname ya esta en uso";
                }
                return "Contacto inexistente";

            }
            return "Usuario inexistente";
        }

        [WebMethod]
        public string modificarUsuario(string nickname, string nicknameNuevo)
        {
            NodoA buscar = usuarios.buscar(nickname);
            if (buscar != null)
            {
                Usuario nuevouser = new Usuario(nicknameNuevo, buscar.Usuario.Contrasenia, buscar.Usuario.Email, buscar.Usuario.Conectado);
                if (usuarios.insertar(nuevouser))
                {
                    usuarios.eliminarNodo(buscar);
                    return "Modificado";
                }
                return "Usuario ya esta en uso";
            }
            return "No Encontrado";
        }

        [WebMethod]
        public string modificarContraseniaContacto(string nickname, string contacto, string contrasenia) 
        {
            NodoA buscar = usuarios.buscar(nickname);
            if (buscar != null)
            {
                NodoA contact = buscar.contactos.buscar(contacto);
                if (contact != null)
                {
                    contact.Usuario.Contrasenia = contrasenia;
                    return "Contraseña modificada";
                }
                return "Contacto inexistente";
            }
            return "Usuario inexistente";
        }

        [WebMethod]
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

        [WebMethod]
        public string modificarCorreoContacto(string nickname, string contacto, string correo) 
        {
            NodoA buscar = usuarios.buscar(nickname);
            if (buscar != null)
            {
                NodoA contact = buscar.contactos.buscar(contacto);
                if (contact != null)
                {
                    contact.Usuario.Email = correo;
                    return "Email Modificado";
                }
                return "Contacto inexistente";
            }
            return "Usuario no encontrado";
        }
        [WebMethod]
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

        

        [WebMethod]
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

        [WebMethod]
        public string buscarUsuario(string nickname)
        {
            NodoA buscar = usuarios.buscar(nickname);
            if (buscar != null)
            {
                return buscar.Usuario.Contrasenia;
            }
            return null;
        }

        [WebMethod]
        public string insertarJuegos(string nicknameActual, string nicknameO, int desplegadas, int sob, int dest, bool ganar)
        {
            Juego juego = new Juego(nicknameO, dest);
            juego.Desplegadas = desplegadas;
            juego.Sobrevivientes = sob;
            juego.Ganar = ganar;
    
            NodoA users = usuarios.buscar(nicknameActual);
            if (users != null)
            {
                users.listJuego.insertar(juego);
                return "Dato ingresado";
            }
            return "Dato no ingresado";
        }

        [WebMethod]
        public string insertarenTablero(int fila, string columna, int nivel, string nickname, string unidad, int alcance, int movimiento, float danio, float vida)
        {
            Pieza pieza = new Pieza(nickname,unidad,alcance, movimiento, danio, vida);
            if (tablero.MatrizVacia())
                tablero.iniciarMatriz();

            Pieza p = tablero.buscarPieza(fila, columna, nivel);
            if (p == null)
            {
                tablero.insertar(fila, columna, nivel, pieza);
                return "Insertado!";
            }
            return "Ya hay un nodo en esa Posicion";
        }
        [WebMethod]
        public string recorrerFila()
        {
            return tablero.recorrerFilas();
        }
        [WebMethod]
        public string recorrerCol()
        {
            return tablero.recorridoColumna();
        }

        [WebMethod]
        public string grafoMatriz(int level)
        {
            return tablero.grafoNivel(level, "");
        }

        [WebMethod]
        public string  getPieza(int fila, string columna, int nivel)
        {
            return tablero.buscarPieza(fila, columna, nivel).Unidad;
        }

        [WebMethod]
        public string insertarenTableroD(int fila, string columna, int nivel, string nickname, string unidad, int alcance, int movimiento, float danio, float vida)
        {
            if (tableroD.MatrizVacia())
                tableroD.iniciarMatriz();

            Pieza p = tableroD.buscarPieza(fila, columna, nivel);
            if (p == null)
            {
                p = new Pieza(nickname, unidad, alcance, movimiento, danio, vida);
                tableroD.insertar(fila, columna, nivel, p);
                return "Insertado";
            }
            return "Nodo ya ocupado";
        }

        [WebMethod]
        public string grafoDestruct(int nivel)
        {
            return tableroD.grafoNivel(nivel, "destruccion");
        }

        [WebMethod]
        public void grafoUsuario(string jugador, int nivel)
        {
            tablero.grafoJugador1(jugador, nivel);
        }

        [WebMethod]
        public void crearMatriz()
        {
            tablero.iniciarMatriz();
        }
        [WebMethod]
        public void eliminarMatriz()
        {
            tablero.eliminarMatriz();
        }

        [WebMethod]
        public void crearMatrizD()
        {
            tableroD.iniciarMatriz();
        }
        [WebMethod]
        public void eliminarMatrizD()
        {
            tableroD.eliminarMatriz();
        }

        [WebMethod]
        public bool matrizVacia()
        {
            return tablero.MatrizVacia();
        }

        [WebMethod]
        public string  ArbolEspejo()
        {
            return usuarios.espejo();
        }

        [WebMethod]
        public string modNickO(string nickname, string nicko, string nicknuevo)
        {
            return usuarios.modifiCarOp(nickname, nicko, nicknuevo);
        }
        [WebMethod]
        public string modDesp(string nickname, string nicko, int desp)
        {
            return usuarios.modifiCarDes(nickname, nicko, desp);
        }
        [WebMethod]
        public string modSob(string nickname, string nicko, int sob)
        {
            return usuarios.modifiCarSob(nickname, nicko, sob);
        }
        [WebMethod]
        public string modDest(string nickname, string nicko, int dest)
        {
            return usuarios.modifiCarDest(nickname, nicko, dest);
        }
        [WebMethod]
        public string modgana(string nickname, string nicko, bool gana)
        {
            return usuarios.modifiCarGanada(nickname, nicko, gana);
        }

        [WebMethod]
        public string eliminarJuego(string nickname, string nicko)
        {
            return usuarios.eliminarJuego(nickname, nicko);
        }

        [WebMethod]
        public string  grafoTopWin()
        {
            return usuarios.getTopWin();
        }
        [WebMethod]
        public string grafoTopDest()
        {
            return usuarios.getTopDest();
        }

        [WebMethod]
        public string eliminarPieza(int fila, string columna, int nivel)
        {
            tablero.eliminarPieza(fila, columna, nivel);
            return "Pieza Eliminada";
        }




        [WebMethod]
        public string insertarContacto(string nickname, string nickname2, string contrasenia, string correo)
        {
            if (usuarios.insertarContacto(nickname, nickname2, contrasenia, correo))
            {
                return "insertado";
            }
            return "Error no inserto";
        }
        
        [WebMethod]
        public string grafoContactos(string nickname)
        {
            return usuarios.grafoContactos(nickname);
        }
        [WebMethod]
        public string TablaDispersa()
        {
            return usuarios.getHash();
        }
        [WebMethod]
        public void insertarHistoria(string X, int Y, string atacante, int resultado, string tipoUD, string nickEmisor, string nickReceptor, string fecha, string tiempoRestante, int numeroA, int key)
        {
            Movimiento movimiento = new Movimiento(X, Y, atacante, resultado, tipoUD, nickEmisor, nickReceptor, fecha, tiempoRestante, numeroA, key);
            historia.insertar(movimiento);

        }
    }
}