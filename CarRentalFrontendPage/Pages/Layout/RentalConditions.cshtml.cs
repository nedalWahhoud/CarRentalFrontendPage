using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalFrontendPage.Pages.Layout
{
    public class RentalConditionsModel : PageModel
    {
        public void OnGet()
        {
        }

        public class FeatureItem
        {
            public string Title { get; set; } = string.Empty;
            public List<string> Subtitles { get; set; } = [];
        }
    }
}
