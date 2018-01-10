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
    public partial class WebForm1 : System.Web.UI.Page
    {
        webServiceNW.ProyectoEDD servicio;
        string dir = "C:\\CSVFile\\";
        protected void Page_Load(object sender, EventArgs e)
        {
            servicio = (webServiceNW.ProyectoEDD)Application["WebServer"];
            this.crearGrafo(servicio.grafoTopWin(), "GANADAS");
            this.crearGrafo(servicio.grafoTopDest(), "DESTRUIDAS");
            this.crearGrafo(servicio.getTopContactos(), "CONTACTOS");
            this.crearGrafo(servicio.getTopEliminadas(), "ELIMINADAS");
            if (File.Exists(Server.MapPath("/images") + "\\GANADAS.jpg"))
                File.Delete(Server.MapPath("/images") + "\\GANADAS.jpg");
            this.Image1.ImageUrl = null;
            if (File.Exists(Server.MapPath("/images") + "\\DESTRUIDAS.jpg"))
                File.Delete(Server.MapPath("/images") + "\\DESTRUIDAS.jpg");
            this.Image9.ImageUrl = null;
            if (File.Exists(Server.MapPath("/images") + "\\CONTACTOS.jpg"))
                File.Delete(Server.MapPath("/images") + "\\CONTACTOS.jpg");
            this.Image2.ImageUrl = null;

            if (File.Exists(Server.MapPath("/images") + "\\ELIMINADAS.jpg"))
                File.Delete(Server.MapPath("/images") + "\\ELIMINADAS.jpg");
            this.Image3.ImageUrl = null;

            

            if (Directory.Exists("C:\\CSVFile\\Imagen\\"))
            {
                if (File.Exists("C:\\CSVFile\\Imagen\\GANADAS.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\GANADAS.jpg", Server.MapPath("/images") + "\\GANADAS.jpg");
                    this.Image9.ImageUrl = "images/GANADAS.jpg";
                }


                if (File.Exists("C:\\CSVFile\\Imagen\\DESTRUIDAS.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\DESTRUIDAS.jpg", Server.MapPath("/images") + "\\DESTRUIDAS.jpg");
                    this.Image1.ImageUrl = "images/DESTRUIDAS.jpg";
                }

                if (File.Exists("C:\\CSVFile\\Imagen\\CONTACTOS.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\CONTACTOS.jpg", Server.MapPath("/images") + "\\CONTACTOS.jpg");
                    this.Image2.ImageUrl = "images/CONTACTOS.jpg";
                }

                if (File.Exists("C:\\CSVFile\\Imagen\\ELIMINADAS.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\ELIMINADAS.jpg", Server.MapPath("/images") + "\\ELIMINADAS.jpg");
                    this.Image3.ImageUrl = "images/ELIMINADAS.jpg";
                }
            }



        }

        private void crearGrafo(string grafo, string nombre)
        {
            try
            {
                //WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
                //WINGRAPHVIZLib.BinaryImage img = dot.ToJPEG(grafo);
                //byte[] imagebytes = Convert.FromBase64String(img.ToBase64String());

                //MemoryStream ms = new MemoryStream(imagebytes, 0, imagebytes.Length);
                //ms.Write(imagebytes,0,imagebytes.Length);
                //System.Drawing.Image im = System.Drawing.Image.FromStream(ms, true);
                //im.Save(Server.MapPath("/images")+nombre+".jpg" );
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.crearGrafo(servicio.TablaDispersa(), "TablaDispersa");
                if (File.Exists(Server.MapPath("/images") + "\\TablaDispersa.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\TablaDispersa.jpg");
                this.Image4.ImageUrl = null;
                
                if (Directory.Exists("C:\\CSVFile\\Imagen\\"))
                {
                    if (File.Exists("C:\\CSVFile\\Imagen\\TablaDispersa.jpg"))
                    {
                        File.Copy("C:\\CSVFile\\Imagen\\TablaDispersa.jpg", Server.MapPath("/images") + "\\TablaDispersa.jpg");
                        this.Image4.ImageUrl = "/images/TablaDispersa.jpg";
                    }


                }

            }
            catch 
            {
                String popupScript = "<script language='JavaScript'> alert('Error'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);

            }
            
        }
    }
}