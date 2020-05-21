using System.ServiceProcess;
using Common.Logging;
using WebDAVSharp.FileExample.Framework;
using WebDAVSharp.Server;
using WebDAVSharp.Server.Stores;
using WebDAVSharp.Server.Stores.DiskStore;
using System.Linq;
using System;
using System.Security.Policy;
//using WebDAVSharp.Server.Stores.Locks;
//using WebDAVSharp.Server.Stores.Locks.Interfaces;
#if DEBUG
using Common.Logging.Configuration;
using Common.Logging.Simple;

#endif

namespace WebDAVSharp.FileExample
{
    /// <summary>
    ///     The actual implementation of the windows service goes here...
    /// </summary>
    [WindowsService("WebDavSharp.FileExample",
        DisplayName = "WebDavSharp.FileExample",
        Description = "WebDavSharp.FileExample",
        EventLogSource = "WebDavSharp.FileExample",
        StartMode = ServiceStartMode.Automatic)]
    public class WebDAVService : IWindowsService
    {
        // IMPORTANT !!
        // change these variables to your wanted configuration
        private string Root = @"c:\";
        private string Url = "http://localhost:8880/";

        public void Dispose()
        {
        }

        /// <summary>
        ///     This method is called when the service gets a request to start.
        /// </summary>
        /// <param name="args">Any command line arguments</param>
        public void OnStart(string[] args)
        {
            var bindText = args.FirstOrDefault(t => t.Contains("-bind:"));
            this.Url = GetValue(bindText) ?? "http://localhost:8880/";
            var rootText = args.FirstOrDefault(t => t.Contains("-root:"));
            this.Root = GetValue(rootText) ?? "c:\\";
            Console.WriteLine($"Listen: {Url}, Root: {Root}");

            InitConsoleLogger();
            StartServer();
        }

        static string GetValue(string p)
        {
            if (p == null || p == "")
                return null;
            var n = p.IndexOf(":");
            if (n > 0)
                return p.Substring(n + 1);
            return null;
        }



        /// <summary>
        ///     This method is called when the service gets a request to stop.
        /// </summary>
        public void OnStop()
        {
        }

        /// <summary>
        ///     This method is called when a service gets a request to pause,
        ///     but not stop completely.
        /// </summary>
        public void OnPause()
        {
        }

        /// <summary>
        ///     This method is called when a service gets a request to resume
        ///     after a pause is issued.
        /// </summary>
        public void OnContinue()
        {
        }

        /// <summary>
        ///     This method is called when the machine the service is running on
        ///     is being shutdown.
        /// </summary>
        public void OnShutdown()
        {
        }

        private void InitConsoleLogger()
        {
            // create properties
            NameValueCollection properties = new NameValueCollection();
            properties["showDateTime"] = "true";
            // set Adapter
            LogManager.Adapter = new ConsoleOutLoggerFactoryAdapter(properties);
        }

        /// <summary>
        /// Starts the server.
        /// Authentication used: Negotiate
        /// </summary>
        private void StartServer()
        {
            //IWebDavStoreItemLock lockSystem = new WebDavStoreItemLock();
            //IWebDavStore store = new WebDavDiskStore(Localpath, lockSystem);
            //WebDavServer server = new WebDavServer(ref store);
            //server.Start(Url);

            WebDavServer server = new WebDavServer(new WebDavDiskStore(Root));
            //server.Listener.Prefixes.Add("http://your_url_here/");
            server.Start(Url);
        }
    }
}