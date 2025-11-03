using CargoTracker.DataManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CargoTracker.DataManager.Infrastructure.Persistence;

public class CargoTrackerDbContext(DbContextOptions<CargoTrackerDbContext> options) : DbContext(options)
{
    public DbSet<CargoEntity> Cargos => Set<CargoEntity>();
    public DbSet<TrackEntity> Tracks => Set<TrackEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CargoEntity>(entity =>
        {
            entity.ToTable("cargos");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.From).IsRequired().HasMaxLength(200);
            entity.Property(e => e.To).IsRequired().HasMaxLength(200);
            entity.Property(e => e.DepartureAt).IsRequired();
            entity.Property(e => e.EstimatedArrivalAt).IsRequired();
        });

        modelBuilder.Entity<TrackEntity>(entity =>
        {
            entity.ToTable("tracks");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Timestamp).IsRequired();
            entity.Property(e => e.Location).IsRequired().HasMaxLength(400);

            // FK to Cargo
            entity.HasOne<CargoEntity>()
                  .WithMany()
                  .HasForeignKey(t => t.CargoId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
