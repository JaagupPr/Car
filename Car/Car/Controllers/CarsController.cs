using Car.Core.Domain;
using Car.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Car.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarServices _carServices;

        public CarsController(ICarServices carServices)
        {
            _carServices = carServices;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _carServices.GetAllCarsAsync();
            return View(cars.Select(c => new CarViewModel
            {
                Id = c.Id,
                Build = c.Build,
                Model = c.Model,
                CarType = c.CarType,
                Fuel = c.Fuel,
                Color = c.Color,
                Year = c.Year,
                Mileage = c.Mileage,
                Doors = c.Doors,
                Seats = c.Seats,
                DailyRate = c.DailyRate,
                CreatedAt = c.CreatedAt,
                ModifiedAt = c.ModifiedAt
            }));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCarViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var car = new Vehicle
            {
                Build = vm.Build,
                Model = vm.Model,
                CarType = vm.CarType,
                Fuel = vm.Fuel,
                Color = vm.Color,
                Year = vm.Year,
                Mileage = vm.Mileage,
                Doors = vm.Doors,
                Seats = vm.Seats,
                DailyRate = vm.DailyRate
            };

            await _carServices.AddCarAsync(car);
            return RedirectToAction(nameof(Index));
        }

    }
}
