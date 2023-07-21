using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET
{
     class Program
    {
        static string connectionString = "server=127.0.0.1;uid=root;pwd=mindfire;database=profileapplication";

        public static void inserttable()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
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
                con.Close();
                return;
            }
        }
        public static void update()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                Console.WriteLine("Enter the country id of country you want to update");
                var countryIdchange = Int32.Parse(Console.ReadLine());
                using (MySqlCommand select = new MySqlCommand($"select * from country_table where countryId={countryIdchange};", con))
                {
                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter dataAdapterr = new MySqlDataAdapter(select))
                    {
                        dataAdapterr.Fill(dataTable);
                    }
                    foreach (DataRow num in dataTable.Rows)
                    {
                        Console.WriteLine($"{num["countryId"]} , {num["country_name"]}");
                    }
                }
                Console.WriteLine("Enter the new country name");
                var country_namechange = Console.ReadLine();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT * FROM country_table",con);

                dataAdapter.UpdateCommand = new MySqlCommand(
                   "UPDATE country_table SET country_name = @country_name " +
                   "WHERE countryId = @countryId", con);

                dataAdapter.UpdateCommand.Parameters.Add("@country_name", MySqlDbType.String, 15, "country_name");

                MySqlParameter parameter = dataAdapter.UpdateCommand.Parameters.Add("@countryId", MySqlDbType.UInt32);
                parameter.SourceColumn = "countryId";
                parameter.SourceVersion = DataRowVersion.Original;

                DataTable countryTable = new DataTable();
                dataAdapter.Fill(countryTable);

                DataRow categoryRow = countryTable.Rows[countryIdchange-1];
                categoryRow["country_name"] = country_namechange;
                categoryRow["countryId"] = 3;

                dataAdapter.Update(countryTable);

                Console.WriteLine("Rows after update.");
                foreach (DataRow row in countryTable.Rows)
                {
                    {
                        Console.WriteLine("{0}: {1}", row[0], row[1]);
                    }
                }
                con.Close();
                return;
            }
        }
        public static void showtable()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                con.Open();
                using (MySqlCommand select = new MySqlCommand("select * from country_table;", con))
                {
                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(select))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                    foreach (DataRow num in dataTable.Rows)
                    {
                        Console.WriteLine($"{num["countryId"]} , {num["country_name"]}");
                    }
                }
                con.Close();
                Console.WriteLine("");
                Console.ReadLine();
                return;
            }
        }
        public static void Main()
        {
            int decision = 0;
            while(decision !=4)
            {
                Console.WriteLine("Enter what you want \n1.Show table\n2.Insert Table\n3.Update Table\n4.Exit");
                decision = Int32.Parse(Console.ReadLine());
                switch (decision)
                {
                    case 1:
                        showtable();
                        break;
                    case 2:
                        inserttable();
                        break;
                    case 3:
                        update();
                        break;
                    default:
                        break;

                }
            }
            

        }
    }
}
