using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUserRegistration.DAL
{
    
    public class DAL
    {
        public static List<UserBasicInto> GetData()
        {
            List<user> userList = new List<user>();

            using (var dbcontext = new ProfileEntities())
            {
                var allusers = dbcontext.userDetails.Select((i) => new
                {
                    i.ID,
                    i.FirstName,
                    i.LastName,
                    i.email,

                }).ToList();
                foreach (var oneuser in allusers)
                {
                    user newuser = new user();
                    newuser.userID = oneuser.ID;
                    newuser.firstName = oneuser.FirstName;
                    newuser.lastName = oneuser.LastName;
                    newuser.email = oneuser.email;
                    newuser.userRole = string.Join(", ", (from userrelation in dbcontext.userrolerelation
                                                          where userrelation.userID == newuser.userID
                                                          join userrole1 in dbcontext.userroletable on userrelation.roleID equals userrole1.userRoleId
                                                          select userrole1.userRole).ToList()).ToLower();
                    newuser.languages = string.Join(", ", dbcontext.language_table.Where((i) => i.userID == oneuser.ID).Select((i) => i.language).ToList());
                    newuser.hobbies = string.Join(", ", dbcontext.Hobby_table.Where((i) => i.userID == oneuser.ID).Select((i) => i.hobby).ToList());
                    userList.Add(newuser);
                }
            }
            return userList;
        }
    }
}
