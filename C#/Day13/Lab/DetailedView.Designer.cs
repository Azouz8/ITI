namespace Lab
{
    partial class DetailedView
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
            label1 = new Label();
            label2 = new Label();
            txtFName = new TextBox();
            txtLName = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtJobID = new TextBox();
            txtJobLvl = new TextBox();
            numericUpDown = new NumericUpDown();
            label5 = new Label();
            btnSave = new Button();
            comboJobs = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 1;
            label1.Text = "FName";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 60);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 2;
            label2.Text = "LName";
            // 
            // txtFName
            // 
            txtFName.Location = new Point(71, 25);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(153, 23);
            txtFName.TabIndex = 3;
            // 
            // txtLName
            // 
            txtLName.Location = new Point(71, 60);
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(153, 23);
            txtLName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 97);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 5;
            label3.Text = "Job ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 136);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 6;
            label4.Text = "Jop Lvl";
            // 
            // txtJobID
            // 
            txtJobID.Location = new Point(71, 94);
            txtJobID.Name = "txtJobID";
            txtJobID.Size = new Size(153, 23);
            txtJobID.TabIndex = 7;
            // 
            // txtJobLvl
            // 
            txtJobLvl.Location = new Point(71, 133);
            txtJobLvl.Name = "txtJobLvl";
            txtJobLvl.Size = new Size(153, 23);
            txtJobLvl.TabIndex = 8;
            // 
            // numericUpDown
            // 
            numericUpDown.Location = new Point(449, 26);
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(120, 23);
            numericUpDown.TabIndex = 9;
            numericUpDown.ValueChanged += numericUpDown_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 178);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 10;
            label5.Text = "Job Desc";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(103, 243);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // comboJobs
            // 
            comboJobs.FormattingEnabled = true;
            comboJobs.Location = new Point(71, 175);
            comboJobs.Name = "comboJobs";
            comboJobs.Size = new Size(153, 23);
            comboJobs.TabIndex = 13;
            // 
            // DetailedView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboJobs);
            Controls.Add(btnSave);
            Controls.Add(label5);
            Controls.Add(numericUpDown);
            Controls.Add(txtJobLvl);
            Controls.Add(txtJobID);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtLName);
            Controls.Add(txtFName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DetailedView";
            Text = "DetailedView";
            Load += DetailedView_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private TextBox txtFName;
        private TextBox txtLName;
        private Label label3;
        private Label label4;
        private TextBox txtJobID;
        private TextBox txtJobLvl;
        private NumericUpDown numericUpDown;
        private Label label5;
        private Button btnSave;
        private ComboBox comboJobs;
    }
}