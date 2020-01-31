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
            List<Lid> ledenLijst;
            if (naam != "")
            {
                if (Session["Bijdragen"] == null)
                    ledenLijst = new List<Lid>();
                else
                    ledenLijst = (List<Lid>)Session["Bijdragen"];
                ledenLijst.Add(new Lid(naam, bijdrage));
                Session["Bijdragen"] = ledenLijst;
            }

            Response.Redirect("Resultaat.aspx");
        }
    }
}