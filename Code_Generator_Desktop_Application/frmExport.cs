using Code_Generator_Business_Layer;
using Code_Generator_Business_Layer.DataAccessGenerators;
using Code_Generator_Business_Layer.DataAccessGenerators.SQLServer.TSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Code_Generator_DApp
{
    public partial class frmExport : Form
    {
        string _DataAccessClass = "";
        string _BusinessClass = "";
        List<string> _Queries = new List<string>();
        string _Table = "";
        clsConnectionData _Connection;

        string _Locations = null;

        public frmExport(string Table, string DataAccessClass, string BusinessClass, List<string> Queries, clsConnectionData connections)
        {
            InitializeComponent();

            _Table = Table;
            _DataAccessClass = DataAccessClass;
            _BusinessClass = BusinessClass;
            _Queries = Queries;

            tsQueries.Checked = (Queries != null && Queries.Count > 0);
            tsQueries.Enabled = (Queries != null && Queries.Count > 0);

            _Connection = connections;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_Locations))
            {
                MessageBox.Show("Choose export's location!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_Connection == null && (tsConnection.Checked || tsQueries.Checked))
            {
                MessageBox.Show("Database connection details are missing!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (tsDataAccessClass.Checked)
                {
                    clsExport.CreateClassWithContent(_DataAccessClass, $"cls{_Table}Data", "cs", $"{_Connection?.databaseName}_DataAccess", _Locations);
                }

                if (tsBusinessClass.Checked)
                {
                    clsExport.CreateClassWithContent(_BusinessClass, $"cls{_Table}", "cs", $"{_Connection?.databaseName}_Business", _Locations);
                }

                if (tsConnection.Checked)
                {
                    switch (_Connection.connectionType)
                    {
                        case clsConnectionData.enConnectionType.StaticClass:
                            clsExport.CreateClassWithContent(_Connection.GenerateConnection(), "clsConnection", "cs", $"{_Connection.databaseName}_DataAccess", _Locations);
                            break;
                        case clsConnectionData.enConnectionType.AppConfig:
                            clsExport.CreateClassWithContent(_Connection.GenerateConnection(), "App", "config", $"{_Connection.databaseName}_DataAccess", _Locations);
                            break;
                    }
                }

                if (tsQueries.Checked)
                {
                    if (!clsTSqlScriptExecutor.ExecuteScripts(_Queries, _Connection))
                    {
                        MessageBox.Show("Failed to execute T-SQL scripts.", "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MessageBox.Show("Exported Files Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.ValidateNames = false;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;
                dialog.FileName = "Select the folder";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _Locations = System.IO.Path.GetDirectoryName(dialog.FileName);
                }
            }
        }
    }
}
