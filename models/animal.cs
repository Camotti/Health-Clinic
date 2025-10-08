using System.Net.WebSockets;

namespace healthclinic.models;

public abstract class Animal 
{ //campos privados
    private Guid id = Guid.NewGuid();   
    private string? name;               
    private byte age;
    private string? specie;

    //campos publicos
    public Guid Id => id;
    public string? Name
    {
        get => name;
        set => name = string.IsNullOrWhiteSpace(value) ? "UNKNOWN" : value;
    }
    public byte Age
    {
        get => age;
        set
        {
            if (value < 0) age = 0;
            else if (value > 20) age = 20;
            else age = value;
        }
    }
    
    public string? Specie
    {
        get => specie;
        set => specie = string.IsNullOrWhiteSpace(value) ? "UNKNOWN" : value;
    }
    public Animal() {} 
    
    public Animal(string name, byte age, string specie, string symptom = "No Symptom")
    {
        Name = name;
        Age = age;
        Specie = specie;
        
    }

    // Método abstracto -> obliga a clases hijas a implementarlo
    public abstract void Breathe();
}