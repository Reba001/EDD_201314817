using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebServerNW
{
    public class NodoL
    {
        private NodoL siguiente;
        private NodoL anterior;
        Juego juego;
        public NodoL(Juego juego) {
            this.juego = juego;
            this.siguiente = null;
            this.anterior = null;
        }


        public NodoL Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
        public NodoL Anterior
        {
            get { return anterior; }
            set { anterior = value; }
        }


        internal Juego Juego
        {
            get { return juego; }
            set { juego = value; }
        }
    }
}
