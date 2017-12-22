using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        webServicePrueba.Service1Client servicio;
        protected void Page_Load(object sender, EventArgs e)
        {
            servicio = (webServicePrueba.Service1Client)Application["WebServer"];
            webServicePrueba.Usuario usuario1 = new webServicePrueba.Usuario();
            usuario1.Nickname = "Reba";
            usuario1.Contrasenia = "26653754Zu";
            usuario1.Email = "aaperez.tomas@gmail.com";
            usuario1.Conectado = false;
            servicio.setUsuario(usuario1);

            webServicePrueba.Usuario usuario2 = new webServicePrueba.Usuario();
            usuario2.Nickname = "Alan";
            usuario2.Contrasenia = "26653754Zu";
            usuario2.Email = "aaperez.tomas@gmail.com";
            usuario2.Conectado = false;
            servicio.setUsuario(usuario2);

            webServicePrueba.Usuario usuario3 = new webServicePrueba.Usuario();
            usuario3.Nickname = "Malacates";
            usuario3.Contrasenia = "26653754Zu";
            usuario3.Email = "aaperez.tomas@gmail.com";
            usuario3.Conectado = false;
            servicio.setUsuario(usuario3);

            webServicePrueba.Usuario usuario4 = new webServicePrueba.Usuario();
            usuario4.Nickname = "Zury";
            usuario4.Contrasenia = "26653754Zu";
            usuario4.Email = "aaperez.tomas@gmail.com";
            usuario4.Conectado = false;
            servicio.setUsuario(usuario4);
            servicio.invocarGrafo();
            Label1.Text = servicio.getUsuarios();



        }
    }
}