using System.Data.Entity;
using WidgetsStorageDemo.Models;

namespace WidgetsStorageDemo
{
    public class WidgetsContext : DbContext
    {
        public WidgetsContext() : base("WidgetsContext")
        {
        }

        public DbSet<WidgetVariation> WidgetVariations { get; set; }
        public DbSet<WidgetState> WidgetStates { get; set; }
        public DbSet<WidgetContainer> WidgetContainers { get; set; }
        public DbSet<WidgetComponent> WidgetComponents { get; set; }
    }
}
