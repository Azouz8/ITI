using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hotel_Manager
{
    public partial class Login : Form
    {
        private string LoginConnectionString => Hotel_Manager.Properties.Settings.Default.loginConnectionString;

        public Login()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void signinButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (verifier("frontend", usernameTextBox.Text.Trim(), passwordTextBox.Text.Trim()))
                {
                    this.Hide();
                    Frontend hotel_management = new Frontend();
                    hotel_management.Show();
                }
                else if (verifier("kitchen", usernameTextBox.Text.Trim(), passwordTextBox.Text.Trim()))
                {
                    this.Hide();
                    Kitchen kitchen_management = new Kitchen();
                    kitchen_management.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password is wrong, try again", "Login Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
        }

        private void usernameTextBox_Click(object sender, EventArgs e) { }

        private void passwordTextBox_Click(object sender, EventArgs e) { }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!usernameLabel.Bounds.Contains(e.Location) && usernameTextBox.Text == string.Empty)
                usernameLabel.Visible = false;
            if (!passwordLabel.Bounds.Contains(e.Location) && passwordTextBox.Text == string.Empty)
                passwordLabel.Visible = false;
        }

        public bool verifier(string tableName, string username, string password)
        {
            string sql = $"SELECT COUNT(1) FROM {tableName} WHERE user_name = @userName AND pass_word = @password";
            try
            {
                using (var conn = new SqlConnection(LoginConnectionString))
                {
                    int count = conn.ExecuteScalar<int>(sql, new { userName = username, password = password });
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return false;
            }
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LicenseCallButton_Click(object sender, EventArgs e)
        {
            License open_license = new License();
            open_license.ShowDialog();
        }
    }
}