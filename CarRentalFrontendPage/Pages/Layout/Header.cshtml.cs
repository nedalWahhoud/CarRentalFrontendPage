using CarRentalFrontendPage.CarF;
using CarRentalFrontendPage.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalFrontendPage.Pages.Layout
{
    public class HeaderModel : PageModel
    {
        private readonly CarService carService;

        public HeaderModel(CarService carService)
        {
            this.carService = carService;
        }

        public string? CurrentPath { get; set; }
        public string CurrentCarName { get; set; } = string.Empty;

        public bool IsCarPage => CurrentPath?.StartsWith("car") == true;

        public void OnGet()
        {
            CurrentPath = Request.Path.Value?.Trim('/');
        }

        public bool IsSelected(string href)
        {
            if (href == "car" && IsCarPage)
                return true;

            return string.Equals(CurrentPath, href, StringComparison.OrdinalIgnoreCase);
        }
    }
}
