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
            var columnsWithOutPrimaryKey = _Columns.GetAllColumnsInfo().Where(n => !n.IsIdentity || !n.IsPrimaryKey).ToList();
            var columnsWithPrimaryKeys = _Columns.GetAllColumnsInfo().Where(n => n.IsPrimaryKey).ToList();

            StringBuilder method = new StringBuilder();
            method.Append($"public static {clsHelper.FormatNullableType(_Columns.PrimaryKey.ColumnType, true)} AddNewRecordeOn{_TableName}");
            method.AppendLine($"({clsHelper.FormatingProperties(columnsWithOutPrimaryKey.ToList().Select(c => $"{clsHelper.FormatNullableType(c.ColumnType, c.IsNullable)} {clsHelper.SafeParamName(c.ColumnName)}").ToList())})");
            method.AppendLine("{");
            method.AppendLine($"\t{clsHelper.FormatNullableType(_Columns.PrimaryKey.ColumnType, true)} result = null;");
            method.AppendLine($"\tusing (SqlConnection connection = new SqlConnection({_Connection.GenerateConnectionString()}))");
            method.AppendLine($"\tusing (SqlCommand command = new SqlCommand(\"SP_AddNewRecordOn{_TableName}\", connection))");
            method.AppendLine("\t{");
            method.AppendLine("\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
            columnsWithOutPrimaryKey.ForEach(c => method.AppendLine($"\t\tcommand.Parameters.AddWithValue(\"@{c.ColumnName}\", {clsHelper.SafeParamName(c.ColumnName)});"));


            int count = 1;
            columnsWithPrimaryKeys.ForEach(
                c =>
                {                    
                    method.AppendLine($"\t\tSqlParameter outPutParam{count} = new SqlParameter(\"@{c.ColumnName}\", System.Data.SqlDbType.)");
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
                    method.AppendLine($"\t\t\t{clsHelper.FormatNullableType(c.ColumnType,c.IsNullable)} new{c.ColumnName} = ({c.ColumnType})command.Parameters[\"@{c.ColumnName}\"].Value;");
                    method.AppendLine($"{clsHelper.GetParamValue(c.ColumnSqlType)}");
                });

            
            method.AppendLine("\t\tcatch (Exception ex)");
            method.AppendLine("\t\t{");
            method.AppendLine("\t\t\t// Handle exception");
            method.AppendLine("\t\t}");
            method.AppendLine("\t}");
            method.AppendLine($"\treturn new{_Columns.PrimaryKey.ColumnName};");
            method.AppendLine("}");
            return method.ToString();
        }
        public string GenerateUpdateMethod()
        {
            return "";
        }
        public string GenerateDeleteMethod()
        {
            return "";
        }
        public string GenerateReadMethod()
        {
            return "";
        }
        public string GenerateReadAllRecordsMethod()
        {
            return "";
        }
        public string GenerateDataAccessLayerClass()
        {
            return "";
        }
    }
}
