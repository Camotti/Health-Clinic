using healthclinic.Interfaces;
namespace healthclinic.Services;

// clase que representa una consulta general

public class GeneralQuery : IAtendibles // Implementa la interfaz IAtendibles
{
    public void AttendCustomer()
    {
        Console.WriteLine("attending a general query customer");
    }
}

