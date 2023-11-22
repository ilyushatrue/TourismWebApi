using DataAccess.DbAccess;

namespace DataAccess.Data;
public abstract class DataAccessor<T> : IDataAccessor<T>
{
    protected readonly ISqlDataAccess _db;
    protected DataAccessor(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<T?> Get(int id)
    {
        var storedProcedure = $"dbo.sp{typeof(T).Name}Get";
        var results = await _db.LoadData<T, dynamic>(storedProcedure, new { Id = id });
        return results.FirstOrDefault();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var storedProcedure = $"dbo.sp{typeof(T).Name}GetAll";
        return await _db.LoadData<T, dynamic>(storedProcedure, new {});
    }

    public async Task Insert(dynamic parameters)
    {
        var storedProcedure = $"dbo.sp{typeof(T).Name}Insert";
        await _db.SaveData(storedProcedure, parameters);
    }

    public async Task Update(dynamic parameters)
    {
        var storedProcedure = $"dbo.sp{typeof(T).Name}Update";
        await _db.SaveData(storedProcedure, parameters);
    }

    public async Task Delete(int id)
    {
        var storedProcedure = $"dbo.sp{typeof(T).Name}Delete";
        await _db.SaveData(storedProcedure, new { Id = id });
    }

}
