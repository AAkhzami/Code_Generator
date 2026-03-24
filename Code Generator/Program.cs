using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Linq;

namespace Code_Generator
{
    public class BasicM
    {
        public struct ConnectionInfo
        {
            public string userID;
            public string password;
            public string dbName;
        }
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

            //use @DBName
            List<string> cName = new List<string>();
            string connectionString = $"Server = .; Database = {dbName}; User Id = sa; Password = sa123456";
            string query = @"
                        SELECT TABLE_NAME as Name
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_TYPE = 'BASE TABLE' ";
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

        static public ColumnsInfo GetColumnsByTableName(string connection_string, string TableName)
        {

            ColumnsInfo ColumnInfo = new ColumnsInfo { };
            string query = $@"
                        Select 
                        c.name as [ColumnName],
                        t.name as [DataType],
                        c.is_nullable as [IsNullable],
                        c.is_identity as [IsIdentity]
                        From sys.columns c
                        inner join sys.types t on c.user_type_id = t.user_type_id
                        where c.object_id = OBJECT_ID('{TableName}')";
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            ColumnInfo.ColumnName = (string )reader["ColumnName"];
                            ColumnInfo.DataType = (string)reader["DataType"];
                            ColumnInfo.IsNullable = (bool)reader["IsNullable"];
                            ColumnInfo.IsIdentity = (bool)reader["IsIdentity"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return ColumnInfo;
        }
        static public List<ColumnsInfo> GetAllColumnsByTableName(string connection_string, string TableName)
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
                        where c.object_id = OBJECT_ID('{TableName}')";
            using (SqlConnection connection = new SqlConnection(connection_string))
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
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return ColumnsInfo;
        }
    }


    internal class Program
    {
        static public string GetColumnsNamesString(string DatabaseName, string TableName, string Seperator = ",", string Additions = null)
        {
            string connectionString = $"Server = .; Database = {DatabaseName}; User Id = sa; Password = sa123456";
            List<BasicM.ColumnsInfo> ColumnsInfo = BasicM.GetAllColumnsByTableName(connectionString, TableName);
            List<string> ParametersList = new List<string>();
            foreach (BasicM.ColumnsInfo ci in ColumnsInfo)
            {
                if (!ci.IsIdentity)
                    ParametersList.Add(Additions + ci.ColumnName);
            }
            string Parameters_Text = string.Join(Seperator, ParametersList);

            return Parameters_Text;
        }
        static public string CreateAddQuery(string DatabaseName ,string TableName)
        {
            string query = $@"Insert into {TableName}
                                ({GetColumnsNamesString(DatabaseName,TableName)})
                                Values ({GetColumnsNamesString(DatabaseName,TableName,",","@")})
                                select SCOPE_IDENTITY();";

            return query;
        }
        static public string GetParameterAddWithValuesString(BasicM.ColumnsInfo cInfo)
        {
            string code = "";
            string Representative = "\"@" + cInfo.ColumnName + "\"";
            if (cInfo.IsNullable)
                code = $@"if({cInfo.ColumnName} == null) ? command.Parameters.AddWithValue({Representative}, DBNull.Value); : command.Parameters.AddWithValue({Representative}, {cInfo.ColumnName.ToLower()});";
            else
                code = $@"command.Parameters.AddWithValue({Representative}, {cInfo.ColumnName.ToLower()});";

            return code;

        }
        static public string WriteBodyOfNewRecordMethod(string tableName, BasicM.ConnectionInfo connectionInfo)
        {
            string connectionString = $"Server = .; Database = {connectionInfo.dbName}; User Id = {connectionInfo.userID}; Password = {connectionInfo.password}";
            List<BasicM.ColumnsInfo> columnsInfo = BasicM.GetAllColumnsByTableName(connectionString, tableName);
            string query_text = CreateAddQuery(connectionInfo.dbName, tableName);
            query_text.Insert(0, "\"");
            query_text.Insert(query_text.Length - 1, "\"");

            StringBuilder sb = new StringBuilder();

            foreach (BasicM.ColumnsInfo columnInfo in columnsInfo)
            {
                if (!columnInfo.IsIdentity)
                    sb.Append(GetParameterAddWithValuesString(columnInfo) + Environment.NewLine);
            }
            string connectiontext = $"\"{connectionString}\"";
            string TheBodyOfMethod = "\"" + $@"
                                        int recordId = null;
                                        string connection_text = {connectiontext};
                                        SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
                                        string query = {query_text};
                                        SqlCommand command = new SqlCommand(query, connection);
                                        {sb}
                                        try
                                        {{
                                            connection.Open();
                                            object result = command.ExecuteScalar();

                                            if (result != null && int.TryParse(result.ToString(), out int newID))
                                            {{
                                                recordId = newID;
                                            }}
                                        }}
                                        catch (Exception ex)
                                        {{
                                            recordId = null;
                                        }}
                                        finally
                                        {{
                                        connection.Close();
                                        }}
                                        return recordId;" + "\"";

            return TheBodyOfMethod;
        }
        static public string WriteAddNewRecordMethod(string tableName,List<BasicM.ColumnsInfo> columnsInfo, BasicM.ConnectionInfo connectionInfo)
        {


            return null;                    
        }
        static public void PrintColumnInfo(BasicM.ColumnsInfo columnsInfo)
        {

            Console.WriteLine($"    CName : {columnsInfo.ColumnName}");
            Console.WriteLine($"    CType : {columnsInfo.DataType}");
            Console.WriteLine($"    Is Nullable : {columnsInfo.IsNullable}");
            Console.WriteLine($"    Is Identity : {columnsInfo.IsIdentity}");
        }
        static public void PrintColumnsInfo(string DatabaseName, string TableName)
        {
            string connectionString = $"Server = .; Database = {DatabaseName}; User Id = sa; Password = sa123456";
            List<BasicM.ColumnsInfo> ColumnsInfo = BasicM.GetAllColumnsByTableName(connectionString,TableName);
            int counter = 1;
            foreach(BasicM.ColumnsInfo ci in ColumnsInfo)
            {
                Console.WriteLine($"Column No.{counter} : ");
                PrintColumnInfo(ci);
                Console.WriteLine(Environment.NewLine);
                counter++;
            }
            Console.WriteLine("--------------------------------");
        }
        static void Main(string[] args)
        {
            //List<string> l = ForTest.GetAllDatabase();
            //foreach (string name in l)
            //{
            //    Console.WriteLine($"Name : {name}");
            //}

            //Console.WriteLine("\n\n\n\n");
            //Console.WriteLine("------------------------------------");
            //Console.WriteLine("\n\n\n\n");

            //foreach (string dbName in l)
            //{
            //    Console.WriteLine($"Database Name : {dbName}");
            //    List<string> c = ForTest.GetAllTablesOnDatabase(dbName);
            //    foreach(string  name in c)
            //    {
            //        Console.WriteLine($"Table Name : {name}");
            //    }
            //    Console.WriteLine("------------------------------------\n\n");
            //}



            //List<string> l = ForTest.GetAllDatabase();
            //int i = 0;
            //foreach (string dbName in l)
            //{
            //    if (i > 3)
            //        break;
            //    Console.WriteLine($"Database Name : {dbName}");
            //    List<string> Tables = ForTest.GetAllTablesOnDatabase(dbName);
            //    foreach (string TableName in Tables)
            //    {
            //        Console.WriteLine($"- Table Name : {TableName}");
            //        PrintColumnsInfo(dbName, TableName);
            //    }
            //    Console.WriteLine("------------------------------------\n\n");
            //    i++;
            //}
            BasicM.ConnectionInfo connection = new BasicM.ConnectionInfo { userID = "sa", password = "sa123456", dbName = "Clinic" };
            Console.WriteLine(WriteBodyOfNewRecordMethod("Persons",connection));
        }
    }
}
