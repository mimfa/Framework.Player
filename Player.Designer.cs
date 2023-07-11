namespace MiMFa.UIL.Player
{
    partial class Player
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Player));
            this.SourcePanel = new System.Windows.Forms.Panel();
            this.tb_SelectPath = new System.Windows.Forms.TextBox();
            this.btn_SelectPath = new System.Windows.Forms.Button();
            this.btn_Play = new System.Windows.Forms.Button();
            this.ViewBox = new MiMFa.Controls.WinForm.Browser.EverythingPlayer();
            this.SourcePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourcePanel
            // 
            this.SourcePanel.AutoSize = true;
            this.SourcePanel.BackColor = System.Drawing.SystemColors.Window;
            this.SourcePanel.Controls.Add(this.tb_SelectPath);
            this.SourcePanel.Controls.Add(this.btn_SelectPath);
            this.SourcePanel.Controls.Add(this.btn_Play);
            this.SourcePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SourcePanel.Location = new System.Drawing.Point(0, 0);
            this.SourcePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SourcePanel.Name = "SourcePanel";
            this.SourcePanel.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.SourcePanel.Size = new System.Drawing.Size(800, 30);
            this.SourcePanel.TabIndex = 14;
            // 
            // tb_SelectPath
            // 
            this.tb_SelectPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tb_SelectPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllSystemSources;
            this.tb_SelectPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_SelectPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_SelectPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_SelectPath.Location = new System.Drawing.Point(46, 7);
            this.tb_SelectPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_SelectPath.Name = "tb_SelectPath";
            this.tb_SelectPath.Size = new System.Drawing.Size(708, 16);
            this.tb_SelectPath.TabIndex = 0;
            this.tb_SelectPath.TabStop = false;
            this.tb_SelectPath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_SelectPath_KeyUp);
            // 
            // btn_SelectPath
            // 
            this.btn_SelectPath.AutoSize = true;
            this.btn_SelectPath.BackColor = System.Drawing.SystemColors.Window;
            this.btn_SelectPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_SelectPath.FlatAppearance.BorderSize = 0;
            this.btn_SelectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectPath.Font = new System.Drawing.Font("Microsoft YaHei", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SelectPath.Location = new System.Drawing.Point(5, 7);
            this.btn_SelectPath.Margin = new System.Windows.Forms.Padding(0);
            this.btn_SelectPath.Name = "btn_SelectPath";
            this.btn_SelectPath.Size = new System.Drawing.Size(41, 16);
            this.btn_SelectPath.TabIndex = 8;
            this.btn_SelectPath.Text = "Select";
            this.btn_SelectPath.UseCompatibleTextRendering = true;
            this.btn_SelectPath.UseVisualStyleBackColor = false;
            this.btn_SelectPath.Click += new System.EventHandler(this.btn_SelectPath_Click);
            // 
            // btn_Play
            // 
            this.btn_Play.AutoSize = true;
            this.btn_Play.BackColor = System.Drawing.SystemColors.Window;
            this.btn_Play.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Play.FlatAppearance.BorderSize = 0;
            this.btn_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Play.Font = new System.Drawing.Font("Microsoft YaHei", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Play.Location = new System.Drawing.Point(754, 7);
            this.btn_Play.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(41, 16);
            this.btn_Play.TabIndex = 9;
            this.btn_Play.Text = "➤";
            this.btn_Play.UseCompatibleTextRendering = true;
            this.btn_Play.UseVisualStyleBackColor = false;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // ViewBox
            // 
            this.ViewBox.AllowDrop = true;
            this.ViewBox.AllowFullScreen = true;
            this.ViewBox.AutoStart = false;
            this.ViewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewBox.InvertColor = false;
            this.ViewBox.Location = new System.Drawing.Point(0, 30);
            this.ViewBox.LockState = false;
            this.ViewBox.Name = "ViewBox";
            this.ViewBox.Size = new System.Drawing.Size(800, 420);
            this.ViewBox.SpecialView = true;
            this.ViewBox.TabIndex = 15;
            this.ViewBox.URL = new System.Uri("https://mimfa.net", System.UriKind.Absolute);
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ViewBox);
            this.Controls.Add(this.SourcePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Player";
            this.Text = "MiMFa Everything Player";
            this.Load += new System.EventHandler(this.EverythingPlayer_Load);
            this.SourcePanel.ResumeLayout(false);
            this.SourcePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel SourcePanel;
        private System.Windows.Forms.TextBox tb_SelectPath;
        private System.Windows.Forms.Button btn_SelectPath;
        private MiMFa.Controls.WinForm.Browser.EverythingPlayer ViewBox;
        private System.Windows.Forms.Button btn_Play;
    }
}

