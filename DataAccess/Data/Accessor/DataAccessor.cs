using DataAccess.DbAccess;
using System.Reflection;
using System.Diagnostics;

namespace DataAccess.Data.Accessor;
public abstract class DataAccessor<T> : IDataAccessor<T>
{
    protected readonly ISqlDataAccess _db;
    protected DataAccessor(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<T?> Get(int id){
        var results = await _db.LoadData<T, dynamic>(GetStoredProcedureString(), new { Id = id });
        return results.FirstOrDefault();
    }

    public async Task<IEnumerable<T>> GetAll()=>
        await _db.LoadData<T, dynamic>(GetStoredProcedureString(), new { });

    public async Task Insert(dynamic parameters) =>
        await _db.SaveData(GetStoredProcedureString(), parameters);
    

    public async Task Update(dynamic parameters)=>
        await _db.SaveData(GetStoredProcedureString(), parameters);

    public async Task Delete(int id)=>
        await _db.SaveData(GetStoredProcedureString(), new { Id = id });

    private string GetStoredProcedureString()
    {
        var st = new StackTrace();
        var sf = st.GetFrame(3);
        var operationName = sf?.GetMethod()?.Name;
        if (operationName == null)
            throw new ArgumentNullException("Failed to get a name of a method");
        var modelName = typeof(T).Name[..^"Model".Length];
        return $"dbo.sp{modelName}_{operationName}";
    }
}
