namespace Car.Core.Domain
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Build { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string CarType { get; set; } = string.Empty;
        public string Fuel { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int Doors { get; set; }
        public int Seats { get; set; }
        public decimal DailyRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool Deleted { get; set; }
    }
}