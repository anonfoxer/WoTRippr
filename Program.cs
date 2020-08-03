using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Text.RegularExpressions;

namespace WoTTool
{
    class Program
    {

        static string rootFolder = @"C:\Games\World_of_Tanks\res_mods\1.10.*\"; //currently still hardcoded to C: drive. 
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine(@"                                 
- World of Tanks Rippr
- v2.0.1
- by anonfoxer
- (c) 2019
- github.com/anonfoxer
");
            #region main
            Console.WriteLine("1. Clear all replay files"); //clearReplays();
            Console.WriteLine("2. Clear all mods from res_mods"); //clearMods();
            Console.WriteLine("3. Dump cef.log"); //cefDump();
            Console.WriteLine("4. Country Bias Calculator"); //russianBias();
            Console.WriteLine("5. Delete logs"); //freeSpace();
            Console.WriteLine("6. Clear temp"); //templesS();
            Console.WriteLine("7. Reset cef.log"); //logReset();
            Console.WriteLine("8. Info, Changelog, ToDo List"); //informMe();

            #region choicehandle

            var choice = Console.ReadLine();
            int choiceSwitch = Convert.ToInt32(choice);
            switch (choiceSwitch)
            {
                case 1:
                    clearReplays();
                    break;
                case 2:
                    clearMods();
                    break;
                case 3:
                    cefDump();
                    break;
                case 4:
                    russianBias();
                    break;
                case 5:
                    freeSpace();
                    break;
                case 6:
                    templesS();
                    break;
                case 7:
                    logReset();
                    break;
                case 8:
                    informMe();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("No choice made.");
                    Console.ReadLine();
                    break;
            }
        }
        #endregion

        #endregion
        public static void clearReplays()
        {
            string[] replays = System.IO.Directory.GetFiles(@"C:\Games\World_of_Tanks\replays", "*.wotreplay");
            foreach (string file in replays)
            {
                System.IO.File.Delete(file);
                Console.WriteLine($"{file} was deleted");
            }
            Console.WriteLine("Press any key to close.");
            Console.ReadLine();
        }
        public static void clearMods()
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(rootFolder);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
                Console.WriteLine($"{file} was deleted"); //This was massively overhauled. This would originally only delete files but most mods are in folders. So
            } //We grab any files that might be there (this includes the readme file bc no one needs it if they're modding)
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
                Console.WriteLine($"{dir} was deleted");  //Start deleting directories as that bulk deletes all the mod contents in them. I could just run this and it could be faster buuuuut oh well.
                //
            }
            Console.WriteLine("Press any key to close.");
            Console.ReadLine();
        }
        public static void informMe()
        {
            Console.Clear();
            Console.WriteLine("This tool acts with the default install path of World of Tanks");
            Console.WriteLine("C:>Games>World_of_Tanks");
            Console.WriteLine("This is planned to be changed in future tool versions so the user can set.");
            Console.WriteLine("Updates available at:");
            Console.WriteLine("github.com/anonfoxer");
            Console.WriteLine("------ CHANGELOG ------");
            Console.WriteLine(" ");
            Console.WriteLine(@"                                 
- v2.0.1
- Updated to WoT Patch 1.10.x
- Added ToDo List
 
");
            Console.WriteLine("------ TO DO------");
            Console.WriteLine(" ");
            Console.WriteLine(@"
- A major rework of this tool will be coming soon, to bring WoTScythe v1.0. This will include a GUI, code optimization, and removal of junk code.
- The original version of WoTRipper (soon to be WoTScythe) will be available on GitHub
 ");
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to close.");
            Console.ReadLine();
        }
        public static void cefDump()
        {
            // Read the log as one string.
            string log = System.IO.File.ReadAllText(@"C:\Games\World_of_Tanks\cef.log");

            // Display the log contents to the console. Variable text is a string.
            System.Console.WriteLine("cef.log = {0}", log);
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to close.");
            Console.ReadLine();
        }
        public static void russianBias()
        {
            #region nations
            int r = 0; //russia
            int c = 0; //china
            int j = 0;//japan
            int i = 0;//italy
            int s = 0;//sweden
            int z = 0;//czech
            int a = 0;//usa
            int b = 0;//great britian
            int g = 0;//germany
            int f = 0;//france
            int p = 0; //poland
            #endregion
            string[] replayslol = System.IO.Directory.GetFiles(@"C:\Games\World_of_Tanks\replays", "*.wotreplay");
            foreach (string file in replayslol)
            {
                #region count
                if (file.Contains("_ussr-")) {
                    r++;
                }
                if (file.Contains("_china-"))
                {
                    c++;
                }
                if (file.Contains("_france-"))
                {
                    f++;
                }
                if (file.Contains("_usa-"))
                {
                    a++;
                }
                if (file.Contains("_japan-"))
                {
                    j++;
                }
                if (file.Contains("_germany-"))
                {
                    g++;
                }
                if (file.Contains("_uk-"))
                {
                    b++;
                }
                if (file.Contains("_italy-"))
                {
                    i++;
                }
                if (file.Contains("_sweden-"))
                {
                    s++;
                }
                if (file.Contains("_czech-"))
                {
                    z++;
                }
                if (file.Contains("_poland-"))
                {
                    p++;
                }
                #endregion
            }
            #region reveals
            Console.Write("");
            Console.WriteLine("You've played Russian vehicles " + r + " time(s)!");
            Console.WriteLine("You've played Chinese vehicles " + c + " time(s)!");
            Console.WriteLine("You've played French vehicles " + f + " time(s)!");
            Console.WriteLine("You've played American vehicles " + a + " time(s)!");
            Console.WriteLine("You've played German vehicles " + g + " time(s)!");
            Console.WriteLine("You've played Japanese vehicles " + j + " time(s)!");
            Console.WriteLine("You've played Italian vehicles " + i + " time(s)!");
            Console.WriteLine("You've played Swedish vehicles " + s + " time(s)!");
            Console.WriteLine("You've played Czechoslovakian vehicles " + z + " time(s)!");
            Console.WriteLine("You've played British vehicles " + b + " time(s)!");
            Console.WriteLine("You've played Polish vehicles " + p + " time(s)!");
            //repeat for all nations
            #region calc
            if(r > 10)
            {
                Console.WriteLine("You're biased to Russian Vehicles!");
            }
            if (c > 10)
            {
                Console.WriteLine("You're biased to Chinese Vehicles!");
            }
            if (f > 10)
            {
                Console.WriteLine("You're biased to French Vehicles!");
            }
            if (p > 10)
            {
                Console.WriteLine("You're biased to Polish Vehicles!");
            }
            if (a > 10)
            {
                Console.WriteLine("You're biased to American Vehicles!");
            }
            if (g > 10)
            {
                Console.WriteLine("You're biased to German Vehicles!");
            }
            if (j > 10)
            {
                Console.WriteLine("You're biased to Japanese Vehicles!");
            }
            if (i > 10)
            {
                Console.WriteLine("You're biased to Italian Vehicles!");
            }
            if (s > 10)
            {
                Console.WriteLine("You're biased to Swedish Vehicles!");
            }
            if (z > 10)
            {
                Console.WriteLine("You're biased to Czechoslovakian Vehicles!");
            }
            if (b > 10)
            {
                Console.WriteLine("You're biased to British Vehicles!");
            }
            #endregion
            Console.Write("");
            Console.WriteLine("Press any key to close.");
            Console.ReadLine();
            #endregion
        }
        public static void freeSpace()
        {
            string[] filess = System.IO.Directory.GetFiles(@"C:\Games\World_of_Tanks\", "*.log");
            foreach (string file in filess)
            {
                System.IO.File.Delete(file);
                Console.WriteLine($"{file} was deleted");
            }
            string[] filesss = System.IO.Directory.GetFiles(@"C:\Games\World_of_Tanks\logs\", "*.log");
            foreach (string file in filesss)
            {
                System.IO.File.Delete(file);
                Console.WriteLine($"{file} was deleted");
            }
            Console.WriteLine("Press any key to close.");
            Console.ReadLine();
        }
        public static void templesS()
        {
            string[] filesss = System.IO.Directory.GetFiles(@"C:\Games\World_of_Tanks\UpdatesData\temp\", "*.*");
            foreach (string file in filesss)
            {
                System.IO.File.Delete(file);
                Console.WriteLine($"{file} was deleted");
            }
            Console.WriteLine("Press any key to close.");
            Console.ReadLine();
        }
        public static void logReset()
        {
            string line = "cef.log overwritten by WoTRippr";
            File.WriteAllText(@"C:\Games\World_of_Tanks\cef.log", line);
            Console.WriteLine("cef.log was overwritten. Please check it to verify.");
            Console.WriteLine("Or don't. Im a computer program, not a cop.");
            Console.WriteLine("Press any key to close.");
            Console.ReadLine();
        }
    }
}

