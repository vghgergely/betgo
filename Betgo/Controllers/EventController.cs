﻿using System;
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
        public ActionResult Create()
        {
            var viewModel = new EventViewModel
            {
                Types = _context.EventTypes.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(EventViewModel viewModel)
        {
            Random rnd = new Random();
            double randomOne = rnd.NextDouble();
            var type = _context.EventTypes.Single(t => t.Id == viewModel.Type);
            var newevent = new Event
            {
                CompetitorA = viewModel.CompA,
                CompetitorB = viewModel.CompB,
                Name = viewModel.Name,
                Date = viewModel.DateTime.Date,
                Time = DateTime.Parse(viewModel.DateTime.Hour + ":" + viewModel.DateTime.Minute),
                OddsA = randomOne,
                OddsB = 1 - randomOne,
                Type = type,
                AWinsReturn = (1-randomOne) / randomOne + 1
            };
            _context.Events.Add(newevent);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
            ;
        }
    }
}