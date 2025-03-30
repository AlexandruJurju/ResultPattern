using ResultPattern.ResultPattern;

namespace ResultPattern.Errors;

public static class UserErrors
{
    public static Error NotFound(int id) => new Error(
        "Users.NotFound",
        $"The user with id {id} was not found.");

    public static Error NotFound(string email) => new Error(
        "Users.NotFound",
        $"The user with email {email} was not found.");
    
    public static Error AlreadyExist() => new Error(
        "Users.AlreadyExists",
        "User already exists.");
}