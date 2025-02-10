using CharacterVaulBack.Models.Context;
using CharacterVaulBack.Repositories;
using CharacterVaulBack.Repositories.Interfaces;
using CharacterVaulBack.Services;
using CharacterVaulBack.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ConnectionContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAnyOrigin",
        policy =>
        {
            policy.AllowAnyOrigin() //mudar depois
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

//Services
builder.Services.AddTransient<ISheetService, SheetService>();

//Repositories
builder.Services.AddTransient<ISheetRepository, SheetRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
