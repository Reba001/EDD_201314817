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
        webServiceNW.ProyectoEDD serv;
        protected void Page_Load(object sender, EventArgs e)
        {
            serv = (webServiceNW.ProyectoEDD)Application["WebServer"];
            if (Session["usuarioAdmin"] != null)
            {
                lblUser.Text = Session["usuarioAdmin"].ToString();
            }
            else 
            {
                Response.Redirect("Login.aspx");
            }
            
            
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