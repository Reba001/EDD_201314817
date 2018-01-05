using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WcfServiceLibrary2
{
    public class ArbolAVL
    {
        NodoA raiz;

        public ArbolAVL(){
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
        // insercion de arbol avl
        //INICIO INSERCION
        public bool insertar(NodoA nuevo)
        {
            if (buscar(nuevo.Usuario.Nickname) == null)
            {
                if (this.raiz == null)
                {
                    this.raiz = nuevo;
                    return true;
                }
                else
                {
                    
                    return inserta(this.raiz, nuevo);

                }
            }
            return false;
        }

        bool inserta( NodoA actual, NodoA nuevo)
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
                    inserta(actual.Izquierda, nuevo);
                    int fe = (calcularH(actual.Derecha) - calcularH(actual.Izquierda));
                    
                    if (fe == 2)
                    {
                        NodoA padreTemp = actual.Padre;
                        int fed = (calcularH(actual.Derecha.Derecha) - calcularH(actual.Derecha.Izquierda));
                        if (fed == 1)
                        {//DD
                            NodoA temporal = actual.Derecha;
                            actual.Derecha = temporal.Izquierda;
                            if (temporal.Izquierda != null)
                                temporal.Izquierda.Padre = actual;
                            temporal.Izquierda = actual;
                            actual.Padre = temporal;// por lo de las rotaciones 
                            actual = temporal;

                        }
                        else if (fed == -1)
                        { //DI
                            NodoA temporal = actual.Derecha;
                            NodoA temporal2 = temporal.Izquierda;
                            actual.Derecha = temporal2.Izquierda;
                            if (temporal2.Izquierda != null)
                                temporal2.Izquierda.Padre = actual;
                            temporal2.Izquierda = actual;
                            actual.Padre = temporal2;
                            temporal.Izquierda = temporal2.Derecha;
                            if (temporal2.Derecha != null)
                                temporal2.Derecha.Padre = temporal;
                            temporal2.Derecha = temporal;
                            temporal.Padre = temporal2;
                            actual = temporal2;
                        }

                        if (padreTemp != null)
                        {
                            if (String.Compare(actual.Usuario.Nickname, padreTemp.Usuario.Nickname) < 0)
                                padreTemp.Izquierda = actual;
                            else
                                padreTemp.Derecha = actual;
                        }
                        else 
                        {
                            this.raiz = actual;
                        }
                           
                    }
                    else if (fe == -2)
                    {
                        NodoA padreTemp = actual.Padre;
                        int fei = (calcularH(actual.Izquierda.Derecha) - calcularH(actual.Izquierda.Izquierda));
                        if (fei == -1)
                        {//II
                            NodoA temporal = actual.Izquierda;
                            actual.Izquierda = temporal.Derecha;
                            if (temporal.Derecha != null)
                                temporal.Derecha.Padre = actual;
                            temporal.Derecha = actual;
                            actual.Padre = temporal;
                            actual = temporal;
                        }
                        else if (fei == 1) 
                        {//ID
                            NodoA temporal = actual.Izquierda;
                            NodoA temporal2 = temporal.Derecha;
                            actual.Izquierda = temporal2.Derecha;
                            if (temporal2.Derecha != null)
                                temporal2.Derecha.Padre = actual;
                            temporal2.Derecha =actual;
                            actual.Padre = temporal2;
                            temporal.Derecha = temporal2.Izquierda;
                            if (temporal2.Izquierda != null)
                                temporal2.Izquierda.Padre = temporal;
                            temporal2.Izquierda = temporal;
                            temporal.Padre = temporal2;
                            actual = temporal2;
                        }

                        if (padreTemp != null)
                        {
                            if (String.Compare(actual.Usuario.Nickname, padreTemp.Usuario.Nickname) < 0)
                                padreTemp.Izquierda = actual;
                            else
                                padreTemp.Derecha = actual;
                        }
                        else
                        {
                            this.raiz = actual;
                        }
                    }


                    return true;
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
                    inserta(actual.Derecha, nuevo);
                    int fe = (calcularH(actual.Derecha) - calcularH(actual.Izquierda));
                    if (fe == 2)
                    {
                        int fed = (calcularH(actual.Derecha.Derecha) - calcularH(actual.Derecha.Izquierda));
                        if (fed == 1)
                        {//DD
                            NodoA temporal = actual.Derecha;
                            actual.Derecha = temporal.Izquierda;
                            if (temporal.Izquierda != null)
                                temporal.Izquierda.Padre = actual;
                            temporal.Izquierda = actual;
                            actual.Padre = temporal;// por lo de las rotaciones 
                            actual = temporal;
                        }
                        else if (fed == -1)
                        { //DI
                            NodoA temporal = actual.Derecha;
                            NodoA temporal2 = temporal.Izquierda;
                            actual.Derecha = temporal2.Izquierda;
                            if (temporal2.Izquierda != null)
                                temporal2.Izquierda.Padre = actual;
                            temporal2.Izquierda = actual;
                            actual.Padre = temporal2;
                            temporal.Izquierda = temporal2.Derecha;
                            if (temporal2.Derecha != null)
                                temporal2.Derecha.Padre = temporal;
                            temporal2.Derecha = temporal;
                            temporal.Padre = temporal2;
                            actual = temporal2;
                        }
                    }
                    else if (fe == -2)
                    {
                        int fei = (calcularH(actual.Izquierda.Derecha) - calcularH(actual.Izquierda.Izquierda));
                        if (fei == -1)
                        {//II
                            NodoA temporal = actual.Izquierda;
                            actual.Izquierda = temporal.Derecha;
                            if (temporal.Derecha != null)
                                temporal.Derecha.Padre = actual;
                            temporal.Derecha = actual;
                            actual.Padre = temporal;
                            actual = temporal;
                        }
                        else if (fei == 1)
                        {//ID
                            NodoA temporal = actual.Izquierda;
                            NodoA temporal2 = temporal.Derecha;
                            actual.Izquierda = temporal2.Derecha;
                            if (temporal2.Derecha != null)
                                temporal2.Derecha.Padre = actual;
                            temporal2.Derecha = actual;
                            actual.Padre = temporal2;
                            temporal.Derecha = temporal2.Izquierda;
                            if (temporal2.Izquierda != null)
                                temporal2.Izquierda.Padre = temporal;
                            temporal2.Izquierda = temporal;
                            temporal.Padre = temporal2;
                            actual = temporal2;
                        }
                    }

                    return true;
                }
            }
        }

        //FIN INSERCION

        

        public NodoA rotacionDI(NodoA raizlocal) //var true
        {
            NodoA temporal = raizlocal.Derecha;
            NodoA temporal2 = temporal.Izquierda;
            raizlocal.Derecha = temporal2.Izquierda;
            if (temporal2.Izquierda != null)
                temporal2.Izquierda.Padre = raizlocal;
            temporal2.Izquierda = raizlocal;
            raizlocal.Padre = temporal2;
            temporal.Izquierda = temporal2.Derecha;
            if (temporal2.Derecha != null)
                temporal2.Derecha.Padre = temporal;
            temporal2.Derecha = temporal;
            temporal.Padre = temporal2;
            raizlocal = temporal2;
            return raizlocal;
        }
        public NodoA rotacionID(NodoA raizlocal) // var false
        {
            NodoA temporal = raizlocal.Izquierda;
            NodoA temporal2 = temporal.Derecha;
            raizlocal.Izquierda = temporal2.Derecha;
            if (temporal2.Derecha != null)
                temporal2.Derecha.Padre = raizlocal;
            temporal2.Derecha = raizlocal;
            raizlocal.Padre = temporal2;
            temporal.Derecha = temporal2.Izquierda;
            if (temporal2.Izquierda != null)
                temporal2.Izquierda.Padre = temporal;
            temporal2.Izquierda = temporal;
            temporal.Padre = temporal2;
            raizlocal = temporal2;
            return raizlocal;
        }
        public NodoA rotacionDD(NodoA contactoLocal) // var false
        {
            NodoA temporal = contactoLocal.Derecha;
            contactoLocal.Derecha = temporal.Izquierda;
            if (temporal.Izquierda != null)
                temporal.Izquierda.Padre = contactoLocal;
            temporal.Izquierda = contactoLocal;
            contactoLocal.Padre = temporal;// por lo de las rotaciones 
            contactoLocal = temporal;
            return contactoLocal;
        }

        public NodoA rotacionII(NodoA contactoLocal) //  var true
        {
            NodoA temporal = contactoLocal.Izquierda;
            contactoLocal.Izquierda = temporal.Derecha;
            if (temporal.Derecha != null)
                temporal.Derecha.Padre = contactoLocal;
            temporal.Derecha = contactoLocal;
            contactoLocal.Padre = temporal;
            contactoLocal = temporal;
            return contactoLocal;

        }

        public void crearGrafo()
        {
            string grafo = "digraph g{\n";
            int h = calcularAltura();
            int nh = getNodoHoja();
            int rama = getRamas();
            grafo += "\"Altura: " + h.ToString() + "\n";
            grafo += "Nodos Hoja: " + nh.ToString() + "\n";
            grafo += "Niveles: " + Convert.ToString(h + 1) + "\n";
            grafo += "Ramas: " + Convert.ToString(rama) + "\";\n";
            grafo += preOrden();
            grafo += "}\n";
            System.IO.File.WriteAllText("C:\\CSVFile\\Imagen\\ArbolAVL.dot", grafo);
            ProcessStartInfo starInfo = new ProcessStartInfo("dot.exe");
            starInfo.Arguments = "-Tjpg C:\\CSVFile\\Imagen\\ArbolAVL.dot -o C:\\CSVFile\\Imagen\\ArbolAVL.jpg";
            Process.Start(starInfo);
        }
        public string preOrden()
        {
            string recorrido = "";
            preO(raiz, ref recorrido);
            return recorrido;

        }

        public string preO(NodoA actual, ref string recorrido)
        {
            if (actual != null)
            {

                if (actual.Izquierda != null)
                {
                    recorrido += "\t\"" + actual.Usuario.toString() + "\" -> \"" + actual.Izquierda.Usuario.toString() + "\";\n";
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
                return (hi > hd ? hi : hd) + 1;

            }
        }

        //ELIMINAR NODO 
        public bool eliminarNodo(NodoA usuario)
        {

            //para poder verificar que tenga hijos izquierdos y derechos
            bool nodoDerecho = usuario.Derecha != null ? true : false;
            bool nodoIzquierdo = usuario.Izquierda != null ? true : false;
            //segun se de el caso asi procedemos

            if (!nodoDerecho && !nodoIzquierdo)
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

        public bool removerCaso3(NodoA usuario)
        {
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


    }
}
