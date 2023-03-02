using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiMFa.Service;
using System.IO;
using MiMFa.General;
using MiMFa.Exclusive.View;
using System.Runtime.ConstrainedExecution;
using System.ComponentModel.Design;

namespace MiMFa.Controls.WinForm.Browser
{
    [DesignTimeVisible(true)]
    [Designer(typeof(System.Windows.Forms.Design.ControlDesigner), typeof(IDesigner))]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    [DefaultEvent("ValueChanged")]
    [DefaultProperty("AllowFullScreen")]
    public partial class EverythingPlayer : Browser
    {
        [CategoryAttribute]
        public event EventHandler ValueChanged = (o,e)=> { };
        public ToHTML Display = new ToHTML();
        public string Path { get; private set; }
        public object Value { get; private set; }
        public bool AllowFullScreen {  get; set;  } = true;
        public bool AutoStart {  get; set;  } = false;
        public bool SpecialView { get; set; } = true;

        string StartHTML = "<html style='width:100%; overflow-x:hidden;'><head><meta charset='UTF-8'/></head><body style='width:100%; overflow-x:hidden;'>";
        string ShowSimplyStartHTML = @"<html style='width:100%; overflow-x:hidden; overflow-y:hidden;'><head><meta charset='UTF-8'/>
                <style>
                    body {
	                padding: 0;
	                margin: 0;
	                border: 0;
	                outline: 0;
	                font-size: 100%;
	                vertical-align: baseline;
                    text-align:center;
	                background: transparent;
	                line-height: 1;
                    width:100%;
                    overflow-x:hidden;
                    height:100%;
                    overflow-y:hidden;
                }
                </style>
</head><body>";
        string EndHTML = "</body></html>";
        public EverythingPlayer()
        {
            InitializeComponent();
            Display.Size = Size;
        }

        public bool Open(object value)
        {
            if (value == null) Clear();
            else if (value is string && Open(value.ToString())) return true;
            else return Load(value);
            return false;
        }
        public bool Open(string path)
        {
            if (!string.IsNullOrEmpty(path))
                if ( InfoService.IsAbsoluteURL(path))
                {
                    LoadUrl(path);
                    return true;
                }
                else
                {
                    string ext = System.IO.Path.GetExtension(path).ToLower();
                    string mime = "";
                    try { mime =  InfoService.GetMimeFile(path).Split('/')[0].Trim().ToLower(); } catch { }
                    if (mime == "image"
                        || ext.StartsWith(".png")
                        || ext.StartsWith(".svg")
                    )
                    {
                        var img = IOService.TryDeserialize(File.ReadAllBytes(path));
                        string size = "";
                        float h = Size.Height * 1F / img.Height;
                        float w = Size.Width * 1F / img.Width;
                        if (h <= w) size += "height:100%;";
                        else size += "width:100%;";
                        LoadWebBrowser("<IMG src='" + path + "' STYLE='max-width:100%;max-height:100%;" + size + "'>", img, true);
                    }
                    else if (mime == "text") LoadWebBrowser(IOService.ReadText(path));
                    else if (mime == "")
                        if (Directory.Exists(path)) LoadDirectory(path);
                        else
                        {
                            //Clear();
                            LoadWebBrowser(path);
                            return false;
                        }
                    else
                    {
                        bool b = InfoService.IsBinaryFile(path);
                        if (b)
                        {
                            if (ext == ".pdf"
                                || ext.StartsWith(".doc")
                                || ext.StartsWith(".xls")
                                ) OpenWebBrowser(path);
                            else OpenMediaPlayer(path);
                        }
                        else LoadWebBrowser(IOService.ReadText(path));
                    }
                    return true;
                }
            else Clear(); 
            return false;
        }
     
        public void OpenMediaPlayer(string path)
        {
            Clear();
            if (string.IsNullOrEmpty(path)) return;
            Path = path;
            //WMP.Visible = true;
            ControlService.SetControlThreadSafe(
                WMP,
                new Action<object[]>((arg) =>
                {
                    WMP.settings.autoStart = AutoStart;
                    WMP.URL = path;
                    WMP.Show();
                }), new object[] { });
                ValueChanged(this, EventArgs.Empty);
        }
        public void OpenWebBrowser(string path)
        {
            Clear();
            if (string.IsNullOrEmpty(path)) return;
            Path = path;
            PWB.Show();
            PWB.Navigate(Path);
            ValueChanged(this, EventArgs.Empty);
        }
        public void OpenBrowser(string path)
        {
            Clear();
            if (string.IsNullOrEmpty(path)) return;
            Path = path;
            WB.Show();
            WB.Navigate(Path);
            ValueChanged(this, EventArgs.Empty);
        }

        public bool Load(object value)
        {
            if (value != null)
                try
                {
                    if (value is Bitmap) LoadWebBrowser(value, true);
                    else if (value is Image) LoadWebBrowser(value, true);
                    else if (value is Form) LoadForm((Form)value);
                    else if (value is Control) LoadControl((Control)value);
                    else if (value is Uri) LoadUri((Uri)value);
                    else
                    {
                        string mime = InfoService.GetMimeObject(value).Split('/')[0].Trim().ToLower();
                        if (mime == "image") LoadWebBrowser(value, true);
                        else if (mime == "text") LoadWebBrowser(StringService.ToHTML(value + ""), false);
                        else LoadMediaPlayer(value);
                    }
                    return true;
                }
                catch(Exception ex) { LoadWebBrowser(value.ToString(), true); }
            else Clear();
            return false;
        }


        public void LoadControl(Control value)
        {
            Clear();
            value.Dock = DockStyle.Fill;
            value.BringToFront();
            this.p_Main.Controls.Add(value);
        }
        public void LoadForm(Form value)
        {
            Clear();
            value.Dock = DockStyle.Fill;
            value.BringToFront();
            this.p_Main.Controls.Add(value);
        }
        public void LoadMediaPlayer(object value)
        {
            Clear();
            Value = value;
            //WMP.Visible = true;
            Path = TempDirectory + System.DateTime.Now.Ticks +".mp4";
            File.WriteAllBytes(Path, IOService.Serialize(Value));
            ControlService.SetControlThreadSafe(
                WMP,
                new Action<object[]>((arg) =>
                {
                    WMP.settings.autoStart = AutoStart;
                    WMP.URL = Path;
                    WMP.Visible = true;
                }), new object[] { });
                ValueChanged(this, EventArgs.Empty);
        }
        public void LoadWebBrowser(object value,bool inCenter = false)
        {
            LoadWebBrowser(Display.Done(value),value, inCenter);
        }
        public void LoadWebBrowser(string tag,object value,bool inCenter = false)
        {
            Clear();
            Value = value;
            PWB.Visible = true;
            PWB.LoadHTML(((SpecialView && inCenter) ? ShowSimplyStartHTML:StartHTML) + tag + EndHTML);
            //ControlService.WebBrowserDocument(ref WB, ((SpecialView && inCenter) ? ShowSimplyStartHTML:StartHTML) + tag + EndHTML);
            ValueChanged(this, EventArgs.Empty);
        }
        public void LoadUri(Uri url)
        {
            LoadWebBrowser(null);
            PWB.Navigate(url);
        }
        public void LoadUrl(string url)
        {
            LoadWebBrowser(null);
            PWB.Navigate(url);
        }
        public void LoadBrowser(object value, bool inCenter = false)
        {
            LoadBrowser(Display.Done(value), value, inCenter);
        }
        public void LoadBrowser(string tag, object value, bool inCenter = false)
        {
            Clear();
            Value = value;
            WB.Show();
            ControlService.WebBrowserDocument(ref WB, ((SpecialView && inCenter) ? ShowSimplyStartHTML:StartHTML) + tag + EndHTML);
            ValueChanged(this, EventArgs.Empty);
        }
        public void LoadDirectory(string url)
        {
            LoadBrowser(null);
            WB.Navigate(url);
        }


        public void Clear()
        {
            try
            {
                 PathService.CreateAllDirectories(TempDirectory);
                Path = string.Empty;
                Value = null;
                PWB.Hide();
                WB.Hide();
                WMP.Hide();
                WMP.URL = string.Empty;

                ControlService.SetControlThreadSafe(
                     p_Main,
                     new Action<object[]>((arg) =>
                     {
                         for (int i = p_Main.Controls.Count - 1; i > 2; i--)
                             p_Main.Controls.RemoveAt(i);
                     })
                    );
                ControlService.SetControlThreadSafe(
                     PWB,
                     new Action<object[]>((arg) =>
                     {
                         PWB.LoadHTML(string.Empty);
                     }), new object[] { });
                ControlService.SetControlThreadSafe(
                     WB,
                     new Action<object[]>((arg) =>
                     {
                         ControlService.WebBrowserDocumentText(ref WB, string.Empty);
                     }), new object[] { });
                ControlService.SetControlThreadSafe(
                    WMP,
                    new Action<object[]>((arg) =>
                    {
                        WMP.settings.autoStart = false;
                        WMP.URL = "";
                    }), new object[] { });
            }
            catch { }
            finally { ValueChanged(this, EventArgs.Empty); }
        }
        public void FullScreen()
        {
            if(AllowFullScreen){
                Form f = new Form();
                EverythingPlayer fv = new EverythingPlayer();
                f.SuspendLayout();
                f.Text = Path;
                fv.SuspendLayout();
                fv.Dock = DockStyle.Fill;
                fv.SpecialView = false;
                fv.AllowFullScreen = false;
                fv.AutoStart = false;
                if (Value != null) fv.Load(Value);
                else if (!string.IsNullOrEmpty(Path)) fv.Open(Path);
                f.Controls.Add(fv);
                fv.ResumeLayout();
                fv.PerformLayout();
                f.ResumeLayout();
                f.PerformLayout();
                f.TopMost = true;
                f.ShowDialog();
                fv.Clear();
            }
        }

        private void p_Main_Resize(object sender, EventArgs e)
        {
            WMP.Size = p_Main.Size;
            WMP.Location = new Point(0,0);
        }
        private void WMP_MediaError(object sender, AxWMPLib._WMPOCXEvents_MediaErrorEvent e)
        {

        }
        private void WMP_DoubleClickEvent(object sender, AxWMPLib._WMPOCXEvents_DoubleClickEvent e)
        {
            FullScreen();
        }
        private void WB_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (WB.Document != null)
                try
                {
                    HtmlElementCollection element = WB.Document.GetElementsByTagName("img");
                    if (element != null)
                        for (int i = 0; i < element.Count; i++)
                        {
                            element[i].DoubleClick += (s, er) =>
                                FullScreen();
                            element[i].Click += (s, er) =>
                                  OnClick(EventArgs.Empty);
                        }
                    else
                    {
                        element = WB.Document.GetElementsByTagName("body");
                        if (element != null)
                            for (int i = 0; i < element.Count; i++)
                            {
                                element[i].DoubleClick += (s, er) =>
                                    FullScreen();
                                element[i].Click += (s, er) =>
                                      OnClick(EventArgs.Empty);
                            }
                    }
                }
                catch { }
        }
        private void WMP_ErrorEvent(object sender, EventArgs e)
        {
            if (Value != null) LoadWebBrowser(Value);
            else OpenWebBrowser(Path);
        }
        private void WMP_Validated(object sender, EventArgs e)
        {
        }

        public void MainDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else if (e.Data.GetDataPresent(DataFormats.UnicodeText) &&
                (InfoService.IsAddress(e.Data.GetData(DataFormats.UnicodeText) + "")
                || InfoService.IsAbsoluteURL(e.Data.GetData(DataFormats.UnicodeText) + "")))
                e.Effect = DragDropEffects.Link;
            else if (e.Data.GetDataPresent(DataFormats.StringFormat))
                e.Effect = DragDropEffects.All;
            else if (e.Data.GetDataPresent(DataFormats.Serializable))
                e.Effect = DragDropEffects.All;
            else if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.All;
            else e.Effect = DragDropEffects.None;
        }
        public void MainDragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                foreach (var item in (string[])e.Data.GetData(DataFormats.FileDrop))
                    Open(item);
            else if (e.Data.GetDataPresent(DataFormats.UnicodeText))
                Open((e.Data.GetData(DataFormats.UnicodeText)));
            else if (e.Data.GetDataPresent(DataFormats.StringFormat))
                Open((e.Data.GetData(DataFormats.StringFormat)));
            else if (e.Data.GetDataPresent(DataFormats.Serializable))
                Open((e.Data.GetData(DataFormats.Serializable)));
            else if (e.Data.GetDataPresent(DataFormats.Bitmap))
                Open((e.Data.GetData(DataFormats.Bitmap)));
        }

    }
}
