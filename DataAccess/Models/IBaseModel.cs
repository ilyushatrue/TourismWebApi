namespace DataAccess.Models;
public interface IBaseModel
{
    int Id { get; set; }
    DateTime CreatedDate { get; set; }
    DateTime UpdatedDate { get; set; }
    bool IsDeleted { get; set; }
}