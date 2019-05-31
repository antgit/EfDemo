using System.Collections.Generic;

namespace WidgetsStorageDemo.Models
{
    public class WidgetContainer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<WidgetComponent> WidgetComponents { get;set;}
    }
}
