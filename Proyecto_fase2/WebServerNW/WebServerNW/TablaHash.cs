using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WebServerNW
{
    public class TablaHash
    {

        NodoHash tabla;
        int tamanio;
        public TablaHash() 
        {
            this.tamanio = 47;
            tabla = new NodoHash(47);
        }

        public bool insertar(Usuario user)
        {
            if (user != null)
            {
                if (tabla.factorCarga < 0.5)
                {
                    int posicion = direccion(user.Nickname);
                    tabla.usuarios[posicion] = user;
                    tabla.elementos++;
                    tabla.factorCarga = (tabla.elementos) / tamanio;
                    return true;
                }
                else
                {
                    NodoHash aux = tabla;
                    tabla = null;
                    int tamaux = tamanio;
                    this.tamanio = tamanio * 2;
                    tabla = new NodoHash(tamanio);
                    for (int i = 0; i < tamaux; i++)
                        insertar(aux.usuarios[i]);

                    return insertar(user);
                }

            }
            return false;
            
        }

        public string grafoTablaHash() 
        {
            StringBuilder grafo = new StringBuilder();
            grafo.Append("digraph g{\n");
            grafo.Append("\t ");
            grafo.Append("\t node[shape=plaintext];\n");
            grafo.Append("\t a[label=<<table border=\"0\" cellborder=\"1\" cellspacing=\"0\">\n");
            grafo.Append("\t \t \t <tr><td><b>TABLA DISPERSA USUARIOS</b></td></tr>\n");
            for (int i = 0; i < tamanio; i++ )
            {
                
                if (tabla.usuarios[i] != null)
                {
                    grafo.Append("\t \t \t <tr><td>");
                    grafo.Append(i.ToString()+" "+tabla.usuarios[i].toString());
                    grafo.Append("</td></tr>\n");
                }
                
            }
            grafo.Append("\t </table>>];\n}\n");
            return grafo.ToString();

        }
        public Usuario buscar(string nickname) 
        {
            int posicion = direccion(nickname);
            Usuario user = tabla.usuarios[posicion];
            return user;
        }

        private int direccion(string nickname) 
        {
            int i = 0;
            int p = Convert.ToInt32(hash(nickname) % tamanio);
            int d = p;
            while (tabla.usuarios[d] != null && String.Compare(tabla.usuarios[d].Nickname, nickname) != 0)
            {
                i++;
                d = p + i * i;
                if (d >= tamanio)
                    d = d % tamanio;
            }

            return d;
        }
        

        private double hash(string nickname) 
        {
            double hashval = 0;
            char [] claves = nickname.ToCharArray();
            for (int i = 0; i < nickname.Length; i++ )
                hashval = hashval * 27 + claves[i];

            return hashval >= 0 ? hashval : -hashval;
        }
    }

}
