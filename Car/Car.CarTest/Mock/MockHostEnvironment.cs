using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Car.CarTest.Mock
{
    public class MockIHostEnvironment : IHostEnvironment
    {
        public string EnvironmentName { get; set; } = "Test";
        public string ApplicationName { get; set; } = "Car.Test";
        public string ContentRootPath { get; set; } = Directory.GetCurrentDirectory();
        public IFileProvider ContentRootFileProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }
}