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

            ControlClass.DebugLogger("VERSION 0.0.4 - PRE-ALPHA");
            ControlClass.ControlMain();
        }

        //STARTING PROMPT - ALLOWS FOR EXECUTION OF COMMANDS AND STARTING INDIVIDUAL SUBSTATES.

        public static void MainPrompt()
        {
            ControlClass.DebugLogger("DEBUG: MainClass.MainPrompt Called Successfully");
            if (Global.passwordFlag == true)
            {
                ControlClass.DebugLogger("DEBUG: PASSWORDFLAG = TRUE");
            }

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
                    StateOne.Start1Handler();
                    break;
                case "version info":
                case "vi":
                    ControlClass.VersionInfo();
                    break;
                case "password reader":
                case "pr":
                    ControlClass.PasswordReader();
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
        public static string VIlocation = "Replace with path to VersionInfo";
        public static string Llocation = "Replace with path to List";
        public static string PLocation = "Replace with path to Password.TXT";

        public static void ControlMain()
        {
            ControlClass.DebugLogger("DEBUG: ControlClass.ControlMain Called Successfully");
            MainClass.MainPrompt();
        }

        //PASSWORD READER - Reads password for supercommands.

        public static void PasswordReader()
        {
            StreamReader sr = new StreamReader(ControlClass.PLocation);

            string passwordInput = Console.ReadLine();

            if (passwordInput == sr.ReadLine())
            {
                Console.Clear();
                ControlClass.UserOutputLogger("Password accepted");
                sr.Close();
                Global.passwordFlag = true;
                MainClass.MainPrompt();
            }
            else
            {
                ControlClass.UserOutputLogger("INCORRECT PASSWORD");
                MainClass.MainPrompt();
            }
        }

        //VERSION INFO - Displays info of VersionInfo, do be changed after every update.

        public static void VersionInfo()
        {
            StreamReader sr = new StreamReader(ControlClass.VIlocation);

            while (sr.EndOfStream != true)
            {
                UserOutputLogger(sr.ReadLine());
            }
            MainClass.MainPrompt();
        }

        //LIST - List now reads from a txt file.

        public static void List()
        {
            StreamReader sr = new StreamReader(ControlClass.Llocation);

            while (sr.EndOfStream != true)
            {
                UserOutputLogger(sr.ReadLine());
            }
            MainClass.MainPrompt();
        }

        //LOGGING METHODS - Each method briefly describes their usecases.

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

    //STATEONE - All code related to StateOne resides here.

    class StateOne 
    {
        public static void StateController() 
        {
            ControlClass.DebugLogger("DEBUG: StateOne.StateController() Called Successfully");
        }

        public static void Start1Handler()
        {
            string userResponse = Console.ReadLine();
            string fixedUserResponse = userResponse.ToLower();
            switch (fixedUserResponse)
            {
                case "y":
                    Console.Clear();
                    ControlClass.UserOutputLogger("Continuing...");
                    StateOne.StateController();
                    break;
                case "n":
                    Console.Clear();
                    MainClass.MainPrompt();
                    break;
                default:
                    StateOne.StateController();
                    break;
            }
        }
    }

    //GLOBAL - USED FOR GLOBAL FLAGS SUCH AS PASSWORDFLAG.

    class Global 
    {
        public static bool passwordFlag = false;

    }
}
