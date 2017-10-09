using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Betgo.Models;

namespace Betgo.ViewModels
{
    public class CompetitorViewModel
    {
        public string Name { get; set; }
        public string Body { get; set; }
        public int Type { get; set; }
        public double? Odds { get; set; }
        public IEnumerable<EventType> Types { get; set; }
        public string ImageLink { get; set; }

    }
}