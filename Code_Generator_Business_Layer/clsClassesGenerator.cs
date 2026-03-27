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
            sb.Append("using System;" + Environment.NewLine);            
            sb.Append("using System.Collections.Generic;" + Environment.NewLine);
            sb.Append("using System.Data;" + Environment.NewLine);
            sb.Append("using System.Data.SqlClient;" + Environment.NewLine);
            return sb.ToString();
        }
        static public string CreateClass(string tableName, strConnectionInfo connectionInfo)
        {
            StringBuilder ClassString = new StringBuilder();
            ClassString.Append(Libraries());
            ClassString.Append($"public class cls{tableName}" + Environment.NewLine);
            ClassString.Append("{" + Environment.NewLine);

            ClassString.Append(WriteSelectRecordMethod(tableName, connectionInfo));
            ClassString.Append(WriteAddNewRecordMethod(tableName, connectionInfo));
            ClassString.Append(WriteUpdateRecordMethod(tableName, connectionInfo));
            ClassString.Append(WriteDeleteRecordMethod(tableName, connectionInfo));
            ClassString.Append(WriteGetAllRecordMethod(tableName, connectionInfo));

            ClassString.Append("}" + Environment.NewLine);

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
