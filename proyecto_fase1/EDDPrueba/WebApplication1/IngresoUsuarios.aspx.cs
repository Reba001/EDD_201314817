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
        string dirIm = "C:\\CSVFile\\Imagen\\";
        protected void Page_Load(object sender, EventArgs e)
        {
            servicio = (webServicePrueba.Service1Client)Application["WebServer"];
            
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (!Directory.Exists(dirIm))
            {
                Directory.CreateDirectory(dirIm);
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
                    servicio.ArbolEspejo();
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
                    servicio.ArbolEspejo();
                }
                
            }catch{
                String popupScript = "<script language='JavaScript'> alert('Archivo Invalido'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            string filename = FileUpload1.FileName;

            try
            {
                FileUpload1.SaveAs(dir + filename);
                
                using (StreamReader readFile = new StreamReader(dir + filename))
                {
                    string line;
                    string[] row;
                    int contador = 0;
                    while ((line = readFile.ReadLine()) != null)
                    {
                        if (contador != 0)
                        {
                            row = line.Split(',');
                            webServicePrueba.Pieza pieza = new webServicePrueba.Pieza();
                            if (row[3].StartsWith("Neosatelite"))
                            {
                                pieza.Nickname = row[0];
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 6;
                                pieza.Alcance = 0;
                                pieza.Danio = 2;
                                pieza.Vida = 10;
                                int fila = Convert.ToInt32(row[2]);
                                if(row[4] == "0"){
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 4, pieza);
                                }else if (row[4] == "1"){

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 4, pieza);
                                }

                            }
                            else if (row[3].StartsWith("Bombardero"))
                            {
                                pieza.Nickname = row[0];
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 7;
                                pieza.Alcance = 0;
                                pieza.Danio = 5;
                                pieza.Vida = 10;

                                int fila = Convert.ToInt32(row[2]);
                                if (row[4] == "0")
                                {
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 3, pieza);
                                }
                                else if (row[4] == "1")
                                {

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 3, pieza);
                                }
                            }
                            else if (row[3].StartsWith("Caza"))
                            {
                                pieza.Nickname = row[0];
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 9;
                                pieza.Alcance = 1;
                                pieza.Danio = 2;
                                pieza.Vida = 20;

                                int fila = Convert.ToInt32(row[2]);
                                if (row[4] == "0")
                                {
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 3, pieza);
                                }
                                else if (row[4] == "1")
                                {

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 3, pieza);
                                }
                            }
                            else if (row[3].StartsWith("Helicóptero de combate"))
                            {
                                pieza.Nickname = row[0];
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 9;
                                pieza.Alcance = 1;
                                pieza.Danio = 3;
                                pieza.Vida = 15;

                                int fila = Convert.ToInt32(row[2]);
                                if (row[4] == "0")
                                {
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 3, pieza);
                                }
                                else if (row[4] == "1")
                                {

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 3, pieza);
                                }
                            }
                            else if (row[3].StartsWith("Fragata"))
                            {
                                pieza.Nickname = row[0];
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 5;
                                pieza.Alcance = 6;
                                pieza.Danio = 3;
                                pieza.Vida = 10;

                                int fila = Convert.ToInt32(row[2]);
                                if (row[4] == "0")
                                {
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 2, pieza);
                                }
                                else if (row[4] == "1")
                                {

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 2, pieza);
                                }

                            }
                            else if (row[3].StartsWith("Crucero"))
                            {
                                pieza.Nickname = row[0];
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 6;
                                pieza.Alcance = 1;
                                pieza.Danio = 3;
                                pieza.Vida = 15;

                                int fila = Convert.ToInt32(row[2]);
                                if (row[4] == "0")
                                {
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 2, pieza);
                                }
                                else if (row[4] == "1")
                                {

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 2, pieza);
                                }
                            }
                            else if (row[3].StartsWith("Submarino"))
                            {
                                pieza.Nickname = row[0];
                                pieza.Unidad = row[3];
                                pieza.Movimiento = 5;
                                pieza.Alcance = 1;
                                pieza.Danio = 2;
                                pieza.Vida = 10;

                                int fila = Convert.ToInt32(row[2]);
                                
                                if (row[4] == "0")
                                {
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 1, pieza);
                                }
                                else if (row[4] == "1")
                                {

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 1, pieza);
                                }
                            }
                        }
                        contador++;
                    }

                }
                servicio.grafoMatriz(1);
                servicio.grafoMatriz(2);
                servicio.grafoMatriz(3);
                servicio.grafoMatriz(4);

                servicio.grafoDestruct(1);
                servicio.grafoDestruct(2);
                servicio.grafoDestruct(3);
                servicio.grafoDestruct(4);

            }
            catch
            {
                String popupScript = "<script language='JavaScript'> alert('Archivo Invalido'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            string filename = FileUpload1.FileName;
            try
            {

                FileUpload1.SaveAs(dir + filename);
                using (StreamReader readFile = new StreamReader(dir + filename))
                {
                    string line;
                    string[] row;
                    int contador = 0;

                    while ((line = readFile.ReadLine()) != null)
                    {
                        if (contador != 0)
                        {
                            row = line.Split(',');
                            Application["usuario1"] = row[0];
                            Application["usuario2"] = row[1];
                            Application["n1"] = Convert.ToInt32(row[2]);
                            Application["n2"] = Convert.ToInt32(row[3]);
                            Application["n3"] = Convert.ToInt32(row[4]);
                            Application["n4"] = Convert.ToInt32(row[5]);
                            Application["lC"] = Convert.ToInt32(row[6]);
                            Application["lF"] = Convert.ToInt32(row[7]);
                            Application["tipo"] = Convert.ToInt32(row[8]);
                            if (row[8].Equals("2")) Application["tiempo"] = row[9];
                            Label4.Text = "Datos Insertados";
                        }
                        contador++;

                    }
                }

            }
            catch
            {
                String popupScript = "<script language='JavaScript'> alert('Archivo Invalido'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            
            }
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            servicio.eliminarMatriz();
            servicio.eliminarMatrizD();
        }

    }
}