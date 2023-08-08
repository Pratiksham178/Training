<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="UserControl.show" %>
<%@ Register Src="~/Employee.ascx" TagPrefix="nt" TagName="Note" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 158px;
        }
        .auto-style2 {
            height: 88px;
            width: 470px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="auto-style2">
    <tr>
        <td class="auto-style1">
            Name:
        </td>
        <td>
            <div id="nameID"  runat="server"></div>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            Company Name:
        </td>
        <td>
            <div id="companynameID"  runat="server" ></div>
        </td>
    </tr>
        </table>
        <div id="message" runat="server">Messages:</div>
        <nt:Note runat="server" ID="notetextbox_input" Tabletype="employee" />
        <asp:Button ID="btn_submit" runat="server" onclick="Addtodb" Text="Add Note" />
    </form>
</body>
</html>
