using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement
{
    public class MasterClass:System.Web.UI.Page
    {
        public static int GetSessionId()
        {
            int sessionId;
            if (HttpContext.Current.Session["id"] != null)
            {
                sessionId = Convert.ToInt32(HttpContext.Current.Session["id"].ToString());
            }
            else
            {
                sessionId = -1;
            }
            return sessionId;
        }

    }

}