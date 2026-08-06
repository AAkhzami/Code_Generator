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
        public static bool ExecuteScript(string script, string connectionString)
        {
            return ExecuteScripts(new List<string> { script}, connectionString);                 
        }

        public static bool ExecuteScripts(List<string> scripts, string connectionString)
        {            
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
