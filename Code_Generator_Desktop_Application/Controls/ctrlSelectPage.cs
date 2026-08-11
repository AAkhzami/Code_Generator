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
        int _ColumnsCount = 0;
        int _TablesCount = 0;
        int _CountTablesHavePK = 0;
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
                int CountColumns = 0;
                string isWithPrimaryKey = "";
                foreach (DataRow dr in dtTables.Rows)
                {
                    _TablesCount++;
                    List<clsColumnModelBuilder.strColumnInfo> Columns = clsMainBridge.GetAllColumnsInfo(_Database, dr[0].ToString());
                    CountColumns = Columns.Count;
                    _ColumnsCount += CountColumns;

                    if(Columns.Where(c => c.IsPrimaryKey).ToList().Count > 0)
                    {
                        isWithPrimaryKey = "Ready";
                        _CountTablesHavePK++;
                    }
                    else
                    {
                        isWithPrimaryKey = "Warning No PK";
                    }

                    dgvTablesInfo.Rows.Add(dr[0], Columns.Count, isWithPrimaryKey);
                    isWithPrimaryKey = "";
                }
            }
            lblColumns.Text = _ColumnsCount.ToString();
            lblKeysCount.Text = _CountTablesHavePK.ToString();
            lblTableCount.Text = _TablesCount.ToString();
        }

        private void dgvTablesInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTablesInfo.Columns[e.ColumnIndex].Name == "cStatus")
            {
                string status = e.Value?.ToString();

                if (status == "Ready")
                {
                    //e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(108, 172, 132);
                    e.CellStyle.Font = new Font("Segoe UI", 18, FontStyle.Bold);

                }
                else if (status == "Warning No PK")
                {
                    //e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                    e.CellStyle.ForeColor = Color.FromArgb(206, 146, 66);
                    e.CellStyle.Font = new Font("Segoe UI", 18, FontStyle.Bold);

                }
            }
        }
    }
}
