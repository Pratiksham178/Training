<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication4.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server"> 
        <p>Select a City of Your Choice</p>  
        <div>  
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Country_name" DataValueField="CountryId" Height="27px" Width="221px">
            </asp:DropDownList>
            <asp:DataList ID="DataList1" runat="server" DataKeyField="CountryId" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    CountryId:
                    <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("CountryId") %>' />
                    <br />
                    Country_name:
                    <asp:Label ID="Country_nameLabel" runat="server" Text='<%# Eval("Country_name") %>' />
                    <br />
                    <br />
                </ItemTemplate>
            </asp:DataList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ProfileConnectionString3 %>" SelectCommand="SELECT [CountryId], [Country_name] FROM [country_table]"></asp:SqlDataSource>
        </div>  
        <br />  
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" Height="30px" Width="184px" />  
        <br />  
        <br />  
        <asp:Label ID="Label1" runat="server" EnableViewState="False"></asp:Label>  
        
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="userId" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="userId" HeaderText="userId" ReadOnly="True" SortExpression="userId" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="firstName" HeaderText="firstName" SortExpression="firstName" />
                <asp:BoundField DataField="lastName" HeaderText="lastName" SortExpression="lastName" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                <asp:BoundField DataField="countryId" HeaderText="countryId" SortExpression="countryId" />
                <asp:BoundField DataField="stateId" HeaderText="stateId" SortExpression="stateId" />
                <asp:BoundField DataField="AddressLine1" HeaderText="AddressLine1" SortExpression="AddressLine1" />
                <asp:BoundField DataField="AddressLine2" HeaderText="AddressLine2" SortExpression="AddressLine2" />
                <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                <asp:BoundField DataField="zipcode" HeaderText="zipcode" SortExpression="zipcode" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ProfileConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ProfileConnectionString4.ProviderName %>" SelectCommand="SELECT * FROM [user_table]"></asp:SqlDataSource>
        
    </form>  
</body>  
</html>
