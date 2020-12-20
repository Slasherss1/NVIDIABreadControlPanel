using System;

namespace NVIDIABreadControlPanel
{
    class Program
    {
        public static string LargeImage { get; private set; }

        static void Main(string[] args)
        {
            Discord.Discord discord = new Discord.Discord(790172329098608702, (ulong)Discord.CreateFlags.Default);
            var activity = new Discord.Activity
            {
                State = "In settings",
                Details = "Changing LED settings.",
                Assets =
                {
                    LargeImage = "bruh"
                }
            };
            discord.GetActivityManager().UpdateActivity(activity, (res) =>
            {
                if (res == Discord.Result.Ok)
                {
                    Console.WriteLine("Success!");
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
