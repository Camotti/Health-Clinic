namespace healthclinic.models;

public class Pet
{
    public Guid Id { get; set; } = Guid.NewGuid(); // genera un ID unico 
    public string? Name { get; set; }
    public string? Specie { get; set; }

    
}

