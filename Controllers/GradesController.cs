using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyTrack.Api.Data;
using StudyTrack.Api.Models;

namespace StudyTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradesController(StudyTrackContext context) : ControllerBase
{
    // 1) Obtener todas las notas
    [HttpGet]
    public async Task<IEnumerable<Grade>> GetAll() =>
        await context.Grades.AsNoTracking().ToListAsync();

    // 2) Obtener notas de un curso
    [HttpGet("course/{courseId:guid}")]
    public async Task<IEnumerable<Grade>> GetByCourse(Guid courseId) =>
        await context.Grades.Where(g => g.CourseId == courseId)
                            .AsNoTracking().ToListAsync();

    // 3) Registrar una nota
    [HttpPost]
    public async Task<ActionResult<Grade>> Create([FromBody] Grade grade)
    {
        grade.Id = Guid.NewGuid();
        context.Grades.Add(grade);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { }, grade);
    }
}