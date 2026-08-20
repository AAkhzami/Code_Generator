using Code_Generator_Business_Layer.BusinessGenerators;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer
{
    public class clsBusinessLayerGenerator : iBusinessGenerator
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

            _Columns.GetAllColumnsInfo().ForEach(c =>
            {
                bool isNullable = c.IsPrimaryKey || c.IsNullable;
                propertiesText.AppendLine($"public {clsHelper.FormatNullableType(c.ColumnType, isNullable)} {c.ColumnName} {{get;set;}}");
            });

            return propertiesText.ToString();
        }
        public string GenerateCreateMethod()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"private bool _AddNew{_table}()");
            sb.AppendLine("{");
            sb.Append($"\tcls{_table}Data.AddNewRecordeOn{_table}(");

            List<string> Parameters = new List<string>();

            _Columns.GetAllColumnsInfo().ForEach((c) =>
            {
                if (!c.IsPrimaryKey && !c.IsIdentity)
                {
                    Parameters.Add($"this.{c.ColumnName}");
                }
                else
                {
                    Parameters.Add($"ref this.{c.ColumnName}");
                }
            });

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

            _ListColumns.ForEach(
                c =>
                {
                    if (!c.IsPrimaryKey)
                    {
                        sb.AppendLine($"\t{clsHelper.FormatNullableType(c.ColumnType, c.IsNullable)} {c.ColumnName} = {clsHelper.DefaultValue(c.ColumnType)};");
                    }
                });
            
            sb.Append($"\tbool IsFound = cls{_table}Data.GetOnRecordFrom{_table}(");

            List<string> propertiesList = new List<string>();

            _ListColumns.ForEach(c => propertiesList.Add(c.ColumnName));

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
            sb.Append($"\treturn cls{_table}Data.UpdateRecordFrom{_table}(");

            List<string> columnsName = new List<string>();

            _Columns.GetAllColumnsInfo().ForEach(c =>
            {
                columnsName.Add(c.ColumnName);
            });

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
            sb.AppendLine($"\treturn cls{_table}Data.DeleteRecordFrom{_table}({_Columns.PrimaryKey.ColumnName});");
            sb.AppendLine("}");
            return sb.ToString();
        }
        public string GenerateReadAllMethod()
        {

            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"public static DataTable GetAll{_table}()");
            sb.AppendLine("{");
            sb.AppendLine($"\treturn cls{_table}Data.GetAll{_table}();");
            sb.AppendLine("}");
            return sb.ToString();
        }
        public string GeneratePublicConstructor()
        {
            List<clsColumnModelBuilder.strColumnInfo> ColumnsList = _Columns.GetAllColumnsInfo();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"public cls{_table}()");

            sb.AppendLine("{");
            ColumnsList.ForEach(c =>
            {
                if (c.IsPrimaryKey)
                {
                    sb.AppendLine($"\tthis.{c.ColumnName} = null;");
                }
                else
                {
                    sb.AppendLine($"\tthis.{c.ColumnName} = {clsHelper.DefaultValue(c.ColumnType)};");
                }
            });

            sb.AppendLine("\tMode = enMode.AddNew;");
            sb.AppendLine("}");

            return sb.ToString();
        }
        public string GeneratePrivateConstructor()
        {
            StringBuilder sb = new StringBuilder();
            List<clsColumnModelBuilder.strColumnInfo> ColumnsList = _Columns.GetAllColumnsInfo();
            List<string> columnsNameAndType = new List<string>();

            ColumnsList.ForEach(c =>
            {
                bool isNullable = c.IsNullable || c.IsPrimaryKey;
                columnsNameAndType.Add($"{clsHelper.FormatNullableType(c.ColumnType, isNullable)} {clsHelper.SafeParamName(c.ColumnName)}");
            });


            sb.AppendLine($"private cls{_table}({clsHelper.FormatingProperties(columnsNameAndType)})");

            sb.AppendLine("{");

            ColumnsList.ForEach(c =>
            {
                sb.AppendLine($"\tthis.{c.ColumnName} = {clsHelper.SafeParamName(c.ColumnName)};");
            });

            sb.AppendLine("\tMode = enMode.Update;");

            sb.AppendLine("}");
            return sb.ToString();
        }
        public string GenerateSaveMethod()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public bool Save()");
            sb.AppendLine("{");
            sb.AppendLine("\tif(Mode == enMode.AddNew)");
            sb.AppendLine("\t{");
            sb.AppendLine($"\t\tif(_AddNew{_table}())");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\tMode = enMode.Update;");
            sb.AppendLine("\t\t\treturn true;");
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");
            sb.AppendLine("\telse if(Mode == enMode.Update)");
            sb.AppendLine("\t{");
            sb.AppendLine($"\t\treturn _Update{_table}();");
            sb.AppendLine("\t}");
            sb.AppendLine("\treturn false;");
            sb.AppendLine("}");
            return sb.ToString();
        }
        public string GenerateBusinessLayerClass()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public class cls{_table}");
            sb.AppendLine("{");
            sb.AppendLine(GenerateProperties());
            sb.AppendLine(GeneratePublicConstructor());
            sb.AppendLine(GeneratePrivateConstructor());
            sb.AppendLine(GenerateCreateMethod());
            sb.AppendLine(GenerateReadMethod());
            sb.AppendLine(GenerateUpdateMethod());
            sb.AppendLine(GenerateDeleteMethod());
            sb.AppendLine(GenerateReadAllMethod());
            sb.AppendLine(GenerateSaveMethod());
            sb.AppendLine("}");
            return sb.ToString();
        }
        public string GenerateSaveCreateMethod()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public bool Save()");
            sb.AppendLine("{");
            sb.AppendLine("\tif(Mode == enMode.AddNew)");
            sb.AppendLine("\t{");
            sb.AppendLine($"\t\tif(_AddNew{_table}())");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\tMode = enMode.Update;");
            sb.AppendLine("\t\t\treturn true;");
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");
            sb.AppendLine("\treturn false;");
            sb.AppendLine("}");
            return sb.ToString();
        }
        public string GenerateSaveUpdateMethod()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"public bool Save()");
            sb.AppendLine("{");
            sb.AppendLine("\tif(Mode == enMode.Update)");
            sb.AppendLine("\t{");
            sb.AppendLine($"\t\treturn _Update{_table}();");
            sb.AppendLine("\t}");
            sb.AppendLine("\treturn false;");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
