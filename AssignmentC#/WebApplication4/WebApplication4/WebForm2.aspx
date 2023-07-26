<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication4.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  
    <title></title>  
</head>  
<body>  
    <form id="form1" runat="server">  
        <div>  
            <asp:Label ID="labelId" runat="server">User Name</asp:Label>  
            <asp:TextBox ID="UserName" runat="server" ToolTip="Enter User Name" AccessKey="t" TabIndex="1"></asp:TextBox>  
        </div>  
        <p>  
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" AccessKey="k" TabIndex="3"/>  
        </p>  
        <br/>
        <div>  
            <asp:Label ID="label1" runat="server">User Name</asp:Label>  
            <asp:TextBox ID="TextBox1" runat="server" ToolTip="Enter User Name" AccessKey="t" TabIndex="2"></asp:TextBox>  
        </div>
        <div>  
            <asp:HyperLink ID="HyperLink1" runat="server" Text="JavaTpoint" NavigateUrl="https://www.javatpoint.com"></asp:HyperLink>  
        </div>
        <div>  
            <asp:RadioButton ID="RadioButton1" runat="server" Text="Male23" GroupName="gender" />  
            <asp:RadioButton ID="RadioButton2" runat="server" Text="Female" GroupName="gender" />  
        </div>
        <h2>Select Date from the Calender</h2>  
        <div>  
            <asp:Calendar ID="Calendar1" runat="server"   
            OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>  
        </div>
        <div>  
            <h2>Select Courses</h2>  
            <asp:CheckBox ID="CheckBox1" runat="server" Text="J2SE" />  
            <asp:CheckBox ID="CheckBox2" runat="server" Text="J2EE" />  
            <asp:CheckBox ID="CheckBox3" runat="server" Text="Spring" />  
        </div>  
        <p>  
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />  
        </p>  
        <div>  
            <p>Browse to Upload File</p>  
            <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="true"/>  
        </div>  
        <p>  
            <asp:Button ID="Button2" runat="server" Text="Upload File" OnClick="Button_Click" />  
        </p>
        <p>  
        Click the button to download a file</p>  
        <asp:Button ID="Button3" runat="server" OnClick="download_Click" Text="Download" />  
        <br />  
        <br />  
        <asp:Label ID="Label2" runat="server"></asp:Label>  
    </form>  
     <asp:Label ID="userInput" runat="server"></asp:Label>  
    <asp:Label runat="server" ID="ShowDate" ></asp:Label> 
    <p>  
        Courses Selected: <asp:Label runat="server" ID="ShowCourses"></asp:Label>  
    </p>
    <p>  
        <asp:Label runat="server" ID="FileUploadStatus"></asp:Label>  
    </p> 
</body>  
</html>  
