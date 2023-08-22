<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormBasicinfo.ascx.cs" Inherits="UserManagement.FormBasicinfo" %>
<div class="eachbox"><fieldset class="fieldset">
        <legend>Personal Information:</legend>
        <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>First Name:<span>*</span></div>
            <input
              type="text"
              id="fname"
              name="FirstName"
                 Validate="yes"
                
            />
          </div>
          <div class="eachDivInGrid">
            <div>Last Name:</div>
            <input type="text" id="lname" name="LastName"  Validate="yes"
 />
          </div>
            </div>
    <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>Email:<span>*</span></div>
            <input
              type="email"
              id="mail"
              name="email"
                 Validate="yes"
            />
          </div>
          <div class="eachDivInGrid">
            <div>Mobile Number:<span>*</span></div>
              <input
                type="tel"
                id="mob"
                maxlength="10"
                name="Mobile"
                max="10"
                   Validate="yes"
              />
          </div>
        </div>
    <div class="divForUsingGridForTwoColumns">
          
            <div class="eachDivInGrid">
                  Password:<span>*</span>
              <input
              type="password"
              id="password"
              name="Password"
                   Validate="yes"
            />
                </div>
              <div class="eachDivInGrid">
                  DOB:<span>*</span>
              <input
              type="date"
              id="dob"
              name="DOB"
                   Validate="yes"
            />
          </div>
        </div>
          <%--<div class="eachDivInGrid">
            <div>Profile Picture:<span>*</span></div>
            <input type="file" id="image" name="image" runat="server" /><br />
              <p id="incorrectimage"></p>
              </div>--%>
    <div class="divForUsingGridForTwoColumns">
            <div class="eachDivInGrid">
            <div>Gender:<span>*</span><br />
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="134px">
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                </asp:RadioButtonList>
                </div>
              </div>
              <div class="eachDivInGrid">
                  User Role:<span>*</span>
              <asp:CheckBoxList ID="CheckBoxList1" runat="server" clientIDMode="Static">
              </asp:CheckBoxList>
              </div>
        </div>
      </fieldset>
      <fieldset class="fieldset">
        <legend>Additional Information:</legend>
        <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGridInGrid">
            <div>Language Known:</div>
            <input type="checkbox" id="Hindi" name = "LanguagesKnown" value="Hindi" class = "LanguagesKnown"/>
            <label for="Hindi">Hindi</label>
            <input type="checkbox" id="English" name = "LanguagesKnown" value="English" class = "LanguagesKnown"/>
            <label for="English">English</label>
          </div>
          <div class="eachDivInGrid">
            <div>Hobbies:</div>
            <input type="checkbox" id="dancing" name="Hobbies" value="dancing" class="Hobbies" />
            <label for="dancing">Dancing</label>
            <input type="checkbox" id="singing" name="Hobbies" value="Singing" class = "Hobbies"/>
            <label for="singing">Singing</label>
            <input type="checkbox" id="otherHobbyCheckBox"  box-id="otherhobby" class = "Hobbies"/>
            <label for="Others">Others</label>
            <input type="text" id="otherhobby" name = "Hobbies" class = "Hobbies" />
          </div>
        </div>
        <b>Present Address:</b>
        <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>Address Line1:<span>*</span></div>
            <input
              type="text"
              id="line1AddressPresent"
              name="AddressLine1Present"
              address="Present Address"
                copyTo="line1AddressPermanent"
             
                 Validate="yes"
            />
          </div>
          <div class="eachDivInGrid">
            <div>Address Line2:</div>
            <input
              type="text"
              id="line2AddressPresent"
              name="AddressLine2Present"
              address="Present Address"
              copyTo="line2AddressPermanent"
                 Validate="yes"
            />
          </div>
           </div>
          <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>Country:<span>*</span>
                <asp:DropDownList ID="countryPresent"  Validate="yes" address="Present Address" runat="server"  copyTo="countryPermanent" objectname="CountryPresent" >
                </asp:DropDownList>
              </div></div>
          <div class="eachDivInGrid">
            <div>State:<span>*</span><asp:DropDownList  Validate="yes" ID="statePresent" copyTo="statePermanent" runat="server" address="Present Address" objectname="StatePresent">
                </asp:DropDownList>
              </div></div>
              </div>
          <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>City:<span>*</span></div>
            <input
              id="cityPresent"
              type="text"
              name="CityPresent"
              address="Present Address"
            copyTo="cityPermanent"
                 Validate="yes"
            />
          </div>
          <div class="eachDivInGrid">
            <div>Postal Code:<span>*</span></div>
            <input
              id="pcodePresent"
              name="ZipcodePresent"
              type="text"
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
              name="AddressLine1Permanent"
                address="Permanent address"
                 Validate="yes"
            />
          </div>
          <div class="eachDivInGrid">
            <div>Address Line2:</div>
            <input
              type="text"
              id="line2AddressPermanent"
              name="AddressLine2Permanent"
                address="Permanent address"
                 Validate="yes"
            />
          </div>
            </div>
            <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>Country:<span>*</span></div>
              <asp:DropDownList ID="countryPermanent" objectname="CountryPermanent" Validate="yes" address="Permanent address" runat="server">
              </asp:DropDownList>
&nbsp;</div>
          <div class="eachDivInGrid">
            <div>State:<span>*</span></div>
              <asp:DropDownList ID="statePermanent" objectname="StatePermanent" Validate="yes" runat="server" address="Permanent address">
              </asp:DropDownList>
              &nbsp;</div>
                </div>
            <div class="divForUsingGridForTwoColumns">
          <div class="eachDivInGrid">
            <div>City:<span>*</span></div>
            <input
              id="cityPermanent"
              type="text"
              name="CityPermanent"
                address="Permanent address"
                 Validate="yes"
            />
          </div>
          <div class="eachDivInGrid">
            <div>Postal Code:<span>*</span></div>
            <input
              id="pcodePermanent"
              name="ZipcodePermanent"
              type="text"
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
          <asp:Button  ID="Save" runat="server" Text="Add User" CssClass="btn_Submit" type="button"  clientIDMode="Static"/>
          <asp:Button  ID="Cancel"  runat="server" Text="Cancel" CssClass="btn_Submit" type="button" clientIDMode="Static" />
      </div>
    </div>