using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WebServerNW
{
 
    class NodoPJ
    {
        private Parametros pj;
 
        public Parametros Pj
        {
            get { return pj; }
            set { pj = value; }
        }

        private NodoPJ siguiente;
 
        public NodoPJ Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }

        private NodoPJ anterior;
         public NodoPJ Anterior
        {
            get { return anterior; }
            set { anterior = value; }
        }
        public NodoPJ(Parametros pj) 
        {
            this.pj = pj;
        }
    }
}
