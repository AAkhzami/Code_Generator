namespace Code_Generator_DApp
{
    partial class frmShowAllDatabase
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
            this.tc = new System.Windows.Forms.TabControl();
            this.tpDatabaseSelector = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvListOfDatabase = new System.Windows.Forms.DataGridView();
            this.tpTablesSelector = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChooseLocation = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbBL = new System.Windows.Forms.CheckBox();
            this.cbDL = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvColumnsList = new System.Windows.Forms.DataGridView();
            this.lblCNumber = new System.Windows.Forms.Label();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tc.SuspendLayout();
            this.tpDatabaseSelector.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfDatabase)).BeginInit();
            this.tpTablesSelector.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumnsList)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            this.SuspendLayout();
            // 
            // tc
            // 
            this.tc.Controls.Add(this.tpDatabaseSelector);
            this.tc.Controls.Add(this.tpTablesSelector);
            this.tc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc.Location = new System.Drawing.Point(27, 27);
            this.tc.Name = "tc";
            this.tc.SelectedIndex = 0;
            this.tc.Size = new System.Drawing.Size(1062, 665);
            this.tc.TabIndex = 1;
            // 
            // tpDatabaseSelector
            // 
            this.tpDatabaseSelector.Controls.Add(this.panel3);
            this.tpDatabaseSelector.Controls.Add(this.panel2);
            this.tpDatabaseSelector.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tpDatabaseSelector.Location = new System.Drawing.Point(4, 28);
            this.tpDatabaseSelector.Name = "tpDatabaseSelector";
            this.tpDatabaseSelector.Padding = new System.Windows.Forms.Padding(3);
            this.tpDatabaseSelector.Size = new System.Drawing.Size(1054, 633);
            this.tpDatabaseSelector.TabIndex = 0;
            this.tpDatabaseSelector.Text = "Database Selector";
            this.tpDatabaseSelector.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnNext1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(537, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(514, 627);
            this.panel3.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(79, 330);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(356, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "Select one of the available databases to continue.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Swis721 Blk BT", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(26, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 35);
            this.label1.TabIndex = 19;
            this.label1.Text = "Select One Of The Database";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext1
            // 
            this.btnNext1.BackColor = System.Drawing.Color.Teal;
            this.btnNext1.Enabled = false;
            this.btnNext1.FlatAppearance.BorderSize = 0;
            this.btnNext1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext1.ForeColor = System.Drawing.Color.White;
            this.btnNext1.Location = new System.Drawing.Point(127, 572);
            this.btnNext1.Margin = new System.Windows.Forms.Padding(15);
            this.btnNext1.Name = "btnNext1";
            this.btnNext1.Size = new System.Drawing.Size(261, 42);
            this.btnNext1.TabIndex = 18;
            this.btnNext1.Text = "Next";
            this.btnNext1.UseVisualStyleBackColor = false;
            this.btnNext1.Click += new System.EventHandler(this.btnNext1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dgvListOfDatabase);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 627);
            this.panel2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Database(s)";
            // 
            // dgvListOfDatabase
            // 
            this.dgvListOfDatabase.AllowUserToAddRows = false;
            this.dgvListOfDatabase.AllowUserToDeleteRows = false;
            this.dgvListOfDatabase.AllowUserToOrderColumns = true;
            this.dgvListOfDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListOfDatabase.Location = new System.Drawing.Point(15, 37);
            this.dgvListOfDatabase.Margin = new System.Windows.Forms.Padding(15);
            this.dgvListOfDatabase.Name = "dgvListOfDatabase";
            this.dgvListOfDatabase.ReadOnly = true;
            this.dgvListOfDatabase.Size = new System.Drawing.Size(468, 575);
            this.dgvListOfDatabase.TabIndex = 4;
            this.dgvListOfDatabase.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListOfDatabase_CellClick);
            this.dgvListOfDatabase.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListOfDatabase_CellDoubleClick);
            // 
            // tpTablesSelector
            // 
            this.tpTablesSelector.Controls.Add(this.panel1);
            this.tpTablesSelector.Controls.Add(this.panel4);
            this.tpTablesSelector.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tpTablesSelector.Location = new System.Drawing.Point(4, 28);
            this.tpTablesSelector.Name = "tpTablesSelector";
            this.tpTablesSelector.Padding = new System.Windows.Forms.Padding(3);
            this.tpTablesSelector.Size = new System.Drawing.Size(1054, 633);
            this.tpTablesSelector.TabIndex = 1;
            this.tpTablesSelector.Text = "Tables Selector";
            this.tpTablesSelector.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChooseLocation);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dgvColumnsList);
            this.panel1.Controls.Add(this.lblCNumber);
            this.panel1.Controls.Add(this.lblDatabaseName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(537, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 627);
            this.panel1.TabIndex = 12;
            // 
            // btnChooseLocation
            // 
            this.btnChooseLocation.BackColor = System.Drawing.Color.CadetBlue;
            this.btnChooseLocation.FlatAppearance.BorderSize = 0;
            this.btnChooseLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseLocation.ForeColor = System.Drawing.Color.White;
            this.btnChooseLocation.Location = new System.Drawing.Point(17, 527);
            this.btnChooseLocation.Margin = new System.Windows.Forms.Padding(15);
            this.btnChooseLocation.Name = "btnChooseLocation";
            this.btnChooseLocation.Size = new System.Drawing.Size(229, 42);
            this.btnChooseLocation.TabIndex = 71;
            this.btnChooseLocation.Text = "Choose Location";
            this.btnChooseLocation.UseVisualStyleBackColor = false;
            this.btnChooseLocation.Click += new System.EventHandler(this.btnChooseLocation_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Teal;
            this.btnCreate.Enabled = false;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(258, 527);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(15);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(240, 42);
            this.btnCreate.TabIndex = 70;
            this.btnCreate.Text = "Create File";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbBL);
            this.groupBox1.Controls.Add(this.cbDL);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 417);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 95);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Layer";
            // 
            // cbBL
            // 
            this.cbBL.AutoSize = true;
            this.cbBL.Checked = true;
            this.cbBL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBL.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBL.Location = new System.Drawing.Point(232, 34);
            this.cbBL.Name = "cbBL";
            this.cbBL.Size = new System.Drawing.Size(151, 27);
            this.cbBL.TabIndex = 49;
            this.cbBL.Text = "Buisness Layer";
            this.cbBL.UseVisualStyleBackColor = true;
            // 
            // cbDL
            // 
            this.cbDL.AutoSize = true;
            this.cbDL.Checked = true;
            this.cbDL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDL.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDL.Location = new System.Drawing.Point(97, 34);
            this.cbDL.Name = "cbDL";
            this.cbDL.Size = new System.Drawing.Size(119, 27);
            this.cbDL.TabIndex = 48;
            this.cbDL.Text = "Data Layer";
            this.cbDL.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 18);
            this.label9.TabIndex = 61;
            this.label9.Text = "Columns";
            // 
            // dgvColumnsList
            // 
            this.dgvColumnsList.AllowUserToAddRows = false;
            this.dgvColumnsList.AllowUserToDeleteRows = false;
            this.dgvColumnsList.AllowUserToOrderColumns = true;
            this.dgvColumnsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColumnsList.Location = new System.Drawing.Point(27, 232);
            this.dgvColumnsList.Margin = new System.Windows.Forms.Padding(15);
            this.dgvColumnsList.Name = "dgvColumnsList";
            this.dgvColumnsList.ReadOnly = true;
            this.dgvColumnsList.Size = new System.Drawing.Size(468, 143);
            this.dgvColumnsList.TabIndex = 62;
            // 
            // lblCNumber
            // 
            this.lblCNumber.AutoSize = true;
            this.lblCNumber.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCNumber.Location = new System.Drawing.Point(324, 184);
            this.lblCNumber.Name = "lblCNumber";
            this.lblCNumber.Size = new System.Drawing.Size(16, 18);
            this.lblCNumber.TabIndex = 68;
            this.lblCNumber.Text = "0";
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseName.Location = new System.Drawing.Point(324, 156);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(34, 18);
            this.lblDatabaseName.TabIndex = 67;
            this.lblDatabaseName.Text = "N/N";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(184, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 18);
            this.label8.TabIndex = 66;
            this.label8.Text = "Columns Number :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(184, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 18);
            this.label7.TabIndex = 65;
            this.label7.Text = "Database Name  : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Swis721 Blk BT", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label5.Location = new System.Drawing.Point(156, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 35);
            this.label5.TabIndex = 64;
            this.label5.Text = "Select Tables";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(436, 18);
            this.label4.TabIndex = 63;
            this.label4.Text = "Select one or more columns from the available tables to continue.";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkBox1);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.dgvTables);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(534, 627);
            this.panel4.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 593);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 21);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Select All Table";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Table(s)";
            // 
            // dgvTables
            // 
            this.dgvTables.AllowUserToAddRows = false;
            this.dgvTables.AllowUserToDeleteRows = false;
            this.dgvTables.AllowUserToOrderColumns = true;
            this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTables.Location = new System.Drawing.Point(15, 37);
            this.dgvTables.Margin = new System.Windows.Forms.Padding(15);
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.ReadOnly = true;
            this.dgvTables.Size = new System.Drawing.Size(468, 546);
            this.dgvTables.TabIndex = 4;
            this.dgvTables.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTables_CellClick);
            // 
            // frmShowAllDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1116, 719);
            this.Controls.Add(this.tc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowAllDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Database";
            this.Load += new System.EventHandler(this.frmShowAllDatabase_Load);
            this.tc.ResumeLayout(false);
            this.tpDatabaseSelector.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfDatabase)).EndInit();
            this.tpTablesSelector.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumnsList)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc;
        private System.Windows.Forms.TabPage tpDatabaseSelector;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNext1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvListOfDatabase;
        private System.Windows.Forms.TabPage tpTablesSelector;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvTables;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnChooseLocation;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvColumnsList;
        private System.Windows.Forms.Label lblCNumber;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbBL;
        private System.Windows.Forms.CheckBox cbDL;
    }
}