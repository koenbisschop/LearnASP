using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LedenbeheerDomain.Business;

namespace Ledenbeheer
{
    public partial class Resultaat1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller c = (Controller)Session["controller"];
            grvBijdragen.DataSource = c.GetLeden();
            grvBijdragen.DataBind();
            lblTotaal.Text = "Totaal bijdragen: " + BerekenTotaal(c.GetLeden()).ToString("c2");
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