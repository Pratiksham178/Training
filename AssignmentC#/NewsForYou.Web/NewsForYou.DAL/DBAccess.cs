using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using NewsForYou.Models;
using NewsForYou.Util;

namespace NewsForYou.DAL
{
    public class DBAccess
    {
        /// <summary>
        /// Returns the agency feed Details to obtain the RSS link
        /// </summary>
        /// <returns>agency feed Details</returns>
        public static List<AgencyFeedDetails> GetAllFeedData()
        {
            List<AgencyFeedDetails> AgencyFeedDetails = new List<AgencyFeedDetails>();
            try
            {
                using (var dbcontext = new NewsForYouEntities())
                {
                    var feeds = dbcontext.AgencyFeed.ToList();
                    foreach (var feed in feeds)
                    {
                        var AgencyFeed = new AgencyFeedDetails();
                        AgencyFeed.AgencyFeedURL = feed.AgencyFeedURL;
                        AgencyFeed.CategoryId = feed.CategoryId;
                        AgencyFeed.AgencyId = feed.AgencyId;
                        AgencyFeedDetails.Add(AgencyFeed);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Utilities.WriteLog(ex);
            }

            return AgencyFeedDetails;
        }

        /// <summary>
        /// Stores the news details in the newsDetails Table in DB
        /// </summary>
        /// <param name="NewsInfo"></param>
        public static void StoreAllDataInNews(List<NewsDetail> NewsInfo)
        {
            try
            {
                using (var dbcontext = new NewsForYouEntities())
                {
                    foreach (var New in NewsInfo)
                    {
                        if (New.NewsPublishDateTime != null && New.NewsLink != null && New.NewsTitle != null)
                        {
                            if (New.NewsPublishDateTime > DBAccess.GetAllLastDate())
                            {
                                NewsDetails news = new NewsDetails();
                                try
                                {
                                    news.NewsTitle = New.NewsTitle;
                                    news.NewsDescription = New.NewsDescription;
                                    news.NewsPublishDateTime = New.NewsPublishDateTime;
                                    news.AgencyId = New.AgencyId;
                                    news.CategoryId = New.CategoryId;
                                    news.NewsLink = New.NewsLink;
                                    news.ClickCount = New.ClickCount;
                                    news.NewsImageLink = New.NewsImageLink;
                                    dbcontext.NewsDetails.Add(news);
                                    dbcontext.SaveChanges();

                                }
                                catch (Exception ex)
                                {
                                    Utilities.WriteLog(ex);
                                };

                            }

                        }
                    }

                }
            }
            catch (Exception e)
            {
                
                Utilities.WriteLog(e);

            }
        }

        /// <summary>
        /// Returns the Newest news's publishdate
        /// </summary>
        /// <returns>Newest news's publishdate</returns>
        public static DateTime GetAllLastDate()
        {
            using (var dbcontext = new NewsForYouEntities())
            {
                DateTime maxtime= new DateTime();
                try{
                    var NewsLinkList = dbcontext.NewsDetails.Select((i) => i.NewsPublishDateTime).ToList();

                    if (NewsLinkList != null) { maxtime = NewsLinkList.Max(); }
                }catch(Exception ex)
                {
                    Utilities.WriteLog(ex);
                }
                return maxtime;
               
            }

        }

        /// <summary>
        /// Returns all the users email and password with userid
        /// </summary>
        /// <returns>users details</returns>
        public static List<LoginDetail> Login()
        {
            List<LoginDetail> userLogins = new List<LoginDetail>();
            try
            {
                using (var dbcontext = new NewsForYouEntities())
                {
                    var allusers = dbcontext.UserDetails.Select((i) => new
                    {
                        i.UserId,
                        i.Email,
                        i.Password,

                    }).ToList();
                    foreach (var oneuser in allusers)
                    {
                        LoginDetail newuser = new LoginDetail();
                        newuser.UserId = oneuser.UserId;
                        newuser.Email = oneuser.Email;
                        newuser.Password = oneuser.Password;
                        userLogins.Add(newuser);
                    }
                }

            }catch(Exception ex)
            {
                Utilities.WriteLog(ex);
            }


            return userLogins;
        }

        /// <summary>
        /// Returns the list of news details from DB
        /// </summary>
        /// <returns>list of news</returns>
        public static List<NewsDetail> GetAllNewsFromDB() {
            List<NewsDetail> allNews = new List<NewsDetail>();
            try
            {
                using (var dbcontext = new NewsForYouEntities())
                {
                    var allNewsData = dbcontext.NewsDetails.OrderByDescending((i) => i.NewsPublishDateTime).ToList();
                    foreach (var onenews in allNewsData)
                    {
                        NewsDetail news = new NewsDetail();
                        news.NewsId = onenews.NewsId;
                        news.NewsLink = onenews.NewsLink;
                        news.NewsImageLink = onenews.NewsImageLink;
                        news.NewsPublishDateTime = onenews.NewsPublishDateTime;
                        news.NewsDescription = onenews.NewsDescription;
                        news.NewsTitle = onenews.NewsTitle;
                        news.AgencyId = onenews.AgencyId;
                        news.CategoryId = onenews.CategoryId;
                        news.AgencyImageLink = dbcontext.AgencyDetails.Where((i) => i.AgencyId == onenews.AgencyId).Select((i) => i.AgencyLogoPath).Single().ToString(); ;
                        news.ClickCount = onenews.ClickCount;
                        news.AgencyName = dbcontext.AgencyDetails.Where((i) => i.AgencyId == onenews.AgencyId).Select((i) => i.AgencyName).Single().ToString();
                        allNews.Add(news);
                    }
                }
            }catch(Exception ex)
            {
                Utilities.WriteLog(ex);
            }
           
            return allNews;
        }

        /// <summary>
        /// Increases the clickcount in DB and Returns the newsLink 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>newsLink</returns>
        public static string IncreaseClickCountAndReturnLinkUsingDB(int id)
        {
            string link="";
            try
            {
                using (var dbcontext = new NewsForYouEntities())
                {
                    var news = dbcontext.NewsDetails.Where((i) => i.NewsId == id).FirstOrDefault();
                    news.ClickCount += 1;
                    link = news.NewsLink.ToString();
                    dbcontext.SaveChanges();
                   
                }
            }
            catch(Exception ex)
            {
                Utilities.WriteLog(ex);
            }
            return link;
        }

        /// <summary>
        /// Returns all the categories from DB
        /// </summary>
        /// <returns>category list</returns>
        public static List<CategoryList> GetAllCategoriesUsingDB()
        {
            List<CategoryList> categories = new List<CategoryList>();
            try
            {
                using (var dbcontext = new NewsForYouEntities())
                {

                    var allcategory = dbcontext.Category.ToList();
                    foreach (var item in allcategory)
                    {
                        CategoryList category = new CategoryList();
                        category.CategoryId = item.CategoryId;
                        category.CategoryName = item.CategoryTitle;
                        categories.Add(category);
                    }
                    
                }
            }catch(Exception ex)
            {
                Utilities.WriteLog(ex);
            }
            return categories;
        }

        /// <summary>
        /// Returns the List of news on a particular date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>List of news on a particular date</returns>
        public static List<Report> GetReportFromDb(string date)
        {
            var reqdate = Convert.ToDateTime(date);
            List<Report> allreports = new List<Report>();
            try
            {
                using (var dbcontext = new NewsForYouEntities())
                {
                    var reports = dbcontext.NewsDetails.OrderByDescending((i) => i.ClickCount).ToList();
                    foreach (var item in reports)
                    {
                        if (Convert.ToDateTime(item.NewsPublishDateTime.ToShortDateString()) == reqdate)
                        {
                            Report report = new Report();
                            report.Title = item.NewsTitle;
                            report.NoOfClick = item.ClickCount;
                            report.Agency = dbcontext.AgencyDetails.Where((i) => i.AgencyId == item.AgencyId).Select((i) => i.AgencyName).ToList()[0];
                            allreports.Add(report);
                        }

                    }

                }
            }catch(Exception ex)
            {
                Utilities.WriteLog(ex);
            }
           
            return allreports;
        }

        /// <summary>
        /// Initializes the website by truncating the tables and adding the required data
        /// </summary>
        public static void DeleteAndAddDetails()
        {
            try
            {
                string allcommands = "truncate table UserDetails;\r\ntruncate table AgencyDetails;\r\ntruncate table AgencyFeed;\r\ntruncate table NewsDetails;\r\ntruncate table category;\r\n\r\nInsert into UserDetails VALUES('Pratiksha','liti624@gmail.com','user123');\r\n\r\nInsert into Category VALUES('Sports');\r\nInsert into Category VALUES('Buisness');\r\nInsert into Category VALUES('Science');\r\nInsert into Category VALUES('Technology');\r\nInsert into Category VALUES('Entertainment');\r\n\r\nInsert into AgencyDetails VALUES('Times Of India','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSuty-_X3M9IZzIDeQ0DnNHt586bdkJj89YsK916FdY_g&s');\r\nInsert into AgencyDetails VALUES('Hindustan Times','https://upload.wikimedia.org/wikipedia/commons/thumb/a/ae/Hindustan_Times_logo.svg/2560px-Hindustan_Times_logo.svg.png');\r\nInsert into AgencyDetails VALUES('The Hindu','https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ0aWed20B0g8QUr_olPUnJetlhvnrjOjBpByhuaprmopBgLyZN3rIb74pX9urhxBeAKGo&usqp=CAU');\r\n\r\nInsert into AgencyFeed VALUES('https://timesofindia.indiatimes.com/rssfeeds/4719148.cms',1,1);\r\nInsert into AgencyFeed VALUES('https://timesofindia.indiatimes.com/rssfeeds/1898055.cms',1,2);\r\nInsert into AgencyFeed VALUES('https://timesofindia.indiatimes.com/rssfeeds/-2128672765.cms',1,3);\r\nInsert into AgencyFeed VALUES('https://timesofindia.indiatimes.com/rssfeeds/66949542.cms',1,4);\r\nInsert into AgencyFeed VALUES('https://timesofindia.indiatimes.com/rssfeeds/1081479906.cms',1,5);\r\n\r\nInsert into AgencyFeed VALUES('https://www.hindustantimes.com/feeds/rss/sports/rssfeed.xml',2,1);\r\nInsert into AgencyFeed VALUES('https://www.hindustantimes.com/feeds/rss/business/rssfeed.xml',2,2);\r\nInsert into AgencyFeed VALUES('https://www.hindustantimes.com/feeds/rss/science/rssfeed.xml',2,3);\r\nInsert into AgencyFeed VALUES('https://www.hindustantimes.com/feeds/rss/technology/rssfeed.xml',2,4);\r\nInsert into AgencyFeed VALUES('https://www.hindustantimes.com/feeds/rss/web-stories/entertainment/rssfeed.xml',2,5);\r\n\r\nInsert into AgencyFeed VALUES('https://www.thehindu.com/sport/feeder/default.rss',3,1);\r\nInsert into AgencyFeed VALUES('https://www.thehindu.com/business/feeder/default.rss',3,2);\r\nInsert into AgencyFeed VALUES('https://www.thehindu.com/sci-tech/science/feeder/default.rss',3,3);\r\nInsert into AgencyFeed VALUES('https://www.thehindu.com/sci-tech/technology/feeder/default.rss',3,4);\r\nInsert into AgencyFeed VALUES('https://www.thehindu.com/entertainment/feeder/default.rss',3,5);";
                using (var dbcontext = new NewsForYouEntities())
                {
                    int x = dbcontext.Database.ExecuteSqlCommand(allcommands);
                }
            }catch(Exception ex)
            {
                Utilities.WriteLog(ex);
            }
            
        }
    }
}

