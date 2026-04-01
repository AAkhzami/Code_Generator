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
            /*
                //clsCRUDMethods.strConnectionInfo ConnectionInfo = new clsCRUDMethods.strConnectionInfo();
                //ConnectionInfo.dbName = "Clinic";
                //ConnectionInfo.password = "sa123456";
                //ConnectionInfo.userID = "sa";
                //string Class = clsClassesGenerator.CreateClass("Persons", ConnectionInfo);
                //clsExport.CreateFile(Class, "cls_People_Testing", "cs");
                //Console.WriteLine("Complete!");
                //Console.WriteLine(clsCreateOperationCRUDMethods.WriteSelectAllRecordsQuery(ConnectionInfo.dbName, "Persons"));

            */

            clsDataAccessLayer.strConnectionInfo ConnectionInfo = new clsDataAccessLayer.strConnectionInfo();
            ConnectionInfo.dbName = "Clinic";
            ConnectionInfo.password = "sa123456";
            ConnectionInfo.userID = "sa";

            List<string> ClassesList = clsClassesGenerator.CreateAllClassByDatabaseName(ConnectionInfo);
            List<string> TablesName = clsClassesGenerator.GetAllTablesNameOnDatabase(ConnectionInfo.dbName);

            for (int i = 0; i < ClassesList.Count; i++)
            {
                clsExport.CreateClassWithContent(ClassesList[i], $@"cls_{TablesName[i]}", $"{ConnectionInfo.dbName}_DataAccess_Layer", @"D:\MyClasses\");
            }
            clsExport.CreateClassWithContent(clsClassesGenerator.CreateConnectionSettings(ConnectionInfo), @"clsDataAccessSettings", $"{ConnectionInfo.dbName}_DataAccess_Layer", @"D:\MyClasses\");
            //clsExport.CreateFolder("D:\\MyClasses\\DataAccess");

            Console.WriteLine("Completed!");
        }
    }
}
