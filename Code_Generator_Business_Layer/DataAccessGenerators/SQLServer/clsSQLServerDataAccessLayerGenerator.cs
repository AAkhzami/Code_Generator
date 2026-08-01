using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return "Create Method";
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
