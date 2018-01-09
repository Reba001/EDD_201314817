using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ClienteInicio2 : System.Web.UI.Page
    {
        int limitX;
        int limitY;
        int tipo;
        string tiempo;
        string usuario;
        string usuario2;
        bool jugar = true;
        int hora = 0;
        int minutos = 0;
        int segundos = 0;
        webServiceNW.ProyectoEDD servicio = new webServiceNW.ProyectoEDD();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.limitX = Convert.ToInt32(Application["lC"].ToString());
            this.limitY = Convert.ToInt32(Application["lF"].ToString());
            if ( Session["usuario2"] != null)
            {

                usuario2 = Session["usuario2"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            this.tipo = Convert.ToInt32(Application["tipo"].ToString());
            this.tiempo = Application["tiempo"].ToString();
            hora = int.Parse(Application["hora2"].ToString());
            minutos = int.Parse(Application["minutos2"].ToString());
            segundos = int.Parse(Application["segundos2"].ToString());
            if (tipo == 2 && hora == -1 && minutos == -1 && segundos == -1)
            {
                string[] time = tiempo.Split(':');
                if (time.Length < 3)
                {
                    lblHoras.Text = "00";
                    lblMinutos.Text = time[0];
                    lblSegundos.Text = time[1];

                    hora = 0;
                    minutos = int.Parse(time[0]);
                    segundos = int.Parse(time[1]);

                }
                else
                {
                    lblHoras.Text = time[0];
                    lblMinutos.Text = time[1];
                    lblSegundos.Text = time[2];

                    hora = int.Parse(time[2]);
                    minutos = int.Parse(time[1]);
                    segundos = int.Parse(time[0]);
                }


            }
            else 
            {
                Timer1.Enabled = false;
            }
            

            if (File.Exists(Server.MapPath("/images") + "\\Matriz1cliente.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matriz1cliente.jpg");
            this.Image1.ImageUrl = null;
            if (File.Exists(Server.MapPath("/images") + "\\Matriz2cliente.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matriz2cliente.jpg");
            this.Image2.ImageUrl = null;
            if (File.Exists(Server.MapPath("/images") + "\\Matriz3cliente.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matriz3cliente.jpg");
            this.Image3.ImageUrl = null;
            if (File.Exists(Server.MapPath("/images") + "\\Matriz4cliente.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matriz4cliente.jpg");
            this.Image4.ImageUrl = null;
            if (File.Exists("C:\\CSVFile\\Imagen\\Matriz1cliente.jpg"))
            {
                File.Copy("C:\\CSVFile\\Imagen\\Matriz1cliente.jpg", Server.MapPath("/images") + "\\Matriz1cliente.jpg");
                this.Image1.ImageUrl = "images/Matriz1cliente.jpg";
            }


            if (File.Exists("C:\\CSVFile\\Imagen\\Matriz2cliente.jpg"))
            {
                File.Copy("C:\\CSVFile\\Imagen\\Matriz2cliente.jpg", Server.MapPath("/images") + "\\Matriz2cliente.jpg");
                this.Image2.ImageUrl = "images/Matriz2cliente.jpg";
            }


            if (File.Exists("C:\\CSVFile\\Imagen\\Matriz3cliente.jpg"))
            {
                File.Copy("C:\\CSVFile\\Imagen\\Matriz3cliente.jpg", Server.MapPath("/images") + "\\Matriz3cliente.jpg");
                this.Image3.ImageUrl = "images/Matriz3cliente.jpg";
            }


            if (File.Exists("C:\\CSVFile\\Imagen\\Matriz4cliente.jpg"))
            {
                File.Copy("C:\\CSVFile\\Imagen\\Matriz4cliente.jpg", Server.MapPath("/images") + "\\Matriz4cliente.jpg");
                this.Image4.ImageUrl = "images/Matriz4cliente.jpg";
            }
            

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (minutos == 0 && segundos == 0 && hora == 0)
            {
                jugar = false;
                String popupScript2 = "<script language='JavaScript'> alert('SE TERMINO EL TIEMPO COMIENZE UNA PARTIDA NUEVA'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript2);

                this.Timer1.Enabled = false;

            }
            else
            {
                segundos--;
                if (segundos < 0)
                {
                    minutos--;

                    segundos = 59;

                }

                if (minutos < 0)
                {
                    hora--;
                    minutos = 59;
                }

                Application["hora2"] = hora;
                Application["segundos2"] = segundos;
                Application["minutos2"] = minutos;
                lblHoras.Text = this.appenzero(hora);
                lblMinutos.Text = this.appenzero(minutos);
                lblSegundos.Text = this.appenzero(segundos);

            }
        }
        private string appenzero(double str)
        {
            if (str < 10)
                return "0" + str.ToString();
            else
                return str.ToString();

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                string x = txtPosX.Text;
                int y = int.Parse(txtPosY.Text);
                int yde = int.Parse(txtDestY.Text);
                string xde = txtDestX.Text;
                int nivel = 0;
                string selectNivel = DropDownList1.SelectedItem.ToString();
                if (selectNivel.Equals("Submarino"))
                {
                    nivel = 1;
                }
                else if (selectNivel.Equals("Fragata") || selectNivel.Equals("Crucero"))
                {
                    nivel = 2;
                }
                else if (selectNivel.Equals("Bombardero") || selectNivel.Equals("Caza") || selectNivel.Equals("Helicóptero de combate"))
                {
                    nivel = 3;
                }
                else
                {
                    nivel = 4;
                }

                servicio.eliminarPieza(yde, xde, nivel);
                txtConsola.Text += "Pieza Eliminada de " + xde + " , " + yde.ToString() + " , " + selectNivel+"\n"; 
                this.crearGrafo(servicio.grafoMatriz(1), "Matriz1cliente2");
                this.crearGrafo(servicio.grafoMatriz(2), "Matriz2cliente2");
                this.crearGrafo(servicio.grafoMatriz(3), "Matriz3cliente2");
                this.crearGrafo(servicio.grafoMatriz(4), "Matriz4cliente2");
                //para recargar los grafos 

                if (File.Exists(Server.MapPath("/images") + "\\Matriz1cliente2.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Matriz1cliente2.jpg");
                this.Image1.ImageUrl = null;

                if (File.Exists(Server.MapPath("/images") + "\\Matriz2cliente2.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Matriz2cliente2.jpg");
                this.Image2.ImageUrl = null;

                if (File.Exists(Server.MapPath("/images") + "\\Matriz3cliente2.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Matriz3cliente2.jpg");
                this.Image3.ImageUrl = null;

                if (File.Exists(Server.MapPath("/images") + "\\Matriz4cliente2.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Matriz4cliente2.jpg");
                this.Image4.ImageUrl = null;

                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz1cliente2.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz1cliente2.jpg", Server.MapPath("/images") + "\\Matriz1cliente2.jpg");
                    this.Image1.ImageUrl = "images/Matriz1cliente2.jpg";
                }


                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz2cliente2.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz2cliente2.jpg", Server.MapPath("/images") + "\\Matriz2cliente2.jpg");
                    this.Image2.ImageUrl = "images/Matriz2cliente2.jpg";
                }


                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz3cliente2.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz3cliente2.jpg", Server.MapPath("/images") + "\\Matriz3cliente2.jpg");
                    this.Image3.ImageUrl = "images/Matriz3cliente2.jpg";
                }


                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz4cliente2.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz4cliente2.jpg", Server.MapPath("/images") + "\\Matriz4cliente2.jpg");
                    this.Image4.ImageUrl = "images/Matriz4cliente2.jpg";
                }

            }
            catch 
            {
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                string x = txtPosX.Text;
                int y = int.Parse(txtPosY.Text);
                int yde = int.Parse(txtDestY.Text);
                string xde = txtDestX.Text;
                int nivel = 0;
                string selectNivel = DropDownList1.SelectedItem.ToString();
                if (selectNivel.Equals("Submarino"))
                {
                    nivel = 1;
                }
                else if (selectNivel.Equals("Fragata") || selectNivel.Equals("Crucero"))
                {
                    nivel = 2;
                }
                else if (selectNivel.Equals("Bombardero") || selectNivel.Equals("Caza") || selectNivel.Equals("Helicóptero de combate"))
                {
                    nivel = 3;
                }
                else
                {
                    nivel = 4;
                }

                servicio.moverPieza(x, y, nivel, xde, yde, nivel);
                txtConsola.Text += "Pieza movida de: "+x+", "+y.ToString()+" hacia: "+xde+yde.ToString()+"\n";
                this.crearGrafo(servicio.grafoMatriz(1), "Matriz1cliente2");
                this.crearGrafo(servicio.grafoMatriz(2), "Matriz2cliente2");
                this.crearGrafo(servicio.grafoMatriz(3), "Matriz3cliente2");
                this.crearGrafo(servicio.grafoMatriz(4), "Matriz4cliente2");
                //para recargar los grafos 

                if (File.Exists(Server.MapPath("/images") + "\\Matriz1cliente2.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Matriz1cliente2.jpg");
                this.Image1.ImageUrl = null;

                if (File.Exists(Server.MapPath("/images") + "\\Matriz2cliente2.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Matriz2cliente2.jpg");
                this.Image2.ImageUrl = null;

                if (File.Exists(Server.MapPath("/images") + "\\Matriz3cliente2.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Matriz3cliente2.jpg");
                this.Image3.ImageUrl = null;

                if (File.Exists(Server.MapPath("/images") + "\\Matriz4cliente2.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Matriz4cliente2.jpg");
                this.Image4.ImageUrl = null;

                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz1cliente2.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz1cliente2.jpg", Server.MapPath("/images") + "\\Matriz1cliente2.jpg");
                    this.Image1.ImageUrl = "images/Matriz1cliente2.jpg";
                }


                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz2cliente2.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz2cliente2.jpg", Server.MapPath("/images") + "\\Matriz2cliente2.jpg");
                    this.Image2.ImageUrl = "images/Matriz2cliente2.jpg";
                }


                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz3cliente2.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz3cliente2.jpg", Server.MapPath("/images") + "\\Matriz3cliente2.jpg");
                    this.Image3.ImageUrl = "images/Matriz3cliente2.jpg";
                }


                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz4cliente2.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz4cliente2.jpg", Server.MapPath("/images") + "\\Matriz4cliente2.jpg");
                    this.Image4.ImageUrl = "images/Matriz4cliente2.jpg";
                }

            }
            catch 
            {
            }
        }

        protected void btFinalizar_Click(object sender, EventArgs e)
        {

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

    }
}