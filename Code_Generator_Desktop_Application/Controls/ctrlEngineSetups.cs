using Code_Generator_Business_Layer;
using Code_Generator_Business_Layer.DataAccessGenerators;
using Code_Generator_Business_Layer.DataAccessGenerators.SQLServer;
using Guna.UI2.WinForms;
using System;
using System.Collections;
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

        public Dictionary<clsClassCodeBuilder.enOperationType, bool> Operations = new Dictionary<clsClassCodeBuilder.enOperationType, bool>()
        {
            { clsClassCodeBuilder.enOperationType.SelectAll, true},
            { clsClassCodeBuilder.enOperationType.Select, true},
            { clsClassCodeBuilder.enOperationType.Insert, true},
            { clsClassCodeBuilder.enOperationType.Update, true},
            { clsClassCodeBuilder.enOperationType.Delete, true}
        };


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

        private void ChangeOperationsStatus(object sender, EventArgs e)
        {
            Guna2CheckBox checkBox = (Guna2CheckBox) sender;

            if (checkBox == checkBoxGetAll)
            {
                Operations[clsClassCodeBuilder.enOperationType.SelectAll] = checkBoxGetAll.Checked;
            }
            else if (checkBox == checkBoxGetByID)
            {
                Operations[clsClassCodeBuilder.enOperationType.Select] = checkBoxGetByID.Checked;
            }
            else if (checkBox == checkBoxInsert)
            {
                Operations[clsClassCodeBuilder.enOperationType.Insert] = checkBoxInsert.Checked;
            }
            else if (checkBox == checkBoxUpdate)
            {
                Operations[clsClassCodeBuilder.enOperationType.Update] = checkBoxUpdate.Checked;
            }
            else if (checkBox == checkBoxDelete)
            {
                Operations[clsClassCodeBuilder.enOperationType.Delete] = checkBoxDelete.Checked;
            }
        }
        public List<clsClassCodeBuilder.enOperationType> GetOperations()
        {
            List<clsClassCodeBuilder.enOperationType> operations = new List<clsClassCodeBuilder.enOperationType>();
            foreach (var item in Operations)
            {
                if (item.Value == true)
                {
                    operations.Add(item.Key);
                }
            }


            return operations;
        }
        public void Reset()
        {
            cbConnectionType.SelectedIndex = 0;
            cbExecutionEngine.SelectedIndex = 0;

            checkBoxGetAll.Checked = true;
            checkBoxGetByID.Checked = true;
            checkBoxInsert.Checked = true;
            checkBoxDelete.Checked = true;
            checkBoxUpdate.Checked = true;

            DatabaseType = enDatabaseType.TSQL;
        }
    }
}
