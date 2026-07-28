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
    public class clsColumnsData
    {
        static public DataTable GetAllColumnsNameByTableName(string DatabaseName,string TableName)
        {
            DataTable dt = new DataTable();
            string query = $@"
                        Select 
                        c.name as [ColumnName]
                        From sys.columns c
                        inner join sys.types t on c.user_type_id = t.user_type_id
                        where c.object_id = OBJECT_ID(@TableName)";
            using (SqlConnection connection = new SqlConnection(clsDataAccessConnections.ConnectionsString.Replace("master", DatabaseName)))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TableName", TableName);
                try
                {
                    connection.Open();
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
