using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ledenbeheer.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                foutboodschap.Text = "";
                foutboodschap.Visible = false;
            }
        }

        protected void btnAanmelden_Click(object sender, EventArgs e)
        {
            //Aanmelden
            if (gebruikersnaam.Value != "test")
            {
                foutboodschap.Text = "Foutieve aanmeldpoging!";
                foutboodschap.Visible = true;
            }
            else
            {
                Session["User"] = gebruikersnaam.Value;
                FormsAuthentication.RedirectFromLoginPage(gebruikersnaam.Value, false);
            }
        }
    }
}