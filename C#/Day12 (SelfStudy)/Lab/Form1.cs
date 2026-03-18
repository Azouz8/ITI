namespace Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are u Sure u want to Exit?", "Warning",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MinimumSize = Size;
            btnClose.Click += (sender, e) => Close();
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Rich Text Files|*.rtf|Text Files|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtfTxt.LoadFile(openFileDialog1.FileName, (RichTextBoxStreamType)(openFileDialog1.FilterIndex - 1));
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Rich Text Files|*.rtf|Text File   s|*.txt";
            saveFileDialog1.InitialDirectory = "D:";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtfTxt.SaveFile(openFileDialog1.FileName, (RichTextBoxStreamType)(openFileDialog1.FilterIndex - 1));
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (rtfTxt.SelectedText?.Length > 0)
            {
                fontDialog1.Font = rtfTxt.SelectionFont;
            }
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                rtfTxt.SelectionFont = fontDialog1.Font;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (rtfTxt.SelectedText?.Length > 0)
            {
                colorDialog1.Color = rtfTxt.SelectionColor;
            }
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rtfTxt.SelectionColor = colorDialog1.Color;
            }
        }
        Form2 form2 = new();
        private void btnCust_Click(object sender, EventArgs e)
        {
            form2.SetText("TypeHere");
            if(form2.ShowDialog() == DialogResult.OK)
            {
                this.rtfTxt.AppendText(form2.GetText());
            }
        }
    }
}
