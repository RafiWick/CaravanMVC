using CaravanMVC.DataAccess;
using CaravanMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaravanMVC.Controllers
{
    public class PassengersController : Controller
    {
        private readonly CaravanMvcContext _context;
        public PassengersController(CaravanMvcContext context)
        {
            _context = context;
        }
        [Route("/wagons/{id:int}/passengers/new")]
        public IActionResult New(int id)
        {
            var wagon = _context.Wagons.Include(w => w.Passengers).First(w => w.Id == id);
            return View(wagon);
        }
        [HttpPost]
        [Route("/wagons/{wagonId:int}/passengers")]
        public IActionResult Create(int WagonId, Passenger passenger)
        {
            var wagon = _context.Wagons.Include(w => w.Passengers).First(w => w.Id == WagonId);
            passenger.Id = pId;
            passenger.Wagon = wagon;
            _context.Passengers.Add(passenger);
            //wagon.Passengers.Add(passenger);
            //_context.Wagons.Update(wagon);
            _context.SaveChanges();
            return Redirect($"/wagons/{wagonId}");
        }
    }
}
