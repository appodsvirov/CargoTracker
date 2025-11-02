using CargoTracker.DataManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CargoTracker.DataManager.Infrastructure.Persistence;

public class CargoTrackerDbContext(DbContextOptions<CargoTrackerDbContext> options) : DbContext(options)
{
    public DbSet<Cargo> Cargos => Set<Cargo>();
    public DbSet<Track> Tracks => Set<Track>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.ToTable("cargos");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.From).IsRequired().HasMaxLength(200);
            entity.Property(e => e.To).IsRequired().HasMaxLength(200);
            entity.Property(e => e.DepartureAt).IsRequired();
            entity.Property(e => e.EstimatedArrivalAt).IsRequired();

            entity.HasOne(e => e.Track)
                  .WithMany(t => t.Cargos)
                  .HasForeignKey(e => e.TrackId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.ToTable("tracks");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Timestamp).IsRequired();
            entity.Property(e => e.Location).IsRequired().HasMaxLength(400);
        });
    }
}
