using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MiMFa.Service;
using MiMFa.Exclusive.View;

namespace MiMFa.Controls.WinForm.Tools
{
    public partial class ProfessionalImportFile : Tools
    {
        #region Categury
        [CategoryAttribute]

        public event EventHandler ValueChanged = (o,e)=> { };
        public string Path
        {
            get { return standardImportFile1.Value; }
            set
            {
                standardImportFile1.Value = value;
                if (System.IO.File.Exists(standardImportFile1.Value))
                {
                    _File = IOService.TryDeserialize(System.IO.File.ReadAllBytes(standardImportFile1.Value));
                    FV.Open(value);
                }
                else
                {
                    _File = null;
                    FV.Clear();
                }
                ValueChanged(this, EventArgs.Empty);
            }
        }
        public object _File = null;
        public object File
        {
            get
            {
                return _File;
            }
            set
            {
                _File = value;
                FV.Load(value);
                ValueChanged(this, EventArgs.Empty);
            }
        }
        public string SubjectValue
        {
            get { return standardImportFile1.SubjectValue; }
            set
            {
                standardImportFile1.SubjectValue = value;
                standardImportFile1.TitleBox.Visible = !string.IsNullOrEmpty(standardImportFile1.SubjectValue);
            }
        }
        public string OpenFileDialogFilter
        {
            get { return OFD.Filter; }
            set { OFD.Filter = value; }
        }
        public string OpenFileDialogFileName
        {
            get { return OFD.FileName; }
            set { OFD.FileName = value; }
        }
        #endregion

        public ProfessionalImportFile()
        {
            InitializeComponent();
        }

        public void Clear() => standardImportFile1.Clear();

        private void standardImportFile1_ValueChanged(object sender, EventArgs e)
        {
            Path = standardImportFile1.Value;
        }
    }
}
