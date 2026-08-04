using Code_Generator_Business_Layer.BusinessGenerators;
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

        private readonly string Database;
        private readonly string Table;

        /// <summary>
        /// classCodeBuilder is a constructor that initializes the ClassCodeBuilder class with the specified database, table, class type, and data access generator.
        /// </summary>
        /// <param name="Database">The name of the database.</param>
        /// <param name="Table">The name of the table.</param>
        public ClassCodeBuilder(string Database, string Table)
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
        public string GenerateDataAccessLayerClass(iDataAccessGenerator dataAccessGenerator, clsConnectionGenerator connectionType, List<enOperationType> operationType)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Data.SqlClient;");

            if (connectionType.connectionType == clsConnectionGenerator.enConnectionType.AppConfig)
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
        public string GenerateBusinessLayerClass(iBusinessGenerators businessGenerator, List<enOperationType> operationType)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");

            sb.AppendLine($"using {Database}_DataAccess;");

            sb.AppendLine($"namespace {Database}_BusinessLayer");
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
                sb.AppendLine("}");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
