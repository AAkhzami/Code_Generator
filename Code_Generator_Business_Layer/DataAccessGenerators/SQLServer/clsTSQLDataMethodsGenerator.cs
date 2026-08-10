using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer.DataAccessGenerators.SQLServer
{
    public class clsTSQLDataMethodsGenerator : iDataAccessGenerator
    {
        string _DatabaseName;
        string _TableName;
        clsColumnModelBuilder _Columns;
        clsConnectionGenerator _Connection;
        
        public clsTSQLDataMethodsGenerator(string Database, string Table, clsConnectionGenerator connectionInfo)
        {
            this._DatabaseName = Database;
            this._TableName = Table;
            this._Columns = new clsColumnModelBuilder(_DatabaseName, _TableName);
            this._Connection = connectionInfo;
        }
        public string GenerateCreateMethod()
        {
            var columnsWithOutPrimaryKey = _Columns.GetAllColumnsInfo().Where(n => !n.IsIdentity && !n.IsPrimaryKey).ToList();
            var columnsWithPrimaryKeys = _Columns.GetAllColumnsInfo().Where(n => n.IsPrimaryKey).ToList();

            StringBuilder method = new StringBuilder();
            method.Append($"public static bool AddNewRecordeOn{_TableName}");


            List<string> functionsParameters = new List<string>();

            columnsWithPrimaryKeys.Select(c => $"ref {clsHelper.FormatNullableType(c.ColumnType, c.IsNullable)} {clsHelper.SafeParamName(c.ColumnName)}").ToList().ForEach(
                c => functionsParameters.Add(c));
            columnsWithOutPrimaryKey.Select(c => $"{clsHelper.FormatNullableType(c.ColumnType, c.IsNullable)} {clsHelper.SafeParamName(c.ColumnName)}").ToList().ForEach(
                c => functionsParameters.Add(c));

            method.AppendLine($"({string.Join(", ", functionsParameters)})");

            method.AppendLine("{");
            method.AppendLine($"\tusing (SqlConnection connection = new SqlConnection({_Connection.GenerateConnectionString()}))");
            method.AppendLine($"\tusing (SqlCommand command = new SqlCommand(\"SP_AddNewRecordOn{_TableName}\", connection))");
            method.AppendLine("\t{");
            method.AppendLine("\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
            columnsWithOutPrimaryKey.ForEach(c => method.AppendLine($"\t\tcommand.Parameters.AddWithValue(\"@{c.ColumnName}\", {clsHelper.SafeParamName(c.ColumnName)});"));


            int count = 1;
            columnsWithPrimaryKeys.ForEach(
                c =>
                {                    
                    method.AppendLine($"\t\tSqlParameter outPutParam{count} = new SqlParameter(\"@{c.ColumnName}\", System.Data.SqlDbType.{clsColumnModelBuilder.GetPropertyForDataSqlDbType(c.ColumnType)})");
                    method.AppendLine("\t\t{");
                    method.AppendLine($"\t\t\tDirection = System.Data.ParameterDirection.Output");
                    method.AppendLine("\t\t};");
                    method.AppendLine($"\t\tcommand.Parameters.Add(outPutParam{count});");
                    count++;
                });

            
            method.AppendLine($"\t\ttry");
            method.AppendLine("\t\t{");
            method.AppendLine($"\t\t\tconnection.Open();");
            method.AppendLine($"\t\t\tcommand.ExecuteNonQuery();");

            columnsWithPrimaryKeys.ForEach(
                c =>
                {
                    method.AppendLine($"\t\t\tvar val{clsHelper.SafeParamName(c.ColumnName)} = ({clsHelper.FormatNullableType(c.ColumnType, true)})command.Parameters[\"@{c.ColumnName}\"].Value;");
                    method.AppendLine($"\t\t\t{clsHelper.SafeParamName(c.ColumnName)} = (val{clsHelper.SafeParamName(c.ColumnName)} != null) ? ({c.ColumnType})val{clsHelper.SafeParamName(c.ColumnName)} : default({c.ColumnType});");
                });

            method.AppendLine("\t\t\treturn true;");
            method.AppendLine("\t\t}");
            method.AppendLine("\t\tcatch (Exception ex)");
            method.AppendLine("\t\t{");
            method.AppendLine("\t\t\t// Handle exception");
            method.AppendLine("\t\t}");
            method.AppendLine("\t}");
            method.AppendLine($"\treturn false;");
            method.AppendLine("}");
            return method.ToString();
        }
        public string GenerateUpdateMethod()
        {
            var parameters = _Columns.GetAllColumnsInfo();
            StringBuilder method = new StringBuilder();
            method.Append($"public static bool UpdateRecordFrom{_TableName}");

            method.AppendLine($"({string.Join(", ", parameters.Select(c => $"{clsHelper.FormatNullableType(c.ColumnType,c.IsNullable)} {clsHelper.SafeParamName(c.ColumnName)}"))})");

            method.AppendLine("{");
            method.AppendLine($"\tusing (SqlConnection connection = new SqlConnection({_Connection.GenerateConnectionString()}))");
            method.AppendLine($"\tusing (SqlCommand command = new SqlCommand(\"SP_UpdateRcordeOn{_TableName}\", connection))");
            method.AppendLine("\t{");
            method.AppendLine("\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");


            parameters.ForEach(c => method.AppendLine($"\t\tcommand.Parameters.AddWithValue(\"@{c.ColumnName}\", {clsHelper.SafeParamName(c.ColumnName)});"));

            method.AppendLine($"\t\ttry");
            method.AppendLine("\t\t{");
            method.AppendLine($"\t\t\tconnection.Open();");
            method.AppendLine($"\t\t\tcommand.ExecuteNonQuery();");
            method.AppendLine("\t\t\treturn true;");
            method.AppendLine("\t\t}");
            method.AppendLine("\t\tcatch (Exception ex)");
            method.AppendLine("\t\t{");
            method.AppendLine("\t\t\t// Handle exception");
            method.AppendLine("\t\t\treturn false;");
            method.AppendLine("\t\t}");
            method.AppendLine("\t}");
            method.AppendLine("}");
            return method.ToString();
        }
        public string GenerateDeleteMethod()
        {
            var parameters = _Columns.GetAllColumnsInfo().Where(n => n.IsIdentity && n.IsPrimaryKey).ToList();
            StringBuilder method = new StringBuilder();
            method.Append($"public static bool DeleteRecordFrom{_TableName}");

            method.AppendLine($"({string.Join(", ", parameters.Select(c => $"{clsHelper.FormatNullableType(c.ColumnType, c.IsNullable)} {clsHelper.SafeParamName(c.ColumnName)}"))})");

            method.AppendLine("{");
            method.AppendLine($"\tusing (SqlConnection connection = new SqlConnection({_Connection.GenerateConnectionString()}))");
            method.AppendLine($"\tusing (SqlCommand command = new SqlCommand(\"SP_DeleteOneRecordOn{_TableName}\", connection))");
            method.AppendLine("\t{");
            method.AppendLine("\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");


            parameters.ForEach(c => method.AppendLine($"\t\tcommand.Parameters.AddWithValue(\"@{c.ColumnName}\", {clsHelper.SafeParamName(c.ColumnName)});"));

            method.AppendLine($"\t\ttry");
            method.AppendLine("\t\t{");
            method.AppendLine($"\t\t\tconnection.Open();");
            method.AppendLine($"\t\t\tint rowAffected = (int)command.ExecuteScalar();");
            method.AppendLine("\t\t\treturn rowAffected > 0;");
            method.AppendLine("\t\t}");
            method.AppendLine("\t\tcatch (Exception ex)");
            method.AppendLine("\t\t{");
            method.AppendLine("\t\t\t// Handle exception");
            method.AppendLine("\t\t\treturn false;");
            method.AppendLine("\t\t}");
            method.AppendLine("\t}");
            method.AppendLine("}");
            return method.ToString();
        }
        public string GenerateReadMethod()
        {
            var columnsWithOutPrimaryKey = _Columns.GetAllColumnsInfo().Where(n => !n.IsIdentity && !n.IsPrimaryKey).ToList();
            var columnsWithPrimaryKeys = _Columns.GetAllColumnsInfo().Where(n => n.IsPrimaryKey).ToList();

            StringBuilder method = new StringBuilder();
            method.Append($"public static bool GetOnRecordFrom{_TableName}");

            List<string> functionsParameters = new List<string>();

            columnsWithPrimaryKeys.Select(c => $"{clsHelper.FormatNullableType(c.ColumnType, c.IsNullable)} {clsHelper.SafeParamName(c.ColumnName)}").ToList().ForEach(
                c => functionsParameters.Add(c));
            columnsWithOutPrimaryKey.Select(c => $"ref {clsHelper.FormatNullableType(c.ColumnType, c.IsNullable)} {clsHelper.SafeParamName(c.ColumnName)}").ToList().ForEach(
                c => functionsParameters.Add(c));

            method.AppendLine($"({string.Join(", ", functionsParameters)})");


            method.AppendLine("{");

            method.AppendLine("\tbool isFound = false;");

            method.AppendLine($"\tusing (SqlConnection connection = new SqlConnection({_Connection.GenerateConnectionString()}))");
            method.AppendLine($"\tusing (SqlCommand command = new SqlCommand(\"SP_GetOneRecordFrom{_TableName}\", connection))");
            method.AppendLine("\t{");
            method.AppendLine("\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");

            columnsWithPrimaryKeys.ForEach(c => method.AppendLine($"\t\tcommand.Parameters.AddWithValue(\"@{c.ColumnName}\", {clsHelper.SafeParamName(c.ColumnName)});"));

            method.AppendLine($"\t\ttry");
            method.AppendLine("\t\t{");
            method.AppendLine($"\t\t\tconnection.Open();");
            method.AppendLine($"\t\t\tusing (SqlDataReader reader = command.ExecuteReader())");
            method.AppendLine("\t\t\t{");
            method.AppendLine("\t\t\t\tif(reader.Read())");
            method.AppendLine("\t\t\t\t{");
            columnsWithOutPrimaryKey.ForEach(
                c =>
                {
                    method.AppendLine($"\t\t\t\t\tif (reader[\"{c.ColumnName}\"] != DBNull.Value)");
                    method.AppendLine("\t\t\t\t\t{");
                    method.AppendLine($"\t\t\t\t\t\t{clsHelper.SafeParamName(c.ColumnName)} = ({c.ColumnType})reader[\"{c.ColumnName}\"];");
                    method.AppendLine("\t\t\t\t\t}");
                    if(c.IsNullable)
                    {
                        method.AppendLine($"\t\t\t\t\telse");
                        method.AppendLine("\t\t\t\t\t{");
                        method.AppendLine($"\t\t\t\t\t\t{clsHelper.SafeParamName(c.ColumnName)} = null;");
                        method.AppendLine("\t\t\t\t\t}");
                    }

                });
            method.AppendLine("\t\t\t\t\tisFound = true;");
            method.AppendLine("\t\t\t\t}");
            method.AppendLine("\t\t\t}");

            method.AppendLine("\t\t\treturn true;");
            method.AppendLine("\t\t}");
            method.AppendLine("\t\tcatch (Exception ex)");
            method.AppendLine("\t\t{");
            method.AppendLine("\t\t\t// Handle exception");
            method.AppendLine("\t\t\tisFound = false;");
            method.AppendLine("\t\t}");
            method.AppendLine("\t}");
            method.AppendLine($"\treturn isFound;");
            method.AppendLine("}");
            return method.ToString();
        }
        public string GenerateReadAllRecordsMethod()
        {
            StringBuilder method = new StringBuilder();
            method.Append($"public static DataTable GetAll{_TableName}()");

            
            method.AppendLine("{");
            method.AppendLine("\tDataTable dt = new DataTable();");
            method.AppendLine($"\tusing (SqlConnection connection = new SqlConnection({_Connection.GenerateConnectionString()}))");
            method.AppendLine($"\tusing (SqlCommand command = new SqlCommand(\"SP_GetAllRecordsFrom{_TableName}\", connection))");
            method.AppendLine("\t{");
            method.AppendLine("\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
            method.AppendLine($"\t\ttry");
            method.AppendLine("\t\t{");
            method.AppendLine($"\t\t\tconnection.Open();");
            method.AppendLine("\t\t\tusing (SqlDataReader reader = command.ExecuteReader())");
            method.AppendLine("\t\t\t{");
            method.AppendLine("\t\t\t\tdt.Load(reader);");
            method.AppendLine("\t\t\t}");
            method.AppendLine("\t\t}");
            method.AppendLine("\t\tcatch (Exception ex)");
            method.AppendLine("\t\t{");
            method.AppendLine("\t\t\t// Handle exception");
            method.AppendLine("\t\t}");
            method.AppendLine("\t}");
            method.AppendLine("\treturn dt;");
            method.AppendLine("}");
            return method.ToString();
        }
        public string GenerateDataAccessLayerClass()
        {
            return "";
        }
    }
}
