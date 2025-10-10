using healthclinic.models;
using healthclinic.Services;
using healthclinic.utils;
using healthclinic.services;
using System;

namespace healthclinic.menus
{
    public class AppointmentMenu
    {
        private readonly AppointmentService _service = new AppointmentService();

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n=== Menú de Citas ===");
                Console.WriteLine("1. Registrar cita");
                Console.WriteLine("2. Listar citas");
                Console.WriteLine("3. Buscar cita por ID");
                Console.WriteLine("4. Eliminar cita");
                Console.WriteLine("0. Volver al menú principal");

                int option = ConsoleHelper.ReadInt("Seleccione una opción: ");

                switch (option)
                {
                    case 1:
                        AddAppointment();
                        break;
                    case 2:
                        ListAppointments();
                        break;
                    case 3:
                        GetAppointmentById();
                        break;
                    case 4:
                        DeleteAppointment();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }

        private void AddAppointment()
        {
            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                PetId = ConsoleHelper.ReadGuid(),
                VeterinarianID = ConsoleHelper.ReadGuid(),
                Date = ConsoleHelper.ReadDate("Fecha (dd/MM/yyyy): "),
                Reason = ConsoleHelper.ReadNonEmptyString("Motivo de la cita: ")
            };

            _service.Add(appointment);
            Console.WriteLine("Cita registrada con éxito.");
        }

        private void ListAppointments()
        {
            var list = _service.GetAll();
            if (list.Count == 0)
            {
                Console.WriteLine("No hay citas registradas.");
                return;
            }

            foreach (var a in list)
            {
                Console.WriteLine($"ID: {a.Id} | Fecha: {a.Date} | Motivo: {a.Reason} | MascotaID: {a.PetId} | VetID: {a.VeterinarianID}");
            }
        }

        private void GetAppointmentById()
        {
            var id = ConsoleHelper.ReadGuid();
            var appointment = _service.GetById(id);

            if (appointment == null)
            {
                Console.WriteLine("Cita no encontrada.");
                return;
            }

            Console.WriteLine($"ID: {appointment.Id} | Fecha: {appointment.Date} | Motivo: {appointment.Reason}");
        }

        private void DeleteAppointment()
        {
            var id = ConsoleHelper.ReadGuid();
            _service.Delete(id);
            Console.WriteLine("Cita eliminada con éxito.");
        }
    }
}