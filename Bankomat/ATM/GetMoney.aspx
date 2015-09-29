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
            <div class="softButtonWrapper">
                <asp:Button ID="button5" runat="server" Text="100" CssClass="buttonLeft" Enabled="false" />
                <asp:Button ID="button6" runat="server" Text="200" CssClass="buttonLeft" Enabled="false" />
                <asp:Button ID="button7" runat="server" Text="500" CssClass="buttonLeft" Enabled="false" />
                <asp:Button ID="button8" runat="server" Text="100" CssClass="buttonLeft" Enabled="false" />
            </div>
            <h1>Uttag</h1>
            Välj önskat belopp på knappaarna eller skriv in belopp från knappsatsen.<br />
            <asp:TextBox ID="loginField" runat="server"></asp:TextBox>
        </div>

        <div class="softRightButtonWrapper">
            <asp:Button ID="button1" runat="server" Text="100" CssClass="buttonLeft" Enabled="false" />
            <asp:Button ID="button2" runat="server" Text="200" CssClass="buttonLeft" Enabled="false" />
            <asp:Button ID="button3" runat="server" Text="500" CssClass="buttonLeft" Enabled="false" />
            <asp:Button ID="button4" runat="server" Text="100" CssClass="buttonLeft" Enabled="false" />
        </div>
    </div>

    <div class="softRightButtonWrapper">
        <asp:Button ID="button1Right" runat="server" Text=" " CssClass="buttonRight" />
        <asp:Button ID="button2Right" runat="server" Text=" " CssClass="buttonRight" />
        <asp:Button ID="button3Right" runat="server" Text=" " CssClass="buttonRight" />
        <asp:Button ID="button4Right" runat="server" Text=" " CssClass="buttonRight" />
    </div>


</asp:Content>
