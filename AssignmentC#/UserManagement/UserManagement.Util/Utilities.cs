using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UserManagement.Util
{
    public class Utilities
    {
        public static int GetSessionId()
        {

            int sessionId=0;
            try
            {
                if (HttpContext.Current.Session != null)
                {
                    sessionId = Convert.ToInt32(HttpContext.Current.Session["id"].ToString());
                }
                else
                {
                    sessionId = -1;
                }
               
            }
            catch(Exception e)
            {

            }
            return sessionId;

        }
    }
}
