using Express_Management.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Express_Management.Pages.LogAnalytics
{
    [Authorize]
    public class LogAnalyticListModel : PageModel
    {
        public LogAnalyticListModel() { }

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
        }

    }
}
