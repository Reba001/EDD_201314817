﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WcfServiceLibrary2
{
    [DataContract]
    public class Parametros
    {

        string usuario1;
        string usuario2;
        int n1;
        int n2;
        int n3;
        int n4; 
        int limitX;
        int limitY;
        int tipo;
        string tiempo;

        public Parametros(string usuario1, string usuario2, int n1, int n2, int n3, int n4, int limitX, int limitY,int tipo, string tiempo)
        {
            this.usuario1 = usuario1;
            this.usuario2 = usuario2;
            this.n1 = n1;
            this.n2 = n2;
            this.n3 = n3;
            this.n4 = n4;
            this.limitX = limitX;
            this.limitY = limitY;
            this.tipo = tipo;
            this.tiempo = tiempo;
        }
        [DataMember]
        public int N2
        {
            get { return n2; }
            set { n2 = value; }
        }
        [DataMember]
        public int N3
        {
            get { return n3; }
            set { n3 = value; }
        }
        
        [DataMember]
        public int N4
        {
            get { return n4; }
            set { n4 = value; }
        }
        
        [DataMember]
        public int LimitX
        {
            get { return limitX; }
            set { limitX = value; }
        }
        
        [DataMember]
        public int LimitY
        {
            get { return limitY; }
            set { limitY = value; }
        }

        [DataMember]
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }


        [DataMember]
        public string Usuario1
        {
            get { return usuario1; }
            set { usuario1 = value; }
        }

        [DataMember]
        public string Usuario2
        {
            get { return usuario2; }
            set { usuario2 = value; }
        }

        [DataMember]
        public int N1
        {
            get { return n1; }
            set { n1 = value; }
        }

        [DataMember]
        public string Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }
    }
}
