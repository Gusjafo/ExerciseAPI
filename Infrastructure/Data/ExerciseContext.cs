using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ExerciseContext(DbContextOptions<ExerciseContext> options) : DbContext(options)
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Aliases> Aliases { get; set; }
        public DbSet<Instructions> Instructions { get; set; }
        public DbSet<PrimaryMuscles> PrimaryMuscles { get; set; }
        public DbSet<SecondaryMuscles> SecondaryMuscles { get; set; }
        public DbSet<Tips> Tips  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrimaryMuscles>(entity =>
            {
                entity.HasOne(e => e.Exercise)
                      .WithMany(m => m.PrimaryMuscles)
                      .HasForeignKey(e => e.ExerciseId);
            });

            modelBuilder.Entity<SecondaryMuscles>(entity =>
            {
                entity.HasOne(e => e.Exercise)
                      .WithMany(m => m.SecondaryMuscles)
                      .HasForeignKey(e => e.ExerciseId);
            });

                
        }
    }
}
