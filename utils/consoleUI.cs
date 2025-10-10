using System;

namespace healthclinic.utils
{
    
    /// Utility class for displaying menus in the HealthClinic system console.
    
    public class ConsoleUI
    {
       
        /// Displays the main menu of the application on the console.
       
        public static void ShowMainMenu()
        {
            
            Console.WriteLine("1️⃣  Patient Management 🐾");
            Console.WriteLine("2️⃣  Veterinarian Management 👨‍⚕️");
            Console.WriteLine("3️⃣  Appointment Management 📅");
            Console.WriteLine("4️⃣  Exit 🚪");
        }

        
        /// Displays the patient CRUD menu on the console.
       
        public static void ShowPatientMenu()
        {
            Console.WriteLine("\n📋 Patient Menu:");
            Console.WriteLine("1️⃣  Register Patient");
            Console.WriteLine("2️⃣  List Patients");
            Console.WriteLine("3️⃣  Search Patient");
            Console.WriteLine("4️⃣  Back to Main Menu 🔙");
        }

        
        /// Displays the veterinarian CRUD menu on the console.
        
        public static void ShowVeterinarianMenu()
        {
            Console.WriteLine("\n📋 Veterinarian Menu:");
            Console.WriteLine("1️⃣  Register Veterinarian");
            Console.WriteLine("2️⃣  List Veterinarians");
            Console.WriteLine("3️⃣  Search Veterinarian");
            Console.WriteLine("4️⃣  Back to Main Menu 🔙");
        }

        /// <summary>
        /// Displays the appointment menu on the console.
        /// </summary>
        public static void ShowAppointmentMenu()
        {
            Console.WriteLine("\n📋 Appointment Menu:");
            Console.WriteLine("1️⃣  Schedule Appointment");
            Console.WriteLine("2️⃣  List Appointments");
            Console.WriteLine("3️⃣  General Query");
            Console.WriteLine("4️⃣  Vaccination");
            Console.WriteLine("5️⃣  Send Notifications");
            Console.WriteLine("6️⃣  Back to Main Menu 🔙");
        }
    }
}