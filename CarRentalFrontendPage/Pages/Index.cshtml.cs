using CarRentalFrontendPage.CarF;
using CarRentalFrontendPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalFrontendPage.Pages
{
    public class IndexModel : PageModel
    {
        public List<Car> RandomCars { get; set; } = [];

        public async Task OnGetAsync([FromServices] CarService carService)
        {
            RandomCars = await carService.GetAllCarsAsync();
            RandomCars = RandomCars.OrderBy(x => Guid.NewGuid()).Take(2).ToList();
        }
    }
}
