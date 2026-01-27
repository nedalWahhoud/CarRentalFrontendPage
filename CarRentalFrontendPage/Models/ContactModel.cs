using System.ComponentModel.DataAnnotations;

namespace CarRentalFrontendPage.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Name erforderlich")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email erforderlich")]
        [EmailAddress(ErrorMessage = "Ungültige E-Mail-Adresse")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Message erforderlich")]
        public string Message { get; set; } = string.Empty;
    }
}
