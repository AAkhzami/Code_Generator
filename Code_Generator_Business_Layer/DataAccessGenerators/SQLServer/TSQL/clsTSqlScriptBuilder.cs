using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer
{
    public class clsTSqlScriptBuilder
    {
        string _TableName;
        string _Database;
        clsColumnModelBuilder _ColumnsInfo;
        List<clsColumnModelBuilder.strColumnInfo> _ColumnsList;

        public clsTSqlScriptBuilder(string Database,string Table)
        {
            _TableName = Table;
            _Database = Database;

            _ColumnsInfo = new clsColumnModelBuilder(_Database, _TableName);
            _ColumnsList = _ColumnsInfo.GetAllColumnsInfo();
        }
        public string GenerateGetAllRecordsScript()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Create Procedure SP_GetAllRecordsFrom{_TableName}");
            sb.AppendLine("as");
            sb.AppendLine("begin");
            sb.AppendLine("\tSET NOCOUNT ON;");
            sb.AppendLine($"\tselect * from {_TableName};");
            sb.AppendLine("end");

            return sb.ToString();
        }
        public string GenerateGetRecordByPrimaryKeyScript()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Create Procedure SP_GetOneRecordFrom{_TableName}");

            sb.AppendLine(clsHelper.FormatingProperties(
                _ColumnsList.Where(c => c.IsPrimaryKey == true).Select(c => $"@{c.ColumnName} {c.ColumnSqlType}").ToList()));
            sb.AppendLine("as");
            sb.AppendLine("begin");
            sb.AppendLine("\tSET NOCOUNT ON;");
            sb.AppendLine($"\tselect * from [{_TableName}]");
            sb.AppendLine("\twhere");
            sb.AppendLine("\t" + string.Join(" and ",_ColumnsList.Where(c => c.IsPrimaryKey == true).Select(c => $"[{c.ColumnName}] = @{c.ColumnName}").ToList()));
            sb.AppendLine("end");

            return sb.ToString();
        }
        public string GenerateDeleteRecordByPrimaryKeyScript()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Create Procedure SP_DeleteOneRecordOn{_TableName}");
            sb.AppendLine(clsHelper.FormatingProperties(
                _ColumnsList.Where(c => c.IsPrimaryKey == true).Select(c => $"@{c.ColumnName} {c.ColumnSqlType}").ToList()));
            sb.AppendLine("as");
            sb.AppendLine("begin");
            sb.AppendLine("\tSET NOCOUNT ON;");
            sb.AppendLine($"\tDelete [{_TableName}]");
            sb.AppendLine("\twhere");
            sb.AppendLine("\t" + string.Join(" and ", _ColumnsList.Where(c => c.IsPrimaryKey == true).Select(c => $"[{c.ColumnName}] = @{c.ColumnName}").ToList()));
            sb.AppendLine("\tSelect @@ROWCOUNT as RowAffected;");
            sb.AppendLine("end");

            return sb.ToString();
        }
        public string GenerateAddNewRecord()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"create procedure SP_AddNewRecordOn{_TableName}");

            List<string> ListParameters = new List<string>();
            _ColumnsList.Where(c => !(c.IsPrimaryKey || c.IsIdentity)).Select(c => $"@{c.ColumnName} {clsColumnModelBuilder.GetFullSqlType(c)}").ToList().ForEach(c => ListParameters.Add(c));
            _ColumnsList.Where(c => (c.IsPrimaryKey || c.IsIdentity)).Select(c => $"@{c.ColumnName} {clsColumnModelBuilder.GetFullSqlType(c)} OUTPUT").ToList().ForEach(c => ListParameters.Add(c));

            sb.AppendLine( string.Join(",\n", ListParameters));
            sb.AppendLine("as");
            sb.AppendLine("begin");
            sb.AppendLine("\tSET NOCOUNT ON;");

            sb.AppendLine("\tDeclare @OutputTable Table");
            sb.AppendLine($"\t({string.Join(", ", _ColumnsList.Where(c => c.IsPrimaryKey || c.IsIdentity).Select(c => $"{c.ColumnName} {clsColumnModelBuilder.GetFullSqlType(c)}").ToList())});");

            sb.AppendLine($"\tInsert into [{_TableName}]");
            sb.AppendLine($"\t({string.Join(",", _ColumnsList.Where(c => !(c.IsPrimaryKey || c.IsIdentity)).Select(c => c.ColumnName))})");
            
            sb.Append($"\tOUTPUT ");
            sb.Append($"{string.Join(", ", _ColumnsList.Where(c => c.IsPrimaryKey || c.IsIdentity).Select(c => $"inserted.{c.ColumnName}").ToList())}");
            sb.AppendLine(" into @OutputTable");
            
            sb.AppendLine("\tValues");
            sb.AppendLine($"\t({string.Join(",", _ColumnsList.Where(c => !(c.IsPrimaryKey || c.IsIdentity)).Select(c => "@" + c.ColumnName))})");

            sb.AppendLine("\tSelect");
            sb.AppendLine(string.Join(",\n", _ColumnsList.Where(c => c.IsPrimaryKey || c.IsIdentity).Select(c => $"\t@{c.ColumnName} = [{c.ColumnName}]").ToList()));
            sb.AppendLine("\tfrom @OutputTable;");

            sb.AppendLine("end");
            return sb.ToString();
        }
    }
}
