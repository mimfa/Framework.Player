using CefSharp;

namespace MiMFa.Controls.WinForm.Browser
{
    internal class SimpleLoadHandler : ILoadHandler
    {
        ProfessionalBrowser Browser = null;

        public SimpleLoadHandler(ProfessionalBrowser browser)
        {
            Browser = browser;
        }

        void ILoadHandler.OnFrameLoadEnd(IWebBrowser chromiumWebBrowser, FrameLoadEndEventArgs frameLoadEndArgs)
        {
        }

        void ILoadHandler.OnFrameLoadStart(IWebBrowser chromiumWebBrowser, FrameLoadStartEventArgs frameLoadStartArgs)
        {
        }

        void ILoadHandler.OnLoadError(IWebBrowser chromiumWebBrowser, LoadErrorEventArgs loadErrorArgs)
        {
        }

        void ILoadHandler.OnLoadingStateChange(IWebBrowser chromiumWebBrowser, LoadingStateChangedEventArgs loadingStateChangedArgs)
        {
        }
    }
}