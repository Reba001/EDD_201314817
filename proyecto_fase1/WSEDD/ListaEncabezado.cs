using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfServiceLibrary2
{
    class ListaEncabezado
    {

        private Encabezado cabeza;

        internal Encabezado Cabeza
        {
            get { return cabeza; }
            set { cabeza = value; }
        }
        private Encabezado cola;
        private int tamanio;
        public ListaEncabezado() {
           
            this.cabeza = null;
            this.cola = null;
            this.tamanio = 0;
        }

        public void insertarF(Encabezado nuevo) {
            if (this.cabeza == null)
            {
                this.cabeza = nuevo;
            }
            else 
            {
                if (nuevo.Id < this.cabeza.Id)
                {
                    nuevo.Siguiente = this.cabeza;
                    this.cabeza.Anterior = nuevo;
                    this.cabeza = nuevo;
                }
                else 
                {
                    Encabezado actual = this.cabeza;
                    while(actual.Siguiente != null)
                    {
                        if (nuevo.Id <  actual.Siguiente.Id)
                        {
                            nuevo.Siguiente = actual.Siguiente;
                            actual.Siguiente.Anterior = nuevo;
                            nuevo.Anterior = actual;
                            actual.Siguiente = nuevo;
                            break;
                        }
                        actual = actual.Siguiente;
                    }

                    if (actual.Siguiente == null)
                    {
                        actual.Siguiente = nuevo;
                        nuevo.Anterior = actual;
                    }
                }

            }
            tamanio++;
        }

        public void insertarC(Encabezado nuevo)
        {
            if (this.cabeza == null)
            {
                this.cabeza = nuevo;
            }
            else
            {

                if (String.Compare(nuevo.Identificador, cabeza.Identificador) < 0)
                {
                    nuevo.Siguiente = this.cabeza;
                    this.cabeza.Anterior = nuevo;
                    this.cabeza = nuevo;
                }
                else
                {
                    Encabezado actual = this.cabeza;
                    while (actual.Siguiente != null)
                    {
                        if (String.Compare(nuevo.Identificador, actual.Siguiente.Identificador) < 0)
                        {
                            nuevo.Siguiente = actual.Siguiente;
                            actual.Siguiente.Anterior = nuevo;
                            nuevo.Anterior = actual;
                            actual.Siguiente = nuevo;
                            break;
                        }
                        actual = actual.Siguiente;
                    }

                    if (actual.Siguiente == null)
                    {
                        actual.Siguiente = nuevo;
                        nuevo.Anterior = actual;
                    }
                }

            }
            tamanio++;
        }


        public Encabezado getEncabezado(int id)
        {
            if (this.cabeza != null)
            {
                Encabezado aux = this.cabeza;
                while (aux != null)
                {
                    if (aux.Id == id)
                    {
                        return aux;
                    }
                    aux = aux.Siguiente;
                }
            }
            return null;
        }

        public Encabezado getEncabezado(string identificador)
        {
            if (this.cabeza != null)
            {
                Encabezado aux = this.cabeza;
                while (aux != null)
                {
                    if (aux.Identificador == identificador)
                    {
                        return aux;
                    }
                    aux = aux.Siguiente;
                }
            }
            return null;
        }

        public void eliminar(int id)
        {
            if (this.cabeza != null)
            {
                if (this.cabeza.Id == id)
                {
                    if (this.cabeza.Siguiente == null)
                    {
                        this.cabeza = null;
                        this.cola = null;
                    }
                    else
                    {
                        Encabezado aux = this.cabeza;
                        this.cabeza = this.cabeza.Siguiente;
                        this.cabeza.Anterior = null;
                        aux = null;
                    }
                }
                else
                {
                    Encabezado aux = this.cabeza;
                    while (aux.Siguiente != null)
                    {
                        if (aux.Id == id)
                        {
                            aux.Anterior.Siguiente = aux.Siguiente;
                            aux.Siguiente.Anterior = aux.Anterior;
                            aux = null;
                            return;
                        }
                        aux = aux.Siguiente;
                    }

                    if (aux.Siguiente == null && aux.Id == id)
                    {
                        this.cola = this.cola.Anterior;
                        this.cola.Siguiente = null;
                        aux = null;
                    }
                }

            }

            Console.WriteLine("Vacio DX");
        }

        public void eliminar(string identificador)
        {
            if (this.cabeza != null)
            {
                if (this.cabeza.Identificador == identificador)
                {
                    if (this.cabeza.Siguiente == null)
                    {
                        this.cabeza = null;
                        this.cola = null;
                    }
                    else
                    {
                        Encabezado aux = this.cabeza;
                        this.cabeza = this.cabeza.Siguiente;
                        this.cabeza.Anterior = null;
                        aux = null;
                    }
                }
                else
                {
                    Encabezado aux = this.cabeza;
                    while (aux.Siguiente != null)
                    {
                        if (aux.Identificador == identificador)
                        {
                            aux.Anterior.Siguiente = aux.Siguiente;
                            aux.Siguiente.Anterior = aux.Anterior;
                            aux = null;
                            return;
                        }
                        aux = aux.Siguiente;
                    }

                    if (aux.Siguiente == null && aux.Identificador == identificador)
                    {
                        this.cola = this.cola.Anterior;
                        this.cola.Siguiente = null;
                        aux = null;
                    }
                }

            }

            Console.WriteLine("Vacio DX");
        }

    }
}
