using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using DNS.Server;

namespace ChromaEmu
{
    public class Dns
    {
        private static DnsServer server;

        public async static void Start()
        {
            server = new DnsServer("8.8.8.8");

            // spoof requests to chromacheats to the local webserver
            server.MasterFile.AddIPAddressResourceRecord("chromacheats.com", "127.0.0.2");
            server.MasterFile.AddIPAddressResourceRecord("www.chromacheats.com", "127.0.0.2");

            await server.Listen();
        }

        public static void Stop()
        {
            server = new DnsServer("8.8.8.8");
        }
    }
}
