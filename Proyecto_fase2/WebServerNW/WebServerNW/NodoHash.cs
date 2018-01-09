using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebServerNW
{
    class NodoHash
    {
        
        public Usuario[] usuarios;
        public double factorCarga;
        public int elementos;
        public NodoHash(int tamanio) 
        {
            this.factorCarga = 0.0;
            this.elementos = 0;
            this.usuarios = new Usuario [tamanio] ;
        }


    }
}
