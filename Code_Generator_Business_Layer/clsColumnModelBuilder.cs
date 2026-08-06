using Code_Generator_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;

namespace Code_Generator_Business_Layer
{
    /// <summary>
    /// Provides functionality for retrieving database column metadata, mapping SQL data types to C# types, and constructing column models for code generation.
    /// </summary>
    public class clsColumnModelBuilder
    {
        /// <summary>
        /// Represents detailed metadata and structural attributes for a specific database column.
        /// </summary>
        public struct strColumnInfo
        {
            /// <summary>Gets or sets the ordinal position or ID of the column.</summary>
            public int ColumnID;
            /// <summary>Gets or sets the name of the database column.</summary>
            public string ColumnName;
            /// <summary>Gets or sets the native SQL data type string (e.g., "varchar", "int").</summary>
            public string ColumnSqlType;
            /// <summary>Gets or sets the mapped target C# data type string (e.g., "string", "int").</summary>
            public string ColumnType;
            /// <summary>Gets or sets the maximum character or byte length of the column.</summary>
            public int MaxLength;
            /// <summary>Get or sets the precision</summary>
            public byte Precision;
            /// <summary>Get or sets the scale </summary>
            public byte Scale;
            /// <summary>Gets or sets the default value configured for the column in the database.</summary>
            public string DefaultValue;
            /// <summary>Gets or sets a value indicating whether the column allows NULL values.</summary>
            public bool IsNullable;
            /// <summary>Gets or sets a value indicating whether the column is an auto-incrementing identity column.</summary>
            public bool IsIdentity;
            /// <summary>Gets or sets a value indicating whether the column is part of the primary key.</summary>
            public bool IsPrimaryKey;
            /// <summary>Gets or sets a value indicating whether the column is a foreign key referencing another table.</summary>
            public bool IsForeignKey;
            /// <summary>Gets or sets the name of the target table referenced if this column is a foreign key.</summary>
            public string ReferencedTable;
            /// <summary>Gets or sets a value indicating whether a unique constraint is applied to the column.</summary>
            public bool IsUnique;
        }

        string _tableName;
        string _databaseName;

        /// <summary>
        /// Holds metadata for the primary key column of the specified table.
        /// </summary>
        public strColumnInfo PrimaryKey;
        /// <summary>
        /// Initializes a new instance of the <see cref="clsColumnModelBuilder"/> class for a target database and table, automatically discovering the primary key.
        /// </summary>
        /// <param name="DatabaseName">The target database name.</param>
        /// <param name="TableName">The target table name.</param>
        public clsColumnModelBuilder(string DatabaseName, string TableName)
        {
            _tableName = TableName;
            _databaseName = DatabaseName;
            PrimaryKey = GetPrimaryKey();
        }

        /// <summary>
        /// Maps a SQL Server data type string to its equivalent C# data type representation.
        /// </summary>
        /// <param name="sqlType">The SQL data type string to map.</param>
        /// <returns>A string representing the matching C# data type (e.g., "int", "string", "DateTime").</returns>
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

        /// <summary>
        /// Parses a raw schema <see cref="DataRow"/> and populates a new <see cref="strColumnInfo"/> instance.
        /// </summary>
        /// <param name="column">The <see cref="DataRow"/> containing column schema properties.</param>
        /// <returns>A populated <see cref="strColumnInfo"/> struct.</returns>
        private strColumnInfo InsertColumnData(DataRow column)
        {
            strColumnInfo info = new strColumnInfo();

            info.ColumnID = (int)column["ColumnID"];
            info.ColumnName = (string)column["ColumnName"];
            info.ColumnSqlType = (string)column["SqlDataType"];
            info.ColumnType = MappingDataType((string)column["SqlDataType"]);
            info.MaxLength = (short)column["MaxLength"];
            info.Precision = (byte)column["Precision"];
            info.Scale = (byte)column["Scale"];
            info.IsNullable = (bool)column["IsNullable"];
            info.IsIdentity = (bool)column["IsIdentity"];

            if (column["DefaultValue"] == System.DBNull.Value)
            {
                info.DefaultValue = "Null";
            }
            else
            {
                info.DefaultValue = column["DefaultValue"].ToString();
            }

            info.IsPrimaryKey = Convert.ToBoolean((int)column["IsPrimaryKey"]);
            info.IsForeignKey = Convert.ToBoolean((int)column["IsForeignKey"]);

            if (column["ReferencedTable"] == System.DBNull.Value)
            {
                info.ReferencedTable = "Null";
            }
            else
            {
                info.ReferencedTable = column["ReferencedTable"].ToString();
            }

            info.IsUnique = Convert.ToBoolean((int)column["IsUnique"]);

            return info;

        }


        /// <summary>
        /// Retrieves metadata for a specific column matching the provided column name.
        /// </summary>
        /// <param name="ColumnName">The name of the column to look up.</param>
        /// <returns>A <see cref="strColumnInfo"/> struct containing the matching column metadata.</returns>
        public strColumnInfo GetColumnInfo(string ColumnName)
        {
            DataTable dt = clsColumnsData.GetAllColumnsInfoByTableName(_databaseName, _tableName);
            strColumnInfo info = new strColumnInfo();
            foreach(DataRow dr in dt.Rows)
            {
                if((string)dr[1] == ColumnName)
                {
                    info = InsertColumnData(dr);
                    break;
                }

            }
            return info;
        }

        /// <summary>
        /// Retrieves metadata for a specific column matching the provided column ID.
        /// </summary>
        /// <param name="ColumnID">The ordinal position/ID of the column to look up.</param>
        /// <returns>A <see cref="strColumnInfo"/> struct containing the matching column metadata.</returns>
        public strColumnInfo GetColumnInfo(int ColumnID)
        {
            DataTable dt = clsColumnsData.GetAllColumnsInfoByTableName(_databaseName, _tableName);
            strColumnInfo info = new strColumnInfo();
            foreach (DataRow dr in dt.Rows)
            {
                if ((int)dr[0] == ColumnID)
                {
                    info = InsertColumnData(dr);
                    break;
                }

            }
            return info;
        }

        /// <summary>
        /// Identifies and returns metadata for the primary key column in the current table schema.
        /// </summary>
        /// <returns>A <see cref="strColumnInfo"/> struct for the primary key column.</returns>
        private strColumnInfo GetPrimaryKey()
        {
            strColumnInfo pk = new strColumnInfo();
            foreach(strColumnInfo c in GetAllColumnsInfo())
            {
                if(c.IsPrimaryKey)
                {
                    pk = c;
                }
            }
            return pk;
        }

        /// <summary>
        /// Retrieves metadata for all columns belonging to the configured table.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="strColumnInfo"/> structs representing each column in the table.</returns>
        public List<clsColumnModelBuilder.strColumnInfo> GetAllColumnsInfo()
        {
            List<strColumnInfo> list = new List<strColumnInfo>();
            DataTable dt = clsColumnsData.GetAllColumnsInfoByTableName(_databaseName, _tableName);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(InsertColumnData(dr));
            }
            return list;
        }
    }
}
