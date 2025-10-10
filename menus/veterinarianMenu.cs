using healthclinic.models;
using healthclinic.services;
using healthclinic.utils;


namespace healthclinic.menus
{
    public class VeterinarianMenu
    {
        private readonly VeterinarianService _service = new VeterinarianService();

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n=== Menú de Veterinarios ===");
                Console.WriteLine("1. Registrar veterinario");
                Console.WriteLine("2. Listar veterinarios");
                Console.WriteLine("3. Buscar veterinario por ID");
                Console.WriteLine("4. Actualizar veterinario");
                Console.WriteLine("5. Eliminar veterinario");
                Console.WriteLine("0. Volver al menú principal");

                int option = ConsoleHelper.ReadInt("Seleccione una opción: ");

                switch (option)
                {
                    case 1:
                        AddVeterinarian();
                        break;
                    case 2:
                        ListVeterinarians();
                        break;
                    case 3:
                        GetVeterinarianById();
                        break;
                    case 4:
                        UpdateVeterinarian();
                        break;
                    case 5:
                        DeleteVeterinarian();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }

        private void AddVeterinarian()
        {
            var vet = new Veterinarian
            {
                Id = Guid.NewGuid(),
                Name = ConsoleHelper.ReadString("Nombre: "),
                Specialty = ConsoleHelper.ReadString("Especialidad: "),
                Phone = ConsoleHelper.ReadString("Teléfono: ")
            };

            _service.Add(vet);
            Console.WriteLine("Veterinario registrado con éxito.");
        }

        private void ListVeterinarians()
        {
            var list = _service.GetAll();
            if (list.Count == 0)
            {
                Console.WriteLine("No hay veterinarios registrados.");
                return;
            }

            foreach (var vet in list)
            {
                Console.WriteLine($"ID: {vet.Id} | Nombre: {vet.Name} | Especialidad: {vet.Specialty} | Teléfono: {vet.Phone}");
            }
        }

        private void GetVeterinarianById()
        {
            var id = ConsoleHelper.ReadGuid();
            var vet = _service.GetById(id);

            if (vet == null)
            {
                Console.WriteLine("Veterinario no encontrado.");
                return;
            }

            Console.WriteLine($"ID: {vet.Id} | Nombre: {vet.Name} | Especialidad: {vet.Specialty} | Teléfono: {vet.Phone}");
        }

        private void UpdateVeterinarian()
        {
            var id = ConsoleHelper.ReadGuid();
            var existing = _service.GetById(id);

            if (existing == null)
            {
                Console.WriteLine("Veterinario no encontrado.");
                return;
            }

            existing.Name = ConsoleHelper.ReadString("Nuevo nombre: ");
            existing.Specialty = ConsoleHelper.ReadString("Nueva especialidad: ");
            existing.Phone = ConsoleHelper.ReadString("Nuevo teléfono: ");

            _service.Update(existing);
            Console.WriteLine("Veterinario actualizado con éxito.");
        }

        private void DeleteVeterinarian()
        {
            var id = ConsoleHelper.ReadGuid();
            _service.Delete(id);
            Console.WriteLine("Veterinario eliminado con éxito.");
        }
    }
}