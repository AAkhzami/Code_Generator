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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static Code_Generator_DApp.Controls.ctrlEngineSetups;

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
                tbCodesGenerator.TabPages["tpDataAccess"].Text = value;
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
                tbCodesGenerator.TabPages["tpBusinessLayer"].Text = value;
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
                tbCodesGenerator.TabPages["tpQueries"].Text = value;
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
                tbCodesGenerator.TabPages["tpConnection"].Text = value;
            }
        }

        public ctrlPreviewAndGeneratePage()
        {
            InitializeComponent();
            ApplyTokyoNightTheme(fctbDataAccessClass);
            ApplyOneDarkProTheme(fctbBusinessClass);
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
        private void ApplyOneDarkProTheme(FastColoredTextBox fctb)
        {
            fctb.BackColor = Color.FromArgb(40, 44, 52);
            fctb.ForeColor = Color.FromArgb(171, 178, 191);
            fctb.IndentBackColor = Color.FromArgb(33, 37, 43);
            fctb.LineNumberColor = Color.FromArgb(92, 99, 112);
            fctb.SelectionColor = Color.FromArgb(80, 61, 68, 81);
            fctb.CaretColor = Color.FromArgb(82, 139, 255);
            fctb.Font = new Font("Consolas", 11f, FontStyle.Regular);

            fctb.Language = Language.Custom;
            fctb.ClearStylesBuffer();

            TextStyle keywordStyle = new TextStyle(new SolidBrush(Color.FromArgb(198, 120, 221)), null, FontStyle.Regular);
            TextStyle typeStyle = new TextStyle(new SolidBrush(Color.FromArgb(86, 182, 194)), null, FontStyle.Regular);
            TextStyle methodStyle = new TextStyle(new SolidBrush(Color.FromArgb(97, 175, 239)), null, FontStyle.Regular); 
            TextStyle stringStyle = new TextStyle(new SolidBrush(Color.FromArgb(152, 195, 121)), null, FontStyle.Regular);
            TextStyle commentStyle = new TextStyle(new SolidBrush(Color.FromArgb(92, 99, 112)), null, FontStyle.Italic);  
            TextStyle numberStyle = new TextStyle(new SolidBrush(Color.FromArgb(209, 154, 102)), null, FontStyle.Regular);

            fctb.TextChanged += (s, ev) =>
            {
                ev.ChangedRange.ClearStyle(keywordStyle, typeStyle, methodStyle, stringStyle, commentStyle, numberStyle);

                ev.ChangedRange.SetStyle(keywordStyle, @"\b(using|namespace|class|public|private|protected|internal|static|async|await|return|var|new|void|string|int|bool|object)\b");
                ev.ChangedRange.SetStyle(typeStyle, @"\b(Task|DataTable|SqlConnection|SqlCommand|SqlDataAdapter|Exception)\b|\b[A-Z]\w*\b");
                ev.ChangedRange.SetStyle(stringStyle, @"""""|@""[^""]*""|""([^""\\]|\\.)*""");
                ev.ChangedRange.SetStyle(commentStyle, @"//.*$|/\*[\s\S]*?\*/", RegexOptions.Multiline);
                ev.ChangedRange.SetStyle(numberStyle, @"\b\d+\b");
            };

            fctb.OnTextChanged();
        }


        public void LoadAccessDataClass(string Table, ctrlEngineSetups.enDatabaseType databaseType, clsConnectionData connection, List<clsClassCodeBuilder.enOperationType> operations)
        {
            if (!string.IsNullOrWhiteSpace(connection.databaseName) && !string.IsNullOrWhiteSpace(Table))
            {
                return;
            }

            clsClassCodeBuilder codeBuilder = new clsClassCodeBuilder(connection.databaseName, Table);
            switch(databaseType)
            {
                case ctrlEngineSetups.enDatabaseType.TSQL:
                    {
                        clsTSQLDataMethodsGenerator TSQL = new clsTSQLDataMethodsGenerator(Table, connection);                        
                        fctbDataAccessClass.Text = codeBuilder.GenerateDataAccessLayerClass(TSQL, connection, operations);
                        break;
                    }
                case ctrlEngineSetups.enDatabaseType.SQL:
                    {
                        clsSQLServerDataAccessLayerGenerator SQL = new clsSQLServerDataAccessLayerGenerator(Table, connection);
                        fctbDataAccessClass.Text = codeBuilder.GenerateDataAccessLayerClass(SQL, connection, operations);
                        break;
                    }
            }
        }
        public void LoadBusinessClass(string Database,string Table, List<clsClassCodeBuilder.enOperationType> operations)
        {
            if (!string.IsNullOrWhiteSpace(Database) && !string.IsNullOrWhiteSpace(Table))
            {
                return;
            }

            clsClassCodeBuilder codeBuilder = new clsClassCodeBuilder(Database, Table);
            clsBusinessLayerGenerator BusinessLayer = new clsBusinessLayerGenerator(Database, Table);
            fctbBusinessClass.Text = codeBuilder.GenerateBusinessLayerClass(BusinessLayer, operations);

        }

    }
}
