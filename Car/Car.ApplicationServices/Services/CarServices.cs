using Car.Core.Domain;
using Car.Data;
using Microsoft.EntityFrameworkCore;

namespace Car.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly CarContext _context;

        public CarServices(CarContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> GetAllCarsAsync()
        {
            return await _context.Cars
                .Where(v => !v.Deleted)
                .ToListAsync();
        }

        public async Task AddCarAsync(Vehicle vehicle)
        {
            vehicle.CreatedAt = DateTime.UtcNow;
            vehicle.ModifiedAt = DateTime.UtcNow;
            vehicle.Deleted = false;

            _context.Cars.Add(vehicle);
            await _context.SaveChangesAsync();

        }
        public async Task<Vehicle> GetCarByIdAsync(int id)
        {
            return await _context.Cars
                .FirstOrDefaultAsync(v => v.Id == id && !v.Deleted);
        }
        public async Task UpdateCarAsync(Vehicle vehicle)
        {
            vehicle.ModifiedAt = DateTime.UtcNow;
            _context.Cars.Update(vehicle);
            await _context.SaveChangesAsync();
        }
    }
}
