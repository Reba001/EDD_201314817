using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfServiceLibrary2
{
    class Encabezado
    {
        private ListaEncabezado listAcceso;

        public ListaEncabezado ListAcceso
        {
            get { return listAcceso; }
            set { listAcceso = value; }
        }

        private Encabezado siguiente;

        public Encabezado Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
        private Encabezado anterior;

        public Encabezado Anterior
        {
            get { return anterior; }
            set { anterior = value; }
        }
        private Nodo acceso;

        public Nodo Acceso
        {
            get { return acceso; }
            set { acceso = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string identificador;

        public string Identificador
        {
            get { return identificador; }
            set { identificador = value; }
        }

        public Encabezado(int id)
        {
            this.id = id;
            this.siguiente = null;
            this.anterior = null;
            this.acceso = null;
            this.listAcceso = new ListaEncabezado();

        }

        public Encabezado(string identificador)
        {
            this.identificador = identificador;
            this.siguiente = null;
            this.anterior = null;
            this.acceso = null;
            this.listAcceso = new ListaEncabezado();
        }
    }
}
