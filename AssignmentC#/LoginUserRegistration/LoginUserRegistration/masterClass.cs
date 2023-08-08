using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.Entity;
using System.Reflection;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;



namespace LoginUserRegistration
{
    public class MasterClass :System.Web.UI.Page 
    {
        public static bool IsAdmin(int sesssionId)
        {
            using (var dbcontext = new ProfileEntities())
            {
                var role = (from userrelation in dbcontext.userrolerelation
                            where userrelation.userID == sesssionId
                            join userrole1 in dbcontext.userroletable on userrelation.roleID equals userrole1.userRoleId
                            select userrole1.userRole).ToList();
                if (role.Contains("ADMIN"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void Page_Init(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                if (Request.Params["userId"] != null)
                {
                    int specificUserId = Int32.Parse(Request.Params["userId"]);
                    var sesssionId = Int32.Parse(Session["id"].ToString());
                    using (var dbcontext = new ProfileEntities())
                    {
                        var role = (from userrelation in dbcontext.userrolerelation
                                    where userrelation.userID == sesssionId
                                    join userrole1 in dbcontext.userroletable on userrelation.roleID equals userrole1.userRoleId
                                    select userrole1.userRole).ToList();
                        if (specificUserId != sesssionId && !(IsAdmin(sesssionId)))
                        {
                            Response.Redirect("LoginPage.aspx");
                        }
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