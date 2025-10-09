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
            Database.Patients.Add(new Patient

            {  // paciente 1 
                Id = Guid.NewGuid(),
                Name = "Ricardo Gomez",
                Age = 60,
                Email = "RicardoG@gmail.com"
            });

            Database.Patients.Add(new Patient

            {
                //Id = Guid.NewGuid(),
                Name = "Anamaria gutierrez",
                Age = 30,
                Email = "Ana80@gmail.com"
            });



            //veterinarian
            Database.Veterinarians.Add(new Veterinarian
            {
                //Id = Guid.NewGuid(),
                Name = "Dro Juan Camilo Rodriguez",
                Specialty = "Avi cultura"
            });

            Database.Veterinarians.Add(new Veterinarian

            {
                Name = "Dra Lucia Jimenez",
                Specialty = "Animales domesticos"
            });


            Database.Pets.Add(new Pet

            {
                
            }
            
            
            );


        }
    }
}