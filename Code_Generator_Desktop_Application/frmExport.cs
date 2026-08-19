using Code_Generator_Business_Layer.DataAccessGenerators;
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
    public partial class frmExport : Form
    {
        string _DataAccessClass = "";
        string _Business = "";
        string _Queries = "";
        clsConnectionData _Connection;
        public frmExport(string DataAccessClass, string BusinessClass, string Queries, clsConnectionData connections)
        {
            InitializeComponent();

            _DataAccessClass = DataAccessClass;
            _Business = BusinessClass;
            _Queries = Queries;
            _Connection = connections;
        }
    }
}
