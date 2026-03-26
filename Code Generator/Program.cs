using Code_Generator_Business_Layer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;
using static Code_Generator_Business_Layer.clsCRUDMethods;
using System.IO;

namespace Code_Generator
{


    internal class Program
    {
        
        static void Main(string[] args)
        {


            clsCRUDMethods.strConnectionInfo ConnectionInfo = new clsCRUDMethods.strConnectionInfo();
            ConnectionInfo.dbName = "Database)name";
            ConnectionInfo.userID = "userID";
            ConnectionInfo.password = "password";

            List<string> ClassesList = clsClassesGenerator.CreateAllClassByDatabaseName(ConnectionInfo);
            List<string> TablesName = clsClassesGenerator.GetAllTablesNameOnDatabase(ConnectionInfo.dbName);

            for (int i = 0; i < ClassesList.Count; i++)
            {
                clsExport.CreateClassWithContent(ClassesList[i], $@"cls_{TablesName[i]}", $"{ConnectionInfo.dbName}_DataAccess_Layer", @"D:\MyClasses\");
            }


            Console.WriteLine("Completed!");
        }
    }
}
