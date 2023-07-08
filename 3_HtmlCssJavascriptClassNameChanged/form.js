function address(){
    var check=document.getElementById("checkBoxForSamePermanentAndPresentAddress");
    var newaddr=document.getElementById("line1AddressPermanent");
    var newaddr2=document.getElementById("line2AddressPermanent");
    var newcity=document.getElementById("cityPermanent");
    var newcode = document.getElementById("codePermanent");
    var newcountry=document.getElementById("countryPermanent");

    var addr1=document.getElementById("line1AddressPresent").value;
    var addr2=document.getElementById("line2AddressPresent").value;
    var state=document.getElementById("statePresent").value;
    var country=document.getElementById("countryPresent").value;
    var city=document.getElementById("cityPresent").value;
    var code = document.getElementById("codePresent").value;

    
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
      document.getElementById("codePermanent").value="";
      document.getElementById("countryPermanent").value="";
      newaddr.disabled=false;
      newaddr2.disabled=false;
      newcity.disabled=false;
      newcode.disabled=false;
      newcountry.disabled=false;
    }

  }

function validate(){
    var firstname = document.getElementById("fname");
    var lastname = document.getElementById("lname");
    var email = document.getElementById("mail");
    var mobileno = document.getElementById("mob");
    var dob = document.getElementById("dob");
    var image = document.getElementById("image");
    var addr1 = document.getElementById("line1AddressPresent");
    var addr2 = document.getElementById("line2AddressPresent");
    var country = document.getElementById("countryPresent");
    var state = document.getElementById("statePresent");
    var city = document.getElementById("cityPresent");
    var pcode = document.getElementById("codePresent");
    var addr1per = document.getElementById("line1AddressPermanent");
    var addr2per = document.getElementById("line2AddressPermanent");
    var countryper = document.getElementById("countryPermanent");
    var stateper = document.getElementById("statePermanent");
    var cityper = document.getElementById("cityPermanent");
    var pcodeper = document.getElementById("codePermanent");
    let msg = document.getElementById("msg");
    msg.innerText="";
    var msg1 = document.createElement("p");

    var fname = firstname.value;
    var lname = lastname.value;
    var mail = email.value;
    var mob=mobileno.value;
    var dob1=dob.value;
    var profile=image.value;

    var flag = 0;

    const d = new Date();
    var year = Number(dob1.slice(0,4));
    var month = Number(dob1.slice(5,7));
    var date = Number(dob1.slice(8,10));
    var yr = Number(d.getFullYear());
    var mon = Number(d.getMonth());
    var dt = Number(d.getDate());
    console.log(date)
    console.log(dt);
    console.log(month)
    console.log(mon);
    console.log(year)
    console.log(yr)

    //first name validation
    if(fname.trim()===""){
        firstname.style.border="1px solid brown";
        msg1.innerText="Please fill the required field";
        flag=1;
    }else if(fname.trim().match("/^[A-Za-z]+/")){
        firstname.style.border="1px solid brown";
        let msg2 = document.createElement("p")
        msg2.innerText="Enter correct name";
        msg.appendChild(msg2);
        flag=1;
    }
    //lastname validation
    if(lname.match("/^[A-Za-z]*/") && lname!=""){
        lastname.style.border="1px solid brown";
        let msg2 = document.createElement("p")
        msg2.innerText="Enter correct name";
        msg.appendChild(msg2);
        flag=1;
    }
    //mail validation
    var atPos = mail.indexOf("@");
    var dotPos = mail.lastIndexOf(".");
    if(mail===""){
        email.style.border="1px solid brown";
        msg1.innerText="Please fill the required field";
        flag=1;
    }else if((atPos > 0 && dotPos > atPos + 1 && dotPos < mail.length - 1)!=true){
        email.style.border="1px solid brown";
        let msg3 = document.createElement("p")
        msg3.innerText="Enter correct name";
        msg.appendChild(msg3);
        flag=1;
    }
    if(mob===""){
        mobileno.style.border="1px solid brown";
        msg1.innerText="Please fill the required field";
        flag=1;
    }
    if(dob1===""){
        dob.style.border="1px solid brown";
        msg1.innerText="Please fill the required field";
        flag=1;
    }else if( yr-year<18){
        msg1.innerText="You need to be 18 by 01-01-2023";
        flag=1;
    }
    if(profile===""){
        image.style.color="brown";
        msg1.innerText="Please fill the required field";
        flag=1;
    }


    if(addr1.value===""){
        addr1.style.border="1px solid brown";
        msg1.innerText="Please fill the required field";
        flag=1;
    }
    if(addr2.value===""){
        addr2.style.border="1px solid brown";
        msg1.innerText="Please fill the required field";
        flag=1;
    }
    if(city.value===""){
        city.style.border="1px solid brown";
        msg1.innerText="Please fill the required field";
        flag=1;
    }
    if(country.value==-1){
        country.style.border="1px solid brown";
        msg1.innerText="Please fill the required field";
        flag=1;
    }
    if(pcode.value===""){
        pcode.style.border="1px solid brown";
        msg1.innerText="Please fill the required field";
        flag=1;
    }
    if(state.value===""){
        state.style.border="1px solid brown";
        msg1.innerText="Please fill the required field";
        flag=1;
    }

    var check = document.getElementById("checkBoxForSamePermanentAndPresentAddress");
    if(check.checked!=true){
        if(addr1per.value===""){
            addr1per.style.border="1px solid brown";
            msg1.innerText="Please fill the required field";
            flag=1;
        }
        if(addr2per.value===""){
            addr2per.style.border="1px solid brown";
            msg1.innerText="Please fill the required field";
            flag=1;
        }
        if(cityper.value===""){
            cityper.style.border="1px solid brown";
            msg1.innerText="Please fill the required field";
            flag=1;
        }
        if(countryper.value==-1){
            countryper.style.border="1px solid brown";
            msg1.innerText="Please fill the required field";
            flag=1;
        }
        if(pcodeper.value===""){
            pcodeper.style.border="1px solid brown";
            msg1.innerText="Please fill the required field";
            flag=1;
        }
        if(stateper.value===""){
            stateper.style.border="1px solid brown";
            msg1.innerText="Please fill the required field";
            flag=1;
        }
    }
    if(flag==1){
        msg.appendChild(msg1);
        msg.style.display="block";
        msg.style.color="brown";
        msg.style.marginLeft="1.4vw";
    }
    return false;
}
  
function handlehobby(){
    let check = document.getElementById("Others");
    if(check.checked==true){
        let hobbies = document.getElementById("otherhobby");
        hobbies.style.display="inline";
    }
    else{
        let hobbies = document.getElementById("otherhobby");
        hobbies.style.display="none";
    }
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
}
function handlelang(){
    let check = document.getElementById("Otherlanguage");
    if(check.checked==true){
        let hobbies = document.getElementById("otherlang");
        hobbies.style.display="inline";
    }
    else{
        let hobbies = document.getElementById("otherlang");
        hobbies.style.display="none";
    }
}
function changeColor(elementId){
    box=document.getElementById(elementId);
    box.style.border = "1px solid grey";
    
}