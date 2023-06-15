using System;
using System.Collections.Generic;
using TabloidCLI.UserInterfaceManagers;

namespace TabloidCLI
{
    class Program
    {
        static void Main(string[] args)
        {
                

            IUserInterfaceManager ui = new MainMenuManager();
            while (ui != null)
            {
                PrintMainMenu();
                string selection = GetMenuSelection();

                switch (selection)
                {
                    case ("List Posts"):
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case ("Add Post"):
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case ("Edit Post"):
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case ("Remove Post"):
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case ("Note Management"):
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    case ("Return to Main Menu"):
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
        }

        static void PrintPleasantGreeting()
        {
            Console.WriteLine("Welcome to the Tabloid Application!");
            Console.WriteLine("We hope you have a pleasant experience.");
            Console.WriteLine();
        }

        static void PrintMainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1) My Journal Management");
            Console.WriteLine("2) Blog Management");
            Console.WriteLine("3) Author Management");
            Console.WriteLine("4) Post Management");
            Console.WriteLine("5) Tag Management");
            Console.WriteLine("6) Search by Tag");
            Console.WriteLine("7) Exit");
            Console.WriteLine();
        }

        static string GetMenuSelection()
        {
            Console.Clear();

            PrintPleasantGreeting();

            Console.Write("Menu Selection: ");
            Console.WriteLine("");
            List<string> options = new List<string>()
            {
                 "List Posts",
                 "Add Post",
                 "Edit Post",
                 "Remove Post",
                 "Note Management",
                 "Return to Main Menu",
            };

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write("Select an option > ");

                    string input = Console.ReadLine();
                    int index = int.Parse(input) - 1;
                    return options[index];
                }
                catch (Exception)
                {

                    continue;
                }
            }
        }
    }
}