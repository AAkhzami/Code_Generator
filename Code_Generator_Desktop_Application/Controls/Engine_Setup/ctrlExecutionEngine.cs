using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Generator_DApp.Controls.Engine_Setup
{
    public partial class ctrlExecutionEngine : UserControl
    {
        public ctrlExecutionEngine()
        {
            InitializeComponent();
        }
        private void ChangeTheOption()
        {
            if (rbStoredProcedures.Checked)
            {
                rbDirectQueries.Checked = true;
                rbStoredProcedures.Checked = false;
                pDirectQueries.BorderColor = Color.FromArgb(85, 128, 230);
                pStoredProcedures.BorderColor = Color.Silver;

                pDirectQueries.FillColor = Color.FromArgb(242, 245, 253);
                pDirectQueries.FillColor2 = Color.FromArgb(242, 245, 253);

                pStoredProcedures.FillColor = Color.FromArgb(254, 254, 254);
                pStoredProcedures.FillColor2 = Color.FromArgb(254, 254, 254);
            }
            else if (rbDirectQueries.Checked)
            {
                rbDirectQueries.Checked = false;
                rbStoredProcedures.Checked = true;

                pStoredProcedures.BorderColor = Color.FromArgb(85, 128, 230);
                pDirectQueries.BorderColor = Color.Silver;

                pStoredProcedures.FillColor = Color.FromArgb(242, 245, 253);
                pStoredProcedures.FillColor2 = Color.FromArgb(242, 245, 253);

                pDirectQueries.FillColor = Color.FromArgb(254, 254, 254);
                pDirectQueries.FillColor2 = Color.FromArgb(254, 254, 254);
            }
        }

        private void pStoredProcedures_Click(object sender, EventArgs e)
        {
            ChangeTheOption();
        }

        private void pDirectQueries_Click(object sender, EventArgs e)
        {
            ChangeTheOption();
        }

        private void rbStoredProcedures_Click(object sender, EventArgs e)
        {
            ChangeTheOption();
        }

        private void rbDirectQueries_Click(object sender, EventArgs e)
        {
            ChangeTheOption();
        }
    }
}
