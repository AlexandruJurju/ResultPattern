using Microsoft.AspNetCore.Mvc;
using ResultPattern.Users;

namespace ResultPattern.Endpoints.User;

public class Register : IEndpoint
{
    public sealed record Request(int Id, string Email, string Name);

    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/register", HandleRegistration)
            .WithName("RegisterUser")
            .WithOpenApi()
            .Produces<Users.User>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }

    private static IResult HandleRegistration(
        [FromBody] Request request,
        IUserRepository userRepository)
    {
        var newUser = new Users.User(request.Id, request.Name, request.Email);
        var createdUser = userRepository.AddUser(newUser);
        return Results.Created($"/users/{createdUser.Id}", createdUser);
    }
}