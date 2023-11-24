

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MongoDB.Driver;

namespace webapi.Controllers;

[ApiController]

[Route("[controller]")]



public class UsersController : ControllerBase
{



    public class User
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

    // This could come from a database in a real application
    private static readonly List<User> users = new List<User>
    {
        new User { Name = "John", Email = "john@gmail.com", Password = "1234" },
        new User { Name = "Mary", Email = "", Password = "1234" },
    };
    
    //Example of a GET request
    [HttpGet]
    // Example of a GET route
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        return users;
    }
    
}