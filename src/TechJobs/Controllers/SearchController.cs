using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller

    {
        public static string search { get; private set; }

       
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
         
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        
        
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);         
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.columnChoices;
            return View("Index");
        }
    }
}
