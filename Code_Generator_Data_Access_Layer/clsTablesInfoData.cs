using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Code_Generator_Data_Access_Layer
{
    public class clsTablesInfoData
    {
        static public DataTable GetAllTablesNameByDatabaseName(string DatabaseName)
        {
            DataTable dt = new DataTable();
            string query = @"
                        SELECT TABLE_NAME as Name
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_TYPE = 'BASE TABLE' ";
            using (SqlConnection connection = new SqlConnection(clsDataAccessConnections.ConnectionsString.Replace("master", DatabaseName)))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {        
                       dt.Load(reader);
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
