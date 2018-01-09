using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WebServerNW
{
   
    public class Usuario
    {
        string nickname;
        string contrasenia;
        string email;
        bool conectado;

        public Usuario(string nickname, string contrasenia, string email, bool conectado){
            this.nickname = nickname;
            this.contrasenia = contrasenia;
            this.email = email;
            this.conectado = conectado;
        }

   
        public bool Conectado
        {
            get { return conectado; }
            set { conectado = value; }
        }
   
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
   
        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }
   
        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }


        public string toString() {
            string cadena = "Nickname: " + nickname + "\n" +
                "Contraseña: " + contrasenia + "\n" +
                "E-mail: " + email + "\n"+
                "Conectado: "+ conectado.ToString()
                ;
            
            return cadena;
        }
    }
}
