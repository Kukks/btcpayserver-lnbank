using LNbank.Services.Settings;
using Microsoft.AspNetCore.Authorization;

namespace LNbank.Pages
{
    [AllowAnonymous]
    public class ErrorModel : BasePageModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public ErrorModel(SettingsService settingsService) : base(settingsService) {}
    }
}
