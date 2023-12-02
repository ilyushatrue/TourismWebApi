namespace DataAccess.Models.User.DTOs;
public class UserReadDto : IMapWith<UserModel>
{    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; } = null!;
}
