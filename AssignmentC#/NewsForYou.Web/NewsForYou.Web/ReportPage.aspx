<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportPage.aspx.cs" Inherits="NewsForYou.Web.ReportPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Space+Mono|Muli"/>
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Varela+Round&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="<%=NewsForYou.Util.Utilities.UpdateFileName("/content/reportPage.css")%>" />

    <title>Report Page</title>
</head>
<body>
     

        <div class="generate-report-div">
            <button type="button" id="backToHome" class="backhome-btn"><i class="fa fa-angle-double-left"></i></button>
            <input type="date" id="reportDate" placeholder="Select Date" class="date-input"/>
            <button type="button" class="generate-report-btn" id="generateReportBtn">Generate Report</button>
            <button type="button" id="downloadReportBtn" class="download-pdf-btn">Download</button>

        </div>
         <div><img src="https://media4.giphy.com/media/3oEjI6SIIHBdRxXI40/giphy.gif?cid=ecf05e47kp7wnvclj2dezfuf013iffibbq36t6fbgrwhw9sd&ep=v1_gifs_search&rid=giphy.gif&ct=g" class="loading-gif" /></div>
        <div class="report-table" id="reportTable">
            
        </div>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
        <script src="<%=NewsForYou.Util.Utilities.UpdateFileName("/Scripts/reportPage.js")%>" type="text/javascript"></script>
</body>
</html>
