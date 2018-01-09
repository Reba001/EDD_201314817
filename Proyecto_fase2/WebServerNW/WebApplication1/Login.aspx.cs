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
        webServiceNW.ProyectoEDD serv1;

        protected void Page_Load(object sender, EventArgs e)
        {
            serv1 = (webServiceNW.ProyectoEDD) Application["WebServer"];
            
            string Nickname = "Many";
            string Contrasenia = "1234abc";
            string Email = "manymontes@live.com";
            bool Conectado = false;
            serv1.setUsuario(Nickname, Contrasenia, Email, Conectado);


        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            String usuario = TextUserInput.Text;
            String contraseña = TextPasswordInput.Text;
            string user = serv1.buscarUsuario(usuario);
            if (user != null)
            {
                if (user.Equals(contraseña))
                {
                    if (usuario == "Many")
                    {
                        Session["usuarioAdmin"] = usuario;
                        serv1.modificarEstad(usuario, true);
                        Response.Redirect("IngresoUsuarios.aspx");
                    }
                    else 
                    {
                        if (Application["usuario1"] != null && Application["usuario2"] != null)
                        {
                            if (usuario.Equals(Application["usuario1"].ToString()))
                            {
                                Session["usuario1"] = usuario;

                                serv1.modificarEstad(usuario, true);
                                Response.Redirect("Cliente.aspx");
                            }
                            else if (usuario.Equals(Application["usuario2"].ToString()))
                            {
                                Session["usuario2"] = usuario;
                                serv1.modificarEstad(usuario, true);
                                Response.Redirect("Cliente2.aspx");
                            }
                            
                        }
                        else 
                        {

                        }

                        
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