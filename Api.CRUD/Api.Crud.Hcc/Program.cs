using Api.Crud.Hcc.Models.Context;
using Api.Crud.Hcc.Repositorio.Interfaces.Ordenes;
using Api.Crud.Hcc.Repositorio.Interfaces.Ordenes.Consultas;
using Api.Crud.Hcc.Servicios.Ordenes;
using Api.Crud.Hcc.Servicios.Ordenes.Consultas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
///
var conexionBaseDatos = builder.Configuration.GetSection("ConnectionStrings:ConexionBaseDatos");

builder.Services.AddDbContext<ApiCrudContext>(option => {
    option.UseSqlServer(conexionBaseDatos.Value);
    });

builder.Services.AddScoped<IConsultaOrdenes, ConsultaOrdenes>();
builder.Services.AddScoped<IOrden, Orden>();

//
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
