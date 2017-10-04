using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor;

namespace Betgo.Models
{
    public class Event
    {
        public Event()
        {
            //AWinsReturn = CompetitorB.Odds / CompetitorA.Odds + 1;
            AWinsReturn = OddsB / OddsA + 1;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string CompetitorA { get; set; }
        public string CompetitorB { get; set; }
        public double OddsA { get; set; }
        public double OddsB { get; set; }

        public double AWinsReturn { get; private set; }
        public string Type { get; set; }
    }
}