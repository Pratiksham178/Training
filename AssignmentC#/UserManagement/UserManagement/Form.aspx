<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs"  EnableEventValidation="true" Inherits="UserManagement.Form" %>

<%@ Register Src="~/FormBasicinfo.ascx" TagPrefix="bi" TagName="Binfo" %>
<%@ Register Src="~/NoteBox.ascx" TagPrefix="nt" TagName="Note" %>
<%@ Register Src="~/filebox.ascx" TagPrefix="fl" TagName="File" %>
<%@ Register Src="~/NavBar.ascx" TagPrefix="nb" TagName="Nav" %>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link
      rel="stylesheet"
      href="https://fonts.googleapis.com/css?family=Space+Mono|Muli"
    />
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <link rel="stylesheet" href="./content/form.css" />
       <link rel="stylesheet" href="./content/nav.css" />
     <script src='<%=ResolveClientUrl("~/Scripts/form.js") %>' type="text/javascript"></script>
      <script src='<%=ResolveClientUrl("~/Scripts/nav-bar.js") %>' type="text/javascript"></script>
    <title>Registration Form</title>
  </head>
  <body>
      <nb:Nav runat="server" ID="nav"  clientIdMode="Static"  />
      <form ID="form1" runat="server">
      <div id="registrationFormHeading">
        <img
          src="https://static.vecteezy.com/system/resources/previews/005/544/718/original/profile-icon-design-free-vector.jpg"
          id="profimage"
          alt="image"
        />
        <div id="registrationFormText">Registration Form</div>
        <div>
            <Button ID="Delete" visible="false"><i class="fa fa-trash"></i> </Button>
        </div>
      </div>
          <div ID="buttonsdiv" runat="server" clientIDMode="Static">
               <asp:Button runat="server" clientIDMode="Static" ID="basicInfobtn" Text="Basic Info" type="button" CssClass="btneachdiv"/>
              <asp:Button runat="server" clientIDMode="Static" ID="noteBoxbtn" Text="Your Notes" type="button"  CssClass="btneachdiv"/>
                <asp:Button runat="server" clientIDMode="Static" ID="filebtn" Text="Your Files" type="button"  CssClass="btneachdiv"/>

          </div>
        <bi:Binfo runat="server" ID="BasicInfo_input" clientIdMode="Static" />
           <nt:Note runat="server" ID="notetextbox_input"  clientIdMode="Static"  />
          <fl:File runat="server" ID="filebox_input"  clientIdMode="Static"  />
      </form>
</body>
</html>