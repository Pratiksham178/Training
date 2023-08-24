using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsForYou.Business;
using NewsForYou.Models;
using NewsForYou.Util;

namespace NewsForYou.Web
{
    public partial class NewsPage : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
                BusinessClass.AddDataToDB();
        }

        [WebMethod]
        public static void DeleteSession()
        {
            try
            {
                if (Utilities.GetSessionId() != -1)
                {
                    HttpContext.Current.Session.Abandon();
                }
            }catch(Exception ex)
            {
                Utilities.WriteLog(ex);
            }
            
        }

        [WebMethod]
        public static List<NewsDetail> GetAllNews()
        {
            try
            {
                return BusinessClass.GetAllNewsData();
            }catch(Exception ex)
            {
                Utilities.WriteLog(ex);
            }
            return null;
            
        }
        [WebMethod]
        public static string IncreaseClickCountAndReturnLink(int id)
        {
            try
            {
                return BusinessClass.IncreaseClickCountAndReturnLinkFromDB(id);
            }catch(Exception ex)
            {
                Utilities.WriteLog(ex);
            }
            return null;
        }
        [WebMethod]
        public static List<CategoryList> GetAllCategories()
        {
            try
            {
                return BusinessClass.GetAllCategoriesFromDB();
            }
            catch (Exception ex)
            {
                Utilities.WriteLog(ex);
            }
            return null;
        }

        [WebMethod]
        public static int GetNewNews()
        {
            
            try
            {
                BusinessClass.AddDataToDB();
                var allNews = BusinessClass.GetAllNewsData();
                return allNews.ToList().Count();
            }
            catch (Exception ex)
            {
                Utilities.WriteLog(ex);
            }
            return -1;

        }
        [WebMethod]
        public static int GetSession()
        {
           
            try
            {
                return Utilities.GetSessionId();
            }
            catch (Exception ex)
            {
                Utilities.WriteLog(ex);
            }
            return -1;
        }
    }
}