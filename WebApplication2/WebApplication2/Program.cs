using Microsoft.EntityFrameworkCore;
using WebApplication2.Application.Interfaces.ApplicationDd;
using WebApplication2.Application.Interfaces.Repositories;
using WebApplication2.Infrastucture.ApplicationDd;
using WebApplication2.Infrastucture.Repositories.NotionRepository;
using WebApplication2.Infrastucture.Repositories.userRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<INotionRepository, NotionRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString : builder.Configuration.GetConnectionString("SqlServer")));
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
