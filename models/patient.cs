namespace healthclinic.models; //definimos el espacio de trabajo 
using healthclinic.Interfaces; //importamos la interfaz IRegistrable y INotificable

public class Patient : Iregistrable, INotificable 
{
    //  Campos privados
    private Guid id = Guid.NewGuid(); 
    private string? name;
    private string? address;
    private byte age;

    //  Propiedades públicas
    public Guid Id => id; // Solo lectura

    public string gender { get; set; } = "UNKNOWN"; 
    public string email { get; set; } = string.Empty; 
    public string phone { get; set; } = string.Empty;

    public string? Name // Propiedad pública con validación
    {
        get => name;
        set => name = string.IsNullOrWhiteSpace(value) ? "UNKNOWN" : value; // si el nombre esta vacio o tiene espacios en blanco se asigna "UNKNOWN", si no se asigna un valor
    }

    public byte Age // Propiedad pública con validación
    {
        get => age;
        set => age = value > 0 ? value : (byte)1; // si la edad es mayor a 0 se asigna el valor, si no se asigna 1
    }

    private string Address // Propiedad pública con validación
    {
        get => address!; // el operador ! indica que la variable no es nula(NO OLVIDARLO PARA FUTURAS OCASIONES)
        set => address = string.IsNullOrWhiteSpace(value) ? "Not public address" : value; // si la dirección esta vacia o tiene espacios en blanco se asigna "Not public address", si no se asigna un valor
    }

    //  Relación con mascotas
    public List<Pet> Pets { get; set; } = new List<Pet>(); // lista de mascotas del paciente

    //  Constructores soluciona errores de vacio
    public Patient() { } // constructor por defecto
    //  Constructor
    public Patient(string name, byte age, string email, string phone, string address, string gender = "UNKNOWN")
    {
        this.id = Guid.NewGuid();   // genera nuevo Id
        this.Name = name;
        this.Age = age;
        this.email = email;
        this.phone = phone;
        this.Address = address;
        this.gender = gender;
        this.Pets = new List<Pet>();
    }

    //  Métodos de interfaz
    public void RegisterPatient() // Implementación del método de la interfaz IRegistrable
    {
        Console.WriteLine($"The patient {Name} has been registed successfully with {Pets.Count} pets.");
    }

    public void SendNotification(string message) // Implementación del método de la interfaz INotificable
    {
        Console.WriteLine($"This is a reminder for patient: {Name}, don't forget your medical appointment tomorrow.");
    }
}