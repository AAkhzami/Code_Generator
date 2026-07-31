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
            _table = Table;
            _Columns = new clsColumnModelBuilder(_database, _table);
        }

        public string WriteProperties()
        {
            StringBuilder propertiesText = new StringBuilder();
            propertiesText.AppendLine("public enum enMode { AddNew = 0, Update = 1 };");
            propertiesText.AppendLine("public enMode Mode = enMode.AddNew;");
            foreach (clsColumnModelBuilder.strColumnInfo column in _Columns.GetAllColumnsInfo())
            {
                if (column.IsNullable)
                {
                    propertiesText.AppendLine($"public {clsHelper.FormatNullableType(column.ColumnType, column.IsNullable)} {column.ColumnName} {{get;set;}}");
                }
                else
                {
                    propertiesText.AppendLine($"public {column.ColumnType} {column.ColumnName} {{get;set;}}");
                }
            }
            return propertiesText.ToString();
        }
        public string WriteCreateMethod()
        {
            string name = char.ToUpper(_table[0]) + _table.Substring(1);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"private bool _AddNew{_table}()");
            sb.AppendLine("{");
            sb.Append($"\tthis.{_Columns.PrimaryKey.ColumnName} = cls{_table}Data.AddNew{name}(");

            List<string> Parameters = new List<string>();
            foreach (clsColumnModelBuilder.strColumnInfo col in _Columns.GetAllColumnsInfo())
            {
                if (!col.IsPrimaryKey)
                {
                    Parameters.Add($"this.{col.ColumnName}");
                }
            }

            sb.Append(string.Join(", ", Parameters));
            sb.Append(");");
            sb.Append($"return (this.{_Columns.PrimaryKey.ColumnName} != null);");
            sb.AppendLine("}");


            return sb.ToString();
        }
    }
}
