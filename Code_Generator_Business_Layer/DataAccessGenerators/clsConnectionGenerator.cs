using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer.DataAccessGenerators
{
    internal class clsConnectionGenerator
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
    }
}
