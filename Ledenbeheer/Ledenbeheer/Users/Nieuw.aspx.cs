using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LedenbeheerDomain.Business;

namespace Ledenbeheer
{
    public partial class Nieuw : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Controller c = (Controller)Session["controller"];
                ddlProjecten.DataSource = c.GetProjecten();
                ddlProjecten.DataTextField = "Omschrijving";
                ddlProjecten.DataValueField = "Id";
                ddlProjecten.DataBind();
            }
        }

        protected void btnResultaat_Click(object sender, EventArgs e)
        {
            Controller c = (Controller)Session["controller"];
            string naam = txtNaam.Value;
            decimal bijdrage = Convert.ToDecimal(txtBijdrage.Value);
            int projectid = Convert.ToInt32(ddlProjecten.SelectedValue);
            if (naam != "")
            {
                c.NieuweBijdrage(naam, bijdrage, projectid);
            }
            Response.Redirect("~/Users/Resultaat.aspx");
        }
    }
}