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

        enConnectionType _connectionType = enConnectionType.StaticClass;
        string _connectionString = string.Empty;
        string _location = string.Empty;
        string _databaseName = string.Empty;
        string _userName = string.Empty;
        string _password = string.Empty;

        public clsConnectionGenerator(enConnectionType connectionType, string Location, string DatabaseName, string UserName, string Password)
        {
            _connectionType = connectionType;
            _location = Location;
            _databaseName = DatabaseName;
            _userName = UserName;
            _password = Password;
        }

        public string GenerateConnection()
        {
            StringBuilder sb = new StringBuilder();
            switch (_connectionType)
            {
                case enConnectionType.StaticClass:
                    sb.AppendLine("public static class clsConnection");
                    sb.AppendLine("{");
                    sb.AppendLine($"\tpublic static string ConnectionString = \"Server = {_location}; Database = {_databaseName}; User Id = {_userName}; Password = {_password}\";");
                    sb.AppendLine("}");
                    break;
                case enConnectionType.AppConfig:
                    sb.AppendLine("<appSettings >");
                    sb.AppendLine($"<add key = \"MyDbConnection\" value =\"Server={_location};Database={_databaseName};User Id={_userName};Password={_password};\"/>");
                    sb.AppendLine("</appSettings>");
                    break;
            }
            return sb.ToString();
        }

        public string GenerateConnectionString()
        {
            string connectionString = string.Empty;
            switch (_connectionType)
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
