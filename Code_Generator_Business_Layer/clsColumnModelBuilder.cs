using Code_Generator_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer
{
    public class clsColumnModelBuilder
    {
        public struct strColumnInfo
        {
            public int ColumnID;
            public string ColumnName;
            public string ColumnSqlType;
            public string ColumnType;
            public int MaxLength;
            public string DefaultValue;
            public bool IsNullable;
            public bool IsIdentity;
            public bool IsPrimaryKey;
            public bool IsForeignKey;
            public string ReferencedTable;
            public bool IsUnique;
        }

        string _tableName;
        string _databaseName;

        public clsColumnModelBuilder(string DatabaseName, string TableName)
        {
            _tableName = TableName;
            _databaseName = DatabaseName;
        }
        public string MappingDataType(string dataType)
        {
            switch (dataType.ToLower().Replace("?", ""))
            {
                case "string":
                    return "null";

                case "int":
                case "long":
                case "short":
                case "byte":
                    return "0";

                case "decimal":
                case "float":
                case "double":
                    return "0";

                case "bool":
                    return "false";

                case "datetime":
                    return "DateTime.Now";

                case "guid":
                    return "Guid.Empty";

                default:
                    return "null";
            }
        }
        public strColumnInfo GetColumnInfo(string ColumnName)
        {
            DataTable dt = clsColumnsData.GetAllColumnsInfoByTableName(_databaseName, _tableName);
            strColumnInfo info = new strColumnInfo();
            foreach(DataRow dr in dt.Rows)
            {
                if((string)dr[1] == ColumnName)
                {
                    info.ColumnID = (int)dr[0];
                    info.ColumnName = (string)dr[1];
                    info.ColumnSqlType = (string)dr[2];
                    info.ColumnType = MappingDataType((string)dr[2]);
                    info.MaxLength = (int)dr[3];
                    info.IsNullable = (bool)dr[4];
                    info.DefaultValue = (string)dr[5];
                    info.IsPrimaryKey = (bool)dr[6];
                    info.IsForeignKey = (bool)dr[7];
                    info.ReferencedTable = (string)dr[8];
                    info.IsUnique = (bool)dr[9];

                    break;
                }

            }
            return info;
        }
    }
}
