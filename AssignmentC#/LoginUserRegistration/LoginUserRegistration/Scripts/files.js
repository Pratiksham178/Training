const queryString = window.location.search;
let params = new URLSearchParams(queryString);
var userId = params.get('userId');

$(document).ready(function () {

    $.ajax({
        
        type: "POST",
        url: "Form.aspx/GetAllFiles",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            Addrow(response.d)
        },
        Error: function (response) {
            alert(response);
        }
    });
    var filerow = `<div class=eachrow>
                        <div class="filename">[filename]</div>
                        <button type="button" class="dwnldBtn" userId="[userId]"><i class="fa fa-download"></i></button>
                        <button type="button" class="dwnldBtn" userId="[userId]"><i class="fa fa-trash"></i></button>
                    </div>`
    function Addrow(data) {
        data.forEach(function (item) {
           
            if (item["userID"] == userId) {
                var newrow = filerow.replace("[filename]", item["name"]).replace("[userId]", item["userID"]).replace("[userId]", item["userId"]);
                $("#filebox1").append(newrow);
            }
            
        })
    }
    $("#uploadBtn").click(function (evt) {
        var fileUpload = $("#FileUpload1").get(0);
        var files = fileUpload.files;
        var data = new FormData();
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
            data.append("USERID", userId);
        }
        console.log(data);

        $.ajax({
            url: "",
            type: "POST",
            data: data,
            contentType: false,
            processData: false,
            success: function (result) { alert(result); },
            error: function (err) {
                alert(err.statusText)
            }
        });

        evt.preventDefault();
    });
})