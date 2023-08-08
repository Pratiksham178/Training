<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userDetails.aspx.cs" Inherits="RegistrationFormUser.userDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link
      rel="stylesheet"
      href="https://fonts.googleapis.com/css?family=Space+Mono|Muli"
    />
    <link rel="stylesheet" href="./content/form.css" />
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <%--<asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:BoundField DataField ="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName"/>
                    
                    <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="Webform1.aspx?userId={0}" HeaderText="EDIT" Text="EDIT" />
                    
                </Columns>
            </asp:GridView>--%>
        </div>
        <span id="userDetails">USER DETAILS:</span>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProfileConnectionString3 %>" SelectCommand="SELECT [ID], [email], [FirstName], [LastName], [Gender] FROM [userDetails]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" >
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="FormPage.aspx?userId={0}" HeaderText="Update" Text="EDIT" />
                
            </Columns>
        </asp:GridView>
        <div id="submit">
            <asp:Button ID="addnew_btn" runat="server" onclick="AddnewUser_btn_Click" Text="Add New User" CssClass="btn_NewUser"/>
        </div>
    </form>
</body>
</html>
