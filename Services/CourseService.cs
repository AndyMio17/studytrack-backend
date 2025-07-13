using StudyTracker.Api.Models;

namespace StudyTracker.Api.Services;

//El CourseService es como una libreta donde vas anotando los cursos que creas.
public interface ICourseService
{
    IEnumerable<Course> GetAll();
    Course? GetById(Guid id);
    Course Create(Course course);
}

public class CourseService : ICourseService
{
    private readonly List<Course> _courses = []; //Esta es una lista en memoria donde se guardan los cursos.

    public IEnumerable<Course> GetAll() => _courses; //Devuelve todos los cursos guardados.
    public Course? GetById(Guid id) => _courses.FirstOrDefault(c => c.Id == id);
    //Busca un curso por su ID. Si no lo encuentra, devuelve null.

    public Course Create(Course course)//Cuando el usuario envía un nuevo curso, esta función lo guarda y devuelve con ID generado.
    {
        course.Id = Guid.NewGuid(); // Genera un ID nuevo
        _courses.Add(course);       // Lo guarda en la lista
        return course;              // Lo devuelve
    }
}