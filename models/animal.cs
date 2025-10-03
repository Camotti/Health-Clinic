namespace healthclinic.models;

public abstract class Animal // clase abstracta que no se puede instanciar directamente
{
    private Guid id = Guid.NewGuid();   // ID único
    private string? name;               // campos privados
    private byte age;
    private string? symptom;
    private string? specie;

    public Guid Id => id; // propiedad de solo lectura

    // Propiedad pública con validación
    public string? Name
    {
        get => name;
        set => name = string.IsNullOrWhiteSpace(value) ? "UNKNOWN" : value;
    }

    public byte Age
    {
        get => age;
        set => age = value > 0 ? value : (byte)1;
    }

    public string? Symptom
    {
        get => symptom;
        set => symptom = string.IsNullOrWhiteSpace(value) ? "No Symptom" : value;
    }

    public string? Specie
    {
        get => specie;
        set => specie = string.IsNullOrWhiteSpace(value) ? "UNKNOWN" : value;
    }

    public Animal() {} // constructor por defecto llena automaticamente los espacios vacios 
    // CONSTRUCTOR: inicializa datos básicos del animal
    public Animal(string name, byte age, string specie, string symptom = "No Symptom")
    {
        Name = name;
        Age = age;
        Specie = specie;
        Symptom = symptom;
    }

    // Método abstracto → obliga a clases hijas a implementarlo
    public abstract void Breathe();
}