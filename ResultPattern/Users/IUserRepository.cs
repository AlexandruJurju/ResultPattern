using ResultPattern.ResultPattern;

namespace ResultPattern.Users;

public interface IUserRepository
{
    User AddUser(User user);
    User? GetById(int id);
    User? GetByName(string name);
    Result<User> GetByEmail(string email);
}