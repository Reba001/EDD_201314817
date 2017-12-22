using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfServiceLibrary2
{
    class ListaEncabezado
    {
        private Encabezado cabeza;
        private Encabezado cola;
        private int tamanio;
        public ListaEncabezado() {
            this.cabeza = null;
            this.cola = null;
            this.tamanio = 0;
        }

        public void insertar(int id)
        {
            Encabezado nuevo = new Encabezado(id);
            if (this.cabeza == null)
            {
                this.cabeza = nuevo;
                this.cola = nuevo;
            }
            else
            {
                this.cola.Siguiente = nuevo;
                nuevo.Anterior = this.cola;
                this.cola = nuevo;
            }
            tamanio++;
        }

        public void insertar(string identificador)
        {
            Encabezado nuevo = new Encabezado(identificador);
            if (this.cabeza == null)
            {
                this.cabeza = nuevo;
                this.cola = nuevo;
            }
            else
            {
                this.cola.Siguiente = nuevo;
                nuevo.Anterior = this.cola;
                this.cola = nuevo;
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
            if (this.cabeza == null)
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
                        this.cabeza = this.cabeza.Siguiente;
                        this.cabeza.Anterior = null;
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
            if (this.cabeza == null)
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
                        this.cabeza = this.cabeza.Siguiente;
                        this.cabeza.Anterior = null;
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
