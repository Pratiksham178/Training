using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
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
            HttpContext.Current.Session.Abandon();
        }

        [WebMethod]
        public static List<NewsDetail> GetAllNews()
        {
            return BusinessClass.GetAllNewsData();
        }
        [WebMethod]
        public static string IncreaseClickCountAndReturnLink(int id)
        {
            return BusinessClass.IncreaseClickCountAndReturnLinkFromDB(id);
        }
        [WebMethod]
        public static List<CategoryList> GetAllCategories()
        {
            return BusinessClass.GetAllCategoriesFromDB();
        }

        [WebMethod]
        public static int GetNewNews()
        {
            BusinessClass.AddDataToDB();
            var allnews = BusinessClass.GetAllNewsData();
            return allnews.ToList().Count();

        }
        [WebMethod]
        public static int GetSession()
        {
            return Utilities.GetSessionId();
        }
    }
}