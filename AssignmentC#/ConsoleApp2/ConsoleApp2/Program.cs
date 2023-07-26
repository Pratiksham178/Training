using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var dbcontext = new ProfileEntities())
            {
                //var x = dbcontext.country_table.Select(i => new { countryId = i.CountryId, countryName = i.Country_name, countryAbbr = i.Country_abbr });
                //foreach (var c in x)
                //{
                //    Console.WriteLine(c.countryId + c.countryName + c.countryAbbr);
                //}
                var state = dbcontext.state_table.Where(s => s.countryId == 1);
                foreach (var c in state)
                {
                    Console.WriteLine(c.state_name);
                }
                var stateincountry = dbcontext.state_table.Join(dbcontext.country_table,
                    s => s.countryId,
                    c => c.CountryId,
                    (s, c) => new
                    {
                        countryID = c.CountryId,
                        countryName = c.Country_name,
                        stateName = s.state_name
                    });
                foreach (var c in stateincountry)
                {
                    Console.WriteLine(c.countryID+c.countryName+c.stateName);
                }
                //Insert
                //country_table newCountry = new country_table { CountryId = 4, Country_name = "Iceland", Country_abbr = "IS" };
                //dbcontext.country_table.Add(newCountry);
                //dbcontext.SaveChanges();
                //Console.ReadKey();
                //delete
                //var deletecountry = dbcontext.country_table.SingleOrDefault(s => s.CountryId == 4);
                //if(deletecountry != null)
                //{
                //    dbcontext.country_table.Remove(deletecountry);
                //    dbcontext.SaveChanges();
                //}
                //update
                var updatecountry = dbcontext.country_table.Single(s=>s.CountryId == 4);
                updatecountry.Country_abbr = "IS";
                dbcontext.SaveChanges();
                var result = dbcontext.getState(1);
                foreach (var c in result)
                {
                    Console.WriteLine(c.state_name);
                }

                Console.ReadKey();

            }
        }
    }
}
