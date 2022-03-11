using System;
using System.IO;

namespace attempt3
{

    class MainClass
    {
        public static void Main()
        {
            ControlClass.DebugLogger("PROGRAM INITIALING");
            ControlClass.DebugLogger("SUCCESS");

            ControlClass.DebugLogger("VERSION 0.0.2 - PRE-ALPHA");
            ControlClass.ControlMain();
        }

        //STARTING PROMPT - ALLOWS FOR EXECUTION OF COMMANDS AND STARTING INDIVIDUAL SUBSTATES.

        public static void MainPrompt()
        {
            ControlClass.DebugLogger("DEBUG: MainClass.MainPrompt Called Successfully");

            ControlClass.InputPrompt("Please enter a string.");

            string sussy = Console.ReadLine();
            string sussyFixed = sussy.ToLower();

            switch (sussyFixed) //MAIN SWITCHBOARD - HANDLES USER INPUT IN THE STARTING PROMPT. EACH COMMAND REQUIRES A SHORTHAND VERSION TO ALLOW CONSISTENCY.
            {
                case "clear":
                case "c":
                    Console.Clear();
                    ControlClass.UserOutputLogger("Cleared Terminal.");
                    MainClass.MainPrompt();
                    break;
                case "list":
                case "l":
                    ControlClass.List();
                    MainClass.MainPrompt();
                    break;
                case "start 1":
                case "s1":
                    ControlClass.UserOutputLogger("Start configuration 1 selected, proceed?");
                    ControlClass.InputPrompt("y / n");
                    ControlClass.Start1Handler();
                    break;
                case "version info":
                case "vi":
                    ControlClass.VersionInfo();
                    break;
                default:
                    ControlClass.UserOutputLogger("Invalid input, please try again. Input: " + sussy);
                    MainClass.MainPrompt();
                    break;
            }
        }
    }

    


    class ControlClass
    {
        public static string VIlocation = "/Users/matthewthomas/Projects/attempt3/attempt3/VersionInfo.txt";
        public static string Llocation = "/Users/matthewthomas/Projects/attempt3/attempt3/List.txt";

        public static void ControlMain()
        {
            ControlClass.DebugLogger("DEBUG: ControlClass.ControlMain Called Successfully");
            MainClass.MainPrompt();
        }

        //START HANDLERS - HANDLES THE START OF EACH STATE.

        public static void Start1Handler()
        {
            string userResponse = Console.ReadLine();
            string fixedUserResponse = userResponse.ToLower();
            switch (fixedUserResponse)
            {
                case "y":
                    Console.Clear();
                    ControlClass.UserOutputLogger("Continuing...");
                    break;
                case "n":
                    Console.Clear();
                    MainClass.MainPrompt();
                    break;
                default:
                    MainClass.MainPrompt();
                    break;
            }
        }

        //PASSWORD READER - READS PASSWORD REQUIRED FOR SUPER COMMANDS.

        public static void PasswordReader()
        {
            string passwordInput = Console.ReadLine();
            string passwordFixed = passwordInput.ToLower();
            string passwordRequired = "test";

            if (passwordFixed == passwordRequired)
            {
                Console.Clear();
                ControlClass.UserOutputLogger("Password accepted");

            }
            else
            {
                ControlClass.UserOutputLogger("INCORRECT PASSWORD");
                MainClass.MainPrompt();
            }
        }

        //VERSION INFO - DISPLAYS THE CONTENTS OF VERSIONINFO.TXT, UPDATE THIS FILE AFTER EVERY MAJOR CHANGE.

        public static void VersionInfo()
        {
            StreamReader sr = new StreamReader(ControlClass.VIlocation);

            while (sr.EndOfStream != true)
            {
                UserOutputLogger(sr.ReadLine());
            }
            MainClass.MainPrompt();
        }

        //LIST - LIST NOW READS FROM AN EASILY EXPANDABLE TXT FILE.

        public static void List()
        {
            StreamReader sr = new StreamReader(ControlClass.Llocation);

            while (sr.EndOfStream != true)
            {
                UserOutputLogger(sr.ReadLine());
            }
            MainClass.MainPrompt();
        }

        //LOGGING METHODS - EACH METHOD CONTAINS A BRIEF DESCRIPTION OF THEIR USECASES.

        public static void DebugLogger(string DebugMessage) //Use for debugging only.
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(DebugMessage);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void UserOutputLogger(string OutputMessage) //Use to respod to user input.
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(OutputMessage);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void InputPrompt(string InputMessage) //Request user input.
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(InputMessage);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
