using Lab.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab
{
    public partial class frmGridView : Form
    {
        public frmGridView()
        {
            InitializeComponent();
        }
        pubsContext pubsContext = new();
        BindingSource bindingSource;

        private void frmGridView_Load(object sender, EventArgs e)
        {
            FormClosed += (sender, e) => pubsContext.Dispose();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pubsContext.Employees.Load();
            grdViewEmp.DataSource = pubsContext.Employees.Local.ToBindingList();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grdViewEmp.EndEdit();
            pubsContext.SaveChanges();
        }
    }
}
