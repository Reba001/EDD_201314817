using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WcfServiceLibrary2
{
    public class Matriz
    {
        ListaEncabezado eColumna;
        ListaEncabezado eFila;
        public Matriz()
        {
            this.eColumna = new ListaEncabezado();
            this.eFila = new ListaEncabezado();
        }

        public void insertar(int fila, string columna, int nivel, Pieza pieza)
        {
            Nodo nuevo = new Nodo(fila, columna, nivel, pieza);
            // fila
            Encabezado efila = this.eFila.getEncabezado(fila);
            if (efila == null)// si fila es null por lo tanto no hay ningun dato de fila
            {
                efila = new Encabezado(fila);
                Encabezado enivel = enivel = new Encabezado(nivel);
                enivel.Acceso = nuevo;
                efila.ListAcceso.insertarF(enivel);
                eFila.insertarF(efila);
            }
            else 
            {
                Encabezado enivel = efila.ListAcceso.getEncabezado(nivel);
                if (enivel == null)// Si ya tenemos fila pero no tenemos nivel
                {
                 
                    enivel = new Encabezado(nivel);
                    efila.ListAcceso.insertarF(enivel);
                    if (enivel.Siguiente != null && enivel.Siguiente.Acceso.Columna == columna)// si hay mas niveles y los queremos enlazar
                    {
                        nuevo.Adelante = enivel.Siguiente.Acceso;
                        enivel.Siguiente.Acceso.Atras = nuevo;
                           
                    }

                    if (enivel.Anterior != null && enivel.Anterior.Acceso.Columna == columna)// si hay mas niveles y los queremos enlazar
                    {
                        nuevo.Atras = enivel.Anterior.Acceso;
                        enivel.Anterior.Acceso.Adelante = nuevo;
                    }

                    enivel.Acceso = nuevo;
                }
                else // si ya esta creado el nivel
                {
                    int comparacion = String.Compare(nuevo.Columna, enivel.Acceso.Columna);
                    if (comparacion < 0) // si el dato que queremos insertar lo insertamos al principio
                    {
                        nuevo.Siguiente = enivel.Acceso;
                        enivel.Acceso.Anterior = nuevo;
                        if (enivel.Siguiente != null && enivel.Siguiente.Acceso.Columna == columna)// si hay mas nodos en nivel entonces verificamossi es la misma columna
                        {
                            nuevo.Adelante = enivel.Siguiente.Acceso;
                            enivel.Siguiente.Acceso.Atras = nuevo;

                        }

                        if (enivel.Anterior != null && enivel.Anterior.Acceso.Columna == columna)// si hay mas nodos en nivel verificamos si es la misma columna
                        {
                            nuevo.Atras = enivel.Anterior.Acceso;
                            enivel.Anterior.Acceso.Adelante = nuevo;
                        }

                        enivel.Acceso = nuevo;
                    }
                    else 
                    {
                        Nodo actual = enivel.Acceso;
                        while(actual.Siguiente != null)
                        {
                            if (String.Compare(nuevo.Columna, actual.Siguiente.Columna) < 0)// si el nodo hay que insertarlo al medio 
                            {
                                nuevo.Siguiente = actual.Siguiente;
                                actual.Siguiente.Anterior = nuevo;
                                nuevo.Anterior = actual;
                                actual.Siguiente = nuevo;
                                if(enivel.Siguiente != null)
                                {
                                    Nodo actualS = enivel.Siguiente.Acceso;
                                    while(actualS != null)
                                    {
                                        if (actualS.Columna == columna)
                                        {
                                            nuevo.Adelante = actualS;
                                            actualS.Atras = nuevo;
                                            break;
                                        }
                                        actualS = actualS.Siguiente;
                                    }
                                }

                                if (enivel.Anterior != null)
                                {
                                    Nodo actualI = enivel.Anterior.Acceso;
                                    while(actualI != null)
                                    {
                                        if (actualI.Columna == columna)
                                        {
                                            nuevo.Atras = actualI;
                                            actualI.Adelante = nuevo;
                                            break;
                                        }
                                        actualI = actualI.Siguiente;
                                    }
                                }
                                
                                break;
                            }
                            actual = actual.Siguiente;
                        }

                        if(actual.Siguiente == null)// insercion de ultimo
                        {
                            actual.Siguiente = nuevo;
                            nuevo.Anterior = actual;
                            if (enivel.Siguiente != null)
                            {
                                Nodo actualS = enivel.Siguiente.Acceso;
                                while (actualS != null)
                                {
                                    if (actualS.Columna == columna)
                                    {
                                        nuevo.Adelante = actualS;
                                        actualS.Atras = nuevo;
                                        break;
                                    }
                                    actualS = actualS.Siguiente;
                                }
                            }

                            if (enivel.Anterior != null)
                            {
                                Nodo actualI = enivel.Anterior.Acceso;
                                while (actualI != null)
                                {
                                    if (actualI.Columna == columna)
                                    {
                                        nuevo.Atras = actualI;
                                        actualI.Adelante = nuevo;
                                        break;
                                    }
                                    actualI = actualI.Siguiente;
                                }
                            }
                        }// fin insercion de ultimo

                    }
                    
                }

            }
           
            //fin fila
            //INSERCION DE COLUMNA
            Encabezado ecolumna = this.eColumna.getEncabezado(columna);
            
            if (ecolumna == null)
            {
                ecolumna = new Encabezado(columna);
                Encabezado enivel = new Encabezado(nivel);
                ecolumna.ListAcceso.insertarF(enivel);
                eColumna.insertarC(ecolumna);
                enivel.Acceso = nuevo;
                
            }
            else 
            {
                Encabezado enivel = ecolumna.ListAcceso.getEncabezado(nivel);
                if (enivel == null)
                {
                    enivel = new Encabezado(nivel);
                    ecolumna.ListAcceso.insertarF(enivel);
                    enivel.Acceso = nuevo;
                }
                else 
                {

                    if (fila < enivel.Acceso.Fila) // insercion al inicio
                    {
                        nuevo.Abajo = enivel.Acceso;
                        enivel.Acceso.Arriba = nuevo;
                        enivel.Acceso = nuevo;
                    }
                    else 
                    {
                        Nodo actual = enivel.Acceso; // insercion al medio 
                        while(actual.Abajo != null)
                        {
                            if (fila < actual.Abajo.Fila)
                            {
                                nuevo.Abajo = actual.Abajo;
                                actual.Abajo.Arriba = nuevo;
                                nuevo.Arriba = actual;
                                actual.Abajo = nuevo;
                                break;
                            }
                            actual = actual.Abajo;
                        }

                        if (actual.Abajo == null) // insercion de columna al final
                        {
                            actual.Abajo = nuevo;
                            nuevo.Arriba = actual;
                        }

                    }
                }
            }
            //FIN INSERCION DE COLUMNA
        }

        public string recorrerFilas() 
        {
            StringBuilder recorrido = new StringBuilder();
            recorrido.Append("Recorrido por Fila \n");
            Encabezado efila = this.eFila.Cabeza;
            while(efila != null){
                recorrido.Append("\t Fila: " + efila.Id.ToString()+ "\n");
                Encabezado enivel = efila.ListAcceso.Cabeza;
                while(enivel != null)
                {
                    recorrido.Append("\t\t nivel: " + enivel.Id.ToString() + "\n");
                    Nodo actual = enivel.Acceso;
                    while(actual != null)
                    {
                        recorrido.Append(actual.Pieza.toString()+" -> ");
                        actual = actual.Siguiente;
                    }
                    enivel = enivel.Siguiente;
                }
                efila = efila.Siguiente;
            }
            return recorrido.ToString();
 
        }

        public string recorridoColumna() 
        {
            StringBuilder recorrido = new StringBuilder();
            recorrido.Append("Recorrido por Columna \n");
            Encabezado ecolumna = this.eColumna.Cabeza;
            while(ecolumna != null)
            {
                recorrido.Append("\t Columna: "+ ecolumna.Identificador);
                Encabezado enivel = ecolumna.ListAcceso.Cabeza;
                while(enivel != null)
                {
                    recorrido.Append("\t\t nivel: "+enivel.Id.ToString() + "\n");
                    Nodo actual = enivel.Acceso;
                    while(actual != null)
                    {
                        recorrido.Append(actual.Pieza.toString()+ " -> ");
                        actual = actual.Abajo;
                    }
                    enivel = enivel.Siguiente;
                }
                ecolumna = ecolumna.Siguiente;
            }
            return recorrido.ToString();
        }
        public void grafoJugador1(string jugador, int nivel) {
            string grafo = "digraph g{\n";
            grafo += "\t node[shape=box, style=filled, color=Gray95];\n";
            grafo += "\t edge[color = black];\n";
            grafo += "\t rankdir = UD; \n";
            grafo += "\t\t"+escrituraJugador1(jugador, nivel);
            grafo += "}\n";
            System.IO.File.WriteAllText("C:\\CSVFile\\Imagen\\Matriz" + jugador+nivel.ToString() + ".dot", grafo);
            ProcessStartInfo starInfo = new ProcessStartInfo("dot.exe");
            starInfo.Arguments = "-Tjpg C:\\CSVFile\\Imagen\\Matriz"+jugador + nivel.ToString() + ".dot -o C:\\CSVFile\\Imagen\\Matriz"+jugador + nivel.ToString() + ".jpg";
            Process.Start(starInfo);


        }

        public string escrituraJugador1(string jugador, int nivel) {
            StringBuilder recorrido = new StringBuilder();
            StringBuilder columnaGrafo = new StringBuilder();
            StringBuilder columnaFila = new StringBuilder();
            StringBuilder cabezaColumna = new StringBuilder();
            StringBuilder cabezaFila = new StringBuilder();
            StringBuilder piezas = new StringBuilder();
            StringBuilder filcol = new StringBuilder();

            // graficamos columnas
            Encabezado ecolumna = this.eColumna.Cabeza;
            columnaGrafo.Append("{rank=min;\"Tablero" + nivel.ToString() + "\";");
            while (ecolumna != null)
            {
                columnaGrafo.Append("\"" + ecolumna.Identificador + "\";");
                Encabezado enivel = ecolumna.ListAcceso.getEncabezado(nivel);
                Nodo acceso = enivel.Acceso;
                while(acceso != null)
                {
                    if (acceso.Pieza.Nickname == jugador)
                    {
                        cabezaColumna.Append("\"" + ecolumna.Identificador + "\" -> \"" + acceso.Pieza.toString() + "\";\n");
                        break;
                    }
                    acceso = acceso.Abajo;
                }
                
                ecolumna = ecolumna.Siguiente;
            }
            columnaGrafo.Append("};\n");
            // fin grafica columnas
            // graficamos filas
            Encabezado efila = this.eFila.Cabeza;
            while (efila != null)
            {
                columnaFila.Append("{rank=same;\"" + efila.Id.ToString() + "\";");
                Encabezado enivel = efila.ListAcceso.getEncabezado(nivel);
                if (enivel != null)
                {
                    
                    Nodo actual = enivel.Acceso;
                    int contador = 0;
                    while (actual != null)
                    {
                        if (actual.Pieza.Nickname == jugador && contador < 1)
                        {
                            cabezaFila.Append("\"" + efila.Id.ToString() + "\" -> \"" + actual.Pieza.toString() + "\";\n");
                            contador++;
                        } 
                            

                        columnaFila.Append("\"" + actual.Pieza.toString() + "\";");
                        actual = actual.Siguiente;
                        
                    }
                }
                columnaFila.Append("};\n");
                efila = efila.Siguiente;
            }
            // fin grafica fila

            //INICIO GRAFICA DE PIEZAS
            Encabezado efila2 = this.eFila.Cabeza;
            while (efila2 != null)
            {
                Encabezado enivel = efila2.ListAcceso.getEncabezado(nivel);
                if (enivel != null && enivel.Acceso != null)
                {
                    Nodo actual = enivel.Acceso;
                    while (actual.Siguiente != null)
                    {
                        if ((actual.Anterior != null) && (actual.Anterior.Pieza.Nickname == jugador) && (actual.Pieza.Nickname == jugador)) 
                            piezas.Append("\"" + actual.Pieza.toString() + "\" -> \"" + actual.Anterior.Pieza.toString() + "\"[constraint=false];\n");

                        
                        if (actual.Siguiente.Pieza.Nickname == jugador && actual.Pieza.Nickname == jugador)
                            piezas.Append("\"" + actual.Pieza.toString() + "\" -> \"" + actual.Siguiente.Pieza.toString() + "\"[constraint=false];\n");
                        actual = actual.Siguiente;
                    }
                    if (actual.Siguiente == null && actual.Pieza.Nickname == jugador)
                    {
                        if (actual.Anterior != null && actual.Anterior.Pieza.Nickname == jugador) piezas.Append("\"" + actual.Pieza.toString() + "\" -> \"" + actual.Anterior.Pieza.toString() + "\"[constraint=false];\n");
                    }
                }

                efila2 = efila2.Siguiente;

            }

            Encabezado eColumna2 = this.eColumna.Cabeza;
            while (eColumna2 != null)
            {
                Encabezado enivel = eColumna2.ListAcceso.getEncabezado(nivel);
                if (enivel != null && enivel.Acceso != null)
                {
                    Nodo actual = enivel.Acceso;
                    while (actual.Abajo != null)
                    {
                        if (actual.Arriba != null && actual.Pieza.Nickname == jugador && actual.Arriba.Pieza.Nickname== jugador) 
                            piezas.Append("\"" + actual.Pieza.toString() + "\" -> \"" + actual.Arriba.Pieza.toString() + "\";\n");
                        
                        if (actual.Pieza.Nickname == jugador && actual.Siguiente.Pieza.Nickname == jugador)
                            piezas.Append("\"" + actual.Pieza.toString() + "\" -> \"" + actual.Abajo.Pieza.toString() + "\";\n");
                        actual = actual.Abajo;
                    }
                    if (actual.Abajo == null && actual.Abajo.Pieza.Nickname == jugador)
                    {
                        if (actual.Arriba != null && actual.Arriba.Pieza.Nickname == jugador && actual.Pieza.Nickname == jugador) piezas.Append("\"" + actual.Pieza.toString() + "\" -> \"" + actual.Arriba.Pieza.toString() + "\";\n");
                    }
                }
                eColumna2 = eColumna2.Siguiente;
            }
            // FIN GRAFICA DE PIEZAS
            //INICIO GRAFICA DE LAS FILAS Y COLUMNAS
            Encabezado eFila3 = this.eFila.Cabeza;

            if (eFila3 != null)
            {
                filcol.Append("\"Tablero" + nivel.ToString() + "\" -> \"" + eFila3.Id.ToString() + "\"[rankdir=UD];\n");
                filcol.Append("subgraph cluster0{\n");
                while (eFila3.Siguiente != null)
                {
                    if (eFila3.Anterior != null) filcol.Append("\"" + eFila3.Id.ToString() + "\" -> \"" + eFila3.Anterior.Id.ToString() + "\"[rankdir=UD];\n");

                    filcol.Append("\"" + eFila3.Id.ToString() + "\" -> \"" + eFila3.Siguiente.Id.ToString() + "\"[rankdir=UD];\n");
                    eFila3 = eFila3.Siguiente;
                }

                if (eFila3.Siguiente == null)
                {
                    if (eFila3.Anterior != null) filcol.Append("\"" + eFila3.Id.ToString() + "\" -> \"" + eFila3.Anterior.Id.ToString() + "\"[rankdir=UD];\n");
                }

                filcol.Append("}\n");
            }


            Encabezado eColumna3 = this.eColumna.Cabeza;
            if (eColumna3 != null)
            {
                filcol.Append("\"Tablero" + nivel.ToString() + "\" -> \"" + eColumna3.Identificador + "\";\n");
                while (eColumna3.Siguiente != null)
                {
                    if (eColumna3.Anterior != null) filcol.Append("\"" + eColumna3.Identificador + "\" -> \"" + eColumna3.Anterior.Identificador + "\";\n");

                    filcol.Append("\"" + eColumna3.Identificador + "\" -> \"" + eColumna3.Siguiente.Identificador + "\";\n");
                    eColumna3 = eColumna3.Siguiente;
                }
                if (eColumna3.Siguiente == null)
                {
                    if (eColumna3.Anterior != null) filcol.Append("\"" + eColumna3.Identificador + "\" -> \"" + eColumna3.Anterior.Identificador + "\";\n");

                }
            }


            //FIN GRAFICA DE LAS FILAS Y COLUMNAS

            recorrido.Append(columnaGrafo);
            recorrido.Append(columnaFila);
            recorrido.Append(cabezaColumna);
            recorrido.Append(cabezaFila);
            recorrido.Append(piezas);
            recorrido.Append(filcol);
            return recorrido.ToString();
        }
        public void grafoNivel(int nivel, string Destruccion) {

            string grafo = "digraph g{\n";
            grafo += "\t node[shape=box, style=filled, color=Gray95];\n";
            grafo += "\t edge[color = black];\n";
            grafo += "\t rankdir = UD; \n";
            if (this.eFila != null && this.eColumna != null)
                grafo += escrituraGrafoNivel1(nivel);
            else
                grafo += "\"Tablero"+nivel.ToString()+"\"; \n";
            grafo += "}\n";
            System.IO.File.WriteAllText("C:\\CSVFile\\Imagen\\Matriz"+Destruccion+nivel.ToString()+".dot", grafo);
            ProcessStartInfo starInfo = new ProcessStartInfo("dot.exe");
            starInfo.Arguments = "-Tjpg C:\\CSVFile\\Imagen\\Matriz"+Destruccion + nivel.ToString() + ".dot -o C:\\CSVFile\\Imagen\\Matriz"+Destruccion+nivel.ToString()+".jpg";
            Process.Start(starInfo);

        }

        public string escrituraGrafoNivel1(int nivel) 
        {
            StringBuilder recorrido = new StringBuilder();
            StringBuilder columnaGrafo = new StringBuilder();
            StringBuilder columnaFila = new StringBuilder();
            StringBuilder cabezaColumna = new StringBuilder();
            StringBuilder cabezaFila = new StringBuilder();
            StringBuilder piezas = new StringBuilder();
            StringBuilder filcol = new StringBuilder();
            
            // graficamos columnas
            Encabezado ecolumna = this.eColumna.Cabeza;
            columnaGrafo.Append("{rank=min;\"Tablero"+nivel.ToString()+"\";");
            while (ecolumna != null)
            {
                columnaGrafo.Append("\""+ecolumna.Identificador+"\";");
                Encabezado enivel = ecolumna.ListAcceso.getEncabezado(nivel);
                if (enivel != null && enivel.Acceso != null)
                {
                    cabezaColumna.Append("\""+ecolumna.Identificador+"\" -> \""+enivel.Acceso.Pieza.toString()+"\";\n");// para hacer la relacion de punteros entre las cabeceras y las piezas
                }
                ecolumna = ecolumna.Siguiente;
            }
            columnaGrafo.Append("};\n");
            // fin grafica columnas
            // graficamos filas
            Encabezado efila = this.eFila.Cabeza;
            while(efila != null)
            {
                columnaFila.Append("{rank=same;\""+efila.Id.ToString()+"\";");
                Encabezado enivel = efila.ListAcceso.getEncabezado(nivel);
                if (enivel != null)
                {
                    if (enivel.Acceso != null)
                        cabezaFila.Append("\""+efila.Id.ToString()+"\" -> \""+enivel.Acceso.Pieza.toString()+"\";\n");
                    
                    Nodo actual = enivel.Acceso;
                    
                    while (actual != null)
                    {
                        columnaFila.Append("\""+actual.Pieza.toString()+"\";");
                        actual = actual.Siguiente;
                    }
                }
                columnaFila.Append("};\n");
                efila = efila.Siguiente;
            }
            // fin grafica fila
            
            //INICIO GRAFICA DE PIEZAS
            Encabezado efila2 = this.eFila.Cabeza;
            while (efila2 != null)
            {
                Encabezado enivel = efila2.ListAcceso.getEncabezado(nivel);
                if (enivel != null && enivel.Acceso != null)
                {
                    Nodo actual = enivel.Acceso;
                    while (actual.Siguiente != null)
                    {
                        if (actual.Anterior != null)
                            piezas.Append("\"" + actual.Pieza.toString() + "\" -> \"" + actual.Anterior.Pieza.toString() + "\"[constraint=false];\n");

                        piezas.Append("\"" + actual.Pieza.toString() + "\" -> \"" + actual.Siguiente.Pieza.toString() + "\"[constraint=false];\n");
                        actual = actual.Siguiente;
                    }
                    if (actual.Siguiente == null)
                    {
                        if (actual.Anterior != null) piezas.Append("\"" + actual.Pieza.toString() + "\" -> \"" + actual.Anterior.Pieza.toString() + "\"[constraint=false];\n");
                    }
                }

                efila2 = efila2.Siguiente;
                
            }

            Encabezado eColumna2 = this.eColumna.Cabeza;
            while(eColumna2 != null)
            {
                Encabezado enivel = eColumna2.ListAcceso.getEncabezado(nivel);
                if (enivel != null && enivel.Acceso != null)
                {
                    Nodo actual = enivel.Acceso;
                    while(actual.Abajo != null)
                    {
                        if (actual.Arriba != null) piezas.Append("\""+actual.Pieza.toString()+ "\" -> \""+ actual.Arriba.Pieza.toString()+ "\";\n");
                        piezas.Append("\"" + actual.Pieza.toString() + "\" -> \"" + actual.Abajo.Pieza.toString() + "\";\n");
                        actual = actual.Abajo;
                    }
                    if (actual.Abajo == null){
                        if (actual.Arriba != null) piezas.Append("\"" + actual.Pieza.toString() + "\" -> \"" + actual.Arriba.Pieza.toString() + "\";\n");
                    }
                }
                eColumna2 = eColumna2.Siguiente;
            }
            // FIN GRAFICA DE PIEZAS
            //INICIO GRAFICA DE LAS FILAS Y COLUMNAS
            Encabezado eFila3 = this.eFila.Cabeza;
            
            if (eFila3 != null){
                filcol.Append("\"Tablero"+nivel.ToString()+"\" -> \""+eFila3.Id.ToString()+"\"[rankdir=UD];\n");
                filcol.Append("subgraph cluster0{\n");
                while (eFila3.Siguiente != null)
                {
                    if (eFila3.Anterior != null) filcol.Append("\"" + eFila3.Id.ToString() + "\" -> \"" + eFila3.Anterior.Id.ToString() + "\"[rankdir=UD];\n");

                    filcol.Append("\"" + eFila3.Id.ToString() + "\" -> \"" + eFila3.Siguiente.Id.ToString() + "\"[rankdir=UD];\n");
                    eFila3 = eFila3.Siguiente;
                }

                if (eFila3.Siguiente == null)
                {
                    if (eFila3.Anterior != null) filcol.Append("\"" + eFila3.Id.ToString() + "\" -> \"" + eFila3.Anterior.Id.ToString() + "\"[rankdir=UD];\n");
                }

                filcol.Append("}\n");
            }
            

            Encabezado eColumna3 = this.eColumna.Cabeza;
            if (eColumna3 != null)
            {
                filcol.Append("\"Tablero" + nivel.ToString() + "\" -> \"" + eColumna3.Identificador + "\";\n");
                while (eColumna3.Siguiente != null)
                {
                    if (eColumna3.Anterior != null) filcol.Append("\"" + eColumna3.Identificador + "\" -> \"" + eColumna3.Anterior.Identificador + "\";\n");

                    filcol.Append("\"" + eColumna3.Identificador + "\" -> \"" + eColumna3.Siguiente.Identificador + "\";\n");
                    eColumna3 = eColumna3.Siguiente;
                }
                if (eColumna3.Siguiente == null)
                {
                    if (eColumna3.Anterior != null) filcol.Append("\"" + eColumna3.Identificador + "\" -> \"" + eColumna3.Anterior.Identificador + "\";\n");

                }
            }
            
            
            //FIN GRAFICA DE LAS FILAS Y COLUMNAS

            recorrido.Append(columnaGrafo);
            recorrido.Append(columnaFila);
            recorrido.Append(cabezaColumna);
            recorrido.Append(cabezaFila);
            recorrido.Append(piezas);
            recorrido.Append(filcol);
            return recorrido.ToString();
        }
        public void eliminarPieza(int fila , string columna , int nivel) 
        {
            Encabezado efila = this.eFila.getEncabezado(fila);
            Encabezado ecolumna = this.eColumna.getEncabezado(columna);
            // if si fila es econtrada
            if (efila != null && ecolumna != null && ecolumna.ListAcceso.Cabeza != null && efila.ListAcceso.Cabeza != null)
            {
                Encabezado enivelF = efila.ListAcceso.getEncabezado(nivel);
                Encabezado enivelC = ecolumna.ListAcceso.getEncabezado(nivel);
                if (enivelF != null && enivelC != null && enivelC.Acceso != null && enivelF.Acceso != null )
                {
                    //iniicio en nodo en acceso a elimina
                    if (enivelF.Acceso.Columna == columna && enivelC.Acceso.Fila == fila)
                    {
                        Nodo auxC = enivelC.Acceso;
                        Nodo auxF = enivelF.Acceso;
                        if (enivelF.Siguiente != null && enivelF.Siguiente.Acceso != null)
                        {
                            if (enivelF.Anterior != null && enivelF.Anterior.Acceso != null)
                            {
                                enivelF.Acceso.Adelante.Atras = enivelF.Acceso.Atras;
                                enivelF.Acceso.Atras.Adelante = enivelF.Acceso.Adelante;

                            }
                            else
                            {
                                enivelF.Acceso.Adelante.Atras = null;
                            }
                        }
                        else
                        {
                            if (enivelF.Anterior != null && enivelF.Anterior.Acceso != null)
                            {
                                enivelF.Acceso.Atras.Adelante = null;
                            }
                        }

                        if (enivelF.Acceso.Siguiente == null && enivelC.Acceso.Abajo == null)
                        {
                            enivelF.Acceso = null;
                            enivelC.Acceso = null;
                            efila.ListAcceso.eliminar(nivel);
                            ecolumna.ListAcceso.eliminar(nivel);
                            if (efila.ListAcceso.Cabeza == null)
                            {
                                this.eFila.eliminar(fila);
                            }

                            if (ecolumna.ListAcceso.Cabeza == null)
                            {
                                this.eColumna.eliminar(columna);
                            }
                        }
                        else if (enivelF.Acceso.Siguiente == null && enivelC.Acceso.Abajo != null)
                        {
                            enivelC.Acceso = enivelC.Acceso.Abajo;
                            enivelF.Acceso = null;
                            efila.ListAcceso.eliminar(nivel);
                            if (efila.ListAcceso.Cabeza == null)
                            {
                                this.eFila.eliminar(fila);
                            }
                        }
                        else if (enivelC.Acceso.Abajo == null && enivelF.Acceso.Siguiente != null)
                        {
                            enivelF.Acceso = enivelF.Acceso.Siguiente;
                            enivelC.Acceso = null;
                            ecolumna.ListAcceso.eliminar(nivel);
                            if (ecolumna.ListAcceso.Cabeza == null)
                            {
                                this.eColumna.eliminar(columna);
                            }
                        }
                        else
                        {
                            enivelF.Acceso = enivelF.Acceso.Siguiente;
                            enivelC.Acceso = enivelC.Acceso.Abajo;
                        }

                        auxF = null;
                        auxC = null;

                        //end if accesos fila y columna
                    }
                    else 
                    {

                        if (enivelF.Acceso.Columna == columna)
                        {
                            if (enivelF.Siguiente != null && enivelF.Siguiente.Acceso != null)
                            {
                                if (enivelF.Anterior != null && enivelF.Anterior.Acceso != null)
                                {
                                    enivelF.Acceso.Adelante.Atras = enivelF.Acceso.Atras;
                                    enivelF.Acceso.Atras.Adelante = enivelF.Acceso.Adelante;

                                }
                                else
                                {
                                    enivelF.Acceso.Adelante.Atras = null;
                                }
                            }
                            else
                            {
                                if (enivelF.Anterior != null && enivelF.Anterior.Acceso != null)
                                {
                                    enivelF.Acceso.Atras.Adelante = null;
                                }
                            }

                            if (enivelF.Acceso.Siguiente == null)
                            {
                                enivelF.Acceso = null;
                                efila.ListAcceso.eliminar(nivel);
                                if (efila.ListAcceso.Cabeza == null)
                                {
                                    this.eFila.eliminar(fila);
                                }
                            }
                            else
                            {
                                enivelF.Acceso = enivelF.Acceso.Siguiente;
                                enivelF.Acceso.Anterior = null;
                            }
                        }
                        else 
                        {
                            Nodo actualI = null;
                            if (enivelF.Anterior != null){
                                actualI = enivelF.Anterior.Acceso;
                            }
                            Nodo actualS = null;
                            if (enivelF.Siguiente != null){
                                actualS = enivelF.Siguiente.Acceso;
                            }
                            Nodo actual = enivelF.Acceso;

                            while(actual != null)
                            {
                                if (actual.Columna == columna)
                                {
                                    if (actual.Siguiente != null)
                                    {
                                        actual.Siguiente.Anterior = actual.Anterior;
                                        actual.Anterior.Siguiente = actual.Siguiente;
                                        while (actualI != null)
                                        {
                                            if (actualI.Columna == columna)
                                            {
                                                if (actual.Adelante != null)
                                                {
                                                    actualI.Adelante = actual.Adelante;
                                                    actual.Adelante.Atras = actualI;
                                                }
                                                else 
                                                {
                                                    actualI.Adelante = null;
                                                }
                                                break;
                                            }
                                            actualI = actualI.Siguiente;
                                        }

                                        while(actualS != null)
                                        {
                                            if (actualS.Columna == columna)
                                            {
                                                if (actual.Atras != null)
                                                {
                                                    actualS.Atras = actual.Atras;
                                                    actualS.Atras.Adelante = actualS;
                                                }
                                                else 
                                                {
                                                    actualS.Atras = null;
                                                }
                                                break;
                                            }
                                            actualS = actualS.Siguiente;
                                        }
                                        
                                        break;
                                    }
                                    else 
                                    {
                                        actual.Anterior.Siguiente = null;
                                        while (actualI != null)
                                        {
                                            if (actualI.Columna == columna)
                                            {
                                                if (actual.Adelante != null)
                                                {
                                                    actualI.Adelante = actual.Adelante;
                                                    actual.Adelante.Atras = actualI;
                                                }
                                                else
                                                {
                                                    actualI.Adelante = null;
                                                }
                                                break;
                                            }
                                            actualI = actualI.Siguiente;
                                        }

                                        while (actualS != null)
                                        {
                                            if (actualS.Columna == columna)
                                            {
                                                if (actual.Atras != null)
                                                {
                                                    actualS.Atras = actual.Atras;
                                                    actualS.Atras.Adelante = actualS;
                                                }
                                                else
                                                {
                                                    actualS.Atras = null;
                                                }
                                                break;
                                            }
                                            actualS = actualS.Siguiente;
                                        }
                                        
                                        break;
                                    }
                                }
                                actual = actual.Siguiente;
                            }
                            actual = null;
                        }
                        

                        if (enivelC.Acceso.Fila == fila)
                        {

                            if (enivelC.Acceso.Abajo == null)
                            {
                                enivelC.Acceso = null;
                                ecolumna.ListAcceso.eliminar(nivel);
                                if (ecolumna.ListAcceso.Cabeza == null)
                                {
                                    this.eColumna.eliminar(columna);
                                }

                            }
                            else
                            {
                                enivelC.Acceso = enivelC.Acceso.Abajo;
                                enivelC.Acceso.Arriba = null;
                            }
                        }
                        else 
                        {
                            Nodo actual = enivelC.Acceso;
                            while(actual != null)
                            {
                                if (actual.Fila == fila)
                                {
                                    if (actual.Abajo != null)
                                    {
                                        actual.Abajo.Arriba = actual.Arriba;
                                        actual.Arriba.Abajo = actual.Abajo;
                                        actual = null;
                                        break;
                                    }
                                    else 
                                    {
                                        actual.Arriba.Abajo = null;
                                        actual = null;
                                        break;
                                    }

                                }
                                actual = actual.Abajo;
                            }
                        }
                    }
                    // fin nodo acceso a eliminar
                }
            }
            // fin if fila y columna encontrada
        }

        public Pieza buscarPieza(int fila, string columna, int nivel) 
        {
            Encabezado efila = this.eFila.Cabeza; 
            while (efila != null)
            {
                if (efila.Id == fila){
                    Encabezado enivel = efila.ListAcceso.getEncabezado(nivel);
                    if (enivel != null )
                    {
                        Nodo acceso = enivel.Acceso;
                        while (acceso != null)
                        {
                            if (acceso.Columna.Equals( columna))
                                return acceso.Pieza;

                            acceso = acceso.Siguiente;
                        }
                    }
                    return null;
                }
                efila = efila.Siguiente;
            }
            return null;
        }

        public bool MatrizVacia() 
        {
            return eFila == null && eColumna == null;
        }
        public void eliminarMatriz()
        {
            this.eColumna = null;
            this.eFila = null;
        }

        public void iniciarMatriz() 
        {
            this.eColumna = new ListaEncabezado();
            this.eFila = new ListaEncabezado();
        }

        public void grafoTablero1(int nivel) {
        }

        public string escrituraTablero(int nivel) {
            StringBuilder cabezerasC = new StringBuilder();
            
            Encabezado ecolumna = this.eColumna.Cabeza;
            cabezerasC.Append("<tr><td><b>Tablero"+nivel.ToString()+"</b></td>");
            while(ecolumna != null)
            {
                cabezerasC.Append("<td><b>"+ecolumna.Identificador+"</b></td>");
                
                ecolumna = ecolumna.Siguiente;
            }
            cabezerasC.Append("</tr>\n");

            Encabezado efila = this.eFila.Cabeza;
            
            while(efila != null)
            {
                cabezerasC.Append("<tr><td><b>"+efila.Id.ToString()+"</b></td>");
                Encabezado enivel = efila.ListAcceso.getEncabezado(nivel);
                cabezerasC.Append("<td>");
                if (enivel != null && enivel.Acceso != null){
                    Nodo acceso = enivel.Acceso;
                    while(acceso != null)
                    {
                        cabezerasC.Append(acceso.Pieza.toString());
                        acceso = acceso.Siguiente;
                    }
                }
                cabezerasC.Append("</td>");
                cabezerasC.Append("</tr>\n");
                efila = efila.Siguiente;
            }
            return cabezerasC.ToString();
        }
    }

}
