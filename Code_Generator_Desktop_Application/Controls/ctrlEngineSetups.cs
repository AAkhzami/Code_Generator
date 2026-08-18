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

        private void cbExecutionEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = cbExecutionEngine.SelectedItem as string;
            if (type == "Stored Procedures(T-SQL)")
            {
                lblConnectionDetails.Text = "Generates stored procedures and calls them\r\nfrom your C# code. More secure and performant.";
                lblConnectionDetails.ForeColor = Color.FromArgb(43, 89, 209);
            }
            else if (type == "Ad-hoc Direct Queries")
            {
                lblConnectionDetails.Text = "Executes direct SQL queries in your C# code.\r\nFaster to implement, less abstraction.";
                lblConnectionDetails.ForeColor = Color.FromArgb(254, 243, 221);
            }
        }
    }
}
