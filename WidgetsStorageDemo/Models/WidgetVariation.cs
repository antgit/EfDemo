using System;
using System.Collections.Generic;
using System.Text;

namespace WidgetsStorageDemo.Models
{
    public class WidgetVariation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<WidgetState> States { get; set; }
    }
}
