using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer.DataAccessGenerators.SQLServer.TSQL
{
    public class clsTSqlScriptExecutor
    {
        public static bool ExecuteScript(string script, clsConnectionData connectionInfo)
        {
            return ExecuteScripts(new List<string> { script}, connectionInfo);                 
        }

        public static bool ExecuteScripts(List<string> scripts, clsConnectionData connectionInfo)
        {
             string connectionString;

            connectionString = $"Server={connectionInfo.location};Database={connectionInfo.databaseName};User Id={connectionInfo.userName};Password={connectionInfo.password};";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (string script in scripts)
                    {
                        using (SqlCommand command = new SqlCommand(script, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
            
        }
    }
}
