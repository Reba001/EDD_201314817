using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        webServicePrueba.Service1Client serv;
        protected void Page_Load(object sender, EventArgs e)
        {
            serv = (webServicePrueba.Service1Client)Application["WebServer"];
            lblUser.Text = Session["usuarioAdmin"].ToString();
            
            
        }

        protected void lbtLogout_Click(object sender, EventArgs e)
        {
            string usuario = Session["usuarioAdmin"].ToString();
            serv.modificarEstad(usuario, false);
            Session.Remove("usuarioAdmin");
            Response.Redirect("Login.aspx");

        }
    }
}