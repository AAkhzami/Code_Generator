using Code_Generator_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Generator_DApp.Controls
{
    public partial class ctrlSelectPage : UserControl
    {
        string _Database;
        public ctrlSelectPage()
        {
            InitializeComponent();
        }
        public void _LoadData(string DatabaseName)
        {
            this._Database = DatabaseName;
            if (string.IsNullOrEmpty(DatabaseName))
            {
                ctrlSelectPage_Load(null,null);
            }
        }
        private void ctrlSelectPage_Load(object sender, EventArgs e)
        {
            
            
            DataTable dt = new DataTable();
            DataTable dtTables = clsMainBridge.GetAllTablesByDatabaseName(dt.TableName);

            if(dtTables.Rows.Count > 0)
            {
                dgvTablesInfo.Columns[0].Name = "Table";
                dgvTablesInfo.Columns[0].Width = 373;
                dgvTablesInfo.Columns[1].Name = "Columns";
                dgvTablesInfo.Columns[1].Width = 374;
                dgvTablesInfo.Columns[2].Name = "Status";
                dgvTablesInfo.Columns[2].Width = 373;

                foreach (DataRow dr in dtTables.Rows)
                {                    
                    List<clsColumnModelBuilder.strColumnInfo> Columns = clsMainBridge.GetAllColumnsInfo(_Database, dr[0].ToString());
                    string isWithPrimaryKey = Columns.Where(c => c.IsPrimaryKey).ToList().Count > 0 ? "Ready" : "Waring No PK";

                    dgvTablesInfo.Rows.Add(dr[0], Columns.Count, isWithPrimaryKey);
                }
            }
        }
    }
}
