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
    public partial class ctrlEngineSetups : UserControl
    {
        public ctrlEngineSetups()
        {
            InitializeComponent();
        }

        private void cbConnectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = cbConnectionType.SelectedItem as string;
            if(type == "App.Config")
            {
                lblConnectionDetails.Text = "Store connection string in App.Config file.";
                lblConnectionDetails.ForeColor = Color.FromArgb(47, 148, 91);
            }
            else if (type == "Static Class")
            {
                lblConnectionDetails.Text = "Manage connection string in a static class.";
                lblConnectionDetails.ForeColor = Color.FromArgb(100, 62, 196);
            }
        }
    }
}
