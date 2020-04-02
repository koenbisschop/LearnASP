using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using LedenbeheerDomain.Business;

namespace Ledenbeheer
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/jquery-3.4.1.slim.js"
                }
                );
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "popper",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/popper.min.js"
                }
                );
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "bootstrap",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/bootstrap.min.js"
                }
                );
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Controller c = new Controller();
            Session["controller"] = c;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs.

            // Get last error from the server
            Exception exc = Server.GetLastError();

            if (exc is HttpUnhandledException)
            {
                if (exc.InnerException != null)
                {
                    exc = new Exception(exc.InnerException.Message);
                    Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax",
                        true);
                }
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}