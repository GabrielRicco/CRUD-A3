using Config;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>();
var mongoClient = new MongoClient(mongoDbSettings?.ConnectionString);
var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings?.DatabaseName); 
builder.Services.AddSingleton(mongoDatabase); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run(); 