using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace UserManagement
{
    /// <summary>
    /// Summary description for DownloadFile
    /// </summary>
    public class DownloadFile : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string filename = context.Request.Params["filename"];
            string filePath = HttpContext.Current.Server.MapPath("~/uploads") + "\\" + filename;
            FileInfo file = new FileInfo(filePath);
       
            if (file.Exists)
            {
                // Clear Rsponse reference  
                context.Response.Clear();
                // Add header by specifying file name  
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                
                var filenamee = file.FullName;

                context.Response.ContentType = "application/octet-stream";
                context.Response.TransmitFile(file.FullName);

                context.Response.Flush();
            }
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