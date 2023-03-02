namespace MiMFa.Controls.WinForm.Browser
{
    partial class EverythingPlayer : Browser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EverythingPlayer));
            this.p_Main = new System.Windows.Forms.Panel();
            this.PWB = new MiMFa.Controls.WinForm.Browser.ProfessionalBrowser();
            this.WB = new System.Windows.Forms.WebBrowser();
            this.WMP = new AxWMPLib.AxWindowsMediaPlayer();
            this.p_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WMP)).BeginInit();
            this.SuspendLayout();
            // 
            // p_Main
            // 
            this.p_Main.BackColor = System.Drawing.Color.Transparent;
            this.p_Main.Controls.Add(this.PWB);
            this.p_Main.Controls.Add(this.WB);
            this.p_Main.Controls.Add(this.WMP);
            this.p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_Main.Location = new System.Drawing.Point(0, 0);
            this.p_Main.Name = "p_Main";
            this.p_Main.Size = new System.Drawing.Size(442, 244);
            this.p_Main.TabIndex = 0;
            this.p_Main.Resize += new System.EventHandler(this.p_Main_Resize);
            // WB
            // 
            this.PWB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PWB.Location = new System.Drawing.Point(0, 0);
            this.PWB.MinimumSize = new System.Drawing.Size(20, 20);
            this.PWB.Name = "PWB";
            this.PWB.Size = new System.Drawing.Size(442, 244);
            this.PWB.TabIndex = 0;
            this.PWB.AllowNavigate = false;
            this.PWB.Visible = false;
            // 
            // WB
            // 
            this.WB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WB.Location = new System.Drawing.Point(0, 0);
            this.WB.MinimumSize = new System.Drawing.Size(20, 20);
            this.WB.Name = "WB";
            this.WB.ScriptErrorsSuppressed = true;
            this.WB.Size = new System.Drawing.Size(442, 244);
            this.WB.TabIndex = 0;
            this.WB.Visible = false;
            this.WB.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WB_DocumentCompleted);
            // 
            // WMP
            // 
            this.WMP.Enabled = true;
            this.WMP.Location = new System.Drawing.Point(0, 0);
            this.WMP.Name = "WMP";
            this.WMP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMP.OcxState")));
            this.WMP.Size = new System.Drawing.Size(442, 244);
            this.WMP.TabIndex = 1;
            this.WMP.Visible = false;
            this.WMP.StatusChange += new System.EventHandler(this.p_Main_Resize);
            this.WMP.ErrorEvent += new System.EventHandler(this.WMP_ErrorEvent);
            this.WMP.MediaError += new AxWMPLib._WMPOCXEvents_MediaErrorEventHandler(this.WMP_MediaError);
            this.WMP.DoubleClickEvent += new AxWMPLib._WMPOCXEvents_DoubleClickEventHandler(this.WMP_DoubleClickEvent);
            this.WMP.Validated += new System.EventHandler(this.WMP_Validated);
            // 
            // EverythingPlayer
            // 
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainDragOver);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainDragDrop);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AllowDrop = true;
            this.Controls.Add(this.p_Main);
            this.Name = "EverythingPlayer";
            this.Size = new System.Drawing.Size(442, 244);
            this.p_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WMP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_Main;
        private AxWMPLib.AxWindowsMediaPlayer WMP;
        private MiMFa.Controls.WinForm.Browser.ProfessionalBrowser PWB;
        private System.Windows.Forms.WebBrowser WB;
    }
}
