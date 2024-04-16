using Express_Management.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Express_Management.Pages.LogSessions
{
    [Authorize]
    public class LogSessionListModel : PageModel
    {
        public LogSessionListModel() { }

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
        }

    }
}
