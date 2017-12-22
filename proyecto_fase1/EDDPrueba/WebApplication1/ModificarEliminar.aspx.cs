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
                Label1.Text = servicio.eliminarUsuario(txtNickname.Text);

            }
            servicio.invocarGrafo();
        }
    }
}