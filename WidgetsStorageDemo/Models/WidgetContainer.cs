using System;
using System.Collections.Generic;
using System.Text;

namespace WidgetsStorageDemo.Models
{
    public class WidgetContainer
    {
        public int Id { get; set; }

        public ICollection<WidgetComponent> WidgetComponents { get;set;}
    }
}
