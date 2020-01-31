using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LedenbeheerDomain.Business;

namespace Ledenbeheer
{
    public partial class Resultaat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller c = new Controller();
            grvBijdragen.DataSource = c.GetLeden();
            grvBijdragen.DataBind();
            lblTotaal.Text = BerekenTotaal(c.GetLeden()).ToString();
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