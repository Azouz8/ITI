using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        private void Form2_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString;
            sqlCommand = new();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "select * from employee";
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();

            SqlDataReader Reader = sqlCommand.ExecuteReader();

            while (Reader.Read())
            {
                lstEmpNames.Items.Add(Reader.GetString("fname"));
            }
            sqlConnection.Close();
        }
    }
}
