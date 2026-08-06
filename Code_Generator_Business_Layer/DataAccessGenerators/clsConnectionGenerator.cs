using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer.DataAccessGenerators
{
    public class clsConnectionGenerator
    {
        public enum enConnectionType
        {
            StaticClass = 0,
            AppConfig = 1,
        }

        public enConnectionType connectionType = enConnectionType.StaticClass;
        public string location = string.Empty;
        public string databaseName = string.Empty;
        public string userName = string.Empty;
        public string password = string.Empty;

        public clsConnectionGenerator(enConnectionType connectionType, string Location, string DatabaseName, string UserName, string Password)
        {
            this.connectionType = connectionType;
            location = Location;
            databaseName = DatabaseName;
            userName = UserName;
            password = Password;
        }
        public clsConnectionGenerator()
        {
            this.connectionType = enConnectionType.StaticClass;
            this.location = ".";
            this.userName = string.Empty;
            this.password = string.Empty;
        }
        public string GenerateConnection()
        {
            StringBuilder sb = new StringBuilder();
            switch (connectionType)
            {
                case enConnectionType.StaticClass:
                    sb.AppendLine("public static class clsConnection");
                    sb.AppendLine("{");
                    sb.AppendLine($"\tpublic static string ConnectionString = \"Server = {location}; Database = {databaseName}; User Id = {userName}; Password = {password}\";");
                    sb.AppendLine("}");
                    break;
                case enConnectionType.AppConfig:
                    sb.AppendLine("<appSettings >");
                    sb.AppendLine($"<add key = \"MyDbConnection\" value =\"Server={location};Database={databaseName};User Id={userName};Password={password};\"/>");
                    sb.AppendLine("</appSettings>");
                    break;
            }
            return sb.ToString();
        }

        public string GenerateConnectionString()
        {
            string connectionString = string.Empty;
            switch (connectionType)
            {
                case enConnectionType.StaticClass:
                    connectionString = $"clsConnection.ConnectionString";
                    break;
                case enConnectionType.AppConfig:
                    connectionString = $"ConfigurationManager.AppSettings[\"MyDbConnection\"]";
                    break;
            }
            return connectionString;
        }
    }
}
