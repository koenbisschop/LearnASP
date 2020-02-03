<%@ Page Title="" Language="C#" MasterPageFile="~/LedenMaster.Master" AutoEventWireup="true" CodeBehind="Dropdown.aspx.cs" Inherits="Ledenbeheer.Dropdown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container table-responsive" style="width:80%;margin-left: auto;margin-right: auto;">
        <asp:DropDownList ID="ddlLeden" runat="server" OnSelectedIndexChanged="ddlLeden_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="grvBijdragenLid" CssClass="col-sm-12" Style="width:20%;" runat="server" EnableViewState="False" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Datum" HeaderText="Datum" DataFormatString="{0:ddd d-M-yy}" >
                    <ItemStyle Width="50%" />
                </asp:BoundField>
                <asp:BoundField DataField="Bedrag" DataFormatString="{0:c2}" HeaderText="Bedrag">
                    <ItemStyle Width="50%" HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label><br />
        <br />
        <asp:Button ID="btnTerug" runat="server" Text="Terug" OnClick="btnTerug_Click" />
    </div>

</asp:Content>
