using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;

namespace LoginUserRegistration
{
    public partial class FormBasicinfo : System.Web.UI.UserControl
    {

        public ProfileEntities dbcontext = new ProfileEntities();
        public int specificUserId;
        public userDetails user;
        protected void Addcountry()
        {
            var country = dbcontext.country_list.ToList();
            countryPresent.Items.Add(new ListItem("Choose country", "0"));
            countryPermanent.Items.Add(new ListItem("Choose country", "0"));
            foreach (var item in country)
            {
                countryPresent.Items.Add(new ListItem(item.countryName, item.ID.ToString()));
                countryPermanent.Items.Add(new ListItem(item.countryName, item.ID.ToString()));
            }
        }
        public void PopulateStates(DropDownList ddlCountry, DropDownList ddlStates)
        {
            int countryId = Int32.Parse(ddlCountry.SelectedItem.Value);
            ddlStates.Items.Clear();
            ddlStates.Items.Add(new ListItem("Choose state", "0"));
            var states = dbcontext.statelist_table.Where((i) => i.countryID == countryId).ToList();
            foreach (var state in states)
            {
                ddlStates.Items.Add(new ListItem(state.stateName, state.ID.ToString()));
            }
        }

        protected void PopulateStatesPresent(object sender, EventArgs e)
        {
            PopulateStates(countryPresent, statePresent);
        }
        protected void PopulateStatesPermanent(object sender, EventArgs e)
        {
            PopulateStates(countryPermanent, statePermanent);
        }

        protected void AddHobby(string hobbyname, int userIdd)
        {
            Hobby_table hobby = new Hobby_table
            {
                userID = userIdd,
                hobby = hobbyname
            };
            dbcontext.Hobby_table.Add(hobby);
        }
        protected void AddLang(string langname, int userIdd)
        {
            language_table lang = new language_table
            {
                userID = userIdd,
                language = langname
            };
            dbcontext.language_table.Add(lang);
        }
        protected void AddHobbyLangToDB(int userIdd)
        {
            if (Request.Params["userId"] != null)
            {
                using (var db = new ProfileEntities())
                {
                    var deletehobbies = dbcontext.Hobby_table.Where((i) => i.userID == userIdd).ToList();
                    dbcontext.Hobby_table.RemoveRange(deletehobbies);
                    var deletelanguages = dbcontext.language_table.Where((i) => i.userID == userIdd).ToList();
                    dbcontext.language_table.RemoveRange(deletelanguages);
                }

            }
            if (dancing.Checked)
            {
                AddHobby("dancing", userIdd);
            }
            if (singing.Checked)
            {
                AddHobby("Singing", userIdd);
            }
            if (otherHobbyCheckBox.Checked)
            {
                AddHobby(otherhobby.Value, userIdd);
            }
            if (Hindi.Checked)
            {
                AddLang("Hindi", userIdd);
            }
            if (English.Checked)
            {
                AddLang("English", userIdd);
            }
        }
        protected void AdduserRole(int userIdd)
        {
            if (Request.Params["userId"] != null)
            {
                using (var db = new ProfileEntities())
                {
                    var deleteroles = dbcontext.userrolerelation.Where((i) => i.userID == userIdd).ToList();
                    dbcontext.userrolerelation.RemoveRange(deleteroles);
                }

            }
            foreach (ListItem role in CheckBoxList1.Items)
            {
                if (role.Selected == true)
                {
                    userrolerelation userrole = new userrolerelation
                    {
                        userID = userIdd,
                        roleID = Int32.Parse(role.Value)
                    };
                    dbcontext.userrolerelation.Add(userrole);
                }

            }
        }
        protected void RedirectToDetailsPage()
        {
            Response.Redirect("LoginPage.aspx");
        }
        protected void SaveChanges(object ob, EventArgs e)
        {
            if (Request.Params["userId"] != null)
            {
                specificUserId = Int32.Parse(Request.Params["userId"]);
                user = dbcontext.userDetails.Where((i) => i.ID == specificUserId).Single();
                user.email = mail.Value;
                user.FirstName = fname.Value;
                user.LastName = lname.Value;
                user.Mobile = mob.Value;
                user.Gender = RadioButtonList1.SelectedValue;
                user.DOB = Convert.ToDateTime(dob.Value.ToString());
                user.AddressLine1Present = line1AddressPresent.Value;
                user.AddressLine2Present = line2AddressPresent.Value;
                user.CityPresent = cityPresent.Value;
                user.StatePresent = Int32.Parse(statePresent.SelectedItem.Value);
                user.CountryPresent = Int32.Parse(countryPresent.SelectedItem.Value);
                user.AddressLine1Permanent = line1AddressPermanent.Value;
                user.AddressLine2Permanent = line2AddressPermanent.Value;
                user.CityPermanent = cityPermanent.Value;
                user.StatePermanent = Int32.Parse(statePermanent.SelectedItem.Value);
                user.CountryPermanent = Int32.Parse(countryPermanent.SelectedItem.Value);
                user.ZipcodePermanent = pcodePermanent.Value;
                user.ZipcodePresent = pcodePresent.Value;

                AddHobbyLangToDB(specificUserId);
                AdduserRole(specificUserId);
                dbcontext.SaveChanges();


            }
            else
            {
                var gendervalue = RadioButtonList1.SelectedValue;
                var datetimedob = Convert.ToDateTime(dob.Value.ToString());

                userDetails user = new userDetails
                {
                    email = mail.Value,
                    FirstName = fname.Value,
                    LastName = lname.Value,
                    Mobile = mob.Value,
                    Gender = gendervalue,
                    DOB = datetimedob,
                    AddressLine1Present = line1AddressPresent.Value,
                    AddressLine2Present = line2AddressPresent.Value,
                    CityPresent = cityPresent.Value,
                    StatePresent = Int32.Parse(statePresent.SelectedItem.Value),
                    CountryPresent = Int32.Parse(countryPresent.SelectedItem.Value),
                    AddressLine1Permanent = line1AddressPermanent.Value,
                    AddressLine2Permanent = line2AddressPermanent.Value,
                    CityPermanent = cityPermanent.Value,
                    StatePermanent = Int32.Parse(statePermanent.SelectedItem.Value),
                    CountryPermanent = Int32.Parse(countryPermanent.SelectedItem.Value),
                    ZipcodePermanent = pcodePermanent.Value,
                    ZipcodePresent = pcodePresent.Value,
                };
                dbcontext.userDetails.Add(user);
                dbcontext.SaveChanges();
                //try
                //{
                //    dbcontext.SaveChanges();
                //}
                //catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                //{
                //    Exception raise = dbEx;
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            string message = string.Format("{0}:{1}",
                //                validationErrors.Entry.Entity.ToString(),
                //                validationError.ErrorMessage);
                //            // raise a new exception nesting  
                //            // the current instance as InnerException  
                //            raise = new InvalidOperationException(message, raise);
                //        }
                //    }
                //    throw raise;
                //}


                //var userIdd= dbcontext.userDetails.SqlQuery("Select SCOPE_IDENTITY").ToString();
                AddHobbyLangToDB(user.ID);
                AdduserRole(user.ID);


                dbcontext.SaveChanges();
            }
            RedirectToDetailsPage();
        }
        protected void CancelChanges(object ob, EventArgs e)
        {

            RedirectToDetailsPage();

        }


        protected void SameAddress()
        {
            if (checkBoxForSamePermanentAndPresentAddress.Checked)
            {
                if (countryPresent.SelectedIndex > 0)
                {
                    PopulateStates(countryPresent, statePermanent);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Addcountry();
                CheckBoxList1.DataSource = dbcontext.userroletable.ToList();
                CheckBoxList1.DataTextField = "userRole";
                CheckBoxList1.DataValueField = "userRoleId";
                CheckBoxList1.DataBind();
                foreach (var items in CheckBoxList1.Items)
                {
                    var k = items;
                }
                if (Request.Params["userId"] != null)
                {

                    
                    Save.Text = "Update";
                    specificUserId = Int32.Parse(Request.Params["userId"]);
                    user = dbcontext.userDetails.Where((i) => i.ID == specificUserId).Single();
                    string dooob = user.DOB.ToString("dd-MM-yyyy");
                    PopulateStatesPresent(sender, e);
                    PopulateStatesPermanent(sender, e);
                    mail.Value = user.email;
                    fname.Value = user.FirstName;
                    lname.Value = user.LastName;
                    mob.Value = user.Mobile;
                    dob.Value = user.DOB.ToString("yyyy-MM-dd");
                    line1AddressPresent.Value = user.AddressLine1Present;
                    line2AddressPresent.Value = user.AddressLine2Present;
                    cityPresent.Value = user.CityPresent;
                    countryPresent.SelectedIndex = user.CountryPresent;
                    line1AddressPermanent.Value = user.AddressLine1Permanent;
                    line2AddressPermanent.Value = user.AddressLine2Permanent;
                    cityPermanent.Value = user.CityPermanent;
                    countryPermanent.SelectedIndex = user.CountryPermanent;
                    pcodePermanent.Value = user.ZipcodePermanent;
                    pcodePresent.Value = user.ZipcodePresent;
                    PopulateStatesPresent(sender, e);
                    PopulateStatesPermanent(sender, e);
                    statePresent.SelectedIndex = user.StatePresent;
                    statePermanent.SelectedIndex = user.StatePermanent;
                    RadioButtonList1.SelectedValue = user.Gender;
                    var userrole = dbcontext.userrolerelation.Where((i) => i.userID == specificUserId).Select(i => i.roleID).ToList();
                    foreach (ListItem role in CheckBoxList1.Items)
                    {
                        var k = role;
                        if (userrole.Contains(Int32.Parse(role.Value)))
                        {
                            role.Selected = true;
                        }
                    }
                    var lang = dbcontext.language_table.Where((i) => i.userID == specificUserId).Select(i => i.language).ToList();
                    foreach (var language_known in lang)
                    {
                        if (language_known == "Hindi")
                        {
                            Hindi.Attributes.Add("checked", "true");
                        }
                        if (language_known == "English")
                        {
                            English.Attributes.Add("checked", "true");
                        }
                    }
                    var hobby = dbcontext.Hobby_table.Where((i) => i.userID == specificUserId).Select(i => i.hobby).ToList();
                    foreach (var hobbies in hobby)
                    {
                        if (hobbies == "dancing")
                        {
                            dancing.Attributes.Add("checked", "true");
                        }
                        else if (hobbies == "Singing")
                        {
                            singing.Attributes.Add("checked", "true");
                        }
                        else
                        {
                            otherhobby.Value = hobbies;
                            otherhobby.Attributes["Style"] = "display : block";
                            otherHobbyCheckBox.Attributes.Add("checked", "true");
                        }
                    }
                }
                else
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }
        }
    }
}
        