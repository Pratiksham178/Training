$(document).ready(function(){
    $.getJSON('countries.json',function(country){
        function populateStates(countryId,stateId){
            var SelectedCountryindex = $(`#${countryId}`).prop('selectedIndex');
            $(`#${stateId}`).empty().append(new Option("", ""))
	        $(`#${stateId}`).selectedIndex = 0;
            if(SelectedCountryindex>0){
                $.each(country[SelectedCountryindex-1].states,function(index,value){
                    $(`#${stateId}`).append(new Option(value, value));
                })
            }
        }
        function populateCountries(countryId,stateId){
            $(`#${countryId}`).append(new Option("", ""));
            $(`#${countryId}`).selectedIndex = 0;
            $.each(country,function(index,value){
                $(`#${countryId}`).append(new Option(value.country, value.country));
            });
            $(`#${countryId}`).change(function(){
                populateStates(countryId,stateId);
            });
        }
        populateCountries("countryPresent","statePresent");
        if(!($("#checkBoxForSamePermanentAndPresentAddress").is(":checked"))){
            populateCountries("countryPermanent","statePermanent")
        } 
        function addressSamePresentPermanent(){
            if($("#checkBoxForSamePermanentAndPresentAddress").is(":checked")){
                populateStates("countryPresent","statePermanent");
                $("[address='Present Address']").each(function(index,value){
                    $(`#${ $(value).attr("copyTo")}`).val($(`#${value.id}`).val()).
                    css({"border":"1px solid grey"}).prop('disabled', true);
                }) 
            }else{
                $("[address='Permanent Address']").prop('disabled', false)
            }
        }
        function addImage(){
            if($("#image").get(0).files[0]=="" || $("#image").get(0).files[0]== null){
                $("#profimage").attr("src","https://static.vecteezy.com/system/resources/previews/005/544/718/original/profile-icon-design-free-vector.jpg");
            }else{
                let path = URL.createObjectURL($("#image").get(0).files[0]);
                let type = $("#image").css({"border":"none"}).get(0).files[0].name.split(".").pop();
                if(type==="jpg"||type==="jpeg"|| type === "png"){
                    $("#profimage").attr("src",path);
                    $("#incorrectimage").text("");
                }else{
                    $("#incorrectimage").text("Please upload correct file type").css({"color":"brown"});
                    $("#image").val("").css({"border":"none"});
                }
            }
        }
        $(".form").change((e)=>{
            if(e.target.id!=""){
                if(e.target.id==="image"){
                    addImage();
                }
                else{
                    if(e.target.id==="checkBoxForSamePermanentAndPresentAddress" || 
                    $(e.target).attr("address")==="Present Address"){
                        addressSamePresentPermanent();
                    }else if(e.target.id==="otherHobbyCheckBox" || e.target.id==="otherLanguageCheckBox"){
                        var target = $(e.target).attr("box-id");
                        if($(`#${e.target.id}`).is(":checked")){
                            $(`#${target}`).css({"display":"inline"});
                        }else{
                            $(`#${target}`).css({"display":"none"})
                        }
                    }
                    $(`#${e.target.id}`).css({"border":"1px solid grey"});
                }
            }
        })
    })
    function validateEmptyField(elementId){
        if($(`#${elementId}`).val()==="" || $(`#${elementId}`).val()===null){
            $(`#${elementId}`).css({"border":"1px solid brown"});
            return 1;
        }
        return 0
    }
    function getValueFromRadioAndCheckBox(elementName){
        var ans =[]
        $(`.${elementName}`).each(function(index,eachelement){
            if($(eachelement).is(":checked")){
                ans.push($(eachelement).val())
            }
            if($(eachelement).attr("type")==="text"){
                ans.push($(eachelement).val())
            }
        })
        return ans.toString()
    }
    $("#submit").click(function(){
        var allInputs = $(":input");
        var flag=0;
        var obj={};
        var PresentAddress={};
        var PermanentAddress={};
        $("#msg").empty();
        $.each(allInputs,function(index,value){
            if(($(value).attr('type')=="text"|| $(value).attr('type')==="file" || 
            $(value).attr('type')==="date" || $(value).attr('type')==="tel"|| $(value).attr('type')==="email" 
            || $(value).attr('class')==="Country"||$(value).attr('class')==="State") && 
            (value.id!="otherhobby" && value.id!="otherlang")){
                flag=validateEmptyField(value.id);
                flagcheck=1;
            }
            if(value.id=="fname"||value.id=="lname"){
                if($(value).val()!="" &&  !$(value).val().match(/^[A-Za-z]+/)){
                    $(value).css({"border":"1px solid brown"})
                    $("#msg").append('<p>Incorrect name</p>');
                    flag=1;
                }
            }
            if(value.id=="dob" && $(value).val()!=""){
                var date = new Date();
                if(Number(date.getFullYear())-Number($(value).val().slice(0,4))<18){
                    $(value).css({"border":"1px solid brown"})
                    $("#msg").append('<p>You need to be 18 by 01-01-2023</p>');
                    flag=1;
                }
            }
        })
        if(flag>0){
            $("#msg").css({"color":"brown","display":"block"});
            if(flagcheck==1){
                $("#msg").append('<p>Please enter required details</p>');
            }
        }else{
            let path = URL.createObjectURL($("#image").get(0).files[0]);
            $("#printInformation").append(`<thead><td class="yourdetails">Your Details:</td><td><img src=${path} id="imageown" alt="image"/></td>`).css({"width":"100%"});
            $.each(allInputs,function(index,value){
                if(($(value).attr('type')==="text"|| $(value).attr('type')==="file" || 
                $(value).attr('type')==="date" || $(value).attr('type')==="tel"|| 
                $(value).attr('type')==="email") && $(value).attr('address')!="Present Address" &&  
                $(value).attr('address')!="Permanent Address" && value.id!="otherhobby" && value.id!="otherlang"){
                    obj[$(value).attr('name')] = $(value).val();
                }
                else if($(value).attr('address')==="Present Address"){
                    PresentAddress[$(value).attr('name')]=$(value).val();
                }else if($(value).attr('address')==="Permanent Address"){
                    PermanentAddress[$(value).attr('name')]=$(value).val();
                }else if(($(value).attr('type')==="checkbox" || $(value).attr('type')==="radio")  && ($(value).attr("name")==="LanguageKnown" || $(value).attr("name")==="hobby" || $(value).attr("name")==="Gender")){
                    obj[$(value).attr("name")]=getValueFromRadioAndCheckBox($(value).attr("name"));
                }
            })
            obj["Present Address"]=PresentAddress;
            obj["Permanent Address"]=PermanentAddress;
            console.log(obj)
            $.each(obj,function(index,value){
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
        }
    })
})