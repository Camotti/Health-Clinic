using healthclinic.services;
using healthclinic.utils;

namespace healthclinic.menus
{
    public static class PatientMenu
    {

        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===  MENÚ PACIENTES ===");
                Console.WriteLine("1️⃣ Registrar paciente");
                Console.WriteLine("2️⃣ Listar pacientes");
                Console.WriteLine("3️⃣ Buscar paciente por ID");
                Console.WriteLine("4️⃣ Actualizar paciente");
                Console.WriteLine("5️⃣ Eliminar paciente");
                Console.WriteLine("0️⃣ Volver al menú principal");
                Console.Write("\nSelecciona una opción: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Patientservice.RegisterPatient();
                        break;
                    case "2":
                        Patientservice.ListPatients();
                        break;
                    // case "3":
                    //     Patientservice.GetPatientById();
                    //     break;
                    // case "4":
                    //     Patientservice.UpdatePatient();
                    //     break;
                    // case "5":
                    //     Patientservice.DeletePatient();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("⚠️ Opción no válida.");
                        break;
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
