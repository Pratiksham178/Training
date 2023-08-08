<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userDataTable.aspx.cs" Inherits="LoginUserRegistration.userDataTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script src='<%=ResolveClientUrl("~/Scripts/details.js") %>' type="text/javascript"></script>
   
<link
      rel="stylesheet"
      href="https://fonts.googleapis.com/css?family=Space+Mono|Muli"
    />
    <link rel="stylesheet" href="./content/form.css" />
    <link rel = "stylesheet" href = "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.3.0/css/font-awesome.min.css"/>
</head>

<body>
   
    <form runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
</asp:ScriptManager>
        <div >
            <div class="user_details">USER DETAILS:</div>
            <div id="userDetailTable">
                <div class="rowhead">
                    <div class="idcolumn">ID</div>
                    <div class="fnamecolumn">First Name</div>
                    <div class="lnamecolumn">Last Name</div>
                    <div class="emailcolumn">Email</div>
                    <div class="rolecolumn">UserRole</div>
                    <div class="hobbycolumn">Hobbies</div>
                    <div class="langcolumn">Languages Known</div>
                    <div class="editcolumn">Update</div>
                </div>
            </div>
            <div id="submit">
            <asp:Button ID="addnew_btn" runat="server" onclick="AddnewUserBtnClick" Text="Add New User" CssClass="btn_NewUser"/>
        </div>
        </div>
    </form>
</body>
</html>
