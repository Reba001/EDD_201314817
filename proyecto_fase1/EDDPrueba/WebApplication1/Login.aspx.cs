using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        webServicePrueba.Service1Client serv1;

        protected void Page_Load(object sender, EventArgs e)
        {
            serv1 = (webServicePrueba.Service1Client) Application["WebServer"];
            webServicePrueba.Usuario admin = new webServicePrueba.Usuario();
            admin.Nickname = "Many";
            admin.Contrasenia = "1234abc";
            admin.Email = "manymontes@live.com";
            admin.Conectado = false;
            serv1.setUsuario(admin);


        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            String usuario = TextUserInput.Text;
            String contraseña = TextPasswordInput.Text;
            webServicePrueba.Usuario user = serv1.buscarUsuario(usuario);
            if (user != null)
            {
                if (user.Contrasenia == contraseña)
                {
                    if (usuario == "Many")
                    {
                        Session["usuarioAdmin"] = usuario;
                        serv1.modificarEstad(usuario, true);
                        Response.Redirect("IngresoUsuarios.aspx");
                    }
                    else 
                    {
                    }
                   


                }
                else
                {
                    String popupScript = "<script language='JavaScript'> alert('¡Contraseña Invalida!'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                    TextUserInput.Text = "";
                    TextPasswordInput.Text = "";

                }
            }
            else 
            {
                String popupScript = "<script language='JavaScript'> alert('¡Usuario Invalido!'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
                TextUserInput.Text = "";
                TextPasswordInput.Text = "";
            }


        }

        protected void TextUserInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}