namespace UI
{
    partial class frmGridView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grdView = new DataGridView();
            menuStrip1 = new MenuStrip();
            manageToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)grdView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grdView
            // 
            grdView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdView.Dock = DockStyle.Fill;
            grdView.Location = new Point(0, 24);
            grdView.Name = "grdView";
            grdView.Size = new Size(800, 426);
            grdView.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { manageToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // manageToolStripMenuItem
            // 
            manageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saToolStripMenuItem });
            manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            manageToolStripMenuItem.Size = new Size(62, 20);
            manageToolStripMenuItem.Text = "Manage";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(180, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saToolStripMenuItem
            // 
            saToolStripMenuItem.Name = "saToolStripMenuItem";
            saToolStripMenuItem.Size = new Size(180, 22);
            saToolStripMenuItem.Text = "Save";
            saToolStripMenuItem.Click += saToolStripMenuItem_Click;
            // 
            // frmGridView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grdView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmGridView";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)grdView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grdView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem manageToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saToolStripMenuItem;
    }
}
