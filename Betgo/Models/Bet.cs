﻿using System.ComponentModel.DataAnnotations;

namespace Betgo.Models
{
    public class Bet
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public bool ChosenOption { get; set; }
        [Required]
        public double Amount { get; set; }
        public double ReturnAmount { get; set; }
    }
}