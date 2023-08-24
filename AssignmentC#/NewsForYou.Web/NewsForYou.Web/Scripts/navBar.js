var sessionId;
$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "NewsPage.aspx/GetSession",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            sessionId = response.d
            if (sessionId != -1) {
                $("#logOut").empty().append('<i class="fa fa-sign-out"></i>');
            } else {
                $("#logOut").empty().append('<i class="fa fa-sign-in"></i>');
            }
        },
        Error: function (response) {
            alert(response);
        }
    })
    $("#logOut").click(function () {
        if (sessionId != -1) {
            $.ajax({
                type: "POST",
                url: "NewsPage.aspx/DeleteSession",
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    window.location.href = "LoginPage.aspx";
                },
                Error: function (response) {
                    alert(response);
                }
            })
        } else {
            window.location.href = "LoginPage.aspx";
        }
        
        
    })
    $("#generateReport").click(function () {
        
        if (sessionId != -1) {
            window.location.href = "ReportPage.aspx";
        } else {
            alert("Please Login")
        }
           
        
    })
})