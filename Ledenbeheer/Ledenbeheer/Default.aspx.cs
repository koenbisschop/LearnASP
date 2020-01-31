using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LedenbeheerDomain.Business;

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
            if (naam != "")
            {

                Controller c;
                if (Session["controller"] == null)
                    c = new Controller();
                else
                    c = (Controller)Session["controller"];
                c.NieuweBijdrage(naam, bijdrage);
            }
            Response.Redirect("Resultaat.aspx");
        }
    }
}