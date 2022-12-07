using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Prueba.Modelos.Datos;
using Prueba.Modelos.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DemoContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
builder.Services.AddTransient<IRepositorioProducto, RepositorioProducto>();
//services cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
              builder =>
              {
                  builder.WithOrigins("http://localhost/*", "http://localhost:5500/*")
               //   builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                  
                  .AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
              

              });

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
