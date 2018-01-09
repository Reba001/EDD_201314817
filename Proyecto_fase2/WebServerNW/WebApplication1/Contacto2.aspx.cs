using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;

namespace WebApplication1
{
    public partial class Contacto2 : System.Web.UI.Page
    {
        webServiceNW.ProyectoEDD servicio = new webServiceNW.ProyectoEDD();
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = Session["usuario2"].ToString();
            if (File.Exists(Server.MapPath("/images") + "\\Contactos2.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Contactos2.jpg");
            this.Image10.ImageUrl = null;
            crearGrafo(servicio.grafoContactos(usuario), "Contactos2");
            if (File.Exists("C:\\CSVFile\\Imagen\\Contactos2.jpg"))
            {
                File.Copy("C:\\CSVFile\\Imagen\\Contactos2.jpg", Server.MapPath("/images") + "\\Contactos2.jpg");
                this.Image10.ImageUrl = "images/Contactos2";
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
            if (nickname != String.Empty && contrasenia != String.Empty && correo != String.Empty)
            {
                string user = Session["usuario2"].ToString();
                servicio.insertarContacto(user, nickname, contrasenia, correo);
                Label1.Text = "Insertado";
                if (File.Exists(Server.MapPath("/images") + "\\Contactos2.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Contactos2.jpg");
                this.Image10.ImageUrl = null;
                crearGrafo(servicio.grafoContactos(user), "Contactos2");
                if (File.Exists("C:\\CSVFile\\Imagen\\Contactos2.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Contactos2.jpg", Server.MapPath("/images") + "\\Contactos2.jpg");
                    this.Image10.ImageUrl = "images/Contactos2";
                }

            }
            else
                Label1.Text = "Ingrese un nuevo usuario";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (txtNickname.Text != String.Empty)
            {
                string contacto = txtNickname.Text;
                string ususario = Session["usuario2"].ToString();
                servicio.eliminarContacto(ususario, contacto);
                Label1.Text = "Elimnado";
                if (File.Exists(Server.MapPath("/images") + "\\Contactos2.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Contactos2.jpg");
                this.Image10.ImageUrl = null;
                crearGrafo(servicio.grafoContactos(ususario), "Contactos2");
                if (File.Exists("C:\\CSVFile\\Imagen\\Contactos2.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Contactos2.jpg", Server.MapPath("/images") + "\\Contactos2.jpg");
                    this.Image10.ImageUrl = "images/Contactos2";
                }
            }
            else 
            {
                Label1.Text = "Ingrese un contacto";
            }
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string user = Session["usuario2"].ToString();
            //implementar modificar contacto
            if (txtNickname.Text != String.Empty && txtContrasenia.Text != String.Empty)
            {
                string nickname = txtNickname.Text;
                string contrasenia = txtContrasenia.Text;
                servicio.modificarContraseniaContacto(user , nickname, contrasenia);
                Label2.Text = "Modificado";
            }

            if (txtNickname.Text != String.Empty && txtCorreo.Text != String.Empty)
            {
                string nickname = txtNickname.Text;
                string correo = txtCorreo.Text;
                servicio.modificarContraseniaContacto(user, nickname, correo);
                Label3.Text = "Modificado";
            }
            if (File.Exists(Server.MapPath("/images") + "\\Contactos2.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Contactos2.jpg");
            this.Image10.ImageUrl = null;
            crearGrafo(servicio.grafoContactos(user), "Contactos2");
            if (File.Exists("C:\\CSVFile\\Imagen\\Contactos2.jpg"))
            {
                File.Copy("C:\\CSVFile\\Imagen\\Contactos2.jpg", Server.MapPath("/images") + "\\Contactos2.jpg");
                this.Image10.ImageUrl = "images/Contactos2";
            }
        }
    }
}