using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace WoTTool
{
    class Program
    {
        static readonly string rootFolder = @"C:\Games\World_of_Tanks\res_mods\1.6.0.2\"; //This is the directory im using for the mods deletion. This means I have to update it with game patches but Im still trying to figure out a way to go through each directory and then delete stuff. Oh well, working on that lol. Least I updated this project and didnt abadon it.
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine(@" 
 __      __            .__       .___         _____  ___________              __            
/  \    /  \___________|  |    __| _/   _____/ ____\ \__    ___/____    ____ |  | __  ______
\   \/\/   /  _ \_  __ \  |   / __ |   /  _ \   __\    |    |  \__  \  /    \|  |/ / /  ___/
 \        (  <_> )  | \/  |__/ /_/ |  (  <_> )  |      |    |   / __ \|   |  \    <  \___ \ 
  \__/\  / \____/|__|  |____/\____ |   \____/|__|      |____|  (____  /___|  /__|_ \/____  >
       \/                         \/                                \/     \/     \/     \/ 
                           __________.__                                                    
                           \______   \__|_____ _____________                                
                            |       _/  \____ \\____ \_  __ \                               
                            |    |   \  |  |_> >  |_> >  | \/                               
                            |____|_  /__|   __/|   __/|__|                                  
                                   \/   |__|   |__|                                         

- World of Tanks Ripper
- v1.2.0
- by anonfoxer
- (c) 2019
- github.com/anonfoxer

");
            Console.WriteLine("1. Clear all replay files"); //clearReplays();
            Console.WriteLine("2. Verify all game files"); //verifyFiles();
            Console.WriteLine("3. Clear all mods from res_mods"); //clearMods();
            Console.WriteLine("4. Dump cef.log"); //cefDump();
            Console.WriteLine("5. Remove stuff from Curse/Twitch Client"); //thisDoesntWork();
            Console.WriteLine("6. Country Bias Finder"); //russianBias();
            Console.WriteLine("7. Info"); //informMe();



            var choice = Console.ReadLine();
            int bigChoice = Convert.ToInt32(choice);
            if (bigChoice == 1)
            {
                clearReplays();
            }
            if (bigChoice == 2)
            {
                verifyFiles();
            }
            if (bigChoice == 3)
            {
                clearMods();
            }
            if (bigChoice == 4)
            {
                cefDump();
            }
            if (bigChoice == 5)
            {
                thisDoesntWork();
            }
            if (bigChoice ==6)
            {
                russianBias();
            }
            if (bigChoice == 7)
            {
                informMe();
            }
        }

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
        public static void verifyFiles()
        {
            string[] files = System.IO.Directory.GetFiles(@"C:\Games\World_of_Tanks\", "*.*");
            foreach (string file in files)
            {
                Console.WriteLine($"{file} is present!");
                System.Threading.Thread.Sleep(300);
                //Everything kinda closes like this
                /* So a note to make about this is that this is not what i intend for this function to do.
                 * yes this does verify that files are existant but does not verify that files are missing nor does it check integrity.
                 * The hope is to keep a nice lil array or list or something of all the neccissarry files and directories that need to be there
                 * and have the tool check for them. that'll hopefully come to fruition. */
            }
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
            Console.WriteLine("anonhub.weebly.com");
            Console.WriteLine("github.com/anonfoxer");
            Console.WriteLine("v1.2.0 - More features coming soon");
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
        public static void thisDoesntWork()
        {
            string[] curseclient = System.IO.Directory.GetFiles(@"C:\Games\World_of_Tanks\", "*.curseclient");
            foreach (string file in curseclient)
            {
                System.IO.File.Delete(file);
                Console.WriteLine($"{file} was deleted");
            }
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
#endregion
            string[] replayslol = System.IO.Directory.GetFiles(@"C:\Games\World_of_Tanks\replays", "*.wotreplay");
            foreach (string file in replayslol)
            {
                #region checks
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
                #endregion
            }
            #region reveals
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
            //repeat for all nations
            Console.WriteLine("Press any key to close.");
            Console.ReadLine();
            #endregion
        }
    }

}

