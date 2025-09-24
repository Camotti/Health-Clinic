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
}
