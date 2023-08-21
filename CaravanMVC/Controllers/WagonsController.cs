using CaravanMVC.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CaravanMVC.Controllers
{
    public class WagonsController : Controller
    {
        private readonly CaravanMvcContext _context;
        public WagonsController(CaravanMvcContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var wagons = _context.Wagons;
            return View(wagons);
        }
    }
}
