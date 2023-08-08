
<%@ Page Title="ViewState" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="viewState.WebForm1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>  
        User Name:-<asp:textbox id="TextBox1"  runat="server"></asp:textbox>  
        <br />  
        Password  :-<asp:textbox id="TextBox2" runat="server"></asp:textbox>  
        <br />  
        <asp:button id="Button1" runat="server" onclick="Submit_Click" text="Submit" />  
        <asp:button id="Button3" runat="server" onclick="Button3_Click" text="Restore" /> 
        <div>Hiiii</div>
    </div>  
</asp:Content>


