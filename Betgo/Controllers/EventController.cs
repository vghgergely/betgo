using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Betgo.Models;
using Betgo.ViewModels;
using System.Data.Entity;
using Google.Maps;
using Google.Maps.Geocoding;
using Google.Maps.Places;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

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

            var request = new GeocodingRequest {Address = viewModel.Address, Sensor = false};
            var response = new GeocodingService().GetResponse(request);
            var result = response.Results.First();
            var address = result.FormattedAddress;
            var lon = result.Geometry.Location.Longitude;
            var lat = result.Geometry.Location.Latitude;
            //var placeRequest = new NearbySearchRequest {Radius = 100 ,Location = new LatLng(geoResult.Geometry.Location.Latitude, geoResult.Geometry.Location.Longitude), Sensor = false};
            //var placeResponse = new PlacesService().GetResponse(placeRequest);
            //var address = placeResponse.Results.First().FormattedAddress;

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
                AWinsReturn = compB.Odds / compA.Odds + 1,
                BWinsReturn = compA.Odds / compB.Odds + 1,
                ImageLink = viewModel.ImageLink,
                Address = address,
                Long = lon,
                Lat = lat
            };
            _context.Events.Add(newevent);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
            ;
        }

        
        public ActionResult Details(int eventId)
        {
            var events = _context.Events
                .Include(e => e.CompetitorA)
                .Include(e => e.CompetitorB)
                .Single(e => e.Id == eventId);
            return View(new DetailsViewModel(events));
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int eventId)
        {
            var events = _context.Events.Single(e => e.Id == eventId);
            _context.Events.Remove(events);
            var bets = _context.Bets.Where(b => b.EventId == eventId);
            _context.Bets.RemoveRange(bets);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult CompleteEvents()
        {
            var paying = _context.Events
                .Where(e => e.ActualDateTime < new DateTime(2020,01,01))
                .Where(e => e.PaidOut == false);

            //TODO: REAL DATETIME AND AUTOMATING THE CHECK OF ELAPSED EVENTS

            foreach (var events in paying)
            {
                var bets = _context.Bets.Where(b => b.EventId == events.Id);
                foreach (var bet in bets)
                {
                    var user = _context.Users.Single(u => u.Id == bet.UserId);
                    if(events.Winner == bet.ChosenOption) user.Money += bet.ReturnAmount;
                }
                
                events.PaidOut = true;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AddWinner(int eventId, bool Winner)
        {
            _context.Events.Single(e => e.Id == eventId).Winner = Winner;
            _context.SaveChanges();

            return RedirectToAction("Details", "Event", new {eventId = eventId});
        }
    }
}