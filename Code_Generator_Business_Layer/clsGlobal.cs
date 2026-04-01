using Code_Generator_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer
{
    public class clsGlobal
    {
        public enum enFilterType { IdentityC, NullableC };

        public struct strColumnsInfo
        {
            public string ColumnName { get; set; }
            public string DataType { get; set; }
            public bool IsNullable { get; set; }
            public bool IsIdentity { get; set; }
        }
        public struct strConnectionInfo
        {
            public string userID;
            public string password;
            public string dbName;
        }

        public static List<strColumnsInfo> GetAllColumnsInfo(string DBName, string TableName)
        {
            List<strColumnsInfo> columnsInfoList = new List<strColumnsInfo>();
            List<clsDatabaseInfo_Data.ColumnsInfo> _columnsInfoList = clsDatabaseInfo_Data.GetAllColumnsByTableName(DBName, TableName);
            foreach (clsDatabaseInfo_Data.ColumnsInfo ci in _columnsInfoList)
            {
                strColumnsInfo columnsInfo = new strColumnsInfo();
                columnsInfo.ColumnName = ci.ColumnName;
                columnsInfo.DataType = ci.DataType;
                columnsInfo.IsNullable = ci.IsNullable;
                columnsInfo.IsIdentity = ci.IsIdentity;
                columnsInfoList.Add(columnsInfo);
            }

            return columnsInfoList;
        }
        public static List<strColumnsInfo> FilterColumnsInfo(List<strColumnsInfo> columnsInfoList, enFilterType filterType)
        {
            List<strColumnsInfo> FilterColumnsInfoList = new List<strColumnsInfo>();

            foreach (strColumnsInfo ColumnsInfo in columnsInfoList)
            {
                switch (filterType)
                {
                    case enFilterType.IdentityC:
                        if (ColumnsInfo.IsIdentity)
                            FilterColumnsInfoList.Add(ColumnsInfo);
                        break;
                    case enFilterType.NullableC:
                        if (ColumnsInfo.IsNullable)
                            FilterColumnsInfoList.Add(ColumnsInfo);
                        break;

                }
            }

            return FilterColumnsInfoList;
        }
        public static string MapSqlTypeToCSharp(string sqlType, bool isNullable = false)
        {
            string csharpType;

            switch (sqlType)
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

            if (isNullable && csharpType != "string" && csharpType != "byte[]" && csharpType != "object")
                csharpType += "?";
            return csharpType;
        }
        public static string GetIDentityParametersName(List<strColumnsInfo> columnsInfos, bool AddType = false)
        {
            List<string> IdentityColumnsList = new List<string>();
            string IdentityColumn = "";
            foreach (strColumnsInfo columnInfo in columnsInfos)
            {

                if (columnInfo.IsIdentity)
                {
                    if (AddType)
                        IdentityColumn += MapSqlTypeToCSharp(columnInfo.DataType) + " ";
                    IdentityColumn += columnInfo.ColumnName;
                    IdentityColumnsList.Add(IdentityColumn);

                }

            }

            return string.Join(",", IdentityColumnsList);
        }

        public static string GetParamatersFunction(List<strColumnsInfo> ColumnsInfo, bool IncludeIdentityParameter = false)
        {
            List<string> ParametersList = new List<string>();
            foreach (strColumnsInfo ci in ColumnsInfo)
            {
                if (!IncludeIdentityParameter)
                    if (ci.IsIdentity) continue;
                ParametersList.Add(MapSqlTypeToCSharp(ci.DataType, ci.IsNullable) + " " + ci.ColumnName.ToLower());
            }
            string Parameters_Text = string.Join(",", ParametersList);

            return Parameters_Text;
        }
        public static string GetColumnsNamesString(List<strColumnsInfo> ColumnsInfo, bool IncludeIdentityParameter = false, string Additions = null)
        {

            List<string> ParametersList = new List<string>();
            foreach (strColumnsInfo ci in ColumnsInfo)
            {
                if (!IncludeIdentityParameter)
                    if (ci.IsIdentity) continue;
                ParametersList.Add(Additions + ci.ColumnName);
            }
            string Parameters_Text = string.Join(",", ParametersList);

            return Parameters_Text;
        }
    }
}
