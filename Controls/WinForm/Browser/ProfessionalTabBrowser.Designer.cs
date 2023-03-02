
namespace MiMFa.Controls.WinForm.Browser
{
    partial class ProfessionalTabBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfessionalTabBrowser));
            this.@TabBar = new MiMFa.Controls.WinForm.Tab.TabBar();
            this.@TabPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // @TabBar
            // 
            this.@TabBar.ActiveBackColor = System.Drawing.Color.Empty;
            this.@TabBar.ActiveForeColor = System.Drawing.Color.Empty;
            this.@TabBar.ActiveImage = null;
            this.@TabBar.AllowClose = true;
            this.@TabBar.AllowDrop = true;
            this.@TabBar.AllowFullScreen = true;
            this.@TabBar.AllowRename = false;
            this.@TabBar.AutoActive = true;
            this.@TabBar.DeactiveBackColor = System.Drawing.Color.Empty;
            this.@TabBar.DeactiveForeColor = System.Drawing.Color.Empty;
            this.@TabBar.DeactiveImage = ((System.Drawing.Image)(resources.GetObject("@TabBar.DeactiveImage")));
            this.@TabBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.@TabBar.HoverBackColor = System.Drawing.Color.Empty;
            this.@TabBar.HoverForeColor = System.Drawing.Color.Empty;
            this.@TabBar.HoverImage = null;
            this.@TabBar.IsUpdating = false;
            this.@TabBar.CurrentTab = null;
            this.@TabBar.TabsContextMenuStrip = null;
            this.@TabBar.Tabs = new MiMFa.Controls.WinForm.Tab.TabBarItem[0];
            this.@TabBar.Location = new System.Drawing.Point(0, 0);
            this.@TabBar.Name = "@TabBar";
            this.@TabBar.Size = new System.Drawing.Size(345, 24);
            this.@TabBar.TabIndex = 0;
            this.@TabBar.TabPanel = this.@TabPanel;
            // 
            // @TabPanel
            // 
            this.@TabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.@TabPanel.Location = new System.Drawing.Point(0, 24);
            this.@TabPanel.Name = "@TabPanel";
            this.@TabPanel.Size = new System.Drawing.Size(345, 246);
            this.@TabPanel.TabIndex = 1;
            // 
            // ProfessioonalTabBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.@TabPanel);
            this.Controls.Add(this.@TabBar);
            this.Name = "ProfessioonalTabBrowser";
            this.Size = new System.Drawing.Size(345, 270);
            this.ResumeLayout(false);

        }

        #endregion

        public Tab.TabBar TabBar;
        public System.Windows.Forms.Panel TabPanel;
    }
}
