<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" EnableViewState="false" Inherits="WebApplication4.WebForm3" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <p>Select a City of Your Choice</p>
        <div>
            <asp:DropDownList  ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Country_name" DataValueField="CountryId" Height="27px" Width="221px">
            </asp:DropDownList>
            <asp:DataList ID="DataList1" runat="server" DataKeyField="CountryId" DataSourceID="SqlDataSource1">
                <itemtemplate>
                    CountryId:
                    <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("CountryId") %>' />
                    <br />
                    Country_name:
                    <asp:Label ID="Country_nameLabel" runat="server" Text='<%# Eval("Country_name") %>' />
                    <br />
                    <br />
                </itemtemplate>
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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="OnRowCommand" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <columns>
                <asp:BoundField DataField="userId" HeaderText="USERID" ReadOnly="True" SortExpression="userId" />
                <asp:BoundField DataField="email" HeaderText="EMAILID" SortExpression="email" />
                <asp:BoundField DataField="firstName" HeaderText="FIRST NAME" SortExpression="firstName" />
                <asp:BoundField DataField="lastName" HeaderText="LAST NAME" SortExpression="lastName" />
                <asp:BoundField DataField="countryId" HeaderText="COUNTRYID" SortExpression="countryId" />
                <asp:BoundField DataField="stateId" HeaderText="STATEID" SortExpression="stateId" />
                <asp:BoundField DataField="city" HeaderText="CITY" SortExpression="city" />
                <asp:BoundField DataField="zipcode" HeaderText="ZIPCODE" SortExpression="zipcode" />
                <asp:ButtonField ButtonType="Button" CommandName="Edit"  HeaderText="EDIT" ShowHeader="True" Text="EDIT/UPDATE" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="DELETE" ShowHeader="True" Text="DELETE" />
            </columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ProfileConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ProfileConnectionString4.ProviderName %>" SelectCommand="SELECT * FROM [user_table]"></asp:SqlDataSource>

        <br />

        <div id="update_form" runat="server" ClientIdMode="static" >
            <table>
                <tr>
                    <td>UserID:</td>
                    <td><input id="userID_input" type="text" runat="server" disabled/></td>
                </tr>
                <tr>
                    <td>EmailId:</td>
                    <td><input id="emailId_input" type="text" runat="server" /></td>
                </tr>
                <tr>
                    <td>First Name:</td>
                    <td><input id="first_name_input" type="text" runat="server" /></td>
                </tr>
                <tr>
                    <td>Last Name:</td>
                    <td><input id="last_name_input" type="text" runat="server"/></td>
                </tr>
                <tr>
                    <td>CountryId:</td>
                    <td><input id="countryid_input" type="text" runat="server"/></td>
                </tr>
                <tr>
                    <td>StateId:</td>
                    <td><input id="stateid_input" type="text" runat="server"/></td>
                </tr>
                <tr>
                    <td>City:</td>
                    <td><input id="city_input" type="text" runat="server"/></td>
                </tr>
                <tr>
                    <td>Zipcode:</td>
                    <td><input id="zipcode_input" type="text" runat="server"/></td>
                </tr>
            </table>
            <asp:Button runat="server"  OnClick="UpdateUser" Text="Update"/>
            <asp:Button runat="server" OnClick="Page_Load" Text="Cancel"/>
        </div>

    </main>
</asp:Content>
