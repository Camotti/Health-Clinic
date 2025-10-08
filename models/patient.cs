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
    public Guid Id { get; set; } = Guid.NewGuid(); // Solo lectura
    public string Gender { get; set; } = "UNKNOWN"; 
    public string Email { get; set; } = string.Empty; 
    public string Phone { get; set; } = string.Empty;



    // Propiedades con validación porque no pueden estar vacias
    public string? Name
    {
        get => name;
        set => name = string.IsNullOrWhiteSpace(value) ? "UNKNOWN" : value; // si el nombre esta vacio o tiene espacios en blanco se asigna "UNKNOWN", si no se asigna un valor
    }
    public byte Age // 
    {
        get => age;
        set => age = value > 0 ? value : (byte)1; // si la edad es mayor a 0 se asigna el valor, si no se asigna 1
    }
    private string Address 
    {
        get => address!; // el operador ! indica que la variable no es nula(NO OLVIDARLO PARA FUTURAS OCASIONES)
        set => address = string.IsNullOrWhiteSpace(value) ? "Not public address" : value; // si la dirección esta vacia o tiene espacios en blanco se asigna "Not public address", si no se asigna un valor
    }


    //  Relación con mascotas
    public List<Pet> Pets { get; set; } = new List<Pet>(); // lista de mascotas del paciente

    
    public Patient() { } // constructor por defecto
    //  Constructor
    public Patient(string name, byte age, string email, string phone, string address, string gender = "UNKNOWN")
    {
        this.id = Guid.NewGuid();   
        this.Name = name;
        this.Age = age;
        this.Email = email;
        this.Phone = phone;
        this.Address = address;
        this.Gender = gender;
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