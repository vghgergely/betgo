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
            AWinsReturn = CompetitorB.Odds / CompetitorA.Odds + 1;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public Competitor CompetitorA { get; set; }
        public Competitor CompetitorB { get; set; }
        public double AWinsReturn { get; set; }
        public List<Bet> Bets { get; set; }
        public EventType Type { get; set; }
    }
}