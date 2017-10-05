using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Betgo.Controllers
{
    public class BetController : Controller
    {
        // GET: Bet
        public ActionResult PlaceBet()
        {
            return View();
        }
    }
}