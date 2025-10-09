using healthclinic.models;

namespace healthclinic.Data
{
    // Simula una base de datos en memoria
    public static class Database
    {
        public static List<Patient> Patients { get; set; } = new List<Patient>();
        public static List<Pet> Pets { get; set; } = new List<Pet>();
        public static List<Veterinarian> Veterinarians { get; set; } = new List<Veterinarian>();
    }
    

    

}