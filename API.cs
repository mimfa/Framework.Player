using MiMFa.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiMFa.UIL.Player
{
    public static class API
    {
        public static bool IsInitialized = false;
        public static string CacheDirectory {get;set;} = Path.Combine(MiMFa.Config.ApplicationDataDirectory, Path.Combine("Cache", "ProfessionalBrowser"));

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Initialize()
        {
            Config.Initial();
            if (IsInitialized && CefSharp.Cef.IsInitialized) return IsInitialized = true;
            else
                try
                {
                    AppDomain.CurrentDomain.AssemblyResolve += MiMFa.Controls.WinForm.Browser.ProfessionalBrowser.AssemblyResolver;

                    if (!Directory.Exists(CacheDirectory)) Directory.CreateDirectory(CacheDirectory);

                    var settings = new CefSharp.WinForms.CefSettings()
                    {
                        //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                        CachePath = CacheDirectory,
                        CommandLineArgsDisabled = false,
                        CefCommandLineArgs = { "enable-print-preview", string.Empty }
                    };
                    if (CefSharp.Cef.Initialize(settings) || !Environment.GetCommandLineArgs().Contains("--type=renderer"))
                    {
                        IsFinalized = false;
                        return IsInitialized = true;
                    }
                }
                catch(Exception ex) { DialogService.Error(ex); }
            if (IsInitialized) return IsInitialized;
            return IsInitialized = false;
        }
        public static bool IsFinalized = false;
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Finalize()
        {
            if (IsFinalized) return IsFinalized;
            Config.Final();
            try { CefSharp.Cef.Shutdown(); } catch { }
            try { PathService.DeleteAllFilesInDirectory(CacheDirectory); } catch { }
            IsInitialized = false;
            return IsFinalized = true;
        }
    }
}
