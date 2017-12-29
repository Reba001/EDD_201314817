using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfServiceLibrary2
{
    public class Nodo
    {
        private Nodo siguiente;
        private Nodo anterior;
        private Nodo arriba;
        private Nodo abajo;
        private Nodo adelante;
        private Nodo atras;
        private Pieza pieza;
        private int fila;
        private string columna;
        private int nivel;

        public int Fila
        {
            get { return fila; }
            set { fila = value; }
        }

        public string Columna
        {
            get { return columna; }
            set { columna = value; }
        }

        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        public Nodo(int fila, string columna, int nivel, Pieza piece) {
            this.pieza = piece;
            this.fila = fila;
            this.columna = columna;
            this.nivel = nivel;
        }



        public Nodo Atras
        {
            get { return atras; }
            set { atras = value; }
        }

        public Nodo Adelante
        {
            get { return adelante; }
            set { adelante = value; }
        }

        public Pieza Pieza
        {
            get { return pieza; }
            set { pieza = value; }
        }

        public Nodo Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }


        public Nodo Anterior
        {
            get { return anterior; }
            set { anterior = value; }
        }
        public Nodo Arriba
        {
            get { return arriba; }
            set { arriba = value; }
        }

        public Nodo Abajo
        {
            get { return abajo; }
            set { abajo = value; }
        }
       
    }
}
