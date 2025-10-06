using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using healthclinic.models;
using healthclinic.Services;
using healthclinic.Interfaces;



List<Patient> patients = new(); // Patient list in memory
IPatientService service = new PatientService(); // aqui se cre un objeto para usar los metodos 

bool continueProgram = true; // variable para controlar el bucle del menu

// menu principal 
while (continueProgram) // mientras continueProgram sea true, el menu se seguira mostrando
{
    Console.WriteLine("\n ----- Main Menu -----");
    Console.WriteLine("1.Register Patient");
    Console.WriteLine("2.List Patients");
    Console.WriteLine("3.Search Patients");
    Console.WriteLine("4.General Query");
    Console.WriteLine("5.Vaccination");
    Console.WriteLine("6. Exit");
    Console.WriteLine("7. Send Notification to a patient");
    Console.WriteLine("Option: ");

    string? option = Console.ReadLine(); // lee la opcion del usuario

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
            string? name = Console.ReadLine() ?? ""; // si el usuario no ingresa nada, se asigna una cadena vacia
            service.SearchPatient(patients, name);
            break;
        case "4": // consulta general
            IAtendibles consultation = new Vaccination();
            consultation.AttendCustomer();
            break;

        case "5": // vacunacion
            IAtendibles  vaccination = new GeneralQuery();
            vaccination.AttendCustomer();
            break;

        case "6":
            continueProgram = false; // cambia la variable para salir del bucle
            break;

        case "7":
            
            if (patients.Count == 0)
            {
                foreach (var patient in patients)
                {
                    patient.SendNotification("This is reminder notification for your appointment tomorrow.");
                }
            }
            else
            {
                Console.WriteLine("No patients no notify.");
            }
            break;
            
        default:
            Console.WriteLine("Invalid option, try again.");
            break;
    }
}

// Fin del programa
Console.WriteLine("Exiting program. Goodbye!");







