using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using healthclinic.models;
using healthclinic.Services;




List<Patient> patients = new();
var service = new PatientService(); // aqui se cre un objeto para usar los metodos 

bool continueProgram = true;

// menu principal 
while (continueProgram)
{
    Console.WriteLine("\n ----- Main Menu -----");
    Console.WriteLine("1.Register Patient");
    Console.WriteLine("2.List Patients");
    Console.WriteLine("3.Search Patients");
    Console.WriteLine("4. Exit");
    Console.WriteLine("Option: ");

    string? option = Console.ReadLine();

    switch (option)
    {
        case "1":
            service.RegisterPatient(patients);
            break;
        case "2":
            service.ListPatients(patients);
            break;
        case "3":
            Console.WriteLine("Enter patient name: ");
            string? name = Console.ReadLine() ?? "";
            service.SearchPatient(patients, name);
            break;
        case "4":
            continueProgram = false;
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}








