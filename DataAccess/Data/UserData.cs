global using DataAccess.Data.Accessor;
using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;
public class UserData : DataAccessor<UserModel>
{
    public UserData(ISqlDataAccess db) : base(db) { }
}
