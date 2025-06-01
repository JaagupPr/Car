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
    }
}
