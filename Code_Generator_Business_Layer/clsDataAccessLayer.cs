using Code_Generator_Data_Access_Layer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static Code_Generator_Data_Access_Layer.clsDatabaseInfo_Data;

namespace Code_Generator_Business_Layer
{
    public class clsDataAccessLayer
    {
        enum enFilterType { IdentityC, NullableC};

        public struct strColumnsInfo
        {
            public string ColumnName { get; set; }
            public string DataType { get; set; }
            public bool IsNullable { get; set; }
            public bool IsIdentity { get; set; }
        }
        public struct strConnectionInfo
        {
            public string userID;
            public string password;
            public string dbName;
        }
        private static List<strColumnsInfo> GetAllColumnsInfo(string DBName, string TableName)
        {
            List<strColumnsInfo> columnsInfoList = new List<strColumnsInfo>();
            List<clsDatabaseInfo_Data.ColumnsInfo> _columnsInfoList = clsDatabaseInfo_Data.GetAllColumnsByTableName(DBName, TableName);
            foreach (clsDatabaseInfo_Data.ColumnsInfo ci in _columnsInfoList)
            {
                strColumnsInfo columnsInfo = new strColumnsInfo();
                columnsInfo.ColumnName = ci.ColumnName;
                columnsInfo.DataType = ci.DataType;
                columnsInfo.IsNullable = ci.IsNullable;
                columnsInfo.IsIdentity = ci.IsIdentity;
                columnsInfoList.Add(columnsInfo);
            }

            return columnsInfoList;
        }
        private static List<strColumnsInfo> FilterColumnsInfo(List<strColumnsInfo> columnsInfoList, enFilterType filterType)
        {
            List<strColumnsInfo> FilterColumnsInfoList = new List<strColumnsInfo>();

            foreach (strColumnsInfo ColumnsInfo in columnsInfoList)
            {
                switch(filterType)
                {
                    case enFilterType.IdentityC:
                        if(ColumnsInfo.IsIdentity)
                            FilterColumnsInfoList.Add(ColumnsInfo);
                        break;
                    case enFilterType.NullableC:
                        if(ColumnsInfo.IsNullable)
                            FilterColumnsInfoList.Add(ColumnsInfo);
                        break;
                    
                }
            }

            return FilterColumnsInfoList;
        }
        private static string MapSqlTypeToCSharp(string sqlType, bool isNullable = false)
        {
            string csharpType;

            switch (sqlType)
            {
                case "bigint": csharpType = "long"; break;
                case "int": csharpType = "int"; break;
                case "smallint": csharpType = "short"; break;
                case "tinyint": csharpType = "byte"; break;
                case "bit": csharpType = "bool"; break;
                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney": csharpType = "decimal"; break;
                case "float": csharpType = "double"; break;
                case "real": csharpType = "float"; break;
                case "datetime":
                case "datetime2":
                case "date":
                case "smalldatetime": csharpType = "DateTime"; break;
                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                case "char":
                case "nchar": csharpType = "string"; break;
                case "binary":
                case "varbinary":
                case "image": csharpType = "byte[]"; break;
                case "uniqueidentifier": csharpType = "Guid"; break;
                default: csharpType = "object"; break;
            }

            if (isNullable && csharpType != "string" && csharpType != "byte[]" && csharpType != "object")
                csharpType += "?";
            return csharpType;
        }
        private static string GetIDentityParametersName(List<strColumnsInfo> columnsInfos, bool AddType = false)
        {
            List<string> IdentityColumnsList = new List<string>();
            string IdentityColumn = "";
            foreach (strColumnsInfo columnInfo in columnsInfos)
            {
               
                if (columnInfo.IsIdentity)
                {
                    if (AddType)
                        IdentityColumn += MapSqlTypeToCSharp(columnInfo.DataType) + " ";
                    IdentityColumn += columnInfo.ColumnName;
                    IdentityColumnsList.Add(IdentityColumn);

                }

            }

            return string.Join(",", IdentityColumnsList);
        }



        private static string GetParamatersFunction(List<strColumnsInfo> ColumnsInfo, bool IncludeIdentityParameter = false)
        {
            List<string> ParametersList = new List<string>();
            foreach (strColumnsInfo ci in ColumnsInfo)
            {
                if (!IncludeIdentityParameter)
                    if (ci.IsIdentity) continue;
                ParametersList.Add(MapSqlTypeToCSharp(ci.DataType,ci.IsNullable) + " " + ci.ColumnName.ToLower());
            }
            string Parameters_Text = string.Join(",", ParametersList);

            return Parameters_Text;
        }
        private static string GetColumnsNamesString(List<strColumnsInfo> ColumnsInfo, bool IncludeIdentityParameter = false, string Additions = null)
        {
            
            List<string> ParametersList = new List<string>();
            foreach (strColumnsInfo ci in ColumnsInfo)
            {
                if (!IncludeIdentityParameter)
                    if (ci.IsIdentity) continue;
                ParametersList.Add(Additions + ci.ColumnName);
            }
            string Parameters_Text = string.Join(",", ParametersList);

            return Parameters_Text;
        }
        
        //Insert Methods
        private static string WriteAddQuery(string DatabaseName, string TableName)
        {
            List<strColumnsInfo> columnsInfos = GetAllColumnsInfo(DatabaseName, TableName);
            string query = $@"@""Insert into {TableName}
                                ({GetColumnsNamesString(columnsInfos)})
                                Values ({GetColumnsNamesString(columnsInfos, false ,"@")})
                                select SCOPE_IDENTITY()"";";
            return query;
        }
        private static string GetParameterAddWithValuesString(strColumnsInfo cInfo)
        {
            string code = "";
            string Representative = "\"@" + cInfo.ColumnName + "\"";
            if (cInfo.IsNullable)
                code = $@"if({cInfo.ColumnName.ToLower()} == null) command.Parameters.AddWithValue({Representative}, DBNull.Value); else command.Parameters.AddWithValue({Representative}, {cInfo.ColumnName.ToLower()});";
            else
                code = $@"command.Parameters.AddWithValue({Representative}, {cInfo.ColumnName.ToLower()});";

            return code;

        }
        private static string WriteBodyOfNewRecordMethod(string tableName, strConnectionInfo connectionInfo)
        {
            List<strColumnsInfo> columnsInfo = GetAllColumnsInfo(connectionInfo.dbName, tableName);
            string query_text = WriteAddQuery(connectionInfo.dbName, tableName);
            query_text.Insert(0, "\"");
            query_text.Insert(query_text.Length - 1, "\"");

            StringBuilder sb = new StringBuilder();

            foreach (strColumnsInfo columnInfo in columnsInfo)
            {
                if (!columnInfo.IsIdentity)
                    sb.Append(GetParameterAddWithValuesString(columnInfo) + Environment.NewLine);
            }
            string TheBodyOfMethod = $@"
                                        int? recordId = null;
                                        SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
                                        string query = {query_text}
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
                                        return recordId;";

            return TheBodyOfMethod;
        }



        //Update Methods

        private static string WriteUpdateQuery(string DatabaseName, string TableName)
        {
            List<strColumnsInfo> columnsInfos = GetAllColumnsInfo(DatabaseName, TableName);

            string[] IdentityParameters = GetIDentityParametersName(columnsInfos).Split(',');
            string[] Parameters = GetColumnsNamesString(columnsInfos,true).Split(',');
            string[] Representative = GetColumnsNamesString(columnsInfos, false, "@").Split(',');

            StringBuilder SetParametersString = new StringBuilder();
            for(int i = 0; i < Parameters.Length -1; i++)
            {
                SetParametersString.Append("        " + Parameters[i + 1] + " = " + Representative[i]);
                if (!(i == (Parameters.Length - (1 + IdentityParameters.Length)))) SetParametersString.Append(",");
                SetParametersString.Append(Environment.NewLine);
            }

            StringBuilder ConditionString = new StringBuilder();

            for (int i = 0; i < IdentityParameters.Length; i++)
            {
                if (i == 0)
                    ConditionString.Append($"where {IdentityParameters[i]} = @{IdentityParameters[i]}");
                else
                    ConditionString.Append($"And {IdentityParameters[i]} = @{IdentityParameters[i]}");

            }

            string query = $"@\"UPDATE {TableName}\n        Set \n{SetParametersString}        {ConditionString}\";";
            return query;
        }
        private static string WriteBodyOfUpdateRecordMethod(string tableName, strConnectionInfo connectionInfo)
        {
            List<strColumnsInfo> columnsInfo = GetAllColumnsInfo(connectionInfo.dbName, tableName);
            string query_text = WriteUpdateQuery(connectionInfo.dbName, tableName);

            StringBuilder sb = new StringBuilder();

            foreach (strColumnsInfo columnInfo in columnsInfo)
            {
                sb.Append("        " + GetParameterAddWithValuesString(columnInfo) + Environment.NewLine);
            }

            string TheBodyOfMethod = $@"
                                        int rowsAffected = 0;
                                        SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
                                        string query = {query_text}
                                        SqlCommand command = new SqlCommand(query, connection);
                                        {sb}
                                        try
                                        {{
                                            connection.Open();
                                            rowsAffected = command.ExecuteNonQuery();
                                        }}
                                        catch (Exception ex)
                                        {{
                                            return false;
                                        }}
                                        finally
                                        {{
                                        connection.Close();
                                        }}
                                        return rowsAffected > 0;";

            return TheBodyOfMethod;
        }


        //Select Methods 
        private static string GetReferParamtersFunction(List<strColumnsInfo> ColumnsInfo)
        {

            List<string> ParametersList = new List<string>();
            foreach (strColumnsInfo ci in ColumnsInfo)
            {
                string paramterFormat = (MapSqlTypeToCSharp(ci.DataType, ci.IsNullable) + " " + ci.ColumnName.ToLower());
                if (ci.IsIdentity)
                {
                    ParametersList.Add(paramterFormat);

                    continue; 
                }
                else
                    ParametersList.Add("ref " + paramterFormat);
            }
            string Parameters_Text = string.Join(",", ParametersList);

            return Parameters_Text;
        }
        private static string WriteSelectQuery(string DatabaseName, string TableName)
        {
            List<strColumnsInfo> parametersList = FilterColumnsInfo(GetAllColumnsInfo(DatabaseName, TableName), enFilterType.IdentityC);
            StringBuilder ConditionString = new StringBuilder();
            foreach (strColumnsInfo idP in parametersList)
            {
                ConditionString.Append(idP.ColumnName + " = @" + idP.ColumnName);
            }

            string query = $"@\"select * from {TableName}\n        where {ConditionString}\";";
            return query;
        }
        private static string CreateSellectionInformationAndVariable(List<strColumnsInfo> parametersList)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (strColumnsInfo parameter in parametersList)
            {
                stringBuilder.Append($"{parameter.ColumnName.ToLower()} = ({MapSqlTypeToCSharp(parameter.DataType)})reader[\"{parameter.ColumnName}\"];" + Environment.NewLine);
            }
            return stringBuilder.ToString();
        }
        private static string WriteBodyOfGetInfoRecordMethod(string tableName, strConnectionInfo connectionInfo)
        {

            string query_text = WriteSelectQuery(connectionInfo.dbName, tableName) ;

            List<strColumnsInfo> ParamtersList = GetAllColumnsInfo(connectionInfo.dbName, tableName);

            List<strColumnsInfo> FilteringParametersList = FilterColumnsInfo(ParamtersList, enFilterType.IdentityC);
            StringBuilder AppendingValues = new StringBuilder();

            foreach(strColumnsInfo par in FilteringParametersList)
                AppendingValues.Append(GetParameterAddWithValuesString(par) + Environment.NewLine);


            string GettingInformationFormateString= CreateSellectionInformationAndVariable(ParamtersList);

            string TheBodyOfMethod = $@"
                                        bool isFound = false;
                                        SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
                                        string query = {query_text}
                                        SqlCommand command = new SqlCommand(query, connection);
                                        {AppendingValues}
                                        try
                                        {{
                                            connection.Open();
                                            SqlDataReader reader = command.ExecuteReader();
                                            if(reader.Read())
                                            {{
                                                isFound = true;
                                                {GettingInformationFormateString}
                                            }}
                                            reader.Close();
                                        }}
                                        catch (Exception ex)
                                        {{
                                            return false;
                                        }}
                                        finally
                                        {{
                                        connection.Close();
                                        }}
                                        return isFound;";

            return TheBodyOfMethod;
        }





        //Delete Methods
        private static string WriteDeleteQuery(string DatabaseName, string TableName)
        {
            List<strColumnsInfo> parametersList = FilterColumnsInfo(GetAllColumnsInfo(DatabaseName, TableName), enFilterType.IdentityC);
            StringBuilder ConditionString = new StringBuilder();
            foreach (strColumnsInfo idP in parametersList)
            {
                ConditionString.Append(idP.ColumnName + " = @" + idP.ColumnName);
            }

            string query = $"@\"DELETE FROM {TableName} where {ConditionString}\";";
            return query;
        }
        private static string WriteBodyOfDeleteRecordMethod(string tableName, strConnectionInfo connectionInfo)
        {

            string query_text = WriteDeleteQuery(connectionInfo.dbName, tableName);

            List<strColumnsInfo> ParamtersList = GetAllColumnsInfo(connectionInfo.dbName, tableName);

            List<strColumnsInfo> FilteringParametersList = FilterColumnsInfo(ParamtersList, enFilterType.IdentityC);
            StringBuilder AppendingValues = new StringBuilder();

            foreach (strColumnsInfo par in FilteringParametersList)
                AppendingValues.Append(GetParameterAddWithValuesString(par) + Environment.NewLine);


            string TheBodyOfMethod = $@"
                                        int rowsAffected = 0;
                                        SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
                                        string query = {query_text}
                                        SqlCommand command = new SqlCommand(query, connection);
                                        {AppendingValues}
                                        try
                                        {{
                                            connection.Open();
                                            rowsAffected = command.ExecuteNonQuery();
                                            
                                        }}
                                        catch (Exception ex)
                                        {{
                                            return false;
                                        }}
                                        finally
                                        {{
                                            connection.Close();
                                        }}
                                        return rowsAffected > 0;";

            return TheBodyOfMethod;
        }





        //Get All Data Methods
        private static string WriteSelectAllRecordsQuery(string DatabaseName, string TableName)
        {
            string query = $"@\"select * FROM {TableName}\";";
            return query;
        }
        private static string WriteBodyOfSelectAllRecordsMethod(string tableName, strConnectionInfo connectionInfo)
        {
            string query_text = WriteSelectAllRecordsQuery(connectionInfo.dbName, tableName);
            string TheBodyOfMethod = $@"
                                        DataTable dt = new DataTable();
                                        SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
                                        string query = {query_text}
                                        SqlCommand command = new SqlCommand(query, connection);
                                        try
                                        {{
                                            connection.Open();
                                            SqlDataReader reader = command.ExecuteReader();

                                            if (reader.HasRows)
                                            {{
                                                dt.Load(reader);
                                            }}

                                            reader.Close();
                                        }}
                                        catch (Exception ex)
                                        {{ }}
                                        finally
                                        {{
                                            connection.Close();
                                        }}
                                        return dt;";

            return TheBodyOfMethod;
        }



        static public string WriteAddNewRecordMethod(string tableName, strConnectionInfo connectionInfo)
        {
            List<strColumnsInfo> columnsInfo = GetAllColumnsInfo(connectionInfo.dbName, tableName);
            string name = char.ToUpper(tableName[0]) + tableName.Substring(1);
            string FunctionParameters = GetParamatersFunction(columnsInfo);
            string headerOfFunction = $"public static int? AddNew{name} ({FunctionParameters})";
            string bodyOfFunction = WriteBodyOfNewRecordMethod(tableName, connectionInfo);

            string function = headerOfFunction + "\n{" + bodyOfFunction + "\n}";
            return function;
        }
        static public string WriteUpdateRecordMethod(string tableName, strConnectionInfo connectionInfo)
        {
            List<strColumnsInfo> columnsInfo = GetAllColumnsInfo(connectionInfo.dbName, tableName);
            string name = char.ToUpper(tableName[0]) + tableName.Substring(1);
            string FunctionParameters = GetParamatersFunction(columnsInfo,true);
            string headerOfFunction = $"public static bool Update{name}InfoByID ({FunctionParameters})";
            string bodyOfFunction = WriteBodyOfUpdateRecordMethod(tableName, connectionInfo);

            string function = headerOfFunction + "\n{" + bodyOfFunction + "\n}";
            return function;
        }
        static public string WriteSelectRecordMethod(string tableName, strConnectionInfo connectionInfo)
        {
            List<strColumnsInfo> columnsInfo = GetAllColumnsInfo(connectionInfo.dbName, tableName);

            string name = char.ToUpper(tableName[0]) + tableName.Substring(1);
            
            string FunctionParameters = GetReferParamtersFunction(columnsInfo);
            string headerOfFunction = $"public static bool Get{name}InfoByID ({FunctionParameters})";
            string bodyOfFunction = WriteBodyOfGetInfoRecordMethod(tableName, connectionInfo);

            string function = headerOfFunction + "\n{" + bodyOfFunction + "\n}";
            return function;
        }
        static public string WriteDeleteRecordMethod(string tableName, strConnectionInfo connectionInfo)
        {
            List<strColumnsInfo> columnsInfo = GetAllColumnsInfo(connectionInfo.dbName, tableName);

            string name = char.ToUpper(tableName[0]) + tableName.Substring(1);

            string FunctionParameters = GetIDentityParametersName(columnsInfo,true).ToLower();
            string headerOfFunction = $"public static bool Delete{name}ByID ({FunctionParameters})";
            string bodyOfFunction = WriteBodyOfDeleteRecordMethod(tableName, connectionInfo);

            string function = headerOfFunction + "\n{" + bodyOfFunction + "\n}";
            return function;
        }
        static public string WriteGetAllRecordMethod(string tableName, strConnectionInfo connectionInfo)
        {
            List<strColumnsInfo> columnsInfo = GetAllColumnsInfo(connectionInfo.dbName, tableName);

            string name = char.ToUpper(tableName[0]) + tableName.Substring(1);

            string headerOfFunction = $"public static DataTable GetAll{name} ()";
            string bodyOfFunction = WriteBodyOfSelectAllRecordsMethod(tableName, connectionInfo);

            string function = headerOfFunction + "\n{" + bodyOfFunction + "\n}";
            return function;
        }

    }
}
