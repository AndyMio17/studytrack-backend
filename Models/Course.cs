namespace StudyTrack.Api.Models;

//  Esto es lo que luego se guarda o se muestra en pantalla.
public class Course
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty; // Nombre del curso
    public int Credits { get; set; }

    // Relación con Grade
    public List<Grade> Grades { get; set; } = new();
}
