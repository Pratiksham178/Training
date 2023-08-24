using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf;
using iTextSharp.text;
using NewsForYou.Business;
using NewsForYou.Models;
using NewsForYou.Util;

namespace NewsForYou.Web
{
    public partial class ReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        public static List<Report> AddDataToReport(string date)
        {
            List<Report> report = new List<Report>();
            try
            {
                if (NewsForYou.Util.Utilities.GetSessionId() != -1)
                {
                    return BusinessClass.GetReport(date);
                }
                else
                {

                    return report;
                }
            }catch(Exception ex)
            {
                NewsForYou.Util.Utilities.WriteLog(ex);
            }
            return report;
            
            
        }



    }
}