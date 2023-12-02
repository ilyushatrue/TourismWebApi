namespace DataAccess.Data;
public interface IUserData
{
    Task Delete(int id);
    Task<TDto?> Get<TDto>(int id);
    Task<IEnumerable<TDto>> GetAll<TDto>();
    Task Insert(dynamic parameters);
    Task Update(dynamic parameters);
}
