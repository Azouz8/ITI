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
    public partial class DetailedView : Form
    {
        public DetailedView()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter empSqlDataAdapter;
        SqlDataAdapter jobSqlDataAdapter;
        DataTable dtEmp = new();
        DataTable dtJobs = new();
        private void DetailedView_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString;
            sqlCommand = new("select * from employee", sqlConnection);
            empSqlDataAdapter = new SqlDataAdapter(sqlCommand);

            SqlCommandBuilder empCommandBuilder = new SqlCommandBuilder(empSqlDataAdapter);
            empSqlDataAdapter.UpdateCommand = empCommandBuilder.GetUpdateCommand();
            empSqlDataAdapter.InsertCommand = empCommandBuilder.GetInsertCommand();
            empSqlDataAdapter.DeleteCommand = empCommandBuilder.GetDeleteCommand();
            empSqlDataAdapter.Fill(dtEmp);

            sqlCommand = new("select * from jobs", sqlConnection);
            jobSqlDataAdapter = new SqlDataAdapter(sqlCommand);
            SqlCommandBuilder jobCommandBuilder = new SqlCommandBuilder(jobSqlDataAdapter);
            jobSqlDataAdapter.UpdateCommand = jobCommandBuilder.GetUpdateCommand();
            jobSqlDataAdapter.InsertCommand = jobCommandBuilder.GetInsertCommand();
            jobSqlDataAdapter.DeleteCommand = jobCommandBuilder.GetDeleteCommand();
            jobSqlDataAdapter.Fill(dtJobs);

            numericUpDown.Minimum = 0;
            numericUpDown.Maximum = dtEmp.Rows.Count - 1;

            txtFName.DataBindings.Add("Text", dtEmp, "fname");
            txtLName.DataBindings.Add("Text", dtEmp, "lname");
            txtJobID.DataBindings.Add("Text", dtEmp, "job_id");
            txtJobLvl.DataBindings.Add("Text", dtEmp, "job_lvl");
            txtJobDesc.DataBindings.Add("Text", dtJobs, "job_desc");
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int index = (int)numericUpDown.Value;
            BindingContext[dtEmp].Position = index;
            var jobId = dtEmp.Rows[index]["job_id"];
            var result = dtJobs.Select($"job_id = {jobId}");

            if (result.Length > 0)
            {
                txtJobDesc.Text = result[0]["job_desc"].ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int index = (int)numericUpDown.Value;
            var jobId = dtEmp.Rows[index]["job_id"];
            var result = dtJobs.Select($"job_id = {jobId}");
            if (result.Length > 0)
            {
                result[0]["job_desc"] = txtJobDesc.Text;
                jobSqlDataAdapter.Update(dtJobs);
                MessageBox.Show("Job Description Updated Successfully");
            }
        }
    }
}
