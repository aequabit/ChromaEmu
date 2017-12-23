using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ChromaEmu
{
    public partial class frmMain : Form
    {
        private static WebClient wc;

        private static bool running = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var result = MessageBox.Show("By using ChromaEmu, you agree with us installing a certificate and temporarily changing your DNS servers.", "Security information", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result != DialogResult.Yes)
            {
                Application.Exit();
                return;
            }

            /*if (Windows.IsWindows10())
                MessageBox.Show("ChromaEmu is currently not supported on Windows 10.", "Compatibility", MessageBoxButtons.OK, MessageBoxIcon.Error);
                */
            if (Windows.IsWindows10())
            {
                btnStart.Enabled = false;
                btnStart.Text = "No Windows 10 support!";
                btnStart.Size = new Size(185, btnStart.Size.Height);
            }

            wc = new WebClient()
            {
                Proxy = null
            };

            // setup console
            Logger.Spawn();
            Console.Title = "ChromaEmu - Debug Console";

            // get network interfaces
            var interfaces = Windows.GetNetworkInterfaces();

            // exit if there are not interfaces available
            if (interfaces.Count == 0)
            {
                UI.MsgBox.Show("There was an error getting the Network Interfaces.", "Error", MessageBoxIcon.Error);
                Application.Exit();
            }

            // add all interfaces to the combobox
            foreach (string name in interfaces)
                cmbInterfaces.Items.Add(name);

            // check if the saved interface is still available
            if (interfaces.Contains(Properties.Settings.Default.nic))
                cmbInterfaces.Text = Properties.Settings.Default.nic;

            // restore old dns settings if the emulator wasn't closed properly before
            if (Properties.Settings.Default.dns_servers.Length > 0)
            {
                Logger.Log("Restoring DNS servers...", "windows", ConsoleColor.Yellow);
                Windows.SetDns(cmbInterfaces.Text, Properties.Settings.Default.dns_servers);
                Properties.Settings.Default.dns_servers = "";
                Properties.Settings.Default.Save();
            }

            Logger.Log("Loading AES keys...", "api", ConsoleColor.Green);

            // try to fetch the current aes keys from the server
            try
            {
                Properties.Settings.Default.key = wc.DownloadString(Properties.Settings.Default.url_key).Trim();
                Properties.Settings.Default.iv = wc.DownloadString(Properties.Settings.Default.url_iv).Trim();
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Logger.Log("Failed to load AES keys.", "api", ConsoleColor.Green);
            }

            // check the api status
            try
            {
                wc.DownloadString(Properties.Settings.Default.url_key);

                lblApiStatus.Text = "online";
                lblApiStatus.ForeColor = Color.DarkGreen;
            }
            catch (Exception)
            {
                lblApiStatus.Text = "offline";
                lblApiStatus.ForeColor = Color.Red;
            }

            this.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {

                // break, if there's no interface selected
                if (cmbInterfaces.Text.Length == 0)
                {
                    UI.MsgBox.Show("Please select a Network Interface before starting the Emulator.", "Error", MessageBoxIcon.Error);
                    return;
                }

                running = true;

                // disable controls
                btnStart.Enabled = false;
                cmbInterfaces.Enabled = false;

                // save the settings
                Properties.Settings.Default.nic = cmbInterfaces.Text;
                if (Properties.Settings.Default.dns_servers.Length == 0)
                {
                    Logger.Log("Backing up DNS servers...", "windows", ConsoleColor.Yellow);
                    Properties.Settings.Default.dns_servers = Windows.GetDns(cmbInterfaces.Text);
                }
                Properties.Settings.Default.Save();

                Logger.Log("Installing SSL certificate...", "windows", ConsoleColor.Yellow);
                if (!Windows.InstallCertificate())
                {
                    Logger.Log("Could not install SSL certificate.", "windows", ConsoleColor.Yellow, ConsoleColor.Red);
                    throw new Exception();
                }

                Logger.Log("Starting services...", "ccemu", ConsoleColor.Red);

                // start the http server
                Logger.Log("Starting...", "http", ConsoleColor.Magenta);
                Http.Start();
                lblHttpStatus.Text = "online";
                lblHttpStatus.ForeColor = Color.DarkGreen;
                Logger.Log("Listening on *:80 and *:443.", "http", ConsoleColor.Magenta);

                // start the dns server
                Logger.Log("Starting...", "dns", ConsoleColor.Cyan);
                Dns.Start();
                lblDnsStatus.Text = "online";
                lblDnsStatus.ForeColor = Color.DarkGreen;
                Logger.Log("Listening on *:53.", "dns", ConsoleColor.Cyan);

                Logger.Log("Setting DNS servers...", "windows", ConsoleColor.Yellow);

                // set the new dns servers
                Windows.SetDns(cmbInterfaces.Text, "127.0.0.1,8.8.8.8");

                Logger.Log("Flushing DNS cache...", "windows", ConsoleColor.Yellow);

                // flush dns cache
                new Process()
                {
                    StartInfo =
                {
                    FileName = "ipconfig",
                    Arguments = "/flushdns",
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
                }.Start();

                Logger.Log("All services up and running.", "ccemu", ConsoleColor.Red);

                btnStop.Enabled = true;

            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message + Environment.NewLine + ex.StackTrace);
                btnStart.Enabled = true;
                cmbInterfaces.Enabled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                btnStop.Enabled = false;

                // restore the dns servers
                if (Properties.Settings.Default.dns_servers.Length > 0)
                {
                    string[] defaultGateways = new string[] { "192.168.178.1" };
                    if (Windows.GetDns(cmbInterfaces.Text).Trim() == "192.168.178.1")
                        Windows.SetDns(cmbInterfaces.Text, null);
                    else
                        Windows.SetDns(cmbInterfaces.Text, Properties.Settings.Default.dns_servers);

                    Logger.Log("Restoring DNS servers...", "windows", ConsoleColor.Yellow);
                    Properties.Settings.Default.dns_servers = "";
                    Properties.Settings.Default.Save();
                }

                Logger.Log("Stopping services...", "ccemu", ConsoleColor.Red);

                // stop the dns server
                Logger.Log("Stopping...", "dns", ConsoleColor.Cyan);
                Dns.Stop();
                lblDnsStatus.Text = "offline";
                lblDnsStatus.ForeColor = Color.Red;

                // stop the http server
                Logger.Log("Stopping...", "http", ConsoleColor.Magenta);
                Http.Stop();
                lblHttpStatus.Text = "offline";
                lblHttpStatus.ForeColor = Color.Red;

                Logger.Log("Uninstalling SSL certificate...", "windows", ConsoleColor.Yellow);
                if (!Windows.UninstallCertificate())
                {
                    Logger.Log("Could not uninstall SSL certificate.", "windows", ConsoleColor.Yellow, ConsoleColor.Red);
                }

                running = false;
                Logger.Log("All services stopped.", "ccemu", ConsoleColor.Red);

                cmbInterfaces.Enabled = true;
                btnStart.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmSettings().ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAbout().ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (running)
            {
                var result = MessageBox.Show("Are you sure you want to stop the server and close ChromaEmu?", "Exit - ChromaEmu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    btnStop.PerformClick();
                    return;
                }

                e.Cancel = true;
            }

            Environment.Exit(0);
        }
    }
}
