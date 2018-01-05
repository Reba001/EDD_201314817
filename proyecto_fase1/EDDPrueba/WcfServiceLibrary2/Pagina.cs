using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfServiceLibrary2
{
    public class Pagina
    { 
        private static int m = 5; 
        public Movimiento [] movimientos;
        public Pagina [] ramas;
        public int cuenta;

        public Pagina()
        {
            this.movimientos = new Movimiento[m];
            this.movimientos[0] = null;
            this.movimientos[1] = null;
            this.movimientos[2] = null;
            this.movimientos[3] = null;
            this.movimientos[4] = null;
            this.ramas = new Pagina[m];
            this.ramas[0] = null;
            this.ramas[1] = null;
            this.ramas[2] = null;
            this.ramas[3] = null;
            this.ramas[4] = null;
            this.cuenta = 0;
        }

        public bool nodoLLeno() 
        {
            return (cuenta == (m - 1));
        }

        public bool nodoSemiVacio() 
        {
            return (cuenta < (m / 2));
        }
        public string escribirNodo() 
        {

            StringBuilder nodoP = new StringBuilder();
            nodoP.Append("Nodo: \n");
            for (int k = 1; k <= cuenta; k++ )
            {
                nodoP.Append(movimientos[k].toString()+"\n");
            }
            return nodoP.ToString();
        }
    }
}
