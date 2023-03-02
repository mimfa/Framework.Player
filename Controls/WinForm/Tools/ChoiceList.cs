using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiMFa.Service;

namespace MiMFa.Controls.WinForm.Tools
{
    public partial class ChoiceList : Tools
    {
        #region CategoryAttribute
        [CategoryAttribute()]
        public event EventHandler ValueChanged = (o, e) => { };
        public event EventHandler ChoicedChanged = (o, e) => { };

        public ChoiceButton ChoicedItem
        {
            get
            {
                for (int i = 0; i < fp_main.Controls.Count; i++)
                    if (((ChoiceButton)fp_main.Controls[i]).Choiced) return ((ChoiceButton)fp_main.Controls[i]);
                return null;
            }
            set
            {
                if (value == null) MultiChoice = false;
                else value.Choiced = true;
            }
        }
        public int ChoicedIndex
        {
            get
            {
                for (int i = 0; i < fp_main.Controls.Count; i++)
                    if (((ChoiceButton)fp_main.Controls[i]).Choiced) return i;
                return -1;
            }
            set
            {
                MultiChoice = false;
                if (value > -1 && value < fp_main.Controls.Count) ((ChoiceButton)fp_main.Controls[value]).Choiced = true;
            }
        }
        public int[] ChoicedIndeces
        {
            get
            {
                List<int> li = new List<int>();
                for (int i = 0; i < fp_main.Controls.Count; i++)
                    if (((ChoiceButton)fp_main.Controls[i]).Choiced) li.Add(i);
                return li.ToArray();
            }
            set
            {
                for (int i = 0; i < fp_main.Controls.Count; i++)
                    if (CollectionService.FindIndex(value, i) > -1)
                        ((ChoiceButton)fp_main.Controls[i]).Choiced = true;
                    else ((ChoiceButton)fp_main.Controls[i]).Choiced = false;
            }
        }
        public string[] ChoicedTexts
        {
            get
            {
                List<string> li = new List<string>();
                ChoiceButton cb;
                for (int i = 0; i < fp_main.Controls.Count; i++)
                    if ((cb = (ChoiceButton)fp_main.Controls[i]).Choiced) li.Add(cb.Label);
                return li.ToArray();
            }
            set
            {
                ChoiceButton cb;
                for (int i = 0; i < fp_main.Controls.Count; i++)
                    for (int j = 0; j < value.Length; j++)
                        if ((cb = (ChoiceButton)fp_main.Controls[i]).Label == value[j]) cb.Choiced = true;
            }
        }
        public FlowDirection FlowDirection
        {
            get { return fp_main.FlowDirection; }
            set { fp_main.FlowDirection = value; }
        }
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = fp_main.AutoSize = value;
            }
        }
        public override bool AutoScroll
        {
            get
            {
                return base.AutoScroll;
            }
            set
            {
                base.AutoScroll = fp_main.AutoScroll = value;
            }
        }

        private void ChoicedChange(object sender, EventArgs e)
        {
            ChoicedChanged(sender, e);
            var cb = (ChoiceButton)sender;
            bool choices = cb.Choiced;
            if (SingleChoice)
                for (int i = 0; i < fp_main.Controls.Count; i++)
                {
                    var choi = ((ChoiceButton)fp_main.Controls[i]);
                    if (choi != cb) choi.Choiced = false;
                    ValueChanged(sender, e);
                }
            cb.Choiced = choices;
        }

        public ChoiceButton[] Items
        {
            get
            {
                List<ChoiceButton> li = new List<ChoiceButton>();
                for (int i = 0; i < fp_main.Controls.Count; i++)
                    li.Add((ChoiceButton)fp_main.Controls[i]);
                return li.ToArray();
            }
            set
            {
                //if (value != null && value.Length > 0) fp_main.Controls.Clear();
                for (int i = 0; i < value.Length; i++)
                {
                    value[i].ChoicedChanged += ChoicedChange;
                    fp_main.Controls.Add(value[i]);
                }
            }
        }
        public bool MultiChoice
        {
            get
            {
                for (int i = 0; i < fp_main.Controls.Count; i++)
                    if (!((ChoiceButton)fp_main.Controls[i]).Choiced) return false;
                return true;
            }
            set
            {
                for (int i = 0; i < fp_main.Controls.Count; i++)
                    ((ChoiceButton)fp_main.Controls[i]).Choiced = value;
            }
        }
        public bool SingleChoice { get; set; } = true;
        #endregion

        public ChoiceList()
        {
            InitializeComponent();
        }
        public ChoiceButton Add(string text,object file)
        {
            ChoiceButton cb = new ChoiceButton();
            {
                cb.Label = text;
                cb.File = file;
                cb.Choiced = false;
            }
            Items = MiMFa.Service.CollectionService.Concat(Items, new ChoiceButton[]{ cb});
            return cb;
        }
        public void Clear()
        {
            fp_main.Controls.Clear();
        }

        private void ChoiceList_Resize(object sender, EventArgs e)
        {
        }

        private void ChoiceList_AutoSizeChanged(object sender, EventArgs e)
        {
        }
    }
}
