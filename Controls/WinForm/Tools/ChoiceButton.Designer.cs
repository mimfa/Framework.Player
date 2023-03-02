namespace MiMFa.Controls.WinForm.Tools
{
    partial class ChoiceButton
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
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.LabelBox = new System.Windows.Forms.Label();
            this.FV = new MiMFa.Controls.WinForm.Browser.EverythingPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.AutoSize = true;
            this.tlp_Main.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_Main.Controls.Add(this.LabelBox, 0, 0);
            this.tlp_Main.Controls.Add(this.FV, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(100, 120);
            this.tlp_Main.TabIndex = 1;
            this.tlp_Main.TabStop = true;
            this.tlp_Main.Click += new System.EventHandler(this.ChoiceButton_Click);
            // 
            // LABLE
            // 
            this.LabelBox.AutoSize = true;
            this.LabelBox.BackColor = System.Drawing.Color.Transparent;
            this.LabelBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelBox.Location = new System.Drawing.Point(3, 3);
            this.LabelBox.Margin = new System.Windows.Forms.Padding(0);
            this.LabelBox.Name = "LABLE";
            this.LabelBox.Padding = new System.Windows.Forms.Padding(5, 3, 5, 6);
            this.LabelBox.Size = new System.Drawing.Size(94, 22);
            this.LabelBox.TabIndex = 1;
            this.LabelBox.Text = "Content";
            this.LabelBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelBox.TextChanged += new System.EventHandler(this.l_label_TextChanged);
            this.LabelBox.Click += new System.EventHandler(this.ChoiceButton_Click);
            // 
            // FV
            // 
            this.FV.AutoStart = false;
            this.FV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FV.AllowFullScreen = true;
            this.FV.InvertColor = false;
            this.FV.Location = new System.Drawing.Point(6, 28);
            this.FV.LockState = false;
            this.FV.Name = "FV";
            this.FV.Size = new System.Drawing.Size(88, 86);
            this.FV.SpecialView = true;
            this.FV.TabIndex = 2;
            this.FV.URL = new System.Uri("http://www.parsgo.ir/", System.UriKind.Absolute);
            this.FV.ValueChanged += new System.EventHandler(this.FV_ValueChanged);
            this.FV.Click += new System.EventHandler(this.ChoiceButton_Click);
            // 
            // ChoiceButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "ChoiceButton";
            this.Size = new System.Drawing.Size(100, 120);
            this.Click += new System.EventHandler(this.ChoiceButton_Click);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private Browser.EverythingPlayer FV;
    }
}
