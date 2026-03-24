using Lab.Context;
using Lab.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        pubsContext pubsContext = new();
        private void DetailedView_Load(object sender, EventArgs e)
        {
            FormClosed += (sender, e) => pubsContext.Dispose();
            pubsContext.Employees.Load();
            lstEmlpoyees.DataSource = pubsContext.Employees.Local.ToBindingList();
            lstEmlpoyees.DisplayMember = "Fname";
            lstEmlpoyees.ValueMember = "EmpId";
            txtEmployeeID.DataBindings.Add("Text", pubsContext.Employees.Local.ToBindingList(), "EmpId");


            pubsContext.Jobs.Load();
            cbJob.DataSource = pubsContext.Jobs.Local.ToBindingList();
            cbJob.DisplayMember = "JobDesc";
            cbJob.ValueMember = "JobId";
            cbJob.SelectedValue = ((Employee)lstEmlpoyees.SelectedItem).JobId;
            txtLname.DataBindings.Add("Text", pubsContext.Employees.Local.ToBindingList(), "Lname");
            txtMinit.DataBindings.Add("Text", pubsContext.Employees.Local.ToBindingList(), "Minit");
            txtHiringDate.DataBindings.Add("Text", pubsContext.Employees.Local.ToBindingList(), "HireDate");
            txtJobID.DataBindings.Add("Text", pubsContext.Jobs.Local.ToBindingList(), "JobId");
            txtMinLevel.DataBindings.Add("Text", pubsContext.Jobs.Local.ToBindingList(), "MinLvl");
            txtMaxLevel.DataBindings.Add("Text", pubsContext.Jobs.Local.ToBindingList(), "MaxLvl");
            txtJobLvl.DataBindings.Add("Text", pubsContext.Employees.Local.ToBindingList(), "JobLvl");
            cbJob.DataBindings.Add("SelectedValue", pubsContext.Employees.Local.ToBindingList(), "JobId", true, DataSourceUpdateMode.OnPropertyChanged);


        }

        private void lstEmlpoyees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEmlpoyees.SelectedItem is Employee emp)
            {
                cbJob.SelectedValue = emp.JobId;
                var selectedJob = pubsContext.Jobs.Local.FirstOrDefault(j => j.JobId == emp.JobId);
                if (selectedJob != null)
                {
                    txtMinLevel.Text = selectedJob.MinLvl.ToString();
                    txtMaxLevel.Text = selectedJob.MaxLvl.ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();

                int recordsAffected = pubsContext.SaveChanges();

                MessageBox.Show($"{recordsAffected} record(s) saved successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Error saving to database: {ex.InnerException?.Message ?? ex.Message}",
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstEmlpoyees.SelectedItem is Employee selectedEmp)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {selectedEmp.Fname} {selectedEmp.Lname}?",
                                             "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        pubsContext.Employees.Remove(selectedEmp);
                        pubsContext.SaveChanges();
                        MessageBox.Show("Employee removed successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting employee:" +
                            $" {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to remove.");
            }
        }
    }
}
