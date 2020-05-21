using System;
using System.Linq;
using System.Net;

namespace WebDAVSharp.Client
{
    /// <summary>
    /// This program will do a PROPFIND request to the WebDAV server.
    /// The statuscode and statusdescription will be written to the console.
    /// </summary>
    class Program
    {
        /// <param name="args">user, password.</param>
        static void Main(string[] args)
        {
            // parameter
            var url = "http://localhost:8880/";
            var user = "cjh";
            var password = "cjhcjh";
            if (args.Length == 3)
            {
                url = args[0];
                user = args[1];
                password = args[2];
            }

            //
            var client = new WebDavClient("cjh", "cjhcjh", "");
            Console.WriteLine("PROPFIND " + url);
            var httpWebResponse = client.Propfind(url);
            if (httpWebResponse != null)
                Console.WriteLine((int)httpWebResponse.StatusCode + " " + httpWebResponse.StatusDescription);
            else
                Console.WriteLine("HttpWebResponse was null.");
        }
    }
}
