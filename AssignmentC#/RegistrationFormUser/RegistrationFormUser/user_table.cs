//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistrationFormUser
{
    using System;
    using System.Collections.Generic;
    
    public partial class user_table
    {
        public int userId { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public int countryId { get; set; }
        public int stateId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
    
        public virtual country_table country_table { get; set; }
        public virtual state_table state_table { get; set; }
    }
}