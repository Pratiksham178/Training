using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserManagement.Model;
using UserManagement.Buisness;
using System.Web.SessionState;
namespace UserManagement
{
    public class StoreFiles : IHttpHandler,IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            List<string> filenames = new List<string>();
            var formData = context.Request.Form;
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string fname = context.Server.MapPath("~/uploads/" + file.FileName);
                    file.SaveAs(fname);
                    filenames.Add(fname);
                }
            }
            int sessionId = MasterClass.GetSessionId();
            int userId = Int32.Parse(HttpContext.Current.Request.Params["userId"].ToString());
            Buisnessclass.StorefilesInDB(sessionId,userId,filenames);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}