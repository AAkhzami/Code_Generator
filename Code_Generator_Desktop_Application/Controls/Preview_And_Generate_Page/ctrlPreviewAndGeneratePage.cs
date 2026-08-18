using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Generator_DApp.Controls.Preview_And_Generate_Page
{
    public partial class ctrlPreviewAndGeneratePage : UserControl
    {

        private string _DataAccessClass = "DataAccessClass";
        private string _BusinessLayerClass = "BusinessLayerClass";
        private string _Queries = "Queries";
        private string _Connection = "ConnectionType";
        public string DataAccessClass
        {
            get
            {
                return _DataAccessClass;
            }
            set
            {
                _DataAccessClass = value;
                tbCodesGenerator.TabPages["tpDataAccessClass"].Text = _DataAccessClass;
            }
        }
        public string BusinessLayerClass
        {
            get
            {
                return _BusinessLayerClass;
            }
            set
            {
                _BusinessLayerClass = value;
                tbCodesGenerator.TabPages["tbBusinessLayerClass"].Text = _BusinessLayerClass;
            }
        }
        public string Querys
        {
            get
            {
                return _Queries;
            }
            set
            {
                _Queries = value;                
                tbCodesGenerator.TabPages["tpQueries"].Text = _BusinessLayerClass;
            }
        }
        public string Connection
        {
            get
            {
                return _Connection;
            }
            set
            {
                _Connection = value;                
                tbCodesGenerator.TabPages["tpConnection"].Text = _BusinessLayerClass;
            }
        }

        public ctrlPreviewAndGeneratePage()
        {
            InitializeComponent();
        }
    }
}
