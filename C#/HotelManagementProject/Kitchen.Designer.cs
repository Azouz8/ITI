namespace Hotel_Manager
{
    partial class Kitchen
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.TodoTabPage = new System.Windows.Forms.TabPage();
            this.onTheLineLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.roomNLabel = new System.Windows.Forms.Label();
            this.floorNLabel = new System.Windows.Forms.Label();
            this.roomTypeLabel = new System.Windows.Forms.Label();
            this.Todo = new System.Windows.Forms.GroupBox();
            this.dinnerQTLabel = new System.Windows.Forms.Label();
            this.lunchQTLabel = new System.Windows.Forms.Label();
            this.breakfastQTLabel = new System.Windows.Forms.Label();
            this.breakfastTextBox = new System.Windows.Forms.TextBox();
            this.foodSelectionButton = new System.Windows.Forms.Button();
            this.supplyCheckBox = new System.Windows.Forms.CheckBox();
            this.lunchTextBox = new System.Windows.Forms.TextBox();
            this.towelCheckBox = new System.Windows.Forms.CheckBox();
            this.dinnerTextBox = new System.Windows.Forms.TextBox();
            this.cleaningCheckBox = new System.Windows.Forms.CheckBox();
            this.surpriseCheckBox = new System.Windows.Forms.CheckBox();
            this.floorNTextBox = new System.Windows.Forms.TextBox();
            this.roomNTextBox = new System.Windows.Forms.TextBox();
            this.roomTypeTextBox = new System.Windows.Forms.TextBox();
            this.phoneNTextBox = new System.Windows.Forms.TextBox();
            this.queueListBox = new System.Windows.Forms.ListBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.phoneNLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.overviewTabPage = new System.Windows.Forms.TabPage();
            this.overviewDataGridView = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.TodoTabPage.SuspendLayout();
            this.Todo.SuspendLayout();
            this.overviewTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.overviewDataGridView)).BeginInit();
            this.SuspendLayout();

            // tabControl
            this.tabControl.Controls.Add(this.TodoTabPage);
            this.tabControl.Controls.Add(this.overviewTabPage);
            this.tabControl.Location = new System.Drawing.Point(11, 63);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 1;
            this.tabControl.Size = new System.Drawing.Size(983, 480);
            this.tabControl.TabIndex = 0;

            // TodoTabPage
            this.TodoTabPage.Controls.Add(this.onTheLineLabel);
            this.TodoTabPage.Controls.Add(this.updateButton);
            this.TodoTabPage.Controls.Add(this.roomNLabel);
            this.TodoTabPage.Controls.Add(this.floorNLabel);
            this.TodoTabPage.Controls.Add(this.roomTypeLabel);
            this.TodoTabPage.Controls.Add(this.Todo);
            this.TodoTabPage.Controls.Add(this.floorNTextBox);
            this.TodoTabPage.Controls.Add(this.roomNTextBox);
            this.TodoTabPage.Controls.Add(this.roomTypeTextBox);
            this.TodoTabPage.Controls.Add(this.phoneNTextBox);
            this.TodoTabPage.Controls.Add(this.queueListBox);
            this.TodoTabPage.Controls.Add(this.nameLabel);
            this.TodoTabPage.Controls.Add(this.phoneNLabel);
            this.TodoTabPage.Controls.Add(this.firstNameTextBox);
            this.TodoTabPage.Controls.Add(this.lastNameTextBox);
            this.TodoTabPage.Location = new System.Drawing.Point(4, 25);
            this.TodoTabPage.Name = "TodoTabPage";
            this.TodoTabPage.Size = new System.Drawing.Size(975, 451);
            this.TodoTabPage.TabIndex = 0;
            this.TodoTabPage.Text = "TODO*";

            // onTheLineLabel
            this.onTheLineLabel.AutoSize = true;
            this.onTheLineLabel.BackColor = System.Drawing.Color.Transparent;
            this.onTheLineLabel.Location = new System.Drawing.Point(707, 30);
            this.onTheLineLabel.Name = "onTheLineLabel";
            this.onTheLineLabel.TabIndex = 61;
            this.onTheLineLabel.Text = "On the line";

            // updateButton
            this.updateButton.Location = new System.Drawing.Point(707, 383);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(224, 31);
            this.updateButton.TabIndex = 60;
            this.updateButton.Text = "Update changes";
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);

            // roomNLabel
            this.roomNLabel.AutoSize = true;
            this.roomNLabel.BackColor = System.Drawing.Color.Transparent;
            this.roomNLabel.Location = new System.Drawing.Point(29, 255);
            this.roomNLabel.Name = "roomNLabel";
            this.roomNLabel.TabIndex = 58;
            this.roomNLabel.Text = "Room #";

            // floorNLabel
            this.floorNLabel.AutoSize = true;
            this.floorNLabel.BackColor = System.Drawing.Color.Transparent;
            this.floorNLabel.Location = new System.Drawing.Point(191, 193);
            this.floorNLabel.Name = "floorNLabel";
            this.floorNLabel.TabIndex = 57;
            this.floorNLabel.Text = "Floor #";

            // roomTypeLabel
            this.roomTypeLabel.AutoSize = true;
            this.roomTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.roomTypeLabel.Location = new System.Drawing.Point(29, 193);
            this.roomTypeLabel.Name = "roomTypeLabel";
            this.roomTypeLabel.TabIndex = 56;
            this.roomTypeLabel.Text = "Room type";

            // Todo (GroupBox)
            this.Todo.BackColor = System.Drawing.Color.Transparent;
            this.Todo.Controls.Add(this.dinnerQTLabel);
            this.Todo.Controls.Add(this.lunchQTLabel);
            this.Todo.Controls.Add(this.breakfastQTLabel);
            this.Todo.Controls.Add(this.breakfastTextBox);
            this.Todo.Controls.Add(this.foodSelectionButton);
            this.Todo.Controls.Add(this.supplyCheckBox);
            this.Todo.Controls.Add(this.lunchTextBox);
            this.Todo.Controls.Add(this.towelCheckBox);
            this.Todo.Controls.Add(this.dinnerTextBox);
            this.Todo.Controls.Add(this.cleaningCheckBox);
            this.Todo.Controls.Add(this.surpriseCheckBox);
            this.Todo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Todo.Location = new System.Drawing.Point(352, 45);
            this.Todo.Name = "Todo";
            this.Todo.Size = new System.Drawing.Size(349, 323);
            this.Todo.TabIndex = 55;
            this.Todo.TabStop = false;
            this.Todo.Text = "Todo";

            // dinnerQTLabel
            this.dinnerQTLabel.AutoSize = true;
            this.dinnerQTLabel.BackColor = System.Drawing.Color.Transparent;
            this.dinnerQTLabel.Location = new System.Drawing.Point(17, 87);
            this.dinnerQTLabel.Name = "dinnerQTLabel";
            this.dinnerQTLabel.TabIndex = 63;
            this.dinnerQTLabel.Text = "Dinner [QTY]";

            // lunchQTLabel
            this.lunchQTLabel.AutoSize = true;
            this.lunchQTLabel.BackColor = System.Drawing.Color.Transparent;
            this.lunchQTLabel.Location = new System.Drawing.Point(179, 24);
            this.lunchQTLabel.Name = "lunchQTLabel";
            this.lunchQTLabel.TabIndex = 62;
            this.lunchQTLabel.Text = "Lunch [QTY]";

            // breakfastQTLabel
            this.breakfastQTLabel.AutoSize = true;
            this.breakfastQTLabel.BackColor = System.Drawing.Color.Transparent;
            this.breakfastQTLabel.Location = new System.Drawing.Point(17, 24);
            this.breakfastQTLabel.Name = "breakfastQTLabel";
            this.breakfastQTLabel.TabIndex = 61;
            this.breakfastQTLabel.Text = "Breakfast [QTY]";

            // breakfastTextBox
            this.breakfastTextBox.BackColor = System.Drawing.Color.White;
            this.breakfastTextBox.Enabled = false;
            this.breakfastTextBox.Location = new System.Drawing.Point(17, 46);
            this.breakfastTextBox.Name = "breakfastTextBox";
            this.breakfastTextBox.PlaceholderText = "Breakfast";
            this.breakfastTextBox.Size = new System.Drawing.Size(155, 23);
            this.breakfastTextBox.TabIndex = 47;

            // foodSelectionButton
            this.foodSelectionButton.Location = new System.Drawing.Point(17, 276);
            this.foodSelectionButton.Name = "foodSelectionButton";
            this.foodSelectionButton.Size = new System.Drawing.Size(317, 31);
            this.foodSelectionButton.TabIndex = 59;
            this.foodSelectionButton.Text = "Change food selection?";
            this.foodSelectionButton.Click += new System.EventHandler(this.foodSelectionButton_Click);

            // supplyCheckBox
            this.supplyCheckBox.AutoSize = true;
            this.supplyCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.supplyCheckBox.Location = new System.Drawing.Point(126, 238);
            this.supplyCheckBox.Name = "supplyCheckBox";
            this.supplyCheckBox.TabIndex = 42;
            this.supplyCheckBox.Text = "Food/Supply status ?";
            this.supplyCheckBox.CheckedChanged += new System.EventHandler(this.supplyCheckBox_CheckedChanged);

            // lunchTextBox
            this.lunchTextBox.BackColor = System.Drawing.Color.White;
            this.lunchTextBox.Enabled = false;
            this.lunchTextBox.Location = new System.Drawing.Point(179, 46);
            this.lunchTextBox.Name = "lunchTextBox";
            this.lunchTextBox.PlaceholderText = "Lunch";
            this.lunchTextBox.Size = new System.Drawing.Size(155, 23);
            this.lunchTextBox.TabIndex = 48;

            // towelCheckBox
            this.towelCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.towelCheckBox.Enabled = false;
            this.towelCheckBox.Location = new System.Drawing.Point(135, 170);
            this.towelCheckBox.Name = "towelCheckBox";
            this.towelCheckBox.Size = new System.Drawing.Size(77, 24);
            this.towelCheckBox.TabIndex = 52;
            this.towelCheckBox.Text = "Towels";

            // dinnerTextBox
            this.dinnerTextBox.BackColor = System.Drawing.Color.White;
            this.dinnerTextBox.Enabled = false;
            this.dinnerTextBox.Location = new System.Drawing.Point(17, 109);
            this.dinnerTextBox.Name = "dinnerTextBox";
            this.dinnerTextBox.PlaceholderText = "Dinner";
            this.dinnerTextBox.Size = new System.Drawing.Size(317, 23);
            this.dinnerTextBox.TabIndex = 49;

            // cleaningCheckBox
            this.cleaningCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.cleaningCheckBox.Enabled = false;
            this.cleaningCheckBox.Location = new System.Drawing.Point(22, 170);
            this.cleaningCheckBox.Name = "cleaningCheckBox";
            this.cleaningCheckBox.Size = new System.Drawing.Size(77, 24);
            this.cleaningCheckBox.TabIndex = 51;
            this.cleaningCheckBox.Text = "Cleaning";

            // surpriseCheckBox
            this.surpriseCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.surpriseCheckBox.Enabled = false;
            this.surpriseCheckBox.Location = new System.Drawing.Point(218, 171);
            this.surpriseCheckBox.Name = "surpriseCheckBox";
            this.surpriseCheckBox.Size = new System.Drawing.Size(121, 24);
            this.surpriseCheckBox.TabIndex = 50;
            this.surpriseCheckBox.Text = "Sweetest Surprise";

            // floorNTextBox
            this.floorNTextBox.BackColor = System.Drawing.Color.White;
            this.floorNTextBox.Enabled = false;
            this.floorNTextBox.Location = new System.Drawing.Point(190, 215);
            this.floorNTextBox.Name = "floorNTextBox";
            this.floorNTextBox.PlaceholderText = "Floor #";
            this.floorNTextBox.Size = new System.Drawing.Size(155, 23);
            this.floorNTextBox.TabIndex = 46;

            // roomNTextBox
            this.roomNTextBox.BackColor = System.Drawing.Color.White;
            this.roomNTextBox.Enabled = false;
            this.roomNTextBox.Location = new System.Drawing.Point(31, 277);
            this.roomNTextBox.Name = "roomNTextBox";
            this.roomNTextBox.PlaceholderText = "Room #";
            this.roomNTextBox.Size = new System.Drawing.Size(316, 23);
            this.roomNTextBox.TabIndex = 45;

            // roomTypeTextBox
            this.roomTypeTextBox.BackColor = System.Drawing.Color.White;
            this.roomTypeTextBox.Enabled = false;
            this.roomTypeTextBox.Location = new System.Drawing.Point(29, 215);
            this.roomTypeTextBox.Name = "roomTypeTextBox";
            this.roomTypeTextBox.PlaceholderText = "Room type";
            this.roomTypeTextBox.Size = new System.Drawing.Size(155, 23);
            this.roomTypeTextBox.TabIndex = 44;

            // phoneNTextBox
            this.phoneNTextBox.BackColor = System.Drawing.Color.White;
            this.phoneNTextBox.Enabled = false;
            this.phoneNTextBox.Location = new System.Drawing.Point(31, 154);
            this.phoneNTextBox.Name = "phoneNTextBox";
            this.phoneNTextBox.PlaceholderText = "(999)-999-9999";
            this.phoneNTextBox.Size = new System.Drawing.Size(316, 23);
            this.phoneNTextBox.TabIndex = 43;

            // queueListBox
            this.queueListBox.FormattingEnabled = true;
            this.queueListBox.Location = new System.Drawing.Point(707, 52);
            this.queueListBox.Name = "queueListBox";
            this.queueListBox.Size = new System.Drawing.Size(224, 316);
            this.queueListBox.TabIndex = 40;
            this.queueListBox.SelectedIndexChanged += new System.EventHandler(this.queueListBox_SelectedIndexChanged);

            // nameLabel
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(29, 69);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.TabIndex = 23;
            this.nameLabel.Text = "Name";

            // phoneNLabel
            this.phoneNLabel.AutoSize = true;
            this.phoneNLabel.BackColor = System.Drawing.Color.Transparent;
            this.phoneNLabel.Location = new System.Drawing.Point(30, 132);
            this.phoneNLabel.Name = "phoneNLabel";
            this.phoneNLabel.TabIndex = 30;
            this.phoneNLabel.Text = "Phone number";

            // firstNameTextBox
            this.firstNameTextBox.BackColor = System.Drawing.Color.White;
            this.firstNameTextBox.Enabled = false;
            this.firstNameTextBox.Location = new System.Drawing.Point(30, 91);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.PlaceholderText = "First";
            this.firstNameTextBox.Size = new System.Drawing.Size(155, 23);
            this.firstNameTextBox.TabIndex = 21;

            // lastNameTextBox
            this.lastNameTextBox.BackColor = System.Drawing.Color.White;
            this.lastNameTextBox.Enabled = false;
            this.lastNameTextBox.Location = new System.Drawing.Point(191, 91);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.PlaceholderText = "Last";
            this.lastNameTextBox.Size = new System.Drawing.Size(155, 23);
            this.lastNameTextBox.TabIndex = 22;

            // overviewTabPage
            this.overviewTabPage.Controls.Add(this.overviewDataGridView);
            this.overviewTabPage.Location = new System.Drawing.Point(4, 25);
            this.overviewTabPage.Name = "overviewTabPage";
            this.overviewTabPage.Size = new System.Drawing.Size(975, 451);
            this.overviewTabPage.TabIndex = 1;
            this.overviewTabPage.Text = "Overview";

            // overviewDataGridView
            this.overviewDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.overviewDataGridView.Location = new System.Drawing.Point(0, 20);
            this.overviewDataGridView.Name = "overviewDataGridView";
            this.overviewDataGridView.Size = new System.Drawing.Size(975, 342);
            this.overviewDataGridView.TabIndex = 2;

            // Kitchen Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Kitchen";
            this.Text = "Room Service";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.kitchen_FormClosing);
            this.Load += new System.EventHandler(this.kitchen_Load);

            this.tabControl.ResumeLayout(false);
            this.TodoTabPage.ResumeLayout(false);
            this.TodoTabPage.PerformLayout();
            this.Todo.ResumeLayout(false);
            this.Todo.PerformLayout();
            this.overviewTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.overviewDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage TodoTabPage;
        private System.Windows.Forms.TabPage overviewTabPage;
        private System.Windows.Forms.DataGridView overviewDataGridView;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label phoneNLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.ListBox queueListBox;
        private System.Windows.Forms.TextBox phoneNTextBox;
        private System.Windows.Forms.CheckBox supplyCheckBox;
        private System.Windows.Forms.TextBox floorNTextBox;
        private System.Windows.Forms.TextBox roomNTextBox;
        private System.Windows.Forms.TextBox roomTypeTextBox;
        private System.Windows.Forms.CheckBox towelCheckBox;
        private System.Windows.Forms.CheckBox cleaningCheckBox;
        private System.Windows.Forms.CheckBox surpriseCheckBox;
        private System.Windows.Forms.TextBox dinnerTextBox;
        private System.Windows.Forms.TextBox lunchTextBox;
        private System.Windows.Forms.TextBox breakfastTextBox;
        private System.Windows.Forms.GroupBox Todo;
        private System.Windows.Forms.Label roomNLabel;
        private System.Windows.Forms.Label floorNLabel;
        private System.Windows.Forms.Label roomTypeLabel;
        private System.Windows.Forms.Button foodSelectionButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label dinnerQTLabel;
        private System.Windows.Forms.Label lunchQTLabel;
        private System.Windows.Forms.Label breakfastQTLabel;
        private System.Windows.Forms.Label onTheLineLabel;
    }
}