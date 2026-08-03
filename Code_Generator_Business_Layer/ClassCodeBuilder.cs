using Code_Generator_Business_Layer.DataAccessGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer
{
    internal class ClassCodeBuilder
    {
        public enum enOperationType
        {
            Insert = 0,
            Update = 1,
            Delete = 2,
            Select = 3,
            All = 4,
        }
        public static string GenerateDataAccessLayerClass(string Database, string Table, clsConnectionGenerator connectionType, enOperationType operationType)
        {
            StringBuilder sb = new StringBuilder();
            clsSQLServerDataAccessLayerGenerator dataAccessLayer = new clsSQLServerDataAccessLayerGenerator(Database, Table, connectionType);

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Data.SqlClient;");

            if (connectionType.connectionType == clsConnectionGenerator.enConnectionType.AppConfig)
            {
                sb.AppendLine("using System.Configuration;");
            }

            switch (operationType)
            {
                case enOperationType.Insert:
                    sb.Append(dataAccessLayer.GenerateCreateMethod());
                    break;
                case enOperationType.Update:
                    sb.Append(dataAccessLayer.GenerateUpdateMethod());
                    break;
                case enOperationType.Delete:
                    sb.Append(dataAccessLayer.GenerateDeleteMethod());
                    break;
                case enOperationType.Select:
                    sb.Append(dataAccessLayer.GenerateReadMethod());
                    break;
                case enOperationType.All:
                    sb.Append(dataAccessLayer.GenerateDataAccessLayerClass());
                    break;
            }
            return sb.ToString();
        }
        public static string GenerateBusinessLayerClass(string Database, string Table, clsConnectionGenerator connectionType, enOperationType operationType)
        {
            StringBuilder sb = new StringBuilder();
            clsBusinessLayerGenerator businessLayer = new clsBusinessLayerGenerator(Database, Table);
            switch (operationType)
            {
                case enOperationType.Insert:
                    sb.Append(businessLayer.GenerateCreateMethod());
                    break;
                case enOperationType.Update:
                    sb.Append(businessLayer.GenerateUpdateMethod());
                    break;
                case enOperationType.Delete:
                    sb.Append(businessLayer.GenerateDeleteMethod());
                    break;
                case enOperationType.Select:
                    sb.Append(businessLayer.GenerateReadMethod());
                    break;
                case enOperationType.All:
                    sb.Append(businessLayer.GenerateBusinessLayerClass());
                    break;
            }
            return sb.ToString();
        }
    }
}
