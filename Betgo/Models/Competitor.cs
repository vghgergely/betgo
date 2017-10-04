using System.Collections.Generic;

namespace Betgo.Models
{
    public class Competitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Odds { get; set; }
        //public List<Event> Events { get; set; }
    }
}