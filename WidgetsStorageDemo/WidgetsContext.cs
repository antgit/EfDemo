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
        public DbSet<WidgetState> WidgetStates { get; set; }
        public DbSet<WidgetContainer> WidgetContainers { get; set; }
        public DbSet<WidgetComponent> WidgetComponents { get; set; }
    }
}
