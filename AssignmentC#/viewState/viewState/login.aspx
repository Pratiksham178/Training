<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="login.aspx.cs" Inherits="viewState.WebForm3" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                UserEmail:
            </td>
            <td>
                <asp:TextBox ID="mailID" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Password:
            </td>
            <td>
                <asp:TextBox ID="passwordID" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />  
</asp:Content>
