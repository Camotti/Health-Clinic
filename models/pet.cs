using System.Security.Cryptography.X509Certificates;
using healthclinic.Interfaces;

namespace healthclinic.models;

public class Pet : Animal , Iregistrable //
{
    // private Guid id = Guid.NewGuid(); // genera un ID unico 
    // private string? name;
    // private string? specie; // campos privados 

    // public Guid Id => id;

    // public string? Name
    // {
    //     get => name;
    //     set => name = string.IsNullOrWhiteSpace(value) ? "UNKNOWN" : value; // si el nombre esta vacio o tiene espacios en blanco se asigna "UNKNOWN", si no se asigna un valor
    // }

    // public string? Specie
    // {
    //     get => specie;
    //     set => specie = string.IsNullOrWhiteSpace(value) ? "UNKNOWN" : value;
    // }

    public override void Breathe() // implementacion del metodo abstracto
    {
        Console.WriteLine($"The {Name} is breathing.");
    }


    public void RegisterPatient() // implementacion del metodo de la interfaz
    {
        Console.WriteLine($"The pet {Name} has been registered successfully.");
    }


}

