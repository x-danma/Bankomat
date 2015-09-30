<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ATM.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="softButtonWrapper">
        <asp:Button ID="button1Left" runat="server" Text=" " CssClass="buttonLeft" />
        <asp:Button ID="button2Left" runat="server" Text=" " CssClass="buttonLeft" />
        <asp:Button ID="button3Left" runat="server" Text=" " CssClass="buttonLeft" />
        <asp:Button ID="button4Left" runat="server" Text=" " CssClass="buttonLeft" />
    </div>
    <div class="atmScreen">
        <div class="infoBox" style="width: 100%; height: 365px">
            <h1 style="font-size: xx-large">Välkommen till banken</h1>
            <span style="font-size: x-large">Skriv in din Pinkod</span><br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="warningLabel" runat="server" Text=""></asp:Label>
            <br />
            
 <asp:TextBox ID="inputField" runat="server" Height="65px" Width="226px" Visible="false"></asp:TextBox>
            <asp:TextBox ID="TextBox1" runat="server" Height="65px" Width="226px" Visible="true"></asp:TextBox>
        </div>
        </div>


    

    <div class="softRightButtonWrapper">
        <asp:Button ID="button1Right" runat="server" Text=" " CssClass="buttonRight" />
        <asp:Button ID="button2Right" runat="server" Text=" " CssClass="buttonRight" />
        <asp:Button ID="button3Right" runat="server" Text=" " CssClass="buttonRight" />
        <asp:Button ID="button4Right" runat="server" Text=" " CssClass="buttonRight" />
    </div>
    
</asp:Content>
