namespace healthclinic.models; //definimos el espacio de trabajo 

public class Patient // se crea la clase con sus atributos 
{
    public Guid Id { get; set; } = Guid.NewGuid(); // Va a generar un id automatico 
    public string? Name { get; set; }
    public byte Age { get; set; }

    public string? Symptom { get; set; } // aqui solo se hace la estructura del paciente 
}



