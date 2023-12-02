namespace DataAccess.Models.User;

public class UserModel : BaseModel
{
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;

}
