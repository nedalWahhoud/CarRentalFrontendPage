using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRentalFrontendPage.Pages.Layout
{
    public class TextCardPageModel : PageModel
    {
        public string Icon { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CardStyle Cardstyle { get; set; } = new CardStyle();
        public CardButton? Cardbutton { get; set; }

        public void OnGet()
        {
            
        }

        public class CardStyle
        {
            public string Width { get; set; } = "auto";
            public string Height { get; set; } = "auto";
        }

        public class CardButton
        {
            public string Text { get; set; } = string.Empty;
            public string UriOrValue { get; set; } = string.Empty;
            public ButtonActionType ActionType { get; set; } = ButtonActionType.Navigate;
        }

        public enum ButtonActionType
        {
            Navigate,
            WhatsApp
        }
    }
}
