using Car.Core.Domain;

public interface ICarServices
{
    Task<List<Vehicle>> GetAllCarsAsync();
}
