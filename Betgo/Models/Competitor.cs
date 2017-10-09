using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Betgo.Models
{
    public class Competitor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Odds { get; set; }
        [Required]
        public EventType Type { get; set; }

        public string Details { get; set; }
        public string ImageLink { get; set; }
    }
}