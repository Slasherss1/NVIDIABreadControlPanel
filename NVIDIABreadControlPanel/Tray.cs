using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NVIDIABreadControlPanel
{
    public partial class Tray : Form
    {
        public static string dt { get; private set; }
        public static string st { get; private set; }
        private static string arg { get; set; }
        private string[] args;
        public Tray(string[] args)
        {
            this.args = args;
            InitializeComponent();
            toolStripMenuItem1.Click += ToolStripMenuItem1_OnClick;
            toolStripMenuItem2.Click += ToolStripMenuItem2_Click;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        Discord.Discord discord = new Discord.Discord(790172329098608702, (ulong)Discord.CreateFlags.Default);

        private void Tray_Load(object sender, EventArgs e)
        {
            #if DEBUG
                Console.WriteLine("This is a debug version and it should not be redistributed. You should use it only for testing.");
            #else
                Console.WriteLine("NVIDIA Bread Control Panel [2.0.0]");
                Console.WriteLine("This work is licensed under a Creative Commons Attribution-NoDerivatives 4.0 International License");
            #endif
            try
            {
                arg = args[0];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No argument found.");
                arg = "default";
            }
            arg = (arg == "led") ? "default" : arg;
            switch (arg)
            {
                default:
                    Console.WriteLine("Using default argument.");
                    dt = "In settings";
                    st = "Changing LED settings.";
                    break;
                case "engitf2":
                    dt = "Bread Gaming";
                    st = "As Engineer in Team Fortress 2.";
                    break;
                case "rando":
                    dt = "RandoMandess";
                    st = "Beta test";
                    break;
                case "yt":
                    dt = "Youtube";
                    st = "Watching YouTube.";
                    break;
                case "gta":
                    dt = "Playing GTA V";
                    st = "Boarding Bogdan's submarine.";
                    break;
                case "gmod":
                    dt = "Playing Garry's Mod";
                    st = "Spawning melon.";
                    break;
            }
            var activity = new Discord.Activity
            {
                Details = dt,
                State = st,
                Assets =
                {
                    LargeImage = "bruh"
                }
            };
            discord.GetActivityManager().UpdateActivity(activity, (res) =>
            {
                if (res == Discord.Result.Ok)
                {
                    Console.WriteLine("Success!\nTo close the program, please press CTRL-C");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            });
        }

        private void Tray_Shown(Object sender, EventArgs e)
        {
#if !DEBUG
                Hide();
#endif
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            discord.RunCallbacks();
        }

        private void ToolStripMenuItem1_OnClick(object sender, EventArgs e)
        {
            timer1.Dispose();
            discord.Dispose();
            Application.Exit();
        }
    }
}
