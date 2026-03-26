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
            string query = $@"
                        use {DBName}
                        SELECT TABLE_NAME as Name
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_TYPE = 'BASE TABLE' ";
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
        static public ColumnsInfo GetColumnsByTableName(string DBName, string TableName)
        {

            ColumnsInfo ColumnInfo = new ColumnsInfo { };
            string query = $@"
                        use {DBName}
                        Select 
                        c.name as [ColumnName],
                        t.name as [DataType],
                        c.is_nullable as [IsNullable],
                        c.is_identity as [IsIdentity]
                        From sys.columns c
                        inner join sys.types t on c.user_type_id = t.user_type_id
                        where c.object_id = OBJECT_ID('{TableName}')";
            using (SqlConnection connection = new SqlConnection(clsDataAccessConnections.ConnectionsString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ColumnInfo.ColumnName = (string)reader["ColumnName"];
                            ColumnInfo.DataType = (string)reader["DataType"];
                            ColumnInfo.IsNullable = (bool)reader["IsNullable"];
                            ColumnInfo.IsIdentity = (bool)reader["IsIdentity"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error: " + ex.Message);
                }
            }
            return ColumnInfo;
        }
        static public List<ColumnsInfo> GetAllColumnsByTableName(string DBName, string TableName)
        {

            List<ColumnsInfo> ColumnsInfo = new List<ColumnsInfo> { };
            string query = $@"
                        use {DBName}
                        Select 
                        c.name as [ColumnName],
                        t.name as [DataType],
                        c.is_nullable as [IsNullable],
                        c.is_identity as [IsIdentity]
                        From sys.columns c
                        inner join sys.types t on c.user_type_id = t.user_type_id
                        where c.object_id = OBJECT_ID('{TableName}')";
            using (SqlConnection connection = new SqlConnection(clsDataAccessConnections.ConnectionsString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ColumnsInfo ColumnInfo = new ColumnsInfo { };
                        while (reader.Read())
                        {
                            ColumnInfo.ColumnName = (string)reader["ColumnName"];
                            ColumnInfo.DataType = (string)reader["DataType"];
                            ColumnInfo.IsNullable = (bool)reader["IsNullable"];
                            ColumnInfo.IsIdentity = (bool)reader["IsIdentity"];

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
        
        static public bool GetColumnsByTableName(string DBName, string TableName,
            ref string ColumnName, ref string DataType, ref bool IsNullable, ref bool IsIdentity)
        {
            bool isFound = false;
            ColumnsInfo ColumnInfo = new ColumnsInfo { };
            string query = $@"
                        use {DBName}
                        Select 
                        c.name as [ColumnName],
                        t.name as [DataType],
                        c.is_nullable as [IsNullable],
                        c.is_identity as [IsIdentity]
                        From sys.columns c
                        inner join sys.types t on c.user_type_id = t.user_type_id
                        where c.object_id = OBJECT_ID('{TableName}')";
            using (SqlConnection connection = new SqlConnection(clsDataAccessConnections.ConnectionsString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;
                            ColumnName = (string)reader["ColumnName"];
                            DataType = (string)reader["DataType"];
                            IsNullable = (bool)reader["IsNullable"];
                            IsIdentity = (bool)reader["IsIdentity"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    isFound = false;
                    //Console.WriteLine("Error: " + ex.Message);
                }
            }
            return isFound;
        }
    }
}
