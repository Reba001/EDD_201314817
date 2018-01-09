using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime;
using System.Diagnostics;
namespace WebApplication1
{
    public partial class IngresoUsuarios : System.Web.UI.Page
    {
        webServiceNW.ProyectoEDD servicio;
        string dir = "C:\\CSVFile\\";
        string dirIm = "C:\\CSVFile\\Imagen\\";
        protected void Page_Load(object sender, EventArgs e)
        {
            servicio = (webServiceNW.ProyectoEDD)Application["WebServer"];
            
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
            
            string Nickname = txtNickname.Text;
            string Contrasenia = txtContrasenia.Text;
            string Email = txtCorreo.Text;
            bool Conectado = false;
            servicio.setUsuario(Nickname, Contrasenia, Email, Conectado);
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
                            
                            string Nickname = row[0];
                            string Contrasenia = row[1];
                            string Email = row[2];
                            bool Conectado;
                            if (row[3] == "1")
                            {
                                Conectado = true;
                            }
                            else
                            {
                                Conectado = false;
                            }
                            Label1.Text = servicio.setUsuario(Nickname, Contrasenia, Email, Conectado);
                        }
                        contador++;
                    }
                    this.crearGrafo(servicio.invocarGrafo(), "Arbol");
                    this.crearGrafo(servicio.ArbolEspejo(), "ArbolE");
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
                            string NicknameO = row[1];
                            int Desplegadas = Convert.ToInt32(row[2]);
                            int Sobrevivientes = Convert.ToInt32(row[3]);
                            int Destruidas = Convert.ToInt32(row[4]);
                            bool Ganar;
                            if (row[5] == "1")
                            {
                                Ganar = true;
                            }
                            else
                            {
                                Ganar = false;
                            }

                            Label2.Text = servicio.insertarJuegos(row[0], NicknameO, Desplegadas, Sobrevivientes, Destruidas, Ganar);
                        
                        
                        
                        }
                        contador++;
                        
                    }
                    this.crearGrafo(servicio.invocarGrafo(), "Arbol");
                    this.crearGrafo(servicio.ArbolEspejo(), "ArbolE");
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
                            if (row[3].StartsWith("Neosatelite"))
                            {
                                string Nickname = row[0];
                                string Unidad = row[3];
                                int Movimiento = 6;
                                int Alcance = 0;
                                float Danio = 2;
                                float Vida = 10;
                                int fila = Convert.ToInt32(row[2]);
                                if(row[4] == "0"){
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 4, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }else if (row[4] == "1"){

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 4, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }

                            }
                            else if (row[3].StartsWith("Bombardero"))
                            {
                                string Nickname = row[0];
                                string Unidad = row[3];
                                int Movimiento = 7;
                                int Alcance = 0;
                                float Danio = 5;
                                float Vida = 10;

                                int fila = Convert.ToInt32(row[2]);
                                if (row[4] == "0")
                                {
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 3, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }
                                else if (row[4] == "1")
                                {

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 3, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }
                            }
                            else if (row[3].StartsWith("Caza"))
                            {
                                string Nickname = row[0];
                                string Unidad = row[3];
                                int Movimiento = 9;
                                int Alcance = 1;
                                float Danio = 2;
                                float Vida = 20;

                                int fila = Convert.ToInt32(row[2]);
                                if (row[4] == "0")
                                {
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 3, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }
                                else if (row[4] == "1")
                                {

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 3, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }
                            }
                            else if (row[3].StartsWith("Helicóptero"))
                            {
                                string Nickname = row[0];
                                string Unidad = row[3];
                                int Movimiento = 9;
                                int Alcance = 1;
                                float Danio = 3;
                                float Vida = 15;

                                int fila = Convert.ToInt32(row[2]);
                                if (row[4] == "0")
                                {
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 3, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }
                                else if (row[4] == "1")
                                {

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 3, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }
                            }
                            else if (row[3].StartsWith("Fragata"))
                            {
                                string Nickname = row[0];
                                string Unidad = row[3];
                                int Movimiento = 5;
                                int Alcance = 6;
                                float Danio = 3;
                                float Vida = 10;

                                int fila = Convert.ToInt32(row[2]);
                                if (row[4] == "0")
                                {
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 2, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }
                                else if (row[4] == "1")
                                {

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 2, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }

                            }
                            else if (row[3].StartsWith("Crucero"))
                            {
                                string Nickname = row[0];
                                string Unidad = row[3];
                                int Movimiento = 6;
                                int Alcance = 1;
                                float Danio = 3;
                                float Vida = 15;

                                int fila = Convert.ToInt32(row[2]);
                                if (row[4] == "0")
                                {
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 2, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }
                                else if (row[4] == "1")
                                {

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 2, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }
                            }
                            else if (row[3].StartsWith("Submarino"))
                            {
                                string Nickname = row[0];
                                string Unidad = row[3];
                                int Movimiento = 5;
                                int Alcance = 1;
                                float Danio = 2;
                                float Vida = 10;

                                int fila = Convert.ToInt32(row[2]);
                                
                                if (row[4] == "0")
                                {
                                    Label3.Text = servicio.insertarenTableroD(fila, row[1], 1, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }
                                else if (row[4] == "1")
                                {

                                    Label3.Text = servicio.insertarenTablero(fila, row[1], 1, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                }
                            }
                        }
                        contador++;
                    }

                }
                this.crearGrafo(servicio.grafoMatriz(1), "Matriz1");
                this.crearGrafo(servicio.grafoMatriz(2), "Matriz2");
                this.crearGrafo(servicio.grafoMatriz(3), "Matriz3");
                this.crearGrafo(servicio.grafoMatriz(4), "Matriz4");

                this.crearGrafo(servicio.grafoDestruct(1), "Matrizdestruccion1");
                this.crearGrafo(servicio.grafoDestruct(2), "Matrizdestruccion2");
                this.crearGrafo(servicio.grafoDestruct(3), "Matrizdestruccion3");
                this.crearGrafo(servicio.grafoDestruct(4), "Matrizdestruccion4");

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

        protected void Button11_Click(object sender, EventArgs e)
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
                            string nicknamepadre = row[0];
                            string nicknameC = row[1];
                            string contrasenia = row[2];
                            string correo = row[3];

                           Label5.Text = servicio.insertarContacto(nicknamepadre, nicknameC, contrasenia, correo); 
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

        protected void Button12_Click(object sender, EventArgs e)
        {
            try {
                this.crearGrafo(servicio.TablaDispersa(), "TablaDispersa");
                Label6.Text = "Creada";
            }
            catch {
                String popupScript = "<script language='JavaScript'> alert('Archivo Invalido'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);

            }
        }

        protected void Button13_Click(object sender, EventArgs e)
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
                            
                            string X1 = row[0];
                            int Y1 = Convert.ToInt32(row[1]);
                            string Atacante = row[2];
                            int Resultado = Convert.ToInt32(row[3]);
                            string TipoUD = row[4];
                            string NickEmisor = row[5];
                            string NickReceptor = row[6];
                            string Fecha = row[7];
                            string TiempoRestante = row[8];
                            int NumerodeAtaque = Convert.ToInt32(row[9]);
                            int Key = clave(row[0], Convert.ToInt32(row[1]), row[2], Convert.ToInt32(row[9]));
                            servicio.insertarHistoria(X1, Y1, Atacante, Resultado, TipoUD, NickEmisor, NickReceptor, Fecha, TiempoRestante, NumerodeAtaque, Key);
                            Label6.Text = "Insertado";
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

        protected void Button14_Click(object sender, EventArgs e)
        {
            try 
            {
                string nickname = txtUsuario.Text;
                this.crearGrafo(servicio.grafoContactos(nickname), "ArbolAVL");

            }
            catch 
            {
                String popupScript = "<script language='JavaScript'> alert('Archivo Invalido'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);

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

        public int clave(string X, int Y, string atacante, int numataque)
        {
            int c = 0;
            for (int i = 0; i < X.Length; i++)
                c += X[i];

            
            if (atacante.StartsWith("Neosatelite"))
                c += 4;
            else if (atacante.StartsWith("Bombardero") || atacante.StartsWith("Caza") || atacante.StartsWith("Helicóptero"))
                c += 3;
            else if (atacante.StartsWith("Fragata") || atacante.StartsWith("Crucero"))
                c += 2;
            else if (atacante.StartsWith("Submarino"))
                c += 1;

            return (c + Y + numataque);
        }

    }
}