namespace MiMFa.Controls.WinForm.Tools
{
    partial class ProfessionalImportFile
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
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.standardImportFile1 = new MiMFa.Controls.WinForm.Tools.StandardImportFile();
            this.FV = new MiMFa.Controls.WinForm.Browser.EverythingPlayer();
            this.SuspendLayout();
            // 
            // OFD
            // 
            this.OFD.RestoreDirectory = true;
            // 
            // standardImportFile1
            // 
            this.standardImportFile1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standardImportFile1.InvertColor = false;
            this.standardImportFile1.Location = new System.Drawing.Point(0, 0);
            this.standardImportFile1.LockState = false;
            this.standardImportFile1.Name = "standardImportFile1";
            this.standardImportFile1.OpenFileDialogFileName = "";
            this.standardImportFile1.OpenFileDialogFilter = "";
            this.standardImportFile1.Size = new System.Drawing.Size(257, 25);
            this.standardImportFile1.SubjectValue = "Select File";
            this.standardImportFile1.TabIndex = 0;
            this.standardImportFile1.Value = "";
            this.standardImportFile1.ValueChanged += new System.EventHandler(this.standardImportFile1_ValueChanged);
            // 
            // FV
            // 
            this.FV.AutoStart = false;
            this.FV.BackColor = System.Drawing.Color.Transparent;
            this.FV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FV.AllowFullScreen = true;
            this.FV.InvertColor = false;
            this.FV.Location = new System.Drawing.Point(0, 25);
            this.FV.LockState = false;
            this.FV.Name = "FV";
            this.FV.Size = new System.Drawing.Size(257, 243);
            this.FV.TabIndex = 1;
            this.FV.URL = new System.Uri("http://www.parsgo.ir/", System.UriKind.Absolute);
            // 
            // ProfessionalImportFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FV);
            this.Controls.Add(this.standardImportFile1);
            this.Name = "ProfessionalImportFile";
            this.Size = new System.Drawing.Size(257, 268);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OFD;
        private StandardImportFile standardImportFile1;
        private Browser.EverythingPlayer FV;
    }
}
