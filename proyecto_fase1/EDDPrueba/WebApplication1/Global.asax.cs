﻿using System;
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
            webServicePrueba.Service1Client serv = new webServicePrueba.Service1Client();
            Application["WebServer"] = serv;

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application["contn1"] = 0;
            Application["contn2"] = 0;
            Application["contn3"] = 0;
            Application["contn4"] = 0;

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