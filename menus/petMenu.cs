using healthclinic.models;
using healthclinic.services;
using healthclinic.utils; 

namespace healthclinic.menus
{
    public class PetMenu
    {
        private readonly PetService _petService = new();

        public void Show()
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("===== 🐾 MENÚ DE MASCOTAS =====");
                Console.WriteLine("1. Registrar nueva mascota");
                Console.WriteLine("2. Listar todas las mascotas");
                Console.WriteLine("3. Buscar mascota por ID");
                Console.WriteLine("4. Actualizar mascota");
                Console.WriteLine("5. Eliminar mascota");
                Console.WriteLine("0. Volver al menú principal");
                option = ConsoleHelper.ReadInt("Seleccione una opción: ");

                switch (option)
                {
                    case 1: AddPet(); break;
                    case 2: ListPets(); break;
                    case 3: FindPet(); break;
                    case 4: UpdatePet(); break;
                    case 5: DeletePet(); break;
                    case 0: Console.WriteLine("Volviendo..."); break;
                    default: Console.WriteLine("❌ Opción no válida."); break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            } while (option != 0);
        }

        private void AddPet()
        {
            Console.WriteLine("\n=== Registro de Mascota ===");
            var pet = new Pet
            {
                Id = Guid.NewGuid(),
                Name = ConsoleHelper.ReadString("Nombre: "),
                Specie = ConsoleHelper.ReadString("Especie: "),
                Age = (byte)ConsoleHelper.ReadInt("Edad: ")
            };
            _petService.Add(pet);
        }

        private void ListPets()
        {
            Console.WriteLine("\n=== Listado de Mascotas ===");
            var pets = _petService.GetAll();
            if (!pets.Any())
            {
                Console.WriteLine("⚠️ No hay mascotas registradas.");
                return;
            }

            foreach (var pet in pets)
            {
                Console.WriteLine($"🐶 ID: {pet.Id} | Nombre: {pet.Name} | Especie: {pet.Specie} | Edad: {pet.Age}");
            }
        }

        private void FindPet()
        {
            var id = ConsoleHelper.ReadGuid("Ingrese el ID de la mascota: ");
            var pet = _petService.GetById(id);
            if (pet == null)
            {
                Console.WriteLine("⚠️ Mascota no encontrada.");
                return;
            }

            Console.WriteLine($"🐾 {pet.Name} ({pet.Specie}) - Edad: {pet.Age}");
        }

        private void UpdatePet()
        {
            var id = ConsoleHelper.ReadGuid("Ingrese el ID de la mascota a actualizar: ");
            var existing = _petService.GetById(id);
            if (existing == null)
            {
                Console.WriteLine("⚠️ No existe una mascota con ese ID.");
                return;
            }

            existing.Name = ConsoleHelper.ReadString("Nuevo nombre: ");
            existing.Specie = ConsoleHelper.ReadString("Nueva especie: ");
            existing.Age = (byte)ConsoleHelper.ReadInt("Nueva edad: ");
            _petService.Update(existing);
        }

        private void DeletePet()
        {
             var id = ConsoleHelper.ReadGuid("Ingrese el ID de la mascota a eliminar: ");
            _petService.Delete(id);
            Console.WriteLine("Mascota eliminada con éxito (si existía).");
        }
    }
}