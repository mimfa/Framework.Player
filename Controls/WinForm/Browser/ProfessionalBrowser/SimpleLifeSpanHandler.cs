using CefSharp;

namespace MiMFa.Controls.WinForm.Browser
{
    public class SimpleLifeSpanHandler : ILifeSpanHandler
    {
        ProfessionalBrowser Browser = null;
        public SimpleLifeSpanHandler(ProfessionalBrowser browser)
        {
            Browser = browser;
        }
        public void OnBeforeClose(IWebBrowser browser)
        {

        }

        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser,
            IBrowser browser,
            IFrame frame,
            string targetUrl,
            string targetFrameName,
            WindowOpenDisposition targetDisposition,
            bool userGesture,
            IPopupFeatures popupFeatures,
            IWindowInfo windowInfo,
            IBrowserSettings browserSettings,
            ref bool noJavascriptAccess,
            out IWebBrowser newBrowser)
        {
            bool allow = true;
            switch (targetDisposition)
            {
                case WindowOpenDisposition.SaveToDisk:
                    allow = Browser.OnBeginDownload(targetUrl) != null;
                    break;
                case WindowOpenDisposition.NewBackgroundTab:
                    if (allow = Browser.OnNewBackgroundTab(targetUrl)) Browser.Navigate(targetUrl);
                    break;
                case WindowOpenDisposition.NewForegroundTab:
                    if (allow = Browser.OnNewForegroundTab(targetUrl)) Browser.Navigate(targetUrl);
                    break;
                default:
                    if (allow = Browser.OnNewWindow(targetUrl)) Browser.Navigate(targetUrl);
                    break;
            }
            newBrowser = null;
            return allow;
        }

        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
        }

        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            return true;
        }

        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
        }
    }

}