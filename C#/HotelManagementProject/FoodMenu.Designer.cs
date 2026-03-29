namespace Hotel_Manager
{
    partial class FoodMenu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodMenu));
            this.foodPanel = new System.Windows.Forms.Panel();
            this.dinnerQTY = new System.Windows.Forms.TextBox();
            this.lunchQTY = new System.Windows.Forms.TextBox();
            this.breakfastQTY = new System.Windows.Forms.TextBox();
            this.dinnerPicture = new System.Windows.Forms.PictureBox();
            this.lunchPicture = new System.Windows.Forms.PictureBox();
            this.breakfastPicture = new System.Windows.Forms.PictureBox();
            this.dinnerCheckBox = new System.Windows.Forms.CheckBox();
            this.lunchCheckBox = new System.Windows.Forms.CheckBox();
            this.breakfastCheckBox = new System.Windows.Forms.CheckBox();
            this.foodSelectionLabel = new System.Windows.Forms.Label();
            this.needPanel = new System.Windows.Forms.Panel();
            this.surpriseCheckBox = new System.Windows.Forms.CheckBox();
            this.towelsCheckBox = new System.Windows.Forms.CheckBox();
            this.cleaningCheckBox = new System.Windows.Forms.CheckBox();
            this.specialNeedsLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.foodPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dinnerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lunchPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakfastPicture)).BeginInit();
            this.needPanel.SuspendLayout();
            this.SuspendLayout();

            // foodPanel
            this.foodPanel.BackColor = System.Drawing.Color.FromArgb(225, 225, 225);
            this.foodPanel.Controls.Add(this.dinnerQTY);
            this.foodPanel.Controls.Add(this.lunchQTY);
            this.foodPanel.Controls.Add(this.breakfastQTY);
            this.foodPanel.Controls.Add(this.dinnerPicture);
            this.foodPanel.Controls.Add(this.lunchPicture);
            this.foodPanel.Controls.Add(this.breakfastPicture);
            this.foodPanel.Controls.Add(this.dinnerCheckBox);
            this.foodPanel.Controls.Add(this.lunchCheckBox);
            this.foodPanel.Controls.Add(this.breakfastCheckBox);
            this.foodPanel.Controls.Add(this.foodSelectionLabel);
            this.foodPanel.Location = new System.Drawing.Point(14, 63);
            this.foodPanel.Name = "foodPanel";
            this.foodPanel.Size = new System.Drawing.Size(332, 367);
            this.foodPanel.TabIndex = 5;

            // dinnerQTY
            this.dinnerQTY.BackColor = System.Drawing.Color.White;
            this.dinnerQTY.Enabled = false;
            this.dinnerQTY.Location = new System.Drawing.Point(14, 327);
            this.dinnerQTY.Name = "dinnerQTY";
            this.dinnerQTY.PlaceholderText = "Quantity ?";
            this.dinnerQTY.Size = new System.Drawing.Size(129, 23);
            this.dinnerQTY.TabIndex = 40;

            // lunchQTY
            this.lunchQTY.BackColor = System.Drawing.Color.White;
            this.lunchQTY.Enabled = false;
            this.lunchQTY.Location = new System.Drawing.Point(172, 181);
            this.lunchQTY.Name = "lunchQTY";
            this.lunchQTY.PlaceholderText = "Quantity ?";
            this.lunchQTY.Size = new System.Drawing.Size(144, 23);
            this.lunchQTY.TabIndex = 39;

            // breakfastQTY
            this.breakfastQTY.BackColor = System.Drawing.Color.White;
            this.breakfastQTY.Enabled = false;
            this.breakfastQTY.Location = new System.Drawing.Point(14, 181);
            this.breakfastQTY.Name = "breakfastQTY";
            this.breakfastQTY.PlaceholderText = "Quantity ?";
            this.breakfastQTY.Size = new System.Drawing.Size(129, 23);
            this.breakfastQTY.TabIndex = 38;

            // dinnerPicture
            this.dinnerPicture.Image = ((System.Drawing.Image)(resources.GetObject("dinnerPicture.Image")));
            this.dinnerPicture.Location = new System.Drawing.Point(14, 226);
            this.dinnerPicture.Name = "dinnerPicture";
            this.dinnerPicture.Size = new System.Drawing.Size(129, 75);
            this.dinnerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dinnerPicture.TabIndex = 8;
            this.dinnerPicture.TabStop = false;

            // lunchPicture
            this.lunchPicture.Image = ((System.Drawing.Image)(resources.GetObject("lunchPicture.Image")));
            this.lunchPicture.Location = new System.Drawing.Point(172, 55);
            this.lunchPicture.Name = "lunchPicture";
            this.lunchPicture.Size = new System.Drawing.Size(144, 92);
            this.lunchPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lunchPicture.TabIndex = 7;
            this.lunchPicture.TabStop = false;

            // breakfastPicture
            this.breakfastPicture.Image = ((System.Drawing.Image)(resources.GetObject("breakfastPicture.Image")));
            this.breakfastPicture.Location = new System.Drawing.Point(14, 55);
            this.breakfastPicture.Name = "breakfastPicture";
            this.breakfastPicture.Size = new System.Drawing.Size(129, 92);
            this.breakfastPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.breakfastPicture.TabIndex = 6;
            this.breakfastPicture.TabStop = false;

            // dinnerCheckBox
            this.dinnerCheckBox.AutoSize = true;
            this.dinnerCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.dinnerCheckBox.Location = new System.Drawing.Point(14, 307);
            this.dinnerCheckBox.Name = "dinnerCheckBox";
            this.dinnerCheckBox.Size = new System.Drawing.Size(110, 19);
            this.dinnerCheckBox.TabIndex = 5;
            this.dinnerCheckBox.Text = "Dinner   ($15)";
            this.dinnerCheckBox.CheckedChanged += new System.EventHandler(this.dinnerCheckBox_CheckedChanged);

            // lunchCheckBox
            this.lunchCheckBox.AutoSize = true;
            this.lunchCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.lunchCheckBox.Location = new System.Drawing.Point(172, 156);
            this.lunchCheckBox.Name = "lunchCheckBox";
            this.lunchCheckBox.Size = new System.Drawing.Size(106, 19);
            this.lunchCheckBox.TabIndex = 4;
            this.lunchCheckBox.Text = "Lunch   ($15)";
            this.lunchCheckBox.CheckedChanged += new System.EventHandler(this.lunchCheckBox_CheckedChanged);

            // breakfastCheckBox
            this.breakfastCheckBox.AutoSize = true;
            this.breakfastCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.breakfastCheckBox.Location = new System.Drawing.Point(14, 156);
            this.breakfastCheckBox.Name = "breakfastCheckBox";
            this.breakfastCheckBox.Size = new System.Drawing.Size(120, 19);
            this.breakfastCheckBox.TabIndex = 3;
            this.breakfastCheckBox.Text = "Break Fast  ($7)";
            this.breakfastCheckBox.CheckedChanged += new System.EventHandler(this.breakfastCheckBox_CheckedChanged);

            // foodSelectionLabel
            this.foodSelectionLabel.BackColor = System.Drawing.Color.Transparent;
            this.foodSelectionLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.foodSelectionLabel.Location = new System.Drawing.Point(3, 10);
            this.foodSelectionLabel.Name = "foodSelectionLabel";
            this.foodSelectionLabel.Size = new System.Drawing.Size(173, 28);
            this.foodSelectionLabel.TabIndex = 2;
            this.foodSelectionLabel.Text = "Food Selection";

            // needPanel
            this.needPanel.BackColor = System.Drawing.Color.FromArgb(225, 225, 225);
            this.needPanel.Controls.Add(this.surpriseCheckBox);
            this.needPanel.Controls.Add(this.towelsCheckBox);
            this.needPanel.Controls.Add(this.cleaningCheckBox);
            this.needPanel.Controls.Add(this.specialNeedsLabel);
            this.needPanel.Location = new System.Drawing.Point(355, 63);
            this.needPanel.Name = "needPanel";
            this.needPanel.Size = new System.Drawing.Size(164, 326);
            this.needPanel.TabIndex = 6;

            // surpriseCheckBox
            this.surpriseCheckBox.AutoSize = true;
            this.surpriseCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.surpriseCheckBox.Location = new System.Drawing.Point(18, 128);
            this.surpriseCheckBox.Name = "surpriseCheckBox";
            this.surpriseCheckBox.Size = new System.Drawing.Size(131, 19);
            this.surpriseCheckBox.TabIndex = 44;
            this.surpriseCheckBox.Text = "Sweetest surprise";

            // towelsCheckBox
            this.towelsCheckBox.AutoSize = true;
            this.towelsCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.towelsCheckBox.Location = new System.Drawing.Point(18, 91);
            this.towelsCheckBox.Name = "towelsCheckBox";
            this.towelsCheckBox.Size = new System.Drawing.Size(66, 19);
            this.towelsCheckBox.TabIndex = 42;
            this.towelsCheckBox.Text = "Towels";

            // cleaningCheckBox
            this.cleaningCheckBox.AutoSize = true;
            this.cleaningCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.cleaningCheckBox.Location = new System.Drawing.Point(18, 55);
            this.cleaningCheckBox.Name = "cleaningCheckBox";
            this.cleaningCheckBox.Size = new System.Drawing.Size(78, 19);
            this.cleaningCheckBox.TabIndex = 41;
            this.cleaningCheckBox.Text = "Cleaning";

            // specialNeedsLabel
            this.specialNeedsLabel.BackColor = System.Drawing.Color.Transparent;
            this.specialNeedsLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.specialNeedsLabel.Location = new System.Drawing.Point(3, 10);
            this.specialNeedsLabel.Name = "specialNeedsLabel";
            this.specialNeedsLabel.Size = new System.Drawing.Size(121, 28);
            this.specialNeedsLabel.TabIndex = 41;
            this.specialNeedsLabel.Text = "Special needs";

            // nextButton
            this.nextButton.Location = new System.Drawing.Point(355, 396);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(164, 34);
            this.nextButton.TabIndex = 45;
            this.nextButton.Text = "Next";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);

            // FoodMenu Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 442);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.needPanel);
            this.Controls.Add(this.foodPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FoodMenu";
            this.ShowInTaskbar = false;
            this.Text = "Food and Menu";

            this.foodPanel.ResumeLayout(false);
            this.foodPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dinnerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lunchPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakfastPicture)).EndInit();
            this.needPanel.ResumeLayout(false);
            this.needPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel foodPanel;
        private System.Windows.Forms.Label foodSelectionLabel;
        private System.Windows.Forms.PictureBox dinnerPicture;
        private System.Windows.Forms.PictureBox lunchPicture;
        private System.Windows.Forms.PictureBox breakfastPicture;
        public System.Windows.Forms.TextBox breakfastQTY;
        public System.Windows.Forms.TextBox dinnerQTY;
        public System.Windows.Forms.TextBox lunchQTY;
        private System.Windows.Forms.Label specialNeedsLabel;
        public System.Windows.Forms.CheckBox dinnerCheckBox;
        public System.Windows.Forms.CheckBox lunchCheckBox;
        public System.Windows.Forms.CheckBox breakfastCheckBox;
        public System.Windows.Forms.CheckBox surpriseCheckBox;
        public System.Windows.Forms.CheckBox towelsCheckBox;
        public System.Windows.Forms.CheckBox cleaningCheckBox;
        public System.Windows.Forms.Panel needPanel;
        public System.Windows.Forms.Button nextButton;
    }
}