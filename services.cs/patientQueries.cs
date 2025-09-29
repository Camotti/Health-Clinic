using healthclinic.models;
using System.Linq;

namespace healthclinic.Services;
{
    public class PatientQueries
{
    public void FilterByAge(List<Patient> patients, byte minimumAge)
    {
        var FilterByPatients = patients.Where(patient => patient.Age > minimumAge);

        Console.WriteLine($"The patients filter by age are: {minimumAge}  ");
        foreach (var patient in FilterByPatients)
        {
            Console.WriteLine($"The patient name is: {patient.Name} and their age is: {patient.Age}");
        }
        
    }
}
}