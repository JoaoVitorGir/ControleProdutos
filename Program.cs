using Microsoft.EntityFrameworkCore;
using ControleProdutos.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Obtem o nome do computador
var computerName = Environment.MachineName;

// Add services to the container.
var stringConexao = "";

if (computerName == "JOAO_GIRARDI")
{
    stringConexao = builder.Configuration.GetConnectionString("Postgres_Local_Joao");
} else
{
    stringConexao = builder.Configuration.GetConnectionString("Postgres_Local_Welson");
}

//add um if aqui com igual o de cima so mudando o nome do pc e add a tua string de conexao bota break ponte para saber o nome do teu pc


builder.Services.AddDbContext<ControleProdutosContext>(x => x.UseNpgsql(stringConexao));

builder.Services.AddControllers();

//adicionado para poder conectar a api ao meu front-end
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllLocalhost",
        //builder => builder.WithOrigins("http://localhost", "https://localhost")
        builder => builder.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseCors("AllowAllLocalhost");

app.MapControllers();

app.Run();
