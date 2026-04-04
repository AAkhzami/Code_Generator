using Code_Generator_Business_Layer;
using Code_Generator_DApp.General_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Code_Generator_DApp
{
    public partial class frmShowAllDatabase : Form
    {
        DataTable _dtDatabase;
        string _FolderPath = string.Empty;
        string _DatabaseName = "";
        public frmShowAllDatabase()
        {
            InitializeComponent();
        }

        private void frmShowAllDatabase_Load(object sender, EventArgs e)
        {
            tpTablesSelector.Enabled = false;
            groupBox1.Enabled = false;

            _dtDatabase = clsGlobal.GetAllDatabase();
            dgvListOfDatabase.DataSource = _dtDatabase;
            if (dgvListOfDatabase.Rows.Count > 0)
            {
                dgvListOfDatabase.Columns[0].Name = "Database Name";
                dgvListOfDatabase.Columns[0].Width = 425;
            }
            else
            {
                btnNext1.Enabled = false;
                MessageBox.Show("No Data to show!", "Not allowed!", MessageBoxButtons.OK);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            int cn = int.Parse(lblCNumber.Text);
            if (checkBox1.Checked)
            {
                if (cn > 0)
                {
                    dgvTables.Enabled = false;
                    groupBox1.Enabled = true;
                    dgvTables.SelectAll();
                }
                else
                {
                    MessageBox.Show("No Tables to select! chose anouther database with Tables.", "Not allowed", MessageBoxButtons.OK);
                }
            }
            else
            {
                dgvTables.ClearSelection();

                dgvTables.Rows[0].Selected = true;
                dgvTables.Enabled = true;
            }
        }

        private void dgvColumns_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dgvTables.SelectedRows[0].Cells[0].Value.ToString();
            MessageBox.Show(name);
        }

        private void dgvListOfDatabase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dgvListOfDatabase.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("Are you sure that you want to continue with this database?", "Confirm", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                tpTablesSelector.Enabled = true;
                tc.SelectedTab = tc.TabPages["tpTablesSelector"];
                _LoadTablesData(name);
            }
        }

        private void dgvListOfDatabase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnNext1.Enabled = true;
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            string name = dgvListOfDatabase.CurrentRow.Cells[0].Value.ToString();
            tpTablesSelector.Enabled = true;
            tc.SelectedTab = tc.TabPages["tpTablesSelector"];
            clsCurrentUser.ConnectionInfo.dbName = name;
            _LoadTablesData(name);
        }
        private void _LoadTablesData(string DatabaseName)
        {
            lblDatabaseName.Text = DatabaseName;
            DataTable dt = clsGlobal.GetAllTablesOnDatabaseTable(DatabaseName);
            _DatabaseName = DatabaseName;

            if (dt.Rows.Count > 0)
            {
                dgvTables.DataSource = dt;

                dgvTables.Columns[0].Name = "Table Name";
                dgvTables.Columns[0].Width = 425;

                lblCNumber.Text = dt.Rows.Count.ToString();
            }

        }
        private void _LoadColumnsData(string Database, string Table)
        {
            DataTable dt = clsGlobal.GetAllColumnsByTableNameTable(Database, Table);

            if (dt.Rows.Count > 0)
            {
                dgvColumnsList.DataSource = dt;
            }
        }
        private void btnChooseLocation_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Please select the folder where you want to save the files.";
            folderBrowserDialog1.ShowNewFolderButton = true;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(folderBrowserDialog1.SelectedPath);
                _FolderPath = folderBrowserDialog1.SelectedPath;
                btnCreate.Enabled = true;
            }
        }
        private void dgvTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tableName = dgvTables.CurrentRow.Cells[0].Value.ToString();
            if (!string.IsNullOrWhiteSpace(_DatabaseName))
            {
                _LoadColumnsData(_DatabaseName, tableName);
                groupBox1.Enabled = true;
                btnCreate.Enabled = true;
            }
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (cbDL.Checked || cbBL.Checked)
            {
                if (MessageBox.Show("Are you sure ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _CreateFiles();
                }
            }
            else
            {
                MessageBox.Show("You should select at least one layer.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _CreateDataLayer(string DatabaseName, List<string> DataAccessClassesList, List<string> TablesName, string FolderPath)
        {
            for (int i = 0; i < DataAccessClassesList.Count; i++)
            {
                clsExport.CreateClassWithContent(DataAccessClassesList[i], $@"cls{TablesName[i]}Data", $"{DatabaseName}_DataAccess_Layer", FolderPath);
            }
        }
        private void _CreateBusinessLayer(string DatabaseName, List<string> ClassesList, List<string> TablesName, string FolderPath)
        {
            for (int i = 0; i < ClassesList.Count; i++)
            {
                clsExport.CreateClassWithContent(ClassesList[i], $@"cls{TablesName[i]}", $"{DatabaseName}_Business_Layer", FolderPath);
            }
        }
        private void _CreateFiles()
        {
            clsGlobal.strConnectionInfo ConnectionInfo = clsCurrentUser.ConnectionInfo;
            List<string> DatabaseLayerClasses = new List<string>();
            List<string> BusinessLayerClasses = new List<string>();
            List<string> TablesName = new List<string>();

            if (dgvTables.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in dgvTables.SelectedCells)
                {
                    TablesName.Add(cell.Value.ToString());

                    if (cbDL.Checked)
                        DatabaseLayerClasses.Add(clsClassesGenerator.CreateDataAccessClass(ConnectionInfo, cell.Value.ToString()));

                    if (cbBL.Checked)
                        BusinessLayerClasses.Add(clsClassesGenerator.CreateBusinessClass(ConnectionInfo, cell.Value.ToString()));

                }

                if(cbDL.Checked)
                    _CreateDataLayer(_DatabaseName, DatabaseLayerClasses, TablesName, _FolderPath);
                
                if(cbBL.Checked)
                    _CreateBusinessLayer(_DatabaseName, BusinessLayerClasses, TablesName, _FolderPath);

            }

            MessageBox.Show("Files are created successfully!", "Created Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
