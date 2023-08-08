<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="LoginUserRegistration.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
          <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>

<head runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link
      rel="stylesheet"
      href="https://fonts.googleapis.com/css?family=Space+Mono|Muli"
    />
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <link rel="stylesheet" href="./content/login.css" />
    <title></title>
    <script src="/Scripts/LoginPage.js" type="text/javascript"></script>
</head>
<body>
    <form runat="server" id="form1">
        <table>
            <tr>
                <td colspan="2"><h2>Log in to see your details</h2></td>
            </tr>
            <tr>
                <td><label for="emailLoginTextbox">Email:</label></td>
                <td><asp:TextBox ID="emailLoginTextbox" runat="server" ClientIDMode="Static" class="textbox"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="passwordLoginTextbox">Password:</label></td>
                <td><asp:TextBox id="passwordLoginTextbox" runat="server" ClientIDMode="Static"  class="textbox"></asp:TextBox><br />
</td>
            </tr>
        </table>
        <asp:Button type="button" ID="loginBtn" runat="server" Text="Login" ClientIDMode="Static" onclick="LoadSession"/>
    </form>
</body>
</html>
