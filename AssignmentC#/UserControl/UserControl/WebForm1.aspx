<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Webform1.aspx.cs" Inherits="UserControl.WebForm1" %>  
<%@ Register Src="~/WebUserControl1.ascx" TagPrefix="uc1" TagName="ContactUC" %>  
  
<!DOCTYPE html>  
  
<html xmlns="http://www.w3.org/1999/xhtml">  
<head runat="server">  
    <title></title>  
</head>  
<body>  
    <form id="form1" runat="server">  
    <div>  
        <uc1:ContactUC runat="server" id="ContactUC"/>  
    </div>  
    </form>  
</body>  
</html>  