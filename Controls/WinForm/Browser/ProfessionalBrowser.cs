using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MiMFa.Network;
using MiMFa.Model;
using MiMFa.Service;
using CefSharp;
using CefSharp.Core;
using MiMFa.General;
using CefSharp.WinForms;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using MiMFa.Engine.Web;
using System.ComponentModel.Design;
using CefSharp.DevTools.Page;
using CefSharp.Internals;
using MiMFa.Model.IO;
using MiMFa.Engine.Template;

namespace MiMFa.Controls.WinForm.Browser
{
    [DesignTimeVisible(true)]
    [Designer(typeof(System.Windows.Forms.Design.ControlDesigner), typeof(IDesigner))]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    [DefaultEvent("DocumentCompleted")]
    [DefaultProperty("Url")]
    public partial class ProfessionalBrowser : UserControl, ITemplateIgnorer, IPointerJSSupported, IWebBrowser<ProfessionalBrowser>
    {
        public ChromiumWebBrowser Browser => InitializeBrowser();
        private ChromiumWebBrowser _Browser = null;

        public event EventHandler Initialized = (o, e) => { };
        public event GenericEventListener<ProfessionalBrowser, string> Navigating = (o, e) => { };
        public event GenericEventListener<ProfessionalBrowser, string> Navigated = (o, e) => { };
        public event GenericEventListener<ProfessionalBrowser, string> TitleChanged = (o, e) => { };
        public event GenericEventListener<ProfessionalBrowser, string, int, object> DocumentCompleted = (o, e, i, a) => { };
        public event GenericEventHandler<ProfessionalBrowser, string, object, string> BeginDownload = (o, e, a) => "";
        public event GenericEventHandler<ProfessionalBrowser, string, int, string, object, bool> Downloading = (o, e, n, p, a) => true;
        public event GenericEventListener<ProfessionalBrowser, string, bool, string, object> FinishDownload = (o, e, p, b, a) => { };
        public event GenericEventListener<ProfessionalBrowser, string, object> ConsoleMessageReceived = (o, a, e) => { };
        public event GenericEventHandler<ProfessionalBrowser, string, bool> WindowCreated = (o, e) => true;
        public event GenericEventHandler<ProfessionalBrowser, string, bool> NewBackgroundWindow = (o, e) => true;
        public event GenericEventHandler<ProfessionalBrowser, string, bool> NewForegroundWindow = (o, e) => true;
        public event EventHandler StopClick = (o, e) => { };
        public event EventHandler ReloadClick = (o, e) => { };
        public event EventHandler NextClick = (o, e) => { };
        public event EventHandler BackClick = (o, e) => { };
        public event EventHandler HomeClick = (o, e) => { };
        public event EventHandler GoClick = (o, e) => { };
        public event KeyEventHandler AddressBarKeyDown = (o, e) => { };
        public event EventHandler DocumentMouseUp = (o, e) => { };
        public event EventHandler DocumentMouseDown = (o, e) => { };
        public event EventHandler DocumentMouseLeave = (o, e) => { };
        public event EventHandler DocumentMouseMove = (o, e) => { };
        public event EventHandler DocumentMouseOver = (o, e) => { };
        public event GenericEventListener<ProfessionalBrowser, string> DocumentSelected = (o, e) => { };
        public event EventHandler ContextMenuShowing = (o, e) => { };

        public bool OnNewWindow(string targetUrl)
        {
            return WindowCreated(this, targetUrl);
        }
        public bool OnNewBackgroundTab(string targetUrl)
        {
            return NewBackgroundWindow(this, targetUrl);
        }
        public bool OnNewForegroundTab(string targetUrl)
        {
            return NewForegroundWindow(this, targetUrl);
        }
        public void OnTitleChanged(string newTitle)
        {
            TitleChanged(this, DocumentTitle = newTitle);
        }
        public void OnNavigating(string uri)
        {
            Navigating(this, uri);
        }
        public void OnNavigating(Uri uri, string targetFrameName)
        {
            //ControlService.SetControlThreadSafe(StatusBox,a => StatusBox.Text = "Navigating...");
            OnNavigating(uri.OriginalString);
        }
        public void OnNavigated(string uri)
        {
            Navigated(this, uri);
        }
        public void OnNavigated(Uri uri)
        {
            OnNavigated(uri.OriginalString);
        }
        public void OnDocumentCompleted(FrameLoadEndEventArgs frameLoadEndArgs)
        {
            DocumentCompleted(this, frameLoadEndArgs.Url, frameLoadEndArgs.HttpStatusCode, frameLoadEndArgs);
        }
        public void OnDocumentCompleted(Uri uri, int status, object obj)
        {
            ExecuteDefaultScript();
            DocumentCompleted(this, uri==null?null: uri.OriginalString, status, obj);
        }
        public string OnBeginDownload(string url)
        {
            ControlService.SetControlThreadSafe(StatusBox, a => StatusBox.Text = "Downloading Started!");
            ControlService.SetControlThreadSafe(ProgressBar, a => ProgressBar.Value = 0);
            return BeginDownload(this, url, default(object));
        }
        public string OnBeginDownload(DownloadItem item)
        {
            ControlService.SetControlThreadSafe(StatusBox, a => StatusBox.Text = "Downloading Started!");
            ControlService.SetControlThreadSafe(ProgressBar, a => ProgressBar.Value = item.PercentComplete);
            return BeginDownload(this, item.OriginalUrl, item);
        }
        public bool OnDownloading(DownloadItem item)
        {
            if (item.IsInProgress) ControlService.SetControlThreadSafe(StatusBox, a => StatusBox.Text = "Downloading Process...");
            ControlService.SetControlThreadSafe(ProgressBar, a => ProgressBar.Value = item.PercentComplete);
            return Downloading(this, item.OriginalUrl, item.PercentComplete, item.FullPath, item);
        }
        public void OnFinishDownload(DownloadItem item)
        {
            if (item.IsCancelled) ControlService.SetControlThreadSafe(StatusBox, a => StatusBox.Text = "Download Canceled!");
            else if (item.IsComplete) ControlService.SetControlThreadSafe(StatusBox, a => StatusBox.Text = "Download Completed!");
            ControlService.SetControlThreadSafe(ProgressBar, a => ProgressBar.Value = 100);
            FinishDownload(this, item.OriginalUrl, item.IsComplete, item.FullPath, item);
            ControlService.SetControlThreadSafe(ProgressBar, a => ProgressBar.Value = 0);
        }
        public virtual void OnDocumentSelected(string text)
        {
            try { if (ContextMenuStrip.IsDropDown) ContextMenuStrip.Hide(); } catch { }
            DocumentSelected(this, text);
        }

        public BrowserVisitor Visitor = new BrowserVisitor();

        public virtual Uri Uri
        {
            get
            {
                return GetUri();
            }

            set
            {
                Navigate(value);
                //this.Browser.Url = base.URL = value;
            }
        }
        public virtual string Url
        {
            get
            {
                return GetUrl();
            }

            set
            {
                Navigate(value);
                //this.Browser.Url = base.URL = value;
            }
        }
        public virtual string BasetUrl { get; set; } = null;
        public virtual string DefaultUrl { get; set; } = "";
        public virtual HtmlAgilityPack.HtmlDocument Document { get => GetDocument(); set => LoadDocument(value); }
        public virtual IFrame Frame { get => _Frame ?? Browser.GetMainFrame(); set => _Frame = Frame; }
        IFrame _Frame { get; set; }
        public virtual string DocumentTitle { get; set; } = null;
        public virtual string DocumentText { get => GetDocumentText(2); set => LoadHTML(value); }
        public virtual bool HasDocument
        {
            get
            {
                return !string.IsNullOrEmpty(_DocumentText);
            }
        }
        private string _DocumentText = "";
        public virtual bool DocumentLoading { get; set; } = false;
        public virtual bool AllowNavigate { get => ControlsBar.Visible; set { ControlsBar.Visible = value; } }
        public virtual Point ScrollOffset { get => Browser.AutoScrollOffset; set => Browser.AutoScrollOffset = value; }
        public virtual int ScrollTop { get => AutoScrollOffset.Y; set => AutoScrollOffset = new Point(AutoScrollOffset.X, value); }
        public virtual int ScrollLeft { get => AutoScrollOffset.X; set => AutoScrollOffset = new Point(value, AutoScrollOffset.Y); }

        public string DefaultScript = "";
        public virtual int WaitingTime { get; set; } = 5000;
        public bool ShowScriptErrorMessage { get; set; } = false;
        public bool ReturnScriptMessage { get; set; } = true;
        public bool Selectable => Browser.CanSelect;
        public bool Focusable => Browser.CanFocus;
        public bool Nextable => Browser.CanGoForward;
        public bool Backable => Browser.CanGoBack;

        //public override Color BackColor
        //{
        //    get => Browser == null || Browser.BrowserSettings == null ? base.BackColor : Color.FromArgb((int)Browser.BrowserSettings.BackgroundColor);
        //    set
        //    {
        //        if (Browser == null || Browser.BrowserSettings == null)
        //            base.BackColor = value;
        //        else Browser.BackColor = value;
        //    }
        //}
        //public override Color ForeColor
        //{
        //    get => Browser == null ? base.ForeColor : Color.FromArgb(Browser.ForeColor.ToArgb());
        //    set
        //    {
        //        if (Browser == null)
        //            base.ForeColor = value;
        //        else Browser.ForeColor = value;
        //    }
        //}

        public ProfessionalBrowser()
        {
            InitializeComponent();

            this.MouseDown += (o, em) => DocumentMouseDown(o, em);
            this.MouseLeave += (o, em) => DocumentMouseLeave(o, em);
            this.MouseMove += (o, em) => DocumentMouseMove(o, em);
            this.MouseHover += (o, em) => DocumentMouseOver(o, em);
            this.MouseUp += (o, em) => OnDocumentSelected(GetSelected());
            this.MouseUp += (o, em) => DocumentMouseUp(o, em);
            this.ContextMenuChanged += (o, em) => ContextMenuShowing(o, em);
            this.GotFocus += (s, e) => RefreshColors();
            this.AddressBox.GotFocus += (s, e) => RefreshColors();

            MainMenu.Renderer = new Menu.ToolStripRender();
            Visitor.DocumentCompleted += Visitor_DocumentCompleted;
        }
        public ChromiumWebBrowser InitializeBrowser()
        {
            if ((_Browser == null || _Browser.IsDisposed || !MiMFa.UIL.Player.API.IsInitialized || MiMFa.UIL.Player.API.IsFinalized) && !Statement.IsDesignTime)
            {
                if (!MiMFa.UIL.Player.API.Initialize())
                    if (!MiMFa.UIL.Player.API.Initialize()
                        && DialogService.ShowMessage(MessageMode.Warning, "Could not initialize browser!" + Environment.NewLine + "Do you want to retry again?") == DialogResult.Yes)
                        return InitializeBrowser();
                _Browser = new ChromiumWebBrowser(string.Empty
                //new CefSharp.Web.HtmlString(
                //    "<HTML><BODY STYLE='WIDTH:100VW;HEIGHT:100VH;BACKGROUND-COLOR:rgb(" +
                //    string.Join(",", BackColor.R, BackColor.G, BackColor.B) + ");COLOR:rgb(" +
                //    string.Join(",", BackColor.R, BackColor.G, BackColor.B) + ");'></BODY></HtML>"
                //,false
                //)
                );

                // 
                // Browser
                // 
                _Browser.ActivateBrowserOnCreation = true;
                _Browser.Dock = System.Windows.Forms.DockStyle.Fill;
                _Browser.Name = "_Browser";
                _Browser.TabIndex = 1;
                _Browser.ContextMenuStrip = ContextMenuStrip ?? DefaultContextMenuStrip;
                _Browser.ContextMenuStrip.AutoClose = true;
                _Browser.DownloadHandler = new SimpleDownloadHandler(this);
                _Browser.LifeSpanHandler = new SimpleLifeSpanHandler(this);
                _Browser.MenuHandler = new ContextMenuStripHandler(_Browser.ContextMenuStrip);
                _Browser.AddressChanged += new System.EventHandler<CefSharp.AddressChangedEventArgs>(Browser_AddressChanged);
                _Browser.FrameLoadStart += new System.EventHandler<CefSharp.FrameLoadStartEventArgs>(Browser_FrameLoadStart);
                _Browser.FrameLoadEnd += new System.EventHandler<CefSharp.FrameLoadEndEventArgs>(Browser_FrameLoadEnd);
                _Browser.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(Browser_LoadingStateChanged);
                _Browser.ConsoleMessage += new System.EventHandler<CefSharp.ConsoleMessageEventArgs>(Browser_ConsoleMessage);
                _Browser.StatusMessage += new System.EventHandler<CefSharp.StatusMessageEventArgs>(Browser_StatusMessage);
                _Browser.IsBrowserInitializedChanged += new System.EventHandler(Browser_IsBrowserInitializedChanged);
                _Browser.TitleChanged += Browser_TitleChanged;
                try { Parent.ContextMenuStrip = _Browser.ContextMenuStrip; } catch { }
                try
                {
                    var bs = _Browser.BrowserSettings?? new CefSharp.BrowserSettings(!System.Diagnostics.Debugger.IsAttached);
                    bs.Javascript = CefState.Enabled;
                    bs.JavascriptAccessClipboard = CefState.Enabled;
                    bs.JavascriptDomPaste = CefState.Enabled;
                    bs.JavascriptCloseWindows = CefState.Enabled;
                    bs.WebGl = CefState.Enabled;
                    bs.BackgroundColor = (uint)Color.FromArgb(255, BackColor).ToArgb();
                    _Browser.BrowserSettings = bs;
                }
                catch { }

                this.Controls.Add(_Browser);
                _Browser.BringToFront();
                StatusBox.BringToFront();
                ControlsBar.SendToBack();
            }
            return _Browser;
        }

        public virtual string NavigateHome()
        {
            return Navigate(DefaultUrl);
        }
        public virtual string Navigate(string url)
        {
            Uri result = null;
            try { result = InternetService.CreateUri(url); } catch { }
            if (result != null && result.IsAbsoluteUri)
                return Navigate(result);
            else if (url == "")
                return Navigate(result = new Uri("https://www.google.com/search?q=" + url));
            //this.Browser.Url = result = new Uri("https://www.google.com/search?q=" + url);
            return null;
        }
        public virtual string Navigate(Uri url)
        {
            if (url == null) return null;

            //CefSharp.Cef.RefreshWebPlugins();
            try
            {
                if (Browser.IsBrowserInitialized) Browser.Load(BasetUrl = url.OriginalString);
                else
                {
                    MiMFa.UIL.Player.API.Initialize();
                    Browser.Load(BasetUrl = url.OriginalString);
                }
                ControlService.SetControlThreadSafe(this, a =>
                {
                    AddressBox.Text = BasetUrl;
                });
                return BasetUrl;
            }
            catch { }
            return null;
        }
        public virtual string NavigateAgain() => Navigate(BasetUrl);
        public virtual bool NavigateNext()
        {
            NextClick(this, EventArgs.Empty);
            this.Browser.Forward();
            UpdateBar();
            return this.Browser.CanGoForward;
        }
        public virtual bool NavigateBack()
        {
            NextClick(this, EventArgs.Empty);
            this.Browser.Back();
            UpdateBar();
            return this.Browser.CanGoBack;
        }
     
        public virtual void Reload()
        {
            if (Browser.IsBrowserInitialized) Browser.Reload();
            else
                try
                {
                    ///MiMFa.UIL.EverythingPlayer.API.Initialize();
                    Navigate(Url);
                }
                catch { }
            UpdateBar();
        }

        public virtual string LoadHTML(string html)
        {
            //this.Browser.LoadHtml(html,true);
            string path = Config.TemporaryDirectory + System.DateTime.Now.Ticks + ".html";
            try
            {
                System.IO.File.WriteAllText(path, html);
                this.Browser.Load(path);
            }
            catch {
                try { InitializeBrowser(); }
                catch
                {
                    try { Browser.Load(path); } catch { }
                }
            }
            return html;
        }
        public virtual string LoadObject(Exception ex)
        {
            return LoadHTML("<html><body style='color:red;padding:45% 5%;text-align: center;'>" + ex.Message + "</body></html>");
        }
        public virtual string LoadDocument(HtmlAgilityPack.HtmlDocument htmlElements)
        {
            return LoadHTML(htmlElements == null || htmlElements.DocumentNode == null ? "" : htmlElements.DocumentNode.OuterHtml);
        }
        public virtual string LoadElements(HtmlElementCollection htmlElements)
        {
            var html = new List<string>();
            foreach (HtmlElement item in htmlElements)
                html.Add(item.OuterHtml);
            return LoadHTML(string.Join(Environment.NewLine, html));
        }
        public virtual string LoadElements(IEnumerable<XMLElement> htmlElements)
        {
            return LoadHTML(XMLElement.GetOuter(htmlElements));
        }
        public virtual string Prepend(string html)
        {
            return ""+ExecuteScript("document.body.innerHTML = `" + html.Replace("`", "\\`") + "` + document.body.innerHTML;");
        }
        public virtual string Append(string html)
        {
            return "" + ExecuteScript("document.body.innerHTML += `" + html.Replace("`","\\`") + "`;");
        }

        public virtual ProfessionalBrowser GoToMainFrame()
        {
            _Frame = Browser.GetMainFrame();
            return this;
        }
        public virtual ProfessionalBrowser GoToParentFrame()
        {
            _Frame = Frame.Parent ?? Browser.GetMainFrame();
            return this;
        }
        public virtual ProfessionalBrowser GoToFrame(int index)
        {
            GetPointerJS("//iframe[" + (index + 1) + "]", PointerMode.XPath).Focus().Perform();
            _Frame = Browser.GetFocusedFrame();
            return this;
        }



        public virtual void ExecuteDefaultScript()
        {
            try
            {
                Browser.ExecuteScriptAsyncWhenPageLoaded(@"
                document.body.onmouseup += function(){
                    console.log('--window--OnDocumentSelected--'+window.getSelection().toString().replaceAll('-','{-}'));
                }");
            }
            catch { }
            if (!string.IsNullOrWhiteSpace(DefaultScript))
                try
                {
                    Browser.ExecuteScriptAsyncWhenPageLoaded(DefaultScript);
                }
                catch { }
        }
        public virtual object ExecuteScript(string script, params object[] args)
        {
            object result = null;
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, WaitingTime);
            if (Browser.IsBrowserInitialized && Browser.CanExecuteJavascriptInMainFrame)
                    using (Task<JavascriptResponse> r = args.Length == 0 ?
                                            Frame.EvaluateScriptAsync(script,Frame.Url,1, ts) :
                                            Browser.EvaluateScriptAsync(ts, script, args))
                        {
                            result = GetResult(r);
                        }
            return result;
        }
        public object ExecuteScript(string script, IEnumerable<object> args) => ExecuteScript(script, args.ToArray());
        public object ExecuteScript(PointerJS element, params object[] args) => ExecuteScript(element.ToString(), args.ToArray());
        public object ExecuteScript(PointerJS element, IEnumerable<object> args) => ExecuteScript(element.ToString(), args.ToArray());
        public virtual object GetResult(Task<JavascriptResponse> r)
        {
            object result=null;
            try {
                result =
                   r == null || r.Result == null ? null
                   : r.Result.Result ?? (ReturnScriptMessage ? r.Result.Message : null);
            } catch (Exception ex)
            {
                if (ShowScriptErrorMessage) DialogService.ShowMessage(ex);
                else if (ReturnScriptMessage && result == null) result = ex;
            }
            return result;
        } 

        public virtual PointerJS GetPointerJS()=> new PointerJS((s, a) => ExecuteScript(s, a.ToArray()));
        public virtual PointerJS GetPointerJS(string pointer, PointerMode pointerType) => new PointerJS(pointer, (s, a) => ExecuteScript(s, a.ToArray()), pointerType);
        public virtual PointerJS GetPointerJS(long x, long y) => new PointerJS(x, y, (s, a) => ExecuteScript(s, a.ToArray()));
        public virtual PointerJS GetPointerJS(Point location)=> GetPointerJS(location.X, location.Y);
        public virtual PointerJS GetPointerJS(string query = "html") => GetPointerJS(query, PointerMode.Query);

        public virtual void RefreshColors()
        {
            try
            {
                AddressBox.BackColor = ScreenService.ColorAt(AddressBarClearButton.PointToScreen(new Point(3, 3)), ScreenScope.Window);
                AddressBox.ForeColor = ForeColor;
            }
            catch { }
        }

        public virtual void Close()
        {
           //MiMFa.Windows.EverythingPlayer.API.Finalize();
        }
        public virtual void Clear()
        {
        }

        public virtual string GetDocumentText(int seconds = 5)
        {
            try
            {
                var ts = Browser.GetSourceAsync();
                //string res = ts.ContinueWith(v=>v.Result).Result;
                ts.Wait(new TimeSpan(0, 0, seconds));
                if (ts.IsCompleted && !string.IsNullOrEmpty(ts.Result))
                    return ts.Result;
            }
            catch { }
            return _DocumentText;
        }
        public virtual HtmlAgilityPack.HtmlDocument GetDocument()
        {
            return ConvertService.ToHtmlDocument(GetDocumentText(3));
        }
        public virtual string GetSelected(bool html = false)
        {
            try
            {
                Browser.Copy();
                return Clipboard.GetText();
            }
            catch { return null; }
        }

        public virtual Uri GetUri()
        {
            try
            {
                var url = GetUrl();
                if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                    return new Uri(url);
            }
            catch { }
            return null;
        }
        public virtual string GetUrl()
        {
            return this.Browser.Address;
        }


        public virtual void UpdateBar()
        {
            ControlService.SetControlThreadSafe(this, a =>
            {
                var url = GetUrl();
                if (url != null) AddressBox.Text = url;
                NextButton.Enabled = this.Browser.CanGoForward;
                BackButton.Enabled = this.Browser.CanGoBack;
            });
            forwardToolStripMenuItem.Enabled = this.Browser.CanGoForward;
            backToolStripMenuItem.Enabled = this.Browser.CanGoBack;
        }


        public virtual string Open()
        {
            string path = DialogService.OpenFile();
            try
            {
                if (string.IsNullOrWhiteSpace(path)) Navigate(path);
                return path;
            }
            catch { }
            return null;
        }
        public virtual string Open(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return Open();
            try
            {
                if (string.IsNullOrWhiteSpace(path)) Navigate(path);
                return path;
            }
            catch { }
            return null;
        }
        public string Save(string path)
        {
            return SaveAs(path);
        }
        public virtual string SaveAs()
        {
            var filter = "Hyper Text Markup Language Files (*.htm, *.html)|*.htm; *.html|Portable Document Format Files (*.pdf)|*.pdf";
            bool hasTable = GetPointerJS("//table[contains(@class,'table')]",PointerMode.XPath).IsExists().TryPerform(false);
            if (hasTable) filter += "|Comma Separated Values Files (*.csv)|*.csv|Tab Separated Values Files (*.tsv, *.txt)|*.tsv;*.txt|Microsoft Excel Files (*.xls, *.xlsx)|*.xlsx;*.xls";
            string path = DialogService.SaveFile(DocumentTitle,filter);
            if (string.IsNullOrWhiteSpace(path)) return null;
            switch(DialogService.SFD.FilterIndex)
            {
                case 2:
                    SaveAsPDF(path);
                    break;
                case 3:
                    SaveAsChainedFile(path, ",");
                    break;
                case 4:
                    SaveAsChainedFile(path, "\t");
                    break;
                case 5:
                    SaveAsExcel(path);
                    break;
                default:
                    SaveAsHTML(path);
                    break;
            }
            return path;
        }
        public virtual string SaveAs(string path = null)
        {
            if (string.IsNullOrWhiteSpace(path)) return SaveAs();
            else SaveAsHTML(path);
            return path;
        }
        public virtual bool SaveAsHTML(string path)
        {
            bool done = false;
            if (!string.IsNullOrWhiteSpace(path))
                ProcessService.RunDialog("Wait to save the \"" + Path.GetFileName(path)+"\"", (a, e) =>
                {
                    try
                    {
                        File.WriteAllText(path, DocumentText);
                        done = true;
                    }
                    catch (Exception ex) { DialogService.ShowMessage(ex); }
                });
            return done;
        }
        public virtual bool SaveAsPDF(string path)
        {
            bool done = false;
            if (!string.IsNullOrWhiteSpace(path))
                ProcessService.RunDialog("Wait to save the \"" + Path.GetFileName(path) + "\"", (a, e) =>
                {
                    try
                    {
                        done = ProcessService.TaskHandler(Browser.PrintToPdfAsync(path));
                    }
                    catch (Exception ex) { DialogService.ShowMessage(ex); }
                });
            return done;
        }
        public virtual bool SaveAsExcel(string path)
        {
            bool done = false;
            if (!string.IsNullOrWhiteSpace(path))
                ProcessService.RunDialog("Wait to save the \"" + Path.GetFileName(path)+ "\"", (a, e) =>
                {
                    try
                    {
                        ConvertService.ToExcelFile(GetDataSet(), path,false,true);
                        done = true;
                    }
                    catch (Exception ex) { DialogService.ShowMessage(ex); }
            });
            return done;
        }
        public virtual bool SaveAsChainedFile(string path, string warpsSeparator = "\t", string linesSeparator="\r\n")
        {
            bool done = false;
            if (!string.IsNullOrWhiteSpace(path))
                ProcessService.RunDialog("Wait to save the \"" + Path.GetFileName(path) + "\"", (a, e) =>
                {
                    try
                    {
                        var cf = new ChainedFile(path, GetDataSet(), warpsSeparator, linesSeparator);
                        cf.Save();
                        done = true;
                    }
                    catch (Exception ex) { DialogService.ShowMessage(ex); }
                });

            return done;
        }
        public virtual DataSet GetDataSet()
        {
            try
            {
                var ds = new DataSet(DocumentTitle);
                ds.Tables.AddRange(GetDataTables().ToArray());
                return ds;
            }
            catch(Exception ex) { }
            return null;
        }
        public virtual IEnumerable<DataTable> GetDataTables()
        {
            //foreach (var item in GetPointerJS("//table[contains(@class,'TABLE')]", PointerMode.XPath).All().TryPerform(new List<object>()))
            foreach (var item in Document.DocumentNode.SelectNodes("//table[contains(@class,'table')]"))
            {
                var dt = new DataTable();
                foreach (var col in item.SelectNodes("tbody/tr | tr") ?? new HtmlAgilityPack.HtmlNodeCollection(item))
                {
                    List<object> lo = (from v in col.SelectNodes("th | td") ?? new HtmlAgilityPack.HtmlNodeCollection(col) select (object)(v.InnerText + "")).ToList();
                    while (lo.Count >= dt.Columns.Count)
                        dt.Columns.Add();
                    dt.Rows.Add(lo.ToArray());
                }
                yield return dt;
            }
        }

        public virtual void Print()
        {
            Browser.Print();
        }
        public virtual void ShowPrintDialog()
        {
            Browser.Print();
        }
        public virtual void ShowPrintPreviewDialog()
        {
            Browser.Print();
        }
        public virtual void ShowPageSetupDialog()
        {
            Browser.Print();
        }
        public virtual void ShowSource()
        {
            ProcessService.Show(DocumentText,Url);
        }



        private void ProfessionalBrowser_Load(object sender, EventArgs e)
        {
            RefreshColors();
            StatusBox.MaximumSize = new Size(Width / 2,0);
        }

        private void pb_Close_Click(object sender, EventArgs e)
        {
            ControlService.SetControlThreadSafe(AddressBox, a=> AddressBox.Clear());
        }
        private void Go_Click(object sender, EventArgs e)
        {
            GoClick(sender, e);
            Navigate(AddressBox.Text);
        }
        private void tsb_Home_Click(object sender, EventArgs e)
        {
            HomeClick(sender, e);
            NavigateHome();
        }
        private void tsb_Next_Click(object sender, EventArgs e)
        {
            NavigateNext();
        }
        private void tsb_Back_Click(object sender, EventArgs e)
        {
           NavigateBack();
        }
        private void tsb_Refresh_Click(object sender, EventArgs e)
        {
            ReloadClick(this,e);
            Reload();
        }
        private void tsb_Stop_Click(object sender, EventArgs e)
        {
            StopClick(sender, e);
            this.Browser.Stop();
        }

        private void tb_AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if ((AddressBox.Text.Split('.')).Length < 2)
                        if (e.Control) try { AddressBox.Text = InternetService.CreateUri(AddressBox.Text + ".com").AbsoluteUri; }catch{ }
                        else AddressBox.Text = "https://www.google.com/search?q=" + AddressBox.Text;
                    Navigate(AddressBox.Text);
                    break;
                case Keys.Escape:
                    AddressBox.Clear();
                    break;
                default:
                    RefreshColors();
                    break;
            }
        }

        private void DocumentCompletion(IFrame frame)
        {
            frame.GetSource(Visitor);
            DocumentLoading = false;
            //DocumentLoading = true;
            ProgressBar.Value = 0;
        }
        private void Visitor_DocumentCompleted(BrowserVisitor sender, string arg)
        {
            DocumentLoading = false;
            _DocumentText = arg;
            OnDocumentCompleted(Uri,0,null);
        }
        private void Browser_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            Initialized(this, e);
            RefreshColors();
        }
        private void Browser_AddressChanged(object sender, CefSharp.AddressChangedEventArgs e)
        {
            ControlService.SetControlThreadSafe(this, a =>
            {
                AddressBox.Text = Url;
            });
        }
        private void Browser_TitleChanged(object sender, CefSharp.TitleChangedEventArgs e)
        {
            OnTitleChanged(e.Title);
        }
        private void Browser_LoadingStateChanged(object sender, CefSharp.LoadingStateChangedEventArgs e)
        {
            var url = GetUri();
            if (url == null) return;
            if (e.IsLoading)
            {
                stopToolStripMenuItem.Enabled = true;
                ControlService.SetControlThreadSafe(this, a =>
                {
                    StopButton.Visible =
                    ProgressView.Visible =
                    StopButton.Enabled = true;
                });
                OnNavigating(url, Text);
            }
            else
            {
                UpdateBar();
                OnNavigated(url);
                ControlService.SetControlThreadSafe(this, a =>
                    stopToolStripMenuItem.Enabled =
                    StopButton.Visible =
                    ProgressView.Visible =
                    StopButton.Enabled = false);
                //if (e.Browser.HasDocument && e.Browser != null && !e.Browser.IsDisposed && !e.Browser.IsLoading && e.Browser.MainFrame != null && !DocumentLoading)
                    //if (_DocumentText == "")
                    //    DocumentCompletion(e.Browser.MainFrame);
                    //else
                    //if (string.IsNullOrWhiteSpace(_DocumentText))
                    //        _DocumentText = ""; 
                if (string.IsNullOrWhiteSpace(_DocumentText) && !e.Browser.IsDisposed) ProcessService.RunThread((() => DocumentCompletion(e.Browser.MainFrame)));
            }
        }
        private void Browser_FrameLoadStart(object sender, CefSharp.FrameLoadStartEventArgs e)
        {
            var st = e.TransitionType + "";
            if (st == "Explicit, DirectLoad"|| st == "AutoSubFrame" || st == "Reload" || st== "FormSubmit")
            {
                DocumentLoading = false;
                _DocumentText = null;
            }
            else DocumentLoading = false;
        }
        private void Browser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            if (!e.Browser.IsLoading && e.Browser.MainFrame != null && !DocumentLoading)
            {//if (_DocumentText == "")
                //    DocumentCompletion(e.Browser.MainFrame);
                //else
                //if (string.IsNullOrWhiteSpace(_DocumentText))
                //    _DocumentText = "";
                if (string.IsNullOrWhiteSpace(_DocumentText) && !e.Browser.IsDisposed)
                    ProcessService.RunThread((() => DocumentCompletion(e.Browser.MainFrame)));
            }
        }
        private void Browser_StatusMessage(object sender, CefSharp.StatusMessageEventArgs e)
        {
            ControlService.SetControlThreadSafe(StatusBox,a => StatusBox.Text = e.Value);
        }
        private void Browser_ConsoleMessage(object sender, CefSharp.ConsoleMessageEventArgs e)
        {
            if (e.Message.StartsWith("--"))
            {
                var sta = e.Message.Split(new string[] { "--" },StringSplitOptions.None);
                object o = null;
                if (sta.Length > 2)
                    try
                    {
                        switch (sta[1])
                        {
                            case "browser":
                                o = Browser;
                                break;
                            default:
                            case "window":
                                o = this;
                                break;
                        }
                        o.GetType().GetMethod(sta[2]).Invoke(o, (from v in sta.Skip(3) select (object)v.Replace("{-}", "-")).ToArray());
                        return;
                    }
                    catch { }
            }
            ConsoleMessageReceived(this,e.Message,e);
        }
        private void Browser_JavascriptMessageReceived(object sender, CefSharp.JavascriptMessageReceivedEventArgs e)
        {
        }

        private void ProfessionalBrowser_BackColorChanged(object sender, EventArgs e)
        {
            RefreshColors();
        }
        private void ProfessionalBrowser_ForeColorChanged(object sender, EventArgs e)
        {
            RefreshColors();
        }

        // Will attempt to load missing assembly from either x86 or x64 subdir
        public static Assembly AssemblyResolver(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("CefSharp.Core.Runtime"))
            {
                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                       Environment.Is64BitProcess ? "x64" : "x86",
                                                       assemblyName);
                return File.Exists(archSpecificPath)
                           ? System.Reflection.Assembly.LoadFile(archSpecificPath)
                           : null;
            }

            return null;
        }

        public System.Net.CookieContainer GetCookieContainer(params string[] targets)
        {
            var lc = GetCookies(targets, 2);
            if (lc == null) return null;
            var cs = new System.Net.CookieContainer();
            foreach (var c in lc)
                cs.Add(new System.Net.Cookie(c.Name,c.Value,c.Path,c.Domain));
            return cs;
        }
        public System.Net.CookieContainer GetCookieContainer(string[] targets, int secondsLimit)
        {
            var lc = GetCookies(targets, secondsLimit);
            if (lc == null) return null;
            var cs = new System.Net.CookieContainer();
            foreach (var c in lc)
                cs.Add(new System.Net.Cookie(c.Name, c.Value, c.Path, c.Domain));
            return cs;
        }
        public List<Cookie> GetCookies(params string[] targets)
        {
            return GetCookies(targets,2);
        }
        public List<Cookie> GetCookies(string[] targets, int secondsLimit)
        {
            List<Cookie> lc = new List<Cookie>();
            foreach (var target in targets)
            {
                var visitor = GetCookiesAsync(target);
                if (visitor.Wait(new TimeSpan(0, 0, secondsLimit*2)))
                    lc.AddRange(visitor.Result);
            }
            return lc.Count == 0? null: lc;
        }
        public async Task<List<Cookie>> GetCookiesAsync(string target)
        {
            var cookieManager = CefSharp.Cef.GetGlobalCookieManager();
            var visitor = new CookiesVisitor();

            cookieManager.VisitUrlCookies(target, true, visitor);

            return await visitor.Task;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPrintDialog();
        }
        private void viewSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSource();
        }
        private void AddressBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
