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
            int c1 = move.Key;
            bool encontrado = false;
            if (c1 < actual.movimientos[1].Key)
            {
                encontrado = false;
                k = 0;
            }
            else 
            {
                k = actual.cuenta;
                while ((c1 < actual.movimientos[k].Key) && (k > 1))
                    k--;
                encontrado = (c1 == actual.movimientos[k].Key);
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
            
            Movimiento mediana = null ;
            Pagina np = null;

            bool subeArriba = empujar(raiz, move, ref mediana, ref np);
            if (subeArriba)
            {
                Pagina p = new Pagina();
                p.cuenta = 1;
                p.movimientos[1] = mediana;
                p.ramas[0] = raiz;
                p.ramas[1] = np;
                raiz = p;
            }
        }

        private bool empujar(Pagina actual, Movimiento move, ref Movimiento mediana, ref Pagina nuevo) 
        {
            int k = 0;
            bool subearriba = false;
            if (actual == null)
            {
                // envia hacia arriba la clave move y su rama derecha null
                // para que se inserte en la pagina padre
                subearriba = true;
                mediana = move;
                nuevo = null;
            }
            else 
            {
                bool esta = buscarNodo(actual, move, ref k);
                if (esta)
                    Console.Write("Clave duplicada");

                subearriba = empujar(actual.ramas[k], move, ref mediana, ref nuevo);
                if (subearriba)
                {
                    if (actual.nodoLLeno())
                    {
                        dividirNodo(actual , ref mediana, ref nuevo, k);
                    }
                    else 
                    {
                        subearriba = false;
                        meterHoja(actual, mediana, nuevo, k);
                    }
                }

            }
            return subearriba;

        }

        private void meterHoja(Pagina actual, Movimiento move, Pagina rd, int k) 
        {
            // desplaza a la derecha los elementos para poder insertar uno
            
            for (int i = actual.cuenta; i >= k + 1; i-- )
            {
                actual.movimientos[i + 1] = actual.movimientos[i];
                actual.ramas[i + 1] = actual.ramas[i];
            }
            //por la clave y la rama derecha en la posicion k+1
            actual.movimientos[k + 1] = move;
            actual.ramas[k + 1] = rd;
            actual.cuenta++;
        }

        private void dividirNodo(Pagina actual, ref Movimiento mediana,ref  Pagina nuevo, int pos ) 
        {
            int i, posMda, k;
            Pagina nuevapag;
            k = pos; //posicion clave mediana
            posMda = (k <= (5/2)) ? 5/2 :(5/2) + 1;
            nuevapag = new Pagina();
            for (i = posMda + 1; i < 5;i++ )
            {
                //desplaza la mitad derecha a la nueva pagina, mediana se queda en pagina aactual
                nuevapag.movimientos[i - posMda] = actual.movimientos[i];
                nuevapag.ramas[i - posMda] = actual.ramas[i];
            }
            nuevapag.cuenta = 4 - posMda;//claves de nueva pagina
            actual.cuenta = posMda; //claves en la pagina de origen
            //inserta la clave y rama en la pagina que le corresponde
            if (k <= 5 / 2)
            {
                meterHoja(actual, mediana, nuevo, pos);
            }
            else 
            {
                pos = k-posMda;
                meterHoja(nuevapag, mediana, nuevo, pos);
            }
            // extrae clave mediana de la pagina origen
            mediana = actual.movimientos[actual.cuenta];
            //rama 0 del nuevo nodo es la rama de la mediana
            nuevapag.ramas[0] = actual.ramas[actual.cuenta];
            actual.cuenta = actual.cuenta - 1;//se quita la mediana
            nuevo = nuevapag;//devuelve la página
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
