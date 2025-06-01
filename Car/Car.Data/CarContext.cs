using Car.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Car.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options) { }

        public DbSet<Vehicle> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicles");
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Build).IsRequired().HasMaxLength(50);
                entity.Property(v => v.Model).IsRequired().HasMaxLength(50);
                entity.Property(v => v.DailyRate).HasColumnType("decimal(18,2)");
            });
        }
    }
}