using System;
using System.Collections.Generic;
using System.Text;

namespace WidgetsStorageDemo.Models
{
    public class WidgetState
    {
        public int Id { get; set; }

        public ICollection<WidgetContainer> WidgetContainers { get; set; }
    }
}
