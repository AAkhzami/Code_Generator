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
            if (!string.IsNullOrEmpty(DatabaseName))
            {
                DataTable dt = new DataTable();
                DataTable dtTables = clsMainBridge.GetAllTablesByDatabaseName(DatabaseName);
                foreach (DataRow dr in dtTables.Rows)
                {
                    List<clsColumnModelBuilder.strColumnInfo> Columns = clsMainBridge.GetAllColumnsInfo(_Database, dr[0].ToString());
                    string isWithPrimaryKey = Columns.Where(c => c.IsPrimaryKey).ToList().Count > 0 ? "Ready" : "Waring No PK";

                    dgvTablesInfo.Rows.Add(dr[0], Columns.Count, isWithPrimaryKey);
                }
            }
        }

        private void dgvTablesInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTablesInfo.Columns[e.ColumnIndex].Name == "cStatus")
            {
                string status = e.Value?.ToString();

                if (status == "Ready")
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);
                }
                else if (status == "Warning No PK")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                    e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);
                }
            }
        }
    }
}
