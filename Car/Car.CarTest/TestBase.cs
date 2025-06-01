using Car.ApplicationServices.Services;
using Car.CarTest.Macros;
using Car.CarTest.Mock;
using Car.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Car.CarTest
{
    public abstract class TestBase : IDisposable
    {
        protected IServiceProvider ServiceProvider { get; }

        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        protected T GetService<T>() => ServiceProvider.GetService<T>();

        protected virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<CarServices, CarServices>();
            services.AddScoped<IHostEnvironment, MockIHostEnvironment>();
            services.AddDbContext<CarContext>(options =>
            {
                options.UseInMemoryDatabase("CarTestDb");
                options.ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            RegisterMacros(services);
        }

        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacros);
            var macros = macroBaseType.Assembly.GetTypes()
                .Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddSingleton(macro);
            }
        }

        public void Dispose()
        {
            var context = GetService<CarContext>();
            context.Database.EnsureDeleted();
        }
    }
}