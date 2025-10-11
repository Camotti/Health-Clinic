using System;
using System.Collections.Generic;
using healthclinic.models;
using healthclinic.repositories;
using healthclinic.utils;

namespace healthclinic.services
{
    public class AppointmentService
    {
        private readonly AppointmentRepository _repository = new AppointmentRepository();
        private readonly PetRepository _petRepository = new PetRepository();
        private readonly VeterinarianRepository _vetRepository = new VeterinarianRepository();

        public void AddAppointment()
        {
            try
            {
                var pets = _petRepository.GetAll();
                if (pets.Count == 0)
                {
                    Console.WriteLine("The Pet list cannot be empty");
                    return;
                }

                Console.WriteLine("Pets List:");
                foreach (var pet in pets)
                    Console.WriteLine($"ID: {pet.Id} | Name: {pet.Name}");

                var petId = ConsoleHelper.ReadGuid("Get into the Pet ID: ");

                var veterinarians = _vetRepository.GetAll();
                if (veterinarians.Count == 0)
                {
                    Console.WriteLine("The Veterinarian list is empty");
                    return;
                }

                Console.WriteLine("Veterinarians List:");
                foreach (var vet in veterinarians)
                    Console.WriteLine($"ID: {vet.Id} | Name: {vet.Name}");

                var vetId = ConsoleHelper.ReadGuid("Get into by the Veterinarian ID: ");
                var date = ConsoleHelper.ReadDate("Date (dd/MM/yyyy): ");
                var reason = ConsoleHelper.ReadNonEmptyString("Appointment Reason: ");

                var appointment = new Appointment
                {
                    Id = Guid.NewGuid(),
                    PetId = petId,
                    VeterinarianID = vetId,
                    Date = date,
                    Reason = reason
                };

                _repository.Add(appointment);
                Console.WriteLine("Appointment successfully registered.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error at register the appointment: {ex.Message}");
            }
        }

        public void ListAppointments()
        {
            try
            {
                var list = _repository.GetAll();
                if (list.Count == 0)
                {
                    Console.WriteLine("There is not appointment registered.");
                    return;
                }

                foreach (var a in list)
                {
                    Console.WriteLine($"ID: {a.Id} | Date: {a.Date:dd/MM/yyyy} | Reason: {a.Reason} | PetID: {a.PetId} | VetID: {a.VeterinarianID}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error listing appointments: {ex.Message}");
            }
        }

        public void GetAppointmentById()
        {
            try
            {
                ListAppointments();
                var id = ConsoleHelper.ReadGuid("Enter the appointment ID: ");
                var appointment = _repository.GetById(id);

                if (appointment == null)
                {
                    Console.WriteLine("Appointment not found.");
                    return;
                }

                Console.WriteLine($"ID: {appointment.Id} | Date: {appointment.Date:dd/MM/yyyy} | Reason: {appointment.Reason} | PetID: {appointment.PetId} | VetID: {appointment.VeterinarianID}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching appointment: {ex.Message}");
            }
        }

        public void DeleteAppointment()
        {
            try
            {
                var id = ConsoleHelper.ReadGuid("Enter the appointment ID to delete: ");
                _repository.Delete(id);
                Console.WriteLine("Appointment successfully deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting appointment: {ex.Message}");
            }
        }

        public void UpdateAppointment()
        {
            try
            {
                ListAppointments();

                var id = ConsoleHelper.ReadGuid("Enter the appointment ID to update: ");
                var appointment = _repository.GetById(id);

                if (appointment == null)
                {
                    Console.WriteLine("Appointment not found.");
                    return;
                }

                Console.WriteLine("Leave empty to keep current value.");

                // Read new date
                Console.Write("New date (dd/MM/yyyy) or press ENTER to keep current: ");
                var dateInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(dateInput))
                {
                    if (DateTime.TryParseExact(dateInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var newDate))
                    {
                        appointment.Date = newDate;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format, keeping current date.");
                    }
                }

                // Read new reason
                Console.Write("New reason or press ENTER to keep current: ");
                var reasonInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(reasonInput))
                {
                    appointment.Reason = reasonInput.Trim();
                }

                _repository.Update(appointment);
                Console.WriteLine("Appointment updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating appointment: {ex.Message}");
            }
        }
    }
}
