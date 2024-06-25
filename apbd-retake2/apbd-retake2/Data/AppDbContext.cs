using apbd_retake2.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_retake.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<ActorMovie> ActorMovies { get; set; }
    public DbSet<AgeRating> AgeRatings { get; set; }
    public DbSet<Movie> Movies { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ActorMovie>().HasKey(am => am.IdActorMovie);

        modelBuilder.Entity<ActorMovie>()
            .HasOne(am => am.Actor)
            .WithMany(a => a.ActorMovies)
            .HasForeignKey(am => am.IdActor);
        
        modelBuilder.Entity<ActorMovie>()
            .HasOne(am => am.Movie)
            .WithMany(a => a.ActorMovies)
            .HasForeignKey(am => am.IdMovie);

        modelBuilder.Entity<ActorMovie>()
            .Property(am => am.CharacterName)
            .HasMaxLength(50)
            .IsRequired();
    }
}