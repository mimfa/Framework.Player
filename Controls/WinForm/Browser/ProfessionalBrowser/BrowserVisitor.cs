using CefSharp;
using MiMFa.General;

namespace MiMFa.Controls.WinForm.Browser
{
    public class BrowserVisitor : IStringVisitor
    {
        public event GenericEventListener<BrowserVisitor, string> DocumentCompleted = (o, e) => { };
        public void Dispose()
        {
        }

        public void Visit(string str)
        {
            DocumentCompleted(this, str);
        }
    }
}