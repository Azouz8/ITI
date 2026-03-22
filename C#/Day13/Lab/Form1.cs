using Microsoft.Data.SqlClient;
using System.Configuration;

namespace Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection();
            sqlConnection?.ConnectionString = ConfigurationManager.ConnectionStrings["pubsCN"].ConnectionString;
            sqlConnection?.StateChange += sqlConnection1_StateChange;
            FormClosed += Form1_FormClosed;
        }

        SqlConnection sqlConnection;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection?.Open();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            sqlConnection.Close();
        }

        private void sqlConnection1_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            Text = $"State was {e.OriginalState} and now the state is {e.CurrentState}";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqlConnection?.Dispose();
        }
    }
}
