using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.Entity;
using System.Reflection;

namespace LoginUserRegistration
{
    public class userLogin
    {
        public int Id;
        public string email;
        public string password;
        public bool admin;
    }
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoadSession(object sender, EventArgs e)
        {
            using(var dbcontext = new ProfileEntities())
            {
                var emailuser = emailLoginTextbox.Text;
                var password = passwordLoginTextbox.Text;
                var user = dbcontext.userDetails.Where((i)=> i.email== emailuser).FirstOrDefault();
                if (user.Password == password)
                {
                    Session["id"] = user.ID;
                    
                    if (MasterClass.IsAdmin(user.ID))
                    {
                        Response.Redirect("userDataTable.aspx");
                    }
                    else
                    {
                        Response.Redirect("Form.aspx?userId=" + user.ID);
                    }
                }
            }
            
        }
        [WebMethod]
        public static List<userLogin> Login()
        {
            List<userLogin> userLogins = new List<userLogin>();
            using (var dbcontext = new ProfileEntities())
            {
                var allusers = dbcontext.userDetails.Select((i) => new
                {
                    i.ID,
                    i.email,
                    i.Password

                }).ToList();
                foreach (var oneuser in allusers)
                {
                    userLogin newuser = new userLogin();
                    newuser.Id = oneuser.ID;
                    newuser.email = oneuser.email;
                    newuser.password = oneuser.Password;
                    var role = (from userrelation in dbcontext.userrolerelation
                                where userrelation.userID == newuser.Id
                                join userrole1 in dbcontext.userroletable on userrelation.roleID equals userrole1.userRoleId
                                select userrole1.userRole).ToList();
                    if (role.Contains("ADMIN"))
                    {
                        newuser.admin = true;
                    }
                    else
                    {
                        newuser.admin = false;
                    }
                    userLogins.Add(newuser);
                }
            }

            return userLogins;
        }
    }
    


}