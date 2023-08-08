var user = [];
var email = [];
var index;
$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "LoginPage.aspx/Login",
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
        console.log(item);
        email.push(item["Email"]);
        console.log(item["email"]);
    })
    //$("#loginBtn").click(function () {
    //    if (user[index]["password"] === $("#passwordLoginTextbox").val()) {
    //        sessionStorage.setItem("id", user[index]["Id"]);
    //        sessionStorage.setItem("admin", user[index]["admin"]);
    //        if (user[index]["admin"] === true) {
    //            window.location.href = "AdminPage.aspx";


    //        } else {
    //            window.location.href = "Form.aspx?userId=" + user[index]["Id"];
    //        }
            
            
    //        return false;
    //    } else {
    //        $("#passwordLoginTextbox").css({ "border": "1px solid brown" });
    //        return false;
    //    }
    //})
    $("#emailLoginTextbox").change(function () {
        user.forEach(function (item) {
            email.push(item["email"]);
        })
        if (!(email.includes($("#emailLoginTextbox").val()))){ 
            $("#emailLoginTextbox").css({ "border": "1px solid brown" });
            $("#loginBtn").prop("disabled", true);
        }else {
            $("#emailLoginTextbox").css({ "border": "1px solid grey" });
            $("#loginBtn").prop("disabled", false);
            index = email.indexOf($("#emailLoginTextbox").val());
        }
    })
})
