<%@ Page Title="" Language="C#" MasterPageFile="~/LedenMaster.Master" AutoEventWireup="true" CodeBehind="Nieuw.aspx.cs" Inherits="Ledenbeheer.Nieuw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-sm-10" style="width:80%; margin:10px auto 10px auto">
        <div class="form-group">
            <label for="txtNaam">Naam</label>
            <input type="text" required="required" runat="server" class="form-control" id="txtNaam" placeholder="jouw naam">
        </div>
        <div class="form-group">
            <label for="txtBijdrage">Bijdrage</label>
            <input type="number" runat="server" required="required" class="form-control" id="txtBijdrage">
        </div>
        <asp:Button Id="btnResultaat" runat="server" CssClass="btn btn-primary" OnClick="btnResultaat_Click" Text="Resultaat" />
    </div>
</asp:Content>
