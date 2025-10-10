using System;
using System.Collections.Generic;
using System.Linq;
using healthclinic.models;


namespace healthclinic.services
{
    public class PetService
    {
        private readonly List<Pet> _pets = new();

        public void Add(Pet pet) => _pets.Add(pet);

        public List<Pet> GetAll() => _pets;

        public Pet? GetById(Guid id) => _pets.FirstOrDefault(p => p.Id == id);

        public void Update(Pet pet)
        {
            var existing = GetById(pet.Id);
            if (existing == null) return;

            existing.Name = pet.Name;
            existing.Specie = pet.Specie;
            existing.Age = pet.Age;
            // se us ownerId (camelCase)
            existing.ownerId = pet.ownerId;
            // si tiene Symptom u otras propiedades:
            existing.Symptom = pet.Symptom;
        }

         public bool Delete(Guid id)
        {
            var p = GetById(id);
            if (p == null) return false;
            _pets.Remove(p);
            return true;
        }
    }
}