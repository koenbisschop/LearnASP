<%@ Page Title="" Language="C#" MasterPageFile="~/LedenMaster.Master" AutoEventWireup="true" CodeBehind="Resultaat.aspx.cs" Inherits="Ledenbeheer.Resultaat1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:GridView ID="grvBijdragen" runat="server" EnableViewState="False"></asp:GridView><br />
        <asp:Label ID="lblTotaal" runat="server" Text="Label">Totaal bijdragen: 0€</asp:Label><br /><br />
        <asp:Button ID="btnTerug" runat="server" Text="Terug" OnClick="btnTerug_Click" />
    </div>
</asp:Content>
