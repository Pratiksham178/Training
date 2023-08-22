const queryString = window.location.search;
let params = new URLSearchParams(queryString);
var userId = parseInt(params.get('userId'));
var newRowNotes = `<div class="eachrownotes">
                        <div class="eachNoteMessageDiv">[Note]</div>
                        <div class="eachCreatedOnDiv">[CreatedOn]</div>
                    </div>`;
var filerow = `<div class="eachrowfiles">
                <div class="filenamebox">
                            <div class="filename">[filename]</div>
                            <div class="create">[createdon]</div>
                             <div class="create">[CreatedBy]</div>
                             </div>
                        <button type="button" class="dwnldBtn" ><i class="fa fa-download" command="Dwnld" filename="[filename]"></i></button>
                        <button type="button" class="dwnldBtn" ><i class="fa fa-trash" command="Delete" fileId="[fileId]" ></i></button>
                    </div>`
var admin
var state = -1; 
$(document).ready(function () {

    function PopulateCountries(data) {
        $("#countryPresent").empty().append('<option selected="selected" value="0">Choose Country</option>');
        $("#countryPermanent").empty().append('<option selected="selected" value="0">Choose Country</option>');
        data.forEach(function (item) {
            $("#countryPresent").append(`<option Value=${item["ID"]}>${item["CountryName"]}</option>`);
            $("#countryPermanent").append(`<option Value=${item["ID"]}>${item["CountryName"]}</option>`);
        })
    }
    function PopulateStatesPresent(id) {

        $.ajax({
            type: "POST",
            url: "Form.aspx/GetStateDropList",
            data: JSON.stringify({ id: id }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $("#statePresent").empty().append('<option selected="selected" value="-1">Choose State</option>');
                response.d.forEach(function (item) {
                    $("#statePresent").append(`<option Value=${item["ID"]}>${item["StateName"]}</option>`);
                })
                if (state != -1) {
                    $("#statePresent").val(state)
                }
            },
            Error: function (response) {
                alert(response);
            }
        });
    }
    function PopulateStatesPermanent(id) {

        $.ajax({
            type: "POST",
            url: "Form.aspx/GetStateDropList",
            data: JSON.stringify({ id: id }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $("#statePermanent").empty().append('<option selected="selected" value="-1">Choose State</option>');
                response.d.forEach(function (item) {
                    $("#statePermanent").append(`<option Value=${item["ID"]}>${item["StateName"]}</option>`);
                })
                if (state != -1) {
                    $("#statePermanent").val(state)
                }
            },
            Error: function (response) {
                alert(response);
            }
        });
    }

    function addressSamePresentPermanent() {
        if ($("#checkBoxForSamePermanentAndPresentAddress").is(":checked")) {
            $("[address='Present Address']").each(function (index, value) {
                $(`#${$(value).attr("copyTo")}`).val($(`#${value.id}`).val()).prop('disabled', true);
            })

        } else {
            $("[address='Permanent address']").prop('disabled', false);
        }
    }


    $("#form1").change((e) => {
        if (e.target.id != "") {

            if (e.target.id === "checkBoxForSamePermanentAndPresentAddress" || $(e.target).attr("address") === "Present Address") {
                addressSamePresentPermanent();
            } else if (e.target.id === "otherHobbyCheckBox") {
                var target = $(e.target).attr("box-id");
                if ($(`#${e.target.id}`).is(":checked")) {
                    $(`#${target}`).css({ "display": "inline" });
                } else {
                    $(`#${target}`).css({ "display": "none" })
                }
            }
            $(`#${e.target.id}`).css({ "border": "1px solid grey" });

        }
    })

    function validateEmptyField(elementId) {
        if ($(`#${elementId}`).val() === "" || $(`#${elementId}`).val() === null || $(`#${elementId}`).val() === "0") {
            $(`#${elementId}`).css({ "border": "1px solid brown" });
            return 1;
        }
        return 0
    }
    function Validate() {
        var allInputs = $(":input");
        var flag = 0;
        $("#msg").empty();
        $.each(allInputs, function (index, value) {
            var check = $(value).attr("Validate");
            if ($(value).attr('Validate') == "yes") {
                flag = validateEmptyField(value.id);
                flagcheck = 1;
            }
            if (value.id == "fname" || value.id == "lname") {
                if ($(value).val() != "" && !$(value).val().match(/^[A-Za-z]+/)) {
                    $(value).css({ "border": "1px solid brown" })
                    $("#msg").append('<p>Incorrect name</p>');
                    flag = 1;
                }
            }
            if (value.id == "dob" && $(value).val() != "") {
                var date = new Date();
                if (Number(date.getFullYear()) - Number($(value).val().slice(0, 4)) < 18) {
                    $(value).css({ "border": "1px solid brown" })
                    $("#msg").append('<p>You need to be 18 by 01-01-2023</p>');
                    flag = 1;
                }
            }
        })
        if (flag > 0) {
            $("#msg").css({ "color": "brown", "display": "block" });
            if (flagcheck == 1) {
                $("#msg").append('<p>Please enter required details</p>');
            }
            return false
        } else {
            return true
        }
    }
    function getValueCheckBox(elementName) {
        var ans = []
        $(`.${elementName}`).each(function (index, eachelement) {
            if ($(eachelement).is(":checked")) {
                ans.push($(eachelement).val())
            }
            if ($(eachelement).attr("type") === "text" && $(eachelement).val() != "") {
                ans.push($(eachelement).val())
            }
        })
        return ans
    }
    function checkValueCheckBox(elementName, obj) {
        let hobby = ["dancing", "singing"];
        $(`.${elementName}`).each(function (index, eachelement) {
            if (obj.includes($(eachelement).val())) {
                $(eachelement).attr("checked", true);
            }
            if ($(eachelement).attr("type") === "text") {
                $.each(obj, function (index, value) {
                    if (!(hobby.includes(value))) {
                        $(eachelement).val(value);
                        $("#otherHobbyCheckBox").attr("checked", true);
                    }
                })

            }
        })
    }

    function PopulateDetails(objectuser) {

        var allInputs = $(":input");
        var userrole = $("#CheckBoxList1 input");
        var countryState = $("select");
        $.each(allInputs, function (index, value) {
            if (($(value).attr('type') === "text" && $(value).attr('name') != "Hobbies") ||
                $(value).attr('type') === "tel" ||
                $(value).attr('type') === "email" || $(value).attr('type') === "password") {
                $(value).val(objectuser[$(value).attr('name')].toString());
            }
            else if ($(value).attr('type') === 'date') {
                $(value).val(objectuser[$(value).attr('name')])
            }
            else if ($(value).attr('type') == "radio") {
                if ($(value).val() == objectuser["Gender"]) {
                    $(value).attr("checked", true);
                }
            }
            else if ($(value).attr('name') == "Hobbies" || $(value).attr('name') == "LanguagesKnown") {
                checkValueCheckBox($(value).attr('name'), objectuser[$(value).attr('name')])
            }
        })
        $.each(countryState, function (index, value) {
            state = objectuser[$(value).attr('objectName')];
            if ($(value).attr('objectName') == "StatePresent") {
                PopulateStatesPresent(objectuser["CountryPresent"]);
            }
            if ($(value).attr('objectName') == "StatePermanent") {
                PopulateStatesPermanent(objectuser["CountryPermanent"]);
            }
            console.log(objectuser[$(value).attr('objectName')]);
            $(value).val(objectuser[$(value).attr('objectName')]);
        })
        $.each(userrole, function (index, value) {
            if (objectuser["UserRoles"].includes(parseInt($(value).val()))) {
                $(value).attr("checked", true);
            }


        })

    }
    function ShowNotes(alldata) {
        if (alldata.length === 0) {
            $("#message").InnerHTML = '<p>No Notes Present</p>'
        }
        $("#userNotes").empty()
        $("#companyNotes").empty()
        alldata.forEach(function (data) {
            if (data["Visible"] != "yes") {
                var newrow = newRowNotes.replace("[Note]", data["Note"]).replace("[CreatedOn]", data["CreatedOn"])
                $("#userNotes").append(newrow);
            }
            else if (admin && data["Visible"] == "yes") {
                $("#companymessage").empty()
                var newrow = newRowNotes.replace("[Note]", data["Note"]).replace("[CreatedOn]", data["CreatedOn"])
                $("#companyNotes").append(newrow);
                $("#companymessage").InnerHTML = '<p>Admin Notes</p>';
            }

        })
    }

    function AddDetails() {
        $.ajax({
            type: "POST",
            url: "Form.aspx/GetUserDetail",
            data: JSON.stringify({ id: userId }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                PopulateDetails(response.d);

            },
            Error: function (response) {
                alert(response);
            }
        });

    }

    function GetNotes() {
        $.ajax({
            type: "POST",
            url: "Form.aspx/GetNoteDataList",
            data: JSON.stringify({ userId: userId }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                ShowNotes(response.d);

            },
            Error: function (response) {
                alert(response);
            }
        });
    }

    $("#basicInfobtn").click(function () {
        $(".eachbox").css({ "display": "block" });
        $("#noteBox").css({ "display": "none" });
        $("#fileinputbox").css({ "display": "none" });
        $(this).css({ "background-color": "black", "color": "white" });
        $("#noteBoxbtn").css({ "background-color": "white", "color": "black" });
        $("#filebtn").css({ "background-color": "white", "color": "black" });
        return false;
    })

    $("#noteBoxbtn").click(function () {
        $(".eachbox").css({ "display": "none" });
        $("#noteBox").css({ "display": "block" });
        $("#fileinputbox").css({ "display": "none" });
        $(this).css({ "background-color": "black", "color": "white" });
        $("#basicInfobtn").css({ "background-color": "white", "color": "black" });
        $("#filebtn").css({ "background-color": "white", "color": "black" });
        if (admin) {
            $("#checkBoxForPrivateMessage").css({ "display": "block" })
            $("#privatemessage").innerHTML += 'Check For Public Messages';
        } else {
            $("#checkBoxForPrivateMessage").css({ "display": "none" })
        }
        GetNotes()
        return false;
    })

    $("#filebtn").click(function () {
        $(".eachbox").css({ "display": "none" });
        $("#fileinputbox").css({ "display": "block" });
        $("#noteBox").css({ "display": "none" });
        $(this).css({ "background-color": "black", "color": "white" });
        $("#basicInfobtn").css({ "background-color": "white", "color": "black" });
        $("#noteBoxbtn").css({ "background-color": "white", "color": "black" });
        showfiles();
        return false;
    })

    $("#addNote").click(function () {
        const date = new Date()

        let currentDate = `${String(date.getDate()).padStart(2, '0')}-${String(date.getMonth() + 1).padStart(2, "0")}-${date.getFullYear()}`;
        var objectnote = {}
        var datetime = Date.now();
        objectnote["UserID"] = userId;
        objectnote["Note"] = $("#addNoteTextBox").val();
        objectnote["CreatedOn"] = currentDate.toString();
        if ($("#checkBoxForPrivateMessage").is(":checked")) {
            objectnote["Visible"] = "yes"
        }
        try {
            $.ajax({
                type: "POST",
                url: "Form.aspx/StoreNoteData",
                data: JSON.stringify({ objectnote: objectnote }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    GetNotes()
                },
                Error: function (response) {
                    alert(response);
                }
            });
        } catch (ex) {
            console.log(ex)
        }

        return false;
    })

    $("#countryPresent").change(function () {
        PopulateStatesPresent($("#countryPresent").val())
    })

    $("#countryPermanent").change(function () {
        PopulateStatesPermanent($("#countryPermanent").val())
    })

    $("#Save").click(function () {
        if (Validate()) {

            var allInputs = $(":input");
            var userrole = $("#CheckBoxList1 input");
            var countryState = $("select");
            var user = [];
            var objectuser = {}
            $.each(allInputs, function (index, value) {
                if (($(value).attr('type') === "text" && $(value).attr('name') != "Hobbies") || $(value).attr('type') === "file" ||
                    $(value).attr('type') === "date" || $(value).attr('type') === "tel" ||
                    $(value).attr('type') === "email" || $(value).attr('type') === "password") {
                    objectuser[$(value).attr('name')] = $(value).val();
                }
                else if ($(value).attr('type') == "radio") {
                    objectuser["Gender"] = $("#RadioButtonList1 input:checked").val();
                }
                else if (($(value).attr('name') == "Hobbies" || $(value).attr('name') == "LanguagesKnown") && objectuser[$(value).attr('name')] == null) {
                    objectuser[$(value).attr('name')] = getValueCheckBox($(value).attr('name'))
                }
            })
            $.each(userrole, function (index, value) {
                if ($(value).is(":checked")) {
                    user.push(parseInt($(value).val()));
                }
            })
            objectuser["UserRoles"] = user;
            $.each(countryState, function (index, value) {
                objectuser[$(value).attr('objectName')] = parseInt($(value).val());
            })
            if (userId == null) {
                $.ajax({
                    type: "POST",
                    url: "Form.aspx/StoreData",
                    data: '{objectuser:' + JSON.stringify(objectuser) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                    },
                    Error: function (response) {
                        alert(response);
                    }
                });
                return false;
            } else {
                $.ajax({
                    type: "POST",
                    url: "Form.aspx/StoreUpdatedData",
                    data: JSON.stringify({ userId: userId, objectuser: objectuser }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        alert(response);
                    },
                    Error: function (response) {
                        alert(response);
                    }
                });
                return false;
            }

        } else {
            return false
        }
    })
    function getCountry() {
        $.ajax({
            type: "POST",
            url: "Form.aspx/GetCountryDropList",
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                PopulateCountries(response.d);

            },
            Error: function (response) {
                alert(response);
            }
        });
    }

    $.ajax({
        type: "POST",
        url: "Form.aspx/GetSessionIdForUser",
        data: "",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d["Id"] != -1) {
                getCountry();
                admin = response.d["Admin"];
                const queryStringForForm = window.location.search;
                let paramsForm = new URLSearchParams(queryStringForForm);
                var userIdd = paramsForm.get('userId');
                if (userIdd != null) {
                    if (response.d["Id"] === userId || response.d["Admin"] === true) {
                        if (response.d["Admin"] === true) {
                            $("#Delete").css({ "display": "block" });
                        } else {
                            $("#Delete").css({ "display": "none" });
                            $("#back").css({ "display": "none" });
                        }
                        AddDetails();
                    } else {
                        window.location.href = "Form.aspx?userId=" + response.d["Id"];
                    }
                } else {
                    if (response.d["Admin"] === true) {
                        $("#noteBoxbtn").css({ "display": "none" })
                        $("#filebtn").css({ "display": "none" })
                        $("#Delete").css({ "display": "none" });
                    } else {
                        window.location.href = "Form.aspx?userId=" + response.d["Id"];
                    }
                }
                
            } else {
                window.location.href="LoginPage.aspx"
            }
            
        },
        Error: function (response) {
            alert(response);
        }
    });

    function Addrow(data) {
        $("#filebox1").empty();
        data.forEach(function (item) {

            if (item["UserID"] == userId) {
                var newrow = filerow.replace("[CreatedBy]", item["CreatedBy"]).replace("[filename]", item["Name"]).replace("[createdon]", item["CreatedOn"]).replace("[fileId]", item["ID"]).replace("[filename]", item["Name"]);
                $("#filebox1").append(newrow);
            }

        })
    }

    function showfiles() {
        $.ajax({

            type: "POST",
            url: "Form.aspx/GetAllFiles",
            data: JSON.stringify({id:userId}),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                Addrow(response.d)
            },
            Error: function (response) {
                alert(response);
            }
        });
    }

    $("#uploadBtn").click(function () {
        var fileUpload = $("#FileUpload1").get(0);
        var files = fileUpload.files;
        var data = new FormData();
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }
        $.ajax({
            type: "POST",
            url: "StoreFiles.ashx?userId=" + userId,
            data: data,
            contentType: false,
            processData: false,
            success: function (response) {
                showfiles();
            },
            error: function (response) {
                alert(response);
            }
        });
        return false;

    })

    $("#Delete").click(function(){
        $.ajax({
            type: "POST",
            url: "Form.aspx/DeleteUser?userId="+userId,
            data: "",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                window.location.href="UserTable.aspx"
            },
            Error: function (response) {
                alert(response);
            }
        });
    })

    $("#filebox1").on('click', 'button', (value) => {
        var fileid = $(value.target).attr('fileId');
        if ($(value.target).attr('command') === 'Delete') {
            $.ajax({
                type: "POST",
                url: "Form.aspx/Deletefiles",
                data: JSON.stringify({ fileid: fileid }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    showfiles();
                },
                error: function (response) {
                    alert(response);
                }
            });
        } else if ($(value.target).attr('command') === 'Dwnld') {
            window.location.href="DownloadFile.ashx?filename="+$(value.target).attr('filename')
        }
        value.preventDefault();
    })

    $("#navBar").on('click', '#back', function () {
        window.location.href = "UserTable.aspx";
    })
})
