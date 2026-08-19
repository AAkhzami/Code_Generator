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
        string _Business = "";
        List<string> _Queries = new List<string>();
        string _Table = "";
        clsConnectionData _Connection;

        string _Locations = null;

        public frmExport(string Table, string DataAccessClass, string BusinessClass, List<string> Queries, clsConnectionData connections)
        {
            InitializeComponent();

            _Table = Table;
            _DataAccessClass = DataAccessClass;
            _Business = BusinessClass;
            _Queries = Queries;

            tsQueries.Checked = (Queries.Count > 0);

            _Connection = connections;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(_Locations))
            {
                MessageBox.Show("Choose export's location!","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (tsDataAccessClass.Checked)
                {
                    clsExport.CreateClassWithContent(_DataAccessClass, $"cls{_Table}Data", "cs", "DataAccess_Layer", _Locations);
                }

                if (tsBusinessClass.Checked)
                {
                    clsExport.CreateClassWithContent(_Business, $"cls{_Table}", "cs", "Business_Layer", _Locations);
                }
                
                if (tsConnection.Checked)
                {
                    switch (_Connection.connectionType)
                    {
                        case clsConnectionData.enConnectionType.StaticClass:
                            clsExport.CreateClassWithContent(_Connection.GenerateConnection(), $"clsConnection", "cs", "DataAccess_Layer", _Locations);
                            break;
                        case clsConnectionData.enConnectionType.AppConfig:
                            clsExport.CreateClassWithContent(_Connection.GenerateConnection(), $"App", "config", "DataAccess_Layer", _Locations);
                            break;
                    }
                }

                if (tsQueries.Checked)
                {
                    if (_Connection != null)
                    {
                        if (!clsTSqlScriptExecutor.ExecuteScripts(_Queries, _Connection))
                        {
                            throw new ArgumentException("An error occurred while executing queries in the databases.");
                        }
                    }
                }

                MessageBox.Show("");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An Error occurred: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
