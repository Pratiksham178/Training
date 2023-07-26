<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication4.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


<main>
 
    <div id="form" runat="server">  
        <div>  
           <h4>Provide the Following Details:</h4>  
            <table class="auto-style1">  
                <tr>  
                    <td class="auto-style3">  
                        <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label></td>  
                    <td>  
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style2"></asp:TextBox></td>
                 
        
                </tr>  
                <tr>  
                    <td class="auto-style3">  
                        <asp:Label ID="Label2" runat="server" Text="Upload a File"></asp:Label></td>  
                    <td>  
                        <asp:FileUpload ID="FileUpload1" runat="server" /></td>  
                </tr>  
            </table>          
        </div>  
    </div>  
</main>
</asp:content>
