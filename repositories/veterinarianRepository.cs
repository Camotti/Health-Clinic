using healthclinic.Interfaces;
using healthclinic.models;
using healthclinic.Data;
using System.Linq;


namespace healthclinic.repositories
{
    public class VeterinarianRepository : IveterinarianRepository
    {
        public void Add(Veterinarian vet)
        {
            Database.Veterinarians.Add(vet);
        }


        public void Delete(Guid id)
        {
            var vet = Database.Veterinarians.FirstOrDefault(v => v.Id == id);
            if (vet != null)
            {
                Database.Veterinarians.Remove(vet);
            }
        }


        public List<Veterinarian> GetAll()
        {
            return Database.Veterinarians;
        }


        public Veterinarian? GetById(Guid id)
        {
            return Database.Veterinarians.FirstOrDefault(v => v.Id == id);
        }


        public void Update(Veterinarian entity)
        {
            var existing = Database.Veterinarians.FirstOrDefault(v => v.Id == entity.Id);
            {
                if (existing != null)
                {
                    existing.Name = entity.Name;
                    existing.Specialty = entity.Specialty;
                }
            }
        }
    }
}