using System;
using System.Web.Mvc;
using Betgo.Models;
using Betgo.ViewModels;

namespace Betgo.Controllers
{
    public class EventController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        [HttpGet]
        public ActionResult Create()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult Create(EventViewModel viewModel)
        {
            Random rnd = new Random();
            double randomOne = rnd.NextDouble();
            var newevent = new Event
            {
                CompetitorA = viewModel.CompA,
                CompetitorB = viewModel.CompB,
                Name = viewModel.Name,
                Date = viewModel.DateTime.Date,
                //Time = DateTime.Parse(viewModel.DateTime.Hour + ":" + viewModel.DateTime.Minute),
                Time = DateTime.Parse("10:00"),
                OddsA = 0.4,
                OddsB = 0.6,
                Type = "meme"
            };
            _context.Events.Add(newevent);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
;        }
    }
}