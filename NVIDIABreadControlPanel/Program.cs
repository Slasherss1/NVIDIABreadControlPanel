using System;

namespace NVIDIABreadControlPanel
{
    class Program
    {
        public static string dt { get; private set; }
        public static string st { get; private set; }
        private static string arg { get; set; }

        static void Main(string[] args)
        {
            #if DEBUG
                Console.WriteLine("This is a debug version and it should not be redistributed. You should use it only for testing.");
            #else
                Console.WriteLine("NVIDIA Bread Control Panel [1.1.0]");
                Console.WriteLine("This work is licensed under a Creative Commons Attribution-NoDerivatives 4.0 International License");
            #endif
            Discord.Discord discord = new Discord.Discord(790172329098608702, (ulong)Discord.CreateFlags.Default);
            try
            {
                arg = args[0];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No argument found. Using default.");
                arg = "default";
            }
            arg = (arg == "led") ? "default" : arg;
            switch (arg)
            {
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
                default:
                    dt = "In settings";
                    st = "Changing LED settings.";
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
            while (true)
            {
                discord.RunCallbacks();
            }
        }
    }
}
