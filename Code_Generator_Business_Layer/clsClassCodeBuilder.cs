using Code_Generator_Business_Layer.BusinessGenerators;
using Code_Generator_Business_Layer.DataAccessGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer
{
    public class clsClassCodeBuilder
    {

        private readonly string Database;
        private readonly string Table;

        /// <summary>
        /// classCodeBuilder is a constructor that initializes the ClassCodeBuilder class with the specified database, table, class type, and data access generator.
        /// </summary>
        /// <param name="Database">The name of the database.</param>
        /// <param name="Table">The name of the table.</param>
        public clsClassCodeBuilder(string Database, string Table)
        {
            this.Database = Database;
            this.Table = Table;
        }

        /// <summary>
        /// operationType is an enum that specifies the type of operation to generate. It can be either Insert, Update, Delete, Select, or All.
        /// </summary>
        public enum enOperationType
        {
            Insert = 0,
            Update = 1,
            Delete = 2,
            Select = 3,
            SelectAll = 4,
            All = 5,
        }
        /// <summary>
        ///  statement that generates the data access layer class based on the specified operation type. It uses the provided data access generator and connection information to generate the appropriate code for each operation type.
        /// </summary>
        /// <param name="dataAccessGenerator">The data access generator used to generate the data access layer class.</param>
        /// <param name="connectionInfo">The connection information used to connect to the database.</param>
        /// <param name="operationType">The list of operation types to generate.</param>
        /// <returns>The generated data access layer class as a string.</returns>
        public string GenerateDataAccessLayerClass(iDataAccessGenerator dataAccessGenerator, clsConnectionData connectionInfo, List<enOperationType> operationType)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Data.SqlClient;");

            if (connectionInfo.connectionType == clsConnectionData.enConnectionType.AppConfig)
            {
                sb.AppendLine("using System.Configuration;");
            }


            sb.AppendLine($"namespace {Database}_DataAccess");
            sb.AppendLine("{");
            if(operationType.Contains(enOperationType.All))
            {
                sb.Append(dataAccessGenerator.GenerateDataAccessLayerClass());
            }
            else 
            {
                sb.AppendLine($"public class cls{Table}Data");
                sb.AppendLine("{");
                operationType.ForEach(op =>
                {
                    switch (op)
                    {
                        case enOperationType.Insert:
                            sb.Append(dataAccessGenerator.GenerateCreateMethod());
                            break;
                        case enOperationType.Update:
                            sb.Append(dataAccessGenerator.GenerateUpdateMethod());
                            break;
                        case enOperationType.Delete:
                            sb.Append(dataAccessGenerator.GenerateDeleteMethod());
                            break;
                        case enOperationType.Select:
                            sb.Append(dataAccessGenerator.GenerateReadMethod());
                            break;
                        case enOperationType.SelectAll:
                            sb.Append(dataAccessGenerator.GenerateReadAllRecordsMethod());
                            break;
                    }
                });
                sb.AppendLine("}");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }

        /// <summary>
        ///  statement that generates the business layer class based on the specified operation type. It uses the provided business generator to generate the appropriate code for each operation type.
        /// </summary>
        /// <param name="businessGenerator">The business generator used to generate the business layer class.</param>
        /// <param name="operationType">The list of operation types to generate.</param>
        /// <returns>The generated business layer class as a string.</returns>
        public string GenerateBusinessLayerClass(iBusinessGenerator businessGenerator, List<enOperationType> operationType)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");

            sb.AppendLine($"using {Database}_DataAccess;");

            sb.AppendLine($"namespace {Database}_Business");
            sb.AppendLine("{");
            if (operationType.Contains(enOperationType.All))
            {
                sb.Append(businessGenerator.GenerateBusinessLayerClass());
            }
            else
            {
                sb.AppendLine($"public class cls{Table}");
                sb.AppendLine("{");
                sb.AppendLine(businessGenerator.GenerateProperties());
                sb.AppendLine(businessGenerator.GeneratePublicConstructor());
                sb.AppendLine();
                operationType.ForEach(op =>
                {
                    switch (op)
                    {
                        case enOperationType.Insert:
                            sb.Append(businessGenerator.GenerateCreateMethod());
                            sb.AppendLine();
                            break;
                        case enOperationType.Update:
                            sb.Append(businessGenerator.GenerateUpdateMethod());
                            sb.AppendLine();
                            break;
                        case enOperationType.Delete:
                            sb.Append(businessGenerator.GenerateDeleteMethod());
                            sb.AppendLine();
                            break;
                        case enOperationType.Select:
                            sb.Append(businessGenerator.GenerateReadMethod());
                            sb.AppendLine();
                            break;
                        case enOperationType.SelectAll:
                            sb.Append(businessGenerator.GenerateReadAllMethod());
                            sb.AppendLine();
                            break;
                    }
                });
                
                if(operationType.Contains(enOperationType.Update) && operationType.Contains(enOperationType.Insert))
                {
                    sb.AppendLine(businessGenerator.GeneratePrivateConstructor());
                    sb.AppendLine();
                    sb.Append(businessGenerator.GenerateSaveMethod());
                    sb.AppendLine();
                }
                else if (operationType.Contains(enOperationType.Insert) && !operationType.Contains(enOperationType.Update))
                {
                    sb.Append(businessGenerator.GenerateSaveCreateMethod());
                    sb.AppendLine();
                }
                else if (operationType.Contains(enOperationType.Update) && !operationType.Contains(enOperationType.Insert))
                {
                    sb.Append(businessGenerator.GenerateSaveUpdateMethod());
                    sb.AppendLine();
                }

                sb.AppendLine("}");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }

        /// <summary>
        /// statement that generates the connection string based on the specified connection type. It uses the provided connection information to generate the appropriate code for each connection type.
        /// </summary>
        /// <param name="connectionInfo">The connection information used to generate the connection string.</param>
        /// <returns>The generated connection string as a string.</returns>
        public string GenerateConnection(clsConnectionData connectionInfo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            switch(connectionInfo.connectionType)
            {
                case clsConnectionData.enConnectionType.StaticClass:

                    stringBuilder.AppendLine("using System;");
                    stringBuilder.AppendLine("using System.Data;");
                    stringBuilder.AppendLine($"namespace {connectionInfo.databaseName}_DataAccess");
                    stringBuilder.AppendLine("{");
                    stringBuilder.AppendLine(connectionInfo.GenerateConnection());
                    stringBuilder.AppendLine("}");

                    break;
                case clsConnectionData.enConnectionType.AppConfig:

                    stringBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
                    stringBuilder.AppendLine("<appSettings>");
                    stringBuilder.AppendLine(connectionInfo.GenerateConnection());
                    stringBuilder.AppendLine("</appSettings>");

                    break;
            }

            return stringBuilder.ToString();
        }
    }
}
