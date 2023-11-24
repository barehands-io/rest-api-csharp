using Bogus;
using webapi.Models; // Add this to use User model
using System.Collections.Generic;

namespace webapi.Services
{
    public class UserSeederService : IHostedService
    {
        private readonly List<User> users;

        public UserSeederService(List<User> users)
        {
            this.users = users;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            SeedUsers(10); // Seed 10 random users at startup

            Console.WriteLine("😒service started here now");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {

            // Cleanup, if needed
            return Task.CompletedTask;
        }

        private void SeedUsers(int count)
        {
            Console.WriteLine( "Start seeding users here now");

            var userFaker = new Faker<User>()
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Password, f => f.Internet.Password());

            for (int i = 0; i < count; i++)
            {
                users.Add(userFaker.Generate());
            }
            
            // print out the users to the console
            
            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user.Name}, Email: {user.Email}, Password: {user.Password}");
            }

        }

    }
}