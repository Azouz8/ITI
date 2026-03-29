using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace Hotel_Manager
{
    public partial class FinalizePayment : Form
    {
        public FinalizePayment()
        {
            InitializeComponent();
            CenterToParent();
        }

        public int totalAmountFromFrontend = 0;
        public int foodBill = 0;
        private double finalTotalFinalized = 0.0;
        private string paymentType;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double FinalTotalFinalized
        {
            get { return finalTotalFinalized; }
            set { finalTotalFinalized = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }

        private string paymentCardNumber;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string PaymentCardNumber
        {
            get { return paymentCardNumber; }
            set { paymentCardNumber = value; }
        }

        private string MM_YY_Of_Card;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string MM_YY_Of_Card1
        {
            get { return MM_YY_Of_Card; }
            set { MM_YY_Of_Card = value; }
        }

        private string CVC_Of_Card;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string CVC_Of_Card1
        {
            get { return CVC_Of_Card; }
            set { CVC_Of_Card = value; }
        }

        private string CardType;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string CardType1
        {
            get { return CardType; }
            set { CardType = value; }
        }

        private void FinalizePayment_Load(object sender, EventArgs e)
        {
            double totalWithTax = Convert.ToDouble(totalAmountFromFrontend) * 0.07;
            double FinalTotal = Convert.ToDouble(totalAmountFromFrontend) + totalWithTax + foodBill;
            currentBillAmount.Text = "$" + Convert.ToString(totalAmountFromFrontend) + " USD";
            foodBillAmount.Text = "$" + Convert.ToString(foodBill) + " USD";
            taxAmount.Text = "$" + Convert.ToString(totalWithTax) + " USD";
            totalAmount.Text = "$" + Convert.ToString(FinalTotal) + " USD";
            FinalTotalFinalized = FinalTotal;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            try
            {
                PaymentType = paymentComboBox.Text;
                PaymentCardNumber = phoneNComboBox.Text;
                MM_YY_Of_Card1 = monthComboBox.SelectedItem.ToString() + "/" + yearComboBox.SelectedItem.ToString();
                CVC_Of_Card1 = cvcComboBox.Text;
                CardType1 = cardTypeView.Text;

                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Error closing the window", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void monthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(phoneNComboBox.Text))
            {
                cardTypeView.Text = "Unknown";
                return;
            }

            switch (phoneNComboBox.Text.Substring(0, 1))
            {
                case "3": cardTypeView.Text = "AmericanExpress"; break;
                case "4": cardTypeView.Text = "Visa"; break;
                case "5": cardTypeView.Text = "MasterCard"; break;
                case "6": cardTypeView.Text = "Discover"; break;
                default: cardTypeView.Text = "Unknown"; break;
            }
        }

        private void phoneNComboBox_Leave(object sender, EventArgs e)
        {
            if (long.TryParse(phoneNComboBox.Text.Replace("-", "").Replace(" ", ""), out long getphn))
            {
                phoneNComboBox.Text = string.Format("{0:0000-0000-0000-0000}", getphn);
            }
        }
    }
}