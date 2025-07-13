using Microsoft.EntityFrameworkCore;
using StudyTrack.Api.Models;

namespace StudyTrack.Api.Data;
//  Esto define el DbContext: es como la conexión y mapa entre tu código C# y la base de datos.
public class StudyTrackContext : DbContext
{
    public StudyTrackContext(DbContextOptions<StudyTrackContext> options) : base(options) { }

    public DbSet<Course> Courses => Set<Course>();

    public DbSet<Grade> Grades => Set<Grade>(); // DbSet para las calificaciones, que representa una colección de entidades de tipo Grade en la base de datos.
}