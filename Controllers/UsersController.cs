using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private static readonly List<User> users = new List<User>
    {
        new User { Name = "John", Email = "john@gmail.com", Password = "1234" },
        new User { Name = "Mary", Email = "", Password = "1234" },
    };

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        return users;
    }
}