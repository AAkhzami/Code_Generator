using Code_Generator_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Text;
using static Code_Generator_Business_Layer.clsCRUDMethods;

namespace Code_Generator_Business_Layer
{
    public class clsClassesGenerator
    {
        public static List<string> GetAllTablesNameOnDatabase(string Database)
        {
            return clsDatabaseInfo_Data.GetAllTablesOnDatabase(Database);
        }
        private static string Libraries()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;");
            sb.Append("using System.Collections.Generic;");
            sb.Append("using System.Data.SqlClient;");
            return sb.ToString();
        }
        static public string CreateClass(string tableName, strConnectionInfo connectionInfo)
        {
            StringBuilder ClassString = new StringBuilder();
            ClassString.Append(Libraries());
            ClassString.Append($"public class cls{tableName}");
            ClassString.Append("{");

            ClassString.Append(WriteSelectRecordMethod(tableName, connectionInfo));
            ClassString.Append(WriteAddNewRecordMethod(tableName, connectionInfo));
            ClassString.Append(WriteUpdateRecordMethod(tableName, connectionInfo));
            ClassString.Append(WriteDeleteRecordMethod(tableName, connectionInfo));
            ClassString.Append(WriteGetAllRecordMethod(tableName, connectionInfo));

            ClassString.Append("}");

            return ClassString.ToString();
        }
        static public List<string> CreateAllClassByDatabaseName(strConnectionInfo connectionInfo)
        {
            List<string> ClassesList = new List<string>();
            List<string> tables = GetAllTablesNameOnDatabase(connectionInfo.dbName);
            foreach (string table in tables)
            {
                ClassesList.Add(CreateClass(table,connectionInfo));
            }

            return ClassesList;
        }
    }
}
