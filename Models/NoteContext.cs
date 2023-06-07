using Microsoft.EntityFrameworkCore;

namespace api_notez_app.Models;
public class NoteContext : DbContext
{
    public NoteContext(DbContextOptions<NoteContext> options)
        : base(options)
    {
    }

    public DbSet<Note> NoteList { get; set; } = null!;
}