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
    public partial class frmCodeGeneratorewindows : Form
    {
        public frmCodeGeneratorewindows()
        {
            InitializeComponent();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
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
        }
    }
}
