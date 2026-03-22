using BLL.Entities;
using BLL.EntityList;
using BLL.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class frmUpdateField : Form
    {
        public frmUpdateField()
        {
            InitializeComponent();
        }
        BindingSource empBindingSrc;
        EmployeeList employees;
        JobList jobs;
        JobList jobListDesc;
        BindingSource jobBS;
        BindingSource jobDescBS;
        private void frmUpdateField_Load(object sender, EventArgs e)
        {
            employees = EmployeeManager.GetAllEmloyees();
            jobs = JobManager.GetAllJobs();
            jobListDesc = JobManager.GetAllJobs();
            empBindingSrc = new BindingSource(employees, "");
            jobBS = new BindingSource(jobs, "");
            jobDescBS = new BindingSource(jobListDesc, "");

            lstEmlpoyees.DataSource = empBindingSrc;
            lstEmlpoyees.DisplayMember = "Fname";
            lstEmlpoyees.ValueMember = "emp_id";

            cbJob.DataSource = jobDescBS;
            cbJob.DisplayMember = "Job_desc";
            cbJob.ValueMember = "Job_id";

            txtEmployeeID.DataBindings.Add("Text", empBindingSrc, "Emp_id");
            txtLname.DataBindings.Add("Text", empBindingSrc, "Lname");
            txtMinit.DataBindings.Add("Text", empBindingSrc, "Minit");

            cbJob.SelectedValue = ((Employee)lstEmlpoyees.SelectedItem).Job_id;
            txtHiringDate.DataBindings.Add("Text", empBindingSrc, "Hire_date");
            txtJobID.DataBindings.Add("Text", jobBS, "Job_id");
            txtMinLevel.DataBindings.Add("Text", jobBS, "Min_lvl");
            txtMaxLevel.DataBindings.Add("Text", jobBS, "Max_lvl");
            txtJobLvl.DataBindings.Add("Text", empBindingSrc, "job_lvl");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var emp = empBindingSrc.Current as Employee;
            if (emp == null) return;

            short newJobId = Convert.ToInt16(cbJob.SelectedValue);
            if (newJobId == emp.Job_id) return;
            bool isSuccess = EmployeeManager.UpdateJobID(emp.Emp_id, newJobId);
            if (isSuccess)
            {
                emp.Job_id = newJobId;
                empBindingSrc.ResetCurrentItem();
            }
        }
        private void lstEmlpoyees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEmlpoyees.SelectedItem is Employee emp)
            {
                cbJob.SelectedValue = emp.Job_id;
                var selectedJob = jobs.FirstOrDefault(j => j.Job_id == emp.Job_id);
                if (selectedJob != null)
                {
                    jobBS.Position = jobBS.IndexOf(selectedJob);
                }
            }
        }
    }
}
