using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUserRegistration.Model
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
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public System.DateTime DOB { get; set; }
        public string CityPermanent { get; set; }
        public int StatePermanent { get; set; }
        public int CountryPermanent { get; set; }
        public string ZipcodePermanent { get; set; }
        public string CityPresent { get; set; }
        public int StatePresent { get; set; }
        public int CountryPresent { get; set; }
        public string ZipcodePresent { get; set; }
        public string Password { get; set; }
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
        public int CountryID { get; set; }
    }
    public class Model
    {
    }
}
