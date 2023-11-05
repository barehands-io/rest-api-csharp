

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace webapi.Controllers;

[ApiController]
// [Route("[controller]")]
[Route("car-list")]
public class CarsController : ControllerBase
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }

    // This could come from a database in a real application
    private static readonly List<Car> cars = new List<Car>
    {
        new Car { Make = "Toyota", Model = "Corolla", Year = 2020 },
        new Car { Make = "Honda", Model = "Civic", Year = 2019 },
        new Car { Make = "Ford", Model = "Mustang", Year = 2021 },
        // Add more cars as needed
    };

    [HttpGet]
    public IEnumerable<Car> Get()
    {
        return cars;
    }
    
    // make a post request to this endpoint to add a new car to the list

    [HttpPost]

    public IActionResult Post([FromBody] Car newCar)
    {
        // For now, we just console write the new car details.
        Console.WriteLine($"Make: {newCar.Make}, Model: {newCar.Model}, Year: {newCar.Year}");

        return CreatedAtAction(nameof(Get), new { id = newCar.Year }, newCar);

    }
    
}
