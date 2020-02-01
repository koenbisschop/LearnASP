<%@ Page Title="" Language="C#" MasterPageFile="~/LedenMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ledenbeheer.Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label">Naam:</asp:Label>
        <asp:TextBox ID="txtNaam" required="required" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Label">Bijdrage:</asp:Label>
        <asp:TextBox ID="txtBijdrage" required="required" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnResultaat" runat="server" Text="Resultaat" OnClick="btnResultaat_Click" />
    </div>
</asp:Content>
