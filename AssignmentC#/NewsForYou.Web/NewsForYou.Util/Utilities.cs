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
        public static void WriteLog(string exception)
        {
            try
            {
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

        public static string UpdateFileName(string filename)
        {
            string filePath = HttpContext.Current.Server.MapPath(filename);
            FileInfo file = new FileInfo(filePath);
            string newfilename = filename.Split('.')[0] + "-" + file.LastAccessTime.ToString("ddMMyyyyHHmmss") + "-mycustomfile."+ filename.Split('.')[1];
            return newfilename;
        }
    }
}
