using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WcfServiceLibrary2
{
    [DataContract]
    public class Pieza
    {
        private string nickname;
        private string unidad;
        private int alcance;
        private int movimiento;
        private float danio;
        private float vida;

        
        public Pieza(string nickname, string unidad, int alcance, int movimiento, float danio, float vida) {
            this.unidad = unidad;
            this.alcance = alcance;
            this.movimiento = movimiento;
            this.danio = danio;
            this.vida = vida;
            this.nickname = nickname;
        }

        [DataMember]
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        [DataMember]
        public string Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }
        
        [DataMember]
        public int Movimiento
        {
            get { return movimiento; }
            set { movimiento = value; }
        }

        [DataMember]
        public int Alcance
        {
            get { return alcance; }
            set { alcance = value; }
        }

        [DataMember]
        public float Danio
        {
            get { return danio; }
            set { danio = value; }
        }
        
        [DataMember]
        public float Vida
        {
            get { return vida; }
            set { vida = value; }
        }

        public string toString() {
            return 
                "Usuario: "+this.nickname + "\n"+
                "Unidad: "+this.unidad + "\n"+
                "Alcance: "+ this.alcance.ToString()+ "\n"+
                "Movimiento: "+ this.movimiento.ToString()+"\n"+
                "Daño: "+ this.danio.ToString()+"\n"+
                "Vida: "+ this.vida.ToString();
        }

    }
}
