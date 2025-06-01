namespace Car.Models
{
    public class DetailsCarViewModel
    {
        public int Id { get; set; }
        public string Build { get; set; }
        public string Model { get; set; }
        public string CarType { get; set; }
        public string Fuel { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int Doors { get; set; }
        public int Seats { get; set; }
        public decimal DailyRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
