<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="navBar.ascx.cs" Inherits="NewsForYou.Web.navBar" %>

<div class="nav-bar" id="navBar">
    <div class="logo"><img src="./Images/mail.png" class="image-nav-bar" /></div>
    <div class="logo-name">DAILYMAIL</div>
    <button id="btnForGenerateReport" type="button" class="report-btn">Report</button>
    <button id="btnForLogOut" type="button" class="nav-bar-button" ></button>
</div>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>

    <script src="<%=NewsForYou.Util.Utilities.UpdateFileName("/Scripts/navBar.js")%>" type="text/javascript"></script>
