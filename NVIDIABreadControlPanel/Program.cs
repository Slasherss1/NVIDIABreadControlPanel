using System;
using System.Windows.Forms;

namespace NVIDIABreadControlPanel
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new Tray(args));
        }
    }
}
