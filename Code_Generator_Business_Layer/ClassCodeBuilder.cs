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
        private readonly iDataAccessGenerator _dataAccessGenerator;

        private readonly string Database;
        private readonly string Table;

        /// <summary>
        /// classCodeBuilder is a constructor that initializes the ClassCodeBuilder class with the specified database, table, class type, and data access generator.
        /// </summary>
        /// <param name="Database">The name of the database.</param>
        /// <param name="Table">The name of the table.</param>
        /// <param name="ClassType">The type of class to generate.</param>
        /// <param name="dataAccessGenerator">The data access generator.</param>
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

            if(operationType.Contains(enOperationType.All))
            {
                sb.Append(_dataAccessGenerator.GenerateDataAccessLayerClass());
            }
            else 
            {
                operationType.ForEach(op =>
                {
                    switch (op)
                    {
                        case enOperationType.Insert:
                            sb.Append(_dataAccessGenerator.GenerateCreateMethod());
                            break;
                        case enOperationType.Update:
                            sb.Append(_dataAccessGenerator.GenerateUpdateMethod());
                            break;
                        case enOperationType.Delete:
                            sb.Append(_dataAccessGenerator.GenerateDeleteMethod());
                            break;
                        case enOperationType.Select:
                            sb.Append(_dataAccessGenerator.GenerateReadMethod());
                            break;
                        case enOperationType.SelectAll:
                            sb.Append(_dataAccessGenerator.GenerateReadAllRecordsMethod());
                            break;
                    }
                });
            }

            return sb.ToString();
        }
        public string GenerateBusinessLayerClass(iBusinessGenerators businessGenerator, clsConnectionGenerator connectionType, List<enOperationType> operationType)
        {
            StringBuilder sb = new StringBuilder();
            clsBusinessLayerGenerator businessLayer = new clsBusinessLayerGenerator(Database, Table);

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");

            if (connectionType.connectionType == clsConnectionGenerator.enConnectionType.AppConfig)
            {
                sb.AppendLine("using System.Configuration;");
            }

            if (operationType.Contains(enOperationType.All))
            {
                sb.Append(businessGenerator.GenerateBusinessLayerClass());
            }
            else
            {
                operationType.ForEach(op =>
                {
                    switch (op)
                    {
                        case enOperationType.Insert:
                            sb.Append(businessGenerator.GenerateCreateMethod());
                            break;
                        case enOperationType.Update:
                            sb.Append(businessGenerator.GenerateUpdateMethod());
                            break;
                        case enOperationType.Delete:
                            sb.Append(businessGenerator.GenerateDeleteMethod());
                            break;
                        case enOperationType.Select:
                            sb.Append(businessGenerator.GenerateReadMethod());
                            break;
                        case enOperationType.SelectAll:
                            sb.Append(businessGenerator.GenerateReadAllMethod());
                            break;
                    }
                });
            }
            return sb.ToString();
        }
    }
}
