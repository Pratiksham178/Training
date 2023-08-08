<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormPage.aspx.cs" Inherits="RegistrationFormUser.FormPage1" %>
<%@ Register Src="~/NoteBox.ascx" TagPrefix="nt" TagName="Note" %>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link
      rel="stylesheet"
      href="https://fonts.googleapis.com/css?family=Space+Mono|Muli"
    />
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js"></script>
    <link rel="stylesheet" href="./content/form.css" />
     <script src='<%=ResolveClientUrl("~/Scripts/form.js") %>' type="text/javascript"></script>
    <title>Registration Form</title>
  </head>
  <body>
      <form ID="form1" runat="server">
      <div id="registrationFormHeading">
        <img
          src="https://static.vecteezy.com/system/resources/previews/005/544/718/original/profile-icon-design-free-vector.jpg"
          id="profimage"
          alt="image"
        />
        <div id="registrationFormText">Registration Form</div>
        <div>
            <Button  OnserverClick="DeleteUser" runat="server"  ID="Delete" visible="false"><i class="fa fa-trash"></i> </Button>
        </div>
      </div>
      <fieldset class="fieldset">
        <legend>Personal Information:</legend>
        <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>First Name:<span>*</span></div>
            <input
              type="text"
              id="fname"
              name="fname"
              runat="server"
                 Validate="yes"
            />
          </div>
          <div class="eachDivInGrid">
            <div>Last Name:</div>
            <input type="text" id="lname" name="lname" runat="server"  Validate="yes"
 />
          </div>
          <div class="eachDivInGrid">
            <div>Email:<span>*</span></div>
            <input
              type="email"
              id="mail"
              name="mail"
              runat="server"
                 Validate="yes"
            />
          </div>
          <div class="eachDivInGrid">
            <div>Mobile Number:<span>*</span></div>
              <input
                type="tel"
                id="mob"
                maxlength="10"
                name="mob"
                max="10"
                runat="server"
                   Validate="yes"
              />
          </div>
          <div class="eachDivInGrid">
            <div>Gender:<span>*</span><br />
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="134px">
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                </asp:RadioButtonList>
                </div>
            
              <div class="eachDivInGrid">
                  DOB:<span>*</span></div>
              <input
              type="date"
              id="dob"
              name="dob"
              runat="server"
                   Validate="yes"
            />
          </div>
          <%--<div class="eachDivInGrid">
            <div>Profile Picture:<span>*</span></div>
            <input type="file" id="image" name="image" runat="server" /><br />
              <p id="incorrectimage"></p>
              </div>--%>
              <div class="eachDivInGrid">
                  User Role:<span>*</span>
              <asp:CheckBoxList ID="CheckBoxList1" runat="server" >
              </asp:CheckBoxList>
              
        </div>
      </fieldset>
      <fieldset class="fieldset">
        <legend>Additional Information:</legend>
        <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGridInGrid">
            <div>Language Known:</div>
            <input type="checkbox" id="Hindi" name = "lang" value="Hindi" runat="server"/>
            <label for="Hindi">Hindi</label>
            <input type="checkbox" id="English" name = "lang" value="English" runat="server"/>
            <label for="English">English</label>
          </div>
          <div class="eachDivInGrid">
            <div>Hobbies:</div>
            <input type="checkbox" id="dancing" name = "hobby" value="Dancing" runat="server"/>
            <label for="dancing">Dancing</label>
            <input type="checkbox" id="singing" name = "hobby" value="Singing" runat="server"/>
            <label for="singing">Singing</label>
            <input type="checkbox" id="otherHobbyCheckBox" runat="server" box-id="otherhobby"/>
            <label for="Others">Others</label>
            <input type="text" id="otherhobby" name = "hobby" runat="server" />
          </div>
        </div>
        <b>Present Address:</b>
        <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>Address Line1:<span>*</span></div>
            <input
              type="text"
              id="line1AddressPresent"
              name="line1paddr"
              address="Present Address"
                copyTo="line1AddressPermanent"
                runat="server"
                 Validate="yes"
            />
          </div>
          <div class="eachDivInGrid">
            <div>Address Line2:</div>
            <input
              type="text"
              id="line2AddressPresent"
              name="line2paddr"
              address="Present Address"
                runat="server"
              copyTo="line2AddressPermanent"
                 Validate="yes"
            />
          </div>
           </div>
           <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
          <asp:UpdatePanel ID="updatepnl" runat="server">  
           <ContentTemplate> 
          <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>Country:<span>*</span>
                <asp:DropDownList ID="countryPresent"  Validate="yes" address="Present Address" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PopulateStatesPresent" copyTo="countryPermanent">
                </asp:DropDownList>
              </div></div>
          <div class="eachDivInGrid">
            <div>State:<span>*</span><asp:DropDownList  Validate="yes" ID="statePresent" copyTo="statePermanent" runat="server" address="Present Address">
                </asp:DropDownList>
              </div></div>
              </div>
               </ContentTemplate>
              </asp:UpdatePanel>
          <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>City:<span>*</span></div>
            <input
              id="cityPresent"
              type="text"
              name="city"
              address="Present Address"
                runat="server"
            copyTo="cityPermanent"
                 Validate="yes"
            />
          </div>
          <div class="eachDivInGrid">
            <div>Postal Code:<span>*</span></div>
            <input
              id="pcodePresent"
              name="pcode"
              type="text"
              runat="server"
                copyTo="pcodePermanent"
                address="Present Address"
                 Validate="yes"
            />
          </div>
              </div>
        <b>Permanent Address:</b>
        <input
          type="checkbox"
          id="checkBoxForSamePermanentAndPresentAddress"
          name="checkaddr"
        onserverclick="SameAddress"
            runat="server"
        />
        <label for="checkBoxForSamePermanentAndPresentAddress"
          ><span id="checkboxaddr"
            >If your present address is same as permanent</span
          ></label
        >
        <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>Address Line1:<span>*</span></div>
            <input
              type="text"
              id="line1AddressPermanent"
              name="line1addr"
                runat="server"
                address="Permanent address"
                 Validate="yes"
            />
          </div>
          <div class="eachDivInGrid">
            <div>Address Line2:</div>
            <input
              type="text"
              id="line2AddressPermanent"
              name="line2addr"
                runat="server"
                address="Permanent address"
                 Validate="yes"
            />
          </div>
            </div>
          <asp:UpdatePanel ID="UpdatePanel2" runat="server">  
           <ContentTemplate> 
            <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>Country:<span>*</span></div>
              <asp:DropDownList ID="countryPermanent" Validate="yes" address="Permanent address" runat="server" AutoPostBack="true" onSelectedIndexChanged="PopulateStatesPermanent">
              </asp:DropDownList>
&nbsp;</div>
          <div class="eachDivInGrid">
            <div>State:<span>*</span></div>
              <asp:DropDownList ID="statePermanent"  Validate="yes" runat="server" address="Permanent address">
              </asp:DropDownList>
              &nbsp;</div>
                </div>
               </ContentTemplate>
             </asp:UpdatePanel>
            <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>City:<span>*</span></div>
            <input
              id="cityPermanent"
              type="text"
              name="pcity"
                runat="server"
                address="Permanent address"
                 Validate="yes"
            />
          </div>
          <div class="eachDivInGrid">
            <div>Postal Code:<span>*</span></div>
            <input
              id="pcodePermanent"
              name="prcode"
              type="text"
                runat="server"
                address="Permanent address"
                 Validate="yes"
            />
          </div>
        </div>
      </fieldset>
      <div id="subs">
        <input type="checkbox" id="checkBoxForSubscription" />
        <label for="checkBoxForSubscription">Suscribe to our newsletter</label>
      </div>
      <div id="msg"></div> 
      <div id="submit">
          <asp:Button  ID="Save" OnClick="SaveChanges" OnClientClick="return Validate();" runat="server" Text="Add User" CssClass="btn_Submit" />
          <asp:Button  ID="Cancel" OnClick="CancelChanges"  runat="server" Text="Cancel" CssClass="btn_Submit"/>
      </div>
           <nt:Note runat="server" ID="notetextbox_input"  />
      </form>
</body>
</html>