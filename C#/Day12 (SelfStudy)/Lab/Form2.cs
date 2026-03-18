using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab
{
    public partial class Form2 : Form
    {
        public string GetText()
        {
            return textBox1.Text;
        }

        public void SetText(string value)
        {
            textBox1.Text = value;
        }

        public Form2()
        {
            InitializeComponent();
        }
    }
}
