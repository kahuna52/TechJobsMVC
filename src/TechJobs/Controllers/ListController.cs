using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> columnChoices = new Dictionary<string, string>();

        // This is a "static constructor" which can be used
        // to initialize static members of a class
        static ListController() 
        {
            
            columnChoices.Add("core competency", "Skill");
            columnChoices.Add("employer", "Employer");
            columnChoices.Add("location", "Location");
            columnChoices.Add("position type", "Position Type");
            columnChoices.Add("all", "All");
        }

        public IActionResult Index()
        {
            ViewBag.columns = columnChoices;
            return View();
        }

        public IActionResult Values(string column)
        {
            if (column.Equals("all"))
            {
                var jobs = JobData.FindAll();
                ViewBag.title =  "All Jobs";
                ViewBag.jobs = jobs;
                return View("Jobs");
            }
            else
            {
                var items = JobData.FindAll(column);
                ViewBag.title =  "All " + columnChoices[column] + " Values";
                ViewBag.column = column;
                ViewBag.items = items;
                return View();
            }
        }

        public IActionResult Jobs(string column, string value)
        {
            var jobs = JobData.FindByColumnAndValue(column, value);
            ViewBag.title = "Jobs with " + columnChoices[column] + ": " + value;
            ViewBag.jobs = jobs;

            return View();
        }
    }
}
