using System;
using healthclinic.menus;

namespace healthclinic.menus
{
    public static class MainMenu
    {
        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("🏥 HEALTHCLINIC - MAIN MENU");
                Console.WriteLine("===================================");
                Console.WriteLine("1️⃣  Patient Menu");
                Console.WriteLine("2️⃣  Pet Menu");
                Console.WriteLine("3️⃣  Appointment Menu");
                Console.WriteLine("0️⃣  Exit");
                Console.Write("\nSelect an option: ");

                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        PatientMenu.Show();
                        break;
                    case "2":
                        var petMenu = new PetMenu();
                        petMenu.Show();
                        break;
                    case "3":
                        var appointmentMenu = new AppointmentMenu();
                        appointmentMenu.Show();
                        break;
                    case "0":
                        Console.WriteLine("👋 Exiting program...");
                        return;
                    default:
                        Console.WriteLine("⚠️ Invalid option, try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
            }
        }
    }
}