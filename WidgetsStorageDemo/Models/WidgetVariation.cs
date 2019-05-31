using System.Collections.Generic;

namespace WidgetsStorageDemo.Models
{
    public class WidgetVariation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<WidgetState> States { get; set; }

        public List<WidgetAudience> Audiences { get; set; }
    }
}
