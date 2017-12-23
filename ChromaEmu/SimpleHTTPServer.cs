// MIT License - Copyright (c) 2016 Can Güney Aksakalli

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using ChromaEmu;
using Newtonsoft.Json;


class SimpleHTTPServer
{
    private readonly string[] _indexFiles = {
        "index.html",
        "index.htm",
        "default.html",
        "default.htm"
    };

    private static IDictionary<string, string> _mimeTypeMappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase) {
        #region extension to MIME type list
        {".asf", "video/x-ms-asf"},
        {".asx", "video/x-ms-asf"},
        {".avi", "video/x-msvideo"},
        {".bin", "application/octet-stream"},
        {".cco", "application/x-cocoa"},
        {".crt", "application/x-x509-ca-cert"},
        {".css", "text/css"},
        {".deb", "application/octet-stream"},
        {".der", "application/x-x509-ca-cert"},
        {".dll", "application/octet-stream"},
        {".dmg", "application/octet-stream"},
        {".ear", "application/java-archive"},
        {".eot", "application/octet-stream"},
        {".exe", "application/octet-stream"},
        {".flv", "video/x-flv"},
        {".gif", "image/gif"},
        {".hqx", "application/mac-binhex40"},
        {".htc", "text/x-component"},
        {".htm", "text/html"},
        {".html", "text/html"},
        {".ico", "image/x-icon"},
        {".img", "application/octet-stream"},
        {".iso", "application/octet-stream"},
        {".jar", "application/java-archive"},
        {".jardiff", "application/x-java-archive-diff"},
        {".jng", "image/x-jng"},
        {".jnlp", "application/x-java-jnlp-file"},
        {".jpeg", "image/jpeg"},
        {".jpg", "image/jpeg"},
        {".js", "application/x-javascript"},
        {".mml", "text/mathml"},
        {".mng", "video/x-mng"},
        {".mov", "video/quicktime"},
        {".mp3", "audio/mpeg"},
        {".mpeg", "video/mpeg"},
        {".mpg", "video/mpeg"},
        {".msi", "application/octet-stream"},
        {".msm", "application/octet-stream"},
        {".msp", "application/octet-stream"},
        {".pdb", "application/x-pilot"},
        {".pdf", "application/pdf"},
        {".pem", "application/x-x509-ca-cert"},
        {".pl", "application/x-perl"},
        {".pm", "application/x-perl"},
        {".png", "image/png"},
        {".prc", "application/x-pilot"},
        {".ra", "audio/x-realaudio"},
        {".rar", "application/x-rar-compressed"},
        {".rpm", "application/x-redhat-package-manager"},
        {".rss", "text/xml"},
        {".run", "application/x-makeself"},
        {".sea", "application/x-sea"},
        {".shtml", "text/html"},
        {".sit", "application/x-stuffit"},
        {".swf", "application/x-shockwave-flash"},
        {".tcl", "application/x-tcl"},
        {".tk", "application/x-tcl"},
        {".txt", "text/plain"},
        {".war", "application/java-archive"},
        {".wbmp", "image/vnd.wap.wbmp"},
        {".wmv", "video/x-ms-wmv"},
        {".xml", "text/xml"},
        {".xpi", "application/x-xpinstall"},
        {".zip", "application/zip"},
        #endregion
    };
    private Thread _serverThread;
    private string _rootDirectory;
    private HttpListener _listener;
    private int _port;

    public int Port
    {
        get { return _port; }
        private set { }
    }

    /// <summary>
    /// Construct server with given port.
    /// </summary>
    /// <param name="path">Directory path to serve.</param>
    /// <param name="port">Port of the server.</param>
    public SimpleHTTPServer(string path, int port)
    {
        this.Initialize(path, port);
    }

    /// <summary>
    /// Construct server with suitable port.
    /// </summary>
    /// <param name="path">Directory path to serve.</param>
    public SimpleHTTPServer(string path)
    {
        //get an empty port
        TcpListener l = new TcpListener(IPAddress.Loopback, 0);
        l.Start();
        int port = ((IPEndPoint)l.LocalEndpoint).Port;
        l.Stop();
        this.Initialize(path, port);
    }

    /// <summary>
    /// Stop server and dispose all functions.
    /// </summary>
    public void Stop()
    {
        _serverThread.Abort();
        _listener.Stop();
    }

    private void Listen()
    {

        try
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:" + _port.ToString() + "/");
            _listener.Prefixes.Add("https://*:443/");
            _listener.Start();
        }
        catch (Exception)
        {
            Logger.Log("Failed to bind HTTP server to port. The most common reason is Skype running.", "http", ConsoleColor.Magenta, ConsoleColor.Red);
            this.Stop();
        }

        while (true)
        {
            try
            {
                HttpListenerContext context = _listener.GetContext();
                Process(context);
            }
            catch (Exception ex)
            {
                //Logger.Log(ex.Message);
            }
        }
    }

    private void Process(HttpListenerContext context)
    {
        byte[] data;

        string route = context.Request.Url.AbsolutePath;

        context.Response.Headers.Add("Content-Type", "application/json");

        if (context.Request.HttpMethod == "GET") // key exchange
        {
            data = Encoding.UTF8.GetBytes("ChromaEmu Emulator Server");

            if (context.Request.QueryString.AllKeys.Contains("data"))
            {
                var split = context.Request.RawUrl.Split(new string[] { "data=" }, StringSplitOptions.None);

                string apiResponse = new ChromaFramework.Networking.HttpRequestHandler().Get(
                    ChromaEmu.Properties.Settings.Default.emu_url + "/?data=" + split[1]
                );

                data = Encoding.UTF8.GetBytes(apiResponse);

                context.Response.StatusCode = (int)HttpStatusCode.OK;

                Logger.Log("Sent key exchange response. ", "http", ConsoleColor.Magenta);
            }
            else if (context.Request.QueryString.AllKeys.Contains("dl"))
            {
                var split = context.Request.RawUrl.Split(new string[] { "dl=" }, StringSplitOptions.None);

                var response = new RequestHandler().Handle(
                     route,
                     split[1],
                     false
                );

                if (response.Payload != null)
                    data = response.Payload;
                else
                    Logger.Log("Invalid request", "http", ConsoleColor.Magenta);
            }
        }
        else if (context.Request.HttpMethod == "POST") // other request
        {
            StreamReader reader = new StreamReader(context.Request.InputStream);

            /*string request = ChromaFramework.Encryption.Rijndael.Decrypt(reader.ReadToEnd());

            if (!hello.Contains("Dispatcher"))
            {
                data = Encoding.UTF8.GetBytes("LrWioYOb0FLgTMUKUPTTzqQ7jdgxLMGHh8MpF4WtUU/A9UHlNmw2TPHHXq9b9BSZVYrODJ/uRVX1/fn8zsmupgqSmza49F0S0lbSK3R8UsRK3kvVIkXai1t0KE+8vUzS3jsb7jYHoHdkZspliLgeR50HKbPbx5Pr+xp3MmDL4IYJ4qd2O8ZlGPn/s8gGUCoXdSEYzoSIPX8hu7OZD3q8OdJ51sRKXRI2EnnMpwylOElFcdFsBMMRb1hLPzHFUwf9");
                context.Response.OutputStream.Write(data, 0, data.Length);
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.OutputStream.Flush();
                Logger.Log("Sent emulated response. ", "http", ConsoleColor.Magenta);
                context.Response.OutputStream.Close();
                return;
            }*/

            var response = new RequestHandler().Handle(route, reader.ReadToEnd());

            if (response.Payload == null) // if there's no response payload set
            {
                data = Encoding.UTF8.GetBytes(
                    ChromaFramework.Encryption.Rijndael.Encrypt(
                        JsonConvert.SerializeObject(
                            response
                        )
                    )
                );
            }
            else // the response is probably a product being loaded
            {
                data = response.Payload;
            }

            context.Response.StatusCode = (int)HttpStatusCode.OK;

            Logger.Log("Sent emulated response. ", "http", ConsoleColor.Magenta);
        }
        else // unknown method
        {
            data = Encoding.UTF8.GetBytes("invalid_request");
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            Logger.Log("Sent emulated response. ", "http", ConsoleColor.Magenta);
        }

        context.Response.OutputStream.Write(data, 0, data.Length);
        context.Response.OutputStream.Flush();
        context.Response.OutputStream.Close();

        //Logger.Log("Request: " + route, "http", ConsoleColor.Magenta);

        /*if (File.Exists(filename))
        {
            try
            {
                Stream input = new FileStream(filename, FileMode.Open);

                //Adding permanent http response headers
                string mime;
                context.Response.ContentType = _mimeTypeMappings.TryGetValue(Path.GetExtension(filename), out mime) ? mime : "application/octet-stream";
                context.Response.ContentLength64 = input.Length;
                context.Response.AddHeader("Date", DateTime.Now.ToString("r"));
                context.Response.AddHeader("Last-Modified", System.IO.File.GetLastWriteTime(filename).ToString("r"));

                byte[] buffer = new byte[1024 * 16];
                int nbytes;
                while ((nbytes = input.Read(buffer, 0, buffer.Length)) > 0)
                    context.Response.OutputStream.Write(buffer, 0, nbytes);
                input.Close();

                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.OutputStream.Flush();
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

        }
        else
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }*/
    }

    private void Initialize(string path, int port)
    {
        this._rootDirectory = path;
        this._port = port;
        _serverThread = new Thread(this.Listen);
        _serverThread.Start();
    }


}