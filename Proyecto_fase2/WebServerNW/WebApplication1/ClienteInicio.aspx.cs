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
    public partial class ClienteInicio : System.Web.UI.Page
    {
        int limitX;
        int limitY;
        int tipo;
        string tiempo;
        string usuario;
        bool jugar = true;
        int hora = 0;
        int minutos= 0;
        int segundos= 0;
        webServiceNW.ProyectoEDD servicio = new webServiceNW.ProyectoEDD();
        protected void Page_Load(object sender, EventArgs e)
        {

            this.limitX = Convert.ToInt32(Application["lC"].ToString());
            this.limitY = Convert.ToInt32(Application["lF"].ToString());
            if (Session["usuario1"] != null )
            {

                usuario = Session["usuario1"].ToString();
            }
            else 
            {
                Response.Redirect("Login.aspx");
            }

            this.tipo = Convert.ToInt32(Application["tipo"].ToString());
            this.tiempo = Application["tiempo"].ToString();
            hora = int.Parse(Application["hora"].ToString());
            minutos = int.Parse(Application["minutos"].ToString());
            segundos = int.Parse(Application["segundos"].ToString());
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {

                //este metodo es para mover pieza 
                //cumplir las condiciones: si es base hasta que capturen la base 
                // si es normal hasta que se destruyan las piezas 
                // si es por tiempo hasta que se termine el tiempo

                //if (txtDestX.Text != "" && txtDestY.Text != "" && txtPosX.Text != "" && txtPosY.Text != "")
                //{
                //    if (tipo == 1)
                //    {
                //        if (servicio.getPiezasDestruidas(usuario))
                //            this.MoverPieza();
                //        else
                //        {
                //            String popupScript2 = "<script language='JavaScript'> alert('NO TIENES PIEZAS HAS PERDIDO LA PARTIDA'); </script>";
                //            Page.RegisterStartupScript("PopupScript", popupScript2);
                //        }
                //    }
                //    else if (tipo == 2)
                //    {
                //        if (jugar && servicio.getPiezasDestruidas(usuario))
                //            this.MoverPieza();
                //        else
                //        {
                //            String popupScript2 = "<script language='JavaScript'> alert('SE TERMINO EL TIEMPO JUEGO COMIENZE UNA PARTIDA NUEVA'); </script>";
                //            Page.RegisterStartupScript("PopupScript", popupScript2);
                //        }

                //    }
                //    else 
                //    {
                //        if (servicio.getPiezasDestruidas(usuario))
                //            this.MoverPieza();
                //        else 
                //        {
                //            String popupScript2 = "<script language='JavaScript'> alert('SE TERMINO EL TIEMPO JUEGO COMIENZE UNA PARTIDA NUEVA'); </script>";
                //            Page.RegisterStartupScript("PopupScript", popupScript2);
                //        }
                            
                //    }

                //}
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
                txtConsola.Text += "Pieza movida de " + x + " , " + y.ToString() + " , " + selectNivel + " \n a "+xde+" , "+yde.ToString()+" , "+selectNivel +"\n";
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

                String popupScript2 = "<script language='JavaScript'> alert('ERROR MOVIMIENTO NO PERMITIDO'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript2);

            }

            
        }

        private void AtaqueAlcance()
        {
            string x = txtPosX.Text;
            int y = int.Parse(txtPosY.Text);
            string selectNivel = DropDownList1.SelectedItem.ToString();
            string xdes = txtDestX.Text;
            int ydes = int.Parse(txtDestY.Text);
            int nivel = 0;
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
            int posX2 = 0;// x2 posicion nueva
            int div = this.limitX / 26;// dividimos dentro de 26 para poder tener un multiplo para multiplicarlo de nuevo :V 
            int sum = this.limitX - (div * 26);// la diferencia para sumarlo y asi tener un limite verdadero
            this.limitX = (65 * xdes.Length) + sum;// lo sumamos dependiendo de cuanto sea el limite
            for (int i = 0; i < xdes.Length; i++) posX2 += xdes[i];// nuevo codigo para posicion en X

            if ((ydes <= this.limitY) && (ydes > 0) && (posX2 < this.limitX) && (posX2 > 64))//para poder realizar el movimiento
            {
                int movimietno = servicio.getAlcance(x, y, nivel);
                string nickname = servicio.getNick(x, y, nivel);
                int resultY = (y - ydes) >= 0 ? (y - ydes) : -(y - ydes);// si nos da un numero negativo usamos este codigo para convertirlo a positivo
                int resultX;
                if (x.Length == 1 && xdes.Length > 1)// si el destino tienes mas caracteres que el origen
                {
                    resultX = -(x[0] - (xdes[0] + 26));
                }
                else if (x.Length > 1 && xdes.Length == 1)// sie el origen tiene mas caracteres que el destino
                {
                    resultX = ((x[0] + 26) - xdes[0]);
                }
                else // si ambos tienen uno o mas caracteres
                {
                    resultX = (x[0] - xdes[0]) >= 0 ? (x[0] - xdes[0]) : -(x[0] - xdes[0]);
                }
                int resultadototal = resultX + resultY;// resultado de movimientos
                if (resultadototal <= movimietno && resultadototal > 0 && nickname == usuario)
                {
                    float danio = servicio.getDanio(x,y, nivel);
                    float life = servicio.getVida(xdes, ydes, nivel);
                    string nickdes = servicio.getNick(xdes, ydes, nivel);
                    if (danio > -1 && life > -1 && nickdes != usuario)// SI  NO ENCUENTRA LAS PIEZAS DEVUELVE -1
                    {
                        life = life - danio;
                        servicio.setVida(xdes, ydes, nivel, life);

                        string insercion = selectNivel + " Ataco a: Pieza en posicion: "+xdes+" "+ydes.ToString()+ " "+nivel.ToString();
                        if (life <= 0)
                        {
                            insercion += " Pieza en posicion: " + xdes + " " + ydes.ToString() + " " + nivel.ToString()+ " Eliminada";
                            string unidad = servicio.getPieza(ydes, xdes, nivel);
                            int alcance2 = servicio.getAlcance(xdes, ydes, nivel);
                            int movimiento2= servicio.getMovimiento(xdes, ydes, nivel);
                            float danio2 = servicio.getDanio(xdes, ydes, nivel);
                            servicio.insertarenTableroD(ydes, xdes, nivel, nickdes,unidad,alcance2, movimiento2 ,danio2, life);
                            servicio.eliminarPieza(ydes, xdes, nivel);
                        }
                        txtConsola.Text += insercion;
                    }
                    else 
                    {
                        String popupScript2 = "<script language='JavaScript'> alert('NO PUEDES ATACAR A TUS PROPIAS PIEZAS'); </script>";
                        Page.RegisterStartupScript("PopupScript", popupScript2);
                    }
                    
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
                }// movimiento realizado
                else //fallo por si no se cumple los parametros del movimiento
                {
                    String popupScript2 = "<script language='JavaScript'> alert('MOVIMIENTO NO PERMITIDO'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript2);

                }// fin de movimiento

            }
            else
            {
                //definimos un mensaje en caso de esxcedernos del limite
                String popupScript3 = "<script language='JavaScript'> alert('LIMITE EN X O EN Y EXCEDIDO'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript3);
            }

        }
        private void MoverPieza() 
        {
            string x = txtPosX.Text;
            int y = int.Parse(txtPosY.Text);
            string selectNivel = DropDownList1.SelectedItem.ToString();
            string xdes = txtDestX.Text;
            int ydes = int.Parse(txtDestY.Text);
            int nivel = 0;
            if (selectNivel.Equals("Submarino"))
            {
                nivel = 1;
            }else if (selectNivel.Equals("Fragata") || selectNivel.Equals("Crucero"))
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
            int posX2=0;// x2 posicion nueva
            int div = this.limitX/26;// dividimos dentro de 26 para poder tener un multiplo para multiplicarlo de nuevo :V 
            int sum = this.limitX - (div * 26);// la diferencia para sumarlo y asi tener un limite verdadero
            this.limitX = (65*xdes.Length) + sum;// lo sumamos dependiendo de cuanto sea el limite
            for (int i = 0; i < xdes.Length ; i++) posX2 += xdes[i];// nuevo codigo para posicion en X

            if ((ydes <= this.limitY) && (ydes > 0) && (posX2 < this.limitX) && (posX2 > 64))//para poder realizar el movimiento
            {
                int movimietno = servicio.getMovimiento(x, y, nivel);
                string nickname = servicio.getNick(x, y, nivel);
                int resultY = (y - ydes) >= 0 ? (y-ydes): -(y-ydes);// si nos da un numero negativo usamos este codigo para convertirlo a positivo
                int resultX;
                if (x.Length == 1 && xdes.Length > 1)// si el destino tienes mas caracteres que el origen
                {
                    resultX = -(x[0] - (xdes[0] + 26));
                }
                else if (x.Length > 1 && xdes.Length == 1)// sie el origen tiene mas caracteres que el destino
                {
                    resultX = ((x[0] + 26) - xdes[0]);
                }
                else // si ambos tienen uno o mas caracteres
                {
                    resultX = (x[0] - xdes[0]) >= 0 ? (x[0] - xdes[0]) : -(x[0] - xdes[0]);
                }
                int resultadototal = resultX+resultY;// resultado de movimientos
                if (resultadototal <= movimietno && resultadototal > 0 && nickname == usuario )
                {
                    string insercion = servicio.moverPieza(x, y, nivel, xdes, ydes, nivel);
                    txtConsola.Text += insercion + " en " + xdes + ", " + ydes.ToString() + ", " + selectNivel + "\n";
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
                }// movimiento realizado
                else //fallo por si no se cumple los parametros del movimiento
                {
                    String popupScript2 = "<script language='JavaScript'> alert('MOVIMIENTO NO PERMITIDO'); </script>";
                    Page.RegisterStartupScript("PopupScript", popupScript2);

                }// fin de movimiento

            }
            else 
            {
                //definimos un mensaje en caso de esxcedernos del limite
                String popupScript3 = "<script language='JavaScript'> alert('LIMITE EN X O EN Y EXCEDIDO'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript3);
            }
            
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {

                //este metodo es para mover pieza 
                //cumplir las condiciones: si es base hasta que capturen la base 
                // si es normal hasta que se destruyan las piezas 
                // si es por tiempo hasta que se termine el tiempo
                //String user2 = Session["usuario2"].ToString();
                //string selectnivel = DropDownList1.SelectedItem.ToString();
                //if (txtDestX.Text != "" && txtDestY.Text != "" && txtPosX.Text != "" && txtPosY.Text != "")
                //{
                //    if (tipo == 1)
                //    {
                //        if (servicio.getPiezasDestruidas(user2)) 
                //        {
                //            if (selectnivel == "Submarino" || selectnivel == "Crucero" || selectnivel == "Fragata" || selectnivel == "Helicóptero de combate" || selectnivel == "Caza")
                //            {
                //                this.AtaqueAlcance();
                //            }
                //            else 
                //            {
                //                // ataquepornivel
                //            }
                //        }

                //        else
                //        {
                //            String popupScript2 = "<script language='JavaScript'> alert('EL OPONENTE YA NO TIENE PIEZAS HAS GANADO LA PARTIDA'); </script>";
                //            Page.RegisterStartupScript("PopupScript", popupScript2);
                //        }
                //    }
                //    else if (tipo == 2)
                //    {
                //        if (jugar && servicio.getPiezasDestruidas(user2))
                //        {
                //            if (selectnivel == "Submarino" || selectnivel == "Crucero" || selectnivel == "Fragata" || selectnivel == "Helicóptero de combate" || selectnivel == "Caza")
                //            {
                //                this.AtaqueAlcance();
                //            }
                //            else
                //            {
                //                // ataquepornivel
                //            }

                //        }
                //        else
                //        {
                //            String popupScript2 = "<script language='JavaScript'> alert('SE TERMINO EL TIEMPO JUEGO COMIENZE UNA PARTIDA NUEVA'); </script>";
                //            Page.RegisterStartupScript("PopupScript", popupScript2);
                //        }

                //    }
                //    else
                //    {
                //        if (servicio.getPiezasDestruidas(user2))
                //        {
                //            if (selectnivel == "Submarino" || selectnivel == "Crucero" || selectnivel == "Fragata" || selectnivel == "Helicóptero de combate" || selectnivel == "Caza")
                //            {
                //                this.AtaqueAlcance();
                //            }
                //            else
                //            {
                //                // ataquepornivel
                //            }

                //        }
                //        else
                //        {
                //            String popupScript2 = "<script language='JavaScript'> alert('SE TERMINO EL TIEMPO JUEGO COMIENZE UNA PARTIDA NUEVA'); </script>";
                //            Page.RegisterStartupScript("PopupScript", popupScript2);
                //        }

                //    }

                //}


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

                string insercion = servicio.eliminarPieza(yde, xde, nivel);
                txtConsola.Text =  "Pieza eliminada en " + xde + " , " + yde.ToString() + " , " + selectNivel + " \n";
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

                String popupScript2 = "<script language='JavaScript'> alert('ERROR MOVIMIENTO NO PERMITIDO'); </script>";
                Page.RegisterStartupScript("PopupScript", popupScript2);

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

        private string appenzero(double str) 
        {
            if (str < 10)
                return "0" + str.ToString();
            else
                return str.ToString();
            
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
                if (segundos < 0 )
                {
                    minutos--;
                    
                    segundos = 59;
                   
                }

                if (minutos < 0)
                {
                    hora--;
                    minutos = 59;
                }

                Application["hora"] = hora;
                Application["segundos"] = segundos;
                Application["minutos"] = minutos;
                int horaw = (int)Application["hora2"];
                int minutow = (int)Application["minutos2"];
                int segundow = (int)Application["segundos2"];
                if (horaw == -1 && minutow == -1 && segundow == -1)
                {
                    Application["hora2"] = hora;
                    Application["segundos2"] = segundos;
                    Application["minutos2"] = minutos;
                }
                lblHoras.Text = this.appenzero(hora);
                lblMinutos.Text = this.appenzero(minutos);
                lblSegundos.Text = this.appenzero(segundos);

            }
        }

        

    }
}