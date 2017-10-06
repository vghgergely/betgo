﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Betgo.Models;
using Betgo.ViewModels;
using Microsoft.AspNet.Identity;

namespace Betgo.Controllers
{
    public class BetController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Bet
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

        
    }
}