using Code_Generator_Business_Layer;
using Guna.UI2.WinForms;
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
    public partial class ctrlTablesList : UserControl
    {
        public ctrlTablesList()
        {
            InitializeComponent();
        }
        string _Database = "";
        public bool IsTableHasPrimaryKey = false;
        private void lblMoreDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Generating code for this table may result in limited or unexpected functionality because the generated class will not have a Primary Key to identify records uniquely."
                , "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        public async void LoadData(string Database)
        {
            if (string.IsNullOrEmpty(Database))
            {
                MessageBox.Show("No Database selected!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _Database = Database;
            guna2ProgressIndicator1.AutoStart = true;
            guna2ProgressIndicator1.Visible = true;

            try
            {

                DataTable dt = await clsMainBridge.GetAllTablesInfo(Database);

                Task.WaitAll();

                if (dt.Rows.Count > 0)
                {
                    lblTablesCount.Text = dt.Rows.Count.ToString();
                    foreach(DataRow row in dt.Rows)
                    {
                        dgvTablesName.Rows.Add(row[0], row[1], row[2]);

                    }
                }
                else
                {
                    dgvTablesName.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                guna2ProgressIndicator1.AutoStart = false;
                guna2ProgressIndicator1.Visible = false;
            }

        }

        private async void dgvTablesName_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTablesName.SelectedRows.Count == 0)
            {
                pWarningMessage.Visible = false;
                return;
            }

            var cellValue = dgvTablesName.SelectedRows[0].Cells["cStatus"].Value;


            this.IsTableHasPrimaryKey = ((int)cellValue == 1);

            if (cellValue != null && cellValue != DBNull.Value && int.TryParse(cellValue.ToString(), out int status))
            {
                pWarningMessage.Visible = (status != 1);
            }
            else
            {
                pWarningMessage.Visible = false;
            }

            string tableName = (string)dgvTablesName.SelectedRows[0].Cells["cTable"].Value;

            await _LoadColumnsByTableName(tableName.Trim());
        }
        public void Reset()
        {
            dgvTablesName.Rows.Clear();
            dgvColumnsTable.Rows.Clear();

            lblTablesCount.Text = "0";
            guna2ProgressIndicator1.AutoStart = true;
            guna2ProgressIndicator1.Visible = true;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = txbSearch.Text.Trim().ToLower();

            dgvTablesName.CurrentCell = null;

            foreach (DataGridViewRow row in dgvTablesName.Rows)
            {
                if (row.IsNewRow) continue;

                var cellValue = row.Cells["cTable"].Value?.ToString().ToLower();

                if (string.IsNullOrEmpty(filterText))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = cellValue != null && cellValue.StartsWith(filterText);
                }
            }

        }
        public string GetSelectedTableName()
        {
            if (dgvTablesName.Rows.Count == 0) return null;
            
            string tableName = dgvTablesName.SelectedRows[0].Cells["cTable"].Value.ToString().Trim();
            if(tableName != null && !string.IsNullOrWhiteSpace(tableName))
            {
                return tableName;
            }
            else
            {
                return null;
            }
        }
        private async Task _LoadColumnsByTableName(string TableName)
        {
            if (string.IsNullOrWhiteSpace(_Database))
                return;

            if (dgvColumnsTable.Rows.Count > 0) dgvColumnsTable.Rows.Clear();

            DataTable columns = await clsMainBridge.GetAllColumnsRawInfo(_Database, TableName);
            if(columns.Rows.Count > 0)
            {
                foreach (DataRow row in columns.Rows)
                {
                    dgvColumnsTable.Rows.Add(row["ColumnName"], row["SqlDataType"], row["IsNullable"], row["IsPrimaryKey"]);
                }
            }
        }
    }
}
