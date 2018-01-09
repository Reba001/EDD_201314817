using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace WebServerNW
{
   public class Movimiento
    {
        private string X;//posicion Y

        private int Y;// posicion X

        private string atacante;//pieza que ataco o sea el nivel

        private int resultado;// resultado -1 o 0 destruida, de cero para arriba daño causado 

        private string tipoUD;// tipo deunidad dañada

        private string nickEmisor; // usuario emisor

        private string nickReceptor; // usuario receptor

        private string fecha;

        private string tiempoRestante;

        private int numerodeAtaque;

        private int key;

        

        public Movimiento(string X, int Y, string atacante, int resultado, string tipoUD, string nickEmisor, string nickReceptor, string fecha, string tiempoRestante, int numeroA, int key) 
        {
            this.X = X;
            this.Y = Y;
            this.atacante = atacante;
            this.resultado = resultado;
            this.tipoUD = tipoUD;
            this.nickEmisor = nickEmisor;
            this.nickReceptor = nickReceptor;
            this.fecha = fecha;
            this.tiempoRestante = tiempoRestante;
            this.numerodeAtaque = numeroA;
            this.key = key;
            
        }

        public int Key
        {
            get { return key; }
            set { key = value; }
        }

        public string X1
        {
            get { return X; }
            set { X = value; }
        }

        public int Y1
        {
            get { return Y; }
            set { Y = value; }
        }

        public string Atacante
        {
            get { return atacante; }
            set { atacante = value; }
        }

        public int Resultado
        {
            get { return resultado; }
            set { resultado = value; }
        }

        public string TipoUD
        {
            get { return tipoUD; }
            set { tipoUD = value; }
        }

        public string NickEmisor
        {
            get { return nickEmisor; }
            set { nickEmisor = value; }
        }

        public string NickReceptor
        {
            get { return nickReceptor; }
            set { nickReceptor = value; }
        }

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string TiempoRestante
        {
            get { return tiempoRestante; }
            set { tiempoRestante = value; }
        }

        public int NumerodeAtaque
        {
            get { return numerodeAtaque; }
            set { numerodeAtaque = value; }
        }

        public void clave() 
        {
            int c = 0;
            int nick= 0; 
            for (int i = 0; i < X.Length; i++)
                c += X[i];

            for (int k = 0; k < this.nickEmisor.Length; k++)
                nick += nickEmisor[k];

                if (atacante.StartsWith("Neosatelite"))
                    c += 4;
                else if (atacante.StartsWith("Bombardero") || atacante.StartsWith("Caza") || atacante.StartsWith("Helicóptero"))
                    c += 3;
                else if (atacante.StartsWith("Fragata") || atacante.StartsWith("Crucero"))
                    c += 2;
                else if (atacante.StartsWith("Submarino"))
                    c += 1;

            this.key = c+Y+nick;
        }
        public string toString() 
        {
            StringBuilder cadena = new StringBuilder();
            cadena.Append("Posicion X: " + X + "\n");
            cadena.Append("Posicion Y: " + Y.ToString() + "\n");
            cadena.Append("Unidad Atacante : " + atacante + "\n");
            if (resultado == 0)
                cadena.Append("Resultado: Golpe \n");
            else
                cadena.Append("Resultado: Eliminado");
            cadena.Append("Unidad Atacada: " + tipoUD + "\n");
            cadena.Append("Emisor: " + nickEmisor + "\n");
            cadena.Append("Receptor: " + nickReceptor + "\n");
            cadena.Append("Fecha: " + fecha + "\n");
            cadena.Append("Unidad Atacada: " + tipoUD + "\n");
            cadena.Append("Tiempo Restante: "+ tiempoRestante+ "\n");
            cadena.Append("Numero de Ataque: "+numerodeAtaque.ToString()+"\n");
            return cadena.ToString();
        }
    }
}
