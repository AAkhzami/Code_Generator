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
        static public async Task<DataTable> GetAllTablesInfoByDatabaseName(string DatabaseName)
        {
            DataTable dt = new DataTable();
            string query = @"
                        WITH cte_pk AS
                        (
                            SELECT 
                                ic.object_id,
                                ic.column_id
                            FROM sys.index_columns ic
                            INNER JOIN sys.indexes i
                                ON ic.object_id = i.object_id
                                AND ic.index_id = i.index_id
                            WHERE i.is_primary_key = 1
                        )
                        SELECT 
                            t.TABLE_NAME AS Name,
                            COUNT(c.column_id) AS Columns,
                            CASE 
                                WHEN COUNT(pk.column_id) > 0 THEN 1
                                ELSE 0
                            END AS IsPrimaryKey
                        FROM INFORMATION_SCHEMA.TABLES t
                        INNER JOIN sys.columns c
                            ON c.object_id = OBJECT_ID(t.TABLE_NAME)
                        LEFT JOIN cte_pk pk
                            ON pk.object_id = c.object_id
                            AND pk.column_id = c.column_id
                        WHERE t.TABLE_TYPE = 'BASE TABLE'
                        GROUP BY 
                            t.TABLE_NAME;";
            using (SqlConnection connection = new SqlConnection(clsDataAccessConnections.ConnectionsString.Replace("master", DatabaseName)))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
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
