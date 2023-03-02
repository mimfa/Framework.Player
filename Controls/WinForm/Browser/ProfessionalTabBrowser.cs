using MiMFa.Controls.WinForm.Tab;
using MiMFa.Engine.Web;
using MiMFa.General;
using MiMFa.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiMFa.Controls.WinForm.Browser
{
    [DesignTimeVisible(true)]
    [Designer(typeof(System.Windows.Forms.Design.ControlDesigner), typeof(IDesigner))]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    [DefaultEvent("DocumentCompleted")]
    [DefaultProperty("DefaultUrl")]
    public partial class ProfessionalTabBrowser : UserControl,IPointerJSSupported, ITabWebBrowser<ProfessionalBrowser>
    {
        public event EventHandler Initialized = (o, e) => { };
        public event GenericEventListener<ProfessionalBrowser, string> Navigating = (o, e) => { };
        public event GenericEventListener<ProfessionalBrowser, string> Navigated = (o, e) => { };
        public event GenericEventListener<ProfessionalBrowser, string> TitleChanged = (o, e) => { };
        public event GenericEventListener<ProfessionalBrowser, string, int, object> DocumentCompleted = (o, e, i, a) => { };
        public event GenericEventHandler<ProfessionalBrowser, string, object, string> BeginDownload = (o, e, a) => "";
        public event GenericEventHandler<ProfessionalBrowser, string, int, string, object, bool> Downloading = (o, e, n, p, a) => true;
        public event GenericEventListener<ProfessionalBrowser, string, bool, string, object> FinishDownload = (o, e, p, b, a) => { };
        public event GenericEventListener<ProfessionalBrowser, string, object> ConsoleMessageReceived = (o, a, e) => { };
        public event GenericEventHandler<ProfessionalBrowser, string, bool> TabCreated = (o, e) => true;
        public event GenericEventHandler<ProfessionalBrowser, string, bool> NewBackgroundTab = (o, e) => true;
        public event GenericEventHandler<ProfessionalBrowser, string, bool> NewForegroundTab = (o, e) => true;
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

        public ProfessionalBrowser this[int index]
        {
            get => Tabs.ElementAtOrDefault(index);
        }

        public string DefaultUrl { get; set; } = Config.URL;
        public int DefaultWaitingTime { get; set; } = 5000;
        public bool AllowNavigate { get; set; } = true;

        public TabBarItem[] TabItems { get => TabBar.Tabs; set => TabBar.Tabs = value; }
        [Browsable(false)]
        public TabBarItem CurrentTabItem { get => TabBar.CurrentTab; set => TabBar.CurrentTab = value; }
        [Browsable(false)]
        public IEnumerable<ProfessionalBrowser> Tabs => from v in TabItems select GetTab(v);
        [Browsable(false)]
        public ProfessionalBrowser CurrentTab => (GetTab(CurrentTabItem) ?? NewTab());
        

        public ProfessionalTabBrowser()
        {
            InitializeComponent();
        }



        public ProfessionalBrowser Navigate(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) url = "about:blank";
            ControlService.SetControlThreadSafe(CurrentTab,()=> CurrentTab.Navigate(url));
            return CurrentTab;
        }
        public ProfessionalBrowser Navigate(Uri uri)
        {
            ControlService.SetControlThreadSafe(CurrentTab,()=> CurrentTab.Navigate(uri));
            return CurrentTab;
        }
        public ProfessionalBrowser NavigateAgain()
        {
            ControlService.SetControlThreadSafe(CurrentTab,()=> CurrentTab.NavigateAgain());
            return CurrentTab;
        }
        public ProfessionalBrowser NavigateBack()
        {
            ControlService.SetControlThreadSafe(CurrentTab,()=> CurrentTab.NavigateBack());
           return CurrentTab;
        }
        public ProfessionalBrowser NavigateNext()
        {
            ControlService.SetControlThreadSafe(CurrentTab, () => CurrentTab.NavigateNext());
            return CurrentTab;
        }
        public ProfessionalBrowser Reload()
        {
            ControlService.SetControlThreadSafe(CurrentTab, () => CurrentTab.Reload());
            return CurrentTab;
        }

        public ProfessionalBrowser[] NewTab(int number)
        {
            return Statement.Loop(number,()=> NewTab(false)).ToArray();
        }
        public ProfessionalBrowser NewTab() => NewTab(true);
        public ProfessionalBrowser NewTab(bool activeToo)
        {
            var tab = TabBar.NewTab("New Tab", (Func<TabBarItem, Control>)((t) =>
            {
                var b = new ProfessionalBrowser();
                b.Dock = DockStyle.Fill;
                b.AllowNavigate = AllowNavigate;
                b.WaitingTime = DefaultWaitingTime;
                b.DefaultUrl = DefaultUrl;
                b.Initialized += Initialized;
                b.Navigating += Navigating;
                b.Navigated += Navigated;
                b.TitleChanged += TitleChanged;
                b.TitleChanged += (o, v) => ControlService.SetControlThreadSafe(t, a => t.Text = v);
                b.DocumentCompleted += DocumentCompleted;
                b.BeginDownload += BeginDownload;
                b.Downloading += Downloading;
                b.FinishDownload += FinishDownload;
                b.ConsoleMessageReceived += ConsoleMessageReceived;
                b.WindowCreated += (o, a) => { return true; };
                b.WindowCreated += TabCreated;
                b.NewBackgroundWindow += (o, a) => { NewTab(false).Navigate(a); return false; };
                b.NewBackgroundWindow += NewBackgroundTab;
                b.NewForegroundWindow += (o, a) => { NewTab(true).Navigate(a); return false; };
                b.NewForegroundWindow += NewForegroundTab;
                b.StopClick += StopClick;
                b.ReloadClick += ReloadClick;
                b.NextClick += NextClick;
                b.BackClick += BackClick;
                b.HomeClick += HomeClick;
                b.GoClick += GoClick;
                b.AddressBarKeyDown += AddressBarKeyDown;
                b.DocumentMouseUp += DocumentMouseUp;
                b.DocumentMouseDown += DocumentMouseDown;
                b.DocumentMouseLeave += DocumentMouseLeave;
                b.DocumentMouseMove += DocumentMouseMove;
                b.DocumentMouseOver += DocumentMouseOver;
                b.DocumentSelected += DocumentSelected;
                b.ContextMenuShowing += ContextMenuShowing;
                return b;
            }));
            if(activeToo)tab.Active();
            return GetTab(tab);
        }
        public ProfessionalBrowser GoToTab(int index)
        {
            return GetTab(TabBar.GoToTab(index));
        }
        public ProfessionalBrowser GoToTab(string windowName)
        {
            return GetTab(TabBar.GoToTab(windowName));
        }
        public ProfessionalBrowser GoToFirstTab()
        {
            return GetTab(TabBar.GoToTab(0));
        }
        public ProfessionalBrowser GoToLastTab()
        {
            return GetTab(TabBar.GoToTab(TabBar.Tabs.Length - 1));
        }
        public ProfessionalBrowser GoToMainFrame()
        {
            CurrentTab.GoToMainFrame();
            return CurrentTab;
        }
        public ProfessionalBrowser GoToParentFrame()
        {
            CurrentTab.GoToParentFrame();
            return CurrentTab;
        }
        public ProfessionalBrowser GoToFrame(int index)
        {
            CurrentTab.GoToFrame(index);
            return CurrentTab;
        }

        private ProfessionalBrowser GetTab(TabBarItem tabBarItem)
        {
            return tabBarItem==null?null:(ProfessionalBrowser)tabBarItem.RelatedControl;
        }

        public ProfessionalBrowser[] Open(params string[] args)
        {
            return (from item in args select Open(item)).ToArray();
        }
        public ProfessionalBrowser Open(string arg)
        {
            NewTab();
            return Navigate(arg);
        }
        public ProfessionalBrowser Print()
        {
            ControlService.SetControlThreadSafe(CurrentTab, () =>  CurrentTab.Print());
            return CurrentTab;
        }
        public ProfessionalBrowser Save(string path)
        {
            ControlService.SetControlThreadSafe(CurrentTab, () => path = CurrentTab.SaveAs(path));
            return CurrentTab;
        }
        public string Save()
        {
            string path = null;
            ControlService.SetControlThreadSafe(CurrentTab, () => path = CurrentTab.SaveAs(path));
            return path;
        }
        /// <summary>
        /// Close Current Tab
        /// </summary>
        /// <returns></returns>
        public ProfessionalBrowser CloseTab()
        {
            try
            {
                TabBar.CloseTab();
                GoToLastTab();
            }
            catch { GoToFirstTab(); }
            return CurrentTab;
        }
        public ProfessionalBrowser CloseTab(int index)
        {
            GoToTab(index);
            return CloseTab();
        }
        public ProfessionalBrowser CloseTab(string tabName)
        {
            GoToTab(tabName);
            return CloseTab();
        }
        /// <summary>
        /// Close All Tabs
        /// </summary>
        /// <returns></returns>
        public ProfessionalBrowser CloseAllTabs()
        {
            TabBar.CloseAllTabs();
            return CurrentTab;
        }


        public virtual PointerJS GetPointerJS() => CurrentTab.GetPointerJS();
        public virtual PointerJS GetPointerJS(string pointer, PointerMode pointerType) => CurrentTab.GetPointerJS(pointer, pointerType);
        public virtual PointerJS GetPointerJS(long x, long y) => CurrentTab.GetPointerJS(x, y);
        public virtual PointerJS GetPointerJS(Point location) => CurrentTab.GetPointerJS(location.X, location.Y);
        public virtual PointerJS GetPointerJS(string query = "html") => CurrentTab.GetPointerJS(query);

        public static explicit operator ProfessionalBrowser(ProfessionalTabBrowser ptb) => ptb.CurrentTab;
    }
}
