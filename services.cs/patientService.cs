using healthclinic.models;
namespace healthclinic.Services;

public class PatientService
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
                Symptom = symptom,
                Pets = pets   // aquí va la lista
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
            Console.WriteLine($"\nName: {patient.Name}, Age: {patient.Age}, Symptom: {patient.Symptom}");

            if (patient.Pets.Count > 0)
            {
                Console.WriteLine(" Pets:");
                foreach (var pet in patient.Pets)
                {
                    Console.WriteLine($"   - {pet.Name} ({pet.Specie}), ID: {pet.Id}");
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
        var patient = patients.FirstOrDefault(patient =>
            patient.Name?.Equals(name, StringComparison.OrdinalIgnoreCase) == true);

        if (patient != null)
        {
            Console.WriteLine($"Patient: {patient.Name}, Age: {patient.Age}, Symptom: {patient.Symptom}");

            if (patient.Pets.Count > 0)
            {
                Console.WriteLine(" Pets:");
                foreach (var pet in patient.Pets)
                {
                    Console.WriteLine($"   - {pet.Name} ({pet.Specie})");
                }
            }
            else
            {
                Console.WriteLine(" No pets.");
            }
        }
        else
        {
            Console.WriteLine("Patient is not registered.");
        }
    }
}