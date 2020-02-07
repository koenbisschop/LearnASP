﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resultaat.aspx.cs" Inherits="Ledenbeheer.Resultaat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="stijlen.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
           <asp:GridView ID="grvBijdragen" runat="server" EnableViewState="False" EnablePaging="True" PageSize="5" AllowPaging="True" OnPageIndexChanging="grvBijdragen_PageIndexChanging">
                <PagerSettings Mode="NextPreviousFirstLast" />
                <PagerStyle BackColor="#FFFFCC" />
            </asp:GridView><br />
            <asp:Label ID="lblTotaal" runat="server" Text="Label">Totaal bijdragen: 0€</asp:Label><br /><br />
            <asp:Button ID="btnTerug" runat="server" Text="Terug" OnClick="btnTerug_Click" />
        </div>
    </form>
</body>
</html>
