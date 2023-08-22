var user = [];
var email = [];
var index;
$(document).ready(function () {
    function getusers() {
        $.ajax({
            type: "POST",
            url: "LoginPage.aspx/GetLoginDetails",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                user = response.d;
                user.forEach(function (item) {
                    email.push(item["Email"]);
                })
            },
            Error: function (response) {
                alert(response);
            }
        });
    }

    getusers();
    
    $("#btnForLogin").click(function () {
        if (user[index]["Password"] === $("#passwordLoginTextbox").val()) {
            userId = user[index]["UserId"];
            $.ajax({
                type: "POST",
                url: "LoginPage.aspx/StoreSession",
                data: JSON.stringify({ userId: userId }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log(user[index]);
                    window.location.href = "NewsPage.aspx" ;
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

    $("#btnForIntialization").click(function(){
        $.ajax({
            type: "POST",
            url: "LoginPage.aspx/IntializeDetails",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                alert("Intialized!")
            },
            Error: function (response) {
                alert(response);
            }
        });
    })
})