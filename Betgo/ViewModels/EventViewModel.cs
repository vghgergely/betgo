using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Betgo.Models;

namespace Betgo.ViewModels
{
    public class EventViewModel
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string CompA { get; set; }
        public string CompB { get; set; }
        public int Type { get; set; }
        public IEnumerable<EventType> Types { get; set; }
    }
}