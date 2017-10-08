using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Betgo.Models;

namespace Betgo.ViewModels
{
    public class CompetitorDetailsViewModel
    {
        public Competitor Competitor { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public int EventId { get; set; }
    }
}