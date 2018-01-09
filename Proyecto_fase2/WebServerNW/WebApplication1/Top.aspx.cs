using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace WebApplication1
{
    public partial class Top : System.Web.UI.Page
    {

        webServiceNW.ProyectoEDD servicio = new webServiceNW.ProyectoEDD();
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = Session["usuario1"].ToString();
            if (File.Exists(Server.MapPath("/images") + "\\Contactos1.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Contactos1.jpg");
            this.Image10.ImageUrl = null;
            crearGrafo(servicio.grafoContactos(usuario), "Contactos1");
            if (File.Exists("C:\\CSVFile\\Imagen\\Contactos1.jpg"))
            {
                File.Copy("C:\\CSVFile\\Imagen\\Contactos1.jpg", Server.MapPath("/images") + "\\Contactos1.jpg");
                this.Image10.ImageUrl = "images/Contactos1.jpg";
            }
            
        }

        private void crearGrafo(string grafo, string nombre)
        {
            try
            {
                System.IO.File.WriteAllText("C:\\CSVFile\\Imagen\\" + nombre + ".dot", grafo);
                ProcessStartInfo starInfo = new ProcessStartInfo("dot.exe");
                starInfo.Arguments = "-Tjpg C:\\CSVFile\\Imagen\\" + nombre + ".dot -o C:\\CSVFile\\Imagen\\" + nombre + ".jpg";
                Process.Start(starInfo);
            }
            catch
            {
                String popupScript = "<script language='JavaScript'> alert('Error'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string nickname = txtNickname.Text;
            string contrasenia = txtContrasenia.Text;
            string correo = txtCorreo.Text;
            if (nickname != "" && contrasenia != "" && correo != "")
            {
                string user = Session["usuario1"].ToString();
                servicio.insertarContacto(user, nickname, contrasenia, correo);
                Label1.Text = "Insertado";
                if (File.Exists(Server.MapPath("/images") + "\\Contactos1.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Contactos1.jpg");
                this.Image10.ImageUrl = null;
                crearGrafo(servicio.grafoContactos(user), "Contactos1");
                if (File.Exists("C:\\CSVFile\\Imagen\\Contactos1.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Contactos1.jpg", Server.MapPath("/images") + "\\Contactos1.jpg");
                    this.Image10.ImageUrl = "images/Contactos1.jpg";
                }
            
            }
            else
                Label1.Text = "Ingrese un nuevo usuario";
            
        }


        protected void Button5_Click(object sender, EventArgs e)
        {
            if (txtNickname.Text != "")
            {
                string user = Session["usuario1"].ToString();
                string contacto = txtNickname.Text;
                servicio.eliminarContacto(user, contacto);
                Label1.Text = "Eliminado";
                if (File.Exists(Server.MapPath("/images") + "\\Contactos1.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Contactos1.jpg");
                this.Image10.ImageUrl = null;
                crearGrafo(servicio.grafoContactos(user), "Contactos1");
                if (File.Exists("C:\\CSVFile\\Imagen\\Contactos1.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Contactos1.jpg", Server.MapPath("/images") + "\\Contactos1.jpg");
                    this.Image10.ImageUrl = "images/Contactos1.jpg";
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string user = Session["usuario1"].ToString();
            if (txtNickname.Text !="" && txtContrasenia.Text != "")
            {
                
                string contrasenia = txtContrasenia.Text;
                string nick = txtNickname.Text;
                servicio.modificarContraseniaContacto(user, nick, contrasenia);
                Label2.Text = "Modificado";
            }

            if (txtNickname.Text != "" && txtCorreo.Text != "")
            {
                string correo = txtCorreo.Text;
                string nick = txtNickname.Text;
                servicio.modificarCorreoContacto(user, nick, correo);
                Label3.Text = "Modificado";
            }
            if (File.Exists(Server.MapPath("/images") + "\\Contactos1.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Contactos1.jpg");
            this.Image10.ImageUrl = null;
            crearGrafo(servicio.grafoContactos(user), "Contactos1");
            if (File.Exists("C:\\CSVFile\\Imagen\\Contactos1.jpg"))
            {
                File.Copy("C:\\CSVFile\\Imagen\\Contactos1.jpg", Server.MapPath("/images") + "\\Contactos1.jpg");
                this.Image10.ImageUrl = "images/Contactos1.jpg";
            }
        }
    }
}