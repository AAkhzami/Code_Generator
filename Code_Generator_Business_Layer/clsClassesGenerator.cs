using Code_Generator_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Text;
using static Code_Generator_Business_Layer.clsDataAccessLayer;

namespace Code_Generator_Business_Layer
{
    public class clsClassesGenerator : clsGlobal
    {
        public static List<string> GetAllTablesNameOnDatabase(string Database)
        {
            return clsDatabaseInfo_Data.GetAllTablesOnDatabase(Database);
        }
        public static string CreateConnectionSettings(strConnectionInfo ConnectionInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Libraries());
            sb.Append($"namespace {ConnectionInfo.dbName}_Data_Layer \n{{");
            sb.Append($"public class clsDataAccessSettings \n{{\tpublic static string connectionString = \"Server = .; Database = {ConnectionInfo.dbName}; User Id = {ConnectionInfo.userID}; Password = {ConnectionInfo.password}\";\n}}\n}}");
            return sb.ToString();
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
        static public string CreateDataAccessClass( strConnectionInfo connectionInfo, string tableName)
        {
            StringBuilder ClassString = new StringBuilder();
            ClassString.AppendLine(Libraries());

            ClassString.AppendLine($"namespace {connectionInfo.dbName}_DataAccess_Layer");
            ClassString.AppendLine("{");
            ClassString.AppendLine($"   public class cls{tableName}Data" + Environment.NewLine);
            ClassString.AppendLine("    {" );

            ClassString.Append(WriteSelectRecordMethod(tableName, connectionInfo));
            ClassString.Append(WriteAddNewRecordMethod(tableName, connectionInfo));
            ClassString.Append(WriteUpdateRecordMethod(tableName, connectionInfo));
            ClassString.Append(WriteDeleteRecordMethod(tableName, connectionInfo));
            ClassString.Append(WriteGetAllRecordMethod(tableName, connectionInfo));

            ClassString.AppendLine("    }");
            ClassString.AppendLine("}");

            return ClassString.ToString();
        }
        static public string CreateBusinessClass(strConnectionInfo connectionInfo, string TableName)
        {
            StringBuilder ClassString = new StringBuilder();
            ClassString.Append(Libraries());
            ClassString.AppendLine($"using {connectionInfo.dbName}_Data_Layer;");
            ClassString.Append($"namespace {connectionInfo.dbName}_Business_Layer \n{{");
            clsBusinessLayer bl = new clsBusinessLayer(connectionInfo, TableName);

            string className = $"cls{TableName}";
            ClassString.AppendLine($"\n\tpublic class {className}\n{{");
            ClassString.AppendLine("\t\t" + bl.GetAllProperties());
            ClassString.AppendLine("\t\t" + bl.Constructors(className));
            ClassString.AppendLine("\t\t" + bl.CreateFindRecord());
            ClassString.AppendLine("\t\t" + bl.CreateAddNewRecordMethod());
            ClassString.AppendLine("\t\t" + bl.CreateUpdateRecordMethod());
            ClassString.AppendLine("\t\t" + bl.CreateSaveRecordMethod());
            ClassString.AppendLine("\t\t" + bl.CreateDeleteRecord());
            ClassString.AppendLine("\t\t" + bl.CreateGetAllRecords());
            ClassString.AppendLine("\t}");
            ClassString.AppendLine("}");

            return ClassString.ToString();
        }
        static public List<string> CreateAllDataAccessClassesAllTables(strConnectionInfo connectionInfo)
        {
            List<string> ClassesList = new List<string>();
            List<string> tables = GetAllTablesNameOnDatabase(connectionInfo.dbName);
            foreach (string table in tables)
            {
                ClassesList.Add(CreateDataAccessClass(connectionInfo, table));
            }
            return ClassesList;
        }

        static public List<string> CreateAllBusinessClassesForAllTables(strConnectionInfo connectionInfo)
        {
            List<string> ClassesList = new List<string>();
            List<string> tables = GetAllTablesNameOnDatabase(connectionInfo.dbName);
            foreach (string table in tables)
            {
                ClassesList.Add(CreateBusinessClass(connectionInfo, table));
            }
            return ClassesList;
        }

        //static public List<string> CreateDataAccessClasses(strConnectionInfo connectionInfo, List<string> tables)
        //{
        //    List<string> ClassesList = new List<string>();
        //    foreach (string table in tables)
        //    {
        //        ClassesList.Add(CreateDataAccessClass(table, connectionInfo));
        //    }
        //    return ClassesList;
        //}
        //static public List<string> CreateBusinessClasses(strConnectionInfo connectionInfo, List<string> tables)
        //{
        //    List<string> ClassesList = new List<string>();
        //    foreach (string table in tables)
        //    {
        //        ClassesList.Add(CreateBusinessClass(connectionInfo, table));
        //    }
        //    return ClassesList;
        //}
    }
}
