using Express_Management.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Express_Management.Pages.LogErrors
{
    [Authorize]
    public class LogErrorListModel : PageModel
    {
        public LogErrorListModel() { }

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
        }

    }
}
