using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Betgo.Models;
using System.Data.Entity;

namespace Betgo.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index(string searchTerm = null)
        {
            var upcomingEvents = _context.Events
                .Include(e => e.Type)
                .Include(e => e.CompetitorA)
                .Include(e => e.CompetitorB)
                .Where(g => g.ActualDateTime > DateTime.Now)
                .Where(e => searchTerm == null || e.Name.StartsWith(searchTerm))
                .OrderBy(e => e.ActualDateTime)
                .Take(10);

            return View(upcomingEvents);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}