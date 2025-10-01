using healthclinic.models;

public abstract class Animal
{
     private Guid id = Guid.NewGuid(); // genera un ID unico 
    private string? name;
    private string? specie; // campos privados 

    public Guid Id => id;

    public string? Name
    {
        get => name;
        set => name = string.IsNullOrWhiteSpace(value) ? "UNKNOWN" : value; // si el nombre esta vacio o tiene espacios en blanco se asigna "UNKNOWN", si no se asigna un valor
    }

    public string? Specie
    {
        get => specie;
        set => specie = string.IsNullOrWhiteSpace(value) ? "UNKNOWN" : value;
    }


    public abstract void Breathe(); // metodo abstracto que debe ser implementado por las clases derivadas
}