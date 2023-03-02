using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiMFa.Exclusive.View;
using MiMFa.Service;

namespace MiMFa.Controls.WinForm.Tools
{
    public partial class ChoiceButton : Button
    {
        [Category()]
        public event EventHandler ValueChanged = (o,e)=>{};
        public event EventHandler ChoicedChanged = (o, e) => { };
        public bool Choiced
        {
            get { return tlp_Main.BackgroundImage != null; }
            set
            {
                if (value != Choiced)
                {
                    if (value)
                    {
                        tlp_Main.BackgroundImage = ChoiceImage;
                    }
                    else
                    {
                        tlp_Main.BackgroundImage = null;
                    }
                    if (ChoicedChanged != null) ChoicedChanged(this, EventArgs.Empty);
                }
            }
        }
        public static ToHTML Display = new ToHTML();
        public object _File = null;
        public object File
        {
            get { return _File; }
            set
            {
                _File = value;
                if (FV.Visible = !string.IsNullOrEmpty((value + "").Trim()))
                    FV.Load(_File);
                else FV.Clear();
                ValueChanged(this, EventArgs.Empty);
            }
        }
        public override string Label
        {
            get { return LabelBox.Text; }
            set
            {
                LabelBox.Text = value;
                if(CanGrow)try { size = Size = new Size( LabelBox.Width + 6,Size.Height); } catch { }
                if (ValueChanged != null) ValueChanged(this, EventArgs.Empty);
            }
        }
        public Image ChoiceImage { get; set; } = Properties.Resources.Green5;
        public bool CanGrow { get; set; } = true;
        public bool FullScreenAllowance
        {
            get
            {
                return FV.AllowFullScreen;
            }
            set
            {
                FV.AllowFullScreen = value;
            }
        }
        public bool AutoStart
        {
            get
            {
                return FV.AutoStart;
            }
            set
            {
                FV.AutoStart = value;
            }
        }

        Size size = new Size(100,125);
        public ChoiceButton()
        {
            InitializeComponent();
            //SetAllEventParentToControls();
            size = Size;
            LabelBox.Visible = !string.IsNullOrEmpty(LabelBox.Text);
            if (FV.Visible) Size = size;
            else Size = LabelBox.Size;
        }

        private void l_label_TextChanged(object sender, EventArgs e)
        {
            LabelBox.Visible = !string.IsNullOrEmpty(LabelBox.Text);
        }
        private void ChoiceButton_Click(object sender, EventArgs e)
        {
            Choiced = !Choiced;
        }
        private void FV_ValueChanged(object sender, EventArgs e)
        {
            LabelBox.Visible = !string.IsNullOrEmpty(LabelBox.Text);
            if (FV.Visible = !string.IsNullOrEmpty((_File + "").Trim()))
                Size = new Size(Math.Max(LabelBox.Width, size.Height),size.Height);
            else Size = LabelBox.Size;
        }
    }
}
