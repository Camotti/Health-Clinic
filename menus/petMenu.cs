using healthclinic.models;
using healthclinic.services;
using healthclinic.utils;
using healthclinic.repositories;

namespace healthclinic.menus
{
    public class PetMenu
    {

        public static void Show()
        {
            var petRepository = new petRepository();
            var pets = petRepository.GetAll();
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
                    case 1: AddPet(petRepository); break;
                    case 2: ListPets(petRepository); break;
                    case 3: FindPet(petRepository); break;
                    case 4: UpdatePet(petRepository); break;
                    case 5: DeletePet(petRepository); break;
                    case 0: Console.WriteLine("Volviendo..."); break;
                    default: Console.WriteLine("❌ Opción no válida."); break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            } while (option != 0);
        }

        private static void AddPet(petRepository petsRep)
        {
            Console.WriteLine("\n=== Registro de Mascota ===");
            var pet = new Pet
            {
                Id = Guid.NewGuid(),
                Name = ConsoleHelper.ReadString("Nombre: "),
                Specie = ConsoleHelper.ReadString("Especie: "),
                Age = (byte)ConsoleHelper.ReadInt("Edad: ")
            };
            petsRep.Add(pet);
        }

        public static void ListPets(petRepository petsRep)
        {
            var pets = petsRep.GetAll();
            Console.WriteLine("\n=== Listado de Mascotas ===");
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

        private static void FindPet(petRepository petsRep)
        {
            var pets = petsRep.GetAll();
            if(pets.Count == 0){ return; }
            ListPets(petsRep);
            var id = ConsoleHelper.ReadGuid("Ingrese el ID de la mascota: ");
            var pet = petsRep.GetById(id);
            if (pet == null)
            {
                Console.WriteLine("⚠️ Mascota no encontrada.");
                return;
            }

            Console.WriteLine($"🐾 {pet.Name} ({pet.Specie}) - Edad: {pet.Age}");
        }

        private static void UpdatePet(petRepository petsRep)
        {
            var pets = petsRep.GetAll();
            if(pets.Count == 0){ return; }
            ListPets(petsRep);
            var id = ConsoleHelper.ReadGuid("Ingrese el ID de la mascota a actualizar: ");
            var existing = petsRep.GetById(id);
            if (existing == null)
            {
                Console.WriteLine("⚠️ No existe una mascota con ese ID.");
                return;
            }

            existing.Name = ConsoleHelper.ReadString("Nuevo nombre: ");
            existing.Specie = ConsoleHelper.ReadString("Nueva especie: ");
            existing.Age = (byte)ConsoleHelper.ReadInt("Nueva edad: ");
            petsRep.Update(existing);
        }

        private static void DeletePet(petRepository petsRep)
        {
            var pets = petsRep.GetAll();
            if(pets.Count == 0){ return; }
            ListPets(petsRep);
             var id = ConsoleHelper.ReadGuid("Ingrese el ID de la mascota a eliminar: ");
            petsRep.Delete(id);
            Console.WriteLine("Mascota eliminada con éxito (si existía).");
        }
    }
}