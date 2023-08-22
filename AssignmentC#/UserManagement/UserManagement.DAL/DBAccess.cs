using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using UserManagement.Model;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Policy;

namespace UserManagement.DAL
{
    public class DBAccess
    {
        public static List<UserBasicInto> GetUserDetails()
        {
            var userList = new List<UserManagement.Model.UserBasicInto>();
            try
            {
                using (var dbcontext = new ProfileEntities())
                {
                    var allusers = dbcontext.userDetails.Select((i) => new
                    {
                        i.ID,
                        i.FirstName,
                        i.LastName,
                        i.email,
                        i.Password,
                        i.Mobile,
                        i.Gender

                    }).ToList();
                    foreach (var oneuser in allusers)
                    {
                        UserBasicInto newuser = new UserBasicInto();
                        newuser.UserID = oneuser.ID;
                        newuser.FirstName = oneuser.FirstName;
                        newuser.LastName = oneuser.LastName;
                        newuser.Email = oneuser.email;
                        newuser.Password = oneuser.Password;
                        newuser.Mobile = oneuser.Mobile;
                        newuser.Gender = oneuser.Gender;
                        newuser.UserRole = string.Join(", ", (from userrelation in dbcontext.userrolerelation
                                                              where userrelation.userID == newuser.UserID
                                                              join userrole1 in dbcontext.userroletable on userrelation.roleID equals userrole1.userRoleId
                                                              select userrole1.userRole).ToList()).ToLower();
                        newuser.LanguagesKnown = string.Join(", ", dbcontext.language_table.Where((i) => i.userID == oneuser.ID).Select((i) => i.language).ToList());
                        newuser.Hobbies = string.Join(", ", dbcontext.Hobby_table.Where((i) => i.userID == oneuser.ID).Select((i) => i.hobby).ToList());
                        userList.Add(newuser);
                    }
                }

            }
            catch (Exception ex)
            {
                StackFrame stackFrame = (new StackTrace(ex, true)).GetFrame(0);
                var message = string.Format("At line {0} column {1} in {2}: {3} {4}{3}{5}  ",
                    stackFrame.GetFileLineNumber(), stackFrame.GetFileColumnNumber(),
                    stackFrame.GetMethod(), Environment.NewLine, stackFrame.GetFileName(),
                    ex.Message);
                var path = ConfigurationManager.AppSettings.Get("pathLogFolder");
                FileStream objFilestream = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
                objStreamWriter.WriteLine(message);
                objStreamWriter.Close();
                objFilestream.Close();
            }
            return userList;
        }
        public static List<CountryList> GetCountryLists()
        {
            List<CountryList> countryList = new List<CountryList>();
            using (var dbcontext = new ProfileEntities())
            {
                var countries = dbcontext.country_list.ToList();
                foreach (var country in countries)
                {
                    CountryList newcountry = new CountryList();
                    newcountry.ID = country.ID;
                    newcountry.CountryName = country.countryName;
                    countryList.Add(newcountry);
                }
            }
            return countryList;
        }
        public static List<StateList> GetStateLists(int id)
        {
            List<StateList> stateList = new List<StateList>();
            using (var dbcontext = new ProfileEntities())
            {
                var states = dbcontext.statelist_table.Where((i) => i.countryID == id).ToList();
                foreach (var state in states)
                {
                    StateList newstate = new StateList();
                    newstate.ID = state.ID;
                    newstate.StateName = state.stateName;
                    stateList.Add(newstate);
                }
            }
            return stateList;
        }
        public static List<UserRole> GetRolesLists()
        {
            List<UserRole> RoleList = new List<UserRole>();
            using (var dbcontext = new ProfileEntities())
            {
                var roles = dbcontext.userroletable.ToList();
                foreach (var role in roles)
                {
                    UserRole newrole = new UserRole();
                    newrole.RoleId = role.userRoleId;
                    newrole.RoleName = role.userRole;
                    RoleList.Add(newrole);
                }
            }
            return RoleList;
        }
        public static void StoreDataInDB(UserInformation objectuser)
        {
            using (var dbcontext = new ProfileEntities())
            {
                userDetails user = new userDetails
                {
                    email = objectuser.email,
                    FirstName = objectuser.FirstName,
                    LastName = objectuser.LastName,
                    Mobile = objectuser.Mobile,
                    Gender = objectuser.Gender,
                    DOB = Convert.ToDateTime(objectuser.DOB),
                    AddressLine1Present = objectuser.AddressLine1Present,
                    AddressLine2Present = objectuser.AddressLine2Present,
                    CityPresent = objectuser.CityPresent,
                    StatePresent = objectuser.StatePresent,
                    CountryPresent = objectuser.CountryPresent,
                    AddressLine1Permanent = objectuser.AddressLine1Permanent,
                    AddressLine2Permanent = objectuser.AddressLine2Permanent,
                    CityPermanent = objectuser.CityPermanent,
                    StatePermanent = objectuser.StatePermanent,
                    CountryPermanent = objectuser.CountryPermanent,
                    ZipcodePermanent = objectuser.ZipcodePermanent,
                    ZipcodePresent = objectuser.ZipcodePresent,
                    Password = objectuser.Password,
                };
                dbcontext.userDetails.Add(user);
                foreach (int role in objectuser.UserRoles)
                {
                    userrolerelation userrole = new userrolerelation()
                    {
                        roleID = role,
                        userID = user.ID,
                    };
                    dbcontext.userrolerelation.Add(userrole);
                    dbcontext.SaveChanges();
                }
                foreach (string lang in objectuser.LanguagesKnown)
                {
                    language_table userlang = new language_table()
                    {
                        language = lang,
                        userID = user.ID,
                    };
                    dbcontext.language_table.Add(userlang);
                    dbcontext.SaveChanges();
                }
                foreach (string hobbby in objectuser.Hobbies)
                {
                    Hobby_table userhobby = new Hobby_table()
                    {
                        hobby = hobbby,
                        userID = user.ID,
                    };
                    dbcontext.Hobby_table.Add(userhobby);
                    dbcontext.SaveChanges();
                }
                
                dbcontext.SaveChanges();
            }
        }
        public static UserInformation GetUserDetail(int id)
        {
            using(var dbcontext = new ProfileEntities())
            {
                var userbasicinfo = dbcontext.userDetails.Where((i)=>i.ID == id).FirstOrDefault();
                var userroles = dbcontext.userrolerelation.Where((i)=>i.userID == id).Select((i)=>i.roleID).ToList();
                var userhobby = dbcontext.Hobby_table.Where((i) => i.userID == id).Select((i) => i.hobby).ToList();
                var userlang = dbcontext.language_table.Where((i)=>i.userID==id).Select((i)=>i.language).ToList();
                UserInformation user = new UserInformation
                {
                    email = userbasicinfo.email,
                    FirstName = userbasicinfo.FirstName,
                    LastName = userbasicinfo.LastName,
                    Mobile = userbasicinfo.Mobile,
                    Gender = userbasicinfo.Gender,
                    DOB = userbasicinfo.DOB.ToString("yyyy-MM-dd"),
                    AddressLine1Present = userbasicinfo.AddressLine1Present,
                    AddressLine2Present = userbasicinfo.AddressLine2Present,
                    CityPresent = userbasicinfo.CityPresent,
                    StatePresent = userbasicinfo.StatePresent,
                    CountryPresent = userbasicinfo.CountryPresent,
                    AddressLine1Permanent = userbasicinfo.AddressLine1Permanent,
                    AddressLine2Permanent = userbasicinfo.AddressLine2Permanent,
                    CityPermanent = userbasicinfo.CityPermanent,
                    StatePermanent = userbasicinfo.StatePermanent,
                    CountryPermanent = userbasicinfo.CountryPermanent,
                    ZipcodePermanent = userbasicinfo.ZipcodePermanent,
                    ZipcodePresent = userbasicinfo.ZipcodePresent,
                    Password = userbasicinfo.Password,
                    UserRoles= userroles,
                    LanguagesKnown = userlang,
                    Hobbies = userhobby
                };
                return user;
            }
        }
        public static void StoreUpdatedDataInDB(int userId, UserInformation objectuser)
        {
            try
            {
                using (var dbcontext = new ProfileEntities())
                {
                    var user = dbcontext.userDetails.Where((i) => i.ID == userId).FirstOrDefault();

                    user.email = objectuser.email;
                    user.FirstName = objectuser.FirstName;
                    user.LastName = objectuser.LastName;
                    user.Mobile = objectuser.Mobile;
                    user.Gender = objectuser.Gender;
                    user.DOB = Convert.ToDateTime(objectuser.DOB);
                    user.AddressLine1Present = objectuser.AddressLine1Present;
                    user.AddressLine2Present = objectuser.AddressLine2Present;
                    user.CityPresent = objectuser.CityPresent;
                    user.StatePresent = objectuser.StatePresent;
                    user.CountryPresent = objectuser.CountryPresent;
                    user.AddressLine1Permanent = objectuser.AddressLine1Permanent;
                    user.AddressLine2Permanent = objectuser.AddressLine2Permanent;
                    user.CityPermanent = objectuser.CityPermanent;
                    user.StatePermanent = objectuser.StatePermanent;
                    user.CountryPermanent = objectuser.CountryPermanent;
                    user.ZipcodePermanent = objectuser.ZipcodePermanent;
                    user.ZipcodePresent = objectuser.ZipcodePresent;
                    user.Password = objectuser.Password;
                    var deletehobbies = dbcontext.Hobby_table.Where((i) => i.userID == userId).ToList();
                    dbcontext.Hobby_table.RemoveRange(deletehobbies);
                    var deletelanguages = dbcontext.language_table.Where((i) => i.userID == userId).ToList();
                    dbcontext.language_table.RemoveRange(deletelanguages);
                    var deleteroles = dbcontext.userrolerelation.Where((i) => i.userID == userId).ToList();
                    dbcontext.userrolerelation.RemoveRange(deleteroles);
                    foreach (int role in objectuser.UserRoles)
                    {
                        userrolerelation userrole = new userrolerelation()
                        {
                            roleID = role,
                            userID = user.ID,
                        };
                        dbcontext.userrolerelation.Add(userrole);
                        dbcontext.SaveChanges();
                    }
                    foreach (string lang in objectuser.LanguagesKnown)
                    {
                        language_table userlang = new language_table()
                        {
                            language = lang,
                            userID = user.ID,
                        };
                        dbcontext.language_table.Add(userlang);
                        dbcontext.SaveChanges();
                    }
                    foreach (string hobbby in objectuser.Hobbies)
                    {
                        Hobby_table userhobby = new Hobby_table()
                        {
                            hobby = hobbby,
                            userID = user.ID,
                        };
                        dbcontext.Hobby_table.Add(userhobby);
                        dbcontext.SaveChanges();
                    }

                    dbcontext.SaveChanges();
                }
            }catch(Exception ex)
            {

                var message = ex.ToString();
                var path = ConfigurationManager.AppSettings.Get("pathLogFolder");
                FileStream objFilestream = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter objStreamWriter = new StreamWriter((Stream)objFilestream);
                objStreamWriter.WriteLine(message);
                objStreamWriter.Close();
                objFilestream.Close();
            }
           
        }
        public static List<NoteData> GetNoteDataFromDB(int usedId)
        {
            List<NoteData> noteList = new List<NoteData>();
            using (var dbcontext = new ProfileEntities())
            {
                var notes = dbcontext.note_table.Where((i) => i.userID == usedId).ToList();
                foreach (var note in notes)
                {
                    NoteData newnote = new NoteData();
                    newnote.Note = note.note;
                    newnote.Visible = note.visible;
                    newnote.CreatedOn=note.createdOn.ToString().Substring(0,10);
                    noteList.Add(newnote);
                }
            }
            return noteList;
        }
        public static void PostNoteDataInDB(NoteData objectnote)
        {
            using(var dbcontext = new ProfileEntities())
            {
                note_table noteData = new note_table();
                noteData.createdOn = Convert.ToDateTime(objectnote.CreatedOn);
                noteData.note = objectnote.Note;
                noteData.visible = objectnote.Visible;
                noteData.userID = objectnote.UserID;
                dbcontext.note_table.Add(noteData);
                dbcontext.SaveChanges();
            }
        }
        public static List<UserLogin> Login()
       {
            List<UserLogin> userLogins = new List<UserLogin>();
            using (var dbcontext = new ProfileEntities())
            {
                var allusers = dbcontext.userDetails.Select((i) => new
                {
                    i.ID,
                    i.email,
                    i.Password

                }).ToList();
                foreach (var oneuser in allusers)
                {
                    UserLogin newuser = new UserLogin();
                    newuser.Id = oneuser.ID;
                    newuser.Email = oneuser.email;
                    newuser.Password = oneuser.Password;
                    var role = (from userrelation in dbcontext.userrolerelation
                                where userrelation.userID == newuser.Id
                                join userrole1 in dbcontext.userroletable on userrelation.roleID equals userrole1.userRoleId
                                select userrole1.userRole).ToList();
                    if (role.Contains("ADMIN"))
                    {
                        newuser.Admin = true;
                    }
                    else
                    {
                        newuser.Admin = false;
                    }
                    userLogins.Add(newuser);
                }
            }

            return userLogins;
        }
        public static List<UserRole> AdminAccess(int id)
        {
            List<UserRole> usersrole = new List<UserRole>();
            using (var dbcontext = new ProfileEntities())
            {
                var userroles = from roles in dbcontext.userroletable
                                join users1 in dbcontext.userrolerelation
                                on roles.userRoleId equals users1.roleID
                                where users1.userID == id
                                select new
                                {
                                    RoleId = roles.userRoleId,
                                    RoleName = roles.userRole
                                };
                foreach(var user in userroles)
                {
                    UserRole userRole = new UserRole()
                    {
                        RoleId = user.RoleId,
                        RoleName = user.RoleName
                    };
                    usersrole.Add(userRole);
                }
                
            }
            return usersrole;

        }
        public static void AddFilesIntoDB(int id, int userId, List<string> filenames)
        {
            using(var dbcontext = new ProfileEntities())
            {
                try
                {
                    
                    var email = dbcontext.userDetails.Where((i) => i.ID == id).Select((i) => i.email).Single().ToString();
                    foreach (var name in filenames)
                    {
                        filelist files = new filelist()
                        {
                            userID = userId,
                            filename = Path.GetFileName(name),
                            createdOn = DateTime.Today,
                            createdBy = email
                        };
                        dbcontext.filelist.Add(files);
                        dbcontext.SaveChanges();
                    }
                }catch(Exception ex)
                {

                }
                
            }
            
        }
        public static List<FileDetails> GetFilesFromDB(int id)
        {

            using (var dbcontext = new ProfileEntities())
            {
                var allfiles = new List<FileDetails>();
                var allfilelist = dbcontext.filelist.Where((i)=>i.userID==id);
                foreach (var file in allfilelist)
                {
                    var fileinfo = new FileDetails();
                    fileinfo.Name = file.filename;
                    fileinfo.ID = file.ID;
                    fileinfo.UserID=file.userID;
                    fileinfo.CreatedOn = file.createdOn.ToString().Substring(0, 10);
                    fileinfo.CreatedBy = file.createdBy.ToString();
                    allfiles.Add(fileinfo);
                }
                return allfiles;
            }
        }
        public static void DeleteUserInDB(int id)
        {
            using (var dbcontext = new ProfileEntities())
            {
                var deleteuser = dbcontext.userDetails.Where((i) => i.ID == id).ToList();
                dbcontext.userDetails.RemoveRange(deleteuser);
                var deletehobbies = dbcontext.Hobby_table.Where((i) => i.userID == id).ToList();
                dbcontext.Hobby_table.RemoveRange(deletehobbies);
                var deletelanguages = dbcontext.language_table.Where((i) => i.userID == id).ToList();
                dbcontext.language_table.RemoveRange(deletelanguages);
                var userroles = dbcontext.userrolerelation.Where((i) => i.userID == id).ToList();
                dbcontext.userrolerelation.RemoveRange(userroles);
                var deletenotes = dbcontext.note_table.Where((i) => i.ID == id).ToList();
                dbcontext.note_table.RemoveRange(deletenotes);
                dbcontext.SaveChanges();
            }
        }
        public static void DeleteFileInDB(int fileid)
        {
            using(var dbcontext = new ProfileEntities())
            {
                var file = dbcontext.filelist.Where((i)=>i.ID == fileid).ToList();
                dbcontext.filelist.RemoveRange(file);
                dbcontext.SaveChanges();
            }
        }
    }
}

