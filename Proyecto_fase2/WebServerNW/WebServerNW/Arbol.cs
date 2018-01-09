using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WebServerNW
{
    public class Arbol
    {
        NodoA raiz;
        
        ListaJuego listTopDest;
        ListaJuego listToopWin;

        public Arbol() 
        {
            this.listToopWin = new ListaJuego();
            this.listTopDest = new ListaJuego();

            this.raiz = null;
        }
        // BUSQUEDA
        public NodoA buscar(string nickname) 
        {
            return busca(this.raiz, nickname);
        }

        public NodoA busca(NodoA actual, string nickname) 
        {
            if (actual == null)
            {
                return null;
            }

            int comparacion = String.Compare(nickname, actual.Usuario.Nickname);
            if (comparacion == 0)
            {
                return actual;
            }
            else 
            {
                return busca(comparacion < 0 ? actual.Izquierda : actual.Derecha, nickname);
            }
        }

        // FIN BUSQUEDA
        //INICIO INSERCION
        public bool insertar(Usuario user) 
        {
            if (buscar(user.Nickname) == null)
            {
                if (this.raiz == null)
                {
                    this.raiz = new NodoA(user);
                    return true;
                }
                else 
                {
                    return inserta(raiz, new NodoA(user));

                }
            }
            return false;
        }

        bool inserta(NodoA actual, NodoA nuevo) 
        {
            if (String.Compare(nuevo.Usuario.Nickname, actual.Usuario.Nickname) < 0)
            {
                if (actual.Izquierda == null)
                {
                    actual.Izquierda = nuevo;
                    nuevo.Padre = actual;
                    return true;
                }
                else
                {
                    return inserta(actual.Izquierda, nuevo);
                }
            }
            else 
            {
                if (actual.Derecha == null)
                {
                    actual.Derecha = nuevo;
                    nuevo.Padre = actual;
                    return true;
                }
                else 
                {
                    return inserta(actual.Derecha, nuevo);
                }
            }
        }

        //FIN INSERCION
        //ELIMINACION DE CONTACTO Y USUARIO
        public bool eliminarContacto(string usuario) 
        {
            if (raiz != null)
            {
                postO(raiz, usuario);
                return true;
            }
            return false;
        }

        public void postO(NodoA actual, string usuario) 
        {
            if (actual != null)
            {
                if (actual.contactos.raiz != null)
                {
                    NodoA usuarioD = actual.contactos.buscar(usuario);
                    if (usuarioD != null)
                        actual.contactos.eliminarNodo(usuarioD);
                    
                }
                postO(actual.Izquierda, usuario);
                postO(actual.Derecha, usuario);
            }
        }
        //FIN ELIMINACION DE CONTACTO Y USUARIO
        // INSERCION DE CONTACTO
        public bool insertarContacto(string nickname, string nickname2, string contrasenia, string correo)
        {
            NodoA usuario = this.buscar(nickname);
            if (usuario != null)
            {
                NodoA contacto = buscar(nickname2);
                if (contacto != null)
                {
                    Usuario user = contacto.Usuario;
                    return usuario.contactos.insertar(new NodoA(ref user));
                }
                else 
                {
                    Usuario user = new Usuario(nickname2, contrasenia, correo, false);
                    return usuario.contactos.insertar(new NodoA(ref user));
                }

            }
            return false;
        }

        //GRAFO CONTACTOS
        public string grafoContactos(string nickname) 
        {
            NodoA usuario = buscar(nickname);
            if (usuario != null)
            {

                return usuario.contactos.crearGrafo(); 
            }
            return "";
        }
        //FIN GRAFOCONTACTOS
        //FIN INSERCION DE CONTACTO
        //IMPRESION PREORDEN
        //arbol espejo
        public string espejo() {
            string grafo = "digraph g{\n";
            string cuerpo = "";
            int h = calcularAltura();
            int nh = getNodoHoja();
            int rama = getRamas();
            grafo += "\"Altura: " + h.ToString() + "\n";
            grafo += "Nodos Hoja: " + nh.ToString() + "\n";
            grafo += "Niveles: " + Convert.ToString(h + 1) + "\n";
            grafo += "Ramas: " + Convert.ToString(rama) + "\";\n";
            grafo += escrituraEspejo(raiz, ref cuerpo);
            grafo += "}\n";
            return grafo;
        }

        public string escrituraEspejo(NodoA actual, ref string recorrido) {
            if (actual != null)
            {
                if (actual.Derecha != null)
                {
                    recorrido += "\t\"" + actual.Usuario.toString() + "\" -> \"" + actual.Derecha.Usuario.toString() + "\";\n";
                }

                if (actual.Izquierda != null)
                {
                    recorrido += "\t\"" + actual.Usuario.toString() + "\" -> \"" + actual.Izquierda.Usuario.toString() + "\";\n";
                }
                
                if (actual.listJuego.primero != null)
                {
                    recorrido += "\t\"" + actual.Usuario.toString() + "\" -> \"" + actual.listJuego.primero.Juego.toString() + "\";\n";
                    recorrido += "\t subgraph cluster" + idUsuario(actual.Usuario.Nickname) + "{\n";
                    recorrido += "\t\t" + actual.listJuego.grafo();
                    recorrido += "}\n";
                }
                escrituraEspejo(actual.Derecha, ref recorrido);
                escrituraEspejo(actual.Izquierda, ref recorrido);
                return recorrido;
            }
            return recorrido;
        }
        // fin arbol espejo
        public string crearGrafo() 
        {
            string grafo = "digraph g{\n";
            int h = calcularAltura();
            int nh = getNodoHoja();
            int rama = getRamas();
            grafo += "\"Altura: "+h.ToString()+ "\n";
            grafo += "Nodos Hoja: "+nh.ToString()+"\n";
            grafo += "Niveles: "+ Convert.ToString(h+1)+"\n";
            grafo += "Ramas: " + Convert.ToString(rama)+"\";\n";
            grafo += preOrden();
            grafo += "}\n";
            return grafo;
            
        }
        public string preOrden() 
        {
            string recorrido = "";
            preO(raiz,ref recorrido); 
            return recorrido;
            
        }

        public string preO(NodoA actual, ref string recorrido) 
        {
            if (actual != null)
            {
                
                if (actual.Izquierda != null){
                    recorrido += "\t\""+ actual.Usuario.toString()+ "\" -> \""+ actual.Izquierda.Usuario.toString()+"\";\n";
                }

                if (actual.Derecha != null)
                {
                    recorrido += "\t\"" + actual.Usuario.toString() + "\" -> \"" + actual.Derecha.Usuario.toString() + "\";\n";
                }

                if (actual.listJuego.primero != null){
                    recorrido += "\t\""+actual.Usuario.toString()+ "\" -> \""+actual.listJuego.primero.Juego.toString()+"\";\n";
                    recorrido += "\t subgraph cluster"+idUsuario(actual.Usuario.Nickname)+"{\n";
                    recorrido += "\t\t"+actual.listJuego.grafo();
                    recorrido += "}\n";
                }
                
                preO(actual.Izquierda, ref recorrido);
                preO(actual.Derecha, ref recorrido);
                return recorrido;
            }
            return recorrido;
            
        }

        private string idUsuario(string nickname) {
            char[] arreglo = nickname.ToCharArray();
            int total = 0;
            for (int i = 0; i < arreglo.Length; i++ )
            {
                total += arreglo[i];
            }
            return total.ToString();
        }
        //FIN IMPRESION PREORDEN
        //UNIDADES MAS ELIMINDAS
        public string getTopEliminadas() 
        {
            ListaJuego listaEliminadas = new ListaJuego();
            if (raiz != null)
            {
                recorridoEliminadas(raiz, ref listaEliminadas);
                return listaEliminadas.grafoTopWin("ELIMINADAS");
            }
            return listaEliminadas.grafoTopWin("ELIMINADAS");
        }

        private void recorridoEliminadas(NodoA actual, ref ListaJuego listaEliminadas) 
        {
            if (actual != null && listaEliminadas != null)
            {
                listaEliminadas.insertarMayor(actual.Usuario.Nickname, actual.listJuego.contadoDest);
                recorridoEliminadas(actual.Izquierda, ref listaEliminadas);
                recorridoEliminadas(actual.Derecha, ref listaEliminadas);
            }

        }

        //FIN UNIDADES MAS ELIMINADAS
        // INICIO RECORRIDO TOP CONTACTOS
        public string getTopContactos() 
        {
            ListaJuego listTopContactos = new ListaJuego();
            if (raiz != null)
            {
                
                recorridoContactos(raiz, ref listTopContactos);
                return listTopContactos.grafoTopWin("CONTACTOS");
            }
            return listTopContactos.grafoTopWin("CONTACTOS");
        }

        private void recorridoContactos(NodoA actual, ref ListaJuego listTopContactos)
        {
            if (actual != null && listTopContactos != null)
            {
                listTopContactos.insertarMayor(actual.Usuario.Nickname, actual.contactos.getRamas());
                recorridoContactos(actual.Izquierda,ref listTopContactos);
                recorridoContactos(actual.Derecha, ref listTopContactos);
            }
        }
        // fin recorrido top contactos
        // INICIO RECORRIDO TOP WIN
        public string getTopDest() {
            this.listTopDest.primero = null;
            if (raiz != null)
            {
                recorridoDest(raiz);
                return this.listTopDest.grafoTopWin("DESTRUIDAS");
            }
            return this.listTopDest.grafoTopWin("DESTRUIDAS");
        }

        public void recorridoDest(NodoA actual) 
        {
            if (actual != null && this.listTopDest != null)
            {
                int porcentaje = (actual.listJuego.contadoDest *100)/ actual.listJuego.contadoUni;
                this.listTopDest.insertarMayor(actual.Usuario.Nickname, porcentaje);
                recorridoDest(actual.Izquierda);
                recorridoDest(actual.Derecha);
            }
        }
        public string getTopWin() 
        {
            this.listToopWin.primero = null;
            if (raiz != null){
                recorridoTopWin(raiz);
                return listToopWin.grafoTopWin("GANADAS");
            }
            return listToopWin.grafoTopWin("GANADAS");
        }

        public void recorridoTopWin(NodoA actual) 
        {
            if (actual != null && listToopWin != null)
            {
                this.listToopWin.insertarMayor(actual.Usuario.Nickname, actual.listJuego.contadorganar);
                recorridoTopWin(actual.Izquierda);
                recorridoTopWin(actual.Derecha);
            }
             
        }
        //FIN RECORRIDO TOP WIN 
        //HASH
        public string getHash()
        {

            if (raiz != null)
            {
                TablaHash hashtable = new TablaHash();
                recorridoHash(raiz,ref hashtable);
                return hashtable.grafoTablaHash();
            }
            return "";
        }

        public void recorridoHash(NodoA actual, ref TablaHash hashtable)
        {
            if (actual != null && hashtable != null)
            {
                hashtable.insertar(actual.Usuario);
                recorridoHash(actual.Izquierda, ref hashtable);
                recorridoHash(actual.Derecha, ref hashtable);
            }

        }

        //FIN HASH
        //CALCULO DE ALTURA
        public int calcularAltura() 
        {
            if (this.raiz == null)
            {
                return 0;
            }
            else 
            {
                return calcularH(raiz);

            }

        }

        public int calcularH(NodoA actual)
        {
            if (actual == null)
            {
                return 0;
            }
            else 
            {
                int hi = calcularH(actual.Izquierda);
                int hd = calcularH(actual.Derecha);
                return (hi > hd ? hi : hd)+ 1;

            }
        }

        // Eliminacion de Juego/
        public string eliminarJuego(string nickname, string nicknameO) 
        {
            if (raiz != null)
            {
                NodoA actual = buscar(nickname);
                if (actual != null)
                {
                    actual.listJuego.eliminarJuego(nicknameO);
                    if (actual.listJuego.primero == null){
                        eliminarNodo(actual);
                    }
                    return "Eliminado";
                }
            }
            return "No encontrado";
        }

        public string modifiCarOp(string nickname, string nickO, string nickONuevo) 
        {
            if (raiz != null)
            {
                NodoA actual = buscar(nickname);
                if (actual != null)
                {
                    Juego game = actual.listJuego.getJuego(nickO);
                    game.NicknameO = nickONuevo;
                    return "Oponente Modificado";
                }
            }
            return "No encontrado";
        }

        public string modifiCarDes(string nickname, string nickO, int desp)
        {
            if (raiz != null)
            {
                NodoA actual = buscar(nickname);
                if (actual != null)
                {
                    Juego game = actual.listJuego.getJuego(nickO);
                    game.Desplegadas = desp;
                    return "Desplegadas Modificado";
                }
            }
            return "No encontrado";
        }

        public string modifiCarSob(string nickname, string nickO, int sob)
        {
            if (raiz != null)
            {
                NodoA actual = buscar(nickname);
                if (actual != null)
                {
                    Juego game = actual.listJuego.getJuego(nickO);
                    game.Sobrevivientes = sob;
                    return "Sobrevivientes Modificado";
                }
            }
            return "No encontrado";
        }

        public string modifiCarDest(string nickname, string nickO, int dest)
        {
            if (raiz != null)
            {
                NodoA actual = buscar(nickname);
                if (actual != null)
                {
                    Juego game = actual.listJuego.getJuego(nickO);
                    game.Destruidas = dest;
                    return "Destruidas Modificado";
                }
            }
            return "No encontrado";
        }

        public string modifiCarGanada(string nickname, string nickO, bool gana)
        {
            if (raiz != null)
            {
                NodoA actual = buscar(nickname);
                if (actual != null)
                {
                    Juego game = actual.listJuego.getJuego(nickO);
                    game.Ganar = gana;
                    return "Desplegadas Modificado";
                }
            }
            return "No encontrado";
        }
        //Fin eliminacion de Juego
        //FIN CALCULO DE ALTURA
        // calculo de ramas 
        public int getRamas() 
        {
            if (this.raiz == null)
            {
                return 0;
            }
            else 
            {
                return getRamas(raiz);
            }
            
        }

        public int getRamas(NodoA actual) 
        {
            if (actual == null)
            {
                return 0;
            }
            else 
            {
                int ri = getRamas(actual.Izquierda);
                int rd = getRamas(actual.Derecha);
                return ri + rd+1;
            }
        }
        // fin calculo de ramas
        //CALCULO DE NODO HOJA 
        public int getNodoHoja() 
        {
            if (this.raiz == null)
            {
                return 0;
            }
            else 
            {
                return getNodoH(this.raiz);
            }

        }

        int getNodoH(NodoA actual) 
        {
            if (actual == null)
            {
                return 0;
            }
            else 
            {
                if (actual.Izquierda == null && actual.Derecha == null)
                {
                    return 1;
                }
                else 
                {
                    return getNodoH(actual.Izquierda) + getNodoH(actual.Derecha);
                }
            }
        }

        // FIN CALCULO NODO HOJA
        //ELIMINAR NODO 
        public bool eliminarNodo(NodoA usuario) 
        {
            
            //para poder verificar que tenga hijos izquierdos y derechos
            bool nodoDerecho = usuario.Derecha != null ? true : false;
            bool nodoIzquierdo = usuario.Izquierda != null ? true : false;
            //segun se de el caso asi procedemos

            if(!nodoDerecho && !nodoIzquierdo)
            {
                return removerNodoCaso1(usuario);
            }

            if (nodoDerecho && !nodoIzquierdo)
            {
                return removerNodoCaso2(usuario);
            }

            if (!nodoDerecho && nodoIzquierdo)
            {
                return removerNodoCaso2(usuario);
            }

            if (nodoDerecho && nodoIzquierdo)
            {
                return removerCaso3(usuario);
            }

            return false;
 
        }

        public bool removerNodoCaso1(NodoA usuario) 
        {
            NodoA hijoIzquierdo = usuario.Padre.Izquierda;
            NodoA hijoDerecho = usuario.Padre.Derecha;

            if (hijoIzquierdo == usuario)
            {
                usuario.Padre.Izquierda = null;
                usuario = null;
                return true;
            }

            if (hijoDerecho == usuario)
            {
                usuario.Padre.Derecha = null;
                usuario = null;
                return true;
            }

            return false;
        }

        public bool removerNodoCaso2(NodoA usuario) 
        {
            NodoA hijoIzquierdo = usuario.Padre.Izquierda;
            NodoA hijoDerecho = usuario.Padre.Derecha;

            NodoA hijoActual = usuario.Izquierda != null ? usuario.Izquierda : usuario.Derecha;

            if (hijoIzquierdo == usuario)
            {
                usuario.Padre.Izquierda = hijoActual;

                hijoActual.Padre = usuario.Padre;
                usuario.Derecha = null;
                usuario.Izquierda = null;
                usuario = null;
                return true;
            }

            if (hijoDerecho == usuario)
            {
                usuario.Padre.Derecha = hijoActual;

                hijoActual.Padre = usuario.Padre;
                usuario.Derecha = null;
                usuario.Izquierda = null;
                usuario = null;
                return true;
            }

            return false;
        }

        public bool removerCaso3(NodoA usuario) {
            NodoA nodoMasIzquierdo = recorrerIzquierda(usuario.Derecha);
            if (nodoMasIzquierdo != null)
            {
                usuario.Usuario = nodoMasIzquierdo.Usuario;

                eliminarNodo(nodoMasIzquierdo);
                return true;

            }

            return false;
        }

        public NodoA recorrerIzquierda(NodoA usuario)
        {
            if (usuario.Izquierda != null)
            {
                return recorrerIzquierda(usuario.Izquierda);
            }
            return usuario;
        }


        //FIN ELIMINAR NODO

       
    }
}
