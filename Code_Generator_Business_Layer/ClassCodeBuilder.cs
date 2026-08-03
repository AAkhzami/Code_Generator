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
        /// <summary>
        ///  classType is an enum that specifies the type of class to generate. It can be either DataAccessLayer, BusinessLayer, or Both.
        /// </summary>
        public enum enClassType
        {
            DataAccessLayer = 0,
            BusinessLayer = 1,
            Both = 2,
        }

        public readonly enClassType ClassType;
        private readonly string Database;
        private readonly string Table;

        /// <summary>
        /// classCodeBuilder is a constructor that initializes the ClassCodeBuilder class with the specified database, table, class type, and data access generator.
        /// </summary>
        /// <param name="Database">The name of the database.</param>
        /// <param name="Table">The name of the table.</param>
        /// <param name="ClassType">The type of class to generate.</param>
        /// <param name="dataAccessGenerator">The data access generator.</param>
        public ClassCodeBuilder(string Database, string Table,enClassType ClassType,iDataAccessGenerator dataAccessGenerator)
        {
            this.ClassType = ClassType;
            _dataAccessGenerator = dataAccessGenerator;
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
            All = 4,
        }
        public string GenerateDataAccessLayerClass(clsConnectionGenerator connectionType, List<enOperationType> operationType)
        {
            if(ClassType != enClassType.DataAccessLayer && ClassType != enClassType.Both)
            {
                throw new InvalidOperationException("Cannot generate Data Access Layer class when ClassType is not DataAccessLayer or Both.");
            }

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

            if(operationType.Contains(enOperationType.All))
            {
                sb.Append(dataAccessLayer.GenerateDataAccessLayerClass());
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
                    }
                });
            }

            return sb.ToString();
        }
        public string GenerateBusinessLayerClass(clsConnectionGenerator connectionType, List<enOperationType> operationType)
        {
            StringBuilder sb = new StringBuilder();
            clsBusinessLayerGenerator businessLayer = new clsBusinessLayerGenerator(Database, Table);

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");

            operationType.ForEach(op =>
            {
                switch (op)
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
            });
            return sb.ToString();
        }
    }
}
