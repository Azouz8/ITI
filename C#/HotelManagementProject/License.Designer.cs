namespace Hotel_Manager
{
    partial class License
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(License));
            this.LicenseText = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // LicenseText
            this.LicenseText.AutoSize = true;
            this.LicenseText.Location = new System.Drawing.Point(-3, 4);
            this.LicenseText.Name = "LicenseText";
            this.LicenseText.Size = new System.Drawing.Size(487, 228);
            this.LicenseText.TabIndex = 0;
            this.LicenseText.Text = resources.GetString("LicenseText.Text");

            // License Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 197);
            this.Controls.Add(this.LicenseText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "License";
            this.Text = "License";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label LicenseText;
    }
}