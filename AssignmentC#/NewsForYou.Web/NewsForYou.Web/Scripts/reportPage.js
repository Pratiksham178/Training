﻿var eachRow = `<div class="row-body">
                <div class="agency-name">[Agency Name]</div>
                <div class="title">[Title]</div>
                <div class="views">[Views]</div>
            </div>`
var header = `<div class="row-header">
                <div class="agency-name">Agency Name</div>
                <div class="title">Title</div>
                <div class="views">Views</div>
            </div>`
var sessionId
$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "NewsPage.aspx/GetSession",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            sessionId = response.d
            if (sessionId == -1) {
                alert("Please Login!");
                window.location.href = "LoginPage.aspx";
            }
        },
        Error: function (response) {
            alert(response);
        }
    })
    if (sessionId != -1) {
        function AddRow(data) {
            $("#reportTable").append(header)
            $.each(data, function (index, value) {
                var newRow = eachRow.replace("[Agency Name]", value["Agency"]).replace("[Title]", value["Title"]).replace("[Views]", value["NoOfClick"]);
                $("#reportTable").append(newRow)
            })
        }

        $("#generateReportBtn").click(function () {
            $(".loading-gif").css({ "display": "block" })
            $("#downloadReportBtn").css({ "display": "none" })
            var date = $("#reportDateInput").val();
            if (date != "") {
                $("#reportTable").empty()
                $("#reportDate").css({ "border": "1px solid grey" })
                $.ajax({
                    type: "POST",
                    url: "ReportPage.aspx/AddDataToReport",
                    data: JSON.stringify({ date: date }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        $(".loading-gif").css({ "display": "none" })

                        if (response.d.length > 0) {
                            $("#downloadReportBtn").css({ "display": "inline" })
                            AddRow(response.d)
                        } else {
                            alert("No news on this date")
                        }

                    },
                    Error: function (response) {
                        alert(response);
                    }
                })
            } else {
                $("#reportDateInput").css({ "border": "1px solid red" })
            }

        })

        $("#downloadReportBtn").click(function () {
            $(".loading-gif").css({ "display": "block" })
            var date = $("#reportDateInput").val();
            if (date != "") {
                $(".loading-gif").css({ "display": "none" })
                window.location.href = "GeneratePDF.ashx?date=" + date;
            } else {
                $("#reportDateInput").css({ "border": "1px solid red" })
            }

        })
        var todaydate = new Date(Date.now())
        $("#reportDateInput").attr("max", todaydate.toISOString().substring(0, 10));
        $("#backToHomeBtn").click(function () {
            window.location.href = "NewsPage.aspx"
        })
    }
    
});