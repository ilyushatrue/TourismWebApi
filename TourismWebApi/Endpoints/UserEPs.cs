using DataAccess.Models.User;
using DataAccess.Models.User.DTOs;

namespace TourismWebApi.Endpoints;

public static class UserEPs
{
    public static void AddUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/users", GetUsers);
        app.MapGet("/users/{id}", GetUser);
        app.MapPost("/users", InsertUser);
        app.MapPut("/users", UpdateUser);
        app.MapDelete("/users", DeleteUser);
    }

    private static async Task<IResult> GetUsers(UserData data)
    {
        try
        {

            return Results.Ok(await data.GetAll<UserReadDto>());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> GetUser(int id, UserData data)
    {
        try
        {
            var result = await data.Get<UserReadDto>(id);
            if (result == null) return Results.NotFound(); 
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> InsertUser(UserInsertDto dto, UserData data)
    {
        try
        {
            await data.Insert(dto);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> UpdateUser(UserModel model, UserData data)
    {
        try
        {
            await data.Update(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteUser(int id, UserData data)
    {
        try
        {
            await data.Delete(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

}
