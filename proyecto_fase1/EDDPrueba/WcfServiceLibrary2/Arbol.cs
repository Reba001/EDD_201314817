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
        public void crearGrafo() 
        {
            string grafo = "digraph g{\n";
            grafo += preOrden();
            grafo += "}\n";
            System.IO.File.WriteAllText(@"C:\Users\aaper\Desktop\Arbol.dot", grafo);
            ProcessStartInfo starInfo = new ProcessStartInfo("dot.exe");
            starInfo.Arguments = "-Tjpg C:\\Users\\aaper\\Desktop\\Arbol.dot -o C:\\Users\\aaper\\Desktop\\Arbol.jpg";
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
                
                preO(actual.Izquierda, ref recorrido);
                preO(actual.Derecha, ref recorrido);
                return recorrido;
            }
            return recorrido;
            
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
