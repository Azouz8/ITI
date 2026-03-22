using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace UI
{
    partial class frmUpdateField
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
            lstEmlpoyees = new ListBox();
            txtEmployeeID = new TextBox();
            txtHiringDate = new TextBox();
            txtLname = new TextBox();
            txtMinit = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMaxLevel = new TextBox();
            txtMinLevel = new TextBox();
            txtJobID = new TextBox();
            label1 = new Label();
            label7 = new Label();
            label8 = new Label();
            cbJob = new ComboBox();
            btnSave = new Button();
            txtJobLvl = new TextBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // lstEmlpoyees
            // 
            lstEmlpoyees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lstEmlpoyees.FormattingEnabled = true;
            lstEmlpoyees.Location = new Point(593, 0);
            lstEmlpoyees.Margin = new Padding(3, 2, 3, 2);
            lstEmlpoyees.Name = "lstEmlpoyees";
            lstEmlpoyees.Size = new Size(179, 409);
            lstEmlpoyees.TabIndex = 0;
            lstEmlpoyees.SelectedIndexChanged += lstEmlpoyees_SelectedIndexChanged;
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(125, 53);
            txtEmployeeID.Margin = new Padding(3, 2, 3, 2);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(145, 23);
            txtEmployeeID.TabIndex = 1;
            // 
            // txtHiringDate
            // 
            txtHiringDate.Location = new Point(125, 278);
            txtHiringDate.Margin = new Padding(3, 2, 3, 2);
            txtHiringDate.Name = "txtHiringDate";
            txtHiringDate.Size = new Size(145, 23);
            txtHiringDate.TabIndex = 2;
            // 
            // txtLname
            // 
            txtLname.Location = new Point(125, 110);
            txtLname.Margin = new Padding(3, 2, 3, 2);
            txtLname.Name = "txtLname";
            txtLname.Size = new Size(145, 23);
            txtLname.TabIndex = 5;
            // 
            // txtMinit
            // 
            txtMinit.Location = new Point(125, 166);
            txtMinit.Margin = new Padding(3, 2, 3, 2);
            txtMinit.Name = "txtMinit";
            txtMinit.Size = new Size(145, 23);
            txtMinit.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 110);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 8;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 166);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 9;
            label3.Text = "minit";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 222);
            label4.Name = "label4";
            label4.Size = new Size(25, 15);
            label4.TabIndex = 10;
            label4.Text = "Job";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 278);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 11;
            label5.Text = "Hiring Date";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 53);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 12;
            label6.Text = "Employee ID";
            // 
            // txtMaxLevel
            // 
            txtMaxLevel.Location = new Point(392, 166);
            txtMaxLevel.Margin = new Padding(3, 2, 3, 2);
            txtMaxLevel.Name = "txtMaxLevel";
            txtMaxLevel.Size = new Size(145, 23);
            txtMaxLevel.TabIndex = 16;
            // 
            // txtMinLevel
            // 
            txtMinLevel.Location = new Point(392, 110);
            txtMinLevel.Margin = new Padding(3, 2, 3, 2);
            txtMinLevel.Name = "txtMinLevel";
            txtMinLevel.Size = new Size(145, 23);
            txtMinLevel.TabIndex = 15;
            // 
            // txtJobID
            // 
            txtJobID.Location = new Point(392, 53);
            txtJobID.Margin = new Padding(3, 2, 3, 2);
            txtJobID.Name = "txtJobID";
            txtJobID.Size = new Size(145, 23);
            txtJobID.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(295, 58);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 19;
            label1.Text = "Job ID";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(295, 171);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 18;
            label7.Text = "Max Level";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(295, 115);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 17;
            label8.Text = "Min Level";
            // 
            // cbJob
            // 
            cbJob.FormattingEnabled = true;
            cbJob.Location = new Point(125, 222);
            cbJob.Margin = new Padding(3, 2, 3, 2);
            cbJob.Name = "cbJob";
            cbJob.Size = new Size(145, 23);
            cbJob.TabIndex = 20;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(431, 326);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(105, 40);
            btnSave.TabIndex = 21;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtJobLvl
            // 
            txtJobLvl.Location = new Point(392, 222);
            txtJobLvl.Name = "txtJobLvl";
            txtJobLvl.Size = new Size(144, 23);
            txtJobLvl.TabIndex = 22;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(295, 230);
            label9.Name = "label9";
            label9.Size = new Size(46, 15);
            label9.TabIndex = 23;
            label9.Text = "Job LVL";
            // 
            // frmUpdateField
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 415);
            Controls.Add(label9);
            Controls.Add(txtJobLvl);
            Controls.Add(btnSave);
            Controls.Add(cbJob);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(txtMaxLevel);
            Controls.Add(txtMinLevel);
            Controls.Add(txtJobID);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtMinit);
            Controls.Add(txtLname);
            Controls.Add(txtHiringDate);
            Controls.Add(txtEmployeeID);
            Controls.Add(lstEmlpoyees);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmUpdateField";
            Text = "DetailedView";
            Load += frmUpdateField_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstEmlpoyees;
        private TextBox txtEmployeeID;
        private TextBox txtHiringDate;
        private TextBox txtLname;
        private TextBox txtMinit;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtMaxLevel;
        private TextBox txtMinLevel;
        private TextBox txtJobID;
        private Label label1;
        private Label label7;
        private Label label8;
        private ComboBox cbJob;
        private Button btnSave;
        private TextBox txtJobLvl;
        private Label label9;
    }
}