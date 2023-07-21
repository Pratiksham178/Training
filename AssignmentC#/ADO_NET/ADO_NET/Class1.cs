using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET
{
    class Program
    {
        static string connectionString = "server=127.0.0.1;uid=root;pwd=mindfire;database=profileapplication";

        public static void inserttable(MySqlConnection con)
        {
                //MySqlCommand sde = new MySqlCommand("select * from country_table;", con);
                Console.WriteLine("Enter the country id");
                var countryId = Console.ReadLine();
                Console.WriteLine("Enter the country name");
                var country_name = Console.ReadLine();
                Console.WriteLine("Enter the country abbr");
                var country_abbr = Console.ReadLine();
                using (MySqlCommand sde = new MySqlCommand($"Insert into country_table values('{countryId}','{country_name}','{country_abbr}')", con))
                {
                    var result = sde.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Console.WriteLine("Data Inserted");
                    }
                    else
                    {
                        Console.WriteLine("Data Not Inserted");
                    }
                };
                return;
            
        }
        public static void update(MySqlConnection con)
        {
                Console.WriteLine("Enter the country id of country you want to update");
                var countryIdchange = Console.ReadLine();
                using (MySqlCommand select = new MySqlCommand($"select * from country_table where countryId={countryIdchange};", con))
                {
                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(select))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                    foreach (DataRow num in dataTable.Rows)
                    {
                        Console.WriteLine($"{num["countryId"]} | {num["country_name"]} | {num["country_abbr"]}");
                    }
                }
                Console.WriteLine("Enter the new country name");
                var country_namechange = Console.ReadLine();
                Console.WriteLine("Enter the new country abbr");
                var country_abbrchange = Console.ReadLine();
                using (MySqlCommand update = new MySqlCommand($"update country_table set country_name='{country_namechange}',country_abbr='{country_abbrchange}' where countryId={countryIdchange};", con))
                {
                    var result = update.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Console.WriteLine("Data Inserted");
                    }
                    else
                    {
                        Console.WriteLine("Data Not Inserted");
                    }
                }
                return;
            
        }
        public static void showtable(MySqlConnection con)
        {
                using (MySqlCommand select = new MySqlCommand("select * from country_table;", con))
                {
                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(select))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                    foreach (DataRow num in dataTable.Rows)
                    {
                    Console.WriteLine($"{num["countryId"]} | {num["country_name"]} | {num["country_abbr"]}");
                }
            }
                Console.WriteLine("");
                Console.ReadLine();
                return;
            
        }
        public static void Main()
        {
            int decision = 0;
            var con = new MySqlConnection(connectionString);
            con.Open();
            while (decision != 4)
            {
                Console.WriteLine("Enter what you want \n1.Show table\n2.Insert Table\n3.Update Table\n4.Exit");
                decision = Int32.Parse(Console.ReadLine());
                switch (decision)
                {
                    case 1:
                        showtable(con);
                        break;
                    case 2:
                        inserttable(con);
                        break;
                    case 3:
                        update(con);
                        break;
                    default:
                        break;

                }
            }
            con.Close();


        }
    }
}
