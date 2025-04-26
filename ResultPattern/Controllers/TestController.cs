using Microsoft.AspNetCore.Mvc;
using ResultPattern.ResultPattern;
using ResultPattern.Users;

namespace ResultPattern.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController(IUserRepository userRepository) : ControllerBase
{
    [HttpGet("email")]
    public async Task<IActionResult> GetId(string email)
    {
        var result = userRepository.GetByEmail(email);

        return result.Match(
            onSuccess: value => Ok(value),
            onFailure: this.Problem);
    }
}