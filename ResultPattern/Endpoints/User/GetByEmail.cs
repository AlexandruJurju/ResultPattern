using ResultPattern.ResultPattern;
using ResultPattern.Users;

namespace ResultPattern.Endpoints.User;

public class GetByEmail : IEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/{id:int}", HandleGetByEmailRequest)
            .WithName("GetByEmail")
            .WithOpenApi()
            .Produces<Users.User>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);
    }

    private static IResult HandleGetByEmailRequest(string email, IUserRepository userRepository)
    {
        var getResult = userRepository.GetByEmail(email);

        return getResult.Match(
            onSuccess: () => Result.Success(),
            onFailure: e => );
    }
}