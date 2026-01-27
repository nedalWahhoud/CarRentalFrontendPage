using CarRentalFrontendPage.Models;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace CarRentalFrontendPage.ContactF
{
    public class ContactService(IOptions<ProjectInfo> projectInfo, IJSRuntime JS)
    {
        private readonly IJSRuntime _JS = JS;
        private readonly IOptions<ProjectInfo> _projectInfo = projectInfo;

        public async Task<bool> OpenWhatsApp(string WhatsappMessage)
        {
            try
            {
                await _JS.InvokeVoidAsync("whatsappRedirect.openWhatsApp", _projectInfo.Value.Whatsapp, WhatsappMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task OpenPhoneNumber(string PhoneNumber)
        {
            await JS.InvokeVoidAsync("open", $"tel:{PhoneNumber}", "_self");
        }
    }
}
