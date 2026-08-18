namespace Code_Generator_DApp
{
    partial class frmMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Table1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Table2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Table3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Table4");
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnReset = new System.Windows.Forms.PictureBox();
            this.tcGCsteps = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpSelect = new System.Windows.Forms.TabPage();
            this.btnNext_ConfigEngine = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlSelectPage1 = new Code_Generator_DApp.Controls.ctrlSelectPage();
            this.tpEngineSetup = new System.Windows.Forms.TabPage();
            this.btnBackToSelectTablePage = new Guna.UI2.WinForms.Guna2Button();
            this.btnNextGenerateCodePage = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlEnginSetupPage1 = new Code_Generator_DApp.Controls.ctrlEnginSetupPage();
            this.tpPreviewGenerate = new System.Windows.Forms.TabPage();
            this.ctrlPreviewAndGeneratePage1 = new Code_Generator_DApp.Controls.Preview_And_Generate_Page.ctrlPreviewAndGeneratePage();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbSelectDatabase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReset)).BeginInit();
            this.tcGCsteps.SuspendLayout();
            this.tpSelect.SuspendLayout();
            this.tpEngineSetup.SuspendLayout();
            this.tpPreviewGenerate.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.guna2Panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.btnReset);
            this.guna2Panel1.Controls.Add(this.tcGCsteps);
            this.guna2Panel1.Controls.Add(this.panel1);
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Controls.Add(this.cbSelectDatabase);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.guna2Panel1.Location = new System.Drawing.Point(19, 19);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(10);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1418, 766);
            this.guna2Panel1.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(411, 35);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(32, 32);
            this.btnReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnReset.TabIndex = 9;
            this.btnReset.TabStop = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tcGCsteps
            // 
            this.tcGCsteps.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tcGCsteps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcGCsteps.Controls.Add(this.tpSelect);
            this.tcGCsteps.Controls.Add(this.tpEngineSetup);
            this.tcGCsteps.Controls.Add(this.tpPreviewGenerate);
            this.tcGCsteps.ItemSize = new System.Drawing.Size(180, 40);
            this.tcGCsteps.Location = new System.Drawing.Point(10, 100);
            this.tcGCsteps.Name = "tcGCsteps";
            this.tcGCsteps.SelectedIndex = 0;
            this.tcGCsteps.Size = new System.Drawing.Size(1398, 663);
            this.tcGCsteps.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tcGCsteps.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcGCsteps.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcGCsteps.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tcGCsteps.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcGCsteps.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tcGCsteps.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcGCsteps.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcGCsteps.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tcGCsteps.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcGCsteps.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tcGCsteps.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tcGCsteps.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcGCsteps.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tcGCsteps.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tcGCsteps.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tcGCsteps.TabIndex = 8;
            this.tcGCsteps.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcGCsteps.TabMenuVisible = false;
            // 
            // tpSelect
            // 
            this.tpSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.tpSelect.Controls.Add(this.btnNext_ConfigEngine);
            this.tpSelect.Controls.Add(this.ctrlSelectPage1);
            this.tpSelect.Location = new System.Drawing.Point(184, 4);
            this.tpSelect.Name = "tpSelect";
            this.tpSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tpSelect.Size = new System.Drawing.Size(1210, 655);
            this.tpSelect.TabIndex = 0;
            this.tpSelect.Text = "Select_Table";
            // 
            // btnNext_ConfigEngine
            // 
            this.btnNext_ConfigEngine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext_ConfigEngine.BorderRadius = 9;
            this.btnNext_ConfigEngine.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext_ConfigEngine.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext_ConfigEngine.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext_ConfigEngine.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext_ConfigEngine.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(99)))), ((int)(((byte)(231)))));
            this.btnNext_ConfigEngine.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext_ConfigEngine.ForeColor = System.Drawing.Color.White;
            this.btnNext_ConfigEngine.Location = new System.Drawing.Point(805, 592);
            this.btnNext_ConfigEngine.Name = "btnNext_ConfigEngine";
            this.btnNext_ConfigEngine.Size = new System.Drawing.Size(390, 57);
            this.btnNext_ConfigEngine.TabIndex = 8;
            this.btnNext_ConfigEngine.Text = "Next: Configure Engine";
            this.btnNext_ConfigEngine.Click += new System.EventHandler(this.btnNext_ConfigEngine_Click);
            // 
            // ctrlSelectPage1
            // 
            this.ctrlSelectPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlSelectPage1.Location = new System.Drawing.Point(6, 6);
            this.ctrlSelectPage1.Name = "ctrlSelectPage1";
            this.ctrlSelectPage1.Size = new System.Drawing.Size(1198, 580);
            this.ctrlSelectPage1.TabIndex = 7;
            // 
            // tpEngineSetup
            // 
            this.tpEngineSetup.Controls.Add(this.btnBackToSelectTablePage);
            this.tpEngineSetup.Controls.Add(this.btnNextGenerateCodePage);
            this.tpEngineSetup.Controls.Add(this.ctrlEnginSetupPage1);
            this.tpEngineSetup.Location = new System.Drawing.Point(184, 4);
            this.tpEngineSetup.Name = "tpEngineSetup";
            this.tpEngineSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tpEngineSetup.Size = new System.Drawing.Size(1210, 655);
            this.tpEngineSetup.TabIndex = 1;
            this.tpEngineSetup.Text = "Engine_Setup";
            this.tpEngineSetup.UseVisualStyleBackColor = true;
            // 
            // btnBackToSelectTablePage
            // 
            this.btnBackToSelectTablePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackToSelectTablePage.BorderColor = System.Drawing.Color.Silver;
            this.btnBackToSelectTablePage.BorderRadius = 9;
            this.btnBackToSelectTablePage.BorderThickness = 1;
            this.btnBackToSelectTablePage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBackToSelectTablePage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBackToSelectTablePage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBackToSelectTablePage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBackToSelectTablePage.FillColor = System.Drawing.Color.White;
            this.btnBackToSelectTablePage.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToSelectTablePage.ForeColor = System.Drawing.Color.Black;
            this.btnBackToSelectTablePage.Location = new System.Drawing.Point(6, 229);
            this.btnBackToSelectTablePage.Name = "btnBackToSelectTablePage";
            this.btnBackToSelectTablePage.Size = new System.Drawing.Size(390, 57);
            this.btnBackToSelectTablePage.TabIndex = 44;
            this.btnBackToSelectTablePage.Text = "Back";
            this.btnBackToSelectTablePage.Click += new System.EventHandler(this.btnBackToSelectTablePage_Click);
            // 
            // btnNextGenerateCodePage
            // 
            this.btnNextGenerateCodePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextGenerateCodePage.BorderRadius = 9;
            this.btnNextGenerateCodePage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNextGenerateCodePage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNextGenerateCodePage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNextGenerateCodePage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNextGenerateCodePage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(99)))), ((int)(((byte)(231)))));
            this.btnNextGenerateCodePage.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextGenerateCodePage.ForeColor = System.Drawing.Color.White;
            this.btnNextGenerateCodePage.Location = new System.Drawing.Point(-263, 229);
            this.btnNextGenerateCodePage.Name = "btnNextGenerateCodePage";
            this.btnNextGenerateCodePage.Size = new System.Drawing.Size(390, 57);
            this.btnNextGenerateCodePage.TabIndex = 43;
            this.btnNextGenerateCodePage.Text = "Generate Code Now";
            // 
            // ctrlEnginSetupPage1
            // 
            this.ctrlEnginSetupPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlEnginSetupPage1.Location = new System.Drawing.Point(0, -181);
            this.ctrlEnginSetupPage1.Name = "ctrlEnginSetupPage1";
            this.ctrlEnginSetupPage1.Size = new System.Drawing.Size(127, 603);
            this.ctrlEnginSetupPage1.TabIndex = 45;
            // 
            // tpPreviewGenerate
            // 
            this.tpPreviewGenerate.Controls.Add(this.guna2Panel5);
            this.tpPreviewGenerate.Controls.Add(this.ctrlPreviewAndGeneratePage1);
            this.tpPreviewGenerate.Controls.Add(this.guna2Button1);
            this.tpPreviewGenerate.Location = new System.Drawing.Point(5, 4);
            this.tpPreviewGenerate.Name = "tpPreviewGenerate";
            this.tpPreviewGenerate.Size = new System.Drawing.Size(1389, 655);
            this.tpPreviewGenerate.TabIndex = 2;
            this.tpPreviewGenerate.Text = "Preview_Generate";
            this.tpPreviewGenerate.UseVisualStyleBackColor = true;
            // 
            // ctrlPreviewAndGeneratePage1
            // 
            this.ctrlPreviewAndGeneratePage1.BusinessLayerClass = "BusinessLayerClass";
            this.ctrlPreviewAndGeneratePage1.Connection = "ConnectionType";
            this.ctrlPreviewAndGeneratePage1.DataAccessClass = "DataAccessClass";
            this.ctrlPreviewAndGeneratePage1.Location = new System.Drawing.Point(332, 8);
            this.ctrlPreviewAndGeneratePage1.Name = "ctrlPreviewAndGeneratePage1";
            this.ctrlPreviewAndGeneratePage1.Querys = "Queries";
            this.ctrlPreviewAndGeneratePage1.Size = new System.Drawing.Size(1049, 580);
            this.ctrlPreviewAndGeneratePage1.TabIndex = 0;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.BorderRadius = 9;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(99)))), ((int)(((byte)(231)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(990, 592);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(390, 57);
            this.guna2Button1.TabIndex = 44;
            this.guna2Button1.Text = "Generate Code Now";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.guna2Panel4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.guna2Panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(660, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(729, 45);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Code_Generator_DApp.Properties.Resources.num_3_Not_Selected;
            this.pictureBox4.Location = new System.Drawing.Point(533, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(573, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Preview && Generate";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Code_Generator_DApp.Properties.Resources.num_2_Not_Selected;
            this.pictureBox3.Location = new System.Drawing.Point(285, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(99)))), ((int)(((byte)(231)))));
            this.guna2Panel4.Location = new System.Drawing.Point(442, 22);
            this.guna2Panel4.Margin = new System.Windows.Forms.Padding(10);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(69, 1);
            this.guna2Panel4.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(325, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Engine Setup";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Code_Generator_DApp.Properties.Resources.num_1;
            this.pictureBox2.Location = new System.Drawing.Point(23, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(99)))), ((int)(((byte)(231)))));
            this.guna2Panel3.Location = new System.Drawing.Point(200, 23);
            this.guna2Panel3.Margin = new System.Windows.Forms.Padding(10);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(69, 1);
            this.guna2Panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(99)))), ((int)(((byte)(231)))));
            this.label1.Location = new System.Drawing.Point(65, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select && validate";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Code_Generator_DApp.Properties.Resources.database;
            this.pictureBox1.Location = new System.Drawing.Point(10, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // cbSelectDatabase
            // 
            this.cbSelectDatabase.BackColor = System.Drawing.Color.Transparent;
            this.cbSelectDatabase.BorderRadius = 9;
            this.cbSelectDatabase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSelectDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectDatabase.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSelectDatabase.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSelectDatabase.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.cbSelectDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.cbSelectDatabase.ItemHeight = 30;
            this.cbSelectDatabase.Items.AddRange(new object[] {
            "Select Database"});
            this.cbSelectDatabase.Location = new System.Drawing.Point(59, 33);
            this.cbSelectDatabase.Name = "cbSelectDatabase";
            this.cbSelectDatabase.Size = new System.Drawing.Size(326, 36);
            this.cbSelectDatabase.StartIndex = 0;
            this.cbSelectDatabase.TabIndex = 1;
            this.cbSelectDatabase.SelectedIndexChanged += new System.EventHandler(this.cbSelectDatabase_SelectedIndexChanged);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(234)))), ((int)(((byte)(239)))));
            this.guna2Panel2.Location = new System.Drawing.Point(10, 97);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(10);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1398, 2);
            this.guna2Panel2.TabIndex = 0;
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Panel5.BorderRadius = 8;
            this.guna2Panel5.BorderThickness = 1;
            this.guna2Panel5.Controls.Add(this.treeView1);
            this.guna2Panel5.Location = new System.Drawing.Point(13, 13);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.Size = new System.Drawing.Size(313, 574);
            this.guna2Panel5.TabIndex = 45;
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(80, 88);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Table1";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Table2";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Table3";
            treeNode4.Name = "Node3";
            treeNode4.Text = "Table4";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(186, 366);
            this.treeView1.TabIndex = 0;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1456, 804);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "frmMainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Generatore";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnReset)).EndInit();
            this.tcGCsteps.ResumeLayout(false);
            this.tpSelect.ResumeLayout(false);
            this.tpEngineSetup.ResumeLayout(false);
            this.tpPreviewGenerate.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.guna2Panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2ComboBox cbSelectDatabase;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TabControl tcGCsteps;
        private System.Windows.Forms.TabPage tpSelect;
        private Guna.UI2.WinForms.Guna2Button btnNext_ConfigEngine;
        private Controls.ctrlSelectPage ctrlSelectPage1;
        private System.Windows.Forms.TabPage tpEngineSetup;
        private System.Windows.Forms.PictureBox btnReset;
        private System.Windows.Forms.TabPage tpPreviewGenerate;
        private Guna.UI2.WinForms.Guna2Button btnNextGenerateCodePage;
        private Guna.UI2.WinForms.Guna2Button btnBackToSelectTablePage;
        private Controls.ctrlEnginSetupPage ctrlEnginSetupPage1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Controls.Preview_And_Generate_Page.ctrlPreviewAndGeneratePage ctrlPreviewAndGeneratePage1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private System.Windows.Forms.TreeView treeView1;
    }
}