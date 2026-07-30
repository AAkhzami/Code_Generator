using Code_Generator_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer
{
    public class clsMainBridge
    {
        static public DataTable GetAllDatabaseNameInCurrentDevise()
        {
            return clsUserDatabasesData.GetAllDatabasesOnDevice();
        }
        static public DataTable GetAllTablesByDatabaseName(string Database)
        {
            return clsTablesInfoData.GetAllTablesNameByDatabaseName(Database);
        }
        static public DataTable GetAllColumnsRawInfo(string Database, string Table)
        {
            return clsColumnsData.GetAllColumnsInfoByTableName(Database,Table);
        }
        static public List<clsColumnModelBuilder.strColumnInfo> GetAllColumnsInfo(string Database, string Table)
        {
            clsColumnModelBuilder cm = new clsColumnModelBuilder(Database, Table);
            return cm.GetAllColumnsInfo();
        }
    }
}
