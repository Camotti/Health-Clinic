using System.Numerics;
using healthclinic.models; //usamos la clase que esta en la carpeta models
namespace healthclinic.Services; // 

public class PatientService
{
    
    public void RegisterPatient(List<Patient> patients)
{
    try
    {
        Console.WriteLine("Name: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) //valida que nombre y síntoma no estén vacíos.
        {
            Console.WriteLine(" Name cannot be empty.");
            return;
        }

        Console.WriteLine("Age: ");
        if (!byte.TryParse(Console.ReadLine(), out byte age)) //convierte la edad a numero, sino mostrara un error
        {
            Console.WriteLine(" Invalid age. Please enter a valid number.");
            return;
        }

        Console.WriteLine("Symptom: ");
        string? symptom = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(symptom)) //valida que nombre y síntoma no estén vacíos.
        {
            Console.WriteLine(" Symptom empty.");
            return;
        }

            // preguntar por la mascota 

            Console.WriteLine("Does the patient have a pet? (yes/no): ");
            string? havePet = Console.ReadLine();

            Pet? pet = null;
            if (havePet?.ToLower() == "y")
            {
                Console.WriteLine("Pet name: ");
                string? petName = Console.ReadLine();

                Console.WriteLine("Pet Specie: ");
                string? petSpecie = Console.ReadLine();

                pet = new Pet
                {
                    Name = petName,
                    Specie = petSpecie
                }; 
            }
            
        patients.Add(new Patient
        {
            Name = name,
            Age = age,
            Symptom = symptom,
            Pet = pet
        });

        Console.WriteLine("✅ Patient registered successfully.");
        Console.WriteLine($"📋 Total patients: {patients.Count}");
    }
    catch (Exception error)
    {
        Console.WriteLine($"404 error occurred: {error.Message}");
    }
}





    public void ListPatients(List<Patient> patients)
    {
        if (patients.Count == 0)
        {
            Console.WriteLine("There isn't patients registered.");
            return;
        }
        
        else
        {
            foreach (var patient in patients)
            {
                string petInfo = patient.Pet != null ? $"{patient.Pet.Name} ({patient.Pet.Specie}), ID: {patient.Pet.Id}" : "No pet";
                Console.WriteLine($"Name: {patient.Name} , Age: {patient.Age} , Symptom: {patient.Symptom} , Pet: {petInfo} ");
            }   
        }
    }


    public void SearchPatient(List<Patient> patients, string name)
    {
        var patient = patients.FirstOrDefault(patient => patient.Name?.Equals(name, StringComparison.OrdinalIgnoreCase) == true);
        if (patient != null)
        {
            string petInfo = patient.Pet != null ? $"{patient.Pet.Name} ({patient.Pet.Specie})" : "Not pet"; 
            Console.WriteLine($"The patient: {patient.Name} , Age: {patient.Age} , Symptom: {patient.Symptom} , Pet: {petInfo}");
        }
        else
        {
            Console.WriteLine("Patient is not registed.");
        }
    }

}


