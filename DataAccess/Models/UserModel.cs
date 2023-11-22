namespace DataAccess.Models;

public class UserModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
}
