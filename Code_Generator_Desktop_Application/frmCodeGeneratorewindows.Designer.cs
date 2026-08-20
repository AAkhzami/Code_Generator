namespace Code_Generator_DApp
{
    partial class frmCodeGeneratorewindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCodeGeneratorewindows));
            this.tbPages = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpEngineSetup = new System.Windows.Forms.TabPage();
            this.ctrlEngineSetups1 = new Code_Generator_DApp.Controls.ctrlEngineSetups();
            this.ctrlTablesList1 = new Code_Generator_DApp.Controls.ctrlTablesList();
            this.btnNextPage = new Guna.UI2.WinForms.Guna2Button();
            this.tpPreviewAndGenerate = new System.Windows.Forms.TabPage();
            this.ctrlPreviewAndGeneratePage1 = new Code_Generator_DApp.Controls.Preview_And_Generate_Page.ctrlPreviewAndGeneratePage();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.btnGenerate = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnReset = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbSelectDatabase = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbPages.SuspendLayout();
            this.tpEngineSetup.SuspendLayout();
            this.tpPreviewAndGenerate.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPages
            // 
            this.tbPages.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPages.Controls.Add(this.tpEngineSetup);
            this.tbPages.Controls.Add(this.tpPreviewAndGenerate);
            this.tbPages.ItemSize = new System.Drawing.Size(180, 40);
            this.tbPages.Location = new System.Drawing.Point(0, 101);
            this.tbPages.Name = "tbPages";
            this.tbPages.SelectedIndex = 0;
            this.tbPages.Size = new System.Drawing.Size(1456, 747);
            this.tbPages.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tbPages.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tbPages.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbPages.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tbPages.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tbPages.TabButtonIdleState.BorderColor = System.Drawing.Color.Gray;
            this.tbPages.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.tbPages.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbPages.TabButtonIdleState.ForeColor = System.Drawing.Color.White;
            this.tbPages.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
            this.tbPages.TabButtonSelectedState.BorderColor = System.Drawing.Color.White;
            this.tbPages.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tbPages.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbPages.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tbPages.TabButtonSelectedState.InnerColor = System.Drawing.Color.White;
            this.tbPages.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tbPages.TabIndex = 0;
            this.tbPages.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tbPages.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalBottom;
            this.tbPages.TabMenuVisible = false;
            // 
            // tpEngineSetup
            // 
            this.tpEngineSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(44)))));
            this.tpEngineSetup.Controls.Add(this.ctrlEngineSetups1);
            this.tpEngineSetup.Controls.Add(this.ctrlTablesList1);
            this.tpEngineSetup.Controls.Add(this.btnNextPage);
            this.tpEngineSetup.Location = new System.Drawing.Point(4, 4);
            this.tpEngineSetup.Name = "tpEngineSetup";
            this.tpEngineSetup.Padding = new System.Windows.Forms.Padding(3);
            this.tpEngineSetup.Size = new System.Drawing.Size(1448, 738);
            this.tpEngineSetup.TabIndex = 0;
            this.tpEngineSetup.Text = "Engine Setup";
            // 
            // ctrlEngineSetups1
            // 
            this.ctrlEngineSetups1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlEngineSetups1.Location = new System.Drawing.Point(800, 8);
            this.ctrlEngineSetups1.Name = "ctrlEngineSetups1";
            this.ctrlEngineSetups1.Size = new System.Drawing.Size(518, 667);
            this.ctrlEngineSetups1.TabIndex = 8;
            // 
            // ctrlTablesList1
            // 
            this.ctrlTablesList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlTablesList1.Location = new System.Drawing.Point(131, 9);
            this.ctrlTablesList1.Name = "ctrlTablesList1";
            this.ctrlTablesList1.Size = new System.Drawing.Size(670, 667);
            this.ctrlTablesList1.TabIndex = 7;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.BorderRadius = 9;
            this.btnNextPage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNextPage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNextPage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNextPage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNextPage.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(99)))), ((int)(((byte)(231)))));
            this.btnNextPage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPage.ForeColor = System.Drawing.Color.White;
            this.btnNextPage.Image = global::Code_Generator_DApp.Properties.Resources.arrow_next;
            this.btnNextPage.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnNextPage.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnNextPage.Location = new System.Drawing.Point(1139, 681);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(301, 50);
            this.btnNextPage.TabIndex = 0;
            this.btnNextPage.Text = "Next: Preview && Generate ";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // tpPreviewAndGenerate
            // 
            this.tpPreviewAndGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(44)))));
            this.tpPreviewAndGenerate.Controls.Add(this.ctrlPreviewAndGeneratePage1);
            this.tpPreviewAndGenerate.Controls.Add(this.btnBack);
            this.tpPreviewAndGenerate.Controls.Add(this.btnGenerate);
            this.tpPreviewAndGenerate.Location = new System.Drawing.Point(4, 4);
            this.tpPreviewAndGenerate.Name = "tpPreviewAndGenerate";
            this.tpPreviewAndGenerate.Size = new System.Drawing.Size(1448, 699);
            this.tpPreviewAndGenerate.TabIndex = 1;
            this.tpPreviewAndGenerate.Text = "Preview & Generate";
            // 
            // ctrlPreviewAndGeneratePage1
            // 
            this.ctrlPreviewAndGeneratePage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlPreviewAndGeneratePage1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPreviewAndGeneratePage1.Location = new System.Drawing.Point(3, 3);
            this.ctrlPreviewAndGeneratePage1.Name = "ctrlPreviewAndGeneratePage1";
            this.ctrlPreviewAndGeneratePage1.Size = new System.Drawing.Size(1442, 587);
            this.ctrlPreviewAndGeneratePage1.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.BorderRadius = 9;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Image = global::Code_Generator_DApp.Properties.Resources.arrow_back;
            this.btnBack.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBack.ImageOffset = new System.Drawing.Point(20, 0);
            this.btnBack.Location = new System.Drawing.Point(9, 596);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(288, 50);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.BorderRadius = 9;
            this.btnGenerate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenerate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(76)))), ((int)(((byte)(188)))));
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnGenerate.Location = new System.Drawing.Point(1152, 596);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(288, 50);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate Code";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(25)))), ((int)(((byte)(38)))));
            this.guna2GradientPanel1.BorderRadius = 10;
            this.guna2GradientPanel1.BorderThickness = 1;
            this.guna2GradientPanel1.Controls.Add(this.btnReset);
            this.guna2GradientPanel1.Controls.Add(this.pictureBox1);
            this.guna2GradientPanel1.Controls.Add(this.cbSelectDatabase);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.guna2GradientPanel1.Location = new System.Drawing.Point(12, 12);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1432, 83);
            this.guna2GradientPanel1.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(901, 25);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(32, 32);
            this.btnReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnReset.TabIndex = 12;
            this.btnReset.TabStop = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::Code_Generator_DApp.Properties.Resources.database;
            this.pictureBox1.Location = new System.Drawing.Point(500, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // cbSelectDatabase
            // 
            this.cbSelectDatabase.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.cbSelectDatabase.Location = new System.Drawing.Point(549, 23);
            this.cbSelectDatabase.Name = "cbSelectDatabase";
            this.cbSelectDatabase.Size = new System.Drawing.Size(326, 36);
            this.cbSelectDatabase.StartIndex = 0;
            this.cbSelectDatabase.TabIndex = 10;
            this.cbSelectDatabase.SelectedIndexChanged += new System.EventHandler(this.cbSelectDatabase_SelectedIndexChanged);
            // 
            // frmCodeGeneratorewindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(25)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1456, 848);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.tbPages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCodeGeneratorewindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Generator v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCodeGeneratorewindows_Load);
            this.tbPages.ResumeLayout(false);
            this.tpEngineSetup.ResumeLayout(false);
            this.tpPreviewAndGenerate.ResumeLayout(false);
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tbPages;
        private System.Windows.Forms.TabPage tpEngineSetup;
        private System.Windows.Forms.TabPage tpPreviewAndGenerate;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.PictureBox btnReset;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cbSelectDatabase;
        private Guna.UI2.WinForms.Guna2Button btnNextPage;
        private Guna.UI2.WinForms.Guna2Button btnGenerate;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Controls.Preview_And_Generate_Page.ctrlPreviewAndGeneratePage ctrlPreviewAndGeneratePage1;
        private Controls.ctrlEngineSetups ctrlEngineSetups1;
        private Controls.ctrlTablesList ctrlTablesList1;
    }
}