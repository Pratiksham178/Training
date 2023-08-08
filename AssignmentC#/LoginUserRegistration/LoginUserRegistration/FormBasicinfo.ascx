<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormBasicinfo.ascx.cs" Inherits="LoginUserRegistration.FormBasicinfo"  %>
<div class="eachbox"><fieldset class="fieldset">
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
    </div>