using FluentValidation.AspNetCore;
using MongoDB.Driver;
using webapi;
using webapi.Services; // Make sure to add this using statement
using webapi.Models; // This too, if you are going to inject List<User>
using Bogus; // If you are using the Faker in the Program.cs

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CarValidator>());

// Add MongoDB services to the container
var mongoDBSettings = builder.Configuration.GetSection("MongoDB").Get<MongoDBSettings>();
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    return new MongoClient(mongoDBSettings.ConnectionString);
});

// Register the UserSeederService as a hosted service
builder.Services.AddHostedService<UserSeederService>();

// If you need to inject a List<User> into the UserSeederService, register it as well
builder.Services.AddSingleton<List<User>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();