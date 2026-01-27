namespace CarRentalFrontendPage.Models
{
    public class CarRentalPrice
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string PromoText { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string unit { get; set; } = string.Empty;
        public int MaxKm { get; set; }
        public string Type { get; set; } =  string.Empty;
        public int CarId { get; set; }
    }
}
