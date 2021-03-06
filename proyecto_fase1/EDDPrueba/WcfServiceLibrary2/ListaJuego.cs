﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WcfServiceLibrary2
{
    public class ListaJuego
    {
        public NodoL primero;
        public NodoL ultimo;
        public int tamanio;
        public int contadorganar;
        public int contadoDest;
        public int contadoUni;
        public ListaJuego() {
            this.primero = null;
            this.ultimo = null;
            this.tamanio = 0;
            this.contadorganar = 0;
            this.contadoDest = 0;
            this.contadoUni = 0;

        }

        public void insertar(Juego juego) 
        {
            NodoL nuevo = new NodoL(juego);
            if (juego.Ganar == true)
                ++contadorganar;
            this.contadoDest += juego.Destruidas;
            this.contadoUni += juego.Desplegadas;

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

        public void insertarMayor(string nickname, int numero) 
        {
            Juego gamenew = new Juego(nickname, numero);
            NodoL nuevo = new NodoL(gamenew);
            if (this.primero == null)
            {
                this.primero = nuevo;
                this.ultimo = nuevo;
            }
            else 
            {
                if (nuevo.Juego.Destruidas > this.primero.Juego.Destruidas)
                {
                    nuevo.Siguiente = this.primero;
                    this.primero.Anterior = nuevo;
                    this.primero = nuevo;
                }
                else 
                {
                    NodoL actual = this.primero;
                    while (actual.Siguiente != null)
                    {
                        if (nuevo.Juego.Destruidas > actual.Siguiente.Juego.Destruidas)
                        {
                            nuevo.Siguiente = actual.Siguiente;
                            actual.Siguiente.Anterior = nuevo;
                            nuevo.Anterior = actual;
                            actual.Siguiente = nuevo;
                            break;
                        }
                        actual = actual.Siguiente;
                    }
                    if (actual.Siguiente == null)
                    {
                        actual.Siguiente = nuevo;
                        nuevo.Anterior = actual;
                    }
                }
            }

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
        public Juego getJuego(string nickO) 
        {
            if (this.primero != null)
            {
                NodoL actual = this.primero;
                while(actual != null)
                {
                    if (actual.Juego.NicknameO == nickO)
                        return actual.Juego;
                    
                    actual = actual.Siguiente;
                }
            }
            return null;
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


        public String grafo() {
            string graph = "";
            if (this.primero != null){
                NodoL aux = this.primero;
                while(aux.Siguiente != null){
                    if(aux.Anterior != null){
                        graph += "\t\t\""+aux.Juego.toString()+ "\" -> \""+aux.Anterior.Juego.toString()+"\";\n";
                    }
                    graph += "\t\t\""+aux.Juego.toString() + "\" -> \"" + aux.Siguiente.Juego.toString() + "\";\n";
                    aux = aux.Siguiente;
                }
                return graph;
            }
            return graph;
        }

        public void grafoTopWin(string titulo) 
        {
            StringBuilder grafo = new StringBuilder();
            grafo.Append("digraph g{\n");
            grafo.Append("\t node[shape=plaintext];\n");
            grafo.Append("\t a[label=<<table border=\"0\" cellborder=\"1\" cellspacing=\"0\">\n");
            grafo.Append("\t \t \t <tr><td><b>TOP JUGADORES CON MAS "+titulo+"</b></td></tr>\n");
            grafo.Append("\t \t \t <tr><td><b>Nickname</b></td><td><b>"+titulo+"</b></td></tr>\n");
            int contador = 0;
            NodoL actual = this.primero;
            while (actual != null && contador < 10){
                grafo.Append("\t \t \t <tr><td>"+actual.Juego.NicknameO+"</td>\n");
                grafo.Append("\t \t \t     <td>" + actual.Juego.Destruidas.ToString() + "</td></tr>\n");
                contador++;
                actual = actual.Siguiente;
            }
            grafo.Append("\t </table>>];\n}\n");
            System.IO.File.WriteAllText("C:\\CSVFile\\Imagen\\"+titulo+".dot", grafo.ToString());
            ProcessStartInfo starInfo = new ProcessStartInfo("dot.exe");
            starInfo.Arguments = "-Tjpg C:\\CSVFile\\Imagen\\"+titulo+".dot -o C:\\CSVFile\\Imagen\\"+titulo+".jpg";
            Process.Start(starInfo);

        }


        
    }
}
