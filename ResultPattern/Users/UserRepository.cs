using ResultPattern.Errors;
using ResultPattern.ResultPattern;

namespace ResultPattern.Users;

public class UserRepository : IUserRepository
{
    private readonly List<User> users = new();

    public User AddUser(User user)
    {
        users.Add(user);

        return user;
    }

    public User? GetById(int id)
    {
        return users[id];
    }

    public User? GetByName(string name)
    {
        return users.FirstOrDefault(u => u.Name == name);
    }

    public Result<User> GetByEmail(string email)
    {
        var user = users.FirstOrDefault(u => u.Email == email);

        if (user is null)
            return Result.Failure<User>(UserErrors.NotFound(email));
        return user;
    }
}