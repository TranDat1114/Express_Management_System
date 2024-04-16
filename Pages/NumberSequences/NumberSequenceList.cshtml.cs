using Express_Management.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Express_Management.Pages.NumberSequences
{
    [Authorize]
    public class NumberSequenceListModel : PageModel
    {
        public NumberSequenceListModel() { }

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
        }

    }
}
