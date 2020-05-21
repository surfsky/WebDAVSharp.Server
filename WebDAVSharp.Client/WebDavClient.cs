using System;
using System.IO;
using System.Net;
using System.Text;

namespace WebDAVSharp.Client
{
    /// <summary>
    /// The basics for talking to the WebDAV server
    /// </summary>
    public partial class WebDavClient
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain   { get; set; }

        /// <summary>Constructor</summary>
        public WebDavClient(string userName, string password, string domain)
        {
            UserName = userName;
            Password = password;
            Domain   = domain;
        }

        /// <summary>Get the credentials of the user</summary>
        /// <param name="requestUri">The request URI</param>
        /// <returns>The credentials as an instance of <see cref="CredentialCache" /></returns>
        internal CredentialCache BuildCredential(string url)
        {
            var credential = new CredentialCache
            {
                {
                    new Uri(url),
                    "Negotiate",
                    new NetworkCredential(UserName, Password, Domain)
                }
            };         
            return credential;
        }

        /// <summary>Creates a basic WebDav Request</summary>
        /// <param name="requestUri">The requested URI as an <see cref="Uri" /></param>
        /// <param name="method">The <see cref="string" /> defining the WebDAV method to be used</param>
        /// <returns>The basic WebDav Request as an <see cref="HttpWebRequest" /></returns>
        internal static HttpWebRequest BuildRequest(string requestUri, string method)
        {
            var request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.UserAgent = "WebDAV-UnitTestProject/1.0.0";
            request.UseDefaultCredentials = true;
            request.Method = method;
            return request;
        }

        /// <summary>Creates the response of the given <see cref="HttpWebRequest" /></summary>
        /// <param name="request">The <see cref="HttpWebRequest" /></param>
        /// <returns>The <see cref="WebResponse" /> of the <see cref="HttpWebRequest" /></returns>
        internal static HttpWebResponse GetResponse(HttpWebRequest request)
        {
            try
            {
                // Send the WebDav method request, get the response from the server.
                // Pipes the stream to a higher level stream reader with the required encoding format. 
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    var encode = Encoding.GetEncoding("utf-8");
                    var readStream = new StreamReader(stream, encode);
                    var read = new Char[256];
                    var str = "";
                    // Reads 256 characters at a time.
                    // Dumps the 256 characters on a string and displays the string to the console.
                    int count = readStream.Read(read, 0, 256);
                    while (count > 0)
                    {
                        str += new String(read, 0, count);
                        count = readStream.Read(read, 0, 256);
                    }
                    readStream.Close();
                }

                // Close the HttpWebResponse object.
                response.Close();
                return response as HttpWebResponse;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Response as HttpWebResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
