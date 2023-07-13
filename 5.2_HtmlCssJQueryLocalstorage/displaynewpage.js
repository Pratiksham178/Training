$(document).ready(function(){
    var obj1 = JSON.parse(localStorage.getItem("obj"));
    $("#printInformation").append(`<thead><td class="yourdetails">Your Details:</td><td><img id="imageown" alt="image"/></td>`).css({"width":"100%"});
    $("#imageown").attr("src",localStorage.getItem("imagesrc"));
    $.each(obj1,function(index,value){
        if(jQuery.type(value) === "object"){
            $("#printInformation").append(`<tr><td class="address">${index}</td></tr>`);
            $(".address").css({"fontWeight":"700"});
            $.each(value,function(indexaddress,valueofaddress){
                $("#printInformation").append(`<tr><td class="infohead">${indexaddress}:</td><td class="info">${valueofaddress}</td></tr>`);
                $(".infohead").css({"width":"60%"});
            })
        }else{
            $("#printInformation").append(`<tr><td class="infohead">${index}:</td><td class="info">${value}</td></tr>`).css({"width":"100%"});
            $(".infohead").css({"width":"55%"});
        }
    })
})