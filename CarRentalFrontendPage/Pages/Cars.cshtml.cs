using CarRentalFrontendPage.CarF;
using CarRentalFrontendPage.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalFrontendPage.Pages
{
    public class CarsModel : PageModel
    {
        private readonly CarService _carService;

        public CarsModel(CarService carService)
        {
            _carService = carService;
        }

        public GetItems<Car> GetItems { get; set; } = new GetItems<Car>();

        public async Task OnGetAsync()
        {
            GetItems = await _carService.GetCarsAsync(GetItems);
        }
    }
}
