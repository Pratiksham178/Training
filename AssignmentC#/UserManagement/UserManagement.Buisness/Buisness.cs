using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Model;
using UserManagement.DAL;
using System.Diagnostics.Eventing.Reader;
using UserManagement;
using UserManagement.Util;
using System.IO;
using System.Web.Services.Description;

namespace UserManagement.Buisness
{
    public class Buisnessclass 
    {
        public static List<UserBasicInto> GetUserDataForGrid()
        {
            return DBAccess.GetUserDetails();

        }
        public static List<CountryList> GetCountriesList()
        {
            return DBAccess.GetCountryLists();
        }
        public static List<StateList> GetStatesList(int id)
        {
            return DBAccess.GetStateLists(id);
        }
        public static List<UserRole> GetRolesList()
        {
            return DBAccess.GetRolesLists();
        }
        public static void PassDataToDB(UserInformation objectuser)
        {
            DBAccess.StoreDataInDB(objectuser);
        }
        public static UserInformation GetUserInformation(int id)
        {
            return DBAccess.GetUserDetail(id);
        }
        public static void PassUpdatedDataToDB(int userId, UserInformation objectuser)
        {
            DBAccess.StoreUpdatedDataInDB(userId, objectuser);
        }
        public static List<NoteData> GetNoteDataListFromDB(int userId)
        {
            return DBAccess.GetNoteDataFromDB(userId);
        }
        public static void PassNoteDataToDB(NoteData objectnote)
        {
            DBAccess.PostNoteDataInDB(objectnote);
        }
        public static List<UserLogin> Logindetails()
        {
            return DBAccess.Login();
        }
        public static bool IfAdmin(int Id)
        {
            List<UserRole> roles= DBAccess.AdminAccess(Id);
            foreach(UserRole role in roles)
            {
                if (role.RoleName == "ADMIN")
                {
                    return true;
                }
                
            }
            return false;
        }
        public static void StorefilesInDB(int id,int userId,List<string> filename)
        {
            DBAccess.AddFilesIntoDB(id,userId,filename);
        }
        public static List<FileDetails> PassFilesFromDB(int id)
        {
            return DBAccess.GetFilesFromDB(id);
        }
        public static void DeleteUserFromDB(int id)
        {
            DBAccess.DeleteUserInDB(id);
        }
        public static void DeleteFileFromDB(int fileid)
        {
            DBAccess.DeleteFileInDB(fileid);
        }


    }
}
