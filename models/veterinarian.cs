using healthclinic.Interfaces;
namespace healthclinic.models;

public class Veterinarian: IAtendibles
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;


    public Veterinarian () {}
    public Veterinarian(string name, string specialty)
    {
        Name = name;
        Specialty = specialty;
    }


    public void AttendCustomer()
    {
        Console.WriteLine($"The veterinarian {Name} attended a customer. ");
    }



}