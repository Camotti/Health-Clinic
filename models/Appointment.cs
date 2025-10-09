using healthclinic.Interfaces;
using healthclinic.models;

public class Appointment : Iregistrable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PatientID { get; set; }
    public Guid VeterinarianID { get; set; }
    public DateTime Date { get; set; }
    public string Reason { get; set; } = string.Empty;



    public Appointment() { }

    public Appointment(Guid patientId, Guid veterinaianId, DateTime date, string reason)
    {
        Id = Guid.NewGuid();
        PatientID = patientId;
        VeterinarianID = veterinaianId;
        Date = date;
        Reason = string.IsNullOrWhiteSpace(reason) ? "General query" : reason;
    }
    
        public void RegisterPatient()
        {
        Console.WriteLine($"Appointment information:");
        Console.WriteLine($"DATE: {Date}");
        Console.WriteLine($"REASON: {Reason}");
        Console.WriteLine($"Patient ID: {PatientID}");
        Console.WriteLine($"Veterinarian ID: {VeterinarianID}");
        }

}