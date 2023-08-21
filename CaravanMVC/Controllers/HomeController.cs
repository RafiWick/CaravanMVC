using CaravanMVC.DataAccess;
using CaravanMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CaravanMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CaravanMvcContext _context;

        public HomeController(ILogger<HomeController> logger, CaravanMvcContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OverView()
        {
            ViewData["DistinctDestinations"] = _context.Passengers.Select(p => p.Destination).Distinct().ToList();
            ViewData["AverageAge"] = Convert.ToInt32(_context.Passengers.Select(p => p.Age).Average());
            return View();
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