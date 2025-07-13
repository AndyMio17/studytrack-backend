namespace StudyTracker.Api.Models;


//  Esto es lo que luego se guarda o se muestra en pantalla.
public class Course
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Credits { get; set; }
}