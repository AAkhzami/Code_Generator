using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Code_Generator
{
    public class ForTest
    {
        static public List<string> GetAllDatabase()
        {
            List<string> dbNames = new List<string>();
            string connectionString = "Server=.;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";
            string query = "SELECT name FROM sys.databases WHERE database_id > 4 ORDER BY name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dbNames.Add(reader["name"].ToString());
                            //Console.WriteLine($"Name : {reader["name"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return dbNames;
        }
        static public List<string> GetAllTablesOnDatabase( string dbName)
        {
            List<string> cName = new List<string>();
            string connectionString = $"Server = .; Database = {dbName}; User Id = sa123456; Password = 123456";
            string query = @"
                        use @DBName
                        SELECT TABLE_NAME as Name
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_TYPE = 'BASE TABLE' ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DBName", dbName);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cName.Add(reader["Name"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return cName;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> l = ForTest.GetAllDatabase();
            foreach (string name in l)
            {
                Console.WriteLine($"Name : {name}");
            }

            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("\n\n\n\n");

            foreach (string dbName in l)
            {
                List<string> c = ForTest.GetAllTablesOnDatabase(dbName);
                foreach(string  name in c)
                {
                    Console.WriteLine($"CName : {c}");
                }
                Console.WriteLine("------------------------------------\n\n");
            }
        }
    }
}
