<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WebForm2.aspx.cs" Inherits="viewState.WebForm2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table class="style1">  
            <tr>  
                <td>  
                    BackColor  
                </td>  
                <td>  
                       
                    <asp:RadioButtonList ID="rbLBackColor" runat="server" AutoPostBack="True"   
                        onselectedindexchanged="rbLBackColor_SelectedIndexChanged"   
                        RepeatDirection="Horizontal">  
                        <asp:ListItem>Red</asp:ListItem>  
                        <asp:ListItem>Green</asp:ListItem>  
                        <asp:ListItem>Blue</asp:ListItem>  
                    </asp:RadioButtonList>  
                </td>  
            </tr>  
            <tr>  
                <td>  
                    ForeColor  
                </td>  
                <td>  
                       
                    <asp:RadioButtonList ID="rbLForeColor" runat="server" AutoPostBack="True"   
                        onselectedindexchanged="rbLForeColor_SelectedIndexChanged"   
                        RepeatDirection="Horizontal">  
                        <asp:ListItem>Red</asp:ListItem>  
                        <asp:ListItem>Green</asp:ListItem>  
                        <asp:ListItem>Blue</asp:ListItem>  
                    </asp:RadioButtonList>  
                </td>  
            </tr>  
            <tr>  
                <td>  
                    Name  
                </td>  
                <td>  
                    <asp:TextBox ID="TextBox1" runat="server" EnableViewState="False"  
                        ></asp:TextBox>  
                </td>  
            </tr>  
            <tr>  
                <td>  
                       
                </td>  
                <td>  
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit"  />  
                </td>  
            </tr>  
</table>    
    <asp:Label ID="tbUserName" runat="server"></asp:Label>
</asp:Content>
