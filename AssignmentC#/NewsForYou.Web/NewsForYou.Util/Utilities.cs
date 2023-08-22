using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Web;
using System.Security.Policy;

namespace NewsForYou.Util
{
    public class Utilities
    {
        public static void WriteLog(string exception)
        {
            try
            {
                string logFile = ConfigurationManager.AppSettings.Get("pathLogFolder") +"\\"+ DateTime.Now.ToString("yyyy_MM_dd") + ".txt";
                string message = "------------------------------------------------------------------------------------\n";
                message += "Error - \n";
                message += exception;
                File.AppendAllText(logFile, message + "\n\n");
            }catch (Exception ex)
            {

            }
            
        }
        
        
    }
}
