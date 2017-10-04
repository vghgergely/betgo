using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Betgo.Models;

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
        public string CompA { get; set; }
        [Required]
        public string CompB { get; set; }
        [Required]
        public int Type { get; set; }
        public IEnumerable<EventType> Types { get; set; }
    }
}