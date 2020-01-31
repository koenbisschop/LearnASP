<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ledenbeheer.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="stijlen.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label">Naam:</asp:Label>
            <asp:TextBox ID="txtNaam" required="required" runat="server"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" Text="Label">Bijdrage:</asp:Label>
            <asp:TextBox ID="txtBijdrage" required="required" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnResultaat" runat="server" Text="Resultaat" OnClick="btnResultaat_Click" />
        </div>
    </form>
</body>
</html>
