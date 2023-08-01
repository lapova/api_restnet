using APICrud.BaseDatos;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//configura y agrega el contexto de base de datos "ApiDB" a la aplicación,
//utilizando SQL Server como proveedor de base de datos:
builder.Services.AddDbContext<ApiDB>(options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:dbConn").Value));

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
