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
            List<Lid> ledenLijst;
            if (Session["Bijdragen"] == null)
                ledenLijst = new List<Lid>();
            else
                ledenLijst = (List<Lid>)Session["Bijdragen"];
            grvBijdragen.DataSource = ledenLijst;
            grvBijdragen.DataBind();
            lblTotaal.Text = BerekenTotaal(ledenLijst).ToString();
        }
        public decimal BerekenTotaal(List<Lid> leden)
        {
            decimal totaal = 0.0M;
            foreach (Lid lid in leden)
            {
                totaal += lid.Bijdrage;
            }
            return totaal;
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}