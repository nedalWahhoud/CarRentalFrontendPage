using CarRentalFrontendPage.CarF;
using CarRentalFrontendPage.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalFrontendPage.Pages
{
    public class CarPageModel : PageModel
    {
        private readonly CarService _carService;

        public CarPageModel(CarService carService)
        {
            _carService = carService;
        }

        public Car Car { get; set; } = null!;
        public string RandomImageUrl { get; set; } = string.Empty;
        public string LeftDescription { get; set; } = string.Empty;
        public string RightDescription { get; set; } = string.Empty;

        public async Task OnGetAsync(int id)
        {
            Car = await _carService.GetCarById(id);

            var images = Car.Images?
                .Where(i => !i.IsMain)
                .ToList() ?? new();

            RandomImageUrl = images.Any()
                ? images[new Random().Next(images.Count)].ImageUrl
                : "/CarImages/HeroBanner.webp";

            SplitDescription(Car.Description);
        }

        private void SplitDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return;

            var sentences = description
                .Split('.', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToList();

            LeftDescription = string.Join("",
                sentences.Take(3).Select(s => $"<p>{s}.</p>"));

            RightDescription = string.Join("",
                sentences.Skip(3).Select(s => $"<p>{s}.</p>"));
        }
    }
}
