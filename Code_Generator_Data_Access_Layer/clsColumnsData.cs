using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Code_Generator_Data_Access_Layer
{
    public class clsColumnsData
    {
        static public DataTable GetAllColumnsInfoByTableName(string DatabaseName,string TableName)
        {
            DataTable dt = new DataTable();
            string query = $@"
                        with cte_pk as
						(
							select 
							ic.column_id,
							i.object_id
							from sys.index_columns ic
							inner join sys.indexes i on
							ic.object_id = i.object_id
						),
						cte_uq as
						(
							select ic.column_id, ic.object_id from sys.indexes i
							inner join sys.index_columns ic on
							i.object_id = ic.object_id AND ic.index_id = i.index_id
							where i.is_unique = 1 AND i.is_primary_key = 0
						)

						select 
							c.column_id as ColumnID,
							c.name as ColumnName,
							TYPE_NAME(c.system_type_id) as SqlDataType,
							c.max_length as MaxLength,
							c.is_nullable as IsNullable,
							dc.definition as DefaultValue,
							case 
								when pk.column_id IS not null then 1 else 0 
							end as IsPrimaryKey,
							case 
								when fk.parent_column_id is not null then 1 else 0
							end as IsForeignKey,
							OBJECT_NAME(fk.referenced_object_id) as ReferencedTable,
							case
								when uq.column_id is not null then 1 else 0
							end as IsUnique
						from sys.columns c
						left join sys.default_constraints dc on
							c.default_object_id = dc.object_id
						left join cte_pk pk on
							c.column_id = pk.column_id and c.object_id = pk.object_id
						left join sys.foreign_key_columns fk on
							fk.parent_object_id = c.object_id AND fk.parent_column_id = c.column_id
						left join cte_uq uq on
							uq.object_id = c.object_id and uq.column_id = c.column_id
						where c.object_id = OBJECT_ID(@TableName)";

            using (SqlConnection connection = new SqlConnection(clsDataAccessConnections.ConnectionsString.Replace("master", DatabaseName)))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TableName", TableName);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dt.Load(reader);                        
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return dt;
        }
    }
}
