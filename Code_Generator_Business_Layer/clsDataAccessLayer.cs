using Code_Generator_Data_Access_Layer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static Code_Generator_Data_Access_Layer.clsDatabaseInfo_Data;

namespace Code_Generator_Business_Layer
{
    public class clsDataAccessLayer : clsGlobal
    {

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

            StringBuilder sb = new StringBuilder();

            foreach (strColumnsInfo columnInfo in columnsInfo)
            {
                if (!columnInfo.IsIdentity)
                    sb.Append(GetParameterAddWithValuesString(columnInfo) + Environment.NewLine);
            }
            string TheBodyOfMethod = $@"
                                        int? recordId = null;
                                        string query = {query_text}
                                        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                                        {{
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
                                        }}
                                        return recordId;";

            return TheBodyOfMethod;
        }



        //Update Methods

        private static string WriteUpdateQuery(string DatabaseName, string TableName)
        {
            List<strColumnsInfo> columnsInfos = GetAllColumnsInfo(DatabaseName, TableName);

            List<string> SetParameters = new List<string>();
            foreach (strColumnsInfo column in columnsInfos)
            {
                if(!column.IsIdentity)
                    SetParameters.Add($"    {column.ColumnName} = @{column.ColumnName}");
            }
            string setClause = string.Join(",\n     ",SetParameters);

            List<strColumnsInfo> ConditionString = FilterColumnsInfo(columnsInfos, enFilterType.IdentityC);
            List<string> WhereConditions = new List<string>();
            foreach (strColumnsInfo idcolumn in ConditionString)
            {
                WhereConditions.Add($"{idcolumn.ColumnName} = @{idcolumn.ColumnName}");
            }
            string WhereConditionsClause = string.Join("    And     ", WhereConditions);
            
            string query = $"@\"UPDATE {TableName}\n        Set \n{setClause}\n        {WhereConditionsClause}\";";
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
                            string query = {query_text}

                            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                            {{
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
                string colName = parameter.ColumnName;
                string type = MapSqlTypeToCSharp(parameter.DataType);
                if (parameter.IsNullable)
                {
                    stringBuilder.AppendLine($@"if (reader[""{colName}""] != DBNull.Value)
                                                {colName.ToLower()} = ({type})reader[""{colName}""];
                                            else
                                                {colName.ToLower()} = {DefaultValue(type)};");
                }
                else
                    stringBuilder.AppendLine($"{colName.ToLower()} = ({type})reader[\"{colName}\"];");
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
                                string query = {query_text}

                                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                                {{
                                    SqlCommand command = new SqlCommand(query, connection);
                                    {AppendingValues}
                                    try
                                    {{
                                        connection.Open();
                                        using (SqlDataReader reader = command.ExecuteReader())
                                        {{
                                            if(reader.Read())
                                            {{
                                                isFound = true;
                                                {GettingInformationFormateString}
                                            }}
                                        }}
                                    }}
                                    catch (Exception ex)
                                    {{
                                        isFound = false;
                                    }}
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
                                string query = {query_text}

                                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                                {{
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
                            string query = {query_text}

                            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString))
                            {{
                                SqlCommand command = new SqlCommand(query, connection);
                                try
                                {{
                                    connection.Open();
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {{
                                        if (reader.HasRows)
                                        {{
                                            dt.Load(reader);
                                        }}
                                    }}
                                }}
                                catch (Exception ex)
                                {{ 
                                }}
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
