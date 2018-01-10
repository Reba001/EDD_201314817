using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WebServerNW
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

        

        public bool piezasDestruidas(string nickname)
        {
            Encabezado efila = this.eFila.Cabeza; 
            while (efila != null)
            {
                //if (efila.Id == fila){
                    Encabezado enivel = efila.ListAcceso.Cabeza;
                    while (enivel != null )
                    {
                        Nodo acceso = enivel.Acceso;
                        while (acceso != null)
                        {
                            if (acceso.Pieza.Nickname.Equals(nickname))
                                return true;

                            acceso = acceso.Siguiente;
                        }
                        enivel = enivel.Siguiente;
                    }
                //}
                efila = efila.Siguiente;
            }
            //return null;
            return false;
        }
        public bool setVida(int fila, string columna, int nivel, float vida) 
        {
            Pieza pieza = this.buscarPieza(fila, columna, nivel);
            if (pieza != null)
            {
                pieza.Vida = vida;
                return true;
            }
            return false;
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
        public string grafoNivel(int nivel, string Destruccion) {

            string grafo = "digraph g{\n";
            grafo += "\t node[shape=box, style=filled, color=Gray95];\n";
            grafo += "\t edge[color = black];\n";
            grafo += "\t rankdir = UD; \n";
            if (this.eFila != null && this.eColumna != null)
                grafo += escrituraGrafoNivel1(nivel);
            else
                grafo += "\"Tablero"+nivel.ToString()+"\"; \n";
            grafo += "}\n";
            return grafo;

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
        // Metodo pendiente para despues de atacar

        public int contarPNick(string nickname) 
        {
            int contador = 0;
            Encabezado efila = this.eFila.Cabeza;
            while (efila != null)
            {
                Encabezado enivel = efila.ListAcceso.Cabeza;
                while (enivel != null)
                {
                    Nodo acceso = enivel.Acceso;
                    while (acceso != null)
                    {
                        if (acceso.Pieza.Nickname == nickname)
                            contador++;
                        acceso = acceso.Siguiente;
                    }
                    enivel = enivel.Siguiente;
                }
                efila = efila.Siguiente;
            }
            return contador;
        }
        public string nivelesAtacados(int fila, string columna, int nivel) 
        {
            Nodo pieza = buscarPiezaNodo(fila, columna, nivel);
            string niveles = "";
            int lvl = 0;
            while (pieza != null)
            {
                if (lvl != 0)
                    niveles += pieza.Nivel.ToString() + ",";
                lvl++;
                pieza = pieza.Atras;
            }
            return niveles;
        }
        public int nivelAtacado(int fila, string columna , int nivel) 
        {
            Nodo pieza = buscarPiezaNodo(fila, columna, nivel);
            int level = 0;
            if (pieza.Atras != null)
            {
                if (pieza.Atras.Pieza.Unidad.StartsWith("Bombardero") || pieza.Atras.Pieza.Unidad.StartsWith("Caza") || pieza.Atras.Pieza.Unidad.StartsWith("Helicóptero"))
                    level = 3;
                else if (pieza.Atras.Pieza.Unidad.StartsWith("Fragata") || pieza.Atras.Pieza.Unidad.StartsWith("Crucero"))
                    level = 2;
                else if (pieza.Atras.Pieza.Unidad.StartsWith("Submarino"))
                    level = 1;
            }
            return level;
        }
        public void eliminarPieza(int fila , string columna , int nivel) 
        {
            Encabezado efila = this.eFila.getEncabezado(fila);
            Encabezado ecolumna = this.eColumna.getEncabezado(columna);
            // if si fila es econtrada
            if (efila != null)
            {
                Encabezado enivelF = efila.ListAcceso.getEncabezado(nivel);
                if (enivelF != null)
                {
                    Nodo Acceso = enivelF.Acceso;
                    if (Acceso != null)
                    {
                        if (Acceso.Columna == columna)// eliminacion si se encuentra en el primer dato acceso
                        {
                            if (enivelF.Siguiente != null && enivelF.Anterior != null)
                            {
                                enivelF.Siguiente.Acceso.Atras = enivelF.Anterior.Acceso;
                                enivelF.Anterior.Acceso.Adelante = enivelF.Siguiente.Acceso;
                            }

                            if (enivelF.Siguiente == null && enivelF.Anterior != null)
                                enivelF.Anterior.Acceso.Adelante = null;

                            if (enivelF.Anterior == null && enivelF.Siguiente != null)
                                enivelF.Siguiente.Acceso.Atras = null;

                            if (Acceso.Siguiente != null)
                            {
                                enivelF.Acceso = Acceso.Siguiente;
                                enivelF.Acceso.Anterior = null;
                                Acceso = null;
                            }
                            else
                            {
                                Acceso = null;
                                enivelF.Acceso = null;
                                efila.ListAcceso.eliminar(nivel);
                                if (efila.ListAcceso.Cabeza == null)
                                {
                                    this.eFila.eliminar(fila);
                                }
                            }
                        }
                        else// de lo contrario se encuentra en algun lugar de la  matriz 
                        {
                            while (Acceso != null)
                            {
                                if (Acceso.Columna == columna)
                                {
                                    if (enivelF.Siguiente != null && enivelF.Anterior != null)
                                    {
                                        Nodo nivelS = enivelF.Siguiente.Acceso;
                                        Nodo nivelA = enivelF.Anterior.Acceso;
                                        while (nivelS != null)
                                        {
                                            if (nivelS.Columna == columna)
                                            {
                                                while (nivelA.Siguiente != null)
                                                {
                                                    if (nivelA.Columna == columna)
                                                    {
                                                        nivelA.Adelante = nivelS;
                                                        nivelS.Atras = nivelA;
                                                        break;
                                                    }
                                                    nivelA = nivelA.Siguiente;
                                                }

                                                if (nivelA.Columna == columna )
                                                {
                                                    nivelA.Adelante = nivelS;
                                                    nivelS.Atras = nivelA;
                                                }
                                                else 
                                                {
                                                    nivelS.Atras = null;
                                                }
                                                break;
                                            }
                                            nivelS = nivelS.Siguiente;
                                        }

                                        while (nivelA != null)
                                        {
                                            if (nivelA.Columna == columna)
                                            {
                                                nivelA.Adelante = null;
                                                break;
                                            }
                                            nivelA = nivelA.Siguiente;
                                        }
                                    }// si siguiente de diferente a null y anterior diferente anull

                                    if (enivelF.Siguiente != null && enivelF.Anterior == null)
                                    {
                                        Nodo nivelS = enivelF.Siguiente.Acceso;
                                        while(nivelS != null)
                                        {
                                            if (nivelS.Columna == columna)
                                            {
                                                nivelS.Atras = null;
                                                break;
                                            }
                                            nivelS = nivelS.Siguiente;
                                        }
                                    }

                                    if (enivelF.Anterior != null && enivelF.Siguiente == null)
                                    {
                                        Nodo nivelA = enivelF.Anterior.Acceso;
                                        while(nivelA != null)
                                        {
                                            if (nivelA.Columna == columna)
                                            {
                                                nivelA.Adelante = null;
                                                break;
                                            }
                                            nivelA = nivelA.Siguiente;
                                        }
                                    }

                                    if (Acceso.Siguiente == null)
                                    {
                                        Acceso.Anterior.Siguiente = null;
                                        Acceso = null;
                                        break;
                                    }
                                    else 
                                    {
                                        Acceso.Anterior.Siguiente = Acceso.Siguiente;
                                        Acceso.Siguiente.Anterior = Acceso.Anterior;
                                        Acceso = null;
                                        break;
                                    }

                                }
                                Acceso = Acceso.Siguiente;
                            }
                        }//fin eliminacion fila
                    }// fin acceso
                }//fin nivel de fila
            }//fin fila

            if (ecolumna != null)
            {
                Encabezado enivelC = ecolumna.ListAcceso.getEncabezado(nivel);
                if (enivelC != null)
                {
                    Nodo acceso = enivelC.Acceso;
                    if (acceso != null)
                    {
                        if (acceso.Fila == fila)
                        {
                            if (acceso.Abajo != null)
                            {
                                enivelC.Acceso = acceso.Abajo;
                                enivelC.Acceso.Arriba = null;
                                acceso = null;
                            }
                            else
                            {
                                enivelC.Acceso = null;
                                acceso = null;
                                ecolumna.ListAcceso.eliminar(nivel);
                                if (ecolumna.ListAcceso.Cabeza == null)
                                {
                                    this.eColumna.eliminar(columna);
                                }
                            }
                        }
                        else 
                        {
                            while (acceso != null)
                            {
                                if (acceso.Fila == fila)
                                {
                                    if (acceso.Abajo != null)
                                    {
                                        acceso.Arriba.Abajo = acceso.Abajo;
                                        acceso.Abajo.Arriba = acceso.Arriba;
                                        acceso = null;
                                        break;
                                    }
                                    else 
                                    {
                                        acceso.Arriba.Abajo = null;
                                        acceso = null;
                                        break;
                                    }
                                }
                                acceso = acceso.Abajo;
                            }
                        }
                    }// fin acceso
                }// fin nivel columna
            }// fin columna 
        }

        public Nodo buscarPiezaNodo(int fila, string columna, int nivel) 
        {
            Encabezado efila = this.eFila.Cabeza;
            while (efila != null)
            {
                if (efila.Id == fila)
                {
                    Encabezado enivel = efila.ListAcceso.getEncabezado(nivel);
                    if (enivel != null)
                    {
                        Nodo acceso = enivel.Acceso;
                        while (acceso != null)
                        {
                            if (acceso.Columna.Equals(columna))
                                return acceso;

                            acceso = acceso.Siguiente;
                        }
                    }
                    return null;
                }
                efila = efila.Siguiente;
            }
            return null;

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
