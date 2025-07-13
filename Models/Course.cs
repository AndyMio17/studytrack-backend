namespace StudyTracker.Api.Models;

public class Course
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Credits { get; set; }
}