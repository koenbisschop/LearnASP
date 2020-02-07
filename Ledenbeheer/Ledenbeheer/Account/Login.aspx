﻿<%@ Page Title="" Language="C#" MasterPageFile="~/LedenMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Ledenbeheer.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-horizontal">
        <fieldset class="container">
            <legend class="col-sm-offset-2">Aanmelden</legend>
            <div class="form-group has-success">
                <label for="gebruikersnaam" class="control-label col-sm-2">
                    Gebruikersnaam:
                </label>
                <div class="col-sm-4">
                    <input class="form-control" type="text" required="required"
                        placeholder="gebruikersnaam" id="gebruikersnaam" runat="server"
                        />
                </div>
            </div>
            <div class="form-group justify-content-center">
                <label for="paswoord" class="control-label col-sm-2">
                    Paswoord:
                </label>
                <div class="col-sm-4">
                    <input class="form-control" type="password" 
                        placeholder="paswoord" id="paswoord" runat="server"  />
                </div>
            </div>
            <div class="form-group" style="margin-top: 25px">
                <asp:Label ID="foutboodschap" EnableViewState="False" runat="server" 
                    visible="false" CssClass="alert alert-danger justify-content-center">
                </asp:Label>
            </div>
            <div class="form-group">
                <asp:Button ID="btnAanmelden"  runat="server" 
                    Text="Aanmelden"  CssClass="btn btn-primary justify-content-center" OnClick="btnAanmelden_Click"/>
            </div>
        </fieldset>
    </div>
</asp:Content>
