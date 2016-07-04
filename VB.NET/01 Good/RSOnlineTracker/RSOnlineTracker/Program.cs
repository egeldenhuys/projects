using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Net;
using System.IO;


namespace RSOnlineTracker
{
    class Program
    {
        private static Boolean exitCommanded = false;
        private static Timer aTimer;

        static void Main(string[] args)
        {
            // Set up timer
            aTimer = new Timer(5000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            GC.KeepAlive(aTimer);

            DisplayMenu();


            while (exitCommanded == false)
            {
                Console.Write("> ");
                HandleCommand(Console.ReadLine());
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);

        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine(GetNumber());
        }

        private static void HandleCommand(string command)
        {
            switch (command)
            {
                case "start":
                    Console.WriteLine("Tracker started...");
                    aTimer.Enabled = true;

                    break;

                case "stop":
                    Console.WriteLine("Tracker stopped...");
                    aTimer.Enabled = false;

                    break;

                case "get":
                    Console.WriteLine("Downloading information...");
                    Console.WriteLine(GetNumber());
                    break;

                case "time":
                    string epoch = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000).ToString();
                    Console.WriteLine("Timestamp: " + epoch);
                    
                    break;

                case "exit":
                    exitCommanded = true;
                    aTimer.Enabled = false;
                    Console.WriteLine("Closing program...");
                    break;

                default:
                    Console.WriteLine("Unkown command!");
                    break;
            }

        }

        private static string GetNumber()
        {
            string result = "";
            WebClient client = new WebClient();
            string epoch = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000).ToString();
            string playerUri = ("http://www.runescape.com/player_count.js?varname=iPlayerCount&callback=jQuery17207130942128143999_1357191788211&_=" + epoch);

            Console.WriteLine("Downloading string from: " + playerUri);

            result = client.DownloadString(playerUri);

            return result;

        }


        private static void AppendNumber(string txt)
        {
            StreamWriter sw = new StreamWriter("OnlinePlayersLog.txt", true);
            sw.Write(


        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Command - Effect");
            Console.WriteLine("----------------");
            Console.WriteLine("start - Start downloading the number of players online. (Every 20 seconds).");
            Console.WriteLine("stop - Stop downloading.");
            Console.WriteLine("get - Get the current amount of players online.");
            Console.WriteLine("time - Return timestamp");
            Console.WriteLine("exit - Close program.");
        }



    }


}
