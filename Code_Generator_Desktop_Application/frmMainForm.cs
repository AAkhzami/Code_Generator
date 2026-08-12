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

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            DataTable dt = clsMainBridge.GetAllDatabaseNameInCurrentDevise();
            foreach (DataRow dr in dt.Rows)
            {
                cbSelectDatabase.Items.Add(dr[0]);
            }
        }

        private void cbSelectDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ctrlSelectPage1.LoadData(cbSelectDatabase.Text);
        }
    }
}
