using Express_Management.Infrastructures.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Express_Management.Pages.VendorCategories
{
    [Authorize]
    public class VendorCategoryListModel : PageModel
    {
        public VendorCategoryListModel() { }

        [TempData]
        public string StatusMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            this.SetupViewDataTitleFromUrl();
            this.SetupStatusMessage();
            StatusMessage = this.ReadStatusMessage();
        }





    }
}
