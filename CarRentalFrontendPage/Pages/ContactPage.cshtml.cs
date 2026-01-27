using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalFrontendPage.Pages
{
    public class ContactPageModel : PageModel
    {
        
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // ??? ????? ????? ??????? ?? ?????
            TempData["SuccessMessage"] = "Vielen Dank! Ihre Nachricht wurde gesendet.";
            return RedirectToPage();
        }
    }
}
