namespace healthclinic.Interfaces;

public interface IGenericRepository<T>
{
    void Add(T entity); // crear
    List<T> GetAll(); //Leer todos
    T? GetById(Guid id); // leer por ID 
    void Update(T entity);
    void Delete(Guid id); // eliminar por ID 
}