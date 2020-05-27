using System;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using WebDAVSharp.FileExample.Framework;

namespace WebDAVSharp.FileExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                // install or uninstall windows service
                if (args.Contains("-install", StringComparer.InvariantCultureIgnoreCase))
                {
                    WindowsServiceInstaller.RuntimeInstall<WebDAVService>();
                }
                else if (args.Contains("-uninstall", StringComparer.InvariantCultureIgnoreCase))
                {
                    WindowsServiceInstaller.RuntimeUnInstall<WebDAVService>();
                }

                // otherwise, fire up the service as either console or windows service based on UserInteractive property.
                // if started from console, file explorer, etc, run as console app.
                // otherwise run as a windows service
                else
                {
                    var implementation = new WebDAVService();
                    if (Environment.UserInteractive)
                        ConsoleHarness.Run(args, implementation);
                    else
                    {
                        Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
                        ServiceBase.Run(new WindowsServiceHarness(implementation));
                    }
                }
            }

            catch (Exception ex)
            {
                ConsoleHarness.WriteToConsole(ConsoleColor.Red, "An exception occurred in Main(): {0}", ex);
            }
        }
    }
}