using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ledenbeheer
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResultaat_Click(object sender, EventArgs e)
        {
            string naam = txtNaam.Text;
            decimal bijdrage = Convert.ToDecimal(txtBijdrage.Text);
            decimal totaal = 0.0M;

            if (Session["totaal"] != null)
                totaal = (decimal)Session["totaal"];

            totaal += bijdrage;

            Session["totaal"] = totaal;
            Session["lid"] = new Lid(naam, bijdrage);

            Response.Redirect("Resultaat.aspx");
        }
    }
}