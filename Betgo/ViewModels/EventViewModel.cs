using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Betgo.Models;
using Google.Maps;

namespace Betgo.ViewModels
{
    public class EventViewModel
    {
        [Required]
        public string Name { get; set; }
        [LaterDate]
        [Required]
        public string DateTime { get; set; }
        [Required]
        public int CompA { get; set; }
        [Required]
        public int CompB { get; set; }
        [Required]
        public int Type { get; set; }

        public string ImageLink { get; set; }
        public IEnumerable<EventType> Types { get; set; }
        public IEnumerable<Competitor> Competitors { get; set; }
        public string Address { get; set; }
    }
}