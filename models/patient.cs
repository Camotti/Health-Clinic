namespace healthclinic.models; //definimos el espacio de trabajo 
using healthclinic.Interfaces;

public class Patient : Iregistrable, INotificable // se crea la clase con sus atributos, Los campos privados van en minuscula y los publicos en mayuscula 
{
    private Guid id = Guid.NewGuid(); // Va a generar un id automatico 
    private string? name;
    private byte age;

    private string? symptom;  // aqui solo se hace la estructura del paciente 

    public Guid Id => id;

    public string? Name

    {
        get => name;
        set => name = string.IsNullOrWhiteSpace(value) ? "UNKNOWN" : value; // si el nombre esta vacio o tiene espacios en blanco se asigna "UNKNOWN", si no se asigna un valor
    }

    public byte Age
    {
        get => age;
        set => age = value > 0 ? value : (byte)1; // si la edad es mayor a 0 se asigna el valor, si no se asigna 1
    }

    public string? Symptom
    {
        get => symptom;
        set => symptom = string.IsNullOrWhiteSpace(value) ? "No Symptom" : value; // si el sintoma esta vacio o tiene espacios en blanco se asigna "No Symptom", si no se asigna un valor
    }


    // relacion 1-1 para que cada paciente tenga una mascota o ninguna
    // public Pet? Pet { get; set; }

    // relacion de 1 - N porque un paciente puede tener varias mascotas. 

    public List<Pet> Pets { get; set; } = new List<Pet>(); // inicializamos la lista de mascotas para evitar errores de referencia nula


    public void RegisterPatient() // Implementacion del metodo de la interfaz Iregistrable
    {
        Console.WriteLine($"The patient {Name} has been registed successfully with {Pets.Count} pets.");
    }


    public void SendNotification(string message) // Implementacion del metodo de la interfaz INotificable
    {
        Console.WriteLine($"This is a reminder for patient: {Name} , don't forget your medical appointment tomorrow.");
    }
}



