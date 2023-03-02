using CefSharp;
using System.Drawing;
using System.Windows.Forms;

namespace MiMFa.Controls.WinForm.Browser
{
    public class ContextMenuStripHandler : IContextMenuHandler
    {
        ContextMenuStrip ContextMenuStrip;
        public ContextMenuStripHandler(ContextMenuStrip cms)
        {
            ContextMenuStrip = cms;
        }

        public void OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            try
            {
                MiMFa.Service.ControlService.SetControlThreadSafe(ContextMenuStrip, () => ContextMenuStrip.Show(Cursor.Position));
                //MiMFa.Service.ControlService.SetControlThreadSafe(ContextMenuStrip, () => ContextMenuStrip.Show(parameters.XCoord, parameters.YCoord));
            }
            catch (System.Exception ex)
            {
                try
                {
                    MiMFa.Service.ControlService.SetControlThreadSafe(ContextMenuStrip, () => ContextMenuStrip.Show(Cursor.Position));
                    //var c = (Control)chromiumWebBrowser;
                    //MiMFa.Service.ControlService.SetControlThreadSafe(ContextMenuStrip, () => ContextMenuStrip.Show(c, c.Location.X + c.Width / 2, c.Location.Y + c.Height / 2));
                }
                catch { }
            }
        }

        public bool OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            return true;
        }

        public void OnContextMenuDismissed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
        {
            try { if(ContextMenuStrip.IsDropDown) ContextMenuStrip.Hide(); } catch { }
        }

        public bool RunContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return true;
        }
    }

}