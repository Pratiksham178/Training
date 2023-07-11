function address(){
    var check=document.getElementById("checkBoxForSamePermanentAndPresentAddress");
    var newaddr=document.getElementById("line1AddressPermanent");
    var newaddr2=document.getElementById("line2AddressPermanent");
    var newcity=document.getElementById("cityPermanent");
    var newcode = document.getElementById("pcodePermanent");
    var newcountry=document.getElementById("countryPermanent");

    var addr1=document.getElementById("line1AddressPresent").value;
    var addr2=document.getElementById("line2AddressPresent").value;
    var state=document.getElementById("statePresent").value;
    var country=document.getElementById("countryPresent").value;
    var city=document.getElementById("cityPresent").value;
    var code = document.getElementById("pcodePresent").value;

    
    if(check.checked==true){
      
      var stateper=document.getElementById("statePermanent");
      stateper.options[0]=new Option(state,state)

      newaddr.value=addr1
      newaddr2.value=addr2;
      newcity.value=city;
      newcode.value=code;
      newcountry.value=country;
      stateper.value=state;

      newaddr.disabled=true;
      newaddr2.disabled=true;
      newcity.disabled=true;
      newcode.disabled=true;
      newcountry.disabled=true;
      stateper.disabled=true;

      newaddr.style.border="1px solid grey";
      newaddr2.style.border="1px solid grey";
      newcity.style.border="1px solid grey";
      newcode.style.border="1px solid grey";
      newcountry.style.border="1px solid grey";
      stateper.style.border="1px solid grey";

      
      
    }
    else{
      document.getElementById("line2AddressPermanent").value="";
      newaddr.value="";
      document.getElementById("statePermanent").value="";
      document.getElementById("cityPermanent").value="";
      document.getElementById("pcodePermanent").value="";
      document.getElementById("countryPermanent").value="";
      newaddr.disabled=false;
      newaddr2.disabled=false;
      newcity.disabled=false;
      newcode.disabled=false;
      newcountry.disabled=false;
    }

  }

function checkNull(elementId){
    var valueId = document.getElementById(elementId)
    var flag=0
    if(valueId.value==="" ){
        valueId.style.border="1px solid brown";
        flag=1
    }
    return flag
}

function getValueFromRadioAndCheckBox(elementName){
    var gendervalue = document.getElementsByName(elementName);
    var ans =[]
    for(let i=0;i<gendervalue.length;i++){
        if(gendervalue[i].checked){
            ans.push(gendervalue[i].value)
        }
        if(gendervalue[i].type=="text"){
            ans.push(gendervalue[i].value)
        }
    }
    var answer = ans.toString()
    return answer
}
function printInformationInScreen(info,infohead){
    var tablecolumninfo = document.createElement("td");
    var tablecolumninfohead = document.createElement("td");
    var table = document.getElementById("printInformation");
    var row = document.createElement("tr");
    tablecolumninfohead.innerText = infohead + ":";
    tablecolumninfo.innerText = info;
    row.appendChild(tablecolumninfohead);
    row.appendChild(tablecolumninfo);
    table.appendChild(row);
    tablecolumninfohead.style.width="60%";
    tablecolumninfo.style.width="40%";
    

}
function validate(){
    var fname = document.getElementById("fname");
    var lname = document.getElementById("lname");
    var mail = document.getElementById("mail");
    var mob = document.getElementById("mob");
    var dob = document.getElementById("dob");
    var image = document.getElementById("image");
    var addr1 = document.getElementById("line1AddressPresent");
    var addr2 = document.getElementById("line2AddressPresent").value;
    var country = document.getElementById("countryPresent");
    var state = document.getElementById("statePresent");
    var city = document.getElementById("cityPresent");
    var pcode = document.getElementById("pcodePresent");
    var addr1per = document.getElementById("line1AddressPermanent");
    var addr2per = document.getElementById("line2AddressPermanent").value;
    var countryper = document.getElementById("countryPermanent");
    var stateper = document.getElementById("statePermanent");
    var cityper = document.getElementById("cityPermanent");
    var pcodeper = document.getElementById("pcodePermanent");
    let msg = document.getElementById("msg");
    msg.innerText="";
    var msg1 = document.createElement("p");
    var msg2 = document.createElement("p");

    const array = ["fname","lname","mail","mob","dob",'image',
    "line1AddressPresent","countryPresent","cityPresent","pcodePresent","statePresent",
    "line1AddressPermanent","countryPermanent","cityPermanent","pcodePermanent","statePermanent"]

    var flag = 0;
    var flagcheck=0;

    var dob1=dob.value;
    const d = new Date();
    var year = Number(dob1.slice(0,4));
    var yr = Number(d.getFullYear());
    for(let i=0;i<array.length;i++){
        flagcheck=checkNull(array[i]);
    }
    if(!fname.value.match(/^[A-Za-z]+/) && fname.value!=""){
        fname.style.border="1px solid brown";
        msg2.innerText="Enter correct name";
        msg.append(msg2)
        flag=2
    }
    if( yr-year<18){
        msg2.innerText="You need to be 18 by 01-01-2023";
        msg.append(msg2);
        flag=2
    }
    if(!(lname.value.match(/^[A-Za-z]+/)) && lname.value!=""){
        lname.style.border="1px solid brown";
        let msg2 = document.createElement("p")
        msg2.innerText="Enter correct name";
        msg.append(msg2)
        flag=2
    }
    
    if(flag==2|| flagcheck==1){
        msg.style.display="block";
        msg.style.color="brown";
        msg.style.marginLeft="1.4vw";
        if(flagcheck==1){
            msg1.innerText="Please enter required field"
            msg.appendChild(msg1);
        }
        return false;
    }else{
        msg.remove()
    }
    var gender = getValueFromRadioAndCheckBox("genderbox")
    var lang = getValueFromRadioAndCheckBox("lang")
    var hobbies = getValueFromRadioAndCheckBox("hobby")
    const info={
        First_Name : fname.value,
        Last_Name : lname.value,
        Email : mail.value,
        Mobile_No : mob.value,
        Gender : gender,
        DOB : dob1,
        Profile : image.value,
        Language : lang,
        hobby : hobbies,
        PresentAddress : {
            AddressLine1 : addr1.value,
            AddressLine2 :  addr2,
            City :  city.value,
            State :  state.value,
            Country :  country.value,
            PostalCode :  pcode.value,
        },
        PermanentAddress : {
            Address1 : addr1per.value,
            Address2 :  addr2per,
            City :  cityper.value,
            State :  stateper.value,
            Country :  countryper.value,
            PostalCode :  pcodeper.value,
        }
    }
    console.log(info)
    for(let x in info){
        table=document.getElementById("printInformation");
        row=document.createElement("tr");
        td=document.createElement("td");
        td.colspan = "2";
        if(typeof info[x] === "object"){
            td.innerText=x;
            td.style.fontWeight="700";
            row.appendChild(td);
            table.appendChild(row);
            for(let addrinfo in info[x]){
                printInformationInScreen(info[x][addrinfo],addrinfo)
            }
            
        }
        else{
            printInformationInScreen(info[x],x)
        }
        
    }
    return false;
}

function addImage(){
    let file = document.getElementById("image");
    let path = URL.createObjectURL(file.files[0]);
    let type = file.files[0].name.split(".").pop();
    var inc = document.getElementById("incorrectimage");
    console.log(type);
    file.style.color = "black";
    if(type==="jpg"||type==="jpeg"|| type === "png"){
        document.getElementById("profimage").src=path;
        inc.innerText="";
    }else{
        inc.innerText="Please upload correct file type";
        file.value ="";
        inc.style.color="brown";
    }
    file.style.border = "none"
}
function changeColor(elementId){
    box=document.getElementById(elementId);
    box.style.border = "1px solid grey";
    
}

document.addEventListener("change",(e)=>{
    let elementId=e.target.id
    
    if(elementId!=""){
        if(elementId==="image"){
            addImage()
        }else if(e.target.address="present"){
            address()
            changeColor(elementId)
        }
        else{
            changeColor(elementId)
        }
    }
})
document.addEventListener("click",(e)=>{
    let checkId = e.target.id;
    if(checkId!=""){
        
        if(checkId==="otherHobbyCheckBox"){
            if(e.target.checked){
                let hobbies = document.getElementById("otherhobby");
                hobbies.style.display="inline";
            }
            else{
                let hobbies = document.getElementById("otherhobby");
                hobbies.style.display="none";
            }
        }else if(checkId==="otherLanguageCheckBox"){
            if(e.target.checked==true){
                let hobbies = document.getElementById("otherlang");
                hobbies.style.display="inline";
            }
            else{
                let hobbies = document.getElementById("otherlang");
                hobbies.style.display="none";
            }
        }
    }
})