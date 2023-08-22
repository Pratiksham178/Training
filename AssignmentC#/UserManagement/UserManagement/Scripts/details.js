var login = {}

$(document).ready(function () {
    try {
        $.ajax({
            type: "POST",
            url: "UserTable.aspx/GetSessionForAdmin",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d) {
                    $("#back").css({ "display": "none" });
                    loadPage();
                } else {
                    window.location.href = "LoginPage.aspx";
                }
                
            },
            Error: function (response) {
                alert(response);
            }
        });
    } catch (exception) {
        console.log(exception)
    }
    function loadPage() {
        var divRow = ` <div class="rowdata">
                    <div class="idcolumn">ID</div>
                    <div class="fnamecolumn">First Name</div>
                    <div class="lnamecolumn">Last Name</div>
                    <div class="emailcolumn">Email</div>
                    <div class="rolecolumn">UserRole</div>
                    <div class="hobbycolumn">Hobbies</div>
                    <div class="langcolumn">Languages Known</div>
                    <div class="editcolumn"><button type=button userId="fillId" class="edit_btn"><i class="fa fa-edit"></i></button></div>
                </div>`



        function AddRow(data) {

            data.forEach(function (item) {
                console.log(item["userID"]);
                var newrow = divRow.replace("ID", item['UserID']).replace("First Name", item['FirstName']).replace("Last Name", item['LastName']).replace("Email", item['Email']).replace("UserRole", item['UserRole']).replace("Hobbies", item['Hobbies']).replace("Languages Known", item['LanguagesKnown']).replace("fillId", item['UserID']);
                $("#userDetailTable").append(newrow);
            })
        }

        $.ajax({
            type: "POST",
            url: "UserTable.aspx/GetData",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                AddRow(response.d)
                console.log(response.d[0]["userID"]);
            },
            Error: function (response) {
                alert(response);
            }
        });
        
        $("#userDetailTable").on('click', 'button', function () {
            var userid = parseInt($(this).attr("userId"));
            var location = "Form.aspx?userId=" + userid;
            window.location.href = location;
        })
        $("#addnew_btn").click(function () {
            window.location.href = "Form.aspx";
            return false;
        })
    }
        
    
})
    
