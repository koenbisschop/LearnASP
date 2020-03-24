<%@ Page Title="" Language="C#" MasterPageFile="~/LedenMaster.Master" AutoEventWireup="true" CodeBehind="Dropdown.aspx.cs" Inherits="Ledenbeheer.Dropdown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container table-responsive" style="width: 80%; margin-left: auto; margin-right: auto;">
        <asp:DropDownList ID="ddlLeden" runat="server" OnSelectedIndexChanged="ddlLeden_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="grvBijdragenLid" DataKeyNames="Datum" CssClass="col-sm-12" Style="width: 90%; top: 0px; left: 0px;" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="grvBijdragenLid_RowCancelingEdit" OnRowEditing="grvBijdragenLid_RowEditing" OnRowUpdating="grvBijdragenLid_RowUpdating" OnRowDeleting="grvBijdragenLid_RowDeleting" OnRowDataBound="grvBijdragenLid_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Datum">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDatum" runat="server" Text='<%# Bind("Datum","0:dd-MM-yyyy") %>' TextMode="Date"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Datum", "{0:dd-MM-yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="30%" />
                </asp:TemplateField>
                <asp:BoundField DataField="Bedrag" DataFormatString="{0:c2}" HeaderText="Bedrag">
                    <ItemStyle Width="15%" HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Project">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlProjecten" runat="server" Height="24px" Width="221px" AppendDataBoundItems="True" DataSourceID="odsProjecten" DataTextField="Omschrijving" DataValueField="Id" ItemType="LedenBeheerDomain.Project" SelectedValue='<%# Bind("ProjectId") %>'>
                            <asp:ListItem Text="-- undefined --" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsProjecten" runat="server" SelectMethod="GetProjecten" TypeName="LedenbeheerDomain.Business.Controller"></asp:ObjectDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Project.Omschrijving") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="40%" />
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowEditButton="True">
                    <ItemStyle Width="20%" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label><br />
        <br />
        <asp:Button ID="btnTerug" runat="server" Text="Terug" OnClick="btnTerug_Click" />
    </div>

</asp:Content>
