<%@ Page Title="" Language="C#" MasterPageFile="~/LedenMaster.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Ledenbeheer.DefaultError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-danger mx-auto" style="width: 80%">
        <asp:Label ID="FriendlyErrorMsg" class="alert alert-danger" runat="server" Text="" Font-Size="Large" Style="color: red"></asp:Label>
        <p>&nbsp;</p>
        <h4>Detailed Error:</h4>
        <p>
            <asp:Label ID="ErrorDetailedMsg" runat="server" Font-Size="Small" /><br />
        </p>
        <h4>Error Handler:</h4>
        <p>
            <asp:Label ID="ErrorHandler" runat="server" Font-Size="Small" /><br />
        </p>
        <h4>Detailed Error Message:</h4>
        <p>
            <asp:Label ID="InnerMessage" runat="server" Font-Size="Small" /><br />
        </p>
        <p>
            <asp:Label ID="InnerTrace" runat="server" />
        </p>
        <p>Press the button to go back to the previous page.</p>
        <input type="button" class="btn btn-danger" id="btnTerug" value="Go Back" onclick="history.go(-1); return false;" />
    </div>
</asp:Content>
