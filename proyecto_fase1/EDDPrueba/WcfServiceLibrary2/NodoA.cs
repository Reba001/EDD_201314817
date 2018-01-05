using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfServiceLibrary2
{
    public class NodoA
    {
        private NodoA izquierda;
        private NodoA derecha;
        private NodoA padre;
        private Usuario usuario;
        public ArbolAVL contactos;
        public ListaJuego listJuego;
        //public ListaJuego listGame;
        public NodoA(Usuario usuario) {
            this.usuario = usuario;
            this.izquierda = null;
            this.derecha = null;
            this.padre = null;
            this.listJuego = new ListaJuego();
            this.contactos = new ArbolAVL();
          //  this.listGame = new ListaJuego();
        }
        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public NodoA Derecha
        {
            get { return derecha; }
            set { derecha = value; }
        }
        
        public NodoA Izquierda
        {
            get { return izquierda; }
            set { izquierda = value; }
        }



        public NodoA Padre
        {
            get { return padre; }
            set { padre = value; }
        }

        




    }
}
