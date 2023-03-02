using CefSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMFa.Controls.WinForm.Browser
{
    public class CookiesVisitor : ICookieVisitor
    {
        private readonly List<Cookie> cookies = new List<Cookie>();
        private readonly TaskCompletionSource<List<Cookie>> source = new TaskCompletionSource<List<Cookie>>();
        public void Dispose() { }

        public bool Visit(Cookie cookie, int count, int total, ref bool deleteCookie)
        {
            cookies.Add(cookie);

            if (count == (total - 1)) source.SetResult(cookies);

            return true;
        }

        public Task<List<Cookie>> Task => source.Task;

        public static string GetCookieHeader(List<Cookie> cookies) =>
            string.Join("; ", from cookie in cookies select string.Join("=", cookie.Name, cookie.Value));

    }
}