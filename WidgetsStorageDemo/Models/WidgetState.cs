using System.Collections.Generic;

namespace WidgetsStorageDemo.Models
{
    public class WidgetState
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<WidgetContainer> WidgetContainers { get; set; }
    }
}
