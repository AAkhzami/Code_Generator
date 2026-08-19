using Code_Generator_Business_Layer;
using Code_Generator_Business_Layer.DataAccessGenerators;
using Code_Generator_DApp.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Generator_DApp
{
    public partial class frmCodeGeneratorewindows : Form
    {
        public frmCodeGeneratorewindows()
        {
            InitializeComponent();
        }

        string _Database = null;
        clsConnectionData _connectionInfo = null;

        private void GenerateDataAccessLayerClass( List<clsClassCodeBuilder.enOperationType> operations)
        {
            if (_Database != null && _connectionInfo != null && string.IsNullOrWhiteSpace(_Database))
            {
                string table = ctrlTablesList1.GetSelectedTableName();
                ctrlPreviewAndGeneratePage1.LoadAccessDataClass(table, ctrlEngineSetups1.DatabaseType, _connectionInfo, operations);
            }
        }
        private void GenerateBusinessLayerClass(List<clsClassCodeBuilder.enOperationType> operations)
        {
            if(_Database != null && !string.IsNullOrWhiteSpace(_Database))
            {
                ctrlPreviewAndGeneratePage1.LoadBusinessClass(_Database, ctrlTablesList1.GetSelectedTableName(), operations);
            }
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if(cbSelectDatabase.Text == "Select Database")
            {
                MessageBox.Show("No Database selected!", "Not Allowed", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            List<clsClassCodeBuilder.enOperationType> operations = ctrlEngineSetups1.GetOperations();

            _connectionInfo = new clsConnectionData(ctrlEngineSetups1.GetConnectionType() ?? clsConnectionData.enConnectionType.StaticClass
                , ".", cbSelectDatabase.Text, "sa", "sa123456");

            GenerateDataAccessLayerClass(operations);
            GenerateBusinessLayerClass(operations);
            ctrlPreviewAndGeneratePage1.LoadConnectionText(_connectionInfo);

            tbPages.SelectedIndex = 1;
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tbPages.SelectedIndex = 0;
        }

        private async void frmCodeGeneratorewindows_Load(object sender, EventArgs e)
        {
            DataTable dt = await clsMainBridge.GetAllDatabaseNameInCurrentDevise();
            foreach (DataRow dr in dt.Rows)
            {
                cbSelectDatabase.Items.Add(dr[0]);
            }
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            cbSelectDatabase.Items.Add("Select Database");
            cbSelectDatabase.SelectedIndex = 0;
            DataTable dt = await clsMainBridge.GetAllDatabaseNameInCurrentDevise();
            foreach (DataRow dr in dt.Rows)
            {
                cbSelectDatabase.Items.Add(dr[0]);
            }

            tbPages.SelectedIndex = 0;
            ctrlPreviewAndGeneratePage1.Reset();
            ctrlEngineSetups1.Reset();

            _Database = null;
            _connectionInfo = null;

        }

        private async void cbSelectDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSelectDatabase.Text != "Select Database")
                {
                    ctrlTablesList1.LoadData(cbSelectDatabase.Text);
                    _Database = cbSelectDatabase.Text;
                }
                else
                {
                    btnReset_Click(null, null);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string dataAccessClass = ctrlPreviewAndGeneratePage1.DataAccessClass();
            string businessClass = ctrlPreviewAndGeneratePage1.BusinessClass();
            string queries = ctrlPreviewAndGeneratePage1.Queries();
            string connection = ctrlPreviewAndGeneratePage1.ConnectionsText();

            string table = ctrlTablesList1.GetSelectedTableName();
            List<string> tables = new List<string>();
            //frmExport frm = new frmExport(table, dataAccessClass, businessClass, tables, connection);
        }
    }
}
