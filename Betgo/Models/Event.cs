using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Razor;

namespace Betgo.Models
{
    public class Event
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public DateTime ActualDateTime { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        //[Required]
        public Competitor CompetitorA { get; set; }
        //[Required]
        public Competitor CompetitorB { get; set; }
        
        public double OddsA { get; set; }
        
        public double OddsB { get; set; }

        public double AWinsReturn { get;  set; }
        public double BWinsReturn { get; set; }
        public EventType Type { get; set; }

        public string Body { get; set; }
        public string ImageLink { get; set; }
        public bool PaidOut { get; set; }
        public bool Winner { get; set; }
    }
}