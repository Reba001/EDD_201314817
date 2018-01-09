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
    public partial class Cliente2 : System.Web.UI.Page
    {
        webServiceNW.ProyectoEDD serv;
        int cont1;
        int cont2;
        int cont3;
        int cont4;
        int limitX;
        int limitY;
        int limitN1;
        int limitN2;
        int limitN3;
        int limitN4;
        int tipo;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            serv = (webServiceNW.ProyectoEDD)Application["WebServer"];

            this.cont1 = (int)Application["contn1"];
            this.cont2 = (int)Application["contn2"];
            this.cont3 = (int)Application["contn3"];
            this.cont4 = (int)Application["contn4"];

            this.limitX = Convert.ToInt32(Application["lC"].ToString());
            this.limitY = Convert.ToInt32(Application["lF"].ToString());

            this.limitN1 = Convert.ToInt32(Application["n1"].ToString());
            this.limitN2 = Convert.ToInt32(Application["n2"].ToString());
            this.limitN3 = Convert.ToInt32(Application["n3"].ToString());
            this.limitN4 = Convert.ToInt32(Application["n4"].ToString());

            this.tipo = Convert.ToInt32(Application["tipo"].ToString());
            String user = (String)Session["usuario2"];
            if (user != null)
            {
                lblUser.Text = user;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            if (tipo == 2)
            {
                lblTiempo.Text = Application["tiempo"].ToString();

            }
            else if (tipo == 1)
            {
                lblTiempo.Text = "No hay, tipo: Normal";
            }
            else
            {
                lblTiempo.Text = "No hay, tipo: Base";
            }

            if (!Directory.Exists("C:\\CSVFile\\Imagen\\"))
            {
                Directory.CreateDirectory("C:\\CSVFile\\Imagen\\");
            }
            this.crearGrafo(serv.grafoMatriz(1), "Matriz1cliente");
            this.crearGrafo(serv.grafoMatriz(2), "Matriz2cliente");
            this.crearGrafo(serv.grafoMatriz(3), "Matriz3cliente");
            this.crearGrafo(serv.grafoMatriz(4), "Matriz4cliente");
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

        protected void lbtLogout_Click(object sender, EventArgs e)
        {
            string usuario = (String)Session["usuario2"];
            serv.modificarEstad(usuario, false);
            Session.Remove("usuario2");
            Response.Redirect("Login.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                string unidadSelect = this.DropDownList1.SelectedItem.ToString();
                string posX = txtPosX.Text;
                char[] arreglo = posX.ToCharArray();// para poder saber el limite de arreglos
                int posX2 = 0;// x2 posicion nueva
                int div = this.limitX / 26;// dividimos dentro de 26 para poder tener un multiplo para multiplicarlo de nuevo :V 
                int sum = this.limitX - (div * 26);// la diferencia para sumarlo y asi tener un limite verdadero
                this.limitX = (65 * arreglo.Length) + sum;// lo sumamos dependiendo de cuanto sea el limite
                for (int i = 0; i < arreglo.Length; i++) posX2 += arreglo[i];// nuevo codigo para posicion en X
                int posY = 0;
                if (txtPosY.Text != "")
                    posY = Convert.ToInt32(txtPosY.Text);

                if (posY <= this.limitY  && (posY > this.limitY/2) && (posX2 < this.limitX) && (posX2 > 64))
                {


                    switch (unidadSelect)
                    {
                        case "Submarino":
                            if (this.cont1 < this.limitN1)
                            {
                                posX.Trim();

                                string Nickname = Session["usuario2"].ToString();
                                string unidad = unidadSelect + cont1.ToString();
                                int movimiento = 5;
                                int alcance = 1;
                                float danio = 2;
                                float vida = 10;

                                string insercion = serv.insertarenTablero(posY, posX, 1, Nickname, unidad, alcance, movimiento, danio, vida);
                                this.txtConsola.Text += insercion + "en Fila: " + txtPosY.Text + " Columna: " + txtPosX.Text + " nivel: 1 Pieza: " + unidadSelect;
                                if (insercion.Equals("Insertado!"))
                                {

                                    Application["cont2n1"] = ++cont1;
                                    this.lblContador1.Text = "Contador nivel 1: " + cont1.ToString();
                                }

                            }
                            else
                            {

                                String popupScript = "<script language='JavaScript'> alert('¡Limite de Nivel 1 Excedido!'); </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);

                            }

                            break;
                        case "Fragata":
                            if (this.cont2 < this.limitN2)
                            {
                                posX.Trim();
                                string Nickname = Session["usuario2"].ToString();
                                string unidad = unidadSelect + cont2.ToString();
                                int movimiento = 5;
                                int alcance = 6;
                                float danio = 3;
                                float vida = 10;


                                string insercion = serv.insertarenTablero(posY, posX, 2, Nickname, unidad, alcance, movimiento, danio, vida);
                                this.txtConsola.Text += insercion + " en Fila: " + txtPosY.Text + " Columna: " + txtPosX.Text + " nivel: 2 Pieza: " + unidadSelect + "\n";
                                if (insercion.Equals("Insertado!"))
                                {

                                    Application["cont2n2"] = ++cont2;
                                    this.lblContador2.Text = "Contador nivel 2: " + cont2.ToString();
                                }
                            }
                            else
                            {

                                String popupScript = "<script language='JavaScript'> alert('¡Limite de nivel 2 Excedido!'); </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);

                            }
                            break;
                        case "Crucero":
                            if (this.cont2 < this.limitN2)
                            {
                                posX.Trim();
                                string Nickname = Session["usuario2"].ToString();
                                string unidad = unidadSelect + cont2.ToString();
                                int movimiento = 6;
                                int alcance = 1;
                                float danio = 3;
                                float vida = 15;
                                string insercion = serv.insertarenTablero(posY, posX, 2, Nickname, unidad, alcance, movimiento, danio, vida);
                                this.txtConsola.Text += insercion + " en Fila: " + txtPosY.Text + " Columna: " + txtPosX.Text + " nivel: 2 Pieza: " + unidadSelect + "\n";
                                if (insercion.Equals("Insertado!"))
                                {

                                    Application["cont2n2"] = ++cont2;
                                    this.lblContador2.Text = "Contador nivel 2: " + cont2.ToString();
                                }
                            }
                            else
                            {

                                String popupScript = "<script language='JavaScript'> alert('¡Limite de nivel 2 Excedido!'); </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);

                            }

                            break;
                        case "Bombardero":
                            if (this.cont3 < this.limitN3 )
                            {
                                posX.Trim();
                                string Nickname = Session["usuario2"].ToString();
                                string Unidad = unidadSelect + cont3.ToString();
                                int Movimiento = 7;
                                int Alcance = 0;
                                float Danio = 5;
                                float Vida = 10;


                                string insercion = serv.insertarenTablero(posY, posX, 3, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                this.txtConsola.Text += insercion + " en Fila: " + txtPosY.Text + " Columna: " + txtPosX.Text + " nivel: 3 Pieza: " + unidadSelect + "\n";
                                if (insercion.Equals("Insertado!"))
                                {

                                    Application["cont2n3"] = ++cont3;
                                    this.lblContador3.Text = "Contador nivel 3: " + cont3.ToString();
                                }
                            }
                            else
                            {

                                String popupScript = "<script language='JavaScript'> alert('¡Limite de nivel 3 Excedido!'); </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);

                            }
                            break;
                        case "Caza":
                            if (this.cont3 < this.limitN3)
                            {
                                posX.Trim();
                                string Nickname = Session["usuario2"].ToString();
                                string Unidad = unidadSelect + cont3.ToString();
                                int Movimiento = 9;
                                int Alcance = 1;
                                float Danio = 2;
                                float Vida = 20;


                                string insercion = serv.insertarenTablero(posY, posX, 3, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                this.txtConsola.Text += insercion + " en Fila: " + txtPosY.Text + " Columna: " + txtPosX.Text + " nivel: 3 Pieza: " + unidadSelect + "\n";
                                if (insercion.Equals("Insertado!"))
                                {

                                    Application["cont2n3"] = ++cont3;
                                    this.lblContador3.Text = "Contador nivel 3: " + cont3.ToString();
                                }
                            }
                            else
                            {

                                String popupScript = "<script language='JavaScript'> alert('¡Limite de nivel 3 Excedido!'); </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);

                            }
                            break;
                        case "Helicóptero de combate":
                            if (this.cont3 < this.limitN3)
                            {
                                posX.Trim();
                                string Nickname = Session["usuario2"].ToString();
                                string Unidad = "Helicóptero" + cont3.ToString();
                                int Movimiento = 9;
                                int Alcance = 1;
                                float Danio = 3;
                                float Vida = 15;


                                string insercion = serv.insertarenTablero(posY, posX, 3, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                this.txtConsola.Text += insercion + " en Fila: " + txtPosY.Text + " Columna: " + txtPosX.Text + " nivel: 3 Pieza: " + unidadSelect + "\n";
                                if (insercion.Equals("Insertado!")) 
                                {

                                    Application["cont2n3"] = ++cont3;
                                    this.lblContador3.Text = "Contador nivel 3: " + cont3.ToString();
                                }
                            }
                            else
                            {

                                String popupScript = "<script language='JavaScript'> alert('¡Limite de nivel 3 Excedido!'); </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);

                            }
                            break;

                        case "Neosatelite":
                            if (this.cont4 < this.limitN4)
                            {
                                posX.Trim();
                                string Nickname = Session["usuario2"].ToString();
                                string Unidad = unidadSelect + cont4.ToString();
                                int Movimiento = 6;
                                int Alcance = 0;
                                int Danio = 2;
                                int Vida = 10;
                                string insercion = serv.insertarenTablero(posY, posX, 4, Nickname, Unidad, Alcance, Movimiento, Danio, Vida);
                                this.txtConsola.Text += insercion + " en Fila: " + txtPosY.Text + " Columna: " + txtPosX.Text + " nivel: 4 Pieza: " + unidadSelect + "\n";
                                if (insercion.Equals("Insertado!")) 
                                {

                                    Application["cont2n4"] = ++cont4;
                                    this.lblContador4.Text = "Contador nivel 4: " + cont4.ToString();
                                }

                            }
                            else
                            {

                                String popupScript = "<script language='JavaScript'> alert('¡Limite de Nivel 4 excedido!'); </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);
                            }
                            break;
                        default:

                            String popupScript1 = "<script language='JavaScript'> alert('¡Error Nivel no existente!'); </script>";
                            Page.RegisterStartupScript("PopupScript", popupScript1);

                            break;
                    }



                    

                }
                else
                {
                    String popupScript = "<script language='JavaScript'> alert('¡Posicion X o Y invalida!'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);
                }

                this.crearGrafo(serv.grafoMatriz(1), "Matriz1cliente");
                this.crearGrafo(serv.grafoMatriz(2), "Matriz2cliente");
                this.crearGrafo(serv.grafoMatriz(3), "Matriz3cliente");
                this.crearGrafo(serv.grafoMatriz(4), "Matriz4cliente");
                //para recargar los grafos 

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
                    this.Image1.ImageUrl = "/images/Matriz1cliente.jpg";
                }
                

                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz2cliente.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz2cliente.jpg", Server.MapPath("/images") + "\\Matriz2cliente.jpg");
                    this.Image2.ImageUrl = "/images/Matriz2cliente.jpg";
                }
                

                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz3cliente.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz3cliente.jpg", Server.MapPath("/images") + "\\Matriz3cliente.jpg");
                    this.Image3.ImageUrl = "/images/Matriz3cliente.jpg";
                }
                

                if (File.Exists("C:\\CSVFile\\Imagen\\Matriz4cliente.jpg"))
                {
                    File.Copy("C:\\CSVFile\\Imagen\\Matriz4cliente.jpg", Server.MapPath("/images") + "\\Matriz4cliente.jpg");
                    this.Image4.ImageUrl = "/images/Matriz4cliente.jpg";
                }
            
            }
            catch 
            {
                String popupScript = "<script language='JavaScript'> alert('¡Error!'); </script>";
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

        protected void Button5_Click(object sender, EventArgs e)
        {

            Application["cont2n1"] = 0;

            Application["cont2n2"] = 0;

            Application["cont2n3"] = 0;

            Application["cont2n4"] = 0;
            serv.eliminarMatriz();
            serv.crearMatriz();

        }

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    if (Session["usuario1"] != null)
        //    {
        //        string user2 = Session["usuario1"].ToString();
        //        bool conectado = serv.getConectado(user2);
        //        if (conectado)
        //        {
        //            Label1.Text = "Oponente " + user2 + " Conectado";
        //        }
        //        int l = (int)Application["listo"];
        //        int l2 = (int)Application["listo2"];
        //        if (l == 1 && l2 == 1)
        //        {

        //            Response.Redirect("ClienteInicio2.aspx");
        //            Timer1.Enabled = false;

        //        }
        //    }
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            Application["listo2"] = 1;
            int l = (int)Application["listo"];
            int l2 = (int)Application["listo2"];
            if (l == 1 && l2 == 1)
            {
                Response.Redirect("ClienteInicio2.aspx");
            }
        }
    }
}