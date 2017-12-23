using System;
using System.Windows.Forms;

namespace ChromaEmu
{
    public class UI
    {
        public class MsgBox
        {
            public static void Show(string body, string title, MessageBoxIcon icon = MessageBoxIcon.None)
            {
                MessageBox.Show(body, title + " - ChromaEmu", MessageBoxButtons.OK, icon);
            }
        }
    }
}
