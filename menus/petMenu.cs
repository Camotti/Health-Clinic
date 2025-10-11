using healthclinic.services;
using healthclinic.utils;
using System;

namespace healthclinic.menus
{
    public class PetMenu
    {
        private static readonly Petservice _petService = new Petservice();

        public static void Show()
        {
            int option;

            do
            {
                Console.Clear();
                Console.WriteLine("===== 🐾 Pets Menu =====");
                Console.WriteLine("1. Register a new Pet");
                Console.WriteLine("2. List all Pets");
                Console.WriteLine("3. Search Pet by ID");
                Console.WriteLine("4. Update Pet");
                Console.WriteLine("5. Delete Pet");
                Console.WriteLine("0. Return to the Main Menu");

                option = ConsoleHelper.ReadInt("Select one option: ");

                switch (option)
                {
                    case 1:
                        _petService.Add();
                        break;
                    case 2:
                        _petService.List();
                        break;
                    case 3:
                        _petService.GetById();
                        break;
                    case 4:
                        _petService.Update();
                        break;
                    case 5:
                        _petService.Delete();
                        break;
                    case 0:
                        Console.WriteLine("Returning to main menu...");
                        break;
                    default:
                        Console.WriteLine("❌ Invalid option.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

            } while (option != 0);
        }
    }
}
