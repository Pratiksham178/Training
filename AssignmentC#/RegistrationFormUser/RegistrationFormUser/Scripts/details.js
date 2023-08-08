$(document).ready(function () {
//var divRow = `
//    <div class="rowdata">
//                    <div class="idcolumn">ID</div>
//                    <div class="fnamecolumn">First Name</div>
//                    <div class="lnamecolumn">Last Name</div>
//                    <div class="emailcolumn">Email</div>
//                    <div class="rolecolumn">UserRole</div>
//                    <div class="hobbycolumn">Hobbies</div>
//                    <div class="langcolumn">Languages Known</div>
//                    <div class="editcolumn" ><a href="filllocation">Edit</a></div>
//                    </div>`
    var divRow = `
    <div class="rowdata">
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
    console.log(data);

    data.forEach(function (item) {
        //var newrow = divRow.replace("ID", item['userID']).replace("First Name", item['firstName']).replace("Last Name", item['lastName']).replace("Email", item['email']).replace("UserRole", item['userRole']).replace("Hobbies", item['hobbies']).replace("Languages Known", item['languages']).replace("filllocation","FormPage.aspx?userId="+item['userID']);
        var newrow = divRow.replace("ID", item['userID']).replace("First Name", item['firstName']).replace("Last Name", item['lastName']).replace("Email", item['email']).replace("UserRole", item['userRole']).replace("Hobbies", item['hobbies']).replace("Languages Known", item['languages']).replace("fillId", item["userID"]);
        $("#userDetailTable").append(newrow);
    })
}

$.ajax({
    type: "POST",
    url: "userDataTable.aspx/GetData",
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
        var userid = $('button').attr("userId");
        var location = "FormPage.aspx?userId=" + userid;
        window.location.href = location;
    })

})
