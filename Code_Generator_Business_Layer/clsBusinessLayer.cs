using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Code_Generator_Business_Layer
{
    public class clsBusinessLayer : clsGlobal
    {
        strConnectionInfo _ConnectionInfo {  get; set; }
        List<strColumnsInfo> _ColumnsListInfo { get; set; }
        string _TableName { get; set; }
        string _IdentityPropertie { get; set; }
        public string GetAllProperties()
        {
            List<strColumnsInfo> ColumnsList = GetAllColumnsInfo(_ConnectionInfo.dbName,_TableName);
            StringBuilder propertiesText = new StringBuilder();
            propertiesText.AppendLine("public enum enMode { AddNew = 0, Update = 1 };");
            propertiesText.AppendLine("public enMode Mode = enMode.AddNew;");
            foreach(strColumnsInfo column in _ColumnsListInfo)
            {
                if(column.IsIdentity)
                    propertiesText.AppendLine($"public {MapSqlTypeToCSharp(column.DataType, true)} {column.ColumnName} {{get;set;}}");
                else
                    propertiesText.AppendLine($"public {MapSqlTypeToCSharp(column.DataType, false)} {column.ColumnName} {{get;set;}}");
            }
            return propertiesText.ToString();
        }
        
        public string Constructors(string className)
        {
            StringBuilder sb = new StringBuilder();
            //public Constructors
            sb.AppendLine($"public {className}()");
            sb.AppendLine("{");
            foreach (strColumnsInfo column in _ColumnsListInfo)
            {
                sb.AppendLine($"\tthis.{column.ColumnName} = {DefaultValue(MapSqlTypeToCSharp(column.DataType,true))};");
            }
            sb.AppendLine("\tMode = enMode.AddNew;");
            sb.AppendLine("}");

            // private Constructors
            sb.AppendLine($"private {className}({GetParamatersFunction(_ColumnsListInfo, true)})");
            sb.AppendLine("{");
            foreach (strColumnsInfo column in _ColumnsListInfo)
            {
                sb.AppendLine($"\tthis.{column.ColumnName} = {column.ColumnName.ToLower()};");
            }
            sb.AppendLine("\tMode = enMode.Update;");

            sb.AppendLine("}");
            return sb.ToString();
        }
        public string CreateAddNewRecordMethod()
        {
            string name = char.ToUpper(_TableName[0]) + _TableName.Substring(1);
            string ID = GetIDentityParametersName(_ColumnsListInfo);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"private bool _AddNew{_TableName}()");
            sb.AppendLine("{");
            sb.Append($"this.{ID} = cls{_TableName}Data.AddNew{name}(");

            List<string> Parameters = new List<string>();
            foreach(strColumnsInfo col  in _ColumnsListInfo)
            {
                if(!col.IsIdentity)
                {
                    Parameters.Add($"this.{col.ColumnName}");
                }
            }
            sb.Append(string.Join(", ", Parameters));
            sb.AppendLine(");");
            sb.AppendLine($"return (this.{ID} != null);");
            sb.AppendLine("}");


            return sb.ToString();
        }
        public string CreateUpdateRecordMethod()
        {
            string name = char.ToUpper(_TableName[0]) + _TableName.Substring(1);
            string ID = GetIDentityParametersName(_ColumnsListInfo);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"private bool _Update{_TableName}()");
            sb.AppendLine("{");
            sb.Append($"return cls{_TableName}Data.Update{name}InfoByID(");
            foreach (strColumnsInfo column in _ColumnsListInfo)
            {
                if (column.IsIdentity)
                {
                    sb.Append($"this.{column.ColumnName} ?? -1, ");
                }

            }
            sb.Append(clsGlobal.GetColumnsNamesString(_ColumnsListInfo,false, "this."));
            sb.Append(");");
            sb.AppendLine("}");


            return sb.ToString();
        }
        public string CreateSaveRecordMethod()
        {
            string name = char.ToUpper(_TableName[0]) + _TableName.Substring(1);
            string ID = GetIDentityParametersName(_ColumnsListInfo);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public bool Save()");
            sb.AppendLine("{");
            sb.AppendLine("\tswitch (Mode)\n\t{");

            sb.AppendLine("\t\t" + "case enMode.AddNew:");
            sb.AppendLine("\t\t\t" + $"if(_AddNew{name}())");
            sb.AppendLine("\t\t" + "{");
            sb.AppendLine("\t\t\t" + "Mode = enMode.Update;");
            sb.AppendLine("\t\t\t" + "return true;");
            sb.AppendLine("\t\t" + "}");
            sb.AppendLine("\t\t" + "else");
            sb.AppendLine("\t\t" + "{");
            sb.AppendLine("\t\t\t" + "return false;");
            sb.AppendLine("\t\t" + "}");
            sb.AppendLine("\t\t" + "case enMode.Update:");
            sb.AppendLine("\t\t\t" + $"return _Update{name}();");
            sb.AppendLine("\t}"); 
            sb.AppendLine("\treturn false;");
            sb.AppendLine("}");

            return sb.ToString();
        }
        public string CreateGetAllRecords()
        {
            string name = char.ToUpper(_TableName[0]) + _TableName.Substring(1);
            string ID = GetIDentityParametersName(_ColumnsListInfo);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public static DataTable GetAll{_TableName}()");
            sb.AppendLine("{");
            sb.AppendLine($"\treturn cls{_TableName}Data.GetAll{name}();");
            sb.AppendLine("}");
            return sb.ToString();
        }
        public string CreateDeleteRecord()
        {
            string name = char.ToUpper(_TableName[0]) + _TableName.Substring(1);
            string ID = GetIDentityParametersName(_ColumnsListInfo);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public static bool Delete{_TableName}({_IdentityPropertie})");
            sb.AppendLine("{");
            sb.Append($"\treturn cls{_TableName}Data.Delete{name}ByID(");
            foreach(strColumnsInfo column in _ColumnsListInfo)
            {
                if(column.IsIdentity)
                    sb.Append(column.ColumnName);
            }
            sb.Append(");\n");
            sb.AppendLine("}");
            return sb.ToString();
        }
        public string CreateFindRecord()
        {
            string ID = GetIDentityParametersName(_ColumnsListInfo);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public static cls{_TableName} Find({_IdentityPropertie})");
            sb.AppendLine("{");
            string type = "";
            sb.Append("\t");
            foreach(strColumnsInfo column in _ColumnsListInfo)
            {
                if(!column.IsIdentity)
                {
                    type = MapSqlTypeToCSharp(column.DataType);
                    sb.AppendLine($"{type} {column.ColumnName} = {DefaultValue(type)};");
                }
            }
            sb.Append($"\n\tbool IsFound = cls{_TableName}Data.Get{_TableName}InfoByID(");
            sb.Append($"{ID}, {GetColumnsNamesString(_ColumnsListInfo,false, "ref ")}");
            sb.Append($");\n");
            sb.AppendLine("\tif(IsFound)\n\t{");
            sb.AppendLine($"\t\treturn new cls{_TableName}({GetColumnsNamesString(_ColumnsListInfo, true)});\n\t}}");
            sb.AppendLine("\telse\n\t{");
            sb.AppendLine("\t\treturn null;\n\t}");
            sb.AppendLine("}");


            return sb.ToString();
        }
        public clsBusinessLayer(strConnectionInfo ConnectionInfo, string tableName)
        {
            _ConnectionInfo = ConnectionInfo;
            _TableName = tableName;
            _ColumnsListInfo = GetAllColumnsInfo(_ConnectionInfo.dbName,tableName);
            _IdentityPropertie = GetIDentityParametersName(_ColumnsListInfo,true);
        }
    }

}
