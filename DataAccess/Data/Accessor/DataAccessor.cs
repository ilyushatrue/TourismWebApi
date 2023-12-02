using AutoMapper;
using DataAccess.DbAccess;

namespace DataAccess.Data.Accessor;
public abstract class DataAccessor<TModel> : IDataAccessor
{
    private readonly IDbAccess _db;
    private readonly string _storedProcTemplate;
    private readonly IMapper _mapper;
    protected DataAccessor(
        IDbAccess db,
        IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
        var modelName = typeof(TModel).Name[..^"Model".Length];
        _storedProcTemplate = $"dbo.sp{modelName}_";
    }

    public virtual async Task<TDto?> Get<TDto>(int id)
    {
        var results = await _db.LoadData<TModel, dynamic>(_storedProcTemplate + "Get", new { Id = id });
        var dtos = _mapper.Map<IEnumerable<TDto>>(results);
        return dtos.FirstOrDefault();
    }

    public virtual async Task<IEnumerable<TDto>> GetAll<TDto>() =>
        await _db.LoadData<TDto, dynamic>(_storedProcTemplate + "GetAll", new { });

    public virtual async Task Insert(dynamic parameters) =>
        await _db.SaveData(_storedProcTemplate + "Insert", parameters);


    public virtual async Task Update(dynamic parameters) =>
        await _db.SaveData(_storedProcTemplate + "Update", parameters);

    public virtual async Task Delete(int id) =>
        await _db.SaveData(_storedProcTemplate + "Delete", new { Id = id });
}
