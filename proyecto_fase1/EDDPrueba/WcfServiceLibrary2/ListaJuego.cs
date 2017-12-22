using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfServiceLibrary2
{
    public class ListaJuego
    {
        NodoL primero;
        NodoL ultimo;
        int tamanio;

        public ListaJuego() {
            this.primero = null;
            this.ultimo = null;
            this.tamanio = 0;
        }

        public void insertar(Juego juego) 
        {
            NodoL nuevo = new NodoL(juego);
            if (this.primero == null)
            {
                this.primero = nuevo;
                this.ultimo = nuevo;
            }
            else 
            {
                this.ultimo.Siguiente = nuevo;
                nuevo.Anterior = this.ultimo;
                this.ultimo = nuevo;
            }
            tamanio++;
        }

        public bool eliminarJuego(string nicknameO) {
            if (this.primero != null)
            {
                if (this.primero.Juego.NicknameO == nicknameO)
                {
                    if (this.primero.Siguiente == null)
                    {
                        this.primero = null;
                        this.ultimo = null;
                    }
                    else 
                    {
                        this.primero = this.primero.Siguiente;
                        this.primero.Anterior = null;
                    }
                    return true;
                }
                else 
                {
                    NodoL aux = this.primero;
                    while(aux.Siguiente != null){
                        if (aux.Juego.NicknameO == nicknameO){
                            aux.Anterior.Siguiente = aux.Siguiente;
                            aux.Siguiente.Anterior = aux.Anterior;
                            aux = null;
                            return true;
                        }
                        aux = aux.Siguiente;
                    }
                    if(aux.Siguiente == null && aux.Juego.NicknameO == nicknameO){
                        this.ultimo = this.ultimo.Anterior;
                        this.ultimo.Siguiente = null;
                        aux.Anterior = null;
                        aux = null;
                        return true;
                    }

                }

            }
            return false;
        }

        public string getListJuego() {
            if (this.primero != null){
                NodoL aux = this.primero;
                string recorrido = "";
                while(aux != null){
                    recorrido += aux.Juego.toString()+ ",";
                    aux = aux.Siguiente;
                }
                return recorrido;
            }
            return "Vacio";
        }

        


        
    }
}
