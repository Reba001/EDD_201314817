using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class Cliente1 : System.Web.UI.Page
    {
        webServicePrueba.Service1Client serv;
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
            serv = (webServicePrueba.Service1Client)Application["WebServer"];
            
            this.cont1 = (int) Application["contn1"];
            this.cont2 = (int) Application["contn2"];
            this.cont3 = (int) Application["contn3"];
            this.cont4 = (int) Application["contn4"];

            this.limitX = Convert.ToInt32(Application["lC"].ToString());
            this.limitY = Convert.ToInt32(Application["lF"].ToString());

            this.limitN1 = Convert.ToInt32(Application["n1"].ToString());
            this.limitN2 = Convert.ToInt32(Application["n2"].ToString());
            this.limitN3 = Convert.ToInt32(Application["n3"].ToString());
            this.limitN4 = Convert.ToInt32(Application["n4"].ToString());

            this.tipo = Convert.ToInt32(Application["tipo"].ToString());
            String user = (String)Session["usuario1"];
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

            if (File.Exists("C:\\CSVFile\\Imagen\\Matriz1.jpg"))
            {
                if (File.Exists(Server.MapPath("/images") + "\\Matriz1.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Matriz1.jpg");
                File.Move("C:\\CSVFile\\Imagen\\Matriz1.jpg", Server.MapPath("/images") + "\\Matriz1.jpg");
                this.Image1.ImageUrl = "/images/Matriz1.jpg";
            }
                this.Image1.ImageUrl = "/images/Matriz1.jpg";
            

            if (File.Exists("C:\\CSVFile\\Imagen\\Matriz2.jpg"))
            {
                if (File.Exists(Server.MapPath("/images") + "\\Matriz2.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Matriz2.jpg");
                File.Move("C:\\CSVFile\\Imagen\\Matriz2.jpg", Server.MapPath("/images") + "\\Matriz2.jpg");
                this.Image2.ImageUrl = "/images/Matriz2.jpg";
            }
                this.Image2.ImageUrl = "/images/Matriz2.jpg";
            

            if (File.Exists("C:\\CSVFile\\Imagen\\Matriz3.jpg"))
            {

                if (File.Exists(Server.MapPath("/images") + "\\Matriz3.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Matriz3.jpg");
                File.Move("C:\\CSVFile\\Imagen\\Matriz3.jpg", Server.MapPath("/images") + "\\Matriz3.jpg");
                this.Image3.ImageUrl = "/images/Matriz3.jpg";
            }
                this.Image3.ImageUrl = "/images/Matriz3.jpg";
            

            if (File.Exists("C:\\CSVFile\\Imagen\\Matriz4.jpg"))
            {

                if (File.Exists(Server.MapPath("/images") + "\\Matriz4.jpg"))
                    File.Delete(Server.MapPath("/images") + "\\Matriz4.jpg");

                File.Move("C:\\CSVFile\\Imagen\\Matriz4.jpg", Server.MapPath("/images") + "\\Matriz4.jpg");
                this.Image4.ImageUrl = "/images/Matriz4.jpg";
            }
                this.Image4.ImageUrl = "/images/Matriz4.jpg";
            
            
        }

        protected void lbtLogout_Click(object sender, EventArgs e)
        {
            string usuario = (String)Session["usuario1"];
            serv.modificarEstad(usuario, false);
            Session.Remove("usuario1");
            Response.Redirect("Login.aspx");

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            

            string unidadSelect = this.DropDownList1.SelectedItem.ToString();
            int nivel = 0;
            if (txtNivel.Text != "")
                nivel = Convert.ToInt32(txtNivel.Text);
            string posX = txtPosX.Text;
            char[] arreglo = posX.ToCharArray();// para poder saber el limite de arreglos
            int posX2=0;// x2 posicion nueva
            int div = this.limitX/26;// dividimos dentro de 26 para poder tener un multiplo para multiplicarlo de nuevo :V 
            int sum = this.limitX - (div * 26);// la diferencia para sumarlo y asi tener un limite verdadero
            this.limitX = (65*arreglo.Length) + sum;// lo sumamos dependiendo de cuanto sea el limite
            for (int i = 0; i < arreglo.Length ; i++) posX2 += arreglo[i];// nuevo codigo para posicion en X
            int posY = 0;
            if (txtPosY.Text != "")
                posY = Convert.ToInt32(txtPosY.Text);
            
            if ((posY <= this.limitY/2) && (posY > 0) && (posX2 < this.limitX) && (posX2 > 64))
            {
                if (nivel < 5 && nivel > 0)
                {

                    switch (nivel)
                    {
                        case 1:
                            if (this.cont1 < this.limitN1 && unidadSelect.Equals("Submarino"))
                            {
                                posX.Trim();
                                webServicePrueba.Pieza pieza = new webServicePrueba.Pieza();
                                pieza.Nickname = Session["usuario1"].ToString();
                                pieza.Unidad = unidadSelect+cont1.ToString();
                                pieza.Movimiento = 5;
                                pieza.Alcance = 1;
                                pieza.Danio = 2;
                                pieza.Vida = 10;

                                string insercion = serv.insertarenTablero(posY, posX, 1, pieza);
                                this.txtConsola.Text += insercion +"en Fila: "+txtPosY.Text+" Columna: "+txtPosX.Text+" nivel: 1 Pieza: "+unidadSelect;
                                if (insercion.Equals("Insertado!"))
                                    Application["contn1"] = ++cont1;

                            }
                            else
                            {

                                String popupScript = "<script language='JavaScript'> alert('¡Limite de Nivel 1 Excedido!'); </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);

                            }

                            break;
                        case 2:
                            if (this.cont2 < this.limitN2 && (unidadSelect.Equals("Fragata") || unidadSelect.Equals("Crucero")))
                            {
                                posX.Trim();
                                webServicePrueba.Pieza pieza = new webServicePrueba.Pieza();
                                pieza.Nickname = Session["usuario1"].ToString();
                                pieza.Unidad = unidadSelect + cont2.ToString();
                                if (unidadSelect.Equals("Fragata"))
                                {
                                    pieza.Movimiento = 5;
                                    pieza.Alcance = 6;
                                    pieza.Danio = 3;
                                    pieza.Vida = 10;
                                }
                                else 
                                {
                                    pieza.Movimiento = 6;
                                    pieza.Alcance = 1;
                                    pieza.Danio = 3;
                                    pieza.Vida = 15;
                                }
                                string insercion = serv.insertarenTablero(posY, posX, 2, pieza);
                                this.txtConsola.Text += insercion + " en Fila: " + txtPosY.Text + " Columna: " + txtPosX.Text + " nivel: 2 Pieza: " + unidadSelect+"\n";
                                if (insercion.Equals("Insertado!"))
                                    Application["contn2"] = ++cont2;
                            }
                            else
                            {

                                String popupScript = "<script language='JavaScript'> alert('¡Limite de nivel 2 Excedido!'); </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);

                            }
                            break;
                        case 3:
                            if (this.cont3 < this.limitN3 && (unidadSelect.Equals("Bombardero") || unidadSelect.Equals("Caza") || unidadSelect.Equals("Helicóptero de combate")))
                            {
                                posX.Trim();
                                webServicePrueba.Pieza pieza = new webServicePrueba.Pieza();
                                pieza.Nickname = Session["usuario1"].ToString();
                                pieza.Unidad = unidadSelect + cont3.ToString();
                                if (unidadSelect.Equals("Bombardero"))
                                {
                                    pieza.Movimiento = 7;
                                    pieza.Alcance = 0;
                                    pieza.Danio = 5;
                                    pieza.Vida = 10;
                                }
                                else if (unidadSelect.Equals("Caza"))
                                {

                                    pieza.Movimiento = 9;
                                    pieza.Alcance = 1;
                                    pieza.Danio = 2;
                                    pieza.Vida = 20;
                                }
                                else 
                                {
                                    pieza.Movimiento = 9;
                                    pieza.Alcance = 1;
                                    pieza.Danio = 3;
                                    pieza.Vida = 15;
                                }
                                string insercion = serv.insertarenTablero(posY, posX, 3, pieza);
                                this.txtConsola.Text += insercion + " en Fila: " + txtPosY.Text + " Columna: " + txtPosX.Text + " nivel: 3 Pieza: " + unidadSelect+"\n";
                                if (insercion.Equals("Insertado!"))
                                    Application["contn3"] = ++cont3;
                            }
                            else
                            {

                                String popupScript = "<script language='JavaScript'> alert('¡Limite de nivel 3 Excedido!'); </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);

                            }
                            break;
                        default:
                            if (this.cont4 < this.limitN4 && unidadSelect.Equals("Neosatelite"))
                            {
                                posX.Trim();
                                webServicePrueba.Pieza pieza = new webServicePrueba.Pieza();
                                pieza.Nickname = Session["usuario1"].ToString();
                                pieza.Unidad = unidadSelect + cont4.ToString();
                                pieza.Movimiento = 6;
                                pieza.Alcance = 0;
                                pieza.Danio = 2;
                                pieza.Vida = 10;
                                string insercion = serv.insertarenTablero(posY, posX, 4, pieza);
                                this.txtConsola.Text += insercion + " en Fila: " + txtPosY.Text + " Columna: " + txtPosX.Text + " nivel: 4 Pieza: " + unidadSelect+"\n";
                                if(insercion.Equals("Insertado!"))
                                    Application["contn4"] = ++cont4;
                                
                            }
                            else
                            {

                                String popupScript = "<script language='JavaScript'> alert('¡Limite de Nivel 4 excedido!'); </script>";
                                Page.RegisterStartupScript("PopupScript", popupScript);
                            }
                            break;

                    }



                
                }
                else
                {
                    String popupScript = "<script language='JavaScript'> alert('¡Nivel invalido!'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript);

                }

            }
            else 
            {
                String popupScript = "<script language='JavaScript'> alert('¡Posicion X o Y invalida!'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript);
            }

            serv.grafoMatriz(1);
            serv.grafoMatriz(2);
            serv.grafoMatriz(3);
            serv.grafoMatriz(4);
            //para recargar los grafos
            if (File.Exists(Server.MapPath("/images") + "\\Matriz1.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matriz1.jpg");
                
            if (File.Exists(Server.MapPath("/images") + "\\Matriz4.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matriz4.jpg");

            if (File.Exists(Server.MapPath("/images") + "\\Matriz2.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matriz2.jpg");

            if (File.Exists(Server.MapPath("/images") + "\\Matriz3.jpg"))
                File.Delete(Server.MapPath("/images") + "\\Matriz3.jpg");
                
            if (File.Exists("C:\\CSVFile\\Imagen\\Matriz1.jpg"))
            {
                File.Move("C:\\CSVFile\\Imagen\\Matriz1.jpg", Server.MapPath("/images") + "\\Matriz1.jpg");
                this.Image1.ImageUrl = "/images/Matriz1.jpg";
            }
            

            if (File.Exists("C:\\CSVFile\\Imagen\\Matriz2.jpg"))
            {
                File.Move("C:\\CSVFile\\Imagen\\Matriz2.jpg", Server.MapPath("/images") + "\\Matriz2.jpg");
                this.Image2.ImageUrl = "/images/Matriz2.jpg";
            }
            

            if (File.Exists("C:\\CSVFile\\Imagen\\Matriz3.jpg"))
            {
                File.Move("C:\\CSVFile\\Imagen\\Matriz3.jpg", Server.MapPath("/images") + "\\Matriz3.jpg");
                this.Image3.ImageUrl = "/images/Matriz3.jpg";
            }
            

            if (File.Exists("C:\\CSVFile\\Imagen\\Matriz4.jpg"))
            {
                File.Move("C:\\CSVFile\\Imagen\\Matriz4.jpg", Server.MapPath("/images") + "\\Matriz4.jpg");
                this.Image4.ImageUrl = "/images/Matriz4.jpg";
            }
            
            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Application["contn1"] = 0;

            Application["contn2"] = 0;

            Application["contn3"] = 0;

            Application["contn4"] = 0;
            serv.eliminarMatriz();
            serv.crearMatriz();
        }

    }
}