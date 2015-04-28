using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using System.Security.Principal;

namespace VirtualTrainingTracker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			if (User.Identity.IsAuthenticated)
			{
				ViewBag.UserName = User.Identity.GetUserName();
			}
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}