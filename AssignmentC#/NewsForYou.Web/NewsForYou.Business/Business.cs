using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using NewsForYou.DAL;
using NewsForYou.Models;

namespace NewsForYou.Business
{
    public class BusinessClass
    {
        /// <summary>
        /// Gets data from RSS link and passes them to DBAccess for storage in DB
        /// </summary>
        public static void AddDataToDB()
        {
            List<AgencyFeedDetails> Feedlist = DBAccess.GetAllFeedData();
            List<NewsDetail> NewsInfo = new List<NewsDetail>();
            foreach (var Feed in Feedlist)
            {
                string url = Feed.AgencyFeedURL.ToString();
                try
                {
                    XDocument xDoc = new XDocument();
                    xDoc = XDocument.Load(url);
                    if(Feed.AgencyId == 1)
                    {
                         var eachfeed = (from x in xDoc.Descendants("item")
                                        select new
                                        {
                                            NewsTitle = x.Element("title").Value,
                                            NewsLink = x.Element("link").Value,
                                            NewsPublishDateTime = Convert.ToDateTime(x.Element("pubDate").Value),
                                            NewsDescription = x.Element("description").Value,
                                            NewsimageLink = x.Element("enclosure").Attribute("url").Value.ToString(),
                                        }).ToList();
                        if (eachfeed != null)
                        {
                            foreach (var item in eachfeed)
                            {
                                string description = item.NewsDescription;
                                string cleaned = Regex.Replace(description, @"<[^>]*>", String.Empty, RegexOptions.IgnoreCase).Trim();
                                NewsDetail news = new NewsDetail();
                                news.NewsTitle = item.NewsTitle;
                                news.NewsLink = item.NewsLink;
                                news.NewsPublishDateTime = item.NewsPublishDateTime;
                                news.NewsDescription = cleaned;
                                news.AgencyId = Feed.AgencyId;
                                news.CategoryId = Feed.CategoryId;
                                news.ClickCount = 0;
                                news.NewsImageLink = item.NewsimageLink;
                                NewsInfo.Add(news);
                            }

                        }
                    }
                    else { 
                        try
                        {
                            XNamespace mediaNamespace = "http://search.yahoo.com/mrss/";
                            var eachfeed = (from x in xDoc.Descendants("item")
                                            select new
                                            {
                                                NewsTitle = x.Element("title").Value,
                                                NewsLink = x.Element("link").Value,
                                                NewsPublishDateTime = Convert.ToDateTime(x.Element("pubDate").Value),
                                                NewsDescription = x.Element("description").Value,
                                                NewsImageLink = x.Element(mediaNamespace + "content")

                                            }).ToList();
                            if (eachfeed != null)
                            {
                                foreach (var item in eachfeed)
                                {
                                    string description = item.NewsDescription;
                                    string cleaned = Regex.Replace(description, @"<[^>]*>", String.Empty, RegexOptions.IgnoreCase).Trim();

                                    NewsDetail news = new NewsDetail();
                                    news.NewsTitle = item.NewsTitle;
                                    news.NewsLink = item.NewsLink;
                                    news.NewsPublishDateTime = item.NewsPublishDateTime;
                                    news.NewsDescription = cleaned;
                                    news.AgencyId = Feed.AgencyId;
                                    news.CategoryId = Feed.CategoryId;
                                    news.ClickCount = 0;
                                    if (item.NewsImageLink != null && item.NewsImageLink.Attribute("url").Value != null)
                                    {
                                        news.NewsImageLink = item.NewsImageLink.Attribute("url").Value;
                                    }
                                    NewsInfo.Add(news);
                                }

                            }
                        }catch (Exception ex)
                        {

                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            DBAccess.StoreAllDataInNews(NewsInfo);
        }

        /// <summary>
        /// Gets the LoginDetails through DBAccess
        /// </summary>
        /// <returns>Login Details</returns>
        public static List<LoginDetail> Logindetails()
        {
            return DBAccess.Login();
        }

        /// <summary>
        /// Gets the NewsDetails through DBAccess
        /// </summary>
        /// <returns></returns>
        public static List<NewsDetail> GetAllNewsData()
        {
            return DBAccess.GetAllNewsFromDB();
        }

        /// <summary>
        /// Gets the Link through DBAccess and passes the id to increase clickcount toDBAccess
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string IncreaseClickCountAndReturnLinkFromDB(int id)
        {
            return DBAccess.IncreaseClickCountAndReturnLinkUsingDB(id);
        }

        /// <summary>
        /// Returns Categories from DB through DBAccess
        /// </summary>
        /// <returns></returns>
        public static List<CategoryList> GetAllCategoriesFromDB()
        {
            return DBAccess.GetAllCategoriesUsingDB();
        }

        /// <summary>
        /// Returns details for Report from DB through DBAccess
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<Report> GetReport(string date)
        {
            return DBAccess.GetReportFromDb(date);
        }

        /// <summary>
        /// Calls DBAccess to initialize
        /// </summary>
        public static void IntializeAllDetails()
        {
            DBAccess.DeleteAndAddDetails();
        }
    }
}

