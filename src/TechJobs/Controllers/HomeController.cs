using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TechJobs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var actionChoices = new Dictionary<string, string>
            {
                {"search", "Search"}, {"list", "List"}
            };

            ViewBag.actions = actionChoices;

            return View();
        }
    }
}
