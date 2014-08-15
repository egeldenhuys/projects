using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Net;
using System.IO;


namespace Runescape_Players_Online
{
    class Program
    {
        private static Boolean exitCommanded = false;
        private static int tmrInterval = 20000;
        private static Timer aTimer;
        private static string ScriptUri = "http://www.runescape.com/player_count.js?varname=iPlayerCount&callback=jQuery17207130942128143999_1357191788211&_=";
        private static string progVersion = "1.7.3";

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments found.");
            }
            else
            {
                try
                {

                    tmrInterval = Convert.ToInt32(args[0]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Argument is not a number");
                    Console.WriteLine(e);
                }
            }


            SetupTimer(tmrInterval);
            DisplayMenu();

            while (exitCommanded == false)
            {
                HandleCommand(Console.ReadLine());
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);

        }

        private static void SetupTimer(int timerInterval)
        {
            // Create a timer
            aTimer = new Timer(timerInterval);

            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(aTimer_Elapsed);

        }

        private static void aTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string onlinePlayerCount = GetOnlineCount();

            Console.WriteLine(onlinePlayerCount);
            AppendPlayerCount(onlinePlayerCount);

        }

        private static void AppendPlayerCount(string onlineCount)
        {
            try
            {
                StreamWriter sw = new StreamWriter("PlayerCount.txt", true);
                sw.Write(onlineCount + ",");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static string GetOnlineCount()
        {
            Console.WriteLine("Getting online player count...");

            string result = "null";
            string rawData;
            string[] substrings;

            try
            {
                WebClient client = new WebClient();
                rawData = client.DownloadString(ScriptUri + GetUnixTime()); //jQuery17207130942128143999_1357191788211(65536);
                substrings = rawData.Split(new Char[] { '(' }); // 0 = jQuery17207130942128143999_1357191788211, 1 = 65536);
                substrings = substrings[1].Split(new Char[] { ')' }); // 0 = 65536, 1= ;

                result = substrings[0];
            }
            catch (WebException)
            {
                Console.WriteLine("Could not connect to server");
            }

            SetLastDownload();

            return result;

        }

        private static string GetUnixTime()
        {
            return ((DateTime.UtcNow.ToUniversalTime().Ticks - 621355968000000000) / 10000).ToString();
        }

        private static void SetLastDownload()
        {
            StreamWriter sw = new StreamWriter("LastDownload.txt", false);
            sw.Write(GetUnixTime());
            sw.Close();
        }

        private static string GetLastDownload()
        {
            string result = "-1";

            try
            {
                StreamReader sr = new StreamReader("LastDownload.txt");
                result = sr.ReadToEnd();

                sr.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("LastDownload.txt does not exist. Skipping fill");

            }
            return result;

        }

        private static void FillInBlanks()
        {
            Console.WriteLine("Filling in missing numbers...");

            StreamWriter sw = new StreamWriter("PlayerCount.txt", true);
            int missed = 0;
            string lastDownload = GetLastDownload();
            if (lastDownload != "-1")
            {
                missed = Convert.ToInt32((Convert.ToUInt64(GetUnixTime()) - Convert.ToUInt64(lastDownload)) / Convert.ToUInt64(tmrInterval));

                for (int i = 0; i < missed; i++)
                {
                    sw.Write("null,");
                }
            }
            sw.Close();
            SetLastDownload();
            Console.WriteLine(missed + " missing numbers have been filled");

        }

        private static void DisplayMenu()
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("This program will download the online player count every " + tmrInterval / 1000 + " seconds.");
            Console.WriteLine("Version: " + progVersion);
            Console.WriteLine("--------------------------------------MENU--------------------------------------");
            Console.WriteLine("Command - Description");
            Console.WriteLine("start - Start capturing the amount of players online.");
            Console.WriteLine("stop - Stop capturing the amount of players online.");
            Console.WriteLine("new - Delete all information and start again.");
            Console.WriteLine("fill - Create blank spaces where numbers are missing.");
            Console.WriteLine("setstart - Set the starting point to the current time.");
            Console.WriteLine("update - Download the latest version, if it is available.");
            Console.WriteLine("time - Prints the current UTC timestamp.");
            Console.WriteLine("updateubuntu - Download latest version and create ubuntu .sh file");
            Console.WriteLine("exit - Close program.");
            Console.WriteLine("help - Displays list of commands.");
            Console.WriteLine("--------------------------------------------------------------------------------");
        }

        private static void HandleCommand(string cmdToHandle)
        {
            switch (cmdToHandle)
            {
                case "start":
                    if (aTimer.Enabled == false)
                    {
                        Console.WriteLine("Tracking Started...");
                        FillInBlanks();
                        string onlineCount = GetOnlineCount();

                        Console.WriteLine(onlineCount);
                        AppendPlayerCount(onlineCount);


                        aTimer.Enabled = true;
                    }
                    else
                    {
                        Console.WriteLine("Tracking is arleady started.");
                    }
                    break;

                case "stop":
                    if (aTimer.Enabled == true)
                    {
                        Console.WriteLine("Tracking Stopped...");
                        aTimer.Enabled = false;
                    }
                    else
                    {
                        Console.WriteLine("Tracking is already stopped.");
                    }

                    break;

                case "new":
                    StartNew();

                    break;

                case "help":
                    DisplayMenu();

                    break;

                case "time":
                    Console.WriteLine(GetUnixTime());
                    Console.WriteLine(DateTime.UtcNow.ToString());

                    break;

                case "fill":
                    FillInBlanks();

                    break;

                case "setstart":
                    UpdateStartPoint();

                    break;

                case "update":
                    DownloadLatestVersion();

                    break;

                case "updateubuntu":
                    DownloadLatestVersion(true);

                    break;

                case "exit":
                    exitCommanded = true;

                    if (aTimer.Enabled == true)
                    {
                        Console.WriteLine("Tracking Stopped...");
                        aTimer.Enabled = false;
                    }

                    break;

                default:
                    Console.WriteLine("Unknown Command.");
                    break;
            }

        }

        private static void DownloadLatestVersion(Boolean ubuntu = false)
        {
            WebClient client = new WebClient();
            Console.WriteLine("Checking for updates...");
            string latestVersion = client.DownloadString("http://dl.dropbox.com/u/57022080/Programs/Runescape%20Online%20Players/version.txt");
            Console.WriteLine("The latest version is " + latestVersion);

            if (latestVersion != progVersion)
            {
                Console.WriteLine("Downloading latest version...");
                client.DownloadFile("http://dl.dropbox.com/u/57022080/Programs/Runescape%20Online%20Players/Runescape%20Players%20Online.exe", "Runescape Players Online " + latestVersion + ".exe");
                Console.WriteLine("New version has been downloaded.");

                if (ubuntu)
                {
                    StreamWriter sw2 = new StreamWriter("Run.sh", false);
                    sw2.Write("mono \"Runescape Players Online " + latestVersion + ".exe\"" + " " + tmrInterval);
                    sw2.Close();
                }
            }
            else
            {
                Console.WriteLine("You have the latest version.");
            }


        }

        private static void UpdateStartPoint()
        {
            StreamWriter sw = new StreamWriter("StartPoint.txt", false);
            sw.Write(GetUnixTime());
            sw.Close();

        }

        private static void StartNew()
        {
            StreamWriter sw = new StreamWriter("PlayerCount.txt", false);
            sw.Write("");
            sw.Close();

            if (aTimer.Enabled == false)
            {
                Console.WriteLine("Tracking Started...");
                string onlineCount = GetOnlineCount();

                Console.WriteLine(onlineCount);
                AppendPlayerCount(onlineCount);

                aTimer.Enabled = true;
            }
            else
            {
                Console.WriteLine("Tracking is arleady started.");
            }
            
            UpdateStartPoint();

        }





    }
}
