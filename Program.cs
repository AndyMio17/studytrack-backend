using StudyTrack.Api.Data;
using Microsoft.EntityFrameworkCore; // al inicio del archivo

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// 1. Controladores
builder.Services.AddControllers();

// 3. Swagger (explorador + generador)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 4. Esto le dice a ASP.NET Core que: Use StudyTrackContext como proveedor de datos y Use un archivo studytrack.db como base de datos SQLite.
builder.Services.AddDbContext<StudyTrackContext>(options => options.UseSqlite("Data Source=studytrack.db"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita Swagger en modo desarrollo
    app.UseSwaggerUI(); // Habilita la interfaz de usuario de Swagger
}

app.MapControllers(); // Mapea los controladores para manejar las solicitudes HTTP

app.Run(); // Inicia la aplicación

