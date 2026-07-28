using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Data_Access_Layer
{
    public class clsUserDatabasesData
    {
        public static DataTable GetAllDatabasesOnDevice()
        {
            DataTable dt = new DataTable();

            string query = "SELECT Name FROM sys.databases WHERE database_id > 4 ORDER BY name";

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnections.ConnectionsString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return dt;
        }
    }
}
