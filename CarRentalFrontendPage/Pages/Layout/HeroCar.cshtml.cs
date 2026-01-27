using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalFrontendPage.Pages.Layout
{
    public class HeroModel : PageModel
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string LastModified { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public HeroCarSubtitle? HeroCarSubtitle { get; set; }
        public HeroMainSubtitle? HeroMainSubtitle { get; set; }

        public void OnGet()
        {
        }
    }

    public class HeroMainSubtitle
    {
        public string Subtitle { get; set; } = string.Empty;
        public string ButtonText { get; set; } = string.Empty;
    }

    public class HeroCarSubtitle
    {
        public string Subtitle { get; set; } = string.Empty;
        public string Subtitle1 { get; set; } = string.Empty;
    }
}
