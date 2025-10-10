using System;
using System.Collections.Generic;
using System.Linq;
using healthclinic.models;
using healthclinic.Interfaces;
using healthclinic.repositories;
using healthclinic.Data; // para usar VeterinarianRepository en el ctor por defecto

namespace healthclinic.services   // <- usar "services" en minúscula (coherente con otros archivos)
{
    public class VeterinarianService
    {
        private readonly IveterinarianRepository _repository;

        // ctor por defecto que crea el repositorio concreto (facilita usar new VeterinarianService() en el menú)
        public VeterinarianService() : this(new VeterinarianRepository())
        {
        }

        // ctor para inyección (si quieres pasar un repo mock o distinto)
        public VeterinarianService(IveterinarianRepository repository)
        {
            _repository = repository;
        }

        // Métodos que el menú espera:
        public void Add(Veterinarian vet) => _repository.Add(vet);

        public List<Veterinarian> GetAll() => _repository.GetAll();

        public Veterinarian? GetById(Guid id) => _repository.GetById(id);

        public void Update(Veterinarian vet) => _repository.Update(vet);

        public bool Delete(Guid id)
        {
            var found = GetById(id);
            if (found == null) return false;
            _repository.Delete(id);
            return true;
        }

        // (Opcional) Mantengo  métodos originales renombrados/llamando a los nuevos
        public void RegisterVeterinarian(Veterinarian vet) => Add(vet);
        public void ListVeterinarians() 
        {
            var vets = GetAll();
            foreach (var v in vets) Console.WriteLine($"{v.Id} {v.Name} {v.Specialty}");
        }
    }
}