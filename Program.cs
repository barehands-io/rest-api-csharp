using MongoDB.Driver;
using webapi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Add MongoDB services to the container
var mongoDBSettings = builder.Configuration.GetSection("MongoDB").Get<MongoDBSettings>();
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    return new MongoClient(mongoDBSettings.ConnectionString);
});


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


