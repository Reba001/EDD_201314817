using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace WebServerNW
{
    public class Juego
    {
        string nicknameO;
        int desplegadas;
        int destruidas;
        int sobrevivientes;
        bool ganar;


        public Juego(string nicknameO,  int destruidas) {
            this.nicknameO = nicknameO;
            this.destruidas = destruidas;
        }

 
        public int Sobrevivientes
        {
            get { return sobrevivientes; }
            set { sobrevivientes = value; }
        }

 
        public int Destruidas
        {
            get { return destruidas; }
            set { destruidas = value; }
        }

 
        public int Desplegadas
        {
            get { return desplegadas; }
            set { desplegadas = value; }
        }


 
        public bool Ganar
        {
            get { return ganar; }
            set { ganar = value; }
        }

 
        public string NicknameO
        {
            get { return nicknameO; }
            set { nicknameO = value; }
        }

        
        public string toString() {
            return "Nickname Oponente: " + nicknameO + "\n"+ 
                "Destruidas: "+ destruidas.ToString()+ "\n"+
                "Desplegadas: "+ desplegadas.ToString()+ "\n"+
                "Sobrevivientes: "+ sobrevivientes.ToString()+ "\n"+
                "Ganada: " + ganar.ToString();
        }

    }
}
