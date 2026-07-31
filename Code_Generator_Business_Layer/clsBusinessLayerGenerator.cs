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
                propertiesText.AppendLine($"public {column.ColumnType} {column.ColumnName} {{get;set;}}");
            }
            return propertiesText.ToString();
        }
    }
}
