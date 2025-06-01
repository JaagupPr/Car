using Car.Core.Domain;

public interface ICarServices
{
    Task<List<Vehicle>> GetAllCarsAsync();
    Task AddCarAsync(Vehicle vehicle);
    Task<Vehicle> GetCarByIdAsync(int id);
    Task UpdateCarAsync(Vehicle vehicle);

}
