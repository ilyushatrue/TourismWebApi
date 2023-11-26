namespace DataAccess.Data.Accessor;

public interface IDataAccessor<T>
{
    Task Delete(int id);
    Task<T?> Get(int id);
    Task<IEnumerable<T>> GetAll();
    Task Insert(dynamic parameters);
    Task Update(dynamic parameters);
}