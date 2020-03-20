<%@ Page Title="" Language="C#" MasterPageFile="~/LedenMaster.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Ledenbeheer.DefaultError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-danger mx-auto" style="width:80%">
        <h1>404</h1>
        <p>Oops... something went wrong!</p>
        <p><asp:Label ID="lblErrorMessage" runat="server" class="alert alert-danger" Text=""></asp:Label></p>
        <p> Press the button to go back to the previous page.</p>
        <input type="button" class="btn btn-danger" id="btnTerug" value="Go Back"  onClick="history.go(-1); return false;" />
    </div>
</asp:Content>
