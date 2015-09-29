<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetMoney.aspx.cs" Inherits="ATM.GetMoney" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="softButtonWrapper">
        <asp:Button ID="button1Left" runat="server" Text=" " CssClass="buttonLeft" OnClick="button1Left_Click" />
        <asp:Button ID="button2Left" runat="server" Text=" " CssClass="buttonLeft" />
        <asp:Button ID="button3Left" runat="server" Text=" " CssClass="buttonLeft" />
        <asp:Button ID="button4Left" runat="server" Text=" " CssClass="buttonLeft" />
    </div>


    <div class="atmScreen">
        <div class="infoBox">
            <div class="softButtonTypeWrapper">
            <div class="softSoft">Uttag</div>
            <div class="softSoft">Saldo</div>
            <div class="softSoft">Abryt</div>
            <div class="softSoft">Något?</div>
            </div>
            <h1>Uttag</h1>
            Välj önskat belopp på knappaarna eller skriv in belopp från knappsatsen.<br />
            <asp:TextBox ID="loginField" runat="server"></asp:TextBox>
        </div>

        <div class="softRightButtonTypeWrapper">
            <div class="softSoft">100</div>
            <div class="softSoft">200</div>
            <div class="softSoft">300</div>
            <div class="softSoft">400</div>
        </div>
    </div>

    <div class="softRightButtonWrapper">
        <asp:Button ID="button1Right" runat="server" Text=" " CssClass="buttonRight" />
        <asp:Button ID="button2Right" runat="server" Text=" " CssClass="buttonRight" />
        <asp:Button ID="button3Right" runat="server" Text=" " CssClass="buttonRight" />
        <asp:Button ID="button4Right" runat="server" Text=" " CssClass="buttonRight" />
    </div>


</asp:Content>
