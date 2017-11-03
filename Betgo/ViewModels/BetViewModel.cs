using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using Betgo.Models;

namespace Betgo.ViewModels
{
    public class BetViewModel
    {
        public BetViewModel()
        {
            
        }
        public BetViewModel(Event events)
        {
            EventId = events.Id;
            CompetitorA = events.CompetitorA;
            CompetitorB = events.CompetitorB;
            AWinsReturn = events.AWinsReturn;
            BWinsReturn = events.BWinsReturn;
        }
        [Required]
        public int EventId { get; set; }
        [Required]
        public Competitor CompetitorA { get; set; }
        [Required]
        public Competitor CompetitorB { get; set; }

        public bool ChosenOption { get; set; }
        public double AWinsReturn { get; set; }
        public double BWinsReturn { get; set; }

        public double Amount { get; set; }
        
    }
}