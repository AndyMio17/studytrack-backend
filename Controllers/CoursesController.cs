using Microsoft.AspNetCore.Mvc;
using StudyTracker.Api.Models;
using StudyTracker.Api.Services;

namespace StudyTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]  // Define el endpoint base: /api/courses.
public class CourseController(ICourseService service) : ControllerBase //Recibe el servicio que creamos como parámetro (lo inyecta automáticamente).
{
    [HttpGet]
    public ActionResult<IEnumerable<Course>> GetAll() => Ok(service.GetAll()); // Cuando haces un GET a /api/courses, responde con la lista de cursos.

    [HttpGet("{id:guid}")]
    public ActionResult<Course> GetById(Guid id)// Cuando haces GET a /api/courses/ID, te devuelve ese curso si existe, o 404 Not Found si no existe.
    {
        var course = service.GetById(id);
        return course is null ? NotFound() : Ok(course);
    }

    [HttpPost]
    public ActionResult<Course> Create([FromBody] Course course)
    // Cuando el frontend o Swagger envía un JSON con nombre y créditos, este método:
    // 1. Genera el ID
    // 2. Guarda el curso
    // 3. Devuelve el curso completo (incluyendo su ID)
    {
        var created = service.Create(course);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}