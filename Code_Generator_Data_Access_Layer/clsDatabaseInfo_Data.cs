using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Code_Generator_Data_Access_Layer
{
    static public class clsDatabaseInfo_Data
    {
        public struct ColumnsInfo
        {
            public string ColumnName { get; set; }
            public string DataType { get; set; }
            public bool IsNullable { get; set; }
            public bool IsIdentity { get; set; }
        }
        static public List<string> GetAllDatabase()
        {
            List<string> dbNames = new List<string>();
            string query = "SELECT name FROM sys.databases WHERE database_id > 4 ORDER BY name";

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
                            dbNames.Add(reader["name"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                }
            }

            return dbNames;
        }
        static public List<string> GetAllTablesOnDatabase(string DBName)
        {

            List<string> cName = new List<string>();
            string query = @"
                        SELECT TABLE_NAME as Name
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_TYPE = 'BASE TABLE' ";
            using (SqlConnection connection = new SqlConnection(clsDataAccessConnections.ConnectionsString.Replace("master", DBName)))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
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
                    //Console.WriteLine("Error: " + ex.Message);
                }
            }
            return cName;
        }
        static public List<ColumnsInfo> GetAllColumnsByTableName(string DBName, string TableName)
        {

            List<ColumnsInfo> ColumnsInfo = new List<ColumnsInfo> { };
            string query = $@"
                        Select 
                        c.name as [ColumnName],
                        t.name as [DataType],
                        c.is_nullable as [IsNullable],
                        c.is_identity as [IsIdentity]
                        From sys.columns c
                        inner join sys.types t on c.user_type_id = t.user_type_id
                        where c.object_id = OBJECT_ID(@TableName)";
            using (SqlConnection connection = new SqlConnection(clsDataAccessConnections.ConnectionsString.Replace("master", DBName)))
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
                            ColumnsInfo ColumnInfo = new ColumnsInfo { 
                                ColumnName = (string)reader["ColumnName"],
                                DataType = (string)reader["DataType"],
                                IsNullable = (bool)reader["IsNullable"],
                                IsIdentity = (bool)reader["IsIdentity"],
                            };
                            ColumnsInfo.Add(ColumnInfo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                }
            }
            return ColumnsInfo;
        }                
    }
}
