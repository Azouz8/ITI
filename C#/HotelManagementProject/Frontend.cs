using Dapper;
using Hotel_Manager.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hotel_Manager
{
    public partial class Frontend : Form
    {
        string RecvPhoneNumber = "";

        private string ConnectionString => Hotel_Manager.Properties.Settings.Default.frontend_reservationConnectionString;

        private HotelContext CreateDbContext() =>
            new HotelContext();

        public Frontend()
        {
            InitializeComponent();
            CenterToScreen();
            entryDatePicker.MinDate = DateTime.Today;
            depDatePicker.MinDate = DateTime.Today.AddDays(1);

            this.roomOccupiedListBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.roomOccupiedListBox.DrawItem += new DrawItemEventHandler(this.roomOccupiedListBox_DrawItem);
            this.roomReservedListBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.roomReservedListBox.DrawItem += new DrawItemEventHandler(this.roomReservedListBox_DrawItem);
        }

        private void roomOccupiedListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            this.roomOccupiedListBox.IntegralHeight = false;
            this.roomOccupiedListBox.ItemHeight = 25;
            e.DrawBackground();
            Font listBoxFont = new Font("Segoe UI Symbol", 12.0f, FontStyle.Regular);
            e.Graphics.DrawString(roomOccupiedListBox.Items[e.Index].ToString(), listBoxFont, Brushes.Black, e.Bounds, StringFormat.GenericTypographic);
        }

        private void roomReservedListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            this.roomReservedListBox.IntegralHeight = false;
            this.roomReservedListBox.ItemHeight = 25;
            e.DrawBackground();
            Font listBoxFont = new Font("Segoe UI Symbol", 12.0f, FontStyle.Regular);
            e.Graphics.DrawString(roomReservedListBox.Items[e.Index].ToString(), listBoxFont, Brushes.Black, e.Bounds, StringFormat.GenericTypographic);
        }

        private string getval;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Getval { get { return getval; } set { getval = value; } }

        public string towelS, cleaningS, surpriseS;
        public int foodBill;
        public string birthday = "";
        public string food_menu = "";
        public int totalAmount = 0;
        public int checkin = 0;
        public int foodStatus = 0;
        public Int32 primartyID = 0;
        public Boolean taskFinder = false;
        public Boolean editClicked = false;
        public string FPayment, FCnumber, FcardExpOne, FcardExpTwo, FCardCVC;
        private double finalizedTotalAmount = 0.0;
        private string paymentType;
        private string paymentCardNumber;
        private string MM_YY_Of_Card;
        private string CVC_Of_Card;
        private string CardType;

        private int lunch = 0; private int breakfast = 0; private int dinner = 0;
        private string cleaning; private string towel; private string surprise;

        private void MainTab_Load(object sender, EventArgs e)
        {
            foodSupplyCheckBox.Enabled = false;
        }

        public void foodMenuButton_Click(object sender, EventArgs e)
        {
            FoodMenu food_menu = new FoodMenu();
            if (taskFinder)
            {
                if (breakfast > 0) { food_menu.breakfastCheckBox.Checked = true; food_menu.breakfastQTY.Text = Convert.ToString(breakfast); }
                if (lunch > 0) { food_menu.lunchCheckBox.Checked = true; food_menu.lunchQTY.Text = Convert.ToString(lunch); }
                if (dinner > 0) { food_menu.dinnerCheckBox.Checked = true; food_menu.dinnerQTY.Text = Convert.ToString(dinner); }
                if (cleaning == "1") food_menu.cleaningCheckBox.Checked = true;
                if (towel == "1") food_menu.towelsCheckBox.Checked = true;
                if (surprise == "1") food_menu.surpriseCheckBox.Checked = true;
            }
            food_menu.ShowDialog();

            breakfast = food_menu.BreakfastQ;
            lunch = food_menu.LunchQ;
            dinner = food_menu.DinnerQ;
            cleaning = food_menu.Cleaning.Replace(" ", string.Empty) == "Cleaning" ? "1" : "0";
            towel = food_menu.Towel.Replace(" ", string.Empty) == "Towels" ? "1" : "0";
            surprise = food_menu.Surprise.Replace(" ", string.Empty) == "Sweetestsurprise" ? "1" : "0";

            if (breakfast > 0 || lunch > 0 || dinner > 0)
                foodBill = (7 * breakfast) + (15 * lunch) + (15 * dinner);
        }

        private void roomTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (roomTypeComboBox.SelectedItem?.ToString())
            {
                case "Single": totalAmount = 149; floorComboBox.SelectedItem = "1"; break;
                case "Double": totalAmount = 299; floorComboBox.SelectedItem = "2"; break;
                case "Twin": totalAmount = 349; floorComboBox.SelectedItem = "3"; break;
                case "Duplex": totalAmount = 399; floorComboBox.SelectedItem = "4"; break;
                case "Suite": totalAmount = 499; floorComboBox.SelectedItem = "5"; break;
            }
            if (int.TryParse(qtGuestComboBox.SelectedItem?.ToString(), out int selectedTemp))
            {
                if (selectedTemp >= 3) totalAmount += (selectedTemp * 5);
            }
            else
            {
                MessageBox.Show("Enter # of guests first", "Error parsing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            editClicked = true;
            entryDatePicker.MinDate = new DateTime(2014, 4, 1);
            entryDatePicker.CustomFormat = "MM-dd-yyyy";
            entryDatePicker.Format = DateTimePickerFormat.Custom;
            depDatePicker.MinDate = new DateTime(2014, 4, 1);
            depDatePicker.CustomFormat = "MM-dd-yyyy";
            depDatePicker.Format = DateTimePickerFormat.Custom;

            submitButton.Visible = false;
            updateButton.Visible = true;
            deleteButton.Visible = true;
            resEditButton.Visible = true;

            ComboBoxItemsFromDataBase();
            LoadForDataGridView();
            reset_frontend();
        }

        private void finalizeButton_Click(object sender, EventArgs e)
        {
            if (breakfast == 0 && lunch == 0 && dinner == 0 && cleaning == "0" && towel == "0" && surprise == "0")
                foodSupplyCheckBox.Checked = true;

            updateButton.Enabled = true;

            FinalizePayment finalizebil = new FinalizePayment();
            finalizebil.totalAmountFromFrontend = totalAmount;
            finalizebil.foodBill = foodBill;
            if (taskFinder)
            {
                finalizebil.paymentComboBox.SelectedItem = FPayment.Replace(" ", string.Empty);
                finalizebil.phoneNComboBox.Text = FCnumber;
                finalizebil.monthComboBox.SelectedItem = FcardExpOne;
                finalizebil.yearComboBox.SelectedItem = FcardExpTwo;
                finalizebil.cvcComboBox.Text = FCardCVC;
            }
            finalizebil.ShowDialog();

            finalizedTotalAmount = finalizebil.FinalTotalFinalized;
            paymentType = finalizebil.PaymentType;
            paymentCardNumber = finalizebil.PaymentCardNumber;
            MM_YY_Of_Card = finalizebil.MM_YY_Of_Card1;
            CVC_Of_Card = finalizebil.CVC_Of_Card1;
            CardType = finalizebil.CardType1;

            if (!editClicked) submitButton.Visible = true;
        }

        // ── INSERT (Entity Framework) ────────────────────────────────────────────
        private void submitButton_Click(object sender, EventArgs e)
        {
            birthday = (monthComboBox.SelectedItem) + "-" + (dayComboBox.SelectedIndex + 1) + "-" + yearTextBox.Text;

            var reservation = new ReservationEntity
            {
                first_name = firstNameTextBox.Text,
                last_name = lastNameTextBox.Text,
                birth_day = birthday,
                gender = genderComboBox.SelectedItem?.ToString(),
                phone_number = phoneNumberTextBox.Text,
                email_address = emailTextBox.Text,
                number_guest = qtGuestComboBox.SelectedIndex + 1,
                street_address = addLabel.Text,
                apt_suite = aptTextBox.Text,
                city = cityTextBox.Text,
                state = stateComboBox.SelectedItem?.ToString(),
                zip_code = zipComboBox.Text,
                room_type = roomTypeComboBox.SelectedItem?.ToString(),
                room_floor = floorComboBox.SelectedItem?.ToString(),
                room_number = roomNComboBox.SelectedItem?.ToString(),
                total_bill = finalizedTotalAmount,
                payment_type = paymentType,
                card_type = CardType,
                card_number = paymentCardNumber,
                card_exp = MM_YY_Of_Card,
                card_cvc = CVC_Of_Card,
                arrival_time = entryDatePicker.Value,
                leaving_time = depDatePicker.Value,
                check_in = checkin == 1,
                break_fast = breakfast,
                lunch = lunch,
                dinner = dinner,
                supply_status = foodStatus == 1,
                cleaning = cleaning == "1",
                towel = towel == "1",
                s_surprise = surprise == "1",
                food_bill = foodBill
            };

            try
            {
                using (var db = CreateDbContext())
                {
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                }
                MessageBox.Show("Entry successfully inserted into database. \n\nProvide this unique ID to the customer.\n\nUSER UNIQUE ID: " + reservation.Id,
                    "Report", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            ComboBoxItemsFromDataBase();
            LoadForDataGridView();
            reset_frontend();
            GetOccupiedRoom();
            ReservedRoom();
            getChecked();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            submitButton.Visible = false;
            updateButton.Visible = false;
            deleteButton.Visible = false;
            resEditButton.Visible = false;
            reset_frontend();
        }

        public void ClearAllTextBoxes(Control controls)
        {
            foreach (Control control in controls.Controls)
            {
                if (control is TextBox) ((TextBox)control).Clear();
                if (control.HasChildren) ClearAllTextBoxes(control);
            }
        }

        public void ClearAllComboBox(Control controls)
        {
            foreach (Control control in controls.Controls)
            {
                if (control == roomTypeComboBox) continue;
                else if (control is ComboBox) ((ComboBox)control).SelectedIndex = -1;
                if (control.HasChildren) ClearAllComboBox(control);
            }
        }

        private void reset_frontend()
        {
            try
            {
                resEditButton.Items.Clear();
                checkinCheckBox.Checked = false;
                foodSupplyCheckBox.Checked = false;
                ClearAllComboBox(this);
                ClearAllTextBoxes(this);
                ComboBoxItemsFromDataBase();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
        }

        private void frontend_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // ── DELETE (Entity Framework) ────────────────────────────────────────────
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (primartyID > 1000)
            {
                try
                {
                    using (var db = CreateDbContext())
                    {
                        var record = db.Reservations.Find(primartyID);
                        if (record != null)
                        {
                            db.Reservations.Remove(record);
                            db.SaveChanges();
                        }
                    }
                    MessageBox.Show("Reservation For the UNIQUE USER ID of: \n\n " + primartyID + " is DELETED.",
                        "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (Exception ex) { MessageBox.Show("Selected ID doesn't exist. " + ex.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning); }
            }
            else
            {
                MessageBox.Show("Selected ID doesn't exist.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }

            ComboBoxItemsFromDataBase();
            LoadForDataGridView();
            reset_frontend();
            GetOccupiedRoom();
            ReservedRoom();
            getChecked();
        }

        // ── UPDATE (Entity Framework) ────────────────────────────────────────────
        private void updateButton_Click(object sender, EventArgs e)
        {
            // Guard: build birthday safely
            string newBirthday = (monthComboBox.SelectedItem != null && dayComboBox.SelectedItem != null)
                ? (monthComboBox.SelectedItem) + "-" + (dayComboBox.SelectedIndex + 1) + "-" + yearTextBox.Text
                : birthday; // fall back to the value loaded from DB

            try
            {
                using (var db = CreateDbContext())
                {
                    var record = db.Reservations.Find(primartyID);
                    if (record == null)
                    {
                        MessageBox.Show("Record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    record.first_name = firstNameTextBox.Text;
                    record.last_name = lastNameTextBox.Text;
                    record.birth_day = newBirthday;
                    record.gender = genderComboBox.SelectedItem?.ToString() ?? record.gender;
                    record.phone_number = phoneNumberTextBox.Text;
                    record.email_address = emailTextBox.Text;
                    record.number_guest = qtGuestComboBox.SelectedIndex >= 0
                                                ? qtGuestComboBox.SelectedIndex + 1
                                                : record.number_guest;
                    record.street_address = addLabel.Text;
                    record.apt_suite = aptTextBox.Text;
                    record.city = cityTextBox.Text;
                    record.state = stateComboBox.SelectedItem?.ToString() ?? record.state;
                    record.zip_code = zipComboBox.Text;
                    record.room_type = roomTypeComboBox.SelectedItem?.ToString() ?? record.room_type;
                    record.room_floor = floorComboBox.SelectedItem?.ToString() ?? record.room_floor;
                    record.room_number = roomNComboBox.SelectedItem?.ToString() ?? record.room_number;

                    // Only overwrite payment fields if Finalize was actually clicked
                    record.total_bill = finalizedTotalAmount > 0 ? finalizedTotalAmount : record.total_bill;
                    record.payment_type = paymentType ?? record.payment_type;
                    record.card_type = CardType ?? record.card_type;
                    record.card_number = paymentCardNumber ?? record.card_number;
                    record.card_exp = MM_YY_Of_Card ?? record.card_exp;
                    record.card_cvc = CVC_Of_Card ?? record.card_cvc;

                    record.arrival_time = entryDatePicker.Value;
                    record.leaving_time = depDatePicker.Value;
                    record.check_in = checkin == 1;
                    record.break_fast = breakfast;
                    record.lunch = lunch;
                    record.dinner = dinner;
                    record.supply_status = foodStatus == 1;
                    record.cleaning = cleaning == "1";
                    record.towel = towel == "1";
                    record.s_surprise = surprise == "1";
                    record.food_bill = foodBill;

                    db.SaveChanges();
                }
                MessageBox.Show("Entry successfully updated. UNIQUE USER ID: \n\n " + primartyID,
                    "Report", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            ComboBoxItemsFromDataBase();
            reset_frontend();
            LoadForDataGridView();
            GetOccupiedRoom();
            ReservedRoom();
            getChecked();
        }

        private void checkinCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkinCheckBox.Checked) { checkinCheckBox.Text = "Checked in"; checkin = 1; }
            else { checkin = 0; checkinCheckBox.Text = "Check in ?"; }
        }

        // ── SELECT by ID (Dapper) ────────────────────────────────────────────────
        private void resEditButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            getChecked();
            string getQuerystring = resEditButton.Text.Substring(0, 4).Replace(" ", string.Empty);

            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var row = conn.QueryFirstOrDefault<ReservationEntity>(
                        "SELECT * FROM reservation WHERE Id = @Id",
                        new { Id = int.Parse(getQuerystring) });

                    if (row == null) return;

                    taskFinder = true;
                    cleaning = row.cleaning ? "1" : "0";
                    towel = row.towel ? "1" : "0";
                    surprise = row.s_surprise ? "1" : "0";

                    roomNComboBox.Items.Add(row.room_number);
                    roomNComboBox.SelectedItem = row.room_number;

                    FPayment = row.payment_type;
                    FCnumber = row.card_number;
                    FCardCVC = row.card_cvc;
                    FcardExpOne = row.card_exp.Substring(0, row.card_exp.IndexOf('/'));
                    FcardExpTwo = row.card_exp.Substring(row.card_exp.Length - Math.Min(2, row.card_exp.Length));

                    entryDatePicker.Value = row.arrival_time;
                    depDatePicker.Value = row.leaving_time;

                    lunch = row.lunch;
                    breakfast = row.break_fast;
                    dinner = row.dinner;
                    foodBill = row.food_bill;

                    foodSupplyCheckBox.Checked = row.supply_status;
                    checkinCheckBox.Checked = row.check_in;
                    primartyID = row.Id;

                    firstNameTextBox.Text = row.first_name;
                    lastNameTextBox.Text = row.last_name;
                    phoneNumberTextBox.Text = row.phone_number;
                    genderComboBox.SelectedItem = row.gender;
                    emailTextBox.Text = row.email_address;
                    qtGuestComboBox.SelectedItem = row.number_guest.ToString();
                    addLabel.Text = row.street_address;
                    aptTextBox.Text = row.apt_suite;
                    cityTextBox.Text = row.city;
                    stateComboBox.SelectedItem = row.state;
                    zipComboBox.Text = row.zip_code;
                    roomTypeComboBox.SelectedItem = row.room_type.Replace(" ", string.Empty);
                    floorComboBox.SelectedItem = row.room_floor.Replace(" ", string.Empty);
                    roomNComboBox.SelectedItem = row.room_number.Replace(" ", string.Empty);

                    monthComboBox.SelectedItem = row.birth_day.Substring(0, row.birth_day.IndexOf('-'));
                    dayComboBox.SelectedItem = row.birth_day.Substring(row.birth_day.IndexOf('-') + 1, 2);
                    yearTextBox.Text = row.birth_day.Substring(row.birth_day.Length - Math.Min(4, row.birth_day.Length));
                }
            }
            catch (Exception ex) { MessageBox.Show("COMBOBOX Selection: " + ex.Message); }
        }

        // ── SELECT all for ComboBox (Dapper) ────────────────────────────────────
        private void ComboBoxItemsFromDataBase()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var rows = conn.Query<ReservationEntity>("SELECT Id, first_name, last_name, phone_number FROM reservation");
                    foreach (var row in rows)
                        resEditButton.Items.Add(row.Id + "  | " + row.first_name + "  " + row.last_name + " | " + row.phone_number);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // ── SELECT all for DataGridView (Dapper) ─────────────────────────────────
        private void LoadForDataGridView()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var rows = conn.Query<ReservationEntity>("SELECT * FROM reservation").ToList();
                    var bs = new BindingSource { DataSource = ToDataTable(rows) };
                    resTotalDataGridView.DataSource = bs;
                }
            }
            catch { MessageBox.Show("Error loading data", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.None); }
        }

        private void foodSupplyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (foodSupplyCheckBox.Checked) { foodSupplyCheckBox.Text = "Food/Supply: Complete"; foodStatus = 1; }
            else { foodStatus = 0; foodSupplyCheckBox.Text = "Food/Supply status?"; }
        }

        // ── SELECT occupied rooms (Dapper) ───────────────────────────────────────
        private void GetOccupiedRoom()
        {
            roomOccupiedListBox.Items.Clear();
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var rows = conn.Query<ReservationEntity>(
                        "SELECT Id, first_name, last_name, phone_number, room_number, room_type FROM reservation WHERE check_in = 1");
                    foreach (var row in rows)
                        roomOccupiedListBox.Items.Add("[" + row.room_number.Trim() + "] " + row.room_type.Trim() +
                            " " + row.Id + " [" + row.first_name.Trim() + " " + row.last_name.Trim() + "] " + row.phone_number.Trim());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // ── SELECT reserved rooms (Dapper) ───────────────────────────────────────
        private void ReservedRoom()
        {
            roomReservedListBox.Items.Clear();
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var rows = conn.Query<ReservationEntity>(
                        "SELECT Id, first_name, last_name, phone_number, room_number, room_type, arrival_time, leaving_time FROM reservation WHERE check_in = 0");
                    foreach (var row in rows)
                        roomReservedListBox.Items.Add("[" + row.room_number.Trim() + "] " + row.room_type.Trim() +
                            " " + row.Id + " " + row.first_name.Trim() + " " + row.last_name.Trim() +
                            " " + row.phone_number.Trim() +
                            " " + row.arrival_time.ToString("MM-dd-yyyy") +
                            " " + row.leaving_time.ToString("MM-dd-yyy"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // ── SELECT taken rooms for ComboBox filter (Dapper) ─────────────────────
        private void getChecked()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var taken = conn.Query<string>(
                        "SELECT room_number FROM reservation WHERE check_in = 1").ToList();
                    foreach (string room in taken)
                    {
                        int idx = roomNComboBox.Items.IndexOf(room.Trim());
                        if (idx >= 0) roomNComboBox.Items.RemoveAt(idx);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // ── SELECT search (Dapper) ────────────────────────────────────────────────
        private void searchButton_Click(object sender, EventArgs e)
        {
            string term = searchTextBox.Text;
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    string sql = @"SELECT * FROM reservation WHERE
                        CAST(Id AS NVARCHAR) LIKE @t OR last_name    LIKE @t OR
                        first_name    LIKE @t OR gender       LIKE @t OR
                        state         LIKE @t OR city         LIKE @t OR
                        room_number   LIKE @t OR room_type    LIKE @t OR
                        email_address LIKE @t OR phone_number LIKE @t";

                    var rows = conn.Query<ReservationEntity>(sql, new { t = "%" + term + "%" }).ToList();
                    if (rows.Count > 0)
                    {
                        var bs = new BindingSource { DataSource = ToDataTable(rows) };
                        searchDataGridView.DataSource = bs;
                        searchButton.Location = new Point(752, 7);
                        searchTextBox.Location = new Point(68, 7);
                        searchDataGridView.Visible = true;
                        SearchError.Visible = false;
                    }
                    else
                    {
                        searchDataGridView.Visible = false;
                        SearchError.Visible = true;
                        SearchError.Text = "SORRY DUDE :(\nI ran out of gas trying to search for " + term + "\nI sure will find it next time.";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void phoneNumberTextBox_Leave(object sender, EventArgs e)
        {
            RecvPhoneNumber = "+1" + phoneNumberTextBox.Text.Replace(" ", string.Empty);
            if (long.TryParse(phoneNumberTextBox.Text.Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", ""), out long getphn))
                phoneNumberTextBox.Text = string.Format("{0:(000)000-0000}", getphn);
        }

        // ── Helper: List<T> → DataTable ───────────────────────────────────────────
        private DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            var table = new DataTable();
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