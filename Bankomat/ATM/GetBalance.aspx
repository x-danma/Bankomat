<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetBalance.aspx.cs" Inherits="ATM.GetBalance" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="softButtonWrapper">
        <asp:Button ID="button1Left" runat="server" Text=" " CssClass="buttonLeft" />
        <asp:Button ID="button2Left" runat="server" Text=" " CssClass="buttonLeft" />
        <asp:Button ID="button3Left" runat="server" Text=" " CssClass="buttonLeft" OnClick="button3Left_Click" />
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
            <h1>Saldo</h1>
            <br />

            Ditt saldo är:
            <br />
            <asp:Label ID="LabelBalance" runat="server" Text="Label"></asp:Label>
            <br /><br />
            <asp:Panel ID="PanelTransactions" runat="server">
            </asp:Panel>



        </div>

        <div class="softRightButtonTypeWrapper">
            <div class="softSoft">5 senaste</div>
            <div class="softSoft">Skriv ut 25 senaste</div>
            <div class="softSoft"></div>
            <div class="softSoft"></div>
        </div>
    </div>

    <div class="softRightButtonWrapper">
        <asp:Button ID="button1Right" runat="server" Text=" " CssClass="buttonRight" OnClick="button1Right_Click" />
        <asp:Button ID="button2Right" runat="server" Text=" " CssClass="buttonRight" OnClick="button2Right_Click" />
        <asp:Button ID="button3Right" runat="server" Text=" " CssClass="buttonRight" OnClick="button3Right_Click" />
        <asp:Button ID="button4Right" runat="server" Text=" " CssClass="buttonRight" OnClick="button4Right_Click" />
    </div>


</asp:Content>
