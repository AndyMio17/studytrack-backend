using Microsoft.AspNetCore.Mvc;
using StudyTrack.Api.Models; // Importa el modelo Course
using StudyTrack.Api.Data; // Importa el contexto de la base de datos
using Microsoft.EntityFrameworkCore; // Importa Entity Framework Core para operaciones de base de datos

namespace StudyTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]  // Define el endpoint base: /api/courses.
public class CoursesController(StudyTrackContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetAll() => await context.Courses.ToListAsync();

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Course>> GetById(Guid id)// Cuando haces GET a /api/courses/ID, te devuelve ese curso si existe, o 404 Not Found si no existe.
    {
        var course = await context.Courses.FindAsync(id); // Busca el curso por ID en la base de datos.
        return course is null ? NotFound() : Ok(course); // Si no se encuentra, devuelve 404 Not Found; si se encuentra, devuelve 200 OK con el curso.
    }

    [HttpPost]
    public async Task<ActionResult<Course>> Create([FromBody] Course course) // Cuando haces POST a /api/courses, crea un nuevo curso.
    {
        course.Id = Guid.NewGuid(); // Genera un nuevo ID para el curso.
        context.Courses.Add(course); // Añade el curso al contexto.
        await context.SaveChangesAsync(); // Guarda los cambios en la base de datos.
        return CreatedAtAction(nameof(GetById), new { id = course.Id }, course); // Devuelve 201 Created con la ubicación del nuevo recurso.
    }
}