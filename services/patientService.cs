using System;
using System.Collections.Generic;
using healthclinic.models;      // importamos los modelos
using healthclinic.Interfaces; // importamos la interfaz
using healthclinic.Exceptions; // importamos la excepción personalizada
using System.Linq;

namespace healthclinic.Services // definimos el espacio de trabajo
{
    public class PatientService : IPatientService
    {
        public void RegisterPatient(List<Patient> patients)
        {
            try
            {
                Console.WriteLine("Name: ");
                string? name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine(" Name cannot be empty.");
                    return;
                }

                Console.WriteLine("Age: ");
                if (!byte.TryParse(Console.ReadLine(), out byte age))
                {
                    Console.WriteLine(" Invalid age. Please enter a valid number.");
                    return;
                }

                Console.WriteLine("Symptom: ");
                string? symptom = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(symptom))
                {
                    Console.WriteLine(" Symptom empty.");
                    return;
                }

                // Preguntar por mascotas
                List<Pet> pets = new();
                Console.WriteLine("How many pets does the patient have?");
                if (int.TryParse(Console.ReadLine(), out int petCount) && petCount > 0)
                {
                    for (int i = 0; i < petCount; i++)
                    {
                        Console.WriteLine($"Pet {i + 1} name: ");
                        string? petName = Console.ReadLine();

                        Console.WriteLine($"Pet {i + 1} specie: ");
                        string? petSpecie = Console.ReadLine();

                        pets.Add(new Pet
                        {
                            Name = petName,
                            Specie = petSpecie
                        });
                    }
                }

                patients.Add(new Patient
                {
                    Name = name,
                    Age = age,
                    
                    Pets = pets
                });

                Console.WriteLine("✅ Patient registered successfully.");
                Console.WriteLine($"📋 Total patients: {patients.Count}");
            }
            catch (Exception error)
            {
                Console.WriteLine($" Error occurred: {error.Message}");
            }
        }

        public void ListPatients(List<Patient> patients)
        {
            if (patients.Count == 0)
            {
                Console.WriteLine("There aren't patients registered.");
                return;
            }

            foreach (var patient in patients)
            {
                Console.WriteLine($"\n Patient Name: {patient.Name}, Age: {patient.Age} , ID: {patient.Id}");

                if (patient.Pets.Count > 0)
                {
                    Console.WriteLine(" Pets:");
                    foreach (var pet in patient.Pets)
                    {
                        Console.WriteLine($" The name {pet.Name} and the specie: ({pet.Specie}), ID: {pet.Id}");
                    }
                }
                else
                {
                    Console.WriteLine(" No pets.");
                }
            }
        }

        public void SearchPatient(List<Patient> patients, string name)
        {
            try
            {
                var patient = patients.FirstOrDefault(patient =>
                    patient.Name?.Equals(name, StringComparison.OrdinalIgnoreCase) == true);

                if (patient == null)
                {
                    Console.WriteLine("The patient is not registered.");
                    return;
                }

                Console.WriteLine($"The patient {patient.Name} , Age: {patient.Age}, ID: {patient.Id} found successfully.");

                if (patient.Pets == null || patient.Pets.Count == 0)
                {
                    throw new PwfiException($"The patient {patient.Name} doesn't have pets registered.");
                }

                Console.WriteLine(" Pets:");
                foreach (var pet in patient.Pets)
                {
                    Console.WriteLine($" Pet Name: {pet.Name} Specie: {pet.Specie} ");
                }
            }
            catch (PwfiException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Search operation finished.");
            }
        }
    }
}