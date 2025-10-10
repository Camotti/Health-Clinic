using healthclinic.Interfaces;
using healthclinic.Data;
using healthclinic.models;
using System.Linq;

namespace healthclinic.repositories
{
    public class petRepository : IPetRepository
    {
        public void Add(Pet pet) // añadir
        {
            Database.Pets.Add(pet);
        }

        public void Delete(Guid id) //eliminar
        {
            var pet = Database.Pets.FirstOrDefault(pet => pet.Id == id);
            if (pet != null)
            {
                Database.Pets.Remove(pet);
            }
        }

        public List<Pet> GetAll() //listar
        {
            return Database.Pets;
        }

        public Pet? GetById(Guid id)
        {
            return Database.Pets.FirstOrDefault(patient => patient.Id == id);
        }

        public void Update(Pet entity)
        {
            var existing = Database.Pets.FirstOrDefault(pet => pet.Id == entity.Id);
            if (existing != null)
            {
                existing.Name = entity.Name;
                existing.Specie = entity.Specie;
                existing.Age = entity.Age;   
            }

        }
    }
}
