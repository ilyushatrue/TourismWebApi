global using DataAccess.Data;
global using DataAccess.Models;
using DataAccess.DbAccess;
using TourismWebApi;
using TourismWebApi.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISqlDataAccess,SqlDataAccess>();
builder.Services.AddScoped<UserData>();

var app = builder.Build();

//builder.Services.AddAutoMapper(typeof(MappingConfig));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.AddUserEndpoints();

app.UseHttpsRedirection();


app.MapGet("/user", (ILogger<string> logger) => "Hello Word");

app.Run();