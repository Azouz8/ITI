namespace Hotel_Manager
{
    partial class Frontend
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frontend));
            this.resPanel = new System.Windows.Forms.TabControl();
            this.reservationPage = new System.Windows.Forms.TabPage();
            this.rightMPanel = new System.Windows.Forms.Panel();
            this.resEditButton = new System.Windows.Forms.ComboBox();
            this.newButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.middlePanel = new System.Windows.Forms.Panel();
            this.smsCheckBox = new System.Windows.Forms.CheckBox();
            this.foodSupplyCheckBox = new System.Windows.Forms.CheckBox();
            this.checkinCheckBox = new System.Windows.Forms.CheckBox();
            this.foodMenuButton = new System.Windows.Forms.Button();
            this.qtGuestComboBox = new System.Windows.Forms.ComboBox();
            this.finalizeButton = new System.Windows.Forms.Button();
            this.departureLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.depDatePicker = new System.Windows.Forms.DateTimePicker();
            this.roomNComboBox = new System.Windows.Forms.ComboBox();
            this.floorComboBox = new System.Windows.Forms.ComboBox();
            this.entryDatePicker = new System.Windows.Forms.DateTimePicker();
            this.entryLabel = new System.Windows.Forms.Label();
            this.roomTypeComboBox = new System.Windows.Forms.ComboBox();
            this.choiceLabel = new System.Windows.Forms.Label();
            this.leftMPanel = new System.Windows.Forms.Panel();
            this.emailLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.birthdayLabel = new System.Windows.Forms.Label();
            this.dayComboBox = new System.Windows.Forms.ComboBox();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.genderLabel = new System.Windows.Forms.Label();
            this.zipComboBox = new System.Windows.Forms.TextBox();
            this.phoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.stateComboBox = new System.Windows.Forms.ComboBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.aptTextBox = new System.Windows.Forms.TextBox();
            this.addLabel = new System.Windows.Forms.TextBox();
            this.searchPage = new System.Windows.Forms.TabPage();
            this.SearchError = new System.Windows.Forms.Label();
            this.searchDataGridView = new System.Windows.Forms.DataGridView();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.advViewPage = new System.Windows.Forms.TabPage();
            this.resTotalDataGridView = new System.Windows.Forms.DataGridView();
            this.roomPage = new System.Windows.Forms.TabPage();
            this.reservedColumnsLabel = new System.Windows.Forms.Label();
            this.occupiedColumnsLabel = new System.Windows.Forms.Label();
            this.reservedLabel = new System.Windows.Forms.Label();
            this.roomReservedListBox = new System.Windows.Forms.ListBox();
            this.roomOccupiedListBox = new System.Windows.Forms.ListBox();
            this.occupiedLabel = new System.Windows.Forms.Label();
            this.resPanel.SuspendLayout();
            this.reservationPage.SuspendLayout();
            this.rightMPanel.SuspendLayout();
            this.middlePanel.SuspendLayout();
            this.leftMPanel.SuspendLayout();
            this.searchPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchDataGridView)).BeginInit();
            this.advViewPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resTotalDataGridView)).BeginInit();
            this.roomPage.SuspendLayout();
            this.SuspendLayout();

            // resPanel (TabControl)
            this.resPanel.Controls.Add(this.reservationPage);
            this.resPanel.Controls.Add(this.searchPage);
            this.resPanel.Controls.Add(this.advViewPage);
            this.resPanel.Controls.Add(this.roomPage);
            this.resPanel.Location = new System.Drawing.Point(11, 73);
            this.resPanel.Margin = new System.Windows.Forms.Padding(4);
            this.resPanel.Name = "resPanel";
            this.resPanel.SelectedIndex = 0;
            this.resPanel.Size = new System.Drawing.Size(1312, 593);
            this.resPanel.TabIndex = 0;

            // reservationPage
            this.reservationPage.Controls.Add(this.rightMPanel);
            this.reservationPage.Controls.Add(this.middlePanel);
            this.reservationPage.Controls.Add(this.leftMPanel);
            this.reservationPage.Location = new System.Drawing.Point(4, 25);
            this.reservationPage.Margin = new System.Windows.Forms.Padding(4);
            this.reservationPage.Name = "reservationPage";
            this.reservationPage.Size = new System.Drawing.Size(1304, 564);
            this.reservationPage.TabIndex = 0;
            this.reservationPage.Text = "Reservation";

            // rightMPanel
            this.rightMPanel.BackColor = System.Drawing.Color.FromArgb(225, 225, 225);
            this.rightMPanel.Controls.Add(this.resEditButton);
            this.rightMPanel.Controls.Add(this.newButton);
            this.rightMPanel.Controls.Add(this.deleteButton);
            this.rightMPanel.Controls.Add(this.editButton);
            this.rightMPanel.Controls.Add(this.updateButton);
            this.rightMPanel.Location = new System.Drawing.Point(944, 17);
            this.rightMPanel.Margin = new System.Windows.Forms.Padding(4);
            this.rightMPanel.Name = "rightMPanel";
            this.rightMPanel.Size = new System.Drawing.Size(353, 518);
            this.rightMPanel.TabIndex = 34;

            // resEditButton
            this.resEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resEditButton.ForeColor = System.Drawing.Color.Green;
            this.resEditButton.FormattingEnabled = true;
            this.resEditButton.Items.AddRange(new object[] { "[ID]    [NAME]    [PHONE NUMBER]" });
            this.resEditButton.Location = new System.Drawing.Point(13, 37);
            this.resEditButton.Margin = new System.Windows.Forms.Padding(4);
            this.resEditButton.Name = "resEditButton";
            this.resEditButton.Size = new System.Drawing.Size(335, 24);
            this.resEditButton.TabIndex = 20;
            this.resEditButton.Visible = false;
            this.resEditButton.SelectedIndexChanged += new System.EventHandler(this.resEditButton_SelectedIndexChanged);

            // newButton
            this.newButton.Location = new System.Drawing.Point(13, 462);
            this.newButton.Margin = new System.Windows.Forms.Padding(4);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(327, 39);
            this.newButton.TabIndex = 22;
            this.newButton.Text = "New reservation";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);

            // deleteButton
            this.deleteButton.BackColor = System.Drawing.Color.IndianRed;
            this.deleteButton.ForeColor = System.Drawing.Color.White;
            this.deleteButton.Location = new System.Drawing.Point(13, 354);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(327, 42);
            this.deleteButton.TabIndex = 23;
            this.deleteButton.Text = "Delete";
            this.deleteButton.Visible = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);

            // editButton
            this.editButton.Location = new System.Drawing.Point(13, 412);
            this.editButton.Margin = new System.Windows.Forms.Padding(4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(327, 39);
            this.editButton.TabIndex = 18;
            this.editButton.Text = "Edit existing Reservation";
            this.editButton.Click += new System.EventHandler(this.editButton_Click);

            // updateButton
            this.updateButton.Enabled = false;
            this.updateButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.updateButton.ForeColor = System.Drawing.Color.White;
            this.updateButton.Location = new System.Drawing.Point(13, 302);
            this.updateButton.Margin = new System.Windows.Forms.Padding(4);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(327, 42);
            this.updateButton.TabIndex = 19;
            this.updateButton.Text = "Update";
            this.updateButton.Visible = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);

            // middlePanel
            this.middlePanel.BackColor = System.Drawing.Color.FromArgb(225, 225, 225);
            this.middlePanel.Controls.Add(this.smsCheckBox);
            this.middlePanel.Controls.Add(this.foodSupplyCheckBox);
            this.middlePanel.Controls.Add(this.checkinCheckBox);
            this.middlePanel.Controls.Add(this.foodMenuButton);
            this.middlePanel.Controls.Add(this.qtGuestComboBox);
            this.middlePanel.Controls.Add(this.finalizeButton);
            this.middlePanel.Controls.Add(this.departureLabel);
            this.middlePanel.Controls.Add(this.submitButton);
            this.middlePanel.Controls.Add(this.depDatePicker);
            this.middlePanel.Controls.Add(this.roomNComboBox);
            this.middlePanel.Controls.Add(this.floorComboBox);
            this.middlePanel.Controls.Add(this.entryDatePicker);
            this.middlePanel.Controls.Add(this.entryLabel);
            this.middlePanel.Controls.Add(this.roomTypeComboBox);
            this.middlePanel.Controls.Add(this.choiceLabel);
            this.middlePanel.Location = new System.Drawing.Point(473, 17);
            this.middlePanel.Margin = new System.Windows.Forms.Padding(4);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Size = new System.Drawing.Size(460, 518);
            this.middlePanel.TabIndex = 16;

            // smsCheckBox
            this.smsCheckBox.AutoSize = true;
            this.smsCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.smsCheckBox.Location = new System.Drawing.Point(140, 358);
            this.smsCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.smsCheckBox.Name = "smsCheckBox";
            this.smsCheckBox.TabIndex = 35;
            this.smsCheckBox.Text = "Send sms?";

            // foodSupplyCheckBox
            this.foodSupplyCheckBox.AutoSize = true;
            this.foodSupplyCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.foodSupplyCheckBox.Location = new System.Drawing.Point(259, 357);
            this.foodSupplyCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.foodSupplyCheckBox.Name = "foodSupplyCheckBox";
            this.foodSupplyCheckBox.TabIndex = 34;
            this.foodSupplyCheckBox.Text = "Food/Supply status ?";
            this.foodSupplyCheckBox.CheckedChanged += new System.EventHandler(this.foodSupplyCheckBox_CheckedChanged);

            // checkinCheckBox
            this.checkinCheckBox.AutoSize = true;
            this.checkinCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.checkinCheckBox.Location = new System.Drawing.Point(21, 358);
            this.checkinCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.checkinCheckBox.Name = "checkinCheckBox";
            this.checkinCheckBox.TabIndex = 33;
            this.checkinCheckBox.Text = "Check in ?";
            this.checkinCheckBox.CheckedChanged += new System.EventHandler(this.checkinCheckBox_CheckedChanged);

            // foodMenuButton
            this.foodMenuButton.Location = new System.Drawing.Point(21, 299);
            this.foodMenuButton.Margin = new System.Windows.Forms.Padding(4);
            this.foodMenuButton.Name = "foodMenuButton";
            this.foodMenuButton.Size = new System.Drawing.Size(419, 42);
            this.foodMenuButton.TabIndex = 23;
            this.foodMenuButton.Text = "Food and menu";
            this.foodMenuButton.Click += new System.EventHandler(this.foodMenuButton_Click);

            // qtGuestComboBox
            this.qtGuestComboBox.FormattingEnabled = true;
            this.qtGuestComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6" });
            this.qtGuestComboBox.Location = new System.Drawing.Point(21, 37);
            this.qtGuestComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.qtGuestComboBox.Name = "qtGuestComboBox";
            this.qtGuestComboBox.Size = new System.Drawing.Size(200, 24);
            this.qtGuestComboBox.TabIndex = 25;

            // finalizeButton
            this.finalizeButton.Location = new System.Drawing.Point(21, 415);
            this.finalizeButton.Margin = new System.Windows.Forms.Padding(4);
            this.finalizeButton.Name = "finalizeButton";
            this.finalizeButton.Size = new System.Drawing.Size(419, 38);
            this.finalizeButton.TabIndex = 22;
            this.finalizeButton.Text = "Finalize bill";
            this.finalizeButton.Click += new System.EventHandler(this.finalizeButton_Click);

            // departureLabel
            this.departureLabel.AutoSize = true;
            this.departureLabel.BackColor = System.Drawing.Color.Transparent;
            this.departureLabel.Location = new System.Drawing.Point(21, 208);
            this.departureLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.departureLabel.Name = "departureLabel";
            this.departureLabel.TabIndex = 32;
            this.departureLabel.Text = "Departure [date]";

            // submitButton
            this.submitButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.submitButton.ForeColor = System.Drawing.Color.White;
            this.submitButton.Location = new System.Drawing.Point(21, 458);
            this.submitButton.Margin = new System.Windows.Forms.Padding(4);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(419, 44);
            this.submitButton.TabIndex = 17;
            this.submitButton.Text = "Submit";
            this.submitButton.Visible = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);

            // depDatePicker
            this.depDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.depDatePicker.CustomFormat = "MM-dd-yyyy";
            this.depDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.depDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.depDatePicker.Location = new System.Drawing.Point(21, 235);
            this.depDatePicker.Margin = new System.Windows.Forms.Padding(4);
            this.depDatePicker.Name = "depDatePicker";
            this.depDatePicker.Size = new System.Drawing.Size(420, 26);
            this.depDatePicker.TabIndex = 31;

            // roomNComboBox
            this.roomNComboBox.FormattingEnabled = true;
            this.roomNComboBox.Items.AddRange(new object[] {
                "101","102","103","104","105","106","107","108","109","110",
                "201","202","203","204","205","206","207","208","209","210",
                "301","302","303","304","305","306","307","308","309","310",
                "401","402","403","404","405","406","407","408","409","410",
                "501","502","503","504","505","506","507","508","509","510"});
            this.roomNComboBox.Location = new System.Drawing.Point(231, 102);
            this.roomNComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.roomNComboBox.Name = "roomNComboBox";
            this.roomNComboBox.Size = new System.Drawing.Size(211, 24);
            this.roomNComboBox.TabIndex = 24;

            // floorComboBox
            this.floorComboBox.FormattingEnabled = true;
            this.floorComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            this.floorComboBox.Location = new System.Drawing.Point(21, 102);
            this.floorComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.floorComboBox.Name = "floorComboBox";
            this.floorComboBox.Size = new System.Drawing.Size(200, 24);
            this.floorComboBox.TabIndex = 23;

            // entryDatePicker
            this.entryDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.entryDatePicker.CustomFormat = "MM-dd-yyyy";
            this.entryDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.entryDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.entryDatePicker.Location = new System.Drawing.Point(21, 172);
            this.entryDatePicker.Margin = new System.Windows.Forms.Padding(4);
            this.entryDatePicker.Name = "entryDatePicker";
            this.entryDatePicker.Size = new System.Drawing.Size(417, 26);
            this.entryDatePicker.TabIndex = 26;

            // entryLabel
            this.entryLabel.AutoSize = true;
            this.entryLabel.BackColor = System.Drawing.Color.Transparent;
            this.entryLabel.Location = new System.Drawing.Point(21, 145);
            this.entryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.entryLabel.Name = "entryLabel";
            this.entryLabel.TabIndex = 30;
            this.entryLabel.Text = "Entry [date]";

            // roomTypeComboBox
            this.roomTypeComboBox.FormattingEnabled = true;
            this.roomTypeComboBox.Items.AddRange(new object[] { "Single", "Double", "Twin", "Duplex", "Suite" });
            this.roomTypeComboBox.Location = new System.Drawing.Point(231, 36);
            this.roomTypeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.roomTypeComboBox.Name = "roomTypeComboBox";
            this.roomTypeComboBox.Size = new System.Drawing.Size(211, 24);
            this.roomTypeComboBox.TabIndex = 22;
            this.roomTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.roomTypeComboBox_SelectedIndexChanged);

            // choiceLabel
            this.choiceLabel.AutoSize = true;
            this.choiceLabel.BackColor = System.Drawing.Color.Transparent;
            this.choiceLabel.Location = new System.Drawing.Point(21, 10);
            this.choiceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.choiceLabel.Name = "choiceLabel";
            this.choiceLabel.TabIndex = 21;
            this.choiceLabel.Text = "Your choices";

            // leftMPanel
            this.leftMPanel.BackColor = System.Drawing.Color.FromArgb(225, 225, 225);
            this.leftMPanel.Controls.Add(this.emailLabel);
            this.leftMPanel.Controls.Add(this.nameLabel);
            this.leftMPanel.Controls.Add(this.emailTextBox);
            this.leftMPanel.Controls.Add(this.yearTextBox);
            this.leftMPanel.Controls.Add(this.monthComboBox);
            this.leftMPanel.Controls.Add(this.genderComboBox);
            this.leftMPanel.Controls.Add(this.birthdayLabel);
            this.leftMPanel.Controls.Add(this.dayComboBox);
            this.leftMPanel.Controls.Add(this.phoneNumberLabel);
            this.leftMPanel.Controls.Add(this.firstNameTextBox);
            this.leftMPanel.Controls.Add(this.genderLabel);
            this.leftMPanel.Controls.Add(this.zipComboBox);
            this.leftMPanel.Controls.Add(this.phoneNumberTextBox);
            this.leftMPanel.Controls.Add(this.stateComboBox);
            this.leftMPanel.Controls.Add(this.lastNameTextBox);
            this.leftMPanel.Controls.Add(this.cityTextBox);
            this.leftMPanel.Controls.Add(this.addressLabel);
            this.leftMPanel.Controls.Add(this.aptTextBox);
            this.leftMPanel.Controls.Add(this.addLabel);
            this.leftMPanel.Location = new System.Drawing.Point(4, 18);
            this.leftMPanel.Margin = new System.Windows.Forms.Padding(4);
            this.leftMPanel.Name = "leftMPanel";
            this.leftMPanel.Size = new System.Drawing.Size(460, 518);
            this.leftMPanel.TabIndex = 4;

            // emailLabel
            this.emailLabel.AutoSize = true;
            this.emailLabel.BackColor = System.Drawing.Color.Transparent;
            this.emailLabel.Location = new System.Drawing.Point(20, 277);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.TabIndex = 15;
            this.emailLabel.Text = "Your e-mail address";

            // nameLabel
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(19, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name";

            // emailTextBox
            this.emailTextBox.BackColor = System.Drawing.Color.White;
            this.emailTextBox.Location = new System.Drawing.Point(20, 304);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.PlaceholderText = "first.last@example.com";
            this.emailTextBox.Size = new System.Drawing.Size(421, 23);
            this.emailTextBox.TabIndex = 14;

            // yearTextBox
            this.yearTextBox.BackColor = System.Drawing.Color.White;
            this.yearTextBox.Location = new System.Drawing.Point(307, 103);
            this.yearTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.PlaceholderText = "Year";
            this.yearTextBox.Size = new System.Drawing.Size(135, 23);
            this.yearTextBox.TabIndex = 9;

            // monthComboBox
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Items.AddRange(new object[] {
                "January ","February ","March ","April ","May ","June ",
                "July ","August ","September ","October ","November ","December"});
            this.monthComboBox.Location = new System.Drawing.Point(20, 103);
            this.monthComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(159, 24);
            this.monthComboBox.TabIndex = 6;

            // genderComboBox
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Items.AddRange(new object[] { "Female", "Male", "Other" });
            this.genderComboBox.Location = new System.Drawing.Point(20, 172);
            this.genderComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.genderComboBox.Name = "genderComboBox";
            this.genderComboBox.Size = new System.Drawing.Size(419, 24);
            this.genderComboBox.TabIndex = 11;

            // birthdayLabel
            this.birthdayLabel.AutoSize = true;
            this.birthdayLabel.BackColor = System.Drawing.Color.Transparent;
            this.birthdayLabel.Location = new System.Drawing.Point(16, 78);
            this.birthdayLabel.Name = "birthdayLabel";
            this.birthdayLabel.TabIndex = 5;
            this.birthdayLabel.Text = "Birthday";

            // dayComboBox
            this.dayComboBox.FormattingEnabled = true;
            this.dayComboBox.Items.AddRange(new object[] {
                "01","02","03","04","05","06","07","08","09","10",
                "11","12","13","14","15","16","17","18","19","20",
                "21","22","23","24","25","26","27","28","29","30","31"});
            this.dayComboBox.Location = new System.Drawing.Point(188, 103);
            this.dayComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.dayComboBox.Name = "dayComboBox";
            this.dayComboBox.Size = new System.Drawing.Size(109, 24);
            this.dayComboBox.TabIndex = 8;

            // phoneNumberLabel
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.phoneNumberLabel.Location = new System.Drawing.Point(19, 210);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.TabIndex = 12;
            this.phoneNumberLabel.Text = "Phone number";

            // firstNameTextBox
            this.firstNameTextBox.BackColor = System.Drawing.Color.White;
            this.firstNameTextBox.Location = new System.Drawing.Point(20, 33);
            this.firstNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.PlaceholderText = "First";
            this.firstNameTextBox.Size = new System.Drawing.Size(207, 23);
            this.firstNameTextBox.TabIndex = 2;

            // genderLabel
            this.genderLabel.AutoSize = true;
            this.genderLabel.BackColor = System.Drawing.Color.Transparent;
            this.genderLabel.Location = new System.Drawing.Point(17, 145);
            this.genderLabel.Name = "genderLabel";
            this.genderLabel.TabIndex = 10;
            this.genderLabel.Text = "Gender";

            // zipComboBox
            this.zipComboBox.BackColor = System.Drawing.Color.White;
            this.zipComboBox.Location = new System.Drawing.Point(229, 465);
            this.zipComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.zipComboBox.Name = "zipComboBox";
            this.zipComboBox.PlaceholderText = "Zip code";
            this.zipComboBox.Size = new System.Drawing.Size(212, 23);
            this.zipComboBox.TabIndex = 20;

            // phoneNumberTextBox
            this.phoneNumberTextBox.BackColor = System.Drawing.Color.White;
            this.phoneNumberTextBox.Location = new System.Drawing.Point(19, 238);
            this.phoneNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.phoneNumberTextBox.Name = "phoneNumberTextBox";
            this.phoneNumberTextBox.PlaceholderText = "(999) 999-9999";
            this.phoneNumberTextBox.Size = new System.Drawing.Size(421, 23);
            this.phoneNumberTextBox.TabIndex = 13;
            this.phoneNumberTextBox.Leave += new System.EventHandler(this.phoneNumberTextBox_Leave);

            // stateComboBox
            this.stateComboBox.FormattingEnabled = true;
            this.stateComboBox.Items.AddRange(new object[] {
                "Alabama ","Alaska ","Arizona ","Arkansas ","California ","Colorado ","Connecticut ",
                "Delaware ","Florida ","Georgia ","Hawaii ","Idaho ","Illinois Indiana ","Iowa ",
                "Kansas ","Kentucky ","Louisiana ","Maine ","Maryland ","Massachusetts ","Michigan ",
                "Minnesota ","Mississippi ","Missouri ","Montana Nebraska ","Nevada ","New Hampshire ",
                "New Jersey ","New Mexico ","New York ","North Carolina ","North Dakota ","Ohio ",
                "Oklahoma ","Oregon ","Pennsylvania Rhode Island ","South Carolina ","South Dakota ",
                "Tennessee ","Texas ","Utah ","Vermont ","Virginia ","Washington ","West Virginia ",
                "Wisconsin ","Wyoming"});
            this.stateComboBox.Location = new System.Drawing.Point(20, 465);
            this.stateComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.stateComboBox.Name = "stateComboBox";
            this.stateComboBox.Size = new System.Drawing.Size(199, 24);
            this.stateComboBox.TabIndex = 19;

            // lastNameTextBox
            this.lastNameTextBox.BackColor = System.Drawing.Color.White;
            this.lastNameTextBox.Location = new System.Drawing.Point(235, 33);
            this.lastNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.PlaceholderText = "Last";
            this.lastNameTextBox.Size = new System.Drawing.Size(207, 23);
            this.lastNameTextBox.TabIndex = 3;

            // cityTextBox
            this.cityTextBox.BackColor = System.Drawing.Color.White;
            this.cityTextBox.Location = new System.Drawing.Point(228, 414);
            this.cityTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.PlaceholderText = "City";
            this.cityTextBox.Size = new System.Drawing.Size(212, 23);
            this.cityTextBox.TabIndex = 18;

            // addressLabel
            this.addressLabel.AutoSize = true;
            this.addressLabel.BackColor = System.Drawing.Color.Transparent;
            this.addressLabel.Location = new System.Drawing.Point(19, 304);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.TabIndex = 16;
            this.addressLabel.Text = "Your address";

            // aptTextBox
            this.aptTextBox.BackColor = System.Drawing.Color.White;
            this.aptTextBox.Location = new System.Drawing.Point(19, 412);
            this.aptTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.aptTextBox.Name = "aptTextBox";
            this.aptTextBox.PlaceholderText = "Apt./Suite";
            this.aptTextBox.Size = new System.Drawing.Size(201, 23);
            this.aptTextBox.TabIndex = 17;

            // addLabel (street address textbox — kept original name for code compatibility)
            this.addLabel.BackColor = System.Drawing.Color.White;
            this.addLabel.Location = new System.Drawing.Point(17, 357);
            this.addLabel.Margin = new System.Windows.Forms.Padding(4);
            this.addLabel.Name = "addLabel";
            this.addLabel.PlaceholderText = "Street address";
            this.addLabel.Size = new System.Drawing.Size(421, 23);
            this.addLabel.TabIndex = 15;

            // searchPage
            this.searchPage.Controls.Add(this.SearchError);
            this.searchPage.Controls.Add(this.searchDataGridView);
            this.searchPage.Controls.Add(this.searchButton);
            this.searchPage.Controls.Add(this.searchTextBox);
            this.searchPage.Location = new System.Drawing.Point(4, 25);
            this.searchPage.Margin = new System.Windows.Forms.Padding(4);
            this.searchPage.Name = "searchPage";
            this.searchPage.Size = new System.Drawing.Size(1304, 564);
            this.searchPage.TabIndex = 4;
            this.searchPage.Text = "Universal Search";

            // SearchError
            this.SearchError.AutoSize = true;
            this.SearchError.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.SearchError.Location = new System.Drawing.Point(360, 46);
            this.SearchError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SearchError.Name = "SearchError";
            this.SearchError.Size = new System.Drawing.Size(332, 150);
            this.SearchError.TabIndex = 19;
            this.SearchError.Text = "I ran out of entries :( SORRY DUDE.\r\n\r\nYou know, we can make another deal.\r\n\r\nI sure will find something.\r\n";
            this.SearchError.Visible = false;

            // searchDataGridView
            this.searchDataGridView.AllowUserToAddRows = false;
            this.searchDataGridView.AllowUserToDeleteRows = false;
            this.searchDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchDataGridView.Location = new System.Drawing.Point(91, 50);
            this.searchDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.searchDataGridView.Name = "searchDataGridView";
            this.searchDataGridView.ReadOnly = true;
            this.searchDataGridView.Size = new System.Drawing.Size(973, 290);
            this.searchDataGridView.TabIndex = 18;
            this.searchDataGridView.Visible = false;

            // searchButton
            this.searchButton.BackColor = System.Drawing.Color.Transparent;
            this.searchButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchButton.BackgroundImage")));
            this.searchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.searchButton.Location = new System.Drawing.Point(1012, 242);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(61, 36);
            this.searchButton.TabIndex = 17;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);

            // searchTextBox
            this.searchTextBox.BackColor = System.Drawing.Color.White;
            this.searchTextBox.Location = new System.Drawing.Point(100, 242);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.PlaceholderText = "Search";
            this.searchTextBox.Size = new System.Drawing.Size(951, 23);
            this.searchTextBox.TabIndex = 15;

            // advViewPage (formerly metroTabPage2)
            this.advViewPage.AutoScroll = true;
            this.advViewPage.Controls.Add(this.resTotalDataGridView);
            this.advViewPage.Location = new System.Drawing.Point(4, 25);
            this.advViewPage.Margin = new System.Windows.Forms.Padding(4);
            this.advViewPage.Name = "advViewPage";
            this.advViewPage.Size = new System.Drawing.Size(1304, 564);
            this.advViewPage.TabIndex = 3;
            this.advViewPage.Text = "Reservation Adv. view";

            // resTotalDataGridView
            this.resTotalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resTotalDataGridView.Location = new System.Drawing.Point(0, 4);
            this.resTotalDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.resTotalDataGridView.Name = "resTotalDataGridView";
            this.resTotalDataGridView.Size = new System.Drawing.Size(1301, 534);
            this.resTotalDataGridView.TabIndex = 2;

            // roomPage
            this.roomPage.Controls.Add(this.reservedColumnsLabel);
            this.roomPage.Controls.Add(this.occupiedColumnsLabel);
            this.roomPage.Controls.Add(this.reservedLabel);
            this.roomPage.Controls.Add(this.roomReservedListBox);
            this.roomPage.Controls.Add(this.roomOccupiedListBox);
            this.roomPage.Controls.Add(this.occupiedLabel);
            this.roomPage.Location = new System.Drawing.Point(4, 25);
            this.roomPage.Margin = new System.Windows.Forms.Padding(4);
            this.roomPage.Name = "roomPage";
            this.roomPage.Size = new System.Drawing.Size(1304, 564);
            this.roomPage.TabIndex = 2;
            this.roomPage.Text = "Room availability";

            // reservedColumnsLabel (formerly metroLabel13)
            this.reservedColumnsLabel.AutoSize = true;
            this.reservedColumnsLabel.BackColor = System.Drawing.Color.Transparent;
            this.reservedColumnsLabel.Location = new System.Drawing.Point(612, 34);
            this.reservedColumnsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.reservedColumnsLabel.Name = "reservedColumnsLabel";
            this.reservedColumnsLabel.TabIndex = 10;
            this.reservedColumnsLabel.Text = "Room#| Type  |  ID#   |       Name      |      Phone #      |     Entry       |    Depart";

            // occupiedColumnsLabel (formerly metroLabel11)
            this.occupiedColumnsLabel.AutoSize = true;
            this.occupiedColumnsLabel.BackColor = System.Drawing.Color.Transparent;
            this.occupiedColumnsLabel.Location = new System.Drawing.Point(-4, 34);
            this.occupiedColumnsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.occupiedColumnsLabel.Name = "occupiedColumnsLabel";
            this.occupiedColumnsLabel.TabIndex = 9;
            this.occupiedColumnsLabel.Text = "Room#| Type  |  ID#   |       Name      |      Phone #";

            // reservedLabel
            this.reservedLabel.AutoSize = true;
            this.reservedLabel.BackColor = System.Drawing.Color.Transparent;
            this.reservedLabel.Location = new System.Drawing.Point(612, 5);
            this.reservedLabel.Name = "reservedLabel";
            this.reservedLabel.TabIndex = 8;
            this.reservedLabel.Text = "Reserved";

            // roomReservedListBox
            this.roomReservedListBox.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.roomReservedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.roomReservedListBox.FormattingEnabled = true;
            this.roomReservedListBox.HorizontalScrollbar = true;
            this.roomReservedListBox.IntegralHeight = false;
            this.roomReservedListBox.ItemHeight = 16;
            this.roomReservedListBox.Location = new System.Drawing.Point(613, 62);
            this.roomReservedListBox.Margin = new System.Windows.Forms.Padding(4);
            this.roomReservedListBox.Name = "roomReservedListBox";
            this.roomReservedListBox.Size = new System.Drawing.Size(688, 476);
            this.roomReservedListBox.TabIndex = 7;

            // roomOccupiedListBox
            this.roomOccupiedListBox.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.roomOccupiedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.roomOccupiedListBox.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            this.roomOccupiedListBox.FormattingEnabled = true;
            this.roomOccupiedListBox.HorizontalScrollbar = true;
            this.roomOccupiedListBox.IntegralHeight = false;
            this.roomOccupiedListBox.ItemHeight = 19;
            this.roomOccupiedListBox.Location = new System.Drawing.Point(0, 62);
            this.roomOccupiedListBox.Margin = new System.Windows.Forms.Padding(4);
            this.roomOccupiedListBox.Name = "roomOccupiedListBox";
            this.roomOccupiedListBox.Size = new System.Drawing.Size(605, 476);
            this.roomOccupiedListBox.TabIndex = 6;

            // occupiedLabel
            this.occupiedLabel.AutoSize = true;
            this.occupiedLabel.BackColor = System.Drawing.Color.Transparent;
            this.occupiedLabel.Location = new System.Drawing.Point(-4, 5);
            this.occupiedLabel.Name = "occupiedLabel";
            this.occupiedLabel.TabIndex = 5;
            this.occupiedLabel.Text = "Occupied";

            // Frontend Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1331, 671);
            this.Controls.Add(this.resPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Frontend";
            this.Text = "Frontend";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frontend_FormClosing);
            this.Load += new System.EventHandler(this.MainTab_Load);

            this.resPanel.ResumeLayout(false);
            this.reservationPage.ResumeLayout(false);
            this.rightMPanel.ResumeLayout(false);
            this.middlePanel.ResumeLayout(false);
            this.middlePanel.PerformLayout();
            this.leftMPanel.ResumeLayout(false);
            this.leftMPanel.PerformLayout();
            this.searchPage.ResumeLayout(false);
            this.searchPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchDataGridView)).EndInit();
            this.advViewPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resTotalDataGridView)).EndInit();
            this.roomPage.ResumeLayout(false);
            this.roomPage.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl resPanel;
        private System.Windows.Forms.TabPage reservationPage;
        private System.Windows.Forms.Panel leftMPanel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label birthdayLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.ComboBox dayComboBox;
        private System.Windows.Forms.TextBox phoneNumberTextBox;
        private System.Windows.Forms.Label genderLabel;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Panel middlePanel;
        private System.Windows.Forms.TextBox zipComboBox;
        private System.Windows.Forms.ComboBox stateComboBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox aptTextBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addLabel;
        private System.Windows.Forms.ComboBox roomTypeComboBox;
        private System.Windows.Forms.Label choiceLabel;
        private System.Windows.Forms.ComboBox roomNComboBox;
        private System.Windows.Forms.ComboBox floorComboBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button finalizeButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.DateTimePicker entryDatePicker;
        private System.Windows.Forms.Label departureLabel;
        private System.Windows.Forms.DateTimePicker depDatePicker;
        private System.Windows.Forms.Label entryLabel;
        private System.Windows.Forms.Button foodMenuButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.CheckBox checkinCheckBox;
        private System.Windows.Forms.ComboBox resEditButton;
        private System.Windows.Forms.Panel rightMPanel;
        private System.Windows.Forms.TabPage roomPage;
        private System.Windows.Forms.TabPage advViewPage;
        private System.Windows.Forms.DataGridView resTotalDataGridView;
        private System.Windows.Forms.CheckBox foodSupplyCheckBox;
        private System.Windows.Forms.ListBox roomOccupiedListBox;
        private System.Windows.Forms.Label occupiedLabel;
        private System.Windows.Forms.Label reservedLabel;
        private System.Windows.Forms.ListBox roomReservedListBox;
        private System.Windows.Forms.TabPage searchPage;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ComboBox qtGuestComboBox;
        private System.Windows.Forms.Label reservedColumnsLabel;
        private System.Windows.Forms.Label occupiedColumnsLabel;
        private System.Windows.Forms.DataGridView searchDataGridView;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label SearchError;
        private System.Windows.Forms.CheckBox smsCheckBox;
    }
}