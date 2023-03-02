namespace MiMFa.Controls.WinForm.Browser
{
     partial class ProfessionalBrowser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfessionalBrowser));
            this.ControlsBar = new System.Windows.Forms.TableLayoutPanel();
            this.MainMenu = new System.Windows.Forms.ToolStrip();
            this.BackButton = new System.Windows.Forms.ToolStripButton();
            this.HomeButton = new System.Windows.Forms.ToolStripButton();
            this.NextButton = new System.Windows.Forms.ToolStripButton();
            this.tss_ss = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.StopButton = new System.Windows.Forms.ToolStripButton();
            this.p_AddressBar = new System.Windows.Forms.Panel();
            this.Addressbar = new System.Windows.Forms.TableLayoutPanel();
            this.AddressBarClearButton = new System.Windows.Forms.Button();
            this.GoButton = new System.Windows.Forms.Button();
            this.ProgressView = new System.Windows.Forms.PictureBox();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.DefaultContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.StatusBox = new System.Windows.Forms.Label();
            this.ControlsBar.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.p_AddressBar.SuspendLayout();
            this.Addressbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressView)).BeginInit();
            this.DefaultContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlsBar
            // 
            this.ControlsBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ControlsBar.BackgroundImage")));
            this.ControlsBar.ColumnCount = 2;
            this.ControlsBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ControlsBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ControlsBar.Controls.Add(this.MainMenu, 0, 0);
            this.ControlsBar.Controls.Add(this.p_AddressBar, 1, 0);
            this.ControlsBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlsBar.Location = new System.Drawing.Point(0, 0);
            this.ControlsBar.Name = "ControlsBar";
            this.ControlsBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ControlsBar.RowCount = 2;
            this.ControlsBar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ControlsBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ControlsBar.Size = new System.Drawing.Size(442, 30);
            this.ControlsBar.TabIndex = 39;
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.Transparent;
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackButton,
            this.HomeButton,
            this.NextButton,
            this.tss_ss,
            this.RefreshButton,
            this.StopButton});
            this.MainMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.ShowItemToolTips = false;
            this.MainMenu.Size = new System.Drawing.Size(122, 30);
            this.MainMenu.TabIndex = 36;
            // 
            // BackButton
            // 
            this.BackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BackButton.Font = new System.Drawing.Font("Tahoma", 15F);
            this.BackButton.Image = global::MiMFa.Properties.Resources.back;
            this.BackButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BackButton.Margin = new System.Windows.Forms.Padding(0);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(25, 30);
            this.BackButton.Text = "«";
            this.BackButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BackButton.Click += new System.EventHandler(this.tsb_Back_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HomeButton.Font = new System.Drawing.Font("Tahoma", 15F);
            this.HomeButton.Image = global::MiMFa.Properties.Resources.homeorig;
            this.HomeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HomeButton.Margin = new System.Windows.Forms.Padding(0);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(35, 30);
            this.HomeButton.Text = "🏠";
            this.HomeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.HomeButton.Click += new System.EventHandler(this.tsb_Home_Click);
            // 
            // NextButton
            // 
            this.NextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NextButton.Font = new System.Drawing.Font("Tahoma", 15F);
            this.NextButton.Image = global::MiMFa.Properties.Resources.next;
            this.NextButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NextButton.Margin = new System.Windows.Forms.Padding(0);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(25, 30);
            this.NextButton.Text = "»";
            this.NextButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NextButton.Click += new System.EventHandler(this.tsb_Next_Click);
            // 
            // tss_ss
            // 
            this.tss_ss.Name = "tss_ss";
            this.tss_ss.Size = new System.Drawing.Size(6, 30);
            // 
            // RefreshButton
            // 
            this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RefreshButton.Font = new System.Drawing.Font("Tahoma", 15F);
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(0);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(28, 30);
            this.RefreshButton.Text = "↺";
            this.RefreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RefreshButton.Click += new System.EventHandler(this.tsb_Refresh_Click);
            // 
            // StopButton
            // 
            this.StopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StopButton.Font = new System.Drawing.Font("Tahoma", 15F);
            this.StopButton.Image = ((System.Drawing.Image)(resources.GetObject("StopButton.Image")));
            this.StopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopButton.Margin = new System.Windows.Forms.Padding(0);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(29, 30);
            this.StopButton.Text = "×";
            this.StopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.StopButton.Visible = false;
            this.StopButton.Click += new System.EventHandler(this.tsb_Stop_Click);
            // 
            // p_AddressBar
            // 
            this.p_AddressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_AddressBar.Controls.Add(this.Addressbar);
            this.p_AddressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_AddressBar.Location = new System.Drawing.Point(125, 3);
            this.p_AddressBar.Name = "p_AddressBar";
            this.p_AddressBar.Size = new System.Drawing.Size(314, 24);
            this.p_AddressBar.TabIndex = 37;
            // 
            // Addressbar
            // 
            this.Addressbar.ColumnCount = 4;
            this.Addressbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Addressbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Addressbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Addressbar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.Addressbar.Controls.Add(this.AddressBarClearButton, 2, 0);
            this.Addressbar.Controls.Add(this.GoButton, 3, 0);
            this.Addressbar.Controls.Add(this.ProgressView, 0, 0);
            this.Addressbar.Controls.Add(this.AddressBox, 1, 0);
            this.Addressbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Addressbar.Location = new System.Drawing.Point(0, 0);
            this.Addressbar.Name = "Addressbar";
            this.Addressbar.RowCount = 1;
            this.Addressbar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Addressbar.Size = new System.Drawing.Size(312, 22);
            this.Addressbar.TabIndex = 2;
            // 
            // AddressBarClearButton
            // 
            this.AddressBarClearButton.AutoSize = true;
            this.AddressBarClearButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddressBarClearButton.FlatAppearance.BorderSize = 0;
            this.AddressBarClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddressBarClearButton.Location = new System.Drawing.Point(250, 0);
            this.AddressBarClearButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddressBarClearButton.Name = "AddressBarClearButton";
            this.AddressBarClearButton.Size = new System.Drawing.Size(22, 22);
            this.AddressBarClearButton.TabIndex = 46;
            this.AddressBarClearButton.Text = "⤬";
            this.AddressBarClearButton.UseVisualStyleBackColor = false;
            this.AddressBarClearButton.Click += new System.EventHandler(this.pb_Close_Click);
            // 
            // GoButton
            // 
            this.GoButton.AutoSize = true;
            this.GoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("GoButton.BackgroundImage")));
            this.GoButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.GoButton.FlatAppearance.BorderSize = 0;
            this.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoButton.Location = new System.Drawing.Point(272, 0);
            this.GoButton.Margin = new System.Windows.Forms.Padding(0);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(40, 22);
            this.GoButton.TabIndex = 45;
            this.GoButton.Text = "➤";
            this.GoButton.UseVisualStyleBackColor = false;
            this.GoButton.Click += new System.EventHandler(this.Go_Click);
            // 
            // ProgressView
            // 
            this.ProgressView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ProgressView.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProgressView.Image = global::MiMFa.Properties.Resources.ajax_loader_2;
            this.ProgressView.Location = new System.Drawing.Point(3, 3);
            this.ProgressView.Name = "ProgressView";
            this.ProgressView.Size = new System.Drawing.Size(14, 16);
            this.ProgressView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProgressView.TabIndex = 44;
            this.ProgressView.TabStop = false;
            this.ProgressView.Visible = false;
            // 
            // AddressBox
            // 
            this.AddressBox.AutoCompleteCustomSource.AddRange(new string[] {
            "MiMFa.net",
            "Google.com"});
            this.AddressBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AddressBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.AddressBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AddressBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddressBox.Location = new System.Drawing.Point(23, 4);
            this.AddressBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AddressBox.Size = new System.Drawing.Size(224, 13);
            this.AddressBox.TabIndex = 43;
            this.AddressBox.TextChanged += new System.EventHandler(this.AddressBox_TextChanged);
            this.AddressBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_AddressBar_KeyDown);
            // 
            // DefaultContextMenuStrip
            // 
            this.DefaultContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem,
            this.forwardToolStripMenuItem,
            this.homeToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.toolStripSeparator2,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.viewSourceToolStripMenuItem});
            this.DefaultContextMenuStrip.Name = "DefaultContextMenuStrip";
            this.DefaultContextMenuStrip.Size = new System.Drawing.Size(147, 214);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.tsb_Back_Click);
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.forwardToolStripMenuItem.Text = "Forward";
            this.forwardToolStripMenuItem.Click += new System.EventHandler(this.tsb_Next_Click);
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.tsb_Home_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.tsb_Stop_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.tsb_Refresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // viewSourceToolStripMenuItem
            // 
            this.viewSourceToolStripMenuItem.Name = "viewSourceToolStripMenuItem";
            this.viewSourceToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.viewSourceToolStripMenuItem.Text = "View Source";
            this.viewSourceToolStripMenuItem.Click += new System.EventHandler(this.viewSourceToolStripMenuItem_Click);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgressBar.Location = new System.Drawing.Point(0, 242);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(442, 2);
            this.ProgressBar.TabIndex = 40;
            // 
            // StatusBox
            // 
            this.StatusBox.AutoSize = true;
            this.StatusBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.StatusBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.StatusBox.Location = new System.Drawing.Point(0, 229);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(0, 13);
            this.StatusBox.TabIndex = 41;
            // 
            // ProfessionalBrowser
            // 
            this.ContextMenuStrip = this.DefaultContextMenuStrip;
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.ControlsBar);
            this.Controls.Add(this.ProgressBar);
            this.Name = "ProfessionalBrowser";
            this.Size = new System.Drawing.Size(442, 244);
            this.Load += new System.EventHandler(this.ProfessionalBrowser_Load);
            this.BackColorChanged += new System.EventHandler(this.ProfessionalBrowser_BackColorChanged);
            this.ForeColorChanged += new System.EventHandler(this.ProfessionalBrowser_ForeColorChanged);
            this.ControlsBar.ResumeLayout(false);
            this.ControlsBar.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.p_AddressBar.ResumeLayout(false);
            this.Addressbar.ResumeLayout(false);
            this.Addressbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressView)).EndInit();
            this.DefaultContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        public System.Windows.Forms.ToolStrip MainMenu;
        public System.Windows.Forms.ToolStripButton BackButton;
        public System.Windows.Forms.ToolStripButton HomeButton;
        public System.Windows.Forms.ToolStripButton NextButton;
        private System.Windows.Forms.ToolStripSeparator tss_ss;
        public System.Windows.Forms.ToolStripButton RefreshButton;
        public System.Windows.Forms.ToolStripButton StopButton;
        public System.Windows.Forms.TableLayoutPanel ControlsBar;
        private System.Windows.Forms.Panel p_AddressBar;
        public System.Windows.Forms.TableLayoutPanel Addressbar;
        public System.Windows.Forms.PictureBox ProgressView;
        public System.Windows.Forms.TextBox AddressBox;
        public System.Windows.Forms.Button AddressBarClearButton;
        public System.Windows.Forms.Button GoButton;
        public System.Windows.Forms.ContextMenuStrip DefaultContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSourceToolStripMenuItem;
        public System.Windows.Forms.Label StatusBox;
        public System.Windows.Forms.ProgressBar ProgressBar;
    }
}
