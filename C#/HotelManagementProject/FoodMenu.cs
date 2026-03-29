using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace Hotel_Manager
{
    public partial class FoodMenu : Form
    {
        public FoodMenu()
        {
            InitializeComponent();
        }

        private int lunchQ = 0;
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public int LunchQ
        {
            get { return lunchQ; }
            set { lunchQ = value; }
        }

        private int breakfastQ = 0;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BreakfastQ
        {
            get { return breakfastQ; }
            set { breakfastQ = value; }
        }

        private int dinnerQ = 0;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DinnerQ
        {
            get { return dinnerQ; }
            set { dinnerQ = value; }
        }

        private string cleaning = "";
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Cleaning
        {
            get { return cleaning; }
            set { cleaning = value; }
        }

        private string towel = "";
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Towel
        {
            get { return towel; }
            set { towel = value; }
        }

        private string surprise = "";
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Surprise
        {
            get { return surprise; }
            set { surprise = value; }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (breakfastCheckBox.Checked)
            {
                if (!int.TryParse(breakfastQTY.Text, out int bq) || bq <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity for Breakfast.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                BreakfastQ = bq;
            }

            if (lunchCheckBox.Checked)
            {
                if (!int.TryParse(lunchQTY.Text, out int lq) || lq <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity for Lunch.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                LunchQ = lq;
            }

            if (dinnerCheckBox.Checked)
            {
                if (!int.TryParse(dinnerQTY.Text, out int dq) || dq <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity for Dinner.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DinnerQ = dq;
            }

            if (cleaningCheckBox.Checked)
                Cleaning = cleaningCheckBox.Text;

            if (towelsCheckBox.Checked)
                Towel = towelsCheckBox.Text;

            if (surpriseCheckBox.Checked)
                Surprise = surpriseCheckBox.Text;

            this.Hide();
        }

        private void breakfastCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            breakfastQTY.Enabled = breakfastCheckBox.Checked;
            if (!breakfastCheckBox.Checked)
                breakfastQTY.Clear();
        }

        private void lunchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lunchQTY.Enabled = lunchCheckBox.Checked;
            if (!lunchCheckBox.Checked)
                lunchQTY.Clear();
        }

        private void dinnerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dinnerQTY.Enabled = dinnerCheckBox.Checked;
            if (!dinnerCheckBox.Checked)
                dinnerQTY.Clear();
        }
    }
}