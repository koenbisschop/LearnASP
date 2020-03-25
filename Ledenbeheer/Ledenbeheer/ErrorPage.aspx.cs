using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ledenbeheer
{
    public partial class DefaultError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create error messages.
            string generalErrorMsg = "A problem has occurred on this web site.";
            string httpErrorMsg = "An HTTP error occurred. Page Not found. Please try again.";
            string unhandledErrorMsg = "The error was unhandled by application code.";

            // Heading of the error page
            FriendlyErrorMsg.Text = generalErrorMsg;

            // Show which page fired the error
            string errorHandler = Request.QueryString["handler"];
            if (errorHandler == null)
            {
                errorHandler = "Error Page";
            }
            ErrorHandler.Text = errorHandler;

            // Determine what went wrong
            // Get the last error from the server.
            Exception ex = Server.GetLastError();
            // Get the error number passed as a querystring value.
            string errorMsg = Request.QueryString["msg"];
            if (errorMsg == "404")
            {
                ex = new HttpException(404, httpErrorMsg, ex);
            }
            // If no exception was thrown, create a generic exception.
            if (ex == null)
                ex = new Exception(unhandledErrorMsg);

            // Show Detailed Error Info.
            ErrorDetailedMsg.Text = ex.Message;
            InnerMessage.Text = ex.GetType().ToString();
            if (ex.StackTrace != null)
            {
                InnerTrace.Text = ex.StackTrace.ToString().TrimStart();
            }
            // Clear the error from the server.
            Server.ClearError();
        }
    }
}