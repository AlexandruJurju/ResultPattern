using ResultPattern.ResultPattern;
using ResultPattern.Users;

namespace ResultPattern.Endpoints.User;

public class GetByEmail : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/{email}", HandleGetByEmailRequest)
            .WithName("GetByEmail")
            .WithOpenApi()
            .Produces<Users.User>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);
    }

    private static IResult HandleGetByEmailRequest(string email, IUserRepository userRepository)
    {
        var result = userRepository.GetByEmail(email);

        return result.Match(
            onSuccess: user => Results.Ok(user),
            onFailure: error => CustomResults.Problem(error));
    }
}