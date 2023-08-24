<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="NewsForYou.Web.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
     <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Varela+Round&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="<%=NewsForYou.Util.Utilities.UpdateFileName("/content/login.css")%>" />
    <title></title>
</head>
<body>
        <div class="login-page">
           <div class="black-film-layer">
            <div class="login-box">
                <div class="welcome-note">
                    <h1>Welcome Back!</h1>
                    <p>The faster you fill,the faster you know what's new?</p>
                </div>
                
                <div class="eachdiv">
                    Email:<br />
                    <input type="text" id="emailLoginTextbox" class="input-login" />
                </div>
                <div class="eachdiv">
                    Password:<br />
                    <input type="password" id="passwordLoginTextbox" class="input-login" />
                </div>
                <div>
                    <button id="btnForLogin" class="btn-submit">Login</button>
                </div>
                <div>
                    <button id="btnForIntialization" class="btn-submit">Initialize</button>
                </div>
            </div>
               </div>
        </div>
          <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>

        <script src="<%=NewsForYou.Util.Utilities.UpdateFileName("/Scripts/loginPage.js")%>" type="text/javascript"></script>

</body>
</html>
