    using healthclinic.Interfaces;
    using healthclinic.Data;
    using healthclinic.models;
    using System.Linq;

namespace healthclinic.Repositories
    {
        public class PatientRepository : IPatientRepository
        {
            
            public void Add(Patient patient)
            {
                Database.Patients.Add(patient);
            }


            public List<Patient> GetAll()
            {
                return Database.Patients;
            }


             public Patient? GetById(Guid id)

             {
                return Database.Patients.FirstOrDefault(patient => patient.Id == id);
            }

            public void Update(Patient entity)
            {
                var existing = Database.Patients.FirstOrDefault(patient => patient.Id == entity.Id);
                if (existing != null)
                {
                    existing.Name = entity.Name;
                    existing.Age = entity.Age;
                    existing.Email = entity.Email;
                    existing.Phone = entity.Phone;
                    existing.Pets = entity.Pets;
                }
            }


            public void Delete(Guid id)
            {
                var patient = Database.Patients.FirstOrDefault(patient => patient.Id == id);
                {
                    if (patient != null)
                    {
                        Database.Patients.Remove(patient);
                    }
                }
            }
       }
    }