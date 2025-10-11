using healthclinic.models;
using healthclinic.repositories;
using healthclinic.utils;
using healthclinic.services;

namespace healthclinic.menus
{
    public class AppointmentMenu
    {
        private static readonly AppointmentService _service = new AppointmentService();

        public static void Show()
        {
            while (true)
            {
                ConsoleUI.ShowMainMenu();

                int option = ConsoleHelper.ReadInt("Select one option: ");

                switch (option)
                {
                    case 1:
                        _service.AddAppointment();
                        break;
                    case 2:
                        _service.ListAppointments();
                        break;
                    case 3:
                        _service.GetAppointmentById();
                        break;
                    case 4:
                        _service.DeleteAppointment();
                        break;
                    case 5:
                        _service.UpdateAppointment(); // Llamamos aquí, la lógica va en el servicio
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
