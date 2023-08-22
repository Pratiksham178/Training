using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsForYou.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Agency
    {
        public int AgencyId { get; set; }
        public string AgencyName { get; set; }
        public string AgencyLogoPath { get; set; }
    }
    public class CategoryList
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    public class AgencyFeedDetails
    {
        public int AgencyFeedId { get; set; }
        public string AgencyFeedURL { get; set; }
        public int AgencyId { get; set; }
        public int CategoryId { get; set; }
    }
    public class NewsDetail
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public System.DateTime NewsPublishDateTime { get; set; }
        public string NewsLink { get; set; }
        public int ClickCount { get; set; }
        public int CategoryId { get; set; }
        public int AgencyId { get; set; }

        public string AgencyName { get; set; }
        public string NewsImageLink { get; set; }
        public string AgencyImageLink { get; set; }
    }
    public class LoginDetail
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Report
    {
        public string Agency { get; set; }
        public string Title { get; set; }
        public int NoOfClick { get; set; }
    }
    public class Models
    {
    }
}
