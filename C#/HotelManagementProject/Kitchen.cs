using Dapper;
using Hotel_Manager.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Manager
{
    public partial class Kitchen : Form
    {
        string cleaning, towel, surprise;
        int breakfast, lunch, dinner, foodBill;
        public Int32 primaryID;
        double totalBill;
        bool supply_status = false;

        private string ConnectionString => Hotel_Manager.Properties.Settings.Default.frontend_reservationConnectionString;

        private HotelContext CreateDbContext() =>
            new HotelContext();

        public Kitchen()
        {
            InitializeComponent();
        }

        private void kitchen_Load(object sender, EventArgs e)
        {
            LoadForDataGridView();
            listBoxFromDataBase();
        }

        private void LoadForDataGridView()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    string sql = @"SELECT Id, first_name, last_name, phone_number, room_type, room_floor,
                                          room_number, break_fast, lunch, dinner, cleaning, towel,
                                          s_surprise, supply_status, food_bill
                                   FROM reservation
                                   WHERE check_in = 1 AND supply_status = 0";

                    var rows = conn.Query<ReservationEntity>(sql).ToList();
                    var table = ToDataTable(rows);
                    var bs = new BindingSource { DataSource = table };
                    overviewDataGridView.DataSource = bs;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading data", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.None);
            }
        }

        private void resetEntries(System.Windows.Forms.Control controls)
        {
            foreach (System.Windows.Forms.Control control in controls.Controls)
            {
                if (control is TextBox) ((TextBox)control).Clear();
                if (control.HasChildren) resetEntries(control);
            }
        }

        private void listBoxFromDataBase()
        {
            queueListBox.Items.Clear();
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var rows = conn.Query<ReservationEntity>(
                        "SELECT Id, first_name, last_name, phone_number FROM reservation WHERE check_in = 1 AND supply_status = 0");
                    foreach (var row in rows)
                        queueListBox.Items.Add(row.Id + "  | " + row.first_name + "  " + row.last_name + " | " + row.phone_number);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void queueListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetEntries(this);
            string getQuerystring = queueListBox.Text.Substring(0, 4).Replace(" ", string.Empty);

            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var row = conn.QueryFirstOrDefault<ReservationEntity>(
                        "SELECT * FROM reservation WHERE Id = @Id",
                        new { Id = int.Parse(getQuerystring) });

                    if (row == null) return;

                    if (row.cleaning) { cleaning = "1"; cleaningCheckBox.Checked = true; } else cleaning = "0";
                    if (row.towel) { towel = "1"; towelCheckBox.Checked = true; } else towel = "0";
                    if (row.s_surprise) { surprise = "1"; surpriseCheckBox.Checked = true; } else surprise = "0";

                    lunch = row.lunch;
                    breakfast = row.break_fast;
                    dinner = row.dinner;

                    lunchTextBox.Text = lunch > 0 ? Convert.ToString(lunch) : "NONE";
                    breakfastTextBox.Text = breakfast > 0 ? Convert.ToString(breakfast) : "NONE";
                    dinnerTextBox.Text = dinner > 0 ? Convert.ToString(dinner) : "NONE";

                    supplyCheckBox.Checked = row.supply_status;

                    firstNameTextBox.Text = row.first_name;
                    lastNameTextBox.Text = row.last_name;
                    phoneNTextBox.Text = row.phone_number;
                    roomTypeTextBox.Text = row.room_type;
                    floorNTextBox.Text = row.room_floor;
                    roomNTextBox.Text = row.room_number;

                    totalBill = row.total_bill;
                    foodBill = row.food_bill;
                    totalBill -= foodBill;
                    primaryID = row.Id;
                }
            }
            catch (Exception ex) { MessageBox.Show("COMBOBOX Selection: " + ex.Message); }
        }

        private void foodSelectionButton_Click(object sender, EventArgs e)
        {
            FoodMenu food_menu = new FoodMenu();
            food_menu.needPanel.Visible = false;
            food_menu.ShowDialog();

            breakfast = food_menu.BreakfastQ;
            lunch = food_menu.LunchQ;
            dinner = food_menu.DinnerQ;

            int bfast = breakfast > 0 ? 7 * breakfast : 0;
            int lnch = lunch > 0 ? 15 * lunch : 0;
            int di_ner = dinner > 0 ? 15 * dinner : 0;
            foodBill += (bfast + lnch + di_ner);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (primaryID <= 1000)
            {
                MessageBox.Show("Selected ID doesn't exist.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = CreateDbContext())
                {
                    var record = db.Reservations.Find(primaryID);
                    if (record != null)
                    {
                        record.total_bill = totalBill + foodBill;
                        record.break_fast = breakfast;
                        record.lunch = lunch;
                        record.dinner = dinner;
                        record.supply_status = supply_status;
                        record.cleaning = cleaning == "1";
                        record.towel = towel == "1";
                        record.s_surprise = surprise == "1";
                        record.food_bill = foodBill;

                        db.SaveChanges();
                    }
                }
                MessageBox.Show("Entry successfully updated into database. For the UNIQUE USER ID of: \n\n " + primaryID,
                    "Report", MessageBoxButtons.OK, MessageBoxIcon.Question);

                listBoxFromDataBase();
                LoadForDataGridView();
                resetEntries(this);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void supplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            cleaningCheckBox.Checked = false;
            cleaningCheckBox.Text = "Cleaned";
            towelCheckBox.Checked = false;
            towelCheckBox.Text = "Toweled";
            surpriseCheckBox.Checked = false;
            surpriseCheckBox.Text = "Surprised";
            supply_status = true;
        }

        private void kitchen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private System.Data.DataTable ToDataTable<T>(System.Collections.Generic.IEnumerable<T> items)
        {
            var table = new System.Data.DataTable();
            var props = typeof(T).GetProperties();
            foreach (var p in props)
                table.Columns.Add(p.Name, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);
            foreach (var item in items)
            {
                var row = table.NewRow();
                foreach (var p in props) row[p.Name] = p.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}