namespace healthclinic.Interfaces;

public interface IGenericRepository<Task>
{
    void Add(Type entity); // crear
    List<Task> Getall(); //Leer todos
    Task GetById(Guid id); // leer por ID 
    void Update(Type entity);
    void Delete(Guid id); // eliminar por ID 
}