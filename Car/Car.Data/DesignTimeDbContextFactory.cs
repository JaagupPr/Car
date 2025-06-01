using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Car.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CarContext>
    {
        public CarContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CarDBs;Trusted_Connection=True;",
                b => b.MigrationsAssembly("Car.Data"));

            return new CarContext(optionsBuilder.Options);
        }
    }
}