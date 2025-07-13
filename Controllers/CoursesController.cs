using Microsoft.AspNetCore.Mvc;
using StudyTracker.Api.Models;
using StudyTracker.Api.Services;

namespace StudyTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController(ICourseService service) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Course>> GetAll() => Ok(service.GetAll());

    [HttpGet("{id:guid}")]
    public ActionResult<Course> GetById(Guid id)
    {
        var course = service.GetById(id);
        return course is null ? NotFound() : Ok(course);
    }

    [HttpPost]
    public ActionResult<Course> Create([FromBody] Course course)
    {
        var created = service.Create(course);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}