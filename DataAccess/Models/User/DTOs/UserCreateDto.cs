using AutoMapper;
using DataAccess.Models.User;

namespace DataAccess.Models.User.DTOs;
public class UserCreateDto : IMapWith<UserModel>
{
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string Password { get; set; } = null!;

    //public void Mapping(Profile profile)
    //{
    //    profile.CreateMap<UserCreateDto, UserModel>();
    //    profile.CreateMap<UserModel, UserCreateDto>();
    //    profile.CreateMap<IEnumerable<UserCreateDto>, IEnumerable<UserModel>>();
    //    profile.CreateMap<IEnumerable<UserModel>, IEnumerable<UserCreateDto>>();
    //}
}
