using System;
using System.Net;
using System.Windows.Forms;

namespace ChromaEmu
{
    public partial class frmSettings : Form
    {
        private WebClient wc;


        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.key = txtKey.Text.Trim();
            Properties.Settings.Default.iv = txtIv.Text.Trim();

            Properties.Settings.Default.url_key = txtKeyUrl.Text.Trim();
            Properties.Settings.Default.url_iv = txtIvUrl.Text.Trim();

            Properties.Settings.Default.emu_url = txtEmuUrl.Text.Trim();

            Properties.Settings.Default.Save();

            this.Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            this.wc = new WebClient()
            {
                Proxy = null
            };

            if (Properties.Settings.Default.key != null)
                txtKey.Text = Properties.Settings.Default.key;

            if (Properties.Settings.Default.iv != null)
                txtIv.Text = Properties.Settings.Default.iv;


            if (Properties.Settings.Default.url_key != null)
                txtKeyUrl.Text = Properties.Settings.Default.url_key;

            if (Properties.Settings.Default.url_iv != null)
                txtIvUrl.Text = Properties.Settings.Default.url_iv;


            if (Properties.Settings.Default.emu_url != null)
                txtEmuUrl.Text = Properties.Settings.Default.emu_url;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtKey.Text = wc.DownloadString(txtKeyUrl.Text).Trim();
            txtIv.Text = wc.DownloadString(txtIvUrl.Text).Trim();
        }
    }
}
