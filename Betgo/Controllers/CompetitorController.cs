using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Betgo.Models;
using Betgo.ViewModels;
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
                Odds = viewModel.Odds,
                Details = viewModel.Details,
                Type = type
            });

            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}