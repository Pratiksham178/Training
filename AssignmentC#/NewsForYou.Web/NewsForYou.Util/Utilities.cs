using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Web;
using System.Security.Policy;
using System.Runtime.Remoting.Channels;
using System.Net.Cache;
using iTextSharp.text.pdf.parser;

namespace NewsForYou.Util
{
    public class Utilities
    {
        /// <summary>
        /// Writes exception in Log file
        /// </summary>
        /// <param name="exception"></param>
        public static void WriteLog(Exception exception)
        {
            try
            {
                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                }
                string logFile = ConfigurationManager.AppSettings.Get("pathLogFolder") + "\\" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";
                string message = "------------------------------------------------------------------------------------\n";
                message += "Error - \n";
                message += exception;
                File.AppendAllText(logFile, message + "\n\n");
            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        /// Update the filename of JS and CSS by adding last modified date to its name so that
        /// the user gets the newewst file without ctrl+F5
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>new filename</returns>
        public static string UpdateFileName(string filename)
        {
            try
            {
                string filePath = HttpContext.Current.Server.MapPath(filename);
                FileInfo file = new FileInfo(filePath);
                string newfilename = filename.Split('.')[0] + "-" + file.LastAccessTime.ToString("ddMMyyyyHHmmss") + "-mycustomfile." + filename.Split('.')[1];
                return newfilename;
            }catch(Exception ex)
            {
                WriteLog(ex);
            }
            return null;
            
        }

        /// <summary>
        /// Returns the SessionId
        /// </summary>
        /// <returns>sessionId</returns>
        public static int GetSessionId()
        {

            int sessionId = 0;
            try
            {
                if (HttpContext.Current.Session["id"]!= null)
                {
                    sessionId = Convert.ToInt32(HttpContext.Current.Session["id"].ToString());
                }
                else
                {
                    sessionId = -1;
                }

            }
            catch (Exception e)
            {
                WriteLog(e);
            }
            return sessionId;

        }
    }
}
