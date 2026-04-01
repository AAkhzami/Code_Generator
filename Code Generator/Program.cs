using Code_Generator_Business_Layer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;
using static Code_Generator_Business_Layer.clsDataAccessLayer;
using System.IO;

namespace Code_Generator
{


    internal class Program
    {
        static void Main(string[] args)
        {


            clsDataAccessLayer.strConnectionInfo ConnectionInfo = new clsDataAccessLayer.strConnectionInfo();
            ConnectionInfo.dbName = "DBName";
            ConnectionInfo.password = "password";
            ConnectionInfo.userID = "userID";

            //Console.WriteLine(clsDataAccessLayer.WriteAddNewRecordMethod("Persons", ConnectionInfo));

            List<string> DataAccessClassesList = clsClassesGenerator.CreateAllDataAccessClasses(ConnectionInfo);
            List<string> TablesName = clsClassesGenerator.GetAllTablesNameOnDatabase(ConnectionInfo.dbName);

            for (int i = 0; i < DataAccessClassesList.Count; i++)
            {
                clsExport.CreateClassWithContent(DataAccessClassesList[i], $@"cls{TablesName[i]}Data", $"{ConnectionInfo.dbName}_DataAccess_Layer", @"D:\MyClasses\");
            }
            clsExport.CreateClassWithContent(clsClassesGenerator.CreateConnectionSettings(ConnectionInfo), @"clsDataAccessSettings", $"{ConnectionInfo.dbName}_DataAccess_Layer", @"D:\MyClasses\");

            List<string> ClassesList = clsClassesGenerator.CreateAllBusinessClasses(ConnectionInfo);

            for (int i = 0; i < ClassesList.Count; i++)
            {
                clsExport.CreateClassWithContent(ClassesList[i], $@"cls{TablesName[i]}", $"{ConnectionInfo.dbName}_Business_Layer", @"D:\MyClasses\");
            }
            Console.WriteLine("Completed!");

        }
    }
}
