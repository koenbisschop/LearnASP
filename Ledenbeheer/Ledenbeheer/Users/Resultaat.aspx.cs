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
        Controller c;
        List<Lid> ledenLijst;
        protected void Page_Load(object sender, EventArgs e)
        {
            c = (Controller)Session["controller"];
            ledenLijst = c.GetLeden();
            grvBijdragen.DataSource = ledenLijst;
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

        protected void grvBijdragen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 lidNr = (Int32) grvBijdragen.SelectedValue;
            Session["lidnr"] = lidNr;
            Response.Redirect("DropDown.aspx");
        }

        protected void grvBijdragen_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 rijNr = e.RowIndex;
            GridViewRow row = grvBijdragen.Rows[rijNr];
            Int32 ledenLijstIndex = row.DataItemIndex;
            Int32 lidNr = ledenLijst[ledenLijstIndex].Id;
            //ofwel: Int32 lidNr = (Int32) grvBijdragen.DataKeys[ledenLijstIndex].Value;
            c.RemoveLid(lidNr);
            grvBijdragen.DataBind();
            //totaal inkomsten is gewijzigd!
            lblTotaal.Text = "Totaal bijdragen: " + BerekenTotaal(c.GetLeden()).ToString("c2");
        }

        protected void grvBijdragen_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvBijdragen.EditIndex = e.NewEditIndex;
            grvBijdragen.DataBind();
        }

        protected void grvBijdragen_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grvBijdragen.Rows[e.RowIndex];
            //welk lid werd aangepast?
            Lid lid = ledenLijst[row.DataItemIndex];
            //wat is de nieuwe naam?
            string nieuweNaam = ((TextBox)row.Cells[1].Controls[0]).Text; //0=Id; 1=Naam
            c.ChangeLid(lid.Id, nieuweNaam);
            //reset the edit index
            grvBijdragen.EditIndex = -1;
            grvBijdragen.DataBind();
        }

        protected void grvBijdragen_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //reset the edit index
            grvBijdragen.EditIndex = -1;
            grvBijdragen.DataBind();
        }
    }
}