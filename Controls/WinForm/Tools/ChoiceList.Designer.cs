namespace MiMFa.Controls.WinForm.Tools
{
    partial class ChoiceList
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
            this.fp_main = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // fp_main
            // 
            this.fp_main.BackColor = System.Drawing.Color.Transparent;
            this.fp_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fp_main.Location = new System.Drawing.Point(0, 0);
            this.fp_main.Name = "fp_main";
            this.fp_main.Size = new System.Drawing.Size(290, 229);
            this.fp_main.TabIndex = 1;
            this.fp_main.TabStop = true;
            // 
            // ChoiceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fp_main);
            this.Name = "ChoiceList";
            this.Size = new System.Drawing.Size(290, 229);
            this.AutoSizeChanged += new System.EventHandler(this.ChoiceList_AutoSizeChanged);
            this.Resize += new System.EventHandler(this.ChoiceList_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fp_main;
    }
}
