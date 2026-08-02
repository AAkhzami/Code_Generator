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
            switch(operationType)
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
                    sb.Append(dataAccessLayer.GenerateDataAccessLayer());
                    break;
            }
            return sb.ToString();
        }
    }
}
