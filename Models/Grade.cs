namespace StudyTrack.Api.Models;

public class Grade
{
    public Guid Id { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public double Value { get; set; }

    // Relación con Course
    public Guid CourseId { get; set; }
    public Course? Course { get; set; }
}