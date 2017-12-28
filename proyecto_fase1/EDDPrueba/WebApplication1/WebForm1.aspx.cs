using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        webServicePrueba.Service1Client servicio;
        string dir = "C:\\CSVFile\\";
        protected void Page_Load(object sender, EventArgs e)
        {
            servicio = (webServicePrueba.Service1Client)Application["WebServer"];
            servicio.grafoTopWin();
            servicio.grafoTopDest();
            if (File.Exists(Server.MapPath("/images") + "\\GANADAS.jpg"))
                File.Delete(Server.MapPath("/images") + "\\GANADAS.jpg");

            if (File.Exists(Server.MapPath("/images") + "\\DESTRUIDAS.jpg"))
                File.Delete(Server.MapPath("/images") + "\\DESTRUIDAS.jpg");

            if (Directory.Exists("C:\\CSVFile\\Imagen\\"))
            {
                if (File.Exists("C:\\CSVFile\\Imagen\\GANADAS.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\GANADAS.jpg", Server.MapPath("/images") + "\\GANADAS.jpg");
                    this.Image9.ImageUrl = "/images/GANADAS.jpg";
                }


                if (File.Exists("C:\\CSVFile\\Imagen\\DESTRUIDAS.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\DESTRUIDAS.jpg", Server.MapPath("/images") + "\\DESTRUIDAS.jpg");
                    this.Image1.ImageUrl = "/images/DESTRUIDAS.jpg";
                }
            }



        }
    }
}