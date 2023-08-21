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
        [Route("/wagons/{id:int}/passengers")]
        public IActionResult Create(int id, Passenger passenger)
        {
            var wagon = _context.Wagons.Include(w => w.Passengers).First(w => w.Id == id);
            int pId = 0;
            while(_context.Passengers.Select(p => p.Id).Contains(pId))
            {
                pId++;
            }
            passenger.Id = pId;
            passenger.Wagon = wagon;
            _context.Passengers.Add(passenger);
            //wagon.Passengers.Add(passenger);
            //_context.Wagons.Update(wagon);
            _context.SaveChanges();
            return Redirect($"/wagons/{id}");
        }
    }
}
