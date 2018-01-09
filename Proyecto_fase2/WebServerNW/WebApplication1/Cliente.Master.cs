using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Cliente : System.Web.UI.MasterPage
    {
        webServiceNW.ProyectoEDD serv = new webServiceNW.ProyectoEDD();
        protected void Page_Load(object sender, EventArgs e)
        {
            String user = (String)Session["usuario1"];
            if (user != null)
            {
                lblUser.Text = user;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void lbtLogout_Click(object sender, EventArgs e)
        {
            string usuario = Session["usuario1"].ToString();
            serv.modificarEstad(usuario, false);
            Session.Remove("usuario1");
            Response.Redirect("Login.aspx");
        }
    }
}