namespace Code_Generator_DApp
{
    partial class frmExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExport));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tsConnection = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.label2 = new System.Windows.Forms.Label();
            this.tsQueries = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.label1 = new System.Windows.Forms.Label();
            this.tsBusinessClass = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.label12 = new System.Windows.Forms.Label();
            this.tsDataAccessClass = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.btnBrowse = new Guna.UI2.WinForms.Guna2Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.guna2ShadowPanel1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(438, 100);
            this.panel2.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 22F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(97, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 36);
            this.label4.TabIndex = 9;
            this.label4.Text = "Export Generated Class";
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.pictureBox5);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(11, 12);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 11;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowShift = 0;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(75, 75);
            this.guna2ShadowPanel1.TabIndex = 5;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Code_Generator_DApp.Properties.Resources.export;
            this.pictureBox5.Location = new System.Drawing.Point(13, 13);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(48, 48);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(61)))), ((int)(((byte)(72)))));
            this.guna2Panel1.BorderColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderRadius = 9;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.tsConnection);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.tsQueries);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.tsBusinessClass);
            this.guna2Panel1.Controls.Add(this.label12);
            this.guna2Panel1.Controls.Add(this.tsDataAccessClass);
            this.guna2Panel1.Location = new System.Drawing.Point(40, 120);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(394, 366);
            this.guna2Panel1.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 24);
            this.label3.TabIndex = 66;
            this.label3.Text = "Connection File";
            // 
            // tsConnection
            // 
            this.tsConnection.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tsConnection.Animated = true;
            this.tsConnection.AutoRoundedCorners = true;
            this.tsConnection.Checked = true;
            this.tsConnection.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(240)))));
            this.tsConnection.CheckedState.BorderRadius = 14;
            this.tsConnection.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(240)))));
            this.tsConnection.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsConnection.CheckedState.InnerBorderRadius = 10;
            this.tsConnection.CheckedState.InnerColor = System.Drawing.Color.White;
            this.tsConnection.Location = new System.Drawing.Point(306, 244);
            this.tsConnection.Margin = new System.Windows.Forms.Padding(10);
            this.tsConnection.Name = "tsConnection";
            this.tsConnection.Size = new System.Drawing.Size(62, 31);
            this.tsConnection.TabIndex = 65;
            this.tsConnection.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsConnection.UncheckedState.BorderRadius = 14;
            this.tsConnection.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsConnection.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsConnection.UncheckedState.InnerBorderRadius = 10;
            this.tsConnection.UncheckedState.InnerColor = System.Drawing.Color.White;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 24);
            this.label2.TabIndex = 64;
            this.label2.Text = "Execute T-SQL queries";
            // 
            // tsQueries
            // 
            this.tsQueries.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tsQueries.Animated = true;
            this.tsQueries.AutoRoundedCorners = true;
            this.tsQueries.Checked = true;
            this.tsQueries.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(240)))));
            this.tsQueries.CheckedState.BorderRadius = 14;
            this.tsQueries.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(240)))));
            this.tsQueries.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsQueries.CheckedState.InnerBorderRadius = 10;
            this.tsQueries.CheckedState.InnerColor = System.Drawing.Color.White;
            this.tsQueries.Location = new System.Drawing.Point(306, 193);
            this.tsQueries.Margin = new System.Windows.Forms.Padding(10);
            this.tsQueries.Name = "tsQueries";
            this.tsQueries.Size = new System.Drawing.Size(62, 31);
            this.tsQueries.TabIndex = 63;
            this.tsQueries.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsQueries.UncheckedState.BorderRadius = 14;
            this.tsQueries.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsQueries.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsQueries.UncheckedState.InnerBorderRadius = 10;
            this.tsQueries.UncheckedState.InnerColor = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 24);
            this.label1.TabIndex = 62;
            this.label1.Text = "Business Class";
            // 
            // tsBusinessClass
            // 
            this.tsBusinessClass.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tsBusinessClass.Animated = true;
            this.tsBusinessClass.AutoRoundedCorners = true;
            this.tsBusinessClass.Checked = true;
            this.tsBusinessClass.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(240)))));
            this.tsBusinessClass.CheckedState.BorderRadius = 14;
            this.tsBusinessClass.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(240)))));
            this.tsBusinessClass.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsBusinessClass.CheckedState.InnerBorderRadius = 10;
            this.tsBusinessClass.CheckedState.InnerColor = System.Drawing.Color.White;
            this.tsBusinessClass.Location = new System.Drawing.Point(306, 142);
            this.tsBusinessClass.Margin = new System.Windows.Forms.Padding(10);
            this.tsBusinessClass.Name = "tsBusinessClass";
            this.tsBusinessClass.Size = new System.Drawing.Size(62, 31);
            this.tsBusinessClass.TabIndex = 61;
            this.tsBusinessClass.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsBusinessClass.UncheckedState.BorderRadius = 14;
            this.tsBusinessClass.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsBusinessClass.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsBusinessClass.UncheckedState.InnerBorderRadius = 10;
            this.tsBusinessClass.UncheckedState.InnerColor = System.Drawing.Color.White;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(25, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(164, 24);
            this.label12.TabIndex = 60;
            this.label12.Text = "DataAccess Class";
            // 
            // tsDataAccessClass
            // 
            this.tsDataAccessClass.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tsDataAccessClass.Animated = true;
            this.tsDataAccessClass.AutoRoundedCorners = true;
            this.tsDataAccessClass.Checked = true;
            this.tsDataAccessClass.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(240)))));
            this.tsDataAccessClass.CheckedState.BorderRadius = 14;
            this.tsDataAccessClass.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(240)))));
            this.tsDataAccessClass.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsDataAccessClass.CheckedState.InnerBorderRadius = 10;
            this.tsDataAccessClass.CheckedState.InnerColor = System.Drawing.Color.White;
            this.tsDataAccessClass.Location = new System.Drawing.Point(306, 91);
            this.tsDataAccessClass.Margin = new System.Windows.Forms.Padding(10);
            this.tsDataAccessClass.Name = "tsDataAccessClass";
            this.tsDataAccessClass.Size = new System.Drawing.Size(62, 31);
            this.tsDataAccessClass.TabIndex = 59;
            this.tsDataAccessClass.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsDataAccessClass.UncheckedState.BorderRadius = 14;
            this.tsDataAccessClass.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsDataAccessClass.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.tsDataAccessClass.UncheckedState.InnerBorderRadius = 10;
            this.tsDataAccessClass.UncheckedState.InnerColor = System.Drawing.Color.White;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BorderRadius = 9;
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(96)))), ((int)(((byte)(240)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(235, 516);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(215, 52);
            this.btnExport.TabIndex = 36;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBrowse.BorderColor = System.Drawing.Color.Transparent;
            this.btnBrowse.BorderRadius = 9;
            this.btnBrowse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBrowse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBrowse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBrowse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBrowse.FillColor = System.Drawing.Color.White;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.DimGray;
            this.btnBrowse.Location = new System.Drawing.Point(12, 516);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(215, 52);
            this.btnBrowse.TabIndex = 37;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(462, 580);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ToggleSwitch tsConnection;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ToggleSwitch tsQueries;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ToggleSwitch tsBusinessClass;
        private System.Windows.Forms.Label label12;
        private Guna.UI2.WinForms.Guna2ToggleSwitch tsDataAccessClass;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private Guna.UI2.WinForms.Guna2Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}