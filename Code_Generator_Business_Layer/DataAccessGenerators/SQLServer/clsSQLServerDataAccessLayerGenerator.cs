using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Code_Generator_Business_Layer.clsGlobal;

namespace Code_Generator_Business_Layer.DataAccessGenerators
{
    internal class clsSQLServerDataAccessLayerGenerator : iDataAccessGenerator
    {
        string _tableName = "";
        string _databaseName = "";
        clsColumnModelBuilder _Columns;
        
        public clsSQLServerDataAccessLayerGenerator(string Database, string Table)
        {
            _databaseName = Database;
            _tableName = Table;
            _Columns = new clsColumnModelBuilder(_databaseName, _tableName);
        }

        // Queries
        private string GenerateInsertQuery()
        {
            var columns = _Columns.GetAllColumnsInfo().Where(n => !n.IsIdentity && !n.IsPrimaryKey).ToList();
            StringBuilder query = new StringBuilder();
            query.AppendLine($"Insert into {_tableName}");
            query.AppendLine($"({clsHelper.FormatingProperties(columns.ToList().Select(n => n.ColumnName).ToList(),", ")})");
            query.AppendLine($"Values ({clsHelper.FormatingProperties(columns.ToList().ToList().Select(n => "@" + n.ColumnName).ToList(), ", ")})");
            query.AppendLine("select SCOPE_IDENTITY();");

            return query.ToString();
        }


        public string GenerateCreateMethod()
        {
            var columns = _Columns.GetAllColumnsInfo().Where(n => !n.IsIdentity && !n.IsPrimaryKey).ToList();
            StringBuilder method = new StringBuilder();
            method.Append($"public static {clsHelper.FormatNullableType(_Columns.PrimaryKey.ColumnType,true)} AddNew{_tableName}");
            method.AppendLine($"({clsHelper.FormatingProperties(columns.ToList().Select(c => clsHelper.SafeParamName(c.ColumnName)).ToList(),", ")})");
            method.AppendLine("{");





            method.AppendLine($"\t{clsHelper.FormatNullableType(_Columns.PrimaryKey.ColumnType,true)} result = null;");
            method.AppendLine($"\tstring query = \"{GenerateInsertQuery()}\";");
            method.AppendLine($"\tusing (SqlConnection connection = new SqlConnection(clsGlobal.ConnectionString))");
            method.AppendLine($"\tusing (SqlCommand command = new SqlCommand(query, connection))");
            method.AppendLine("\t{");


            columns.ForEach(c => method.AppendLine($"\t\tcommand.Parameters.AddWithValue(@{c.ColumnName}, {clsHelper.SafeParamName(c.ColumnName)});"));
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
            method.AppendLine("\t\t\tthrow;");
            method.AppendLine("\t\t}");
            method.AppendLine("\t}");
            method.AppendLine("\treturn result;");     
            method.AppendLine("}");
            return method.ToString();
        }
        public string GenerateReadMethod()
        {
            return "Read Method";
        }
        public string GenerateUpdateMethod()
        {
            return "Update Method";
        }
        public string GenerateDeleteMethod()
        {
            return "Delete Method";
        }
    }
}
