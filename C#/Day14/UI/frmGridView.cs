using BLL.EntityList;
using BLL.EntityManager;
using System.Data;

namespace UI
{
    public partial class frmGridView : Form
    {
        public frmGridView()
        {
            InitializeComponent();
        }
        BindingSource empBindingSource;
        DataTable dtEmployees;
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtEmployees = EmployeeManager.GetAllEmployeesDataTable();
            //employeeList = EmployeeManager.DataTableToEmpList(dtEmployees);
            empBindingSource = new BindingSource(dtEmployees, "");
            grdView.DataSource = empBindingSource;
        }

        private void saToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeManager.SaveChanges(dtEmployees);
        }

    }
}
