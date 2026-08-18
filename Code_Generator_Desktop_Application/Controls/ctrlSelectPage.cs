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
        public ctrlSelectPage()
        {
            InitializeComponent();
        }
        public void Reset()
        {
            dgvTablesInfo.Rows.Clear();
            lblColumns.Text = "0";
            lblKeysCount.Text = "0";
            lblTableCount.Text = "0";
            txbSearchOnTable.Text = "";

        }
        public async Task LoadData(string Database)
        {
            Reset();
            if (string.IsNullOrEmpty(Database))
                return;

            DataTable dt = await clsMainBridge.GetAllTablesInfo(Database);
            
            int ColumnsCount = 0;
            int TablesCount = 0;
            int CountTablesHavePK = 0;
            string CountPKTable = "";

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TablesCount++;
                    ColumnsCount += (int)dr[1];
                    if (Convert.ToBoolean(dr[2]))
                    {
                        CountTablesHavePK++;
                    }
                    CountPKTable = Convert.ToBoolean(dr[2]) ? "Ready" : "Warning No PrimaryKey";
                    dgvTablesInfo.Rows.Add(dr[0], (int)dr[1], CountPKTable);

                }           
                cbsSelectAllTables.Enabled = true;
            }
            else
            {
                cbsSelectAllTables.Enabled = false;
            }

            lblColumns.Text = ColumnsCount.ToString();
            lblKeysCount.Text = CountTablesHavePK.ToString();
            lblTableCount.Text = TablesCount.ToString();
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

        private void ctrlSelectPage_Load(object sender, EventArgs e)
        {
            lblColumns.Text = "0";
            lblKeysCount.Text = "0";
            lblTableCount.Text = "0";
            cbsSelectAllTables.Checked = false;
            cbsSelectAllTables.Enabled = false;

        }

        public List<string> GetSelectedTableName()
        {
            DataGridViewSelectedRowCollection rows = dgvTablesInfo.SelectedRows;
            List<string> tablesName = new List<string>();
            
            if(rows.Count > 0)
            {
                string tableName = "";
                foreach (DataGridViewRow item in rows)
                {
                    tableName = item.Cells["cTable"].Value.ToString();
                    if (item.Cells["cStatus"].Value.ToString() != "Ready")
                    {
                        if (
                            MessageBox.Show($"Warning: The selected table ({tableName}) does not contain a Primary Key.\nGenerating code for this table may result in limited or unexpected functionality because the generated class will not have a Primary Key to identify records uniquely.\nDo you want to continue?",
                            "Warning",
                            MessageBoxButtons.YesNo,MessageBoxIcon.Warning) 
                            == DialogResult.No)
                        {
                            continue;
                        }
                    }

                    tablesName.Add(tableName);

                }
            }

            return tablesName;
        }

        private void cbsSelectAllTables_CheckedChanged(object sender, EventArgs e)
        {
            if(cbsSelectAllTables.Checked)
            {
                dgvTablesInfo.SelectAll();
                dgvTablesInfo.Enabled = false;
            }
        }
    }
}
