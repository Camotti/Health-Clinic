using healthclinic.models;

namespace healthclinic.Data
{
    public static class DataSeeder
    {
        public static void Seed()
        {

            if (Database.Patients.Count > 0)
                return;

            //objeto de pacientes add(para uno ), addRange(para varios de golpe)


            var patient1= new Patient
            {  // paciente 1 
                Name = "Ricardo Gomez",
                Age = 60,
                Email = "RicardoG@gmail.com",
                Phone = "3001234567",
                Gender = "Masculino"
            };

            var patient2= new Patient

            {
                
                Name = "Anamaria Gutierrez",
                Age = 30,
                Email = "Ana80@gmail.com",
                Phone = "3209876543",
                Gender = "Femenino"
            };
            Database.Patients.Add(patient1);
            Database.Patients.Add(patient2);


            //veterinarian
            var vet1 = new Veterinarian
            {
                Id = Guid.NewGuid(),
                Name = "Dr. Juan Camilo Rodríguez",
                Specialty = "Avicultura"
            };

            var vet2 = new Veterinarian
            {
                Id = Guid.NewGuid(),
                Name = "Dra. Lucía Jiménez",
                Specialty = "Animales domésticos"
            };

            var vet3 = new Veterinarian
            {
                Id = Guid.NewGuid(),
                Name = "Dra. Sofía Torres",
                Specialty = "Veterinaria general"
            };

             Database.Veterinarians.Add(vet1);
             Database.Veterinarians.Add(vet2);
             Database.Veterinarians.Add(vet3);


            // mascotas 
            var pet1 = new Pet
            {
                Name = "Rocco",
                Specie = "Jack Russel",
                Age = 18,
                Symptom = "Obesidad",
                
            };

            var pet2 = new Pet
            {
                Name = "Milo",
                Age = 3,
                Specie = "Golden Retriever",
                Symptom = "Dolor en las patas"
                // OwnerId = patient2.Id
            };

            var pet3 = new Pet
            {
                Name = "Luna",
                Age = 2,
                Specie = "Gato criollo",
                Symptom = "Fiebre"
                // OwnerId = patient2.Id
            };

            Database.Pets.Add(pet1);
            Database.Pets.Add(pet2);
            Database.Pets.Add(pet3);
        }
    }
}