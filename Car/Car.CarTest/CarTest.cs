using Car.ApplicationServices.Services;
using Car.Controllers;
using Car.Core.Domain;
using Car.Data;
using Car.Models;
using Microsoft.AspNetCore.Mvc;

namespace Car.CarTest
{
    public class CarTest : TestBase
    {
        private readonly CarsController _controller;
        private readonly CarContext _context;

        public CarTest()
        {
            _context = GetService<CarContext>();
            _controller = new CarsController(GetService<CarServices>());

            _context.Cars.Add(new Vehicle
            {
                Id = 1,
                Build = "Toyota",
                Model = "Camry",
                Year = 2023,
                Deleted = false
            });
            _context.SaveChanges();
        }

        [Fact]
        public async Task Create_ValidCar_RedirectsToIndex()
        {
            var newCar = new CreateCarViewModel
            {
                Build = "Honda",
                Model = "Civic",
                CarType = "Sedan",
                Fuel = "Gasoline",
                Color = "Red",      
                Year = 2024,
                Mileage = 0,
                Doors = 4,
                Seats = 5,
                DailyRate = 50.00m
            };

            var result = await _controller.Create(newCar);
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Single(_context.Cars.Where(c => c.Model == "Civic"));
        }
        [Fact]
        public async Task Delete_ExistingCar_ReturnsDeleteView()
        {
            var result = await _controller.Delete(1);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<DeleteCarViewModel>(viewResult.Model);
        }
        
        [Fact]
        public async Task Details_ExistingId_ReturnsViewWithCar()
        {
            var testCar = await _context.Cars.FindAsync(1);
            testCar.Model = "Camry";
            await _context.SaveChangesAsync();

            var result = await _controller.Details(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<DetailsCarViewModel>(viewResult.Model);
            Assert.Equal("Camry", model.Model);
        }
        [Fact]
        public async Task Edit_ValidUpdate_RedirectsToIndex()
        {
            var updatedCar = new EditCarViewModel
            {
                Id = 1,
                Build = "UpdatedToyota",
                Model = "Camry",
                CarType = "Sedan",
                Fuel = "Gasoline",
                Color = "Red",
                Year = 2023,
                Mileage = 1000,
                Doors = 4,
                Seats = 5,
                DailyRate = 50.00m
            };
            var result = await _controller.Edit(updatedCar);
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            var dbCar = await _context.Cars.FindAsync(1);
            Assert.Equal("UpdatedToyota", dbCar.Build);
        }
    }
    }