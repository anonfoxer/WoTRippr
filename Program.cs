using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WoTTool
{
    class Program
    {
        static readonly string rootFolder = @"C:\Games\World_of_Tanks\res_mods\";
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine(@" 
 __      __            .__       .___       ___________ ___________              __            
/  \    /  \___________|  |    __| _/   ____\_   _____/ \__    ___/____    ____ |  | __  ______
\   \/\/   /  _ \_  __ \  |   / __ |   /  _ \|    __)     |    |  \__  \  /    \|  |/ / /  ___/
 \        (  <_> )  | \/  |__/ /_/ |  (  <_> )     \      |    |   / __ \|   |  \    <  \___ \ 
  \__/\  / \____/|__|  |____/\____ |   \____/\___  /      |____|  (____  /___|  /__|_ \/____  >
       \/                         \/             \/                    \/     \/     \/     \/ 
                         __________.__                                                         
                         \______   \__|_____ ______   ___________                              
                          |       _/  \____ \\____ \_/ __ \_  __ \                             
                          |    |   \  |  |_> >  |_> >  ___/|  | \/                             
                          |____|_  /__|   __/|   __/ \___  >__|                                
                                 \/   |__|   |__|        \/                                    


- World of Tanks Ripper
- v1.0.0
- by anonfoxer
- (c) 2019
- github.com/anonfoxer

");
            Console.WriteLine("1. Clear all replay files");
            Console.WriteLine("2. Verify all game files");
            Console.WriteLine("3. Clear all mods from res_mods");
            Console.WriteLine("4. Info");


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
        }
            public static void verifyFiles()
        {
            string[] files = System.IO.Directory.GetFiles(@"C:\Games\World_of_Tanks\", "*.*");
            foreach (string file in files)
            {
                Console.WriteLine($"{file} is present!");
                System.Threading.Thread.Sleep(300);
            }
            string[] files2 = System.IO.Directory.GetFiles(@"C:\\Games\World_of_Tanks\\", "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                Console.WriteLine($"{file} is present!");
                System.Threading.Thread.Sleep(300);
            }
        }
        public static void clearMods()
        {
            string[] files = Directory.GetFiles(rootFolder);
            foreach (string file in files)
            {
                File.Delete(file);
                Console.WriteLine($"{file} was deleted.");
            }
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
            Console.WriteLine("v1.0.0 - More features coming soon");
            Console.WriteLine(" ");
            Console.WriteLine("1) Exit");
            var choice2 = Console.ReadLine();
            int bigChoice2 = Convert.ToInt32(choice2);

            if (bigChoice2 == 1)
            {
                Exit();
            }
        }

            public static void Exit()
        {
            System.Environment.Exit(0);
        }
    }
}
