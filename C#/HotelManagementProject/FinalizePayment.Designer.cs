namespace Hotel_Manager
{
    partial class FinalizePayment
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
            this.nextButton = new System.Windows.Forms.Button();
            this.reservation = new System.Windows.Forms.Label();
            this.currentBillAmount = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.currentBill = new System.Windows.Forms.Label();
            this.phoneNComboBox = new System.Windows.Forms.TextBox();
            this.paymentLabel = new System.Windows.Forms.Label();
            this.paymentComboBox = new System.Windows.Forms.ComboBox();
            this.metroLabel5 = new System.Windows.Forms.Label();
            this.taxAmount = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalAmount = new System.Windows.Forms.Label();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.metroLabel10 = new System.Windows.Forms.Label();
            this.cvcComboBox = new System.Windows.Forms.TextBox();
            this.cardTypeView = new System.Windows.Forms.Label();
            this.metroLabel12 = new System.Windows.Forms.Label();
            this.foodBillLabel = new System.Windows.Forms.Label();
            this.foodBillAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // nextButton
            this.nextButton.Location = new System.Drawing.Point(340, 243);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(88, 34);
            this.nextButton.TabIndex = 0;
            this.nextButton.Text = "Next";
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);

            // reservation
            this.reservation.AutoSize = true;
            this.reservation.Location = new System.Drawing.Point(14, 25);
            this.reservation.Name = "reservation";
            this.reservation.Size = new System.Drawing.Size(80, 19);
            this.reservation.TabIndex = 1;
            this.reservation.Text = "Reservation";

            // currentBillAmount
            this.currentBillAmount.AutoSize = true;
            this.currentBillAmount.Location = new System.Drawing.Point(356, 48);
            this.currentBillAmount.Name = "currentBillAmount";
            this.currentBillAmount.Size = new System.Drawing.Size(17, 19);
            this.currentBillAmount.TabIndex = 2;
            this.currentBillAmount.Text = "$";
            this.currentBillAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // priceLabel
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(390, 25);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(38, 19);
            this.priceLabel.TabIndex = 3;
            this.priceLabel.Text = "Price";

            // currentBill
            this.currentBill.AutoSize = true;
            this.currentBill.Location = new System.Drawing.Point(14, 48);
            this.currentBill.Name = "currentBill";
            this.currentBill.Size = new System.Drawing.Size(77, 19);
            this.currentBill.TabIndex = 4;
            this.currentBill.Text = "Current bill";

            // phoneNComboBox
            this.phoneNComboBox.BackColor = System.Drawing.Color.White;
            this.phoneNComboBox.Location = new System.Drawing.Point(161, 159);
            this.phoneNComboBox.Name = "phoneNComboBox";
            this.phoneNComboBox.Size = new System.Drawing.Size(267, 23);
            this.phoneNComboBox.TabIndex = 28;
            this.phoneNComboBox.PlaceholderText = "9999 - 9999 - 9999 - 9999";
            this.phoneNComboBox.Leave += new System.EventHandler(this.phoneNComboBox_Leave);

            // paymentLabel
            this.paymentLabel.AutoSize = true;
            this.paymentLabel.BackColor = System.Drawing.Color.Transparent;
            this.paymentLabel.Location = new System.Drawing.Point(14, 137);
            this.paymentLabel.Name = "paymentLabel";
            this.paymentLabel.Size = new System.Drawing.Size(63, 19);
            this.paymentLabel.TabIndex = 25;
            this.paymentLabel.Text = "Payment";

            // paymentComboBox
            this.paymentComboBox.FormattingEnabled = true;
            this.paymentComboBox.Items.AddRange(new object[] { "Credit", "Debit" });
            this.paymentComboBox.Location = new System.Drawing.Point(18, 159);
            this.paymentComboBox.Name = "paymentComboBox";
            this.paymentComboBox.Size = new System.Drawing.Size(128, 23);
            this.paymentComboBox.TabIndex = 29;

            // metroLabel5 (Tax label)
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(267, 99);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(29, 19);
            this.metroLabel5.TabIndex = 30;
            this.metroLabel5.Text = "Tax";

            // taxAmount
            this.taxAmount.AutoSize = true;
            this.taxAmount.Location = new System.Drawing.Point(343, 99);
            this.taxAmount.Name = "taxAmount";
            this.taxAmount.Size = new System.Drawing.Size(17, 19);
            this.taxAmount.TabIndex = 31;
            this.taxAmount.Text = "$";
            this.taxAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // totalLabel
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
            this.totalLabel.Location = new System.Drawing.Point(245, 127);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(42, 19);
            this.totalLabel.TabIndex = 32;
            this.totalLabel.Text = "Total";

            // totalAmount
            this.totalAmount.AutoSize = true;
            this.totalAmount.Location = new System.Drawing.Point(334, 127);
            this.totalAmount.Name = "totalAmount";
            this.totalAmount.Size = new System.Drawing.Size(17, 19);
            this.totalAmount.TabIndex = 33;
            this.totalAmount.Text = "$";
            this.totalAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // monthComboBox
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Items.AddRange(new object[] {
                "01","02","03","04","05","06","07","08","09","10","11","12"});
            this.monthComboBox.Location = new System.Drawing.Point(18, 200);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(59, 23);
            this.monthComboBox.TabIndex = 34;
            this.monthComboBox.SelectedIndexChanged += new System.EventHandler(this.monthComboBox_SelectedIndexChanged);

            // yearComboBox
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Items.AddRange(new object[] {
                "14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30"});
            this.yearComboBox.Location = new System.Drawing.Point(101, 201);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(45, 23);
            this.yearComboBox.TabIndex = 35;

            // metroLabel10 (slash separator)
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(83, 205);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(14, 19);
            this.metroLabel10.TabIndex = 36;
            this.metroLabel10.Text = "/";

            // cvcComboBox
            this.cvcComboBox.BackColor = System.Drawing.Color.White;
            this.cvcComboBox.Location = new System.Drawing.Point(161, 201);
            this.cvcComboBox.Name = "cvcComboBox";
            this.cvcComboBox.Size = new System.Drawing.Size(41, 23);
            this.cvcComboBox.TabIndex = 37;
            this.cvcComboBox.PlaceholderText = "CVC";

            // cardTypeView
            this.cardTypeView.AutoSize = true;
            this.cardTypeView.Location = new System.Drawing.Point(296, 208);
            this.cardTypeView.Name = "cardTypeView";
            this.cardTypeView.Size = new System.Drawing.Size(68, 19);
            this.cardTypeView.TabIndex = 38;
            this.cardTypeView.Text = "Unknown";

            // metroLabel12 (Card type label)
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(215, 207);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(76, 19);
            this.metroLabel12.TabIndex = 39;
            this.metroLabel12.Text = "Card type :";

            // foodBillLabel
            this.foodBillLabel.AutoSize = true;
            this.foodBillLabel.Location = new System.Drawing.Point(14, 72);
            this.foodBillLabel.Name = "foodBillLabel";
            this.foodBillLabel.Size = new System.Drawing.Size(61, 19);
            this.foodBillLabel.TabIndex = 40;
            this.foodBillLabel.Text = "Food bill";

            // foodBillAmount
            this.foodBillAmount.AutoSize = true;
            this.foodBillAmount.Location = new System.Drawing.Point(356, 72);
            this.foodBillAmount.Name = "foodBillAmount";
            this.foodBillAmount.Size = new System.Drawing.Size(17, 19);
            this.foodBillAmount.TabIndex = 41;
            this.foodBillAmount.Text = "$";
            this.foodBillAmount.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // FinalizePayment Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 284);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinalizePayment";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Finalize Payment";
            this.Load += new System.EventHandler(this.FinalizePayment_Load);

            this.Controls.Add(this.foodBillAmount);
            this.Controls.Add(this.foodBillLabel);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.cardTypeView);
            this.Controls.Add(this.cvcComboBox);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.totalAmount);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.taxAmount);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.currentBill);
            this.Controls.Add(this.paymentComboBox);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.currentBillAmount);
            this.Controls.Add(this.phoneNComboBox);
            this.Controls.Add(this.reservation);
            this.Controls.Add(this.paymentLabel);
            this.Controls.Add(this.nextButton);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label reservation;
        private System.Windows.Forms.Label currentBillAmount;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label currentBill;
        private System.Windows.Forms.Label paymentLabel;
        private System.Windows.Forms.Label metroLabel5;
        private System.Windows.Forms.Label taxAmount;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label totalAmount;
        private System.Windows.Forms.Label metroLabel10;
        private System.Windows.Forms.Label cardTypeView;
        private System.Windows.Forms.Label metroLabel12;
        public System.Windows.Forms.TextBox phoneNComboBox;
        public System.Windows.Forms.ComboBox paymentComboBox;
        public System.Windows.Forms.ComboBox monthComboBox;
        public System.Windows.Forms.ComboBox yearComboBox;
        public System.Windows.Forms.TextBox cvcComboBox;
        private System.Windows.Forms.Label foodBillLabel;
        private System.Windows.Forms.Label foodBillAmount;
    }
}