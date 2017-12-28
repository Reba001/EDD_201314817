using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WcfServiceLibrary2
{
    [DataContract]
    class NodoPJ
    {
        private Parametros pj;
        [DataMember]
        public Parametros Pj
        {
            get { return pj; }
            set { pj = value; }
        }

        private NodoPJ siguiente;
        [DataMember]
        public NodoPJ Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
        private NodoPJ anterior;
        [DataMember]
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
