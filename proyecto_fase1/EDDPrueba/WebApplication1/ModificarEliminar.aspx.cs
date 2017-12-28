using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ModificarEliminar : System.Web.UI.Page
    {
        webServicePrueba.Service1Client servicio;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            servicio = (webServicePrueba.Service1Client)Application["WebServer"];
           
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
            servicio.invocarGrafo();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if(txtNickname.Text != "")
            {
                Label10.Text = servicio.eliminarUsuario(txtNickname.Text);

            }
            servicio.invocarGrafo();
            servicio.ArbolEspejo();
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

            servicio.invocarGrafo();
            servicio.ArbolEspejo();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (txtNickJuego.Text != "" && txtNicO.Text != "")
            {
                Label10.Text = servicio.eliminarJuego(txtNickJuego.Text, txtNicO.Text);
            }

            servicio.invocarGrafo();
            servicio.ArbolEspejo();
        }
    }
}