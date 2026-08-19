using Code_Generator_Business_Layer;
using Code_Generator_Business_Layer.DataAccessGenerators;
using Code_Generator_Business_Layer.DataAccessGenerators.SQLServer;
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
        public enum enDatabaseType
        {
            TSQL = 1,
            SQL = 2
        }
        public enDatabaseType DatabaseType = enDatabaseType.TSQL;

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
            if (type == "Stored Procedures (T-SQL)")
            {
                lblExecutionEngineDetails.Text = "Generates stored procedures and calls them\r\nfrom your C# code. More secure and performant.";
                lblExecutionEngineDetails.ForeColor = Color.FromArgb(43, 89, 209);
                DatabaseType = enDatabaseType.TSQL;
            }
            else if (type == "Ad-hoc Direct Queries")
            {
                lblExecutionEngineDetails.Text = "Executes direct SQL queries in your C# code.\r\nFaster to implement, less abstraction.";
                lblExecutionEngineDetails.ForeColor = Color.FromArgb(254, 243, 221);
                DatabaseType = enDatabaseType.SQL;
            }
        }


        public clsConnectionData.enConnectionType? GetConnectionType()
        {
            string type = cbConnectionType.SelectedItem as string;
            if (type == "App.Config")
            {
                return clsConnectionData.enConnectionType.AppConfig;
            }
            else if (type == "Static Class")
            {
                return clsConnectionData.enConnectionType.StaticClass;
            }
            return null;
        }
    }
}
