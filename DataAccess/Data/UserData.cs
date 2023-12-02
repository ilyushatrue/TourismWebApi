global using DataAccess.Data.Accessor;
using AutoMapper;
using DataAccess.DbAccess;
using DataAccess.Models.User;

namespace DataAccess.Data;
public class UserData : DataAccessor<UserModel>
{
    public UserData(IDbAccess db, IMapper mapper) : base(db, mapper) { }
}
