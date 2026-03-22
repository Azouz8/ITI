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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dtEmp = new();
        private void Form3_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString;
            sqlCommand = new("select * from employee", sqlConnection);
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            sqlDataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            sqlDataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
            sqlDataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlDataAdapter.Fill(dtEmp);
            gridViewEmps.DataSource = dtEmp;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sqlDataAdapter.Update(dtEmp);
        }


    }
}
