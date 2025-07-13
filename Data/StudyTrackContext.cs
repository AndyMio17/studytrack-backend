using Microsoft.EntityFrameworkCore;
using StudyTracker.Api.Models;

namespace StudyTrack.Api.Data;
//  Esto define el DbContext: es como la conexión y mapa entre tu código C# y la base de datos.
public class StudyTrackContext : DbContext
{
    public StudyTrackContext(DbContextOptions<StudyTrackContext> options) : base(options){}

    public DbSet<Course> Courses => Set<Course>();
}