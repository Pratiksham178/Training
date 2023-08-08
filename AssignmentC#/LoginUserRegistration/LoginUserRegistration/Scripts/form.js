$(document).ready(function () {
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
        return false;
    })
    $("#filebtn").click(function () {
        $(".eachbox").css({ "display": "none" });
        $("#fileinputbox").css({ "display": "block" });
        $("#noteBox").css({ "display": "none" });
        $(this).css({ "background-color": "black", "color": "white" });
        $("#basicInfobtn").css({ "background-color": "white", "color": "black" });
        $("#noteBoxbtn").css({ "background-color": "white", "color": "black" });
        return false;
    })


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