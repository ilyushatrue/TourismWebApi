global using DataAccess.Data;
using DataAccess.DbAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using TourismWebApi.Configurations;
using TourismWebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IDbAccess,DbAccess>();
builder.Services.AddScoped<UserData>();

builder.Services.Configure<Jwt>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt =>
{
    var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!);
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true, 
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true, 
        ValidAudience = builder.Configuration["Jwt:Audience"],
        RequireExpirationTime = false,
        ValidateLifetime = false,
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.MapPost("/accounts/login", [AllowAnonymous] () =>
//{

//});
app.AddUserEndpoints();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
