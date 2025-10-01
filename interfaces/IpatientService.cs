using healthclinic.models;
namespace healthclinic.Interfaces;

public interface IPatientService
{
    void RegisterPatient(List<Patient> patients); // este metodo recibe una lista de pacientes(datos de memoria)
    void ListPatients(List<Patient> patients); // este metodo recibe una lista de pacientes(datos de memoria)
    void SearchPatient(List<Patient> patients, string name); // este metodo recibe una lista de pacientes(datos de memoria)
}

