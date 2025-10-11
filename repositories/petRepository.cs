using healthclinic.Interfaces;
using healthclinic.Data;
using healthclinic.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace healthclinic.repositories
{
    public class PetRepository : IPetRepository
    {
        public void Add(Pet entity)
        {
            Database.Pets.Add(entity);
        }

        public void Delete(Guid id)
        {
            var pet = Database.Pets.FirstOrDefault(p => p.Id == id);
            if (pet != null)
            {
                Database.Pets.Remove(pet);
            }
        }

        public List<Pet> GetAll()
        {
            return Database.Pets.ToList();
        }

        public Pet? GetById(Guid id)
        {
            return Database.Pets.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Pet entity)
        {
            var existingPet = Database.Pets.FirstOrDefault(p => p.Id == entity.Id);
            if (existingPet != null)
            {
                existingPet.Name = entity.Name;
                existingPet.Specie = entity.Specie;
                existingPet.Age = entity.Age;
            }
        }
    }
}
