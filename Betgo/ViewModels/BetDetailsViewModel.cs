using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Betgo.Models;

namespace Betgo.ViewModels
{
    public class BetDetailsViewModel
    {
        public BetDetailsViewModel(Event events, Bet bet)
        {
            Bet = bet;
            Event = events;
        }
        public Bet Bet { get; set; }
        public Event Event { get; set; }
    }
}