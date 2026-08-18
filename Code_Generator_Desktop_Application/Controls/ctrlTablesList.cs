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
    public partial class ctrlTablesList : UserControl
    {
        public ctrlTablesList()
        {
            InitializeComponent();
        }

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

        private void dgvTablesName_SelectionChanged(object sender, EventArgs e)
        {


            if (dgvTablesName.SelectedRows.Count == 0)
            {
                pWarningMessage.Visible = false;
                return;
            }

            var cellValue = dgvTablesName.SelectedRows[0].Cells["cStatus"].Value;


            if (cellValue != null && cellValue != DBNull.Value && int.TryParse(cellValue.ToString(), out int status))
            {
                pWarningMessage.Visible = (status != 1);
            }
            else
            {
                pWarningMessage.Visible = false;
            }
        }
        public void Reset()
        {
            dgvTablesName.Rows.Clear();
            lblTablesCount.Text = "0";
            guna2ProgressIndicator1.AutoStart = true;
            guna2ProgressIndicator1.Visible = true;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if(dgvTablesName.Rows.Count != 0)
            {
                string filterText = txbSearch.Text.Trim();
                DataTable dt = null;

                if (dgvTablesName.DataSource is DataTable dataTable)
                {
                    dt = dataTable;
                }
                else if (dgvTablesName.DataSource is BindingSource bindingSource && bindingSource.DataSource is DataTable bDataTable)
                {
                    dt = bDataTable;
                }
                else if (dgvTablesName.DataSource is DataView dataView)
                {
                    dt = dataView.Table;
                }

                if (!string.IsNullOrWhiteSpace(filterText) && dt != null)
                {
                    dt.DefaultView.RowFilter = string.IsNullOrWhiteSpace(filterText)
                                ? string.Empty
                                : string.Format("Name LIKE '{0}%'", filterText.Replace("'", "''"));
                }
            }
 

        }
    }
}
