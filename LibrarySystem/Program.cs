using ConsoleTheme;
using LibrarySystem.Helpers;
using LibrarySystem.Models;
using LibrarySystem.Services;

namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //seeding the data 
            LibraryBranch branch = DataSeeder.seed();
            DisplayServices display = new();
            LibraryServices libraryServices=new(branch, display);

            bool running = true;
            while (running)
            {
                try
                {
                    ConsoleHelper.ShowMenu();
                    string? choice = Console.ReadLine()?.Trim();
                    switch (choice)
                    {
                        case "1":
                            display.ShowBranchInfo(branch);
                            break;
                        case "2":
                            display.ShowAllUsers(branch);
                            break;
                        case "3":
                            display.ShowAvailableCopies(branch);
                            break;
                         case "4":
                            display.ShowAllBookCopies(branch);
                            break;
                        case "5":
                            libraryServices.HandleBorrow();
                            break;
                        case "6":
                            libraryServices.HandleReturn();
                            break;
                        case "7":
                            libraryServices.HandleHistory();
                            break;
                        case "8":
                            libraryServices.HandleRegisterMember();
                            break;
                        case "0":
                            running = false;
                            Console.WriteLine("GoodBye");
                            break;

                        default:
                            Console.WriteLine("Invalid Opptions");
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Press Enter To Continue......");
                Console.ReadLine();

                Console.Clear(); 
            }

            // show the menu 

            // Take option from user 

        }
    }
}
