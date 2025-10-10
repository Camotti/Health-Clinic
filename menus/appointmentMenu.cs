using healthclinic.models;
using healthclinic.repositories;
using healthclinic.utils;
using healthclinic.services;

namespace healthclinic.menus;
public class AppointmentMenu
{
    private static readonly AppointmentService _service = new AppointmentService();

    public static void Show()
    {
        while (true)
        {
            ConsoleUI.ShowMainMenu();

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
                case 5:
                    UpdateAppointment();
                    break;

                case 0:
                    return;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }
    }

    private static void AddAppointment()
    {
        try
        {
            // Instanciar repositorio de mascotas y mostrar listado
            var petRepository = new petRepository();
            var pets = petRepository.GetAll();
            if (pets.Count == 0)
            {
                Console.WriteLine("La lista de mascotas esta vacia");
                return;
            }
            Console.WriteLine("Listado de mascotas:");
            foreach (var pet in pets)
            {
                Console.WriteLine($"ID: {pet.Id} | Nombre: {pet.Name}");
            }

            var petId = ConsoleHelper.ReadGuid("Ingrese el ID de la mascota: ");

            // Instanciar repositorio de veterinarios y mostrar listado
            var veterinarianRepository = new VeterinarianRepository();
            var veterinarians = veterinarianRepository.GetAll();
            if (veterinarians.Count == 0)
            {
                Console.WriteLine("La lista de veterinarios esta vacia");
                return;
            }
            Console.WriteLine("Listado de veterinarios:");
            foreach (var vet in veterinarians)
            {
                Console.WriteLine($"ID: {vet.Id} | Nombre: {vet.Name}");
            }

            var vetId = ConsoleHelper.ReadGuid("Ingrese el ID del veterinario: ");

            var date = ConsoleHelper.ReadDate("Fecha (dd/MM/yyyy): ");
            var reason = ConsoleHelper.ReadNonEmptyString("Motivo de la cita: ");

            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                PetId = petId,
                VeterinarianID = vetId,
                Date = date,
                Reason = reason
            };

            _service.Add(appointment);
            Console.WriteLine("Cita registrada con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al registrar la cita: {ex.Message}");
        }
    }

    private static void ListAppointments()
    {
        try
        {
            var list = _service.GetAll();
            if (list.Count == 0)
            {
                Console.WriteLine("No hay citas registradas.");
                return;
            }

            foreach (var a in list)
            {
                Console.WriteLine($"ID: {a.Id} | Fecha: {a.Date:dd/MM/yyyy} | Motivo: {a.Reason} | MascotaID: {a.PetId} | VetID: {a.VeterinarianID}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al listar las citas: {ex.Message}");
        }
    }

    private static void GetAppointmentById()
    {
        try
        {
            ListAppointments();
            var id = ConsoleHelper.ReadGuid("Ingrese el ID de la cita: ");
            var appointment = _service.GetById(id);

            if (appointment == null)
            {
                Console.WriteLine("Cita no encontrada.");
                return;
            }

            Console.WriteLine($"ID: {appointment.Id} | Fecha: {appointment.Date:dd/MM/yyyy} | Motivo: {appointment.Reason} | MascotaID: {appointment.PetId} | VetID: {appointment.VeterinarianID}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al buscar la cita: {ex.Message}");
        }
    }

    private static void DeleteAppointment()
    {
        try
        {
            var id = ConsoleHelper.ReadGuid("Ingrese el ID de la cita a eliminar: ");
            _service.Delete(id);
            Console.WriteLine("Cita eliminada con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al eliminar la cita: {ex.Message}");
        }
    }


    private static void UpdateAppointment()
    {
        try
        {
            ListAppointments(); // Mostrar todas las citas para que el usuario pueda seleccionar una
            var id = ConsoleHelper.ReadGuid("Ingrese el ID de la cita a actualizar: ");
            var appointment = _service.GetById(id);

            if (appointment == null)
            {
                Console.WriteLine("Cita no encontrada.");
                return;
            }

            Console.WriteLine("Deje el campo vacío para mantener el valor actual.");

            DateTime? newDate = null;
            try
            {
                newDate = ConsoleHelper.ReadDate("Nueva fecha (dd/MM/yyyy): ");
            }
            catch
            {
                Console.WriteLine("Si el usuario deja todo vacio");
            }

            string newReason = ConsoleHelper.ReadNonEmptyString("Nuevo motivo de la cita: ");

            if (newDate.HasValue)
            {
                appointment.Date = newDate.Value;
            }

            if (!string.IsNullOrWhiteSpace(newReason))
            {
                appointment.Reason = newReason;
            }

            _service.Update(appointment); // Asegúrate de implementar este método en AppointmentService
            Console.WriteLine("Cita actualizada con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al actualizar la cita: {ex.Message}");
        }
    }











}


