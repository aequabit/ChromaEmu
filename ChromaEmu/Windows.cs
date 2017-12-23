using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Management;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace ChromaEmu
{
    class Windows
    {
        public static bool IsWindows10()
        {
            return Environment.OSVersion.Version.Major == 10;
        }

        public static bool IsDnsStatic(string nic)
        {
            var cls = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var instances = cls.GetInstances();

            foreach (ManagementObject obj in instances)
            {
                if ((bool)obj["IPEnabled"])
                {
                    if (obj["Caption"].ToString().Contains(nic))
                    {
                        string key = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces\\" + (string)obj["SettingId"], "NameServer", null);
                        if (String.IsNullOrEmpty(key))
                            return false;

                        return true;
                    }
                }
            }

            return false;
        }

        public static void SetDns(string nic, string dns)
        {
            var cls = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var instances = cls.GetInstances();

            foreach (ManagementObject obj in instances)
            {
                if ((bool)obj["IPEnabled"])
                {
                    if (obj["Caption"].ToString().Contains(nic))
                    {
                        try
                        {
                            ManagementBaseObject newDNS = obj.GetMethodParameters("SetDNSServerSearchOrder");
                            if (dns == "%DYNAMIC%")
                                newDNS["DNSServerSearchOrder"] = null;
                            else
                                newDNS["DNSServerSearchOrder"] = dns.Split(',');
                            ManagementBaseObject setDNS = obj.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
        }

        public static string GetDns(string nic)
        {
            if (!IsDnsStatic(nic))
                return "%DYNAMIC%";

            var cls = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var instances = cls.GetInstances();

            foreach (ManagementObject obj in instances)
            {
                if ((bool)obj["IPEnabled"])
                {
                    if (obj["Caption"].ToString().Contains(nic))
                    {
                        try
                        {
                            var final = "";
                            foreach (string address in (string[])obj["DNSServerSearchOrder"])
                                final += address + ",";
                            return final.Trim(',');
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            return "";
        }

        public static List<string> GetNetworkInterfaces()
        {
            List<string> interfaces = new List<string>();
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                interfaces.Add(nic.Description);
            }
            return interfaces;
        }

        public static bool InstallCertificate()
        {
            if (File.Exists(Path.GetTempPath() + "chromacheats.pfx"))
                File.Delete(Path.GetTempPath() + "chromacheats.pfx");

            File.WriteAllBytes(Path.GetTempPath() + "chromacheats.pfx", Helper.ExtractResource("chromacheats.pfx"));

            X509Certificate2Collection Collection = new X509Certificate2Collection();
            Collection.Import(Path.GetTempPath() + "chromacheats.pfx", "1337", X509KeyStorageFlags.MachineKeySet
                                              | X509KeyStorageFlags.PersistKeySet
                                              | X509KeyStorageFlags.Exportable);

            if (Collection.Count < 1)
                return false;

            X509Certificate2 certificate = Collection[0];

            X509Store personal = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            personal.Open(OpenFlags.ReadWrite);
            personal.Add(certificate);
            personal.Close();


            X509Store root = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            root.Open(OpenFlags.ReadWrite);
            root.Add(certificate);
            root.Close();



            var netsh = new Process();
            netsh.StartInfo.FileName = "netsh";
            netsh.StartInfo.Arguments = "http add sslcert ipport=0.0.0.0:443 certhash=" + certificate.GetCertHashString().ToLower() + " appid=" + Helper.GetGuid();
            netsh.StartInfo.UseShellExecute = false;
            netsh.StartInfo.CreateNoWindow = true;
            netsh.Start();

            return true;
        }

        public static bool UninstallCertificate()
        {

            var netsh = new Process();
            netsh.StartInfo.FileName = "netsh";
            netsh.StartInfo.Arguments = "http delete sslcert ipport=0.0.0.0:443";
            netsh.StartInfo.UseShellExecute = false;
            netsh.StartInfo.CreateNoWindow = true;
            netsh.Start();

            X509Certificate2Collection Collection = new X509Certificate2Collection();
            Collection.Import(Path.GetTempPath() + "chromacheats.pfx", "1337", X509KeyStorageFlags.MachineKeySet
                                              | X509KeyStorageFlags.PersistKeySet
                                              | X509KeyStorageFlags.Exportable);

            if (Collection.Count < 1)
                return false;

            X509Certificate2 certificate = Collection[0];

            X509Store personal = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            personal.Open(OpenFlags.ReadWrite);
            personal.Remove(certificate);
            personal.Close();


            X509Store root = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            root.Open(OpenFlags.ReadWrite);
            root.Remove(certificate);
            root.Close();

            if (File.Exists(Path.GetTempPath() + "chromacheats.pfx"))
                File.Delete(Path.GetTempPath() + "chromacheats.pfx");

            return true;
        }
    }
}
