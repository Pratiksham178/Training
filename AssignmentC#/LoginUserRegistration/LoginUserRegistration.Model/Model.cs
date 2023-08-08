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
    }
    public class countryList
    {

    }
    public class Model
    {
    }
}
