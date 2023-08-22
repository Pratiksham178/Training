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
    public partial class UserTable : MasterClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        [WebMethod]
        public static List<UserBasicInto> GetData()
        {
            return Buisnessclass.GetUserDataForGrid();

        }
        [WebMethod(EnableSession = true)]
        public static bool GetSessionForAdmin()
        {
            int Id = GetSessionId();
            if(Id != -1)
            {
                bool Admin = Buisnessclass.IfAdmin(Id);
                return Admin;
            }
            return false;
           
        }
    }
}