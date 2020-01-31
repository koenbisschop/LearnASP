using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ledenbeheer
{
    public partial class Resultaat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal totaal = (decimal)Session["totaal"];
            Lid lid = (Lid) Session["lid"];
            lblLid.Text = lid.ToString();
            lblTotaal.Text = totaal.ToString("0.0")+"€";
        }
        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}