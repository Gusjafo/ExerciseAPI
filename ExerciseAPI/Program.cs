using Aplication.Interfaces;
using Aplication.Services;
using Infrastructure.Data.Repositories;
using Domain.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    var cacheProfiles = builder.Configuration
                               .GetSection("CacheProfiles")
                               .GetChildren();
    
    foreach (var cacheProfile in cacheProfiles)
    {
        options.CacheProfiles.Add(cacheProfile.Key, cacheProfile.Get<CacheProfile>()!);
    }
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<ExerciseContext>(builder.Configuration.GetConnectionString("ExerciseConnection"));
builder.Services.AddResponseCaching();


builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();

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
app.UseResponseCaching();

app.Run();

