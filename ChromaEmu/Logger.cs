using System;
using System.Runtime.InteropServices;

namespace ChromaEmu
{
    public class Logger
    {
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();

        public static void Spawn()
        {
            AllocConsole();
        }
    }
}
