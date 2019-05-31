using Microsoft.EntityFrameworkCore;
using WidgetsStorageDemo.Models;

namespace WidgetsStorageDemo
{
    public class WidgetsContext : DbContext
    {
        public WidgetsContext(DbContextOptions<WidgetsContext> options)
            : base(options)
        {
        }

        public DbSet<WidgetVariation> WidgetVariations { get; set; }
        public DbSet<WidgetAudience> WidgetAudiences { get; set; }
        public DbSet<WidgetState> WidgetStates { get; set; }
        public DbSet<WidgetContainer> WidgetContainers { get; set; }
        public DbSet<WidgetComponent> WidgetComponents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WidgetVariation>()
                .HasMany(x => x.States).WithOne().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WidgetVariation>()
                .HasMany(x => x.Audiences).WithOne().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WidgetState>()
                .HasMany(x => x.WidgetContainers).WithOne().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WidgetContainer>()
                .HasMany(x => x.WidgetComponents).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
