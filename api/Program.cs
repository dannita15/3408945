using Microsoft.EntityFrameworkCore;
using Tienda.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TiendaDbContext>(options =>
 options.UseSqlServer(builder.Configuration
 .GetConnectionString("tiendaConnection")));

builder.Services.AddControllers();

// 👉 AGREGAR: política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirWasm", policy =>
    {
        policy.WithOrigins("http://localhost:5108", "https://localhost:7135")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 👉 AGREGAR: activar la política (debe ir antes de UseAuthorization)
app.UseCors("PermitirWasm");

app.UseAuthorization();

app.MapControllers();

app.Run();