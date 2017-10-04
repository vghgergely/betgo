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
        //public Event()
        //{
        //    //AWinsReturn = CompetitorB.Odds / CompetitorA.Odds + 1;
        //    AWinsReturn = OddsB / OddsA + 1;
        //}

        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string CompetitorA { get; set; }
        public string CompetitorB { get; set; }
        [Range(0,1)]
        public double OddsA { get; set; }
        [Range(0,1)]
        public double OddsB { get; set; }

        public double AWinsReturn { get;  set; }
        public EventType Type { get; set; }
    }
}