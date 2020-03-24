using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LedenbeheerDomain.Business;

namespace Ledenbeheer
{
    public partial class Dropdown : System.Web.UI.Page
    {
        Controller c;
        protected void Page_Load(object sender, EventArgs e)
        {
            c = (Controller)Session["controller"];
            if (!IsPostBack)
            {
                ddlLeden.DataSource = c.GetLeden();
                ddlLeden.DataTextField = "Naam";
                ddlLeden.DataValueField = "Id";
                ddlLeden.DataBind();
                ToonInfo(Convert.ToInt32(ddlLeden.SelectedValue));
            }
            if (Session["lidnr"] != null)
            {
                //haal het geselecteerde lidnr op in de session-ruimte
                Int32 lidNr = (Int32)Session["lidnr"];
                //deze sessievariabele verwijderen!
                Session["lidnr"] = null;
                //haal het lid-item op in de dropdownlist
                ListItem item = ddlLeden.Items.FindByValue(lidNr.ToString());
                //stel de index van de dropdownlist in op dit item 
                ddlLeden.SelectedIndex = ddlLeden.Items.IndexOf(item);
                ToonInfo(Convert.ToInt32(ddlLeden.SelectedValue));
            }
        }

        protected void ToonInfo(Int32 id = 0)
        {
            Lid lid = c.GetLid(id); //of beter: id!=0 ? c.GetLid(id) : null;
            if (lid != null)
            {
                grvBijdragenLid.DataSource = lid.Bijdragen;
                grvBijdragenLid.DataBind();
                lblInfo.Text = lid.ToString();
            }
            else
            {
                grvBijdragenLid.DataSource = null;
                lblInfo.Text = "";
            }
        }



        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ddlLeden_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToonInfo(Convert.ToInt32(ddlLeden.SelectedValue));
        }

        protected void grvBijdragenLid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvBijdragenLid.EditIndex = e.NewEditIndex;
            ToonInfo(Convert.ToInt32(ddlLeden.SelectedValue));
        }

        protected void grvBijdragenLid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvBijdragenLid.EditIndex = -1;
            ToonInfo(Convert.ToInt32(ddlLeden.SelectedValue));
        }

        protected void grvBijdragenLid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int lidId = Convert.ToInt32(ddlLeden.SelectedValue);
            GridViewRow row = grvBijdragenLid.Rows[e.RowIndex];
            DropDownList ddlProjecten = (DropDownList)row.FindControl("ddlProjecten");
            int projectId = Convert.ToInt32(ddlProjecten.SelectedValue);
            decimal bedrag = Convert.ToDecimal(((TextBox)row.Cells[1].Controls[0]).Text);
            //ofwel:
            //decimal bedrag = Convert.ToDecimal(e.NewValues["Bedrag"]);
            DateTime datum = (DateTime)grvBijdragenLid.DataKeys[e.RowIndex][0];
            c.WijzigBijdrage(lidId, datum, bedrag, projectId);
            grvBijdragenLid.EditIndex = -1;
            ToonInfo(Convert.ToInt32(ddlLeden.SelectedValue));
        }

        protected void grvBijdragenLid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 rowIndex = e.RowIndex;
            Int32 dataItemIndex = grvBijdragenLid.Rows[rowIndex].DataItemIndex;
            DateTime datum = (DateTime)grvBijdragenLid.DataKeys[dataItemIndex][0];
            Int32 lidId = Convert.ToInt32(ddlLeden.SelectedValue);
            c.VerwijderBijdrage(lidId, datum);
            ToonInfo(lidId);
        }

    }
}