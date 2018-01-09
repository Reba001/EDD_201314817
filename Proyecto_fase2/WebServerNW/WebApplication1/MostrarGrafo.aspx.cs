using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;
using WINGRAPHVIZLib;
using System.Drawing;
namespace WebApplication1
{
    public partial class MostrarGrafo : System.Web.UI.Page
    {

        webServiceNW.ProyectoEDD servicio;
        string dir = "C:\\CSVFile\\";
        protected void Page_Load(object sender, EventArgs e)
        {
            servicio = (webServiceNW.ProyectoEDD) Application["WebServer"];
            //this.crearGrafo(servicio.grafoMatriz(1), "Matriz1");
            //this.crearGrafo(servicio.grafoMatriz(2), "Matriz2");
            //this.crearGrafo(servicio.grafoMatriz(3), "Matriz3");
            //this.crearGrafo(servicio.grafoMatriz(4), "Matriz4");
            //this.crearGrafo(servicio.grafoDestruct(1), "Matrizdestruccion1");
            //this.crearGrafo(servicio.grafoDestruct(2), "Matrizdestruccion2");
            //this.crearGrafo(servicio.grafoDestruct(3), "Matrizdestruccion3");
            //this.crearGrafo(servicio.grafoDestruct(4), "Matrizdestruccion4");
            //this.crearGrafo(servicio.invocarGrafo(), "Arbol");
            //this.crearGrafo(servicio.ArbolEspejo(), "ArbolE");
            if (File.Exists(Server.MapPath("/images") + "\\Matriz1.jpg"))
            
                File.Delete(Server.MapPath("/images") + "\\Matriz1.jpg");
            this.Image1.ImageUrl = null;
            

            if (File.Exists(Server.MapPath("/images") + "\\Matriz2.jpg"))
            
                File.Delete(Server.MapPath("/images") + "\\Matriz2.jpg");
            this.Image2.ImageUrl = null;

            if (File.Exists(Server.MapPath("/images") + "\\Matriz3.jpg"))
            
                File.Delete(Server.MapPath("/images") + "\\Matriz3.jpg");
            this.Image3.ImageUrl = null;

            if (File.Exists(Server.MapPath("/images") + "\\Matriz4.jpg"))
            
                File.Delete(Server.MapPath("/images") + "\\Matriz4.jpg");
            this.Image4.ImageUrl = null;

            if (File.Exists(Server.MapPath("/images") + "\\Matrizdestruccion1.jpg"))
            
                File.Delete(Server.MapPath("/images") + "\\Matrizdestruccion1.jpg");
            this.Image5.ImageUrl = null;

            if (File.Exists(Server.MapPath("/images") + "\\Matrizdestruccion2.jpg"))

                File.Delete(Server.MapPath("/images") + "\\Matrizdestruccion2.jpg");
            this.Image6.ImageUrl = null;

            if (File.Exists(Server.MapPath("/images") + "\\Matrizdestruccion3.jpg"))

                File.Delete(Server.MapPath("/images") + "\\Matrizdestruccion3.jpg");
            this.Image7.ImageUrl = null;

            if (File.Exists(Server.MapPath("/images") + "\\Matrizdestruccion4.jpg"))

                File.Delete(Server.MapPath("/images") + "\\Matrizdestruccion4.jpg");
            this.Image8.ImageUrl = null;

            if (File.Exists(Server.MapPath("/images") + "\\Arbol.jpg"))

                File.Delete(Server.MapPath("/images") + "\\Arbol.jpg");
            this.Image9.ImageUrl = null;

            if (File.Exists(Server.MapPath("/images") + "\\ArbolE.jpg"))

                File.Delete(Server.MapPath("/images") + "\\ArbolE.jpg");
            this.Image10.ImageUrl = null;

            if (File.Exists(Server.MapPath("/images") + "\\ArbolAVL.jpg"))

                File.Delete(Server.MapPath("/images") + "\\ArbolAVL.jpg");
            this.Image11.ImageUrl = null;


            if (Directory.Exists(dir+"\\Imagen"))
            {
                if (File.Exists(dir + "\\Imagen\\Matriz1.jpg")) 
                {
                    File.Copy(dir + "\\Imagen\\Matriz1.jpg", Server.MapPath("/images")+"\\Matriz1.jpg");
                    this.Image1.ImageUrl = "images/Matriz1.jpg";
                }



                if (File.Exists(dir + "\\Imagen\\Matriz2.jpg")) 
                {
                    File.Copy(dir + "\\Imagen\\Matriz2.jpg", Server.MapPath("/images") + "\\Matriz2.jpg");
                    this.Image2.ImageUrl = "images/Matriz2.jpg";
                }

                if (File.Exists(dir + "\\Imagen\\Matriz3.jpg")) 
                {
                    File.Copy(dir + "\\Imagen\\Matriz3.jpg", Server.MapPath("/images") + "\\Matriz3.jpg");
                    this.Image3.ImageUrl = "images/Matriz3.jpg";
                }

                
                if (File.Exists(dir + "\\Imagen\\Matriz4.jpg"))
                {
                    File.Copy(dir + "\\Imagen\\Matriz4.jpg", Server.MapPath("/images") + "\\Matriz4.jpg");
                    this.Image4.ImageUrl = "images/Matriz4.jpg";
                }

                if (File.Exists(dir + "\\Imagen\\Matrizdestruccion1.jpg"))
                {
                    File.Copy(dir + "\\Imagen\\Matrizdestruccion1.jpg", Server.MapPath("/images") + "\\Matrizdestruccion1.jpg");
                    this.Image5.ImageUrl = "images/Matrizdestruccion1.jpg";
                }

                if (File.Exists(dir + "\\Imagen\\Matrizdestruccion2.jpg"))
                {
                    File.Copy(dir + "\\Imagen\\Matrizdestruccion2.jpg", Server.MapPath("/images") + "\\Matrizdestruccion2.jpg");
                    this.Image6.ImageUrl = "images/Matrizdestruccion2.jpg";
                }
                if (File.Exists(dir + "\\Imagen\\Matrizdestruccion3.jpg"))
                {
                    File.Copy(dir + "\\Imagen\\Matrizdestruccion3.jpg", Server.MapPath("/images") + "\\Matrizdestruccion3.jpg");
                    this.Image7.ImageUrl = "images/Matrizdestruccion3.jpg";
                }

                if (File.Exists(dir + "\\Imagen\\Matrizdestruccion4.jpg"))
                {
                    File.Copy(dir + "\\Imagen\\Matrizdestruccion4.jpg", Server.MapPath("/images") + "\\Matrizdestruccion4.jpg");
                    this.Image8.ImageUrl = "images/Matrizdestruccion4.jpg";
                }

                if (File.Exists(dir + "\\Imagen\\Arbol.jpg"))
                {
                    File.Copy(dir + "\\Imagen\\Arbol.jpg", Server.MapPath("/images") + "\\Arbol.jpg");
                    this.Image9.ImageUrl = "images/Arbol.jpg";
                }
                if (File.Exists(dir + "\\Imagen\\ArbolE.jpg"))
                {
                    File.Copy(dir + "\\Imagen\\ArbolE.jpg", Server.MapPath("/images") + "\\ArbolE.jpg");
                    this.Image10.ImageUrl = "images/ArbolE.jpg";
                }
                
                
                
                
            }
                
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        protected void btnGrafousuario_Click(object sender, EventArgs e)
        {

            
        }

        private string obtenerImagen(String nombre) 
        {
            try
            {
                Byte[] imagen = System.IO.File.ReadAllBytes("C:\\CSVFile\\Imagen\\"+nombre+".jpg");
                string i = Convert.ToBase64String(imagen);
                string tipocontenido = "image/jpg";
                return System.String.Format("data{0};base64,{1}", tipocontenido, i);
            }
            catch 
            {
                throw;
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
                System.IO.File.WriteAllText("C:\\CSVFile\\Imagen\\"+nombre+".dot", grafo);
                ProcessStartInfo starInfo = new ProcessStartInfo("dot.exe");
                starInfo.Arguments = "-Tjpg C:\\CSVFile\\Imagen\\"+nombre+".dot -o C:\\CSVFile\\Imagen\\"+nombre+".jpg";
                Process.Start(starInfo);
                

            }
            catch
            {
                String popupScript = "<script language='JavaScript'> alert('Error'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
                
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text != "")
                {
                    crearGrafo(servicio.grafoContactos(txtUsuario.Text), "ArbolAVL");
                    Label8.Text = "Encontrado";
                    if (File.Exists(Server.MapPath("/images") + "\\ArbolAVL.jpg"))
                        File.Delete(Server.MapPath("/images") + "\\ArbolAVL.jpg");
                    this.Image11.ImageUrl = null;
                    if (File.Exists(dir+"\\Imagen\\ArbolAVL.jpg"))
                    {
                        File.Copy(dir + "\\Imagen\\ArbolAVL.jpg", Server.MapPath("/images") + "\\ArbolAVL.jpg");
                        this.Image11.ImageUrl = "images/ArbolAVL.jpg";
                    }
                }
                Label8.Text = "Ingrese un usuario";

            }
            catch 
            {
                Label8.Text = "Error";
            }
        }
    }
}