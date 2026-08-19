using Code_Generator_Business_Layer;
using Code_Generator_Business_Layer.DataAccessGenerators;
using Code_Generator_Business_Layer.DataAccessGenerators.SQLServer;
using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private void ApplyTokyoNightTheme(FastColoredTextBox codeEditor)
        {
            codeEditor.BackColor = Color.FromArgb(26, 27, 38);
            codeEditor.ForeColor = Color.FromArgb(169, 177, 214);
            codeEditor.IndentBackColor = Color.FromArgb(22, 22, 30);
            codeEditor.LineNumberColor = Color.FromArgb(70, 75, 108);
            codeEditor.SelectionColor = Color.FromArgb(80, 51, 62, 100);
            codeEditor.CaretColor = Color.FromArgb(192, 202, 245);
            codeEditor.Font = new Font("Consolas", 11f, FontStyle.Regular);

            codeEditor.Language = Language.Custom;
            codeEditor.ClearStylesBuffer();

            TextStyle keywordStyle = new TextStyle(new SolidBrush(Color.FromArgb(187, 154, 247)), null, FontStyle.Regular); 
            TextStyle typeStyle = new TextStyle(new SolidBrush(Color.FromArgb(122, 162, 247)), null, FontStyle.Regular);
            TextStyle stringStyle = new TextStyle(new SolidBrush(Color.FromArgb(156, 207, 122)), null, FontStyle.Regular);
            TextStyle commentStyle = new TextStyle(new SolidBrush(Color.FromArgb(86, 95, 137)), null, FontStyle.Italic); 
            TextStyle numberStyle = new TextStyle(new SolidBrush(Color.FromArgb(255, 158, 100)), null, FontStyle.Regular);

            codeEditor.TextChanged += (s, ev) =>
            {
                ev.ChangedRange.ClearStyle(keywordStyle, typeStyle, stringStyle, commentStyle, numberStyle);

                ev.ChangedRange.SetStyle(keywordStyle, @"\b(using|namespace|class|public|private|protected|internal|static|async|await|return|var|new|void|string|int|bool|object)\b");
                ev.ChangedRange.SetStyle(typeStyle, @"\b(Task|DataTable|SqlConnection|SqlCommand|SqlDataAdapter|Exception)\b|\b[A-Z]\w*\b");
                ev.ChangedRange.SetStyle(stringStyle, @"""""|@""[^""]*""|""([^""\\]|\\.)*""");
                ev.ChangedRange.SetStyle(commentStyle, @"//.*$|/\*[\s\S]*?\*/", RegexOptions.Multiline);
                ev.ChangedRange.SetStyle(numberStyle, @"\b\d+\b");
            };

            codeEditor.OnTextChanged();
        }
        public void LoadAccessDataClass(string Datatable, string Table, ctrlEngineSetups.enDatabaseType databaseType, clsConnectionData connection, List<clsClassCodeBuilder.enOperationType> operations)
        {
            clsClassCodeBuilder codeBuilder = new clsClassCodeBuilder(Datatable, Table);
            switch(databaseType)
            {
                case ctrlEngineSetups.enDatabaseType.TSQL:
                    {
                        clsTSQLDataMethodsGenerator TSQL = new clsTSQLDataMethodsGenerator(Table, connection);
                        codeBuilder.GenerateDataAccessLayerClass(TSQL, connection, operations);
                        break;
                    }
                case ctrlEngineSetups.enDatabaseType.SQL:
                    {
                        clsSQLServerDataAccessLayerGenerator SQL = new clsSQLServerDataAccessLayerGenerator(Table, connection);
                        codeBuilder.GenerateDataAccessLayerClass(SQL, connection, operations);
                        break;
                    }
            }
        }

    }
}
