﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATM._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="softButtonWrapper">
        <asp:Button ID="button1Left" runat="server" Text=" " CssClass="buttonLeft" />
        <asp:Button ID="button2Left" runat="server" Text=" " CssClass="buttonLeft" />
        <asp:Button ID="button3Left" runat="server" Text=" " CssClass="buttonLeft" />
        <asp:Button ID="button4Left" runat="server" Text=" " CssClass="buttonLeft" />
    </div>
    <div class="atmScreen">
        <div class="softButtonTypeWrapper">
            
            </div>
        <div class="infoBox">
            <h1>Välkommen</h1>
            Sätt in ditt kort i kortläsaren.<br />
 
        </div>

        <div class="softRightButtonTypeWrapper">
            
        </div>


    </div>

    <div class="softRightButtonWrapper">
        <asp:Button ID="button1Right" runat="server" Text=" " CssClass="buttonRight" />
        <asp:Button ID="button2Right" runat="server" Text=" " CssClass="buttonRight" />
        <asp:Button ID="button3Right" runat="server" Text=" " CssClass="buttonRight" />
        <asp:Button ID="button4Right" runat="server" Text=" " CssClass="buttonRight" />
    </div>
    <div id="moveCard" class="moveCard">Bankkort</div>

</asp:Content>
