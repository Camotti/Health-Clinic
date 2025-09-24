using healthclinic.models; //usamos la clase que esta en la carpeta models
namespace healthclinic.Services; // 

public class PatientService
{
    public void RegisterPatient(List<Patient> patients)
    {
        Console.WriteLine("Name: ");
        string? name = Console.ReadLine();

        Console.WriteLine("Age: ");
        byte age = byte.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Symptom: ");
        string? symptom = Console.ReadLine();

        Console.WriteLine("Patient registered sucessfully. ");

    }

    public void ListPatients(List<Patient> patients)
    {
        if (patients.Count == 0)
        {
            Console.WriteLine("There isn't patients registered.");
            return;
        }
    
        foreach(var patient in patients)
        {
        Console.WriteLine($"Name: {patient.Name} , Age: {patient.Age} , Symptom: {patient.Symptom} ");
        }
    }
    
    


}
