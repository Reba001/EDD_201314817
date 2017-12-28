using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class MostrarGrafo : System.Web.UI.Page
    {

        webServicePrueba.Service1Client servicio;
        string dir = "C:\\CSVFile\\";
        protected void Page_Load(object sender, EventArgs e)
        {
            servicio = (webServicePrueba.Service1Client) Application["WebServer"];


            if (File.Exists(Server.MapPath("/images") + "\\Matriz1.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matriz1.jpg");

            if (File.Exists(Server.MapPath("/images") + "\\Matriz2.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matriz2.jpg");

            if (File.Exists(Server.MapPath("/images") + "\\Matriz3.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matriz3.jpg");
            if (File.Exists(Server.MapPath("/images") + "\\Matriz4.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matriz4.jpg");

            if (File.Exists(Server.MapPath("/images") + "\\Matrizdestruccion1.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matrizdestruccion1.jpg");


            if (File.Exists(Server.MapPath("/images") + "\\Matrizdestruccion2.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matrizdestruccion2.jpg");


            if (File.Exists(Server.MapPath("/images") + "\\Matrizdestruccion3.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matrizdestruccion3.jpg");

            if (File.Exists(Server.MapPath("/images") + "\\Matrizdestruccion4.jpg"))
            {
                File.Delete(Server.MapPath("/images") + "\\Matrizdestruccion4.jpg");
                
            }

            if (File.Exists(Server.MapPath("/images") + "\\Arbol.jpg")) {
                File.Delete(Server.MapPath("/images") + "\\Arbol.jpg");
            }


            if (File.Exists(Server.MapPath("/images") + "\\ArbolE.jpg")) {
                File.Delete(Server.MapPath("/images") + "\\ArbolE.jpg");
            }
            

            if (Directory.Exists("C:\\CSVFile\\Imagen"))
            {


                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz1.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz1.jpg", Server.MapPath("/images") + "\\Matriz1.jpg");
                    this.Image1.ImageUrl = "/images/Matriz1.jpg";
                }
                

                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz2.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz2.jpg", Server.MapPath("/images") + "\\Matriz2.jpg");
                    this.Image2.ImageUrl = "/images/Matriz2.jpg";
                }
                

                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz3.jpg"))
                {

                    File.Copy("C:\\CSVFile\\Imagen\\Matriz3.jpg", Server.MapPath("/images") + "\\Matriz3.jpg");
                    this.Image3.ImageUrl = "/images/Matriz3.jpg";
                }
                
                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz4.jpg"))
                {

                    
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz4.jpg", Server.MapPath("/images") + "\\Matriz4.jpg");
                    this.Image4.ImageUrl = "/images/Matriz4.jpg";
                }

                if (File.Exists("C:\\CSVFile\\Imagen\\Matrizdestruccion1.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matrizdestruccion1.jpg", Server.MapPath("/images") + "\\Matrizdestruccion1.jpg");
                    this.Image5.ImageUrl = "/images/Matrizdestruccion1.jpg";
                }
                

                if (File.Exists("C:\\CSVFile\\Imagen\\Matrizdestruccion2.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matrizdestruccion2.jpg", Server.MapPath("/images") + "\\Matrizdestruccion2.jpg");
                    this.Image6.ImageUrl = "/images/Matrizdestruccion2.jpg";
                }
                
                if (File.Exists("C:\\CSVFile\\Imagen\\Matrizdestruccion3.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matrizdestruccion3.jpg", Server.MapPath("/images") + "\\Matrizdestruccion3.jpg");
                    this.Image7.ImageUrl = "/images/Matrizdestruccion3.jpg";
                }

                if (File.Exists("C:\\CSVFile\\Imagen\\Matrizdestruccion4.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matrizdestruccion4.jpg", Server.MapPath("/images") + "\\Matrizdestruccion4.jpg");
                    this.Image8.ImageUrl = "/images/Matrizdestruccion4.jpg";
                }

                if (File.Exists("C:\\CSVFile\\Imagen\\Arbol.jpg"))
                {

                    File.Copy("C:\\CSVFile\\Imagen\\Arbol.jpg", Server.MapPath("/images") + "\\Arbol.jpg");

                    this.Image9.ImageUrl = "/images/Arbol.jpg";       
                }

                if (File.Exists("C:\\CSVFile\\Imagen\\ArbolE.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\ArbolE.jpg", Server.MapPath("/images") + "\\ArbolE.jpg");

                    this.Image10.ImageUrl = "/images/ArbolE.jpg";       
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        protected void btnGrafousuario_Click(object sender, EventArgs e)
        {

            servicio.invocarGrafo();
            servicio.ArbolEspejo();

            if (File.Exists(Server.MapPath("/images") + "\\Arbol.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Arbol.jpg");

            if (File.Exists(Server.MapPath("/images") + "\\ArbolE.jpg"))
                File.Delete(Server.MapPath("/images") + "\\ArbolE.jpg");

            if (File.Exists("C:\\CSVFile\\Imagen\\Arbol.jpg"))
            {
                File.Move("C:\\CSVFile\\Imagen\\Arbol.jpg", Server.MapPath("/images") + "\\Arbol.jpg");
                this.Image9.ImageUrl = "images/Arbol.jpg";
            }

            if (File.Exists("C:\\CSVFile\\Imagen\\ArbolE.jpg"))
            {
                File.Move("C:\\CSVFile\\Imagen\\ArbolE.jpg", Server.MapPath("/images") + "\\ArbolE.jpg");
                this.Image10.ImageUrl = "images/ArbolE.jpg";
            }

        }
    }
}