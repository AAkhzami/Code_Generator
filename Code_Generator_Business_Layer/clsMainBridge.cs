using Code_Generator_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator_Business_Layer
{
    /// <summary>
    /// Acts as a central facade/bridge providing static access to database schema information, table structures, and column metadata.
    /// </summary>
    public class clsMainBridge
    {
        /// <summary>
        /// Retrieves a <see cref="DataTable"/> containing all user database names available on the local device/server instance.
        /// </summary>
        /// <returns>A <see cref="DataTable"/> listing the accessible database names.</returns>
        static public async Task<DataTable> GetAllDatabaseNameInCurrentDevise()
        {
            return await clsUserDatabasesData.GetAllDatabasesOnDevice();
        }

        /// <summary>
        /// Retrieves a <see cref="DataTable"/> containing all table names within a specified database.
        /// </summary>
        /// <param name="Database">The target database name.</param>
        /// <returns>A <see cref="DataTable"/> listing table names belonging to the specified database.</returns>
        static public DataTable GetAllTablesByDatabaseName(string Database)
        {
            return clsTablesInfoData.GetAllTablesNameByDatabaseName(Database);
        }

        /// <summary>
        /// Retrieves raw schema metadata as a <see cref="DataTable"/> for all columns in a given table.
        /// </summary>
        /// <param name="Database">The target database name.</param>
        /// <param name="Table">The target table name.</param>
        /// <returns>A <see cref="DataTable"/> containing raw database column schema attributes.</returns>
        static public async Task<DataTable> GetAllColumnsRawInfo(string Database, string Table)
        {
            return await clsColumnsData.GetAllColumnsInfoByTableNameAsync(Database,Table);
        }

        /// <summary>
        /// Retrieves structured metadata objects for all columns in a given table.
        /// </summary>
        /// <param name="Database">The target database name.</param>
        /// <param name="Table">The target table name.</param>
        /// <returns>A <see cref="List{T}"/> of <see cref="clsColumnModelBuilder.strColumnInfo"/> representing populated column models.</returns>
        static public List<clsColumnModelBuilder.strColumnInfo> GetAllColumnsInfo(string Database, string Table)
        {
            clsColumnModelBuilder cm = new clsColumnModelBuilder(Database, Table);
            return cm.GetAllColumnsInfo();
        }
        /// <summary>
        /// Retrieves a <see cref="DataTable"/> containing all table info within a specified database
        /// </summary>
        /// <param name="Database">The target database name.</param>
        /// <returns>A <see cref="DataTable"/> listing table names belonging to the specified database.</returns>
        static public async Task<DataTable> GetAllTablesInfo(string Database)
        {
            return await clsTablesInfoData.GetAllTablesInfoByDatabaseName(Database);
        }
    }
}
