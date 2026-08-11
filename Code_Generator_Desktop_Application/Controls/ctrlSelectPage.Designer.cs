namespace Code_Generator_DApp.Controls
{
    partial class ctrlSelectPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbSearchOnTable = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvTablesInfo = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblKeysCount = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblColumns = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTableCount = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.cTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cColumns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablesInfo)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panel2.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearchOnTable
            // 
            this.tbSearchOnTable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbSearchOnTable.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(171)))), ((int)(((byte)(249)))));
            this.tbSearchOnTable.BorderRadius = 9;
            this.tbSearchOnTable.BorderThickness = 2;
            this.tbSearchOnTable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSearchOnTable.DefaultText = "";
            this.tbSearchOnTable.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSearchOnTable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSearchOnTable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearchOnTable.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearchOnTable.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearchOnTable.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchOnTable.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearchOnTable.IconLeft = global::Code_Generator_DApp.Properties.Resources.search;
            this.tbSearchOnTable.IconLeftOffset = new System.Drawing.Point(10, 0);
            this.tbSearchOnTable.IconLeftSize = new System.Drawing.Size(23, 23);
            this.tbSearchOnTable.Location = new System.Drawing.Point(279, 138);
            this.tbSearchOnTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSearchOnTable.Name = "tbSearchOnTable";
            this.tbSearchOnTable.PlaceholderText = "Search tables by name...";
            this.tbSearchOnTable.SelectedText = "";
            this.tbSearchOnTable.Size = new System.Drawing.Size(792, 59);
            this.tbSearchOnTable.TabIndex = 35;
            this.tbSearchOnTable.TextOffset = new System.Drawing.Point(20, 0);
            // 
            // dgvTablesInfo
            // 
            this.dgvTablesInfo.AllowUserToAddRows = false;
            this.dgvTablesInfo.AllowUserToDeleteRows = false;
            this.dgvTablesInfo.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTablesInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTablesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTablesInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(90)))), ((int)(((byte)(187)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTablesInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTablesInfo.ColumnHeadersHeight = 60;
            this.dgvTablesInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTablesInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTable,
            this.cColumns,
            this.cStatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTablesInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTablesInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTablesInfo.Location = new System.Drawing.Point(115, 313);
            this.dgvTablesInfo.Name = "dgvTablesInfo";
            this.dgvTablesInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTablesInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTablesInfo.RowHeadersVisible = false;
            this.dgvTablesInfo.RowTemplate.Height = 60;
            this.dgvTablesInfo.Size = new System.Drawing.Size(1120, 219);
            this.dgvTablesInfo.TabIndex = 34;
            this.dgvTablesInfo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTablesInfo.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.dgvTablesInfo.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(90)))), ((int)(((byte)(187)))));
            this.dgvTablesInfo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTablesInfo.ThemeStyle.HeaderStyle.Height = 60;
            this.dgvTablesInfo.ThemeStyle.ReadOnly = true;
            this.dgvTablesInfo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTablesInfo.ThemeStyle.RowsStyle.Height = 60;
            this.dgvTablesInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTablesInfo_CellFormatting);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lblKeysCount);
            this.panel3.Controls.Add(this.pictureBox8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lblColumns);
            this.panel3.Controls.Add(this.pictureBox7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lblTableCount);
            this.panel3.Controls.Add(this.pictureBox6);
            this.panel3.Location = new System.Drawing.Point(317, 204);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(716, 60);
            this.panel3.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.label8.Location = new System.Drawing.Point(572, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "With Primary Key";
            // 
            // lblKeysCount
            // 
            this.lblKeysCount.AutoSize = true;
            this.lblKeysCount.Font = new System.Drawing.Font("SansSerif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblKeysCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(155)))), ((int)(((byte)(106)))));
            this.lblKeysCount.Location = new System.Drawing.Point(533, 20);
            this.lblKeysCount.Name = "lblKeysCount";
            this.lblKeysCount.Size = new System.Drawing.Size(32, 22);
            this.lblKeysCount.TabIndex = 14;
            this.lblKeysCount.Text = "20";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::Code_Generator_DApp.Properties.Resources.key;
            this.pictureBox8.Location = new System.Drawing.Point(489, 15);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(32, 32);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 13;
            this.pictureBox8.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.label7.Location = new System.Drawing.Point(344, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Columns";
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Font = new System.Drawing.Font("SansSerif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblColumns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(99)))), ((int)(((byte)(231)))));
            this.lblColumns.Location = new System.Drawing.Point(302, 19);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(43, 22);
            this.lblColumns.TabIndex = 11;
            this.lblColumns.Text = "312";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Code_Generator_DApp.Properties.Resources.column;
            this.pictureBox7.Location = new System.Drawing.Point(260, 14);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 10;
            this.pictureBox7.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.label6.Location = new System.Drawing.Point(115, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tables";
            // 
            // lblTableCount
            // 
            this.lblTableCount.AutoSize = true;
            this.lblTableCount.Font = new System.Drawing.Font("SansSerif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblTableCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(99)))), ((int)(((byte)(231)))));
            this.lblTableCount.Location = new System.Drawing.Point(75, 20);
            this.lblTableCount.Name = "lblTableCount";
            this.lblTableCount.Size = new System.Drawing.Size(32, 22);
            this.lblTableCount.TabIndex = 8;
            this.lblTableCount.Text = "24";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Code_Generator_DApp.Properties.Resources.table;
            this.pictureBox6.Location = new System.Drawing.Point(31, 15);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 0;
            this.pictureBox6.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.guna2ShadowPanel1);
            this.panel2.Location = new System.Drawing.Point(346, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(658, 123);
            this.panel2.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(139)))), ((int)(((byte)(153)))));
            this.label5.Location = new System.Drawing.Point(149, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(481, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Search and Select your database table to start generate clean code.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(145, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(510, 39);
            this.label4.TabIndex = 6;
            this.label4.Text = "Select a table to generate code for";
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
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(104, 100);
            this.guna2ShadowPanel1.TabIndex = 5;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Code_Generator_DApp.Properties.Resources.search;
            this.pictureBox5.Location = new System.Drawing.Point(20, 18);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(64, 64);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            // 
            // cTable
            // 
            this.cTable.HeaderText = "Table";
            this.cTable.Name = "cTable";
            this.cTable.ReadOnly = true;
            // 
            // cColumns
            // 
            this.cColumns.HeaderText = "Columns";
            this.cColumns.Name = "cColumns";
            this.cColumns.ReadOnly = true;
            // 
            // cStatus
            // 
            this.cStatus.HeaderText = "Status";
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            // 
            // ctrlSelectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbSearchOnTable);
            this.Controls.Add(this.dgvTablesInfo);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "ctrlSelectPage";
            this.Size = new System.Drawing.Size(1351, 544);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablesInfo)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tbSearchOnTable;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTablesInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblKeysCount;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTableCount;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn cColumns;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
    }
}
