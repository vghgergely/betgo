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
        public ActionResult Index()
        {
            var upcomingEvents = _context.Events
                .Include(e => e.Type)
                .Where(g => g.ActualDateTime > DateTime.Now);

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