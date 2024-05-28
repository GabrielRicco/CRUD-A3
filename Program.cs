using Config;
using CrudMongoApp.Repositories;
using CrudMongoApp.Services;
using MongoDB.Driver;
using Repositories;

var builder = WebApplication.CreateBuilder(args); 

var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>(); 
var mongoClient = new MongoClient(mongoDbSettings!.ConnectionString); 
var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.DatabaseName); 

builder.Services.AddSingleton(mongoDatabase); 

builder.Services.AddScoped<IStudentRepository, StudentRepository>(); 
builder.Services.AddScoped<IStudentService, StudentService>(); 

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 

var app = builder.Build(); 


if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
}

app.UseAuthorization(); 

app.MapControllers();

app.Run(); 