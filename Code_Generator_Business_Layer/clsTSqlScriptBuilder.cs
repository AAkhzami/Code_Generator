using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer
{
    public class clsTSqlScriptBuilder
    {
        //string _TableName;
        //string _DatabaseName;
        //List<clsGlobal.strColumnsInfo> _ListColumnsInfo;
        //public clsTSqlScriptBuilder(string databaseName,string tableName)
        //{
        //    _DatabaseName = databaseName;
        //    _TableName = tableName;
        //    _ListColumnsInfo = clsGlobal.GetAllColumnsInfo(databaseName,tableName);
        //}
        //string CreateGetAllRecordsScript()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.AppendLine($"Create Procedure GetAll{_TableName}");
        //    sb.AppendLine("as");
        //    sb.AppendLine("begin");
        //    sb.AppendLine("\tSET NOCOUNT ON;");
        //    sb.AppendLine($"\tselect * from {_TableName};");
        //    sb.AppendLine("end");

        //    return sb.ToString();
        //}
        //string CreateGetRecordBy()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    List<clsGlobal.strColumnsInfo> identityColumns = clsDataAccessLayer.FilterColumnsInfo(_ListColumnsInfo, clsGlobal.enFilterType.IdentityC);
        //    List<string> SetParameters = new List<string>();

        //    foreach (clsGlobal.strColumnsInfo columnsInfo in identityColumns)
        //    {
        //        SetParameters.Add($"{columnsInfo.ColumnName}");
        //    }

        //    sb.AppendLine($"Create Procedure Get{_TableName}By{string.Join("And", SetParameters)}");

        //    SetParameters.Clear();

        //    foreach (clsGlobal.strColumnsInfo columnsInfo in identityColumns)
        //    {
        //        SetParameters.Add($"@{columnsInfo.ColumnName} {columnsInfo.DataType}");
        //    }

        //    sb.AppendLine(string.Join(",\n",SetParameters));
            
        //    SetParameters.Clear();

        //    sb.AppendLine("as");
        //    sb.AppendLine("begin");
        //    sb.AppendLine("\tSET NOCOUNT ON;");
        //    sb.AppendLine($"select * from {_TableName}");
        //    sb.AppendLine("where");

        //    foreach (clsGlobal.strColumnsInfo columnsInfo in identityColumns)
        //    {
        //        SetParameters.Add($"{columnsInfo.ColumnName} = @{columnsInfo.ColumnName}");
        //    }

        //    sb.AppendLine(string.Join(" and ", SetParameters));

        //    sb.AppendLine("end");

        //    return sb.ToString();
        //}
    }
}
