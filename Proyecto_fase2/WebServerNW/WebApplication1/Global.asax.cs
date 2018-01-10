using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            webServiceNW.ProyectoEDD servicio = new webServiceNW.ProyectoEDD();
            Application["usuario1"] = "vacio1";
            Application["usuario2"] = "vacio2";
            Application["WebServer"] = servicio;
            Application["n1"] = 0;
            Application["n2"] = 0;
            Application["n3"] = 0;
            Application["n4"] = 0;
            Application["lC"] = 0;
            Application["lF"] = 0;
            Application["tipo"] = 0;
            Application["tiempo"] = "no hay";

            Application["contn1"] = 0;
            Application["contn2"] = 0;
            Application["contn3"] = 0;
            Application["contn4"] = 0;


            Application["cont2n1"] = 0;
            Application["cont2n2"] = 0;
            Application["cont2n3"] = 0;
            Application["cont2n4"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application["hora"] = -1;
            Application["minutos"] = -1;
            Application["segundos"] = -1;

            Application["listo"] = 0;
            Application["listo2"] = 0;

            Application["hora2"] = -1;
            Application["minutos2"] = -1;
            Application["segundos2"] = -1;

            Application["BASE"] = 1;
            Application["BASE2"] = 1;

            Application["contU"] = 0;
            Application["contD"] = 0;
            Application["contS"] = 0;

            Application["contAtack"] = 0;
            Application["contAtack2"] = 0;

            Application["contU2"] = 0;
            Application["contD2"] = 0;
            Application["contS2"] = 0;

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}