using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfServiceLibrary2
{
    public class Matriz
    {
        ListaEncabezado eColumna;
        ListaEncabezado eFila;
        public Matriz()
        {
            this.eColumna = new ListaEncabezado();
            this.eFila = new ListaEncabezado();
        }

        public void insertar(int fila, string columna, int nivel, Pieza pieza)
        {
            Nodo nuevo = new Nodo(fila, columna, nivel, pieza);
            // fila
            Encabezado efila = this.eFila.getEncabezado(fila);
            if (efila == null)// si fila es null por lo tanto no hay ningun dato de fila
            {
                efila = new Encabezado(fila);
                Encabezado enivel = enivel = new Encabezado(nivel);
                enivel.Acceso = nuevo;
                efila.ListAcceso.insertarF(enivel);
                eFila.insertarF(efila);
            }
            else 
            {
                Encabezado enivel = efila.ListAcceso.getEncabezado(nivel);
                if (enivel == null)// Si ya tenemos fila pero no tenemos nivel
                {
                 
                    enivel = new Encabezado(nivel);
                    efila.ListAcceso.insertarF(enivel);
                    if (enivel.Siguiente != null && enivel.Siguiente.Acceso.Columna == columna)// si hay mas niveles y los queremos enlazar
                    {
                        nuevo.Adelante = enivel.Siguiente.Acceso;
                        enivel.Siguiente.Acceso.Atras = nuevo;
                           
                    }

                    if (enivel.Anterior != null && enivel.Anterior.Acceso.Columna == columna)// si hay mas niveles y los queremos enlazar
                    {
                        nuevo.Atras = enivel.Anterior.Acceso;
                        enivel.Anterior.Acceso.Adelante = nuevo;
                    }

                    enivel.Acceso = nuevo;
                }
                else // si ya esta creado el nivel
                {
                    int comparacion = String.Compare(nuevo.Columna, enivel.Acceso.Columna);
                    if (comparacion < 0) // si el dato que queremos insertar lo insertamos al principio
                    {
                        nuevo.Siguiente = enivel.Acceso;
                        enivel.Acceso.Anterior = nuevo;
                        if (enivel.Siguiente != null && enivel.Siguiente.Acceso.Columna == columna)// si hay mas nodos en nivel entonces verificamossi es la misma columna
                        {
                            nuevo.Adelante = enivel.Siguiente.Acceso;
                            enivel.Siguiente.Acceso.Atras = nuevo;

                        }

                        if (enivel.Anterior != null && enivel.Anterior.Acceso.Columna == columna)// si hay mas nodos en nivel verificamos si es la misma columna
                        {
                            nuevo.Atras = enivel.Anterior.Acceso;
                            enivel.Anterior.Acceso.Adelante = nuevo;
                        }

                        enivel.Acceso = nuevo;
                    }
                    else 
                    {
                        Nodo actual = enivel.Acceso;
                        while(actual.Siguiente != null)
                        {
                            if (String.Compare(nuevo.Columna, actual.Siguiente.Columna) < 0)// si el nodo hay que insertarlo al medio 
                            {
                                nuevo.Siguiente = actual.Siguiente;
                                actual.Siguiente.Anterior = nuevo;
                                nuevo.Anterior = actual;
                                actual.Siguiente = nuevo;
                                if(enivel.Siguiente != null)
                                {
                                    Nodo actualS = enivel.Siguiente.Acceso;
                                    while(actualS != null)
                                    {
                                        if (actualS.Columna == columna)
                                        {
                                            nuevo.Adelante = actualS;
                                            actualS.Atras = nuevo;
                                            break;
                                        }
                                        actualS = actualS.Siguiente;
                                    }
                                }

                                if (enivel.Anterior != null)
                                {
                                    Nodo actualI = enivel.Anterior.Acceso;
                                    while(actualI != null)
                                    {
                                        if (actualI.Columna == columna)
                                        {
                                            nuevo.Atras = actualI;
                                            actualI.Adelante = nuevo;
                                            break;
                                        }
                                        actualI = actualI.Siguiente;
                                    }
                                }
                                
                                break;
                            }
                            actual = actual.Siguiente;
                        }

                        if(actual.Siguiente == null)// insercion de ultimo
                        {
                            actual.Siguiente = nuevo;
                            nuevo.Anterior = actual;
                            if (enivel.Siguiente != null)
                            {
                                Nodo actualS = enivel.Siguiente.Acceso;
                                while (actualS != null)
                                {
                                    if (actualS.Columna == columna)
                                    {
                                        nuevo.Adelante = actualS;
                                        actualS.Atras = nuevo;
                                        break;
                                    }
                                    actualS = actualS.Siguiente;
                                }
                            }

                            if (enivel.Anterior != null)
                            {
                                Nodo actualI = enivel.Anterior.Acceso;
                                while (actualI != null)
                                {
                                    if (actualI.Columna == columna)
                                    {
                                        nuevo.Atras = actualI;
                                        actualI.Adelante = nuevo;
                                        break;
                                    }
                                    actualI = actualI.Siguiente;
                                }
                            }
                        }// fin insercion de ultimo

                    }
                    
                }

            }
           
            //fin fila
            //INSERCION DE COLUMNA
            Encabezado ecolumna = this.eColumna.getEncabezado(columna);
            if (ecolumna == null)
            {
                ecolumna = new Encabezado(columna);
                Encabezado enivel = new Encabezado(nivel);
                enivel.Acceso = nuevo;
                ecolumna.ListAcceso.insertarF(enivel);
                eColumna.insertarC(ecolumna);
            }
            else 
            {
                Encabezado enivel = ecolumna.ListAcceso.getEncabezado(nivel);
                if (enivel == null)
                {
                    enivel = new Encabezado(nivel);
                    ecolumna.ListAcceso.insertarF(enivel);
                    enivel.Acceso = nuevo;
                }
                else 
                {
                    if (nuevo.Fila < enivel.Acceso.Fila) // insercion al inicio
                    {
                        nuevo.Abajo = enivel.Acceso;
                        enivel.Acceso.Arriba = nuevo;
                        enivel.Acceso = nuevo;
                    }
                    else 
                    {
                        Nodo actual = enivel.Acceso; // insercion al medio 
                        while(actual.Abajo != null)
                        {
                            if (nuevo.Fila < actual.Abajo.Fila)
                            {
                                nuevo.Abajo = actual.Abajo;
                                actual.Abajo.Arriba = nuevo;
                                nuevo.Arriba = actual;
                                actual.Abajo = nuevo;
                                break;
                            }
                            actual = actual.Abajo;
                        }

                        if (actual.Abajo == null) // insercion de columna al final
                        {
                            actual.Abajo = nuevo;
                            nuevo.Arriba = actual;
                        }

                    }
                }
            }
            //FIN INSERCION DE COLUMNA
        }

        public string recorrerFilas() 
        {
            StringBuilder recorrido = new StringBuilder();
            recorrido.Append("Recorrido por Fila \n");
            Encabezado efila = this.eFila.Cabeza;
            while(efila != null){
                recorrido.Append("\t Fila: " + efila.Id.ToString()+ "\n");
                Encabezado enivel = efila.ListAcceso.Cabeza;
                while(enivel != null)
                {
                    recorrido.Append("\t\t nivel: " + enivel.Id.ToString() + "\n");
                    Nodo actual = enivel.Acceso;
                    while(actual != null)
                    {
                        recorrido.Append(actual.Pieza.toString()+" -> ");
                        actual = actual.Siguiente;
                    }
                    enivel = enivel.Siguiente;
                }
                efila = efila.Siguiente;
            }
            return recorrido.ToString();
 
        }

        public string recorridoColumna() 
        {
            StringBuilder recorrido = new StringBuilder();
            recorrido.Append("Recorrido por Columna \n");
            Encabezado ecolumna = this.eColumna.Cabeza;
            while(ecolumna != null)
            {
                recorrido.Append("\t Columna: "+ ecolumna.Identificador);
                Encabezado enivel = ecolumna.ListAcceso.Cabeza;
                while(enivel != null)
                {
                    recorrido.Append("\t\t nivel: "+enivel.Id.ToString() + "\n");
                    Nodo actual = enivel.Acceso;
                    while(actual != null)
                    {
                        recorrido.Append(actual.Pieza.toString()+ " -> ");
                        actual = actual.Abajo;
                    }
                    enivel = enivel.Siguiente;
                }
                ecolumna = ecolumna.Siguiente;
            }
            return recorrido.ToString();
        }
    }
}
