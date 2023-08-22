using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagement.Model;
using UserManagement.Buisness;
namespace UserManagement
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public static void SetSessionId(int userId)
        {
            HttpContext.Current.Session["id"] = userId;
        }
        
        [WebMethod]
        public static List<UserLogin> GetLoginDetails()
        {
            return Buisnessclass.Logindetails();
        }
        [WebMethod]
        public static void StoreSession(int userId)
        {
            HttpContext.Current.Session.Add("id", userId);
        }
        
    }
}