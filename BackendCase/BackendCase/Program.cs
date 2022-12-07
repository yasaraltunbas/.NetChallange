using BackendCase.Repositories;
using BackendCase.Repositories.Interfaces;
using LinqToDB.Data;
using Microsoft.OpenApi.Models;
using static BackendCase.DataAccess.DataContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<ISalonRepository, SalonRepository>();
builder.Services.AddScoped<IShowRepository, ShowRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackendCase v1");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
DataConnection.DefaultSettings = new DBContextSettings();

app.Run();
