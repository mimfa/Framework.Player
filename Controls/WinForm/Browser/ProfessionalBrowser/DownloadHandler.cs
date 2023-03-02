using CefSharp;
using MiMFa.Service;
using System;

namespace MiMFa.Controls.WinForm.Browser
{
    public class SimpleDownloadHandler : IDownloadHandler
    {
        ProfessionalBrowser Browser = null;
        public SimpleDownloadHandler(ProfessionalBrowser browser)
        {
            Browser = browser;
        }

        public bool CanDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, string url, string requestMethod)
        {
            if (DialogService.Question("Do you want to download the file '" + url + "'?"))
                return true;
            return false;
        }

        void IDownloadHandler.OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            var path = Browser.OnBeginDownload(downloadItem);
            if (path != null) callback.Continue(path,string.IsNullOrWhiteSpace(path));
        }

        void IDownloadHandler.OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            if (downloadItem.IsComplete || downloadItem.IsCancelled)
                Browser.OnFinishDownload(downloadItem);
            else
                if (!Browser.OnDownloading(downloadItem)) callback.Cancel();
        }
    }
}