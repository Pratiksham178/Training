$(document).ready(function () {
    $("#logOut").click(function () {
        $.ajax({
            type: "POST",
            url: "Form.aspx/DeleteSession",
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
    })
})