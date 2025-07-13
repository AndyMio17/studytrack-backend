using StudyTracker.Api.Models;

namespace StudyTracker.Api.Services;

public interface ICourseService
{
    IEnumerable<Course> GetAll();
    Course? GetById(Guid id);
    Course Create(Course course);
}

public class CourseService : ICourseService
{
    private readonly List<Course> _courses = [];

    public IEnumerable<Course> GetAll() => _courses;
    public Course? GetById(Guid id) => _courses.FirstOrDefault(c => c.Id == id);
    public Course Create(Course course)
    {
        course.Id = Guid.NewGuid();
        _courses.Add(course);
        return course;
    }
}