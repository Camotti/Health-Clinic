using healthclinic.Interfaces;
namespace healthclinic.Services;


// clase que representa una vacunacion
public class Vaccination: IAtendibles // Implementa la interfaz IAtendibles
{
    public void AttendCustomer() // Metodo para vacunar a una mascota
    {
        Console.WriteLine("Vaccinating a Pet");
    }
}
