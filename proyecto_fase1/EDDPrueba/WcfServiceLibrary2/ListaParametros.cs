using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfServiceLibrary2
{
    public class ListaParametros
    {
        NodoPJ primero;
        NodoPJ ultimo;
        public ListaParametros() 
        {
            this.primero = null;
            this.ultimo = null;
        }

        public void insertar(Parametros pj) {
            NodoPJ nuevo = new NodoPJ(pj);
            if (this.primero == null)
            {
                this.primero = nuevo;
                this.ultimo = nuevo;
            }
            else 
            {
                this.ultimo.Siguiente = nuevo;
                nuevo.Anterior = this.ultimo;
                this.ultimo = nuevo;
            }
        }

        public Parametros getPJ() 
        {
            if (this.primero != null)
            {
                if (this.primero != this.ultimo){

                    NodoPJ actual = this.primero;
                    this.primero = this.primero.Siguiente;
                    this.primero.Anterior = null;
                    Parametros pj1 = actual.Pj;
                    actual = null;
                    return pj1;
                }
                Parametros pj2 = this.primero.Pj;
                this.primero = null;
                this.ultimo = null;
                return pj2;
            }
            return null;
        }
    }
}
