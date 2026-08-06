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

            sb.AppendLine($"Create Procedure GetAll{_TableName}");
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

            sb.AppendLine($"Create Procedure GetBy{_ColumnsInfo.PrimaryKey.ColumnName}");

            sb.AppendLine(clsHelper.FormatingProperties(
                _ColumnsList.Where(c => c.IsPrimaryKey == true).Select(c => $"@{c.ColumnName} {c.ColumnSqlType}").ToList()));
            sb.AppendLine("as");
            sb.AppendLine("begin");
            sb.AppendLine("\tSET NOCOUNT ON;");
            sb.AppendLine($"select * from [{_TableName}]");
            sb.AppendLine("where");
            sb.AppendLine(string.Join(" and ",_ColumnsList.Where(c => c.IsPrimaryKey == true).Select(c => $"[{c.ColumnName}] = @{c.ColumnName}").ToList()));
            sb.AppendLine("end");

            return sb.ToString();
        }

    }
}
