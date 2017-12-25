using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace WebApplication1
{
    public partial class IngresoUsuarios : System.Web.UI.Page
    {
        webServicePrueba.Service1Client servicio;
        string dir = "C:\\CSVFile\\";
        protected void Page_Load(object sender, EventArgs e)
        {
            servicio = (webServicePrueba.Service1Client)Application["WebServer"];
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            webServicePrueba.Usuario usuario1 = new webServicePrueba.Usuario();
            usuario1.Nickname = txtNickname.Text;
            usuario1.Contrasenia = txtContrasenia.Text;
            usuario1.Email = txtCorreo.Text;
            usuario1.Conectado = false;
            servicio.setUsuario(usuario1);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string filename = FileUpload1.FileName;
            try {
                FileUpload1.SaveAs(dir + filename);
                using(StreamReader readFile = new StreamReader(dir+filename)){
                    string line;
                    string[] row;
                    int contador = 0;
                    while((line = readFile.ReadLine()) != null)
                    {
                        if (contador != 0)
                        {
                            row = line.Split(',');
                            webServicePrueba.Usuario user1 = new webServicePrueba.Usuario();
                            user1.Nickname = row[0];
                            user1.Contrasenia = row[1];
                            user1.Email = row[2];
                            if (row[3] == "1")
                            {
                                user1.Conectado = true;
                            }
                            else
                            {
                                user1.Conectado = false;
                            }
                            Label1.Text = servicio.setUsuario(user1);
                        }
                        contador++;
                    }
                    servicio.invocarGrafo();
                }
                
            }catch{
                String popupScript = "<script language='JavaScript'> alert('Archivo Invalido'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            string filename = FileUpload1.FileName;
            try {
                FileUpload1.SaveAs(dir + filename);
                using(StreamReader readFile = new StreamReader(dir+filename)){
                    string line;
                    string[] row;
                    int contador = 0;

                    while((line = readFile.ReadLine()) != null)
                    {
                        if (contador != 0)
                        {
                            row = line.Split(',');
                            webServicePrueba.Juego game = new webServicePrueba.Juego();
                            game.NicknameO = row[1];
                            game.Desplegadas = Convert.ToInt32(row[2]);
                            game.Sobrevivientes = Convert.ToInt32(row[3]);
                            game.Destruidas = Convert.ToInt32(row[4]);
                            if (row[5] == "1")
                            {
                                game.Ganar = true;
                            }
                            else
                            {
                                game.Ganar = false;
                            }

                            Label2.Text = servicio.insertarJuegos(row[0], game);
                        }
                        contador++;
                        
                    }
                    servicio.invocarGrafo();
                }
                
            }catch{
                String popupScript = "<script language='JavaScript'> alert('Archivo Invalido'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

        }

    }
}