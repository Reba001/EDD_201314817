using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfServiceLibrary2
{
    public class ArbolB
    {
        public Pagina raiz;

        public ArbolB() 
        {
            this.raiz = null;
        }

        public bool buscarNodo(Pagina actual, Movimiento move, ref int k) 
        {
            int c1 = move.clave();
            bool encontrado = false;
            if (c1 < actual.movimientos[1].clave())
            {
                encontrado = false;
                k = 0;
            }
            else 
            {
                k = actual.cuenta;
                while ((c1 < actual.movimientos[k].clave()) && (k > 1))
                    k--;
                encontrado = (c1 == actual.movimientos[k].clave());
            }
            return encontrado;
        }

        public Pagina buscar(Pagina actual, Movimiento mov, ref int indice)// busca y devuelve el nodo en el que se encuentra 
        {
            if (actual == null)
            {
                return null;
            }
            else 
            {
                bool esta = buscarNodo(actual, mov, ref indice);
                if (esta)
                    return actual;
                else
                    return buscar(actual.ramas[indice],mov, ref indice);
            }
        }

        public void insertar(Movimiento move)//insertar movimiento 
        {
            bool subeArriba = true;
            Movimiento mediana = null ;
            Pagina p, np = null;

            empujar(raiz, move, ref subeArriba, ref mediana, np);
            if (subeArriba)
            {
                p = new Pagina();
                p.cuenta = 1;
                p.movimientos[1] = mediana;
                p.ramas[0] = raiz;
                p.ramas[1] = np;
                raiz = p;
            }
        }

        private void empujar(Pagina actual, Movimiento move, ref bool subearriba, ref Movimiento mediana, Pagina nuevo) 
        {
            int k = 0;
            if (actual == null)
            {
                subearriba = true;
                mediana = move;
                nuevo = null;
            }
            else 
            {
                bool esta = buscarNodo(actual, move, ref k);
                if (esta)
                {
                    // si la clave esta duplicada
                    Console.WriteLine("Clave Duplicada");
                    subearriba = false;
                    return;
                }
                empujar(actual.ramas[k], move,ref subearriba,ref mediana, nuevo );
                if (subearriba)
                {
                    if (actual.nodoLLeno())
                    {
                        dividirNodo(actual , ref mediana, nuevo, k, mediana, nuevo );
                    }
                    else 
                    {
                        subearriba = false;
                        meterHoja(actual, mediana, nuevo, k);
                    }
                }

            }

        }

        private void meterHoja(Pagina actual, Movimiento move, Pagina rd, int k) 
        {
            int i;
            for (i = actual.cuenta; i >= k + 1; i-- )
            {
                actual.movimientos[i + 1] = actual.movimientos[i];
                actual.ramas[i + 1] = actual.ramas[i];
            }
            actual.movimientos[i + 1] = move;
            actual.ramas[i + 1] = rd;
            actual.cuenta++;

        }

        private void dividirNodo(Pagina actual,ref Movimiento mov, Pagina rd, int k,  Movimiento mediana, Pagina nuevo) 
        {
            int i, posMda;
            posMda = (k <= 5/2) ? 5/2: (5/2)+1;//posicion a la mitad
            nuevo = new Pagina();//nuevo nodo pagina
            for (i = posMda + 1; i < 5; i++)
            {
                //es desplazada la mitad derecha al nuevo nodo la clave mediana se queda en el nodo origen
                nuevo.movimientos[i - posMda] = actual.movimientos[i];
                nuevo.ramas[i - posMda] = actual.ramas[i];
            }
            nuevo.cuenta = 4 - posMda; //claves en el nuevo nodo
            actual.cuenta = posMda;//claves en el nodod de origen

            // es insertada la clave y rama en el nodo que le corresponde
            if (k <= 5 / 2)
            {
                meterHoja(actual, mov, rd, k);
            }
            else 
            {
                meterHoja(nuevo, mov, rd, k-posMda);
            }

            //Se extrae la clave mediana del nodo origen
            mediana = actual.movimientos[actual.cuenta];
            // Rama del nuevo nodo es la rama de la mediana
            nuevo.ramas[0] = actual.ramas[actual.cuenta];
            actual.cuenta--; // disminuye ya que se quita la mediana

        }
        public int clave(int fila, string columna, string nivel)
        {
            int c = 0;
            for (int i = 0; i <columna.Length; i++)
                c += columna[i];

            if (nivel.StartsWith("Neosatelite"))
                c += 4;
            else if (nivel.StartsWith("Bombardero") || nivel.StartsWith("Caza") || nivel.StartsWith("Helicóptero"))
                c += 3;
            else if (nivel.StartsWith("Fragata") || nivel.StartsWith("Crucero"))
                c += 2;
            else if (nivel.StartsWith("Submarino"))
                c += 1;

            return c + fila;
        }
    }
}
