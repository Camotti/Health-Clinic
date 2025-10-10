using System;
using healthclinic.models;
using healthclinic.utils;
using healthclinic.services;

namespace healthclinic.menus
{
    public class PetMenu
    {
        private readonly PetService _service = new PetService();

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n=== Menú de Mascotas ===");
                Console.WriteLine("1. Registrar mascota");
                Console.WriteLine("2. Listar mascotas");
                Console.WriteLine("3. Buscar mascota por ID");
                Console.WriteLine("4. Actualizar mascota");
                Console.WriteLine("5. Eliminar mascota");
                Console.WriteLine("0. Volver al menú principal");

                int option = ConsoleHelper.ReadInt("Seleccione una opción: ");

                switch (option)
                {
                    case 1:
                        AddPet();
                        break;
                    case 2:
                        ListPets();
                        break;
                    case 3:
                        GetPetById();
                        break;
                    case 4:
                        UpdatePet();
                        break;
                    case 5:
                        DeletePet();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
            }
        }

        private void AddPet()
        {
            var pet = new Pet
            {
                
                Name = ConsoleHelper.ReadString("Nombre de la mascota: "),
                Specie = ConsoleHelper.ReadString("Tipo (Perro, Gato, etc.): "),
                Age =(byte) ConsoleHelper.ReadInt("Edad: ")
            };

            _service.Add(pet);
            Console.WriteLine("🐾 Mascota registrada con éxito.");
        }

        private void ListPets()
        {
            var list = _service.GetAll();
            if (list.Count == 0)
            {
                Console.WriteLine("No hay mascotas registradas.");
                return;
            }

            foreach (var pet in list)
            {
                Console.WriteLine($"ID: {pet.Id} | Nombre: {pet.Name} | Tipo: {pet.Specie} | Edad: {pet.Age}");
            }
        }

        private void GetPetById()
        {
            var id = ConsoleHelper.ReadGuid("Ingrese el ID de la mascota: ");
            var pet = _service.GetById(id);

            if (pet == null)
            {
                Console.WriteLine("Mascota no encontrada.");
                return;
            }

            Console.WriteLine($"🐶 ID: {pet.Id} | Nombre: {pet.Name} | Tipo: {pet.Specie} | Edad: {pet.Age}");
        }

        private void UpdatePet()
        {
            var id = ConsoleHelper.ReadGuid("Ingrese el ID de la mascota a actualizar: ");
            var existing = _service.GetById(id);

            if (existing == null)
            {
                Console.WriteLine("Mascota no encontrada.");
                return;
            }

            existing.Name = ConsoleHelper.ReadString("Nuevo nombre: ");
            existing.Specie = ConsoleHelper.ReadString("Nuevo tipo: ");
            existing.Age = (byte)ConsoleHelper.ReadInt("Nueva edad: ");

            _service.Update(existing);
            Console.WriteLine("🐕 Mascota actualizada con éxito.");
        }

        private void DeletePet()
        {
            var id = ConsoleHelper.ReadGuid("Ingrese el ID de la mascota a eliminar: ");
            _service.Delete(id);
            Console.WriteLine("🐾 Mascota eliminada con éxito.");
        }
    }
}