using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ChromaEmu
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void lnkAequabit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://steamcommunity.com/id/aequabit");
        }

        private void lnkImiTat0r_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://steamcommunity.com/id/imitat0r");
        }

        private void lnkToxic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://steamcommunity.com/profiles/76561198335942657");
        }

        private void lnkSapphyrus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://steamcommunity.com/id/sapphyrusxyz");
        }

        private void lnkCzeuss_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://steamcommunity.com/id/czeuss");
        }
    }
}
