using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ModificarEliminar : System.Web.UI.Page
    {
        webServiceNW.ProyectoEDD servicio;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            servicio = (webServiceNW.ProyectoEDD)Application["WebServer"];
           
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (txtNickname.Text != "" && txtUsuarioNuevo.Text != ""){

                Label4.Text = servicio.modificarUsuario(txtNickname.Text, txtUsuarioNuevo.Text);
            }

            if(txtNickname.Text != "" && txtContrasenia.Text != ""){

                Label2.Text = servicio.modificarContrasenia(txtNickname.Text, txtContrasenia.Text); 
            }

            if(txtNickname.Text != "" && txtCorreo.Text != ""){

                Label3.Text = servicio.modificarCorreo(txtNickname.Text, txtCorreo.Text);
            }
            this.crearGrafo(servicio.invocarGrafo(), "Arbol");

            this.crearGrafo(servicio.ArbolEspejo(), "ArbolE");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if(txtNickname.Text != "")
            {
                Label10.Text = servicio.eliminarUsuario(txtNickname.Text);

            }
            this.crearGrafo(servicio.invocarGrafo(), "Arbol");
            this.crearGrafo(servicio.ArbolEspejo(), "ArbolE");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (txtNickJuego.Text != "" && txtNicO.Text != "" && txtNicoNuevo.Text != "")
            {
                Label13.Text = servicio.modNickO(txtNickJuego.Text, txtNicO.Text, txtNicoNuevo.Text);
            }

            if(txtNicO.Text != "" && txtNickJuego.Text != "" && txtDesplegada.Text != "")
            {
                int desplegada = Convert.ToInt32(txtDesplegada.Text);
                Label8.Text = servicio.modDesp(txtNickJuego.Text, txtNicO.Text, desplegada);
            }

            if (txtNickJuego.Text != "" && txtNicO.Text != "" && txtDest.Text != "")
            {
                int dest = Convert.ToInt32(txtDest.Text);
                Label9.Text = servicio.modDest(txtNickJuego.Text, txtNicO.Text, dest);
            }

            if (txtNickJuego.Text != "" && txtNicO.Text != "" && txtSobreviviente.Text != "")
            {
                int sob = Convert.ToInt32(txtSobreviviente.Text);
                Label11.Text = servicio.modSob(txtNickJuego.Text, txtNicO.Text, sob);
            }

            string ganar = DropDownList1.SelectedItem.ToString();
            if (ganar == "Perdio")
            
                Label12.Text = servicio.modgana(txtNickJuego.Text, txtNicO.Text, false);
            
            else 
            
                Label12.Text = servicio.modgana(txtNickJuego.Text, txtNicO.Text, true);

            this.crearGrafo(servicio.invocarGrafo(), "Arbol");
            this.crearGrafo(servicio.ArbolEspejo(), "ArbolE");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (txtNickJuego.Text != "" && txtNicO.Text != "")
            {
                Label10.Text = servicio.eliminarJuego(txtNickJuego.Text, txtNicO.Text);
            }

            this.crearGrafo(servicio.invocarGrafo(), "Arbol");
            this.crearGrafo(servicio.ArbolEspejo(), "ArbolE");
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            try
            {
                int fila = Convert.ToInt32(txtFila.Text);
                string columna = txtColumna.Text;
                int nivel = Convert.ToInt32(txtNivel.Text);

                servicio.eliminarPieza(fila, columna, nivel);
                this.crearGrafo(servicio.grafoMatriz(1),"Matriz1");
                this.crearGrafo(servicio.grafoMatriz(2), "Matriz2");
                this.crearGrafo(servicio.grafoMatriz(3), "Matriz3");
                this.crearGrafo(servicio.grafoMatriz(4), "Matriz4");
                Label16.Text = "LA PIEZA HA SIDO ELIMINADA";
            }
            catch 
            {
                Label16.Text = "ERROR FATAK :v y Ella no te ama";
              
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
        protected void Button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtColumna.Text != "" && txtFila.Text != "" && txtColDest.Text != "" && txtDestinoFila.Text != "" && txtNivel.Text != "")
                {
                    string col = txtColumna.Text;
                    int fila = int.Parse(txtFila.Text);
                    string colD = txtColDest.Text;
                    int filaD = int.Parse(txtDestinoFila.Text);
                    int lvl = int.Parse(txtNivel.Text);
                    servicio.moverPieza(col, fila, lvl, colD, filaD, lvl);
                    Label21.Text = "La pieza ha sido movida";

                    this.crearGrafo(servicio.grafoMatriz(1), "Matriz1");
                    this.crearGrafo(servicio.grafoMatriz(2), "Matriz2");
                    this.crearGrafo(servicio.grafoMatriz(3), "Matriz3");
                    this.crearGrafo(servicio.grafoMatriz(4), "Matriz4");
                }

            }
            catch 
            {
                Label21.Text = "ERROR FATAL";
            }
            
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            if (txtNick.Text != "" && txtColumna.Text != "")
            {
                servicio.eliminarContacto(txtNick.Text, txtColumna.Text);
               
                Label20.Text = "Contacto Eliminado";
            }

        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            if (txtNick.Text != "" && txtContacto.Text != "" && TextBox2.Text != "" && TextBox3.Text != "")
            {
                Label20.Text = servicio.insertarContacto(txtNick.Text, txtColumna.Text, TextBox2.Text, TextBox3.Text);
            }
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            if (txtNick.Text != "" && txtContacto.Text != "" && txtContactNew.Text != "")
            {
                servicio.modificarContacto(txtNick.Text, txtContacto.Text, txtContactNew.Text);
                Label20.Text = "Modificado contacto nuevo";
            }

            if (txtNick.Text != "" && txtContacto.Text != "" && TextBox2.Text != "")
            {
                servicio.modificarContraseniaContacto(txtNick.Text, txtContacto.Text, TextBox2.Text);
                Label18.Text = "Contrasenia Modificada";

            }

            if (txtNick.Text != "" && txtContacto.Text != "" && TextBox3.Text != "")
            {
                servicio.modificarCorreoContacto(txtNick.Text, txtContacto.Text, TextBox3.Text);
                Label19.Text = "Correo Modificado";

            }
        }
    }
}