using System.Security.Cryptography.X509Certificates;
using healthclinic.Interfaces;

namespace healthclinic.models;

public class Pet : Animal , Iregistrable //
{
    private string? symptom;

    public string? Symptom
    {
        get => symptom;
        set => symptom = string.IsNullOrWhiteSpace(value) ? "No Symptom" : value;
    }


    public Pet() { } // constructor por defecto

    // CONSTRUCTOR:
    public Pet(
        string name, byte age, string specie, string symptom) : base(name, age, specie, symptom)
    {}

    //Metodos
    public override void Breathe() // implementacion del metodo abstracto
    {
        Console.WriteLine($"The {Name} is breathing calmly.");
    }

    public void RegisterPatient() // implementacion del metodo de la interfaz
    {
        Console.WriteLine($"The pet {Name} has been registered successfully.");
    }


}

