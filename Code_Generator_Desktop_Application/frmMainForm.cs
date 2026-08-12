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

namespace Code_Generator_DApp
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void ctrlSelectPage1_Load(object sender, EventArgs e)
        {

        }

        private async void frmMainForm_Load(object sender, EventArgs e)
        {
            DataTable dt = await clsMainBridge.GetAllDatabaseNameInCurrentDevise();
            foreach (DataRow dr in dt.Rows)
            {
                cbSelectDatabase.Items.Add(dr[0]);
            }
        }

        private async void cbSelectDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbSelectDatabase.Text != "Select Database")
            {
                await ctrlSelectPage1.LoadData(cbSelectDatabase.Text);
            }
            else
            {
                ctrlSelectPage1.Reset();
            }
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            cbSelectDatabase.Items.Clear();
            cbSelectDatabase.Items.Add("Select Database");
            cbSelectDatabase.SelectedIndex = 0;
            DataTable dt = await clsMainBridge.GetAllDatabaseNameInCurrentDevise();
            foreach (DataRow dr in dt.Rows)
            {
                cbSelectDatabase.Items.Add(dr[0]);
            }
            ctrlSelectPage1.Reset();
            
        }
    }
}
