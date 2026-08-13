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
    public partial class ctrlConnectionSetting : UserControl
    {
        public ctrlConnectionSetting()
        {
            InitializeComponent();
        }
        private void ChangeTheOption()
        {
            if (rbStaticClass.Checked)
            {
                rbAppConfig.Checked = true;
                rbStaticClass.Checked = false;
                pAppConfig.BorderColor = Color.FromArgb(47, 147, 91);
                pStaticClass.BorderColor = Color.Silver;

                pAppConfig.FillColor = Color.FromArgb(246, 252, 249);
                pAppConfig.FillColor2 = Color.FromArgb(246, 252, 249);

                pStaticClass.FillColor = Color.FromArgb(254, 254, 254);
                pStaticClass.FillColor2 = Color.FromArgb(254, 254, 254);
            }
            else if (rbAppConfig.Checked)
            {
                rbAppConfig.Checked = false;
                rbStaticClass.Checked = true;

                pStaticClass.BorderColor = Color.FromArgb(100, 62, 196);
                pAppConfig.BorderColor = Color.Silver;

                pStaticClass.FillColor = Color.FromArgb(237, 239, 253);
                pStaticClass.FillColor2 = Color.FromArgb(237, 239, 253);

                pAppConfig.FillColor = Color.FromArgb(254, 254, 254);
                pAppConfig.FillColor2 = Color.FromArgb(254, 254, 254);
            }
        }

        private void pDirectQueries_Click(object sender, EventArgs e)
        {
            ChangeTheOption();
        }
        private void pStaticClass_Click(object sender, EventArgs e)
        {
            ChangeTheOption();
        }

        private void rbStaticClass_Click(object sender, EventArgs e)
        {
            ChangeTheOption();
        }

        private void rbAppConfig_Click(object sender, EventArgs e)
        {
            ChangeTheOption();
        }
    }
}
