using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Model
{
    public class Hobbies
    {
        public int UserID { get; set; }
        public string HobbyName { get; set; }
    }
    public class LanguagesKnown
    {
        public int UserID { get; set; }
        public string LangName { get; set; }
    }
    public class UserBasicInto
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string Hobbies { get; set; }
        public string LanguagesKnown { get; set; }
    }
    public class CountryList
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
    }
    public class StateList
    {
        public int ID { get; set; }
        public string StateName { get; set; }
    }
    public class UserRole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class UserInformation { 
        public string email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string AddressLine1Permanent { get; set; }
        public string AddressLine2Permanent { get; set; }
        public string CityPermanent { get; set; }
        public int StatePermanent { get; set; }
        public int CountryPermanent { get; set; }
        public string ZipcodePermanent { get; set; }
        public string AddressLine1Present { get; set; }
        public string AddressLine2Present { get; set; }
        public string CityPresent { get; set; }
        public int StatePresent { get; set; }
        public int CountryPresent { get; set; }
        public string ZipcodePresent { get; set; }
        public string Password { get; set; }
        public List<string> Hobbies { get; set; }
        public List<string> LanguagesKnown { get; set; }
        public List<int> UserRoles { get; set; }
    }
    public class NoteData
    {
        public string Note { get; set; }
        public int UserID { get; set; }
        public string CreatedOn { get; set; }
        public string Visible { get; set; }
    }
    public class UserLogin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }
    public class FileDetails
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int UserID { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }

    }
    public class Models
    {
    }
}
