using Code_Generator_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
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
        public string MappingDataType(string sqlType)
        {
            string csharpType;

            switch (sqlType.ToLower())
            {
                case "bigint": csharpType = "long"; break;

                case "int": csharpType = "int"; break;

                case "smallint": csharpType = "short"; break;

                case "tinyint": csharpType = "byte"; break;

                case "bit": csharpType = "bool"; break;

                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney": csharpType = "decimal"; break;

                case "float": csharpType = "double"; break;

                case "real": csharpType = "float"; break;

                case "datetime":
                case "datetime2":
                case "date":
                case "smalldatetime": csharpType = "DateTime"; break;

                case "varchar":
                case "nvarchar":
                case "text":
                case "ntext":
                case "char":
                case "nchar": csharpType = "string"; break;

                case "binary":
                case "varbinary":
                case "image": csharpType = "byte[]"; break;

                case "uniqueidentifier": csharpType = "Guid"; break;

                default: csharpType = "object"; break;
            }

            return csharpType;
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
                    info.MaxLength = (short)dr[3];
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
