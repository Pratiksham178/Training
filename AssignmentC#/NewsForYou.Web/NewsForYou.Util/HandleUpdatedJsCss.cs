using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace NewsForYou.Util
{
    public class HandleUpdatedJsCss : IHttpHandler
    {
        public void ProcessRequest(System.Web.HttpContext context)
        {
            string[] path = context.Request.Path.Split('-');
            string filename = path[0] +"."+ path[path.Length - 1].Split('.')[1];
            string filePath = HttpContext.Current.Server.MapPath(filename) ;
            FileInfo file = new FileInfo(filePath);

            if (file.Exists)
            {
                // Clear Rsponse reference  
                context.Response.Clear();
                // Add header by specifying file name  
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);

                if(path[path.Length - 1].Split('.')[1] == "js")
                {
                    context.Response.ContentType = "text/js";

                }
                else
                {
                    context.Response.ContentType = "text/css";

                }
                context.Response.TransmitFile(file.FullName);
                var refresh = new TimeSpan(365, 0, 0, 0);
                context.Response.Cache.SetExpires(DateTime.Now.Add(refresh));
                context.Response.Cache.SetMaxAge(refresh);
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.Cache.SetValidUntilExpires(true);
                context.Response.Cache.SetLastModified(DateTime.Now);
                context.Response.Flush();
            }
        }
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
