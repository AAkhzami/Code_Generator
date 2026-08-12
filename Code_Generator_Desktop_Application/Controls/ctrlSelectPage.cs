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
        public void Reset()
        {
            dgvTablesInfo.Rows.Clear();
            _ColumnsCount = 0;
            _TablesCount = 0;
            _CountTablesHavePK = 0;
            lblColumns.Text = "0";
            lblKeysCount.Text = "0";
            lblTableCount.Text = "0";
        }
        public async Task LoadData(string Database)
        {
            Reset();
            if (string.IsNullOrEmpty(Database))
                return;

            DataTable dt = await clsMainBridge.GetAllTablesInfo(Database);
            
            int _ColumnsCount = 0;
            int _TablesCount = 0;
            int _CountTablesHavePK = 0;
            string isWithPrimaryKey = "";

            foreach (DataRow dr in dt.Rows)
            {
                _TablesCount++;
                _ColumnsCount += (int)dr[1];
                if (Convert.ToBoolean(dr[2]))
                {
                    _CountTablesHavePK++;
                }
                isWithPrimaryKey = Convert.ToBoolean(dr[2]) ? "Ready" : "Warning No PrimaryKey";
                dgvTablesInfo.Rows.Add(dr[0], (int)dr[1], isWithPrimaryKey);

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

        private void ctrlSelectPage_Load(object sender, EventArgs e)
        {
            lblColumns.Text = "0";
            lblKeysCount.Text = "0";
            lblTableCount.Text = "0";
        }
    }
}
