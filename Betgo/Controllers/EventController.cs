using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Betgo.Models;
using Betgo.ViewModels;

namespace Betgo.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext _context;

        public EventController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            var viewModel = new EventViewModel
            {
                Types = _context.EventTypes.ToList(),
                Competitors = _context.Competitors.ToList()
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Create(EventViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Competitors = _context.Competitors.ToList();
                viewModel.Types = _context.EventTypes.ToList();
                return View("Create", viewModel);
            }
            
            Random rnd = new Random();
            double randomOne = rnd.NextDouble();
            var dt = DateTime.Parse(viewModel.DateTime);
            var type = _context.EventTypes.Single(t => t.Id == viewModel.Type);
            var compA = _context.Competitors.Single(c => c.Id == viewModel.CompA);
            var compB = _context.Competitors.Single(c => c.Id == viewModel.CompB);
            var newevent = new Event
            {
                CompetitorA = compA,
                CompetitorB = compB,
                Name = viewModel.Name,
                ActualDateTime = dt,
                Date = dt.ToShortDateString(),
                Time = dt.ToShortTimeString(),
                OddsA = compA.Odds,
                OddsB = compB.Odds,
                Type = type,
                AWinsReturn = compB.Odds / compA.Odds + 1
            };
            _context.Events.Add(newevent);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
            ;
        }
    }
}