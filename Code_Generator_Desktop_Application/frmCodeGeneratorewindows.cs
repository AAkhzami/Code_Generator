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
    }
}
