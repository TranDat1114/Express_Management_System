using Express_Management.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Express_Management.Pages.Companies
{
    [Authorize]
    public class CompanyListModel : PageModel
    {
        public CompanyListModel() { }

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();

        }



    }
}
