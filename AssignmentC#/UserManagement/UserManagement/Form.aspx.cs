using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserManagement.Model;
using UserManagement.Buisness;
using System.Web.Services;
using System.EnterpriseServices.Internal;
using Microsoft.SqlServer.Server;
using System.Xml.Linq;
using System.IO;

namespace UserManagement
{
    public partial class Form : System.Web.UI.Page, IHttpHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public static int GetSessionId()
        {
            int sessionId;
            if (HttpContext.Current.Session["id"] != null)
            {
                sessionId = Convert.ToInt32(HttpContext.Current.Session["id"].ToString());
            }
            else
            {
                sessionId = -1;
            }
            return sessionId;
        }

        public static List<UserRole> GetUserRoleCheckList()
        {
            return Buisnessclass.GetRolesList();
        }

        [WebMethod]
        public static List<CountryList> GetCountryDropList()
        {
            return Buisnessclass.GetCountriesList();
        }

        [WebMethod]
        public static List<StateList> GetStateDropList(int id)
        {
            return Buisnessclass.GetStatesList(id);
        }

        [WebMethod]
        public static void StoreData(UserInformation objectuser)
        {
            Buisnessclass.PassDataToDB(objectuser);
        }

        [WebMethod]
        public static UserInformation GetUserDetail(int id)
        {
            return Buisnessclass.GetUserInformation(id);
        }

        [WebMethod]
        public static void StoreUpdatedData(int userId,UserInformation objectuser)
        {
            Buisnessclass.PassUpdatedDataToDB(userId,objectuser);
        }

        [WebMethod]
        public static List<NoteData> GetNoteDataList(int userId)
        {
            return Buisnessclass.GetNoteDataListFromDB(userId);
        }

        [WebMethod]
        public static void StoreNoteData(NoteData objectnote)
        {
            Buisnessclass.PassNoteDataToDB(objectnote);
        }

        [WebMethod]
        public static UserLogin GetSessionIdForUser()
        {
            
            int sessionId = GetSessionId();
            bool admin = Buisnessclass.IfAdmin(sessionId);
            UserLogin user = new UserLogin()
            {
                Id = sessionId,
                Admin = admin,
            };
            return user;
        }
       
        [WebMethod]
        public static List<FileDetails> GetAllFiles(int id)
        {
            return Buisnessclass.PassFilesFromDB(id);
        }

        [WebMethod]
        public static void DeleteSession()
        {
            HttpContext.Current.Session.Abandon();
        }

        [WebMethod]
        public static void DeleteUser()
        {
            int id = Int32.Parse(HttpContext.Current.Request.Params["userId"].ToString());
            Buisnessclass.DeleteUserFromDB(id);
        }

        [WebMethod]
        public static void Deletefiles(int fileid)
        {
            Buisnessclass.DeleteFileFromDB(fileid);
        }
        
    }
}