using AutoMapper;
using DataAccess.Models.User;

namespace DataAccess.Models.User.DTOs;
public class UserInsertDto : IMapWith<UserModel>
{
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string Password { get; set; } = null!;

    //public void Mapping(Profile profile)
    //{
    //    profile.CreateMap<UserInsertDto, UserModel>();
    //    profile.CreateMap<UserModel, UserInsertDto>();
    //    profile.CreateMap<IEnumerable<UserInsertDto>, IEnumerable<UserModel>>();
    //    profile.CreateMap<IEnumerable<UserModel>, IEnumerable<UserInsertDto>>();
    //}
}
