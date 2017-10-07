using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Betgo.Models;
using Betgo.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace Betgo.Controllers
{
    public class BetController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Bet
        [Authorize]
        public ActionResult Create(int eventId, bool chosenOption, double amount)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(u => u.Id == userId);
            var events = _context.Events.Single(e => e.Id == eventId);

            if (user.Money < amount)
            {
                //TODO: DISPLAY ALERT
                //ViewBag.Message = "Insufficient funds";
                return RedirectToAction("Details", "Event", new { eventId = events.Id});
            }

            
            double returnValue = 0;
            
            if (chosenOption == false) returnValue = amount * events.AWinsReturn;
            else returnValue = amount * events.BWinsReturn;
           
            
            _context.Bets.Add(new Bet
            {
               Amount = amount,
               UserId = userId,
               ChosenOption = chosenOption,
               EventId = events.Id,
               ReturnAmount = returnValue,
               
            });

            
            user.Money -= amount;
            _context.SaveChanges();
            
            //var events = _context.Events.Single(e => e.Id == viewModel.EventId);
            return RedirectToAction("Details", "Event", new {eventId = events.Id});
        }

        [Authorize]
        public ActionResult MyBets()
        {
            var userId = User.Identity.GetUserId();
            var bets = _context.Bets.Where(b => b.UserId == userId);
            var viewModels = new List<BetDetailsViewModel>();
            foreach (var bet in bets)
            {
                
                viewModels.Add(new BetDetailsViewModel(_context.Events
                    .Include(e => e.CompetitorA)
                    .Include(e => e.CompetitorB)
                    .Single(e => e.Id == bet.EventId), bet));

            }
            return View(viewModels);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int betId)
        {
            var bet = _context.Bets.Single(b => b.Id == betId);
            var events = _context.Events
                .Include(e => e.CompetitorA)
                .Include(e => e.CompetitorB)
                .Single(e => e.Id == bet.EventId);
            return View(new BetDetailsViewModel(events,bet));
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Bet bet)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(u => u.Id == userId);
            var newBet = _context.Bets.Single(b => b.Id == bet.Id);
            user.Money += newBet.Amount;
            if (user.Money < bet.Amount)
            {
                //TODO: ALERT IF INSUFF FUNDS
                return View(bet);
            }

            newBet.Amount = bet.Amount;
            newBet.ChosenOption = bet.ChosenOption;
            if (bet.ChosenOption == false) newBet.ReturnAmount = _context.Events.Single(e => e.Id == bet.EventId).AWinsReturn * bet.Amount;
            else newBet.ReturnAmount = _context.Events.Single(e => e.Id == bet.EventId).BWinsReturn * bet.Amount;
            _context.SaveChanges();
            return RedirectToAction("MyBets", "Bet");
        }

        [Authorize]
        public ActionResult Remove(int betid)
        {
            var userId = User.Identity.GetUserId();
            var bet = _context.Bets.Single(b => b.Id == betid);
            _context.Users.Single(u => u.Id == userId).Money += bet.Amount;
            _context.Bets.Remove(bet);
            _context.SaveChanges();

            return RedirectToAction("MyBets", "Bet");
        }
    }
}