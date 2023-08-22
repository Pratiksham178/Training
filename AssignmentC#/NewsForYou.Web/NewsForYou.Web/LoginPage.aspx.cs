
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsForYou.Models;
using NewsForYou.Business;
namespace NewsForYou.Web
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<LoginDetail> GetLoginDetails()
        {
            return BusinessClass.Logindetails();
        }

        [WebMethod]
        public static void StoreSession(int userId)
        {
            HttpContext.Current.Session.Add("id", userId);
        }

        [WebMethod]
        public static void IntializeDetails()
        {
            BusinessClass.IntializeAllDetails();
        }
    }
}