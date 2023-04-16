using Microsoft.EntityFrameworkCore;
using ControleProdutos.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var stringConexao = builder.Configuration.GetConnectionString("Postgres_Unidavi");
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
