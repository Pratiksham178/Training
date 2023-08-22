var user = [];
var email = [];
var index;
$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "LoginPage.aspx/GetLoginDetails",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            user = response.d;
        },
        Error: function (response) {
            alert(response);
        }
    });
    user.forEach(function (item) {
        email.push(item["Email"]);
    })
    $("#loginBtn").click(function () {
        if (user[index]["Password"] === $("#passwordLoginTextbox").val()) {
            userId = user[index]["Id"];
            $.ajax({
                type: "POST",
                url: "LoginPage.aspx/StoreSession",
                data: JSON.stringify({userId:userId}),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log(user[index]);
                    if (user[index]["Admin"] === true) {
                        window.location.href = "UserTable.aspx";


                    } else {
                        window.location.href = "Form.aspx?userId=" + userId;
                    }
                },
                Error: function (response) {
                    alert(response);
                }
            });
            return false;
        } else {
            $("#passwordLoginTextbox").css({ "border": "1px solid brown" });
            return false;
        }
    })
    $("#emailLoginTextbox").change(function () {
        user.forEach(function (item) {
            email.push(item["Email"]);
        })
        if (!(email.includes($("#emailLoginTextbox").val()))) {
            $("#emailLoginTextbox").css({ "border": "1px solid brown" });
            $("#loginBtn").prop("disabled", true);
        } else {
            $("#emailLoginTextbox").css({ "border": "1px solid grey" });
            $("#loginBtn").prop("disabled", false);
            index = email.indexOf($("#emailLoginTextbox").val());
        }
    })
})