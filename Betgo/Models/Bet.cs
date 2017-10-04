namespace Betgo.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public ApplicationUser Better { get; set; }
        public int EventId { get; set; }
        public char ChosenOption { get; set; }
        public double Amount { get; set; }
        public double ReturnAmount { get; private set; }
    }
}