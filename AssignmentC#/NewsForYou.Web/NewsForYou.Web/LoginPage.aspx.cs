
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsForYou.Models;
using NewsForYou.Business;
using NewsForYou.Util;
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
            try
            {
                return BusinessClass.Logindetails();

            }catch(Exception ex)
            {
                Utilities.WriteLog(ex);
            }
            return null;
        }

        [WebMethod]
        public static void StoreSession(int userId)
        {
            try
            {
                HttpContext.Current.Session["id"] = userId;

            }
            catch (Exception ex)
            {
                Utilities.WriteLog(ex);
            }
        }

        [WebMethod]
        public static void IntializeDetails()
        { 
            try
            {
                BusinessClass.IntializeAllDetails();

            }catch(Exception ex)
            {
                Utilities.WriteLog(ex);
            }
            
        }
    }
}