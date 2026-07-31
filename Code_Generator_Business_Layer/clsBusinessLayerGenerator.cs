using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Code_Generator_Business_Layer.clsGlobal;

namespace Code_Generator_Business_Layer
{
    public class clsBusinessLayerGenerator
    {
        string _database;
        string _table;
        clsColumnModelBuilder _Columns;
        public clsBusinessLayerGenerator(string Database, string Table)
        {
            _database = Database;
            _table = string.IsNullOrEmpty(Table) ? Table : char.ToUpper(Table[0]) + Table.Substring(1);
            _Columns = new clsColumnModelBuilder(_database, Table);
        }

        public string GenerateProperties()
        {
            StringBuilder propertiesText = new StringBuilder();
            propertiesText.AppendLine("public enum enMode { AddNew = 0, Update = 1 };");
            propertiesText.AppendLine("public enMode Mode = enMode.AddNew;");
            foreach (clsColumnModelBuilder.strColumnInfo column in _Columns.GetAllColumnsInfo())
            {
                bool isNullable = column.IsPrimaryKey || column.IsNullable;
                propertiesText.AppendLine($"public {clsHelper.FormatNullableType(column.ColumnType, isNullable)} {column.ColumnName} {{get;set;}}");
            }
            return propertiesText.ToString();
        }
        public string GenerateCreateMethod()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"private bool _AddNew{_table}()");
            sb.AppendLine("{");
            sb.Append($"\tthis.{_Columns.PrimaryKey.ColumnName} = cls{_table}Data.AddNew{_table}(");

            List<string> Parameters = new List<string>();
            foreach (clsColumnModelBuilder.strColumnInfo col in _Columns.GetAllColumnsInfo())
            {
                if (!col.IsPrimaryKey && !col.IsIdentity)
                {
                    Parameters.Add($"this.{col.ColumnName}");
                }
            }

            sb.Append(string.Join(", ", Parameters));
            sb.AppendLine(");");
            sb.AppendLine($"\treturn (this.{_Columns.PrimaryKey.ColumnName} != null);");
            sb.AppendLine("}");


            return sb.ToString();
        }
        public string GenerateReadMethod()
        {
            List<clsColumnModelBuilder.strColumnInfo> _ListColumns = _Columns.GetAllColumnsInfo();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public static cls{_table} Find({_Columns.PrimaryKey.ColumnType} {_Columns.PrimaryKey.ColumnName})");
            sb.AppendLine("{");

            foreach (clsColumnModelBuilder.strColumnInfo column in _ListColumns)
            {
                if (!column.IsPrimaryKey && !column.IsIdentity)
                {
                    sb.Append("\t");
                    sb.AppendLine($"{clsHelper.FormatNullableType(column.ColumnType, column.IsNullable)} {column.ColumnName} = {clsHelper.DefaultValue(column.ColumnType)};");
                }
            }
            sb.Append($"\tbool IsFound = cls{_table}Data.Get{_table}InfoByID(");

            List<string> propertiesList = new List<string>();

            foreach (clsColumnModelBuilder.strColumnInfo column in _ListColumns)
            {
                propertiesList.Add(column.ColumnName);
            }


            sb.Append(clsHelper.FormatingProperties(propertiesList, "ref ", 1));

            sb.AppendLine($");");

            sb.AppendLine("\tif(IsFound)");
            sb.AppendLine("\t{");
            sb.AppendLine($"\t\treturn new cls{_table}({clsHelper.FormatingProperties(propertiesList)});");
            sb.AppendLine("\t}");
            sb.AppendLine("\telse");
            sb.AppendLine("\t{");
            sb.AppendLine("\t\treturn null;");
            sb.AppendLine("\t}");
            sb.AppendLine("}");


            return sb.ToString();
        }
        public string GenerateUpdateMethod()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"private bool _Update{_table}()");
            sb.AppendLine("{");
            sb.Append($"\treturn cls{_table}Data.Update{_table}InfoByID(");

            List<string> columnsName = new List<string>();
            foreach (clsColumnModelBuilder.strColumnInfo c in _Columns.GetAllColumnsInfo())
            {
                columnsName.Add(c.ColumnName);
            }

            sb.Append(clsHelper.FormatingProperties(columnsName, "this.", 0));
            sb.AppendLine(");");
            sb.AppendLine("}");


            return sb.ToString();
        }
        public string GenerateDeleteMethod()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public static bool Delete{_table}({_Columns.PrimaryKey.ColumnType} {_Columns.PrimaryKey.ColumnName})");
            sb.AppendLine("{");
            sb.AppendLine($"\treturn cls{_table}Data.Delete{_table}ByID({_Columns.PrimaryKey.ColumnName});");
            sb.AppendLine("}");
            return sb.ToString();
        }
        public string GenerateReadAllMethod()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"public static DataTable GetAll{_table}()");
            sb.AppendLine("{");
            sb.AppendLine($"\treturn cls{_table}Data.GetAll{_table}Records();");
            sb.AppendLine("}");
            return sb.ToString();
        }
        public string GeneratePublicConstructor()
        {
            List<clsColumnModelBuilder.strColumnInfo> ColumnsList = _Columns.GetAllColumnsInfo();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"public cls{_table}()");

            sb.AppendLine("{");
            foreach (clsColumnModelBuilder.strColumnInfo column in ColumnsList)
            {
                sb.AppendLine($"\tthis.{column.ColumnName} = {clsHelper.DefaultValue(column.ColumnType)};");
            }

            sb.AppendLine("\tMode = enMode.AddNew;");
            sb.AppendLine("}");

            return sb.ToString();
        }
        public string GeneratePrivateConstructor()
        {
            StringBuilder sb = new StringBuilder();
            List<clsColumnModelBuilder.strColumnInfo> ColumnsList = _Columns.GetAllColumnsInfo();
            List<string> columnsNameAndType = new List<string>();

            foreach (clsColumnModelBuilder.strColumnInfo column in ColumnsList)
            {
                columnsNameAndType.Add($"{clsHelper.FormatNullableType(column.ColumnType,column.IsNullable)} {column.ColumnName.ToLower()}");
            }


            sb.AppendLine($"private cls{_table}({clsHelper.FormatingProperties(columnsNameAndType)})");

            sb.AppendLine("{");

            foreach (clsColumnModelBuilder.strColumnInfo column in ColumnsList)
            {
                sb.AppendLine($"\tthis.{column.ColumnName} = {column.ColumnName.ToLower()};");
            }

            sb.AppendLine("\tMode = enMode.Update;");

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
