using healthclinic.models;
using healthclinic.Repositories;
using healthclinic.utils;

namespace healthclinic.menus
{
    public static class PatientMenu
    {
        private static readonly PatientRepository _patientRepo = new();

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
                    case "1": AddPatient(); break;
                    case "2": ListPatients(); break;
                    case "3": GetPatientById(); break;
                    case "4": UpdatePatient(); break;
                    case "5": DeletePatient(); break;
                    case "0": return;
                    default: Console.WriteLine("⚠️ Opción no válida."); break;
                }

                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void AddPatient()
        {
            var name = ConsoleHelper.ReadNonEmptyString("Nombre: ");
            var age = ConsoleHelper.Readbyte("Edad: ");
            var email = ConsoleHelper.ReadNonEmptyString("Email: ");
            var phone = ConsoleHelper.ReadNonEmptyString("Teléfono: ");
            var gender = ConsoleHelper.ReadNonEmptyString("Género: ");

            var patient = new Patient { Name = name, Age = age, Email = email, Phone = phone, Gender = gender };
            _patientRepo.Add(patient);

            Console.WriteLine("✅ Paciente registrado correctamente.");
        }

        private static void ListPatients()
        {
            if(_patientRepo.GetAll().Count == 0){ return; }
            Console.WriteLine("\n📋 Lista de pacientes:");
            foreach (var p in _patientRepo.GetAll())
                Console.WriteLine($"🧍 {p.Id} | {p.Name} | {p.Email} | {p.Gender}");
        }

        private static void GetPatientById()
        {
            if (_patientRepo.GetAll().Count == 0) { return; }
            ListPatients();
            var id = ConsoleHelper.ReadGuid("Ingrese el ID del paciente: ");
            var p = _patientRepo.GetById(id);
            if (p != null)
                Console.WriteLine($"✅ Encontrado: {p.Name} ({p.Email})");
            else
                Console.WriteLine("❌ Paciente no encontrado.");
        }

        private static void UpdatePatient()
        {
            if (_patientRepo.GetAll().Count == 0) { return; }
            ListPatients();
            var id = ConsoleHelper.ReadGuid("ID del paciente a actualizar: ");
            var p = _patientRepo.GetById(id);
            if (p == null)
            {
                Console.WriteLine("❌ No se encontró el paciente.");
                return;
            }

            var name = ConsoleHelper.ReadNonEmptyString("Nuevo nombre: ");
            var email = ConsoleHelper.ReadNonEmptyString("Nuevo email: ");
            var phone = ConsoleHelper.ReadNonEmptyString("Nuevo teléfono: ");

            p.Name = name;
            p.Email = email;
            p.Phone = phone;

            _patientRepo.Update(p);
            Console.WriteLine("✅ Paciente actualizado correctamente.");
        }

        private static void DeletePatient()
        {
            if(_patientRepo.GetAll().Count == 0){ return; }
            ListPatients();
            var id = ConsoleHelper.ReadGuid("ID del paciente a eliminar: ");
            _patientRepo.Delete(id);
            Console.WriteLine("🗑️ Paciente eliminado correctamente.");
        }
    }
}