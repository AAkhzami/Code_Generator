namespace Code_Generator_DApp.Controls.Engine_Setup
{
    partial class ctrlExecutionEngine
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2CustomRadioButton1 = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 21F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(78, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 34);
            this.label4.TabIndex = 7;
            this.label4.Text = "Execution Engine";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(139)))), ((int)(((byte)(153)))));
            this.label5.Location = new System.Drawing.Point(80, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(365, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Choose how database operations will be executed.";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.Controls.Add(this.guna2GradientPanel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(88, 71);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1211, 120);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2GradientPanel1.BorderRadius = 8;
            this.guna2GradientPanel1.BorderThickness = 2;
            this.guna2GradientPanel1.Controls.Add(this.guna2Panel1);
            this.guna2GradientPanel1.Controls.Add(this.label2);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Controls.Add(this.guna2CustomRadioButton1);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.SetFlowBreak(this.guna2GradientPanel1, true);
            this.guna2GradientPanel1.Location = new System.Drawing.Point(3, 3);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(597, 115);
            this.guna2GradientPanel1.TabIndex = 4;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 9;
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(89)))), ((int)(((byte)(209)))));
            this.guna2Panel1.Location = new System.Drawing.Point(20, 25);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(65, 65);
            this.guna2Panel1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Code_Generator_DApp.Properties.Resources.box;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(139)))), ((int)(((byte)(153)))));
            this.label2.Location = new System.Drawing.Point(96, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 38);
            this.label2.TabIndex = 11;
            this.label2.Text = "Generates stored procedures and calls them\r\nfrom your C# code. More secure and pe" +
    "rformant.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(34)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(95, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Stored Procedures (T-SQL)";
            // 
            // guna2CustomRadioButton1
            // 
            this.guna2CustomRadioButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomRadioButton1.Checked = true;
            this.guna2CustomRadioButton1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CustomRadioButton1.CheckedState.BorderThickness = 0;
            this.guna2CustomRadioButton1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CustomRadioButton1.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2CustomRadioButton1.Location = new System.Drawing.Point(556, 11);
            this.guna2CustomRadioButton1.Name = "guna2CustomRadioButton1";
            this.guna2CustomRadioButton1.Size = new System.Drawing.Size(34, 24);
            this.guna2CustomRadioButton1.TabIndex = 0;
            this.guna2CustomRadioButton1.Text = "guna2CustomRadioButton1";
            this.guna2CustomRadioButton1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CustomRadioButton1.UncheckedState.BorderThickness = 2;
            this.guna2CustomRadioButton1.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.guna2CustomRadioButton1.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // ctrlExecutionEngine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "ctrlExecutionEngine";
            this.Size = new System.Drawing.Size(1377, 194);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CustomRadioButton guna2CustomRadioButton1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
