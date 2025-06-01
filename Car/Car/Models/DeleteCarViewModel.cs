namespace Car.Models
{
    public class DeleteCarViewModel
    {
        public int Id { get; set; }
        public string Build { get; set; }
        public string Model { get; set; }
        public string CarType { get; set; } = null!;
        public string Color { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
    }
}
