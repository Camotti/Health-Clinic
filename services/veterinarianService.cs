using healthclinic.models;
using healthclinic.Interfaces;
using System.Linq;



namespace healthclinic.Services
{
    public class veterinarianService 
    {
        private readonly IveterinarianRepository _repository;

        public veterinarianService(IveterinarianRepository repository)
        {
            _repository = repository;
        }


        public void RegisterVeterinarian()
        {
            Console.WriteLine("Veterinarian name: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            Console.WriteLine("Speciality: ");
            string? specialty = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(specialty))
            {
                Console.WriteLine("Specialty cannot be empty.");
                return;
            }

            Console.WriteLine("Years of experience: ");
            int.TryParse(Console.ReadLine(), out int experience);


            var veterinarian = new Veterinarian
            {
                Name = name,
                Specialty = specialty,
                ExperienceYears = experience
            };


            _repository.Add(veterinarian);
            Console.WriteLine("Veterinarian correctly registered.");
        }



        public void ListVeterinarians()
        {
            var vets = _repository.GetAll();
            if (!vets.Any())
            {
                Console.WriteLine("No veterinarians found.");
                return;
            }

            foreach (var vet in vets)
            {
                Console.WriteLine($"ID: {vet.Id} , Name: {vet.Name} , specialty: {vet.Specialty} , experience years: {vet.ExperienceYears} ");
            }
        }
        

        public void SearchVeterinarianById(Guid id)
        {
            var vet = _repository.GetById(id);
            if (vet == null)
            {
                Console.WriteLine("Veterinarian not found");
                return;
            }

            Console.WriteLine($"Veterinarian Found: Id: {vet.Id} Name: {vet.Name} specialty: {vet.Specialty} experience years: {vet.ExperienceYears}  ");
        }


        public void DeleteVeterinarian(Guid id)
        {
            var vet = _repository.GetById(id);
            if (vet == null)
            {
                Console.WriteLine("Veterinarian not found");
                return;
            }

            _repository.Delete(id);
            Console.WriteLine($"Veterinarian {vet.Name} deleted succesfully.");
        }
    }
}