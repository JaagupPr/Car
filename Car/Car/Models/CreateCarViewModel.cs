using System.ComponentModel.DataAnnotations;

namespace Car.Models
{
    public class CreateCarViewModel
    {
        [Required(ErrorMessage = "Build is required.")]
        [StringLength(50, ErrorMessage = "Build cannot exceed 50 characters.")]
        public string Build { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [StringLength(50, ErrorMessage = "Model cannot exceed 50 characters.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Car Type is required.")]
        public string CarType { get; set; }

        [Required(ErrorMessage = "Fuel type is required.")]
        public string Fuel { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        public string Color { get; set; }

        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
        public int Year { get; set; }

        [Range(0, 1000000, ErrorMessage = "Mileage must be a positive number.")]
        public int Mileage { get; set; }

        [Range(1, 10, ErrorMessage = "Doors must be between 1 and 10.")]
        public int Doors { get; set; }

        [Range(1, 10, ErrorMessage = "Seats must be between 1 and 10.")]
        public int Seats { get; set; }

        [Range(0.01, 10000.00, ErrorMessage = "Daily rate must be a positive value.")]
        public decimal DailyRate { get; set; }
    }
}