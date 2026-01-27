namespace CarRentalFrontendPage.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int ManufactureYear { get; set; } = 0;
        public string EngineType { get; set; } = string.Empty;
        public string EnginePower { get; set; } = string.Empty;
        public int MaxSpeed { get; set; } = 0;
        public string TransmissionType { get; set; } = string.Empty;
        public string FuelType { get; set; } = string.Empty;
        public string DriveType { get; set; } = string.Empty;
        public bool IsActive { get; set; } 
        public string Description { get; set; } = string.Empty;
        public ICollection<CarImage>? Images { get; set; }
        public ICollection<CarRentalPrice>? RentalPrices { get; set; }

    }
}
