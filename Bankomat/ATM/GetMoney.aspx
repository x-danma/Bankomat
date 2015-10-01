<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetMoney.aspx.cs" Inherits="ATM.GetMoney" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="softButtonWrapper">
        <asp:Button ID="button1Left" runat="server" Text=" " CssClass="buttonLeft" />
        <asp:Button ID="button2Left" runat="server" Text=" " CssClass="buttonLeft" OnClick="button2Left_Click" />
        <asp:Button ID="button3Left" runat="server" Text=" " CssClass="buttonLeft" OnClick="button3Left_Click" />
        <asp:Button ID="button4Left" runat="server" Text=" " CssClass="buttonLeft" OnClick="button4Left_Click" />
    </div>


    <div class="atmScreen">
        <div class="softButtonTypeWrapper">
            <div class="softSoft">Uttag</div>
            <div class="softSoft">Saldo</div>
            <div class="softSoft">Avbryt</div>
            <div class="softSoft">Ångra</div>
        </div>
        <div class="infoBox">

            <h1>Uttag</h1>
            <asp:Label ID="getMoneyMessage" runat="server" Visible="False" Font-Size="Large" ForeColor="Red"></asp:Label><br />
            Välj önskat belopp på knapparna eller skriv in belopp från knappsatsen.<br />

            <asp:TextBox ID="inputField" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
        </div>

        <div class="softRightButtonTypeWrapper">
            <div class="softSoft">100</div>
            <div class="softSoft">300</div>
            <div class="softSoft">500</div>
            <div class="softSoft">OK</div>
        </div>
    </div>

    <div class="softRightButtonWrapper">
        <asp:Button ID="button1Right" runat="server" Text=" " CssClass="buttonRight" OnClick="button1Right_Click" />
        <asp:Button ID="button2Right" runat="server" Text=" " CssClass="buttonRight" OnClick="button2Right_Click" />
        <asp:Button ID="button3Right" runat="server" Text=" " CssClass="buttonRight" OnClick="button3Right_Click" />
        <asp:Button ID="button4Right" runat="server" Text=" " CssClass="buttonRight" OnClick="button4Right_Click" />
    </div>


</asp:Content>
