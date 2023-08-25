<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsPage.aspx.cs" Inherits="NewsForYou.Web.NewsPage" %>
<%@ Register Src="~/navBar.ascx" TagPrefix="nb" TagName="Nav" %> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Space+Mono|Muli"/>
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Varela+Round&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="<%=NewsForYou.Util.Utilities.UpdateFileName("/content/navBar.css")%>" />
     <link rel="stylesheet" href="<%=NewsForYou.Util.Utilities.UpdateFileName("/content/newsPage.css")%>" />

   
    <title>News Page</title>
</head>
<body>
     <nb:Nav runat="server" ID="nav"  clientIdMode="Static"  />
  <div><img src="https://media4.giphy.com/media/3oEjI6SIIHBdRxXI40/giphy.gif?cid=ecf05e47kp7wnvclj2dezfuf013iffibbq36t6fbgrwhw9sd&ep=v1_gifs_search&rid=giphy.gif&ct=g" class="loading-gif" /></div>
    <div id="refreshpageAlertbox" class="refreshpage-alertbox">
        <div><button class="cross-btn" id="crossBtnForAlertbox"><i class="fa fa-close"></i></button></div>
        <div id="newMessages"></div>
        
    </div>
        <div id="slideShowNews" class="slideshow-container">
            
        </div>
    <div class="categories-btns" id="categories">
        <span class="categories-header">Categories</span>

    </div>
    <div class="all-news" id="newsBoxId">

    </div>
    <div class="pagination-btns-div" id="paginationBtnsDiv">

    </div>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <script src="<%=NewsForYou.Util.Utilities.UpdateFileName("/Scripts/newsPage.js")%>" type="text/javascript"></script>
</body>
</html>
