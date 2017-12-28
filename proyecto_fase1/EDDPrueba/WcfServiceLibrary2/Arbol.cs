using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WcfServiceLibrary2
{
    public class Arbol
    {
        NodoA raiz;
        public Arbol() 
        {
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
        //IMPRESION PREORDEN
        //arbol espejo
        public void espejo() {
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
            System.IO.File.WriteAllText("C:\\CSVFile\\Imagen\\ArbolE.dot", grafo);
            ProcessStartInfo starInfo = new ProcessStartInfo("dot.exe");
            starInfo.Arguments = "-Tjpg C:\\CSVFile\\Imagen\\ArbolE.dot -o C:\\CSVFile\\Imagen\\ArbolE.jpg";
            Process.Start(starInfo);

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
        public void crearGrafo() 
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
            System.IO.File.WriteAllText("C:\\CSVFile\\Imagen\\Arbol.dot", grafo);
            ProcessStartInfo starInfo = new ProcessStartInfo("dot.exe");
            starInfo.Arguments = "-Tjpg C:\\CSVFile\\Imagen\\Arbol.dot -o C:\\CSVFile\\Imagen\\Arbol.jpg";
            Process.Start(starInfo);
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
                return ri + rd + 1;
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
