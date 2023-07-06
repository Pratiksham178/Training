function address(){
    var check=document.getElementById("checkaddr");
    var newaddr=document.getElementById("line1addr");
    var newaddr2=document.getElementById("line2addr");
    var newcity=document.getElementById("pcity");
    var newcode = document.getElementById("prcode");
    var newcountry=document.getElementById("country1");

    var addr1=document.getElementById("line1paddr").value;
    var addr2=document.getElementById("line2paddr").value;
    var state=document.getElementById("state").value;
    var country=document.getElementById("country").value;
    var city=document.getElementById("city").value;
    var code = document.getElementById("pcode").value;


    if(check.checked==true){
      
      var stateper=document.getElementById("state1");
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

      
      
    }
    else{
      document.getElementById("line2addr").value="";
      newaddr.value="";
      document.getElementById("state1").value="";
      document.getElementById("pcity").value="";
      document.getElementById("prcode").value="";
      document.getElementById("country1").value="";
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

    let msg = document.getElementById("msg");
    var msg1 = document.createElement("p");

    var fname = firstname.value;
    var lname = lastname.value;
    var mail = email.value;
    var mob=mobileno.value;
    var dob1=dob.value;
    var profile=image.value;

    var flag = 0;

    const d = new Date();
    var year = dob1.slice(0,4);
    var month = dob1.slice(5,2);
    var date = dob1.slice(8,2);
    var yr = d.getFullYear();
    var mon = d.getMonth();
    var dt = d.getDate();

    if(fname==""){
        firstname.style.border="1px solid red";
        msg1.innerText="Please fill the required field";
        flag=1;
    }else if(fname != "/^[A-Za-z]*/"){
        firstname.style.border="1px solid red";
        let msg2 = document.createElement("p")
        msg2.innerText="Enter correct name";
        msg.appendChild(msg2);
        flag=1;
    }
    if(mail==""){
        email.style.border="1px solid red";
        msg1.innerText="Please fill the required field";
        flag=1;
    }
    if(mob==""){
        mobileno.style.border="1px solid red";
        msg1.innerText="Please fill the required field";
        flag=1;
    }
    if(dob1==""){
        dob.style.border="1px solid red";
        msg1.innerText="Please fill the required field";
        flag=1;
    }else if(date>=dt || year>=yr || month>=mon){
        msg1.innerText="Please fill the required field";
        
        flag=1;
    }
    if(profile==""){
        image.style.border="1px solid red";
        msg.innerText="Please fill the required field";
        flag=1;
    }
    if(flag==1){
        msg.appendChild(msg1);
        msg.style.display="block";
        msg.style.color="brown";
        msg.style.marginLeft="1.4vw";
        return false;
    }
    return true;
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
    console.log(type);
    if(type==="jpg"||type==="jpeg"|| type === "png"){
        document.getElementById("profimage").src=path;
    }else{
        var inc = document.getElementById("incorrectimage");
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