namespace CarRentalFrontendPage.Models
{
    public class CarImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty; 
        public bool IsMain { get; set; } 
        public string ImageType { get; set; } = string.Empty;
        public int CarId { get; set; }
        public string LastModified { get; set; }
        public CarImage()
        {
            LastModified = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }
    }
}
