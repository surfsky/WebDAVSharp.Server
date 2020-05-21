using System;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;

namespace WebDAVSharp.Client
{
    /// <summary>
    /// The WebDAV Client methods
    /// </summary>
    public partial class WebDavClient
    {
        /// <summary>Execute a WebDAV Propfind method on the requested URI</summary>
        /// <param name="requestUri">The <see cref="Uri" /> for the request</param>
        /// <param name="depth">The <see cref="string" /> for the Depth header</param>
        /// <param name="content">The <see cref="string" /> of the body content</param>
        /// <returns>The response as a <see cref="WebResponse" /></returns>
        internal HttpWebResponse Propfind(string requestUri, string depth = "", string content = "")
        {
            var request = BuildRequest(requestUri, "PROPFIND");
            request.Credentials = BuildCredential(requestUri);
            request.ContentLength = content.Length;
            request.Headers.Add("Depth", depth);
            return GetResponse(request);
        }

        /// <summary>Execute a WebDAV MkCol method on the requested URI</summary>
        /// <param name="requestUri">The <see cref="Uri" /> for the request</param>
        /// <param name="content">The <see cref="string" /> of the body content</param>
        /// <returns>The response as a <see cref="WebResponse" /></returns>
        internal HttpWebResponse MkCol(string requestUri, string content = "")
        {
            var request = BuildRequest(requestUri, "MKCOL");
            request.Credentials = BuildCredential(requestUri);
            request.ContentLength = content.Length;
            return GetResponse(request);
        }

        /// <summary>Execute a WebDAV Delete method on the requested URI</summary>
        /// <param name="requestUri">The <see cref="Uri" /> for the request</param>
        /// <returns>The response as a <see cref="WebResponse" /></returns>
        internal HttpWebResponse Delete(string requestUri)
        {
            var request = BuildRequest(requestUri, "DELETE");
            request.Credentials = BuildCredential(requestUri);
            return GetResponse(request);
        }

        /// <summary>Execute a WebDAV Put method on the requested URI</summary>
        /// <param name="requestUri">The <see cref="Uri" /> for the request</param>
        /// <param name="content">The <see cref="string" /> of the body content</param>
        /// <returns>The response as a <see cref="WebResponse" /></returns>
        internal HttpWebResponse Put(string requestUri, string content = "")
        {
            var request = BuildRequest(requestUri, "PUT");
            request.Credentials = BuildCredential(requestUri);
            request.ContentLength = content.Length;
            return GetResponse(request);
        }

        /// <summary>Execute a WebDAV Copy method on the requested URI</summary>
        /// <param name="requestUri">The <see cref="Uri" /> for the request</param>
        /// <param name="destinationUri">The <see cref="string" /> for the Destination header</param>
        /// <param name="overwrite">The <see cref="bool" /> for the Overwrite header</param>
        /// <returns>The response as a <see cref="WebResponse" /></returns>
        internal HttpWebResponse Copy(string requestUri, string destinationUri, bool overwrite = false)
        {
            var request = BuildRequest(requestUri, "COPY");
            request.Credentials = BuildCredential(requestUri);
            request.Headers.Add("Destination", destinationUri);
            request.Headers.Add("Overwrite", overwrite ? "T" : "F");
            return GetResponse(request);
        }

        /// <summary>Execute a WebDAV Move method on the requested URI</summary>
        /// <param name="requestUri">The <see cref="Uri" /> for the request</param>
        /// <param name="destinationUri">The <see cref="string" /> for the Destination header</param>
        /// <param name="overwrite">The <see cref="bool" /> for the Overwrite header</param>
        /// <returns>The response as a <see cref="WebResponse" /></returns>
        internal HttpWebResponse Move(string requestUri, string destinationUri, bool overwrite = false)
        {
            var request = BuildRequest(requestUri, "MOVE");
            request.Credentials = BuildCredential(requestUri);
            request.Headers.Add("Destination", destinationUri);
            request.Headers.Add("Overwrite", overwrite ? "T" : "F");
            return GetResponse(request);
        }

        /// <summary>Execute a WebDAV Lock method on the requested URI</summary>
        /// <param name="requestUri">The <see cref="Uri" /> for the request</param>
        /// <param name="content">The <see cref="string" /> of the body content</param>
        /// <returns>The response as a <see cref="WebResponse" /></returns>
        internal HttpWebResponse Lock(string requestUri, string content = "")
        {
            var request = BuildRequest(requestUri, "LOCK");
            request.Credentials = BuildCredential(requestUri);
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            request.ContentLength = content.Length;
            request.ContentType = "text/xml; charset=\"utf-8\"";
            request.Timeout = 3600;
            request.Headers.Add("Depth", "0"); //can also be infinity
            request.Headers.Add("Pragma", "no-cache");

            // send content
            var encoding = new UTF8Encoding();
            byte[] byte1 = encoding.GetBytes(content);
            var newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            return GetResponse(request);
        }

        /// <summary>Execute a WebDAV Unlock method on the requested URI</summary>
        /// <param name="requestUri">The <see cref="Uri" /> for the request</param>
        /// <param name="content">The <see cref="string" /> of the body content</param>
        /// <returns>The response as a <see cref="WebResponse" /></returns>
        internal HttpWebResponse Unlock(string requestUri, string content = "")
        {
            var request = BuildRequest(requestUri, "UNLOCK");
            request.Credentials = BuildCredential(requestUri);
            return GetResponse(request);
        }

        /// <summary>Execute a WebDAV Options method on the requested URI</summary>
        /// <param name="requestUri">The <see cref="Uri" /> for the request</param>
        /// <returns>The response as a <see cref="WebResponse" /></returns>
        internal HttpWebResponse Options(string requestUri)
        {
            var request = BuildRequest(requestUri, "OPTIONS");
            request.Credentials = BuildCredential(requestUri);
            return GetResponse(request);
        }

        /// <summary>Execute a WebDAV Head method on the requested URI</summary>
        /// <param name="requestUri">The <see cref="Uri" /> for the request</param>
        /// <returns>The response as a <see cref="WebResponse" /></returns>
        internal HttpWebResponse Head(string requestUri)
        {
            var request = BuildRequest(requestUri, "HEAD");
            request.Credentials = BuildCredential(requestUri);
            return GetResponse(request);
        }

        /// <summary>Execute a WebDAV Proppatch method on the requested URI</summary>
        /// <param name="requestUri">The <see cref="Uri" /> for the request</param>
        /// <param name="content">The <see cref="string" /> of the body content</param>
        /// <returns>The response as a <see cref="WebResponse" /></returns>
        internal HttpWebResponse Proppatch(string requestUri, string content = "")
        {
            var request = BuildRequest(requestUri, "PROPPATCH");
            request.Credentials = BuildCredential(requestUri);
            request.ContentLength = content.Length;
            request.ContentType = "text/xml; charset=\"utf-8\"";

            // send content
            var encoding = new UTF8Encoding();
            byte[] byte1 = encoding.GetBytes(content);
            var newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            return GetResponse(request);
        }

        /// <summary>Execute a WebDAV Get method on the requested URI</summary>
        /// <param name="requestUri">The <see cref="Uri" /> for the request</param>
        /// <returns>The response as a <see cref="WebResponse" /></returns>
        internal HttpWebResponse Get(string requestUri)
        {
            var request = BuildRequest(requestUri, "GET");
            request.Credentials = BuildCredential(requestUri);
            return GetResponse(request);
        }
    }
}
