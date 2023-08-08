using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginUserRegistration
{
    public class user
    {
        public int userID;
        public string firstName;
        public string lastName;
        public string email;
        public string userRole;
        public string hobbies;
        public string languages;
    }
    
    public partial class userDataTable : MasterClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!(IsAdmin(Int32.Parse(Session["id"].ToString()))))
            {
                Response.Redirect("LoginPage.aspx");
            }
        }
        protected void AddnewUserBtnClick(object sender, EventArgs e)
        {
            Response.Redirect("Form.aspx");
        }
        [WebMethod]
        public static List<user> GetData()
        {
            List<user> userList = new List<user>();

            using (var dbcontext = new ProfileEntities())
            {
                var allusers = dbcontext.userDetails.Select((i) => new
                {
                    i.ID,
                    i.FirstName,
                    i.LastName,
                    i.email,

                }).ToList();
                foreach (var oneuser in allusers)
                {
                    user newuser = new user();
                    newuser.userID = oneuser.ID;
                    newuser.firstName = oneuser.FirstName;
                    newuser.lastName = oneuser.LastName;
                    newuser.email = oneuser.email;
                    newuser.userRole = string.Join(", ", (from userrelation in dbcontext.userrolerelation
                                                          where userrelation.userID == newuser.userID
                                                          join userrole1 in dbcontext.userroletable on userrelation.roleID equals userrole1.userRoleId
                                                          select userrole1.userRole).ToList()).ToLower();
                    newuser.languages = string.Join(", ", dbcontext.language_table.Where((i) => i.userID == oneuser.ID).Select((i) => i.language).ToList());
                    newuser.hobbies = string.Join(", ", dbcontext.Hobby_table.Where((i) => i.userID == oneuser.ID).Select((i) => i.hobby).ToList());
                    userList.Add(newuser);
                }
            }
            return userList;
        }
    }
}