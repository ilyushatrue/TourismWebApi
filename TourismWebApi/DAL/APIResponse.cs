using System.Net;

namespace TourismWebApi.DAL;

public class APIResponse
{
    public bool IsSuccess { get; set; }
    public object? Result { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public List<string>? ErrorMessages { get; set; } = new List<string>();
}
