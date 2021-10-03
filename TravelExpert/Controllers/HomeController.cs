using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TravelExpert.Data;
using TravelExpert.Models;

namespace TravelExpert.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TravelExpertsContext _context;

       //public HomeController(ILogger<HomeController> logger)
       // {
       //     _logger = logger;
       // }

        public HomeController(TravelExpertsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Package> packages = _context.Packages.ToList();
            return View(packages);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
