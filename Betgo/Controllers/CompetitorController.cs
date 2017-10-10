using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Betgo.Models;
using Betgo.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Betgo.Controllers
{
    public class CompetitorController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Competitor
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            var viewModel = new CompetitorViewModel
            {
                Types = _context.EventTypes.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(CompetitorViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Types = _context.EventTypes.ToList();
                return View("Create", viewModel);
            }

            var type = _context.EventTypes.Single(t => t.Id == viewModel.Type);

            _context.Competitors.Add(new Competitor
            {
                Name = viewModel.Name,
                Odds = (double)viewModel.Odds,
                Details = viewModel.Body,
                Type = type,
                ImageLink = viewModel.ImageLink
            });

            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Details(int compId, int eventId)
        {
            var comp = _context.Competitors.Single(c => c.Id == compId);
            var events = _context.Events
                .Include(e => e.CompetitorA)
                .Include(e => e.CompetitorB)
                .Include(e => e.Type)
                .Where(e => e.CompetitorA.Id == compId || e.CompetitorB.Id == compId);
            return View("Details", new CompetitorDetailsViewModel {Competitor = comp, Events = events, EventId = eventId});
        }
    }
}