using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
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
        SqlDataAdapter empSqlDataAdapter;
        SqlDataAdapter jobSqlDataAdapter;

        DataTable dtEmp = new();
        DataTable dtJobs = new();

        private void DetailedView_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString;

            empSqlDataAdapter = new SqlDataAdapter("select * from employee", sqlConnection);

            SqlCommandBuilder empBuilder = new SqlCommandBuilder(empSqlDataAdapter);
            empSqlDataAdapter.UpdateCommand = empBuilder.GetUpdateCommand();
            empSqlDataAdapter.InsertCommand = empBuilder.GetInsertCommand();
            empSqlDataAdapter.DeleteCommand = empBuilder.GetDeleteCommand();

            empSqlDataAdapter.Fill(dtEmp);

            jobSqlDataAdapter = new SqlDataAdapter("select * from jobs", sqlConnection);

            SqlCommandBuilder jobBuilder = new SqlCommandBuilder(jobSqlDataAdapter);
            jobSqlDataAdapter.UpdateCommand = jobBuilder.GetUpdateCommand();
            jobSqlDataAdapter.InsertCommand = jobBuilder.GetInsertCommand();
            jobSqlDataAdapter.DeleteCommand = jobBuilder.GetDeleteCommand();

            jobSqlDataAdapter.Fill(dtJobs);

            numericUpDown.Minimum = 0;
            numericUpDown.Maximum = dtEmp.Rows.Count - 1;

            txtFName.DataBindings.Add("Text", dtEmp, "fname");
            txtLName.DataBindings.Add("Text", dtEmp, "lname");
            txtJobLvl.DataBindings.Add("Text", dtEmp, "job_lvl");
            txtJobID.DataBindings.Add("Text", dtEmp, "job_id");


            comboJobs.DataSource = dtJobs;
            comboJobs.DisplayMember = "job_desc";
            comboJobs.ValueMember = "job_id";

            comboJobs.DataBindings.Add("SelectedValue", dtEmp, "job_id");

        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int index = (int)numericUpDown.Value;
            BindingContext[dtEmp].Position = index;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.BindingContext[dtEmp].EndCurrentEdit();

            int r = empSqlDataAdapter.Update(dtEmp);

            MessageBox.Show($"Employee Updated Successfully ---- {r}");
        }
    }
}