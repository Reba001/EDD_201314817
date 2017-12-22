using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WcfServiceLibrary2
{
    public class ListaPrueba
    {
        Nodo Cabeza;
        int tamanio;
        public ListaPrueba()
        {
            this.Cabeza = null;
            this.tamanio = 0;
        }
        public void insertar(Pieza pieces)
        {

            Nodo nuevo = new Nodo(pieces);
            if (this.Cabeza == null)
            {
                this.Cabeza = nuevo;
            }
            else
            {
                Nodo aux = this.Cabeza;
                while (aux.Siguiente != null)
                {
                    aux = aux.Siguiente;
                }

                aux.Siguiente = nuevo;
            }
            tamanio++;
        }

        public void recorrer()
        {
            if (this.Cabeza != null)
            {
                Nodo aux = this.Cabeza;
                while (aux != null)
                {

                    Console.WriteLine(aux.Pieza.Unidad);
                    aux = aux.Siguiente;
                }

            }
            else
            {
                Console.WriteLine("Vacio DX");
            }

        }

        public string recorrer2()
        {
            if (this.Cabeza != null)
            {
                string recorrido = "";
                Nodo aux = this.Cabeza;
                while (aux != null)
                {

                    recorrido += aux.Pieza.Unidad+"\n";
                    aux = aux.Siguiente;
                }
                return recorrido;

            }
            return "Vacio DX";
            
        }
    }
}
