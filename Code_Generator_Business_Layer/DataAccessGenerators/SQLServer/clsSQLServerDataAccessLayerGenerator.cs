using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Code_Generator_Business_Layer.clsGlobal;

namespace Code_Generator_Business_Layer.DataAccessGenerators
{
    public class clsSQLServerDataAccessLayerGenerator : iDataAccessGenerator
    {
        string _tableName = "";
        string _databaseName = "";
        clsColumnModelBuilder _Columns;
        clsConnectionGenerator _connection;
        public clsSQLServerDataAccessLayerGenerator(string Database, string Table, clsConnectionGenerator connectionType)
        {
            _databaseName = Database;
            _tableName = Table;
            _Columns = new clsColumnModelBuilder(_databaseName, _tableName);
            _connection = connectionType;
        }

        // Queries
        private string GenerateInsertQuery()
        {
            var columns = _Columns.GetAllColumnsInfo().Where(n => !n.IsIdentity && !n.IsPrimaryKey).ToList();
            StringBuilder query = new StringBuilder();
            query.AppendLine($"Insert into {_tableName}");
            query.AppendLine($"({clsHelper.FormatingProperties(columns.ToList().Select(n => n.ColumnName).ToList())})");
            query.AppendLine($"Values ({clsHelper.FormatingProperties(columns.ToList().ToList().Select(n => "@" + n.ColumnName).ToList())})");
            query.AppendLine("select SCOPE_IDENTITY();");

            return query.ToString();
        }
        private string GenerateSelectQuery()
        {
            var columns = _Columns.GetAllColumnsInfo().ToList();
            StringBuilder query = new StringBuilder();
            query.AppendLine($"Select {clsHelper.FormatingProperties(columns.ToList().Select(n => n.ColumnName).ToList())}");
            query.AppendLine($"from {_tableName}");
            query.AppendLine($"where {_Columns.PrimaryKey.ColumnName} = @{_Columns.PrimaryKey.ColumnName};");
            return query.ToString();
        }
        private string GenerateUpdateQuery()
        {
            var columns = _Columns.GetAllColumnsInfo().Where(n => !n.IsIdentity && !n.IsPrimaryKey).ToList();
            StringBuilder query = new StringBuilder();
            query.AppendLine($"Update {_tableName}");
            query.AppendLine($"set {clsHelper.FormatingProperties(columns.ToList().Where(n => !n.IsIdentity || !n.IsPrimaryKey).Select(n => $"{n.ColumnName} = @{n.ColumnName}").ToList())}");
            query.AppendLine($"where {_Columns.PrimaryKey.ColumnName} = @{_Columns.PrimaryKey.ColumnName};");
            return query.ToString();
        }
        private string GenerateDeleteQuery()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"Delete from {_tableName}");
            query.AppendLine($"where {_Columns.PrimaryKey.ColumnName} = @{_Columns.PrimaryKey.ColumnName};");
            return query.ToString();
        }
        private string GenerateSelectAllQuery()
        {
            StringBuilder query = new StringBuilder();
            query.AppendLine($"Select * from {_tableName};");
            return query.ToString();
        }

        // Methods
        public string GenerateCreateMethod()
        {
            var columns = _Columns.GetAllColumnsInfo().Where(n => !n.IsIdentity && !n.IsPrimaryKey).ToList();
            StringBuilder method = new StringBuilder();
            method.Append($"public static {clsHelper.FormatNullableType(_Columns.PrimaryKey.ColumnType,true)} AddNew{_tableName}");
            method.AppendLine($"({clsHelper.FormatingProperties(columns.ToList().Select(c => $"{clsHelper.FormatNullableType(c.ColumnType,c.IsNullable)} {clsHelper.SafeParamName(c.ColumnName)}").ToList())})");
            method.AppendLine("{");
            method.AppendLine($"\t{clsHelper.FormatNullableType(_Columns.PrimaryKey.ColumnType,true)} result = null;");
            method.AppendLine($"\tstring query = @\"{GenerateInsertQuery()}\";");
            method.AppendLine($"\tusing (SqlConnection connection = new SqlConnection({_connection.GenerateConnectionString()}))");
            method.AppendLine($"\tusing (SqlCommand command = new SqlCommand(query, connection))");
            method.AppendLine("\t{");
            columns.ForEach(c => method.AppendLine($"\t\tcommand.Parameters.AddWithValue(\"@{c.ColumnName}\", {clsHelper.SafeParamName(c.ColumnName)});"));
            method.AppendLine($"\t\ttry");
            method.AppendLine("\t\t{");
            method.AppendLine($"\t\t\tconnection.Open();");
            method.AppendLine($"\t\t\tobject scalarResult = command.ExecuteScalar();");
            method.AppendLine($"\t\t\tif (scalarResult != null && {_Columns.PrimaryKey.ColumnType}.TryParse(scalarResult.ToString(), out {_Columns.PrimaryKey.ColumnType} newRecord))");
            method.AppendLine("\t\t\t\t{");
            method.AppendLine($"\t\t\t\t\tresult = newRecord;");
            method.AppendLine("\t\t\t\t}");
            method.AppendLine("\t\t}");
            method.AppendLine("\t\tcatch (Exception ex)");
            method.AppendLine("\t\t{");
            method.AppendLine("\t\t\t// Handle exception");
            method.AppendLine("\t\t}");
            method.AppendLine("\t}");
            method.AppendLine("\treturn result;");     
            method.AppendLine("}");
            return method.ToString();
        }
        public string GenerateReadMethod()
        {
            var columns = _Columns.GetAllColumnsInfo().ToList();
            StringBuilder method = new StringBuilder();
            method.Append($"public static bool Get{_tableName}By{_Columns.PrimaryKey.ColumnName}");
            method.Append("(");
            var parameters = columns.Select(c => $"{clsHelper.FormatNullableType(c.ColumnType, c.IsNullable)} {clsHelper.SafeParamName(c.ColumnName)}");
            method.Append(clsHelper.FormatingProperties(parameters.ToList(),"ref ",1));
            method.AppendLine(")");
            method.AppendLine("{");
            method.AppendLine($"\tbool isFound = false;");
            method.AppendLine($"\tstring query = @\"{GenerateSelectQuery()}\";");
            method.AppendLine($"\tusing (SqlConnection connection = new SqlConnection({_connection.GenerateConnectionString()}))");
            method.AppendLine($"\tusing (SqlCommand command = new SqlCommand(query, connection))");
            method.AppendLine("\t{");
            method.AppendLine($"\t\tcommand.Parameters.AddWithValue(\"@{_Columns.PrimaryKey.ColumnName}\", {clsHelper.SafeParamName(_Columns.PrimaryKey.ColumnName)});");
            method.AppendLine($"\t\ttry");
            method.AppendLine("\t\t{");
            method.AppendLine($"\t\t\tconnection.Open();");
            method.AppendLine($"\t\t\tusing (SqlDataReader reader = command.ExecuteReader())");
            method.AppendLine("\t\t\t{");
            method.AppendLine("\t\t\t\tif (reader.Read())");
            method.AppendLine("\t\t\t\t{");
            method.AppendLine($"\t\t\t\t\tisFound = true;");
            columns.Skip(1).ToList().ForEach(c => method.AppendLine($"\t\t\t\t\t{clsHelper.SafeParamName(c.ColumnName)} = reader[\"{c.ColumnName}\"] != DBNull.Value ? ({clsHelper.FormatNullableType(c.ColumnType,c.IsNullable)})reader[\"{c.ColumnName}\"] : null;"));
            method.AppendLine("\t\t\t\t}");
            method.AppendLine("\t\t\t}");
            method.AppendLine("\t\t}");
            method.AppendLine("\t\tcatch (Exception ex)");
            method.AppendLine("\t\t{");
            method.AppendLine("\t\t\tisFound = false;");
            method.AppendLine("\t\t\t// Handle exception");
            method.AppendLine("\t\t}");
            method.AppendLine("\t}");
            method.AppendLine("\treturn isFound;");     
            method.AppendLine("}");
            
            return method.ToString();
        }
        public string GenerateUpdateMethod()
        {
            StringBuilder method = new StringBuilder();
            var columns = _Columns.GetAllColumnsInfo().ToList();
            method.Append($"public static bool Update{_tableName}By{_Columns.PrimaryKey.ColumnName}");
            method.Append("(");
            method.Append(clsHelper.FormatingProperties(columns.ToList().Select(c => $"{clsHelper.FormatNullableType(c.ColumnType, true)} {clsHelper.SafeParamName(c.ColumnName)}").ToList()));
            method.AppendLine(")");
            method.AppendLine("{");
            method.AppendLine($"\tbool isUpdated = false;");
            method.AppendLine($"\tstring query = @\"{GenerateUpdateQuery()}\";");
            method.AppendLine($"\tusing (SqlConnection connection = new SqlConnection({_connection.GenerateConnectionString()}))");
            method.AppendLine($"\tusing (SqlCommand command = new SqlCommand(query, connection))");
            method.AppendLine("\t{");
            columns.ForEach(c => method.AppendLine($"\t\tcommand.Parameters.AddWithValue(\"@{c.ColumnName}\", {clsHelper.SafeParamName(c.ColumnName)});"));
            method.AppendLine($"\t\ttry");
            method.AppendLine("\t\t{");
            method.AppendLine($"\t\t\tconnection.Open();");
            method.AppendLine($"\t\t\tint rowsAffected = command.ExecuteNonQuery();");
            method.AppendLine($"\t\t\tisUpdated = rowsAffected > 0;");
            method.AppendLine("\t\t}");
            method.AppendLine("\t\tcatch (Exception ex)");
            method.AppendLine("\t\t{");
            method.AppendLine("\t\t\tisUpdated = false;");
            method.AppendLine("\t\t\t// Handle exception");
            method.AppendLine("\t\t}");
            method.AppendLine("\t}");
            method.AppendLine("\treturn isUpdated;");
            method.AppendLine("}");
            return method.ToString();

        }
        public string GenerateDeleteMethod()
        {
            StringBuilder method = new StringBuilder();
            method.Append($"public static bool Delete{_tableName}By{_Columns.PrimaryKey.ColumnName}");
            method.Append($"({clsHelper.FormatNullableType(_Columns.PrimaryKey.ColumnType,true)} {clsHelper.SafeParamName(_Columns.PrimaryKey.ColumnName)})");
            method.AppendLine("{");
            method.AppendLine($"\tbool isDeleted = false;");
            method.AppendLine($"\tstring query = @\"{GenerateDeleteQuery()}\";");
            method.AppendLine($"\tusing (SqlConnection connection = new SqlConnection({_connection.GenerateConnectionString()}))");
            method.AppendLine($"\tusing (SqlCommand command = new SqlCommand(query, connection))");
            method.AppendLine("\t{");
            method.AppendLine("\t\tcommand.Parameters.AddWithValue(\"@" + _Columns.PrimaryKey.ColumnName + "\", " + clsHelper.SafeParamName(_Columns.PrimaryKey.ColumnName) + ");");
            method.AppendLine("\t\ttry");
            method.AppendLine("\t\t{");
            method.AppendLine("\t\t\tconnection.Open();");
            method.AppendLine("\t\t\tint rowsAffected = command.ExecuteNonQuery();");
            method.AppendLine("\t\t\tisDeleted = rowsAffected > 0;");
            method.AppendLine("\t\t}");
            method.AppendLine("\t\tcatch (Exception ex)");
            method.AppendLine("\t\t{");
            method.AppendLine("\t\t\tisDeleted = false;");
            method.AppendLine("\t\t\t// Handle exception");
            method.AppendLine("\t\t}");
            method.AppendLine("\t}");
            method.AppendLine("\treturn isDeleted;");
            method.AppendLine("}");
            return method.ToString();
        }
        public string GenerateReadAllRecordsMethod()
        {
            StringBuilder method = new StringBuilder();
            method.Append($"public static DataTable GetAll{_tableName}()");
            method.AppendLine("{");
            method.AppendLine($"\tDataTable dt = new DataTable();");
            method.AppendLine($"\tstring query = @\"{GenerateSelectAllQuery()}\";");
            method.AppendLine($"\tusing (SqlConnection connection = new SqlConnection({_connection.GenerateConnectionString()}))");
            method.AppendLine($"\tusing (SqlCommand command = new SqlCommand(query, connection))");
            method.AppendLine("\t{");
            method.AppendLine("\t\ttry");
            method.AppendLine("\t\t{");
            method.AppendLine("\t\t\tconnection.Open();");
            method.AppendLine("\t\t\tusing (SqlDataReader reader = command.ExecuteReader())");
            method.AppendLine("\t\t\t{");
            method.AppendLine("\t\t\t\tif(reader.HasRows)");
            method.AppendLine("\t\t\t\t{");
            method.AppendLine("\t\t\t\t\tdt.Load(reader);");
            method.AppendLine("\t\t\t\t}");
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
    
        public string GenerateDataAccessLayer()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("public class cls" + _tableName + "Data");
            sb.AppendLine("{");
            sb.AppendLine(GenerateCreateMethod());
            sb.AppendLine(GenerateReadMethod());
            sb.AppendLine(GenerateUpdateMethod());
            sb.AppendLine(GenerateDeleteMethod());
            sb.AppendLine(GenerateReadAllRecordsMethod());
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
