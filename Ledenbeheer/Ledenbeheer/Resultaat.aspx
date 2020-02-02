<%@ Page Title="" Language="C#" MasterPageFile="~/LedenMaster.Master" AutoEventWireup="true" CodeBehind="Resultaat.aspx.cs" Inherits="Ledenbeheer.Resultaat1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table table-borderless table-hover table-responsive table-striped">
        <asp:GridView ID="grvBijdragen" CssClass="col-sm-12" Style="margin: auto; width: 50%;" runat="server" EnableViewState="False" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Naam" HeaderText="Naam">
                    <ItemStyle Width="40%" />
                </asp:BoundField>
                <asp:BoundField DataField="Bijdrage" DataFormatString="{0:c2}" HeaderText="Bijdrage">
                    <ItemStyle Width="20%" HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <br />
        <div style="width: 200px;" class="mx-auto">
            <asp:Label ID="lblTotaal" runat="server" Text="Label">Totaal bijdragen: 0€</asp:Label><br />
        </div>
        <div style="width: 200px;" class="mx-auto">
            <asp:Button Style="width: 200px;" CssClass="mx-auto" ID="btnTerug" runat="server" Text="Terug" OnClick="btnTerug_Click" />
        </div>
    </div>
</asp:Content>
